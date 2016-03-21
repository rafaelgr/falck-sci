using System;
using LainsaSciExtranet;
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

public partial class MensajeView : System.Web.UI.Page 
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    UsuarioExtranet uex; // Usuario loged
    Permiso permiso;
    Mensaje mensaje = null;
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        uex = CntLainsaSci.GetUsuarioExtranet((int)Session["UsuarioExtranetId"], ctx);
        if (uex == null)
            Response.Redirect("Default.aspx");
        if (Request.QueryString["MensajeId"] != null)
        {
            mensaje = CntLainsaSci.GetMensaje(int.Parse(Request.QueryString["MensajeId"]), ctx);
            lblT2.Text = mensaje.Titulo;
            lblM2.Text = mensaje.Cuerpo;
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
        //
        //Session["MensajeGrid"] = null;
    }
    #endregion
}
