using System;
using Telerik.OpenAccess;
using LainsaSciModelo;
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
    #region Declaracion de variables
    LainsaSci ctx = null;
    Usuario usuario = null;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // mostrar la versión del programa
        String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        lblVersion.Text = String.Format("VRS {0}", strVersion);
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
    #region Acciones
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (!DatosOk()) return;
        Response.Redirect("MainMenu.aspx");
    }
    #endregion
    #region Funciones auxiliares
    protected bool DatosOk()
    {
        if (txtLogin.Text == "" || txtPassword.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "LoginAndPasswordNeeded"));
            RadNotification1.Show();
            return false;
        }
        // Comprobación del login
        usuario = CntAutenticacion.Login(txtLogin.Text, txtPassword.Text, ctx);
        if (usuario == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "LoginFail"));
            RadNotification1.Show();
            return false;
        }
        // Grabamos el usuario en la sessión
        Session["UsuarioId"] = usuario.UsuarioId;
        return true;
    }
    #endregion

}