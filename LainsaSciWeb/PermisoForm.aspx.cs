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

public partial class PermisoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    string caller = ""; // who calls the form
    Permiso permiso = null;
    bool newRecord = true;
    // 
    GrupoUsuario grupoUsuario = null;
    Proceso proceso = null;
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
        // Is it a new record or not?
        if (Request.QueryString["PermisoId"] != null)
        {
            permiso = CntLainsaSci.GetPermiso(int.Parse(Request.QueryString["PermisoId"]), ctx);
            LoadData(permiso);
            newRecord = false;
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
        }
        if (Request.QueryString["GrupoUsuarioId"] != null)
        {
            grupoUsuario = CntLainsaSci.GetGrupoUsuario(int.Parse(Request.QueryString["GrupoUsuarioId"]), ctx);
        }
        if (Request.QueryString["Nombre"] != null)
        {
            proceso = CntLainsaSci.GetProceso(Request.QueryString["Nombre"].ToString(), ctx);
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
                permiso = new Permiso();
            UnloadData(permiso);
            if (newRecord)
                ctx.Add(permiso);
            ctx.SaveChanges();
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
        return true;
    }

    protected void LoadData(Permiso permiso)
    {
        txtPermisoId.Text = permiso.PermisoId.ToString();
        txtProceso.Text = permiso.Proceso.Nombre;
        txtGrupo.Text = permiso.GrupoUsuario.Nombre;
        // permisos propiamente dicho
        chkVer.Checked = permiso.Ver;
        chkCrear.Checked = permiso.Crear;
        chkModificar.Checked = permiso.Modificar;
        chkEspecial.Checked = permiso.Especial;
    }

    protected void UnloadData(Permiso permiso)
    {
        // solamente son modificables los permisos
        permiso.Ver = chkVer.Checked;
        permiso.Crear = chkCrear.Checked;
        permiso.Modificar = chkModificar.Checked;
        permiso.Especial = chkEspecial.Checked;
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