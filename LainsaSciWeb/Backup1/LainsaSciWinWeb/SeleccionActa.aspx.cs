using System;
using LainsaSciModelo;
using LainsaSciInformes;
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
using Telerik.Reporting.Processing;
using System.IO;
using Telerik.Reporting;

public partial class SeleccionActa : System.Web.UI.Page
{
    #region Declarations
    // conector con la base de datos
    LainsaSci ctx = null;
    // parametros
    Usuario usuario = null;
    // internas
    Instalacion instalacion = null;
    Empresa emp;
    string informe = "";
    DateTime fechaActa;
    string actaNumero;
    Usuario tecnicoResponsable;
    string observaciones;

    #endregion

    #region Page events
    
    protected void Page_Init(object sender, EventArgs e)
    {
        // conectamos con la base de datos
        // LainsaSCiCTX se puede consultar en web.config
        ctx = new LainsaSci("LainsaSciCTX");
        
        // Control de acceso
        // se omite, sus acciones necesitan una página
        // contenedora.

        // obtener parámetros recibidos
        ParametrosURL();

        //cargas de controles
        CargaComboEmpresa(usuario);
       // CargaComboInstalacion(usuario);
        CargaComboUsuarios(usuario);
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Cambiar el alto del panel superior para que quepa este formulario
            string jCommand = String.Format("parent.ResizeReportPanel({0});", 400);
            RadAjaxManager1.ResponseScripts.Add(jCommand);
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // es educado no dejar cosas abiertas por ahi
        ctx.Dispose();
    }
    #endregion

    #region Auxiliary functions
    protected void ParametrosURL()
    {
        //if (Request.QueryString["Param"] != null)
        //    param = Request.QueryString["Param"];
        if (Request.QueryString["UsuarioId"] != null)
            usuario = CntLainsaSci.GetUsuario(int.Parse(Request.QueryString["UsuarioId"]), ctx);
        if (Request.QueryString["Informe"] != null)
        {
            informe = Request.QueryString["Informe"];
        }
    }

    protected void CargaComboEmpresa(Usuario usu)
    {
        rcbEmpresa.Items.Clear();
        if (usu == null)
            return;
       foreach (Empresa emp in CntLainsaSci.GetEmpresas(usu, ctx))
        {
            rcbEmpresa.Items.Add(new RadComboBoxItem(emp.Nombre, emp.EmpresaId.ToString()));
        }
       if (rcbEmpresa.Items.Count > 0)
       {
           rcbEmpresa.Items[0].Selected = true;
           CargaInstalaciones(CntLainsaSci.GetEmpresa(int.Parse(rcbEmpresa.SelectedValue), ctx));
       }
       else
           rcbEmpresa.Items.Clear();
    }
    protected void CargaInstalaciones(Empresa empresa)
    {
        rcbInstalacion.Items.Clear();
        if (empresa == null)
            return;
        rcbInstalacion.Items.Add(new RadComboBoxItem("Todas", ""));
        foreach (Instalacion instalacion in empresa.Instalaciones)
        {
            rcbInstalacion.Items.Add(new RadComboBoxItem(instalacion.Nombre, instalacion.InstalacionId.ToString()));
        }
    }
    protected void CargaComboUsuarios(Usuario usu)
    {
        rcbUsuario.Items.Clear();
        if (usu == null)
            return;
        foreach (Usuario usuario in CntLainsaSci.GetUsuarios(usu, ctx))
        {
            rcbUsuario.Items.Add(new RadComboBoxItem(usuario.Nombre, usuario.UsuarioId.ToString()));
        }
        rcbUsuario.Text = "";
    }
    protected void LanzarAviso(string aviso)
    {
        RadWindowManager1.RadAlert(aviso, null, null, "AVISO", "noHaceNada");
    }
    protected bool DatosOk()
    {
        fechaActa = (DateTime)rdtFechaActa.SelectedDate;
        if (rcbInstalacion.SelectedValue != "")
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(rcbInstalacion.SelectedValue), ctx);
        emp = CntLainsaSci.GetEmpresa(int.Parse(rcbEmpresa.SelectedValue), ctx);
        actaNumero = txtActaNumero.Text;
        observaciones = txtObservaciones.Text;
        tecnicoResponsable = CntLainsaSci.GetUsuario(int.Parse(rcbUsuario.SelectedValue), ctx);
        return true;
    }
    #endregion
    #region Buttons events (clics)
    protected void btnExit_Click(object sender, EventArgs e)
    {
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        if (!DatosOk())
            return;
        //instalacion = CntLainsaSci.GetInstalacion(int.Parse(rcbInstalacion.SelectedValue), ctx);
        int id_instalacion = -1;
        if(instalacion != null)
            id_instalacion = instalacion.InstalacionId;
        string jCommand = String.Format("parent.CargaActa('{0}', '{1:dd/MM/yyyy}', '{2}', '{3}', '{4}', '{5}', {6});",
            informe, fechaActa, actaNumero, tecnicoResponsable.UsuarioId, observaciones, id_instalacion, emp.EmpresaId);
        RadAjaxManager1.ResponseScripts.Add(jCommand);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (!DatosOk())
            return;
        int id_instalacion = -1;
        if (instalacion != null)
            id_instalacion = instalacion.InstalacionId;
        string directorio = MapPath("/") + "\\Repo";
        string nombreFichero = String.Format("ACT{0:0000000}_{1:0000}.pdf", id_instalacion, usuario.UsuarioId);
        string fichero = String.Format("{0}\\{1}", directorio, nombreFichero);
        ReportProcessor reportProcessor = new ReportProcessor();
        RenderingResult renderingResult = null;
        string nombre = "";

        switch(informe)
        {
            case "RptActa":
                 Plantilla plantilla = CntLainsaSci.GetPlantilla(1, ctx); // la primera plantilla es la de acta.
                string numeroAutorizado = ConfigurationManager.AppSettings["NumeroAutorizado"];
                string contenido = String.Format(plantilla.Contenido, numeroAutorizado, tecnicoResponsable.Nombre, actaNumero, fechaActa);
                ReportBook reportBook = new ReportBook();
                RptCartaActa rptCartaActa = new RptCartaActa(contenido);
                reportBook.Reports.Add(rptCartaActa);
                if (instalacion != null)
                {
                    RptInformeActa rptInformeActa = new RptInformeActa(instalacion, observaciones, actaNumero, fechaActa, tecnicoResponsable.Nombre, ctx);
                    reportBook.Reports.Add(rptInformeActa);
                }
                else
                {
                    RptInformeActaEmpresa rptInformeActaEmpresa = new RptInformeActaEmpresa(emp, observaciones, actaNumero, fechaActa, tecnicoResponsable.Nombre, ctx);
                    reportBook.Reports.Add(rptInformeActaEmpresa);
                }
               
                renderingResult = reportProcessor.RenderReport("PDF", reportBook, null);
                break;
        }
        FileStream fs = new FileStream(fichero, FileMode.Create);
        fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
        fs.Close();
        // abrir como documento sobre el repositorio
        nombre = txtActaNumero.Text + "_" + DateTime.Now.ToShortDateString();
        string url = String.Format("DocumentoView.aspx?FileName={0}&InstalacionId={1}&Nombre={2}&EmpresaId={3}", nombreFichero, id_instalacion, nombre, emp.EmpresaId);
        string jCommand = String.Format("parent.openOutSide('{0}', 'DocumentoView');", url);
        RadAjaxManager1.ResponseScripts.Add(jCommand);

        //string url = String.Format("VisorInforme.aspx?Informe=RptInformeActaEmpresas&prueba=arg&emp={0}",emp.EmpresaId);
        //string jCommand = String.Format("parent.openOutSide('{0}','{1}');", url, "VisorInforme");
        //RadAjaxManager1.ResponseScripts.Add(jCommand);
    }
    protected void rcbEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value != "")
        {
            Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Value), ctx);
            CargaInstalaciones(empresa);
        }
        else
            rcbInstalacion.Items.Clear();
    }
    #endregion

  
   
}