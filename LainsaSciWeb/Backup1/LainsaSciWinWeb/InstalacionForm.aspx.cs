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

public partial class InstalacionForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null; //
    string caller = ""; // who calls the form
    string inTab = "";
    Instalacion instalacion = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "Instalaciongrid", ctx);
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
        // Si esto no va antes de InstalacionID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Mirar si se ha pasado una empresa
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
            CargaEmpresa(empresa);
        }
        // Is it a new record or not?
        if (Request.QueryString["RevisionId"] != null)
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["RevisionId"]), ctx);
            LoadData(instalacion);
            this.Title = String.Format("Instalacion: {0}", instalacion.Nombre);
            newRecord = false;
        }
        else
        {
            CargarEmpresas(null);
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
            if (newRecord) instalacion = new Instalacion();
            UnloadData(instalacion);
            if (newRecord) ctx.Add(instalacion);
            ctx.SaveChanges();
            if (newRecord)
            {
                string url = String.Format("InstalacionTab.aspx?Caller=InstalacionGrid&RevisionId={0}", instalacion.InstalacionId);
                string jCommand = String.Format("closeOpen('{0}','{1}');", url, "InstalacionTab");
                RadAjaxManager1.ResponseScripts.Add(jCommand);
                //RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');"
                //    , caller));
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
        if (txtNombre.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }
    protected void LoadData(Instalacion instalacion)
    {
        txtInstalacionId.Text = instalacion.InstalacionId.ToString();
        txtNombre.Text = instalacion.Nombre;
        txtCodAx.Text = instalacion.CodAx;
        CargarEmpresas(instalacion.Empresa);
        // carga del frame de direcciones
        HtmlControl frm = (HtmlControl)this.FindControl("ifDirecciones");
        HtmlControl frm2 = (HtmlControl)this.FindControl("ifEmails");
        HtmlControl frm3 = (HtmlControl)this.FindControl("ifTelefonos");
        // este lio del caller igual se puede solucionar con el InTab;
        string caller2 = "InstalacionForm";
        if (inTab == "S") caller2 = "InstalacionTab";
        frm.Attributes["src"] = String.Format("DireccionGrid.aspx?RevisionId={0}&Caller={1}&InFrame=S", instalacion.InstalacionId, caller2);
        frm2.Attributes["src"] = String.Format("EmailGrid.aspx?RevisionId={0}&Caller={1}&InFrame=S", instalacion.InstalacionId, caller2);
        frm3.Attributes["src"] = String.Format("TelefonoGrid.aspx?RevisionId={0}&Caller={1}&InFrame=S", instalacion.InstalacionId, caller2);
        //RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifDirecciones');");
    }
    protected void UnloadData(Instalacion instalacion)
    {
        instalacion.Nombre = txtNombre.Text;
        instalacion.CodAx = txtCodAx.Text;
        instalacion.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
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
    protected void CargaEmpresa(Empresa empresa)
    {
        if (empresa == null) return;
        rdcEmpresa.Items.Clear();
        rdcEmpresa.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
        rdcEmpresa.SelectedValue = empresa.EmpresaId.ToString();
        rdcEmpresa.Enabled = false;
    }
    #endregion

    protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Empresa empresa in CntLainsaSci.GetEmpresas(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
        }
    }
    protected void CargarEmpresas( Empresa e) 
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
}
