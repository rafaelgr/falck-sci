using System;
using LainsaSciModelo;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class DocumentoForm : System.Web.UI.Page 
{
    #region Definición de variables generales
    LainsaSci ctx = null; // contexto para acceso a datos
    UsuarioExtranet uex = null; // usuario logado
    Documento documento = null;
    int documentoId = 0;
    #endregion
    #region Eventos iniciales de carga de página
    protected void Page_Init(object sender, EventArgs e)
    {
        // lo primero es cargar el contexto
        ctx = new LainsaSci("LainsaSciCTX"); // (LainsaSciCTX -> web.config)
        // Comprobar si hay un usuario logado
        if (Session["UsuarioExtranetId"] != null)
        {
            int id = (int)Session["UsuarioExtranetId"];
            uex = CntLainsaSci.GetUsuarioExtranet(id, ctx);
            if (uex == null) Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        if (Request.QueryString["DocumentoId"] != null)
        {
            documentoId = int.Parse(Request.QueryString["DocumentoId"]);
            documento = CntLainsaSci.GetDocumento(documentoId, ctx);
            if (documento != null)
            {
                string newFileName = String.Format("{0:000000000}", documento.DocumentoId) + documento.Extension;
                string repodir = ConfigurationManager.AppSettings["Repositorio"];
                string origen = repodir + "\\" + newFileName;
                string destino = Session["UsuarioDir"] + "\\" + newFileName;
                File.Copy(origen, destino, true);
                SplView.ContentUrl = String.Format("/Docs/A{0:000000}/{1}", uex.UsuarioExtranetId, newFileName);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!documento.Revisable) SplData.Visible = false;
        //if (documento.Revisable && documento.Revisado)
        //{
        //    SplData.Visible = false;
        //}
        //if (uex.Global) SplData.Visible = false;
        SplData.Visible = false;
        if (!IsPostBack)
        {
            lblMensaje.Text = (string)GetGlobalResourceObject("LainsaSciExtranet", "Revisable");
            chkComprueba.Text = (string)GetGlobalResourceObject("LainsaSciExtranet", "Revisado");
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //if (!chkComprueba.Checked)
        //{
        //    lblError.Text = (string)GetGlobalResourceObject("LainsaSciExtranet", "MarcarRevision");
        //}
        //else
        //{
        //    documento.Revisado = true;
            ctx.SaveChanges();
            Response.Redirect(String.Format("DocumentoForm.aspx?DocumentoId={0}", documento.DocumentoId));
        //}
    }
}
