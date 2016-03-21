using System;
using LainsaSciModelo;
using LainsaSciExtranet;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class Default : System.Web.UI.Page
{
    #region Definición de variables generales
    LainsaSci ctx = null; // contexto para acceso a datos
    UsuarioExtranet uex = null; // usuario logado
    #endregion
    #region Eventos iniciales de carga de página
    protected void Page_Init(object sender, EventArgs e)
    {
        // lo primero es cargar el contexto
        ctx = new LainsaSci("LainsaSciCTX"); // (LainsaSciCTX -> web.config)
        // mostrar la versión del programa
        String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        LblTituloDerechoInferior.Text = String.Format("VRS {0}", strVersion);
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
    #region Acciones disparadas por controles
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

        uex = CntAutenticacion.LoginExtranet(txtLogin.Text, txtPassword.Text, ctx);
        if (uex != null)
        {
            // grabar Id de usario en la sesion
            Session["UsuarioExtranetId"] = uex.UsuarioExtranetId;
            // montamos el directorio personal
            string userDir = MapPath("/") + "Docs\\A" + String.Format("{0:000000}", uex.UsuarioExtranetId);
            CntWinWeb.PrepareUserFolder(userDir);
            Session["UsuarioDir"] = userDir;
            RadAjaxManager1.ResponseScripts.Add("window.open('MainPage.aspx');");
           // Response.Redirect("MainPage.aspx");
        }
        else
        {
            // mostramos error en el login
            string mensaje = (string)GetGlobalResourceObject("LainsaSciExtranet", "FalloLogin");
            RadWindowManager1.RadAlert(mensaje, null, null, "Login EXTRANET", "noHaceNada");
        }
    }
    #endregion

}
