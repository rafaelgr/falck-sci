using System;
using LainsaSciModelo;
using Telerik.OpenAccess;
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
    LainsaSci ctx = null;
    Usuario usuario = null;
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // mostrar la versión del programa
        String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        lblTitulo.Text = String.Format("Revision DCI VRS {0}", strVersion);
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        // Comprobación del login
        usuario = CntAutenticacion.Login(txtUsuario.Text, txtPassword.Text, ctx);
        if (usuario == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "LoginFail"));
            RadNotification1.Show();
            return;
        }
        // Grabamos el usuario en la sessión
        Session["UsuarioId"] = usuario.UsuarioId;
        Response.Redirect("ProgramaList.aspx");
    }
}
