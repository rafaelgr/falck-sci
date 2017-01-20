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

public partial class EmailForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    string caller = ""; // who calls the form
    Email email = null; //
    Empresa empresa = null;
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
        // Is it a new record or not?
        if (Request.QueryString["EmailId"] != null)
        {
            email = CntLainsaSci.GetEmail(int.Parse(Request.QueryString["EmailId"].ToString()), ctx);
            LoadData(email);
            empresa = email.Empresa;
            instalacion = email.Instalacion;
            newRecord = false;
        }
        else
        {
            if (Request.QueryString["EmpresaId"] != null)
            {
                int empresaId = int.Parse(Request.QueryString["EmpresaId"]);
                empresa = CntLainsaSci.GetEmpresa(empresaId, ctx);
                lblPropietario.Text = "EMPRESA";
                txtPropietario.Text = empresa.Nombre;
            }
            if (Request.QueryString["InstalacionId"] != null)
            {
                int instalacionId = int.Parse(Request.QueryString["InstalacionId"]);
                instalacion = CntLainsaSci.GetInstalacion(instalacionId, ctx);
                lblPropietario.Text = "INSTALACION";
                txtPropietario.Text = instalacion.Nombre;
            }
            if (empresa == null && instalacion == null)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "EmailWithoutOwner"));
                RadNotification1.Show();
            }
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
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
            if (!DataOk())
                return;
            if (newRecord)
                email = new Email();
            UnloadData(email);
            if (newRecord)
            {
                ctx.Add(email);
            }
            ctx.SaveChanges();
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid2('{0}', 'new', 'ifEmails');", caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid2('{0}', 'edit', 'ifEmails');", caller));
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

    protected void LoadData(Email email)
    {
        txtMail.Text = email.Mail;      
        txtDescripcion.Text = email.Descripcion;
        if (email.Empresa != null)
        {
            lblPropietario.Text = "EMPRESA";
            txtPropietario.Text = email.Empresa.Nombre;
        }
        if (email.Instalacion != null)
        {
            lblPropietario.Text = "INSTALACION";
            txtPropietario.Text = email.Instalacion.Nombre;
        }
        chkEnvio.Checked = email.Envio;

    }

    protected void UnloadData(Email email)
    {
        email.Mail = txtMail.Text;
        email.Envio = chkEnvio.Checked;
        if (empresa != null)
            email.Empresa = empresa;
        if (instalacion != null)
            email.Instalacion = instalacion;
        email.Descripcion = txtDescripcion.Text;
    }
    #endregion


    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = new Proceso() { Nombre = "EMA", Descripcion = "Email" };
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
}