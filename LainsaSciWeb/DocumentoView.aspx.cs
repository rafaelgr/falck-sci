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
using System.IO;

public partial class DocumentoView : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null;
    Instalacion instalacion = null;
    TipoDispositivo tipo = null;
    int instId = -1, tId = -1;
    string nombre = "";
    string caller = ""; // who calls the form
    string fileName = "";
    int documentoId = 0;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (usuario == null)
            Response.Redirect("Default.aspx");
        else
            Session["UsuarioId"] = usuario.UsuarioId;
        //
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "repositoriotmpform", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
        }
        if (Request.QueryString["FileName"] != null)
        {
            fileName = Request.QueryString["FileName"];
        }
        if (Request.QueryString["DocumentoId"] != null)
        {
            documentoId = int.Parse(Request.QueryString["DocumentoId"]);
        }
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
        }
        if (Request.QueryString["Nombre"] != null)
        {
            nombre = Request.QueryString["Nombre"];
        }
        if (Request.QueryString["InstalacionId"] != null)
        {
            instId = int.Parse(Request.QueryString["InstalacionId"]);
            instalacion = CntLainsaSci.GetInstalacion(instId, ctx);
            if (instalacion != null)
                empresa = CntLainsaSci.GetEmpresa(instalacion.Empresa.EmpresaId, ctx);
        }
        if (Request.QueryString["TipoDispositivoId"] != null)
        {
            tId = int.Parse(Request.QueryString["TipoDispositivoId"]);
            tipo = CntLainsaSci.GetTipoDispositivo(tId, ctx);
            if (tipo != null)
              empresa = CntLainsaSci.GetEmpresa(tipo.Empresa.EmpresaId, ctx);
        }
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Cargar las propiedades de el FileExplorer.
        //string repodir = ConfigurationManager.AppSettings["Repositorio"];
        if (documentoId == 0)
        {
            SplView.ContentUrl = String.Format("/Repo/{0}", fileName);
            if (empresa == null)
                SplData.ContentUrl = String.Format("DocumentoForm.aspx?Caller=DocumentoView&InTab=S&FileName={0}", fileName);
            else
            {
                if (instalacion == null && tipo == null)
                    SplData.ContentUrl = String.Format("DocumentoForm.aspx?Caller=DocumentoView&InTab=S&FileName={0}&EmpresaId={1}&Nombre={2}",
                    fileName,
                    empresa.EmpresaId,
                    nombre);
                else if (instalacion != null)
                    if(tipo == null)
                        SplData.ContentUrl = String.Format("DocumentoForm.aspx?Caller=DocumentoView&InTab=S&FileName={0}&Nombre={1}&InstalacionId={2}",
                        fileName,
                        nombre,
                        instalacion.InstalacionId);
                    else
                        SplData.ContentUrl = String.Format("DocumentoForm.aspx?Caller=DocumentoView&InTab=S&FileName={0}&Nombre={1}&InstalacionId={2}&TipoDispositivoId={3}",
                                               fileName,
                                               nombre,
                                               instalacion.InstalacionId,
                                               tipo.TipoId);
                else
                    SplData.ContentUrl = String.Format("DocumentoForm.aspx?Caller=DosumentoView&InTab=SFileName={0}&Nombre={1}&TipoDispositivoId={2}",
                        fileName,
                        nombre,
                        tipo.TipoId);
            }

        }
        else
        {
            Documento documento = CntLainsaSci.GetDocumento(documentoId, ctx);
            if (documento != null)
            {
                string newFileName = String.Format("{0:000000000}.", documento.DocumentoId) + documento.Extension;
                string repodir = ConfigurationManager.AppSettings["Repositorio"];
                string origen = repodir + "\\" + newFileName;
                if (File.Exists(origen))
                {
                    string destino = Session["UsuarioDir"] + "\\" + newFileName;
                    File.Copy(origen, destino, true);
                    SplView.ContentUrl = String.Format("/Docs/A{0:000000}/{1}", usuario.UsuarioId, newFileName);
                    SplData.ContentUrl = String.Format("DocumentoForm.aspx?Caller=DocumentoView&InTab=S&DocumentoId={0}", documento.DocumentoId);
                }
                else
                {

                    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NDocumento"));
                    RadNotification1.Show();

                }
            }
        }

    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion
    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
}
