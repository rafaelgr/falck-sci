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

public partial class TerminalTab : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario Usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    int TerminalId, empresaId = 0; // identificador de emprtesa si es que se ha pasado uno
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
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "TerminalGrid", ctx);
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
        {
            caller = Request.QueryString["Caller"];
            if (caller.Equals("TerminalTab"))
            {
                RadTabStrip1.Tabs[1].Visible = false;
                this.Title = String.Format("Accesorio");
            }
        }
        if (Request.QueryString["TerminalId"] != null)
        {
            TerminalId = int.Parse(Request.QueryString["TerminalId"]);
            Terminal terminal = CntLainsaSci.GetTerminal(TerminalId, ctx);
            if (terminal != null) Title = String.Format("Terminal: {0}", terminal.Nombre);
        }
        else
        {
            CntWinWeb.OcultarPestanyas(RadTabStrip1);
        }
        if (Request.QueryString["EmpresaId"] != null)
            empresaId = int.Parse(Request.QueryString["EmpresaId"]);


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
    }
    #endregion

    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        NavegaFrame(e.Tab.Value);
    }
    protected void NavegaFrame(string value)
    { 
        // obtenemos el frame en el que se muestran las páginas.
        HtmlControl frame = (HtmlControl)this.FindControl("ifTabTerminal");
        string url = "";
        // el valor de value en el tab indica lo que queremos mostrar en el frame.
        switch (value)
        {
           case "general":
                url = String.Format("TerminalForm.aspx?Caller='{0}'&Frame='ifTabTerminal'&InTab=S", caller);
                if (empresaId != 0)
                    url = String.Format("{0}&EmpresaId={1}", url, empresaId);
                if (TerminalId != 0)
                    url = String.Format("{0}&TerminalId={1}", url, TerminalId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabTerminal');");
                break;
            default: break;
        }
    }
}
