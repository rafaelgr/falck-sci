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

public partial class FabricanteForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null; //
    string caller = ""; // who calls the form
    Fabricante Fabricante = null;
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
            Session["UsuarioId"] = Usuario.UsuarioId;
        //
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "FabricanteGrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de FabricanteID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        
        // Is it a new record or not?
        if (Request.QueryString["FabricanteId"] != null)
        {
            Fabricante = CntLainsaSci.GetFabricante(int.Parse(Request.QueryString["FabricanteId"]), ctx);
            LoadData(Fabricante);
            newRecord = false;
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
            if (newRecord) Fabricante = new Fabricante();
            UnloadData(Fabricante);
            if (newRecord) ctx.Add(Fabricante);
            ctx.SaveChanges();
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');"
                    , caller));
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
    protected void LoadData(Fabricante Fabricante)
    {
        txtFabricanteId.Text = Fabricante.FabricanteId.ToString();
        txtNombre.Text = Fabricante.Nombre;

        CargarEmpresas(Fabricante.Empresa);
        
    }
    protected void UnloadData(Fabricante Fabricante)
    {
        Fabricante.Nombre = txtNombre.Text;
        if(rdcEmpresa.SelectedValue != "") {
            Fabricante.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
        }
       
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
    protected void CargaEmpresa(Empresa empresa) {
        if(empresa == null) return;
        rdcEmpresa.Items.Clear();
        rdcEmpresa.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
        rdcEmpresa.SelectedValue = empresa.EmpresaId.ToString();
        rdcEmpresa.Enabled = false;
    }
    #endregion
    protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e) {

    }

    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e) {
        if(e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach(Empresa empresa in CntLainsaSci.GetEmpresas(e.Text, Usuario, ctx)) {
            combo.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
        }
    }
    protected void CargarEmpresas(Empresa e) {
        rdcEmpresa.Items.Clear();
        foreach(Empresa e1 in CntLainsaSci.GetEmpresas(Usuario, ctx)) {
            rdcEmpresa.Items.Add(new RadComboBoxItem(e1.Nombre, e1.EmpresaId.ToString()));
        }
        if(e == null) {
            rdcEmpresa.Items.Add(new RadComboBoxItem(" ", ""));
            rdcEmpresa.SelectedValue = "";
        } else
            rdcEmpresa.SelectedValue = e.EmpresaId.ToString();

    }
    
}
