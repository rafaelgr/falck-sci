using System;
using System.Web;
using System.Web.UI;
using LainsaSciModelo;
using LainsaSciWinWeb;
using Telerik.OpenAccess;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Collections.Generic;
using System.Linq;

public partial class RevisionForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    string inTab = "";
    string modo = "";
    Revision revision = null;
    Dispositivo dispositivo = null;
    bool newRecord = true;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (Usuario == null)
            Response.Redirect("Default.aspx");
        else
        {
            Session["UsuarioId"] = Usuario.UsuarioId;
            CargaOperario(Usuario);
        }
        //
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "DispositivoGrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        if (Request.QueryString["InTab"] != null)
        {
            inTab = Request.QueryString["InTab"];
        }
        // Si esto no va antes de RevisionID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        if (Request.QueryString["DispositivoId"] != null)
        {
            dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
            txtDispositivo.Text = dispositivo.Nombre;
        }
        // Is it a new record or not?
        if (Request.QueryString["RevisionId"] != null)
        {
            revision = CntLainsaSci.GetRevision(int.Parse(Request.QueryString["RevisionId"]), ctx);
            dispositivo = revision.Dispositivo;
            LoadData(revision);
            this.Title = String.Format("Revision: ");
            newRecord = false;
        }
        if (Request.QueryString["Modo"] != null)
        {
            modo = Request.QueryString["Modo"];
            if (modo == "S")
            {
                // en silencio
                btnAccept.Visible = false;
                btnSustitucion.Visible = false;
            }
        }
        //if (revision.Estado == "PROGRAMADA")
        //    crearPlantilla();
        //else if (revision.Estado == "REALIZADA")
        //    cargarPlantilla();
        cargarPlantilla();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (revision != null)
            {
                if (revision.CaduProx && !revision.Dispositivo.Caducado)
                {
                    string mensaje = String.Format((string)GetGlobalResourceObject("ResourceLainsaSci", "CaducidadProxima"),
                        revision.Dispositivo.FechaCaducidad);
                    mensaje = String.Format("<b>{0}</b><br/>{1}",
                        (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                        mensaje);
                    string jCommand = String.Format("confirmar('{0}','{1:dd/MM/yyyy}');", mensaje, DateTime.Now);
                    RadAjaxManager1.ResponseScripts.Add(jCommand);
                }
                if (revision.Sustitucions.Count > 0)
                {
                    string mensaje = String.Format("Hay {0} sustituciones asociadas a esta revisión puede acceder a ellas haciendo clic en el botón inferior.",
                        revision.Sustitucions.Count);
                    RadWindowManager1.RadAlert(mensaje, 330, 110, "AVISO", "retornoAlert");
                    //string jCommand = String.Format("radalert('{0}');", mensaje);
                    //RadAjaxManager1.ResponseScripts.Add(jCommand);
                }
            }
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion
    #region Actions
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!DataOk())
                return;
            if (newRecord)
                revision = new Revision();
            UnloadData(revision);
            CntLainsaSci.CTXGuardar(ctx);

            CntLainsaSci.EliminarInferiores(revision, ctx);
            CntLainsaSci.ProgramarSiguienteRevision(revision, ctx, true);
            CntLainsaSci.ProgramarInferiores(revision, ctx);
  
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
        }
        catch (Exception ex)
        {
            ControlDeError(ex);
        }
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
    #endregion
    #region Auxiliary
    protected bool DataOk()
    {
        if (txtResultado.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        if (rdpFechaRevision.SelectedDate == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                (string)GetGlobalResourceObject("ResourceLainsaSci", "FechaRevisionNeeded"));
            RadNotification1.Show();
            return false;
        }
        // Hay que controlar si hay un cambio programado pendiente
        if (revision != null)
        {
            Sustitucion sus = (from s in revision.Sustitucions
                               where s.Estado == "PROGRAMADA"
                               select s).FirstOrDefault<Sustitucion>();
            if (sus != null)
            {
                RadNotification1.Text = "Hay un cambio programado pendiente, hágalo antes de cerrar la revisión";
                RadNotification1.Show();
                return false;
            }
            // Ha habido un cambio?
            if (revision.Sustitucions.Count == 1)
            {
                // Preguntamos si quiere hacer descambio
                string mens = "El dispositivo de esta revisión fué cambiado por un sustituto ¿Desea descambiar los dispositivos?";
                RadWindowManager1.RadConfirm(mens, "retornoConfirm", 330, 110, null, "DESCAMBIO");
                return false;
            }
        }
        //if (rdpFechaRevision.SelectedDate < rdpFechaPlanificada.SelectedDate)
        //{
        //    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
        //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
        //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "RevisionMenosPlanificacion"));
        //    RadNotification1.Show();
        //    return false;
        //}

        return true;
    }

    protected void LoadData(Revision revision)
    {
        txtRevisionId.Text = revision.RevisionId.ToString();
        if (!CntLainsaSci.FechaNula(revision.FechaPlanificada))
            rdpFechaPlanificada.SelectedDate = revision.FechaPlanificada;
        if (!CntLainsaSci.FechaNula(revision.FechaProgramada))
            rdpFechaProgramada.SelectedDate = revision.FechaProgramada;
        if (!CntLainsaSci.FechaNula(revision.FechaRevision))
            rdpFechaRevision.SelectedDate = revision.FechaRevision;
        else
            rdpFechaRevision.SelectedDate = DateTime.Now;
        CargaOperario(revision.Usuario);
        txtResultado.Text = revision.Resultado;
        txtObservaciones.Text = revision.Observaciones;
        txtDispositivo.Text = revision.Dispositivo.Nombre;
        txtPlantilla.Text = revision.PlantillaRevision.Descripcion;
        txtStatus.Text = revision.Estado;
    }

    protected void UnloadData(Revision revision)
    {
        revision.FechaRevision = (DateTime)rdpFechaRevision.SelectedDate;
        revision.Resultado = txtResultado.Text;
        revision.Observaciones = txtObservaciones.Text;
        revision.Usuario = CntLainsaSci.GetUsuario(int.Parse(rdcOperario.SelectedValue), ctx);
        leerDatos();
        revision.ResumenInforme = CntLainsaSci.GetResumenInforme(revision, ctx);
        revision.Estado = "REALIZADA";
        if (revision.Programa != null)
            revision.Programa.Estado = CntLainsaSci.EstadoPrograma(revision.Programa);
    }

    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = Usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }

    protected void CargaOperario(Usuario operario)
    {
        if (operario == null)
            return;
        rdcOperario.Items.Clear();
        rdcOperario.Items.Add(new RadComboBoxItem(operario.Nombre, operario.UsuarioId.ToString()));
        rdcOperario.SelectedValue = operario.UsuarioId.ToString();
        rdcOperario.Enabled = false;
    }
    #endregion

    protected void rdcOperario_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    protected void rdcOperario_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        //foreach (Operario usuario in )
        //{
        //    combo.Items.Add(new RadComboBoxItem(usuario.Nombre, usuario.OperarioId.ToString()));
        //}
    }

    protected void crearPlantilla()
    {
        //IList<Campo> listaCampos = revision.PlanificacionRevision.PlantillaRevision.Campos;
        //IEnumerable<Campo> sortedEnum = listaCampos.OrderBy(f => f.Posicion);
        //IList<Campo> campos = sortedEnum.ToList();
        //foreach (Campo item in campos)
        //{
        //    Plantilla.Rows.Add(crearFila(item));
        //}
    }

    protected void cargarPlantilla()
    {
        foreach (DatosRevision item in revision.DatosRevisions.OrderBy(f => f.Campo.Posicion))
        {
            string tipo = item.Campo.TipoCampo.Descripcion;
            switch (tipo)
            {
                case "Campo Si/No":
                    CampoSN csn = (CampoSN)LoadControl("~/CampoSN.ascx");
                    csn.ID = item.DatosId.ToString();
                    csn.SetNombre(item.Campo.Nombre);
                    csn.SetValor(item.Valor);
                    PlantillaHolder.Controls.Add(csn);
                    break;
                case "Texto":
                    CampoText ctxt = (CampoText)LoadControl("~/CampoText.ascx");
                    ctxt.ID = item.DatosId.ToString();
                    ctxt.SetNombre(item.Campo.Nombre);
                    ctxt.SetValor(item.Valor);
                    PlantillaHolder.Controls.Add(ctxt);
                    break;
                case "Tetra":
                    CampoTetra ctt = (CampoTetra)LoadControl("~/CampoTetra.ascx");
                    ctt.ID = item.DatosId.ToString();
                    ctt.SetNombre(item.Campo.Nombre);
                    ctt.SetValor(item.Valor);
                    PlantillaHolder.Controls.Add(ctt);
                    break;
                case "Numerico":
                    CampoNum cnum = (CampoNum)LoadControl("~/CampoNum.ascx");
                    cnum.ID = item.DatosId.ToString();
                    cnum.SetNombre(item.Campo.Nombre);
                    cnum.SetValor(item.Valor);
                    PlantillaHolder.Controls.Add(cnum);
                    break;
                case "Fecha":
                    CampoDate cdt = (CampoDate)LoadControl("~/CampoDate.ascx");
                    cdt.ID = item.DatosId.ToString();
                    cdt.SetNombre(item.Campo.Nombre);
                    cdt.SetValor(item.Valor);
                    PlantillaHolder.Controls.Add(cdt);
                    break;
            }
        }
    }

    protected void leerDatos()
    {
        foreach (Control control in PlantillaHolder.Controls)
        {
            string tipo = control.GetType().ToString();
            int id = int.Parse(control.ID);
            DatosRevision dr = (from d in revision.DatosRevisions
                                where d.DatosId == id
                                select d).FirstOrDefault<DatosRevision>();
            if (dr != null)
            {
                switch (tipo)
                {
                    case "ASP.camposn_ascx":
                        CampoSN csn = (CampoSN)control;
                        dr.Valor = csn.GetValor();
                        break;
                    case "ASP.campotext_ascx":
                        CampoText ctxt = (CampoText)control;
                        dr.Valor = ctxt.GetValor();
                        break;
                    case "ASP.camponum_ascx":
                        CampoNum cnum = (CampoNum)control;
                        dr.Valor = cnum.GetValor();
                        break;
                    case "ASP.campodate_ascx":
                        CampoDate cdt = (CampoDate)control;
                        dr.Valor = cdt.GetValor();
                        break;
                    case "ASP.campotetra_ascx":
                        CampoTetra ctetra = (CampoTetra)control;
                        dr.Valor = ctetra.GetValor();
                        break;
                }
                dr.Revision = revision;
            }
        }
        ctx.SaveChanges();
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        string valor = e.Argument;
        string tipo = valor.Substring(0, 1);
        valor = valor.Substring(1);
        switch (tipo)
        {
            case "A":
                DateTime fechaBaja;
                if (DateTime.TryParse(valor, out fechaBaja))
                {
                    revision.Dispositivo.Caducado = true;
                    revision.Dispositivo.FechaBaja = fechaBaja;
                    ctx.SaveChanges();
                    CntLainsaSci.EliminarRevisionesPendientes(revision.Dispositivo, ctx, revision);
                    string mensaje = String.Format("El dispositivo ha sido dado de baja con fecha {0:dd/MM/yyyy}", fechaBaja);
                    RadWindowManager1.RadAlert(mensaje, 330, 110, "DADO DE BAJA", "retornoAlert");
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
                    //string jCommand = String.Format("radalert('{0}');", mensaje);
                    //RadAjaxManager1.ResponseScripts.Add(jCommand);
                }
                else
                {
                    string mensaje = (string)GetGlobalResourceObject("ResourceLainsaSci", "DateNeeded");
                    mensaje = "La fecha introducida es incorrecta";
                    RadWindowManager1.RadAlert(mensaje, 330, 110, "AVISO", "retornoAlert");
                    //string jCommand = String.Format("radalert('{0}');", mensaje);
                    //RadAjaxManager1.ResponseScripts.Add(jCommand);
                }
                break;
            case "B":
                if (valor == "true")
                {
                    // quiere descambiar
                    Sustitucion s = revision.Sustitucions[0]; // solo tiene que estar el cambio inicial
                    Sustitucion ns = new Sustitucion()
                    {
                        DispositivoOriginal = s.DispositivoSustituto,
                        DispositivoSustituto = s.DispositivoOriginal,
                        Fecha = DateTime.Now,
                        Revision = revision
                    };
                    ns.Estado = "REALIZADA"; // si llega aquí es realizada fijo.
                    // control de estados
                    Dispositivo dspo = ns.DispositivoOriginal;
                    Dispositivo dsps = ns.DispositivoSustituto;
                    dspo.Estado = "A";
                    if (dsps.Funcion == "R")
                        dsps.Estado = "S";
                    else
                        dsps.Estado = "N";
                    dsps.Posicion = dsps.Posicion;
                    dspo.Posicion = "SUSTITUIDOS";
                    ctx.Add(ns);
                }
                else
                {
                    Sustitucion s = revision.Sustitucions[0]; // solo tiene que estar el cambio inicial
                    s.DispositivoOriginal.Funcion = "R";
                }
                // Como si hubiera pulsado el botón.
                UnloadData(revision);
                CntLainsaSci.CTXGuardar(ctx);

                CntLainsaSci.EliminarInferiores(revision, ctx);
                CntLainsaSci.ProgramarSiguienteRevision(revision, ctx, true);
                CntLainsaSci.ProgramarInferiores(revision, ctx);
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
                break;
        }
    }

    protected void btnSustitucion_Click(object sender, ImageClickEventArgs e)
    {
        string url = "";
        string jCommand = "";
        if (revision == null)
            return;
        if (revision.Sustitucions.Count == 0)
        {
            // este es el caso de que quiere hacer un cambio dentro de una revisión.
            url = String.Format("SustitucionForm.aspx?RevisionId={0}", revision.RevisionId);
            jCommand = String.Format("openOutSide('{0}','{1}');", url, "SustitucionForm");
            RadAjaxManager1.ResponseScripts.Add(jCommand);
        }
        else
        {
            url = String.Format("SustitucionGrid.aspx?RevisionId={0}", revision.RevisionId);
            jCommand = String.Format("openOutSide('{0}','{1}');", url, "SustitucionGrid");
            RadAjaxManager1.ResponseScripts.Add(jCommand);
        }
    }
}