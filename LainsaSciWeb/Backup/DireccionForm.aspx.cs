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

public partial class DireccionForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    string caller = ""; // who calls the form
    Direccion direccion = null; //
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
        if (Request.QueryString["DireccionId"] != null)
        {
            direccion = CntLainsaSci.GetDireccion(int.Parse(Request.QueryString["DireccionId"].ToString()), ctx);
            LoadData(direccion);
            empresa = direccion.Empresa;
            instalacion = direccion.Instalacion;
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
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "DirectionWithoutOwner"));
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
                direccion = new Direccion();
            UnloadData(direccion);
            if (newRecord)
            {
                ctx.Add(direccion);
            }
            ctx.SaveChanges();
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid2('{0}', 'new', 'ifDirecciones');", caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid2('{0}', 'edit', 'ifDirecciones');", caller));
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

    protected void LoadData(Direccion direccion)
    {
        txtDirPostal.Text = direccion.DirPostal ;
        txtPoblacion.Text = direccion.Poblacion;
        txtCodPostal.Text = direccion.CodPostal;
        txtProvincia.Text = direccion.Provincia ;
        txtPais.Text = direccion.Pais;
        txtDescripcion.Text = direccion.Descripcion;
        if (direccion.Empresa != null)
        {
            lblPropietario.Text = "EMPRESA";
            txtPropietario.Text = direccion.Empresa.Nombre;
        }
        if (direccion.Instalacion != null)
        {
            lblPropietario.Text = "INSTALACION";
            txtPropietario.Text = direccion.Instalacion.Nombre;
        }

    }

    protected void UnloadData(Direccion direccion)
    {
        direccion.DirPostal = txtDirPostal.Text;
        direccion.Poblacion = txtPoblacion.Text;
        direccion.CodPostal = txtCodPostal.Text;
        direccion.Provincia = txtProvincia.Text;
        direccion.Pais = txtPais.Text;
        if (empresa != null)
            direccion.Empresa = empresa;
        if (instalacion != null)
            direccion.Instalacion = instalacion;
        direccion.Descripcion = txtDescripcion.Text;
    }
    #endregion


    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = new Proceso() { Nombre = "DIR", Descripcion = "Direccion" };
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
}