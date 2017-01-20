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

public partial class DispositivoTab : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario Usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    int dispositivoId, instalacionId = 0, dispositivoPadreId = 0; // identificador de emprtesa si es que se ha pasado uno
    string mode = ""; // the way it's called, S = for search
    string modo = "";
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
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "DispositivoGrid", ctx);
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
            if (caller.Equals("DispositivoTab"))
            {
                RadTabStrip1.Tabs[1].Visible = false;
                this.Title = String.Format("Accesorio");
            }
        }
        if (Request.QueryString["DispositivoId"] != null)
        {
            dispositivoId = int.Parse(Request.QueryString["DispositivoId"]);
            Dispositivo dispositivo = CntLainsaSci.GetDispositivo(dispositivoId, ctx);
            if (caller.Equals("DispositivoTab"))
                this.Title = String.Format("Accesorio: {0}", dispositivo.Nombre);
            else
                this.Title = String.Format("dispositivo: {0}", dispositivo.Nombre);
        }
        else
        {
            CntWinWeb.OcultarPestanyas(RadTabStrip1);
        }
        if (Request.QueryString["RevisionId"] != null)
            instalacionId = int.Parse(Request.QueryString["RevisionId"]);

        if (Request.QueryString["DispositivoPadreId"] != null)
            dispositivoPadreId = int.Parse(Request.QueryString["DispositivoPadreId"]);
        if (Request.QueryString["Modo"] != null)
        {
            modo = Request.QueryString["Modo"];
        }
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

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
        HtmlControl frame = (HtmlControl)this.FindControl("ifTabDispositivo");
        string url = "";
        // el valor de value en el tab indica lo que queremos mostrar en el frame.
        switch (value)
        {
           case "general":
                url = String.Format("DispositivoForm.aspx?Caller='{0}'&Frame='ifTabDispositivo'&InTab=S&Modo={1}", caller, modo);
                if (instalacionId != 0)
                    url = String.Format("{0}&InstalacionId={1}", url, instalacionId);
                if (dispositivoId != 0)
                    url = String.Format("{0}&DispositivoId={1}", url, dispositivoId);
                if (dispositivoPadreId != 0)
                    url = String.Format("{0}&DispositivoPadreId={1}", url, dispositivoPadreId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabDispositivo');");
                break;
           case "accesorios":
                url = String.Format("DispositivoGrid.aspx?Caller='{0}'&Frame='ifTabDispositivo'&InTab=S", caller);
                if (dispositivoId != 0)
                    url = String.Format("{0}&DispositivoId={1}", url, dispositivoId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabDispositivo');");
                break;
            case "revisiones":
                url = String.Format("RevisionGrid.aspx?Caller='{0}'&Frame='ifTabDispositivo'&InTab=S", caller);
                if (dispositivoId != 0)
                    url = String.Format("{0}&DispositivoId={1}", url, dispositivoId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabDispositivo');");
                break;
            case "incidencias":
                url = String.Format("IncidenciaGrid.aspx?Caller='{0}'&Frame='ifTabDispositivo'&InTab=S", caller);
                if (dispositivoId != 0)
                    url = String.Format("{0}&DispositivoId={1}", url, dispositivoId);
                frame.Attributes["src"] = url;
                RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifTabDispositivo');");
                break;
            default: break;
        }
    }
}
