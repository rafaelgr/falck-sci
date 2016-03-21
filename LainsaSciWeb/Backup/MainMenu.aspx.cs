using System;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using LainsaSciModelo;
using LainsaSciWinWeb;

public partial class MainMenu : System.Web.UI.Page 
{
    LainsaSci ctx = null;
    Usuario Usuario = null;
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (Usuario == null)
            Response.Redirect("Default.aspx");
        else
        {
            Session["UsuarioId"] = Usuario.UsuarioId;
            ChekPermissions(Usuario.GrupoUsuario, RadMenu1.Items);
        }
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadNotification1.Text = (string)GetGlobalResourceObject("ResourceLainsaSci","LegalNote");
            RadNotification1.Show();
            String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = String.Format("VRS {0} TS: {1}", strVersion, Session.Timeout);
            lblUsuario.Text = Usuario.Nombre;
        }
        // Deactivate all windows in reload, prevents to show closed windows (Not possible in JS)
        //CntWinWeb.VisibleOnPageLoadAllWindows(RadWindowManager1, false);
        //CntWinWeb.controlOpenedWindows(RadWindowManager1, this);
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["PermisoGrid"] = null;
    }
    protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        //string jCommand = "";
        switch (e.Item.Value)
        {
            case "salir":
                Session["UsuarioId"] = null;
                Response.Redirect("Default.aspx");
                break;
        }
    }

    protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
    {
        string valor = e.Item.Value;
        string jCommand = "";
        switch (valor)
        {
            case "tile":
                jCommand = "windowTile();";
                break;
            case "cascade":
                jCommand = "windowCascade();";
                break;
            default:
                jCommand = String.Format("openWindowFromMenu('{0}.aspx?Caller={1}','{0}'); return false;", valor, "MainMenu.aspx");
                break;
        }
        RadAjaxManager1.ResponseScripts.Add(jCommand);
        //string name = e.Item.Value;
        //RadWindow rdw = GetWindowByName(name);
        //if (rdw != null)
        //{
        //    rdw.NavigateUrl = String.Format("{0}.aspx?Caller={1}", e.Item.Value, "MainMenu");
        //    rdw.VisibleOnPageLoad = true;
        //    Session[name] = "open"; // indica que esta ventana está abierta.
        //}
    }
    protected RadWindow GetWindowByName(string name)
    {
        RadWindow rdw = null;
        foreach (RadWindow w in RadWindowManager1.Windows)
        {
            if (w.ID == name) rdw = w;
        }
        return rdw;
    }
    protected void ChekPermissions(GrupoUsuario gu, RadMenuItemCollection col)
    {
        foreach (RadMenuItem i in col)
        {
            Proceso proceso = CntLainsaSci.GetProceso(i.Value, ctx);
            if (proceso != null)
            {
                Permiso permiso = CntLainsaSci.GetPermiso(gu, proceso, ctx);
                if (permiso != null)
                {
                    if (!permiso.Ver) i.Visible = false;
                }
                else i.Visible = false; // If no permission not show
            }
            else i.Visible = false; // If doesn't exits not show

            // recursive call if there are submenus or items in it
            if (i.Items.Count > 0)
                ChekPermissions(gu, i.Items);
        }
    }
}
