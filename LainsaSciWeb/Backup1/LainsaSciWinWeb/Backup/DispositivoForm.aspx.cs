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

public partial class DispositivoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Instalacion instalacion = null; //
    string caller = ""; // who calls the form
    Dispositivo dispositivo = null;
    Dispositivo dispositivoPadre = null;
    bool newRecord = true;
    string modo = "";
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "Dispositivogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de DispositivoID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Mirar si se ha pasado una Instalacion
        if (Request.QueryString["RevisionId"] != null)
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["RevisionId"]), ctx);
            CargarInstalaciones(instalacion);
        }
        else
        {
            CargarInstalaciones(null);
        }
        if (Request.QueryString["DispositivoPadreId"] != null)
        {
            dispositivoPadre = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoPadreId"]), ctx);
            instalacion = CntLainsaSci.GetInstalacion(dispositivoPadre.Instalacion.InstalacionId, ctx);
            CargaInstalacion(instalacion);
        }
        // Is it a new record or not?
        if (Request.QueryString["DispositivoId"] != null)
        {
            dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
            dispositivoPadre = dispositivo.DispositivoPadre;
            // comprobamos los resumenes
            CntLainsaSci.CrearResumenesRevision(dispositivo, ctx);
            LoadData(dispositivo);
            newRecord = false;
        }
        else
        {
            CargarFunciones(null);
            CargarEstados(null);
            CargarTipos(0);
            //CargarModelos(0); // de momento los modelos dependen de los tipos
            CargarFabricantes(0);
            CargarAgentesExtintores(0);
            if (instalacion == null && usuario.Instalacion != null)
            {
                instalacion = usuario.Instalacion;
                CargaInstalacion(instalacion);
            }
        }
        if (Request.QueryString["Modo"] != null)
        {
            modo = Request.QueryString["Modo"];
            if (modo == "S")
            {
                // en silencio
                btnAccept.Visible = false;
            }
        }
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
        //try
        //{
            if (!DataOk())
                return;
            if (newRecord)
                dispositivo = new Dispositivo();
            UnloadData(dispositivo);
            if (newRecord)
            {
                dispositivo.DispositivoPadre = dispositivoPadre;
                ctx.Add(dispositivo);
            }
            ctx.SaveChanges();
            if(newRecord)
                dispositivo = CntLainsaSci.GetLastDispositivo(ctx);

            CntLainsaSci.CrearResumenesRevision(dispositivo, ctx);
            if (newRecord)
            {
                if (dispositivoPadre == null)
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
                else
                {
                    //string keydisp = CntLainsaSci.GetLastDispositivo(ctx).DispositivoId.ToString();
                    string keydisp = dispositivo.DispositivoId.ToString();
                    RadAjaxManager1.ResponseScripts.Add(String.Format("newDispositivo({0});", keydisp));
                }
            }
            else
            {
                //CntLainsaSci.CrearResumenesRevision(dispositivo, ctx);
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
             }
        //}
        //catch (Exception ex)
        //{
        //    ControlDeError(ex);
        //}
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
    #endregion
    #region Auxiliary
    protected bool DataOk()
    {
        if (rdcTipoDisp.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NcTipoDispositivo"));
            RadNotification1.Show();
            return false;
        }
        if (rdcFuncion.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NcFuncion"));
            RadNotification1.Show();
            return false;
        }
        if (rdcEstado.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NcEstado"));
            RadNotification1.Show();
            return false;
        }
        if (rdcInstalacion.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NcInstalacion"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }

    protected void LoadData(Dispositivo dispositivo)
    {
        chkOperativo.Checked = dispositivo.Operativo;
        CargarInstalaciones(dispositivo.Instalacion);
        ////
        //CargaTipos(dispositivo.TipoDispositivo);
        //CargaModelos(dispositivo.ModeloDispositivo);
        //CargaAgenteExtintor(dispositivo.AgenteExtintor);
        //CargaFabricante(dispositivo.Fabricante);
        CargarTipos(dispositivo.TipoDispositivo.TipoId);
        CargarFunciones(dispositivo.Funcion);
        CargarEstados(dispositivo.Estado);
        if (dispositivo.ModeloDispositivo != null)
        CargarModelos(dispositivo.ModeloDispositivo.ModeloId);
        if (dispositivo.Fabricante !=null)
        CargarFabricantes(dispositivo.Fabricante.FabricanteId);
        if (dispositivo.AgenteExtintor != null)
        CargarAgentesExtintores(dispositivo.AgenteExtintor.AgenteExtintorId);
        
        if (!CntLainsaSci.FechaNula(dispositivo.FechaFabricacion))
            dateFfabricacion.SelectedDate = dispositivo.FechaFabricacion;
        if (!CntLainsaSci.FechaNula(dispositivo.FechaCaducidad))
            dateFCaducidad.SelectedDate = dispositivo.FechaCaducidad;

        chkCaducado.Checked = dispositivo.Caducado;
        if (!CntLainsaSci.FechaNula(dispositivo.FechaBaja))
            rdtFechaBaja.SelectedDate = dispositivo.FechaBaja;
        txtComentarios.Text = dispositivo.Comentarios;
        txtPosicion.Text = dispositivo.Posicion;
        txtNombre.Text = dispositivo.Nombre;
        txtNumIndustria.Text = dispositivo.NumeroIndustria;
        txtCodBarras.Text = dispositivo.CodBarras;
        // este lio del caller igual se puede solucionar con el InTab;
        HtmlControl frm = (HtmlControl)this.FindControl("ifRevisiones");
        frm.Attributes["src"] = String.Format("ResumenRevisionGrid.aspx?DispositivoId={0}&Caller={1}&InFrame=S", dispositivo.DispositivoId, "DispositivoForm");
        if (dispositivo.CargaKg != 0) txtCargaKg.Value = (double)dispositivo.CargaKg;
    }

    protected void UnloadData(Dispositivo dispositivo)
    {
        if (rdcInstalacion.SelectedValue != "")
            dispositivo.Instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
        if (rdcTipoDisp.SelectedValue != "")
            dispositivo.TipoDispositivo = CntLainsaSci.GetTiposDispositivo(int.Parse(rdcTipoDisp.SelectedValue), ctx);
        if (rdcModelos.SelectedValue != "")    
            dispositivo.ModeloDispositivo = CntLainsaSci.GetModelodispositivo(int.Parse(rdcModelos.SelectedValue), ctx);
        if (rdcAgenteExtintor.SelectedValue != "")     
            dispositivo.AgenteExtintor = CntLainsaSci.GetAgenteExtintor(int.Parse(rdcAgenteExtintor.SelectedValue), ctx);
        if (rdcFabricante.SelectedValue != "")     
            dispositivo.Fabricante = CntLainsaSci.GetFabricante(int.Parse(rdcFabricante.SelectedValue), ctx);

        if (dateFfabricacion.SelectedDate > DateTime.MinValue)
            dispositivo.FechaFabricacion = (DateTime)dateFfabricacion.SelectedDate;
        else
            dispositivo.FechaFabricacion = DateTime.MinValue;
        // Nuevo cálculo de la caducidad
        if (!CntLainsaSci.FechaNula(dispositivo.FechaFabricacion))
            dispositivo.FechaCaducidad = dispositivo.FechaFabricacion.AddYears(dispositivo.TipoDispositivo.Caduca);
        dispositivo.Funcion = rdcFuncion.SelectedValue;
        dispositivo.Estado = rdcEstado.SelectedValue;
        dispositivo.Comentarios = txtComentarios.Text;
        dispositivo.Posicion = txtPosicion.Text;
        dispositivo.Nombre = txtNombre.Text;
        dispositivo.NumeroIndustria = txtNumIndustria.Text;
        dispositivo.Caducado = chkCaducado.Checked;
        if (dispositivo.Caducado)
        {
            if (rdtFechaBaja.SelectedDate != null)
                dispositivo.FechaBaja = (DateTime)rdtFechaBaja.SelectedDate;
            else
                dispositivo.FechaBaja = DateTime.Now;
            CntLainsaSci.EliminarPendientesDispositivo(dispositivo, ctx);
        }
        else
        {
            dispositivo.FechaBaja = DateTime.Parse("01/01/0001");
        }
        //dispositivo.CodBarras = dispositivo.Nombre;
        dispositivo.CodBarras = txtCodBarras.Text;
        if (dispositivo.Revisiones.Count > 0)
            foreach (Revision r in dispositivo.Revisiones)
                r.CodBarras = dispositivo.CodBarras;
        if (txtCargaKg.Text == "")
        {
            if (dispositivo.ModeloDispositivo != null && dispositivo.ModeloDispositivo.CargaKg != 0)
                dispositivo.CargaKg = dispositivo.ModeloDispositivo.CargaKg;
        }
        else
        {
            // tiene un valor propio
            dispositivo.CargaKg = (decimal)txtCargaKg.Value;
        }
        dispositivo.Operativo = chkOperativo.Checked;
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
    
    protected void CargaInstalacion(Instalacion Instalacion)
    {
        if (Instalacion == null)
        {
            rdcInstalacion.DataSource = CntLainsaSci.GetInstalaciones(ctx);
            rdcInstalacion.DataTextField = "Nombre";
            rdcInstalacion.DataValueField = "RevisionId";
        }
        else
        {
            rdcInstalacion.Items.Clear();
            rdcInstalacion.Items.Add(new RadComboBoxItem(Instalacion.Nombre, Instalacion.InstalacionId.ToString()));
            rdcInstalacion.SelectedValue = Instalacion.InstalacionId.ToString();
        }
        if (caller.Equals("InstalacionTab") || caller.Equals("DispositivoTab"))
            rdcInstalacion.Enabled = false;
    }

    protected void CargaTipos(TipoDispositivo tipo)
    {
        rdcTipoDisp.DataSource = CntLainsaSci.GetTiposDispositivo(ctx);
        rdcTipoDisp.DataTextField = "Nombre";
        rdcTipoDisp.DataValueField = "TipoId";

        if (tipo != null)
        {
            rdcTipoDisp.Items.Add(new RadComboBoxItem(tipo.Nombre, tipo.TipoId.ToString()));
            rdcTipoDisp.SelectedValue = tipo.TipoId.ToString();
        }
    }

    protected void CargaModelos(ModeloDispositivo modelo)
    {
        rdcModelos.DataSource = CntLainsaSci.GetModelodispositivo(ctx);
        rdcModelos.DataTextField = "Nombre";
        rdcModelos.DataValueField = "ModeloId";

        if (modelo != null)
        {
            rdcModelos.Items.Add(new RadComboBoxItem(modelo.Nombre, modelo.ModeloId.ToString()));
            rdcModelos.SelectedValue = modelo.ModeloId.ToString();
        }
    }

    protected void CargaAgenteExtintor(AgenteExtintor agente)
    {
        rdcAgenteExtintor.DataSource = CntLainsaSci.GetModelodispositivo(ctx);
        rdcAgenteExtintor.DataTextField = "Descripcion";
        rdcAgenteExtintor.DataValueField = "AgenteExtintorId";

        if (agente != null)
        {
            rdcAgenteExtintor.Items.Add(new RadComboBoxItem(agente.Descripcion, agente.AgenteExtintorId.ToString()));
            rdcAgenteExtintor.SelectedValue = agente.AgenteExtintorId.ToString();
        }
    }

    protected void CargaFabricante(Fabricante fabricante)
    {
        rdcFabricante.DataSource = CntLainsaSci.GetModelodispositivo(ctx);
        rdcFabricante.DataTextField = "Nombre";
        rdcFabricante.DataValueField = "FabricanteId";

        if (fabricante != null)
        {
            rdcFabricante.Items.Add(new RadComboBoxItem(fabricante.Nombre, fabricante.FabricanteId.ToString()));
            rdcFabricante.SelectedValue = fabricante.FabricanteId.ToString();
        }
    }
    #endregion

    protected void rdcInstalacion_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Instalacion Instalacion in CntLainsaSci.GetInstalaciones(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(Instalacion.Nombre, Instalacion.InstalacionId.ToString()));
        }
    }

    protected void rdcInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    protected void CargarTipos(int id)
    {
        rdcTipoDisp.Items.Clear();
        foreach (TipoDispositivo tp in CntLainsaSci.GetTipoDispositivos(usuario,ctx))
        {
            rdcTipoDisp.Items.Add(new RadComboBoxItem(tp.Nombre, tp.TipoId.ToString()));
        }
        rdcTipoDisp.Items.Add(new RadComboBoxItem(" ",""));
        if (id != 0)
        {
            rdcTipoDisp.SelectedValue = id.ToString();
        }
        else
        {
            rdcTipoDisp.SelectedValue = "";
        }
    }

    protected void CargarModelos(int id)
    {
        rdcModelos.Items.Clear();
        foreach (ModeloDispositivo md in CntLainsaSci.GetModeloDispositivos(usuario, ctx))
        {
            rdcModelos.Items.Add(new RadComboBoxItem(md.Nombre, md.ModeloId.ToString()));
        }
        rdcModelos.Items.Add(new RadComboBoxItem(" ", ""));
        if (id != 0)
        {
            rdcModelos.SelectedValue = id.ToString();
        }
        else
        {
            rdcModelos.SelectedValue = "";
        }
    }
    protected void CargarModelos(TipoDispositivo tdp)
    {
        rdcModelos.Items.Clear();
        foreach (ModeloDispositivo md in tdp.ModelosDispositivo)
        {
            rdcModelos.Items.Add(new RadComboBoxItem(md.Nombre, md.ModeloId.ToString()));
        }
        rdcModelos.Items.Add(new RadComboBoxItem(" ", ""));
        rdcModelos.SelectedValue = "";
    }

    protected void CargarFabricantes(int id)
    {
        rdcFabricante.Items.Clear();
        foreach (Fabricante f in ctx.Fabricantes)
        {
            rdcFabricante.Items.Add(new RadComboBoxItem(f.Nombre, f.FabricanteId.ToString()));
        }
        rdcFabricante.Items.Add(new RadComboBoxItem(" ", ""));
        if (id != 0)
        {
            rdcFabricante.SelectedValue = id.ToString();
        }
        else
        {
            rdcFabricante.SelectedValue = "";
        }
    }

    protected void CargarAgentesExtintores(int id)
    {
        rdcAgenteExtintor.Items.Clear();
        foreach (AgenteExtintor ae in ctx.AgenteExtintors)
        {
            rdcAgenteExtintor.Items.Add(new RadComboBoxItem(ae.Descripcion, ae.AgenteExtintorId.ToString()));
        }
        rdcAgenteExtintor.Items.Add(new RadComboBoxItem(" ", ""));
        if (id != 0)
        {
            rdcAgenteExtintor.SelectedValue = id.ToString();
        }
        else
        {
            rdcAgenteExtintor.SelectedValue = "";
        }
    }

    protected void rdcModelos_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    protected void rdcTipoDisp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rdcTipoDisp.SelectedValue != "")
        {
            TipoDispositivo tipo = CntLainsaSci.GetTipoDispositivo(int.Parse(rdcTipoDisp.SelectedValue), ctx);
            CargarModelos(tipo);
        }
    }

    protected void chkCaducado_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void CargarInstalaciones(Instalacion i) 
    { 
        rdcInstalacion.Items.Clear();
        foreach (Instalacion i1 in CntLainsaSci.GetInstalaciones(usuario, ctx))
        {
            rdcInstalacion.Items.Add(new RadComboBoxItem(i1.Nombre,i1.InstalacionId.ToString()));
        }
        rdcInstalacion.Items.Add(new RadComboBoxItem(" ",""));
        rdcInstalacion.SelectedValue = "";
        if (i != null)
            rdcInstalacion.SelectedValue = i.InstalacionId.ToString();
    }
    public void CargarFunciones(string funcion)
    {
        rdcFuncion.Items.Clear();
        rdcFuncion.Items.Add(new RadComboBoxItem("ORIGINAL","O"));
        rdcFuncion.Items.Add(new RadComboBoxItem("REPUESTO","R"));
        if (funcion == null || funcion == "")
        {
            rdcFuncion.Items.Add(new RadComboBoxItem(" ", ""));
            rdcFuncion.SelectedValue = "";
        }
        else
        {
            rdcFuncion.SelectedValue = funcion;
        }
    }
    public void CargarEstados(string estado)
    {
        rdcEstado.Items.Clear();
        rdcEstado.Items.Add(new RadComboBoxItem("NORMAL", "N"));
        rdcEstado.Items.Add(new RadComboBoxItem("SUSTITUTO", "S"));
        rdcEstado.Items.Add(new RadComboBoxItem("ALMACEN", "A"));
        if (estado == null || estado == "")
        {
            rdcEstado.Items.Add(new RadComboBoxItem(" ", ""));
            rdcEstado.SelectedValue = "";
        }
        else
        {
            rdcEstado.SelectedValue = estado;
        }
    }
}