using System;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class UsuarioExtranetTab : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario Usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    int usuarioExtranetId = 0;
    UsuarioExtranet uext = null;
    Empresa empresa = null;
    Instalacion instalacion = null;
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
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
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "UsuarioExtranetGrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        if (Request.QueryString["Mode"] != null)
            mode = Request.QueryString["Mode"];
        if (Request.QueryString["Caller"] != null)
            caller = Request.QueryString["Caller"];
        RadTabStrip1.Tabs[1].Visible = false;
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
        }
        if (Request.QueryString["RevisionId"] != null)
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["RevisionId"]), ctx);
        }
        if (Request.QueryString["UsuarioExtranetId"] != null)
        {
            usuarioExtranetId = int.Parse(Request.QueryString["UsuarioExtranetId"]);
            uext = CntLainsaSci.GetUsuarioExtranet(usuarioExtranetId, ctx);
            this.Title = String.Format("Usuario: {0}", uext.Nombre);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) NavegaFrame("general");
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["UsuarioExtranetGrid"] = null;
    }
    #endregion

    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        NavegaFrame(e.Tab.Value);
    }
    protected void NavegaFrame(string value)
    { 
        // obtenemos el frame en el que se muestran las páginas.
        HtmlControl frame = (HtmlControl)this.FindControl("ifTabUsuarioExtranet");
        string url = "";
        // el valor de value en el tab indica lo que queremos mostrar en el frame.
        switch (value)
        {
            case "general":
                url = String.Format("UsuarioExtranetForm.aspx?Caller='{0}'&Frame='ifTabUsuarioExtranet'&InTab=S", caller);
                if (usuarioExtranetId != 0)
                    url = String.Format("UsuarioExtranetForm.aspx?Caller='{0}'&Frame='ifTabUsuarioExtranet'&InTab=S&UsuarioExtranetId={1}", caller, usuarioExtranetId);
                if (empresa != null)
                    url = String.Format("{0}&EmpresaId={1}", url, empresa.EmpresaId);
                if (instalacion != null)
                    url = String.Format("{0}&RevisionId={1}", url, instalacion.InstalacionId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabUsuarioExtranet');");
                break;
            case "categorias":
                url = String.Format("UsuarioCategoriaForm.aspx?UsuarioExtranetId={0}", usuarioExtranetId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabUsuarioExtranet');");
                break;
        }
    }
}
