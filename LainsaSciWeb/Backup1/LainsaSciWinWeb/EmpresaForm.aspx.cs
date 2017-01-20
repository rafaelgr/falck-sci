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

public partial class EmpresaForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Empresa empresa = null;
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
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "Empresagrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de EmpresaID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Is it a new record or not?

        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
            LoadData(empresa);
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
            if (newRecord) empresa = new Empresa();
            UnloadData(empresa);
            if (newRecord) ctx.Add(empresa);
            ctx.SaveChanges();
            if (newRecord)
            {
                string url = String.Format("EmpresaTab.aspx?Caller=EmpresaGrid&EmpresaId={0}", empresa.EmpresaId);
                string jCommand = String.Format("closeOpen('{0}','{1}');", url, "EmpresaTab");
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
    protected void LoadData(Empresa empresa)
    {
        txtEmpresaId.Text = empresa.EmpresaId.ToString();
        txtNombre.Text = empresa.Nombre;
        txtCodAx.Text = empresa.CodAx;
        txtPersonaContacto.Text = empresa.PersonaContacto;
        // carga del frame de direcciones
        HtmlControl frm = (HtmlControl)this.FindControl("ifDirecciones");
        HtmlControl frm2 = (HtmlControl)this.FindControl("ifEmails");
        HtmlControl frm3 = (HtmlControl)this.FindControl("ifTelefonos");
        // este lio del caller igual se puede solucionar con el InTab;
        string caller2 = "EmpresaForm";
        if (caller == "EmpresaGrid") caller2 = "EmpresaTab";
        frm.Attributes["src"] = String.Format("DireccionGrid.aspx?EmpresaId={0}&Caller={1}&InFrame=S", empresa.EmpresaId, caller2);
        frm2.Attributes["src"] = String.Format("EmailGrid.aspx?EmpresaId={0}&Caller={1}&InFrame=S", empresa.EmpresaId, caller2);
        frm3.Attributes["src"] = String.Format("TelefonoGrid.aspx?EmpresaId={0}&Caller={1}&InFrame=S", empresa.EmpresaId, caller2);
        //RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifDirecciones');");
    }
    protected void UnloadData(Empresa empresa)
    {
        empresa.Nombre = txtNombre.Text;
        empresa.CodAx = txtCodAx.Text;
        empresa.PersonaContacto = txtPersonaContacto.Text;
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
    #endregion
}
