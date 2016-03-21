using System;
using System.Linq;
using System.Collections.Generic;
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

public partial class TipoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    TipoDispositivo tipo = null;
    Empresa empresa = null;
    Instalacion instalacion = null;
    int antCaduca = 0;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "Tipogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de TipoID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Is it a new record or not?
        if (Request.QueryString["TipoId"] != null)
        {
            tipo = CntLainsaSci.GetTipoDispositivo(int.Parse(Request.QueryString["TipoId"]), ctx);
            LoadData(tipo);
            newRecord = false;
        }
        else
        {
            newRecord = true;
            CargarEmpresas(null);
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
        try
        {
            if (!DataOk()) return;
            if (newRecord) tipo = new TipoDispositivo();
            UnloadData(tipo);
            if (newRecord) ctx.Add(tipo);
            ctx.SaveChanges();
            if (newRecord)
            {
                string url = String.Format("TipoTab.aspx?Caller=TipoGrid&TipoId={0}", tipo.TipoId);
                string jCommand = String.Format("closeOpen('{0}','{1}');", url, "TipoTab");
                RadAjaxManager1.ResponseScripts.Add(jCommand);
                //RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
            }
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');"
                    , caller));
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
        return true;
    }
    protected void LoadData(TipoDispositivo tipo)
    {
        txtTipoId.Text = tipo.TipoId.ToString();
        txtNombre.Text = tipo.Nombre;
        txtCaducidad.Value = tipo.Caduca;
        antCaduca = tipo.Caduca;
        if (tipo.Empresa != null)
        {
            CargarEmpresas(tipo.Empresa);
        }
        if (tipo.Instalacion != null) 
        {
            CargarInstalaciones(tipo.Instalacion);
        }

        // este lio del caller igual se puede solucionar con el InTab;
    }
    protected void UnloadData(TipoDispositivo tipo)
    {
        tipo.Nombre = txtNombre.Text;
        if (rdcEmpresa.SelectedValue != "") 
            tipo.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
        if (rdcInstalacion.SelectedValue != "")
        {
            tipo.Instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
            tipo.Empresa = tipo.Instalacion.Empresa;
        }
        tipo.Caduca = (int)txtCaducidad.Value;
        if (antCaduca != 0 && antCaduca != tipo.Caduca)
        {
            CntLainsaSci.CambioCaducidad(tipo.Caduca, tipo, ctx);
        }
    }

    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Empresa emp in CntLainsaSci.GetEmpresas(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(emp.Nombre, emp.EmpresaId.ToString()));
        }
    }

    protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        CargarInstalaciones(CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx));
    }

    protected void rdcInstalacion_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Instalacion ins in CntLainsaSci.GetInstalaciones(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(ins.Nombre, ins.InstalacionId.ToString()));
        }
    }

    protected void rdcInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

        //if (rdcInstalacion.SelectedValue != "")
        //{
        //    instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
        //    if (instalacion != null)
        //    {
        //        rdcEmpresa.Items.Clear();
        //        rdcEmpresa.Items.Add(new RadComboBoxItem(instalacion.Empresa.Nombre, instalacion.Empresa.EmpresaId.ToString()));
        //        rdcEmpresa.SelectedValue = instalacion.Empresa.EmpresaId.ToString();
        //    }
        //}
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
    #endregion

    #region Empresas - Instalaciones
    protected void CargarEmpresas(Empresa e)
    {
        rdcEmpresa.Items.Clear();
        foreach (Empresa e1 in CntLainsaSci.GetEmpresas(usuario, ctx))
        {
            rdcEmpresa.Items.Add(new RadComboBoxItem(e1.Nombre, e1.EmpresaId.ToString()));
        }
        if (e == null)
        {
            rdcEmpresa.Items.Add(new RadComboBoxItem(" ", ""));
            rdcEmpresa.SelectedValue = "";
        }
        else
            rdcEmpresa.SelectedValue = e.EmpresaId.ToString();

    }
    protected void CargarInstalaciones(Empresa e)
    {
        rdcInstalacion.Items.Clear();
        IList<Instalacion> l = CntLainsaSci.GetInstalaciones(usuario, ctx);
        l = (from i in l
            where i.Empresa.EmpresaId == e.EmpresaId
            select i).ToList<Instalacion>();

        foreach (Instalacion i1 in l)
        {
            rdcInstalacion.Items.Add(new RadComboBoxItem(i1.Nombre, i1.InstalacionId.ToString()));
        }
        rdcInstalacion.Items.Add(new RadComboBoxItem(" ", ""));
        rdcInstalacion.SelectedValue = "";
        rdcInstalacion.Text = "";
    }
    protected void CargarInstalaciones(Instalacion i)
    {
        rdcInstalacion.Items.Clear();
        rdcInstalacion.Items.Add(new RadComboBoxItem(i.Nombre, i.InstalacionId.ToString()));
        rdcInstalacion.SelectedValue = i.InstalacionId.ToString();
    }
    #endregion



}
