using System;
using System.Collections.Generic;
using System.Linq;
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

public partial class SustitucionForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Revision revision = null;
    string caller = ""; // who calls the form
    Sustitucion sustitucion = null, sustitucionRevert = null;
    Empresa empresa = null;
    Instalacion instalacion = null;
    TipoDispositivo tipo = null;
    Programa programa = null;
    bool newRecord = true;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (usuario == null)
            Response.Redirect("Default.aspx");
        else
            Session["UsuarioId"] = usuario.UsuarioId;
        //
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "sustituciongrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de SustitucionDispositivoID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
       
        // Esto es cuando es llamada desde una revisión
        if (Request.QueryString["RevisionId"] != null)
        {
            revision = CntLainsaSci.GetRevision(int.Parse(Request.QueryString["RevisionId"]), ctx);
            if (revision != null)
            {
                Title = String.Format("Sustitución [REV]: {0:dd/MM/yyyy} {1}",
                    revision.FechaPlanificada,
                    CntLainsaSci.GetNomLargo(revision.Dispositivo));
                rdcDispositivoOriginal.Items.Clear();
                rdcDispositivoOriginal.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(revision.Dispositivo),
                    revision.Dispositivo.DispositivoId.ToString()));
                rdcDispositivoOriginal.SelectedValue = revision.Dispositivo.DispositivoId.ToString();
                Session["DispositivoOriginal"] = revision.Dispositivo;
                CargarPosiblesSustitutos(revision.Dispositivo);
            }
        }
        // Is it a new record or not?
        if (Request.QueryString["SustitucionId"] != null)
        {
            sustitucion = CntLainsaSci.GetSustitucion(int.Parse(Request.QueryString["SustitucionId"]), ctx);
            LoadData(sustitucion);
            newRecord = false;
        }
        else
        {
            newRecord = true;
            CargarUsuarios(null);
            CargarEstados("");
        }
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {

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
            if (!DataOk()) return;
            if (newRecord)
            {
                sustitucion = new Sustitucion();
                sustitucionRevert = new Sustitucion();//Aqui
                if(revision != null) {
                    sustitucion.Revision = revision;
                    this.sustitucionRevert.Revision = revision; //Aqui
                }
            }
            UnloadData(sustitucion);

            if(newRecord) {

                if(invData.SelectedDate != null) {
                    this.UnloadDataRevert(this.sustitucionRevert);//Aqui
                }

                if(rbInt.Checked) {
                    string pos = this.sustitucion.DispositivoOriginal.Posicion;
                    this.sustitucion.DispositivoOriginal.Posicion = this.sustitucion.DispositivoSustituto.Posicion;
                    this.sustitucion.DispositivoSustituto.Posicion = pos;

                }
            }

            if(newRecord){
                ctx.Add(sustitucion);
                if(invData.SelectedDate != null) {
                    this.ctx.Add(this.sustitucionRevert);
                }
            }
            ctx.SaveChanges();
            if (revision == null)
            {
                if (newRecord)
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');"
                        , caller));
                else
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');"
                        , caller));
            }
            else
            {
                RadAjaxManager1.ResponseScripts.Add("closeWindow();");
            }
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
        // controlamos los equipos
        Dispositivo dspo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoOriginal.SelectedValue), ctx);
        Dispositivo dsps = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoSustituto.SelectedValue), ctx);
        //if (dspo.Instalacion.InstalacionId != dsps.Instalacion.InstalacionId)
        //{
        //    RadNotification1.Text = "Los dispositivos pertenecen a diferentes instalaciones";
        //    RadNotification1.Show();
        //    return false;
        //}

        //Esto es un ejemplo
        //if(dspo.TipoDispositivo.TipoId != dsps.TipoDispositivo.TipoId) {
        //    RadNotification1.Text = "Los dispositivos son de diferente tipo";
        //    RadNotification1.Show();
        //    return false;
        //}
        if (dspo.AgenteExtintor != dsps.AgenteExtintor)
        {
            RadNotification1.Text = "Los agentes extintores son de distinto tipo";
            RadNotification1.Show();
            return false;
        }

        //Hasta Aqui
        //if (dsps.Estado != "A")
        //{
        //    RadNotification1.Text = "El sustituto no figura en almacen";
        //    RadNotification1.Show();
        //    return false;
        //}
        if (dspo.Estado == "A")
        {
            RadNotification1.Text = "El dispositivo original figura en el almacén";
            RadNotification1.Show();
            return false;
        }
        //if (dsps.Estado == "S")
        //{
        //    RadNotification1.Text = "Los dispositivo sustituto tiene estado 'SUSTITUIDO'";
        //    RadNotification1.Show();
        //    return false;
        //}
        return true;
    }
    protected void LoadData(Sustitucion sustitucion)
    {
        txtSustitucionId.Text = sustitucion.SustitucionId.ToString();
        CargarUsuarios(sustitucion.Usuario);
        CargarEstados(sustitucion.Estado);
        if (!CntLainsaSci.FechaNula(sustitucion.Fecha))
            dtpFecha.SelectedDate = sustitucion.Fecha;
        txtComentarios.Text = sustitucion.Comentarios;
        rdcDispositivoOriginal.Items.Clear();
        Session["DispositivoOriginal"] = sustitucion.DispositivoOriginal;
        rdcDispositivoOriginal.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(sustitucion.DispositivoOriginal),
            sustitucion.DispositivoOriginal.DispositivoId.ToString()));
        rdcDispositivoOriginal.SelectedValue = sustitucion.DispositivoOriginal.DispositivoId.ToString();
        if (sustitucion.DispositivoSustituto != null)
        {
            rdcDispositivoSustituto.Items.Clear();
            rdcDispositivoSustituto.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargo(sustitucion.DispositivoSustituto),
                sustitucion.DispositivoSustituto.DispositivoId.ToString()));
            rdcDispositivoSustituto.SelectedValue = sustitucion.DispositivoSustituto.DispositivoId.ToString();
        }
        else
        {
            CargarPosiblesSustitutos(sustitucion.DispositivoOriginal);
        }
    }
        
    protected void UnloadDataRevert(Sustitucion sustitucion)
    {
        sustitucion.Usuario = CntLainsaSci.GetUsuario(int.Parse(rdcUsuario.SelectedValue), ctx);
        sustitucion.Fecha = (DateTime)invData.SelectedDate;
        sustitucion.DispositivoOriginal = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoSustituto.SelectedValue), ctx);
        sustitucion.DispositivoSustituto = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoOriginal.SelectedValue), ctx);
        sustitucion.Comentarios = txtComentarios.Text;
        sustitucion.Estado = "PROGRAMADA"; // si llega aquí es realizada fijo.
        // control de estados
/*        Dispositivo dspo = sustitucion.DispositivoOriginal;
        Dispositivo dsps = sustitucion.DispositivoSustituto;
        dspo.Estado = "A";
        if (dsps.Funcion == "R")
            dsps.Estado = "S";
        else
            dsps.Estado = "N";
        //Control de posición
/       if (rbInt.Checked)
        {
            string pos_orig = dspo.Posicion;
            dspo.Posicion = dsps.Posicion;
            dsps.Posicion = pos_orig;
        }
 * */
    }

    protected void UnloadData(Sustitucion sustitucion)
    {
        sustitucion.Usuario = CntLainsaSci.GetUsuario(int.Parse(rdcUsuario.SelectedValue), ctx);
        sustitucion.Fecha = (DateTime)dtpFecha.SelectedDate;
        sustitucion.DispositivoOriginal = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoOriginal.SelectedValue), ctx);
        sustitucion.DispositivoSustituto = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoSustituto.SelectedValue), ctx);
        sustitucion.Comentarios = txtComentarios.Text;
        sustitucion.Estado = "REALIZADA"; // si llega aquí es realizada fijo.
        // control de estados
        Dispositivo dspo = sustitucion.DispositivoOriginal;
        Dispositivo dsps = sustitucion.DispositivoSustituto;
        dspo.Estado = "A";
        if (dsps.Funcion == "R")
            dsps.Estado = "S";
        else
            dsps.Estado = "N";
        //Control de posición
/*        if (rbInt.Checked)
        {
            string pos_orig = dspo.Posicion;
            dspo.Posicion = dsps.Posicion;
            dsps.Posicion = pos_orig;
        }
 * */
    }


    protected void rdcTipo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (TipoDispositivo tpd in CntLainsaSci.GetTiposDispositivo(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(tpd.Nombre, tpd.TipoId.ToString()));
        }
    }

    protected void rdcTipo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }


    protected void rdcDispositivoOriginal_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Dispositivo dsp in CntLainsaSci.GetDispositivos(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(dsp), dsp.DispositivoId.ToString()));
        }
    }

    protected void rdcDispositivoOriginal_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Dispositivo dispositivoOriginal;
        if (rdcDispositivoOriginal.SelectedValue != "")
        {
            dispositivoOriginal = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoOriginal.SelectedValue), ctx);
            Session["DispositivoOriginal"] = dispositivoOriginal;
            CargarPosiblesSustitutos(dispositivoOriginal);
        }
    }

    protected void CargarPosiblesSustitutos(Dispositivo dispositivoOriginal)
    {
        // ahora adicionalmente cargamos el desplegable de sustitutos SCI-151
        RadComboBox combo = rdcDispositivoSustituto;
        combo.Items.Clear();
        foreach (Dispositivo dsp in CntLainsaSci.GetPosiblesSustitutos(dispositivoOriginal, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(dsp), dsp.DispositivoId.ToString()));
        }
    }

    
    protected void rdcDispositivoSustituto_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        if (rdcDispositivoOriginal.SelectedValue == "") return;
        Dispositivo dispositivoOriginal = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoOriginal.SelectedValue), ctx);
        if (dispositivoOriginal == null) return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Dispositivo dsp in CntLainsaSci.GetPosiblesSustitutos(e.Text,usuario,dispositivoOriginal,ctx))
        {
            combo.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(dsp), dsp.DispositivoId.ToString()));
        }
    }

    protected void rdcDispositivoSustituto_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
    protected void CargarUsuarios(Usuario u)
    {
        rdcUsuario.Items.Clear();
        foreach (Usuario usu in CntLainsaSci.GetUsuarios(usuario, ctx))
        {
            rdcUsuario.Items.Add(new RadComboBoxItem(usu.Nombre, usu.UsuarioId.ToString()));
        }
        if (u != null)
            rdcUsuario.SelectedValue = u.UsuarioId.ToString();
        else
        {
            rdcUsuario.Items.Add(new RadComboBoxItem(" ", ""));
            rdcUsuario.SelectedValue = "";
        }
    }
    protected void CargarEstados(string estado)
    {
        rdcEstado.Items.Clear();
        rdcEstado.Items.Add(new RadComboBoxItem("PROGRAMADA","PROGRAMADA"));
        rdcEstado.Items.Add(new RadComboBoxItem("REALIZADA", "REALIZADA"));
        if (estado == "")
        {
            rdcEstado.Items.Add(new RadComboBoxItem("", ""));
            rdcEstado.SelectedValue = "";
        }
        else
        {
            rdcEstado.SelectedValue = estado;
        }

    }
    #endregion
}
