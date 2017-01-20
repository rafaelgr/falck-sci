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

public partial class TelefonoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    string caller = ""; // who calls the form
    Telefono telefono = null; //
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
        if (Request.QueryString["TelefonoId"] != null)
        {
            telefono = CntLainsaSci.GetTelefono(int.Parse(Request.QueryString["TelefonoId"].ToString()), ctx);
            LoadData(telefono);
            empresa = telefono.Empresa;
            instalacion = telefono.Instalacion;
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
            if (Request.QueryString["RevisionId"] != null)
            {
                int instalacionId = int.Parse(Request.QueryString["RevisionId"]);
                instalacion = CntLainsaSci.GetInstalacion(instalacionId, ctx);
                lblPropietario.Text = "INSTALACION";
                txtPropietario.Text = instalacion.Nombre;
            }
            if (empresa == null && instalacion == null)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "TelefonoWithoutOwner"));
                RadNotification1.Show();
            }
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
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
            if (!DataOk())
                return;
            if (newRecord)
                telefono = new Telefono();
            UnloadData(telefono);
            if (newRecord)
            {
                ctx.Add(telefono);
            }
            ctx.SaveChanges();
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid2('{0}', 'new', 'ifTelefonos');", caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid2('{0}', 'edit', 'ifTelefonos');", caller));
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

    protected void LoadData(Telefono telefono)
    {
        txtNumero.Text = telefono.Numero;      
        txtDescripcion.Text = telefono.Descripcion;
        if (telefono.Empresa != null)
        {
            lblPropietario.Text = "EMPRESA";
            txtPropietario.Text = telefono.Empresa.Nombre;
        }
        if (telefono.Instalacion != null)
        {
            lblPropietario.Text = "INSTALACION";
            txtPropietario.Text = telefono.Instalacion.Nombre;
        }
    }

    protected void UnloadData(Telefono telefono)
    {
        telefono.Numero = txtNumero.Text;
        if (empresa != null)
            telefono.Empresa = empresa;
        if (instalacion != null)
            telefono.Instalacion = instalacion;
        telefono.Descripcion = txtDescripcion.Text;
    }
    #endregion


    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = new Proceso() { Nombre = "TEL", Descripcion = "Telefono" };
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
}