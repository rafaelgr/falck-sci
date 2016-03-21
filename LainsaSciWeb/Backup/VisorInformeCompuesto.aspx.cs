using System;
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

public partial class VisorInformeCompuesto : System.Web.UI.Page 
{
    LainsaSci ctx = null;
    Usuario usuario = null;
    string informe = "";
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (usuario == null)
            Response.Redirect("Default.aspx");
        else
        {
            Session["UsuarioId"] = usuario.UsuarioId;
        }
        if (Request.QueryString["Informe"] != null)
        {
            informe = Request.QueryString["Informe"];
        }
        else
        {
            RadWindowManager1.RadAlert("No se ha solicitado ningún informe", null, null, "AVISO", "noHaceNada");
            RadAjaxManager1.ResponseScripts.Add("closeWindow);");
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // cargamos la página de selección en función del informe
            switch (informe)
            {
                case "RptResumenEmpresaInstalacion":
                    SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}&Informe={1}", usuario.UsuarioId, informe);
                    break;
                case "RptFacturableEmpresaInstalacion":
                    SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}&Informe={1}", usuario.UsuarioId, informe);
                    break;
                case "RptResumenEmpresaTipoDispositivo":
                    SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}&Informe={1}", usuario.UsuarioId, informe);
                    break;
                case "RptFacturableEmpresaTipoDispositivo":
                    SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}&Informe={1}", usuario.UsuarioId, informe);
                    break;
                case "RptActa":
                    SplData.ContentUrl = String.Format("SeleccionActa.aspx?UsuarioId={0}&Informe={1}", usuario.UsuarioId, informe);
                    break;
            }
            MostrarTitulosCampos();
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #region Gestión de la carga de informes
    protected void CargarInformes(string informe)
    {
        switch (informe)
        {
            case "RptResumenEmpresaInstalacion":
                //String.Format("VisorInforme.aspx?ProgramaId={0}", programa.ProgramaId);
                SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}", usuario.UsuarioId);
                break;
            case "RptFacturableEmpresaInstalacion":
                //String.Format("VisorInforme.aspx?ProgramaId={0}", programa.ProgramaId);
                SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}", usuario.UsuarioId);
                break;
            case "RptResumenEmpresaTipoDispositivo":
                //String.Format("VisorInforme.aspx?ProgramaId={0}", programa.ProgramaId);
                SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}", usuario.UsuarioId);
                break;
            case "RptFacturableEmpresaTipoDispositivo":
                //String.Format("VisorInforme.aspx?ProgramaId={0}", programa.ProgramaId);
                SplData.ContentUrl = String.Format("SeleccionInforme.aspx?UsuarioId={0}", usuario.UsuarioId);
                break;
            case "RptActa":
                //String.Format("VisorInforme.aspx?ProgramaId={0}", programa.ProgramaId);
                SplData.ContentUrl = String.Format("SeleccionActa.aspx?UsuarioId={0}", usuario.UsuarioId);
                break;
            default:
                break;
        }
    }
    protected void MostrarTitulosCampos()
    {
        switch (informe)
        {
            case "RptResumenEmpresaInstalacion":
                this.Title = "Resumen de revisiones y anomalias por empresa";
                break;
            case "RptFacturableEmpresaInstalacion":
                this.Title = "Revisiones facturables por empresa";
                break;
            case "RptResumenEmpresaTipoDispositivo":
                this.Title = "Resumen de revisiones y anomalias por empresa";
                break;
            case "RptFacturableEmpresaTipoDispositivo":
                this.Title = "Revisiones facturables por empresa";
                break;
            case "RptActa":
                this.Title = "Actas";
                break;
        }
    }
    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }

}
