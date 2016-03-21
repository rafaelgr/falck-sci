using System;
using LainsaSciModelo;
using LainsaSciWinWeb;
using LainsaSciInformes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class VisorLibroInformes : System.Web.UI.Page 
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null;
    string informe = "";
    DateTime desdeFecha;
    DateTime hastaFecha;
    string caller = ""; // who calls the form
    Programa programa = null;
    bool newRecord = true;
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
        if (Request.QueryString["Informe"] != null)
        {
            informe = Request.QueryString["Informe"];
        }

        if (Request.QueryString["ProgramaId"] != null)
        {
            programa = CntLainsaSci.GetPrograma(int.Parse(Request.QueryString["ProgramaId"]), ctx);
            if (programa != null)
            {
                switch(informe)
                {
                    case "RptPrograma2":
                        RptPrograma2 rptPrograma2 = new RptPrograma2(programa.ProgramaId, ctx);
                        ReportViewer1.Report = rptPrograma2;
                        break;
                    case "RptRevisionFormulario":
                        RptRevisionFormulario rptRF = new RptRevisionFormulario(programa, ctx);
                        ReportViewer1.Report = rptRF;
                        break;
                }
            }
            newRecord = false;
        }
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
            if (empresa != null)
            {
                desdeFecha = DateTime.Parse(Request.QueryString["DesdeFecha"]);
                hastaFecha = DateTime.Parse(Request.QueryString["HastaFecha"]);
                switch(informe)
                {
                    case "RptResumenEmpresaInstalacion":
                        RptResumenEmpresaInstalacion rpt = new RptResumenEmpresaInstalacion(desdeFecha, hastaFecha, empresa.EmpresaId, -1, ctx);
                        ReportViewer1.Report = rpt;
                        break;
                    case "RptFacturableEmpresaInstalacion":
                        RptFacturableEmpresaInstalacion rpt2 = new RptFacturableEmpresaInstalacion(desdeFecha, hastaFecha, empresa.EmpresaId, -1, ctx);
                        ReportViewer1.Report = rpt2;
                        break;
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
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}