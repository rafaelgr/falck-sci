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
using System.Collections.Generic;

public partial class SeleccionInforme : System.Web.UI.Page
{
    #region Declarations
    // conector con la base de datos
    LainsaSci ctx = null;
    // parametros
    Usuario usuario = null;
    // internas
    Empresa empresa = null;
    Instalacion instalacion = null;
    TipoDispositivo tipo_dispositivo = null;
    string tipo_informe = "";
    DateTime desdeFecha;
    DateTime hastaFecha;
    readonly static string RCD_EMPTY = "0";
    readonly static string RCD_ALL = "1";
    
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
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            tipo_informe = Request.QueryString["Informe"];
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
            Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(rcbEmpresa.SelectedValue), ctx);
            CargaInstalaciones(empresa,usuario);
            CargarTiposDispositivo(empresa);
        }
        //rcbEmpresa.Text = "";
    }
   
    protected void LanzarAviso(string aviso)
    {
        RadWindowManager1.RadAlert(aviso, null, null, "AVISO", "noHaceNada");
    }
    protected bool DatosOk()
    {
        if (rdtFromDate.SelectedDate > rdtToDate.SelectedDate)
        {
            LanzarAviso("La fecha_apertura desde no puede ser superior a la fecha_apertura hasta");
            return false;
        }
        desdeFecha = (DateTime)rdtFromDate.SelectedDate;
        hastaFecha = (DateTime)rdtToDate.SelectedDate;
        if (rcbInstalacion.SelectedValue != RCD_ALL && rcbInstalacion.SelectedValue != RCD_EMPTY)
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(rcbInstalacion.SelectedValue), ctx);
        else
            instalacion = null;
        if (rcbTipoDispositivo.SelectedValue != RCD_ALL && rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
            tipo_dispositivo = CntLainsaSci.GetTipoDispositivo(int.Parse(rcbTipoDispositivo.SelectedValue), ctx);
        else
            tipo_dispositivo = null;
        if (rcbInstalacion.SelectedValue == RCD_EMPTY && rcbTipoDispositivo.SelectedValue == RCD_EMPTY)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
              (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
              (string)GetGlobalResourceObject("ResourceLainsaSci", "NcInformeEmpresa"));
            RadNotification1.Show();
            return false;
        }
        empresa = CntLainsaSci.GetEmpresa(int.Parse(rcbEmpresa.SelectedValue), ctx);
        
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
        string informe = tipo_informe;
        string instid = "-1", t_disp_id = "-1";
        string jCommand = string.Empty;
        switch (tipo_informe)
        {
            case "RptResumenEmpresaInstalacion":
                if (rcbInstalacion.SelectedValue != RCD_EMPTY)
                {
                    if (instalacion != null)
                        instid = instalacion.InstalacionId.ToString();
                    if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                    {
                        informe = "RptResumenEmpresa";
                        if (tipo_dispositivo != null)
                            t_disp_id = tipo_dispositivo.TipoId.ToString();
                        jCommand = String.Format("parent.CargaInformeEmpresa('{0}', '{1:dd/MM/yyyy}', '{2:dd/MM/yyyy}', {3}, {4}, {5});",
                        informe, rdtFromDate.SelectedDate, rdtToDate.SelectedDate, empresa.EmpresaId.ToString(), instid, t_disp_id);
                    }
                }
                else if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                {
                    informe = "RptResumenEmpresaTipoDispositivo";
                    if (tipo_dispositivo != null)
                        t_disp_id = tipo_dispositivo.TipoId.ToString();
                    jCommand = String.Format("parent.CargaInformeTipo('{0}', '{1:dd/MM/yyyy}', '{2:dd/MM/yyyy}', {3}, {4});",
                      informe, rdtFromDate.SelectedDate, rdtToDate.SelectedDate, empresa.EmpresaId.ToString(), t_disp_id);
                    
                }
                
                break;
           
            case "RptFacturableEmpresaInstalacion":
                if (rcbInstalacion.SelectedValue != RCD_EMPTY)
                {
                    if (instalacion != null)
                        instid = instalacion.InstalacionId.ToString();
                    if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                    {
                        informe = "RptFacturableEmpresa";
                        if (tipo_dispositivo != null)
                            t_disp_id = tipo_dispositivo.TipoId.ToString();
                        jCommand = String.Format("parent.CargaInformeEmpresa('{0}', '{1:dd/MM/yyyy}', '{2:dd/MM/yyyy}', {3}, {4}, {5});",
                           informe, rdtFromDate.SelectedDate, rdtToDate.SelectedDate, empresa.EmpresaId.ToString(), instid, t_disp_id);
                    }
                }
                else if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                {
                    informe = "RptFacturableEmpresaTipoDispositivo";
                    if (tipo_dispositivo != null)
                        t_disp_id = tipo_dispositivo.TipoId.ToString();
                    jCommand = String.Format("parent.CargaInformeTipo('{0}', '{1:dd/MM/yyyy}', '{2:dd/MM/yyyy}', {3}, {4});",
                      informe, rdtFromDate.SelectedDate, rdtToDate.SelectedDate, empresa.EmpresaId.ToString(), t_disp_id);
                }
               
                break;
        }
        if(String.IsNullOrEmpty(jCommand))
            jCommand = String.Format("parent.CargaInformeInstalacion('{0}', '{1:dd/MM/yyyy}', '{2:dd/MM/yyyy}', {3}, {4});",
              informe, rdtFromDate.SelectedDate, rdtToDate.SelectedDate, empresa.EmpresaId.ToString(), instid);
                    
           
           
        RadAjaxManager1.ResponseScripts.Add(jCommand);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (!DatosOk())
            return;
        string instid = "-1", t_disp_id = "-1";
        string informe = tipo_informe;
        string nombreFichero = string.Empty;
        string directorio = MapPath("/") + "\\Repo";
        ReportProcessor reportProcessor = new ReportProcessor();
        RenderingResult renderingResult = null;
        string nombre = "";
        switch (tipo_informe)
        {
            case "RptResumenEmpresaInstalacion":
                if (rcbInstalacion.SelectedValue != RCD_EMPTY)
                {
                       if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                       {
                            informe = "RptResumenEmpresa";
                            if (tipo_dispositivo != null)
                            {
                                t_disp_id = tipo_dispositivo.TipoId.ToString();
                                if (instalacion == null)
                                {
                                    nombreFichero = String.Format("EXP{0:0000000}_Instalaciones_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, t_disp_id, usuario.UsuarioId);
                                }
                                else
                                {
                                    instid = instalacion.InstalacionId.ToString();
                                    nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{2:0000000}_{3:0000}.pdf", empresa.EmpresaId, instid, t_disp_id, usuario.UsuarioId);
                                }
                            }
                            else
                            {
                                if (instalacion == null)
                                {
                                    nombreFichero = String.Format("EXP{0:0000000}_Instalaciones_{1:0000}.pdf", empresa.EmpresaId, usuario.UsuarioId);
                                }
                                else
                                {
                                    instid = instalacion.InstalacionId.ToString();
                                    nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, instid, usuario.UsuarioId);
                                }
                            }

                            RptResumenEmpresa rptR = new RptResumenEmpresa(desdeFecha, hastaFecha, empresa.EmpresaId, int.Parse(instid), int.Parse(instid), ctx);
                            nombre = String.Format("Resumen Revisiones {0:dd/MM/yyyy} {1:dd/MM/yyyy}", desdeFecha, hastaFecha);
                            renderingResult = reportProcessor.RenderReport("PDF", rptR, null);
                        }
                        else
                        {
                            if (instalacion != null)
                            {
                                instid = instalacion.InstalacionId.ToString();
                                nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, instid, usuario.UsuarioId);
                            }
                            else
                            {
                                nombreFichero = String.Format("EXP{0:0000000}_Instalaciones_{1:0000}.pdf", empresa.EmpresaId, usuario.UsuarioId);
                            }
                            
                           RptResumenEmpresaInstalacion rptR = new RptResumenEmpresaInstalacion(desdeFecha, hastaFecha, empresa.EmpresaId, int.Parse(instid), ctx);
                           nombre = String.Format("Resumen Revisiones {0:dd/MM/yyyy} {1:dd/MM/yyyy}", desdeFecha, hastaFecha);
                           renderingResult = reportProcessor.RenderReport("PDF", rptR, null);
                        }
                }
                else if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                {
                    informe = "RptResumenEmpresaTipoDispositivo";
                    if (tipo_dispositivo != null)
                    {
                        t_disp_id = tipo_dispositivo.TipoId.ToString();
                        nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, t_disp_id, usuario.UsuarioId);
                    }
                    else
                        nombreFichero = String.Format("EXP{0:0000000}_{1:0000}.pdf", empresa.EmpresaId, usuario.UsuarioId);
                    
                    RptResumenEmpresaTipoDispositivo rptR = new RptResumenEmpresaTipoDispositivo(desdeFecha, hastaFecha, empresa.EmpresaId, int.Parse(t_disp_id), ctx);
                    nombre = String.Format("Resumen Revisiones {0:dd/MM/yyyy} {1:dd/MM/yyyy}", desdeFecha, hastaFecha);
                    renderingResult = reportProcessor.RenderReport("PDF", rptR, null);
                }
                break;
            
            case "RptFacturableEmpresaInstalacion":
                if (rcbInstalacion.SelectedValue != RCD_EMPTY)
                {
                    if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                    {
                        informe = "RptFacturableEmpresa";
                        if (tipo_dispositivo != null)
                        {
                            t_disp_id = tipo_dispositivo.TipoId.ToString();
                            if (instalacion == null)
                            {
                                nombreFichero = String.Format("EXP{0:0000000}_Instalaciones_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, t_disp_id, usuario.UsuarioId);
                            }
                            else
                            {
                                instid = instalacion.InstalacionId.ToString();
                                nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{2:0000000}_{3:0000}.pdf", empresa.EmpresaId, instid, t_disp_id, usuario.UsuarioId);
                            }
                        }
                        else
                        {
                            if (instalacion != null)
                            {
                                instid = instalacion.InstalacionId.ToString();
                                nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, instid, usuario.UsuarioId);
                            }
                            else
                            {
                                nombreFichero = String.Format("EXP{0:0000000}_{2:0000}.pdf", empresa.EmpresaId, usuario.UsuarioId);
                            }
                        }

                        RptFacturableEmpresa rptT = new RptFacturableEmpresa(desdeFecha, hastaFecha, empresa.EmpresaId, int.Parse(instid), int.Parse(t_disp_id), ctx);
                        nombre = String.Format("Revisiones facturables {0:dd/MM/yyyy} {1:dd/MM/yyyy}", desdeFecha, hastaFecha);
                        renderingResult = reportProcessor.RenderReport("PDF", rptT, null);
                    }
                    else
                    {
                        if (instalacion != null)
                        {
                            instid = instalacion.InstalacionId.ToString();
                            nombreFichero = String.Format("EXP{0:0000000}_Instalaciones_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, instid, usuario.UsuarioId);
                        }
                        else
                        {
                            nombreFichero = String.Format("EXP{0:0000000}_Instalaciones_{1:0000000}_{2:0000}.pdf", empresa.EmpresaId, t_disp_id, usuario.UsuarioId);
                        }
                       
                        RptFacturableEmpresaInstalacion rptF = new RptFacturableEmpresaInstalacion(desdeFecha, hastaFecha, empresa.EmpresaId, int.Parse(instid), ctx);
                        nombre = String.Format("Revisiones facturables {0:dd/MM/yyyy} {1:dd/MM/yyyy}", desdeFecha, hastaFecha);
                        renderingResult = reportProcessor.RenderReport("PDF", rptF, null);
                    }
                    
                }
                else if (rcbTipoDispositivo.SelectedValue != RCD_EMPTY)
                {
                    informe = "RptFacturableEmpresaTipoDispositivo";
                    if (tipo_dispositivo != null)
                    {
                        t_disp_id = tipo_dispositivo.TipoId.ToString();
                        nombreFichero = String.Format("EXP{0:0000000}_{1:0000000}_{3:0000}.pdf", empresa.EmpresaId, t_disp_id, usuario.UsuarioId);
                    }
                    else
                    {
                        nombreFichero = String.Format("EXP{0:0000000}_{1:0000}.pdf", empresa.EmpresaId, usuario.UsuarioId);
                    }

                    RptFacturableEmpresaTipoDispositivo rptT = new RptFacturableEmpresaTipoDispositivo(desdeFecha, hastaFecha, empresa.EmpresaId, int.Parse(t_disp_id), ctx);
                    nombre = String.Format("Revisiones facturables {0:dd/MM/yyyy} {1:dd/MM/yyyy}", desdeFecha, hastaFecha);
                    renderingResult = reportProcessor.RenderReport("PDF", rptT, null);
                }

                break;
         }
      
        string fichero = String.Format("{0}\\{1}", directorio, nombreFichero);

        FileStream fs = new FileStream(fichero, FileMode.Create);
        fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
        fs.Close();
        // abrir como documento sobre el repositorio
        string url = String.Format("DocumentoView.aspx?FileName={0}&EmpresaId={1}&Nombre={2}&InstalacionId={3}&TipoDispositivoId={4}", nombreFichero, empresa.EmpresaId, nombre, instid, t_disp_id);
        string jCommand = String.Format("parent.openOutSide('{0}', 'DocumentoView');", url);
        RadAjaxManager1.ResponseScripts.Add(jCommand);
    }
    #endregion

    protected void rcbEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value != "")
        {
            Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Value), ctx);
            CargaInstalaciones(empresa, usuario);
            CargarTiposDispositivo(empresa);
        }
    }
    protected void CargaInstalaciones(Empresa empresa,Usuario usu)
    {
        rcbInstalacion.Items.Clear();
        if(empresa == null)
            return;
        if(usu == null)
            return;

        rcbInstalacion.Items.Add(new RadComboBoxItem("", RCD_EMPTY));
        rcbInstalacion.Items.Add(new RadComboBoxItem("Todas", RCD_ALL));


        foreach(Instalacion instalacion in CntLainsaSci.GetInstalaciones(empresa, usu, ctx))
        {
            rcbInstalacion.Items.Add(new RadComboBoxItem(instalacion.Nombre, instalacion.InstalacionId.ToString()));
        }
        rcbInstalacion.Items[0].Selected = true;
    }
    protected void CargarTiposDispositivo(Empresa empresa)
    {
        if (empresa == null)
            return;
        rcbTipoDispositivo.Items.Clear();
        rcbTipoDispositivo.Items.Add(new RadComboBoxItem("", RCD_EMPTY));
        rcbTipoDispositivo.Items.Add(new RadComboBoxItem("Todos", RCD_ALL));
        foreach (TipoDispositivo t_disp in empresa.TipoDispositivos)
        {
            rcbTipoDispositivo.Items.Add(new RadComboBoxItem(t_disp.Nombre, t_disp.TipoId.ToString()));
        }
        rcbTipoDispositivo.Items[0].Selected = true;
    }
    protected void rcbTipoDispositivo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    
    }

    protected void rcbInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        rcbTipoDispositivo.Items.Clear();
        Instalacion inst = CntLainsaSci.GetInstalacion(int.Parse(rcbInstalacion.SelectedValue), ctx);
        if(inst != null)
        {
            rcbTipoDispositivo.Items.Add(new RadComboBoxItem("", RCD_EMPTY));
            rcbTipoDispositivo.Items.Add(new RadComboBoxItem("Todos", RCD_ALL));
            IList<TipoDispositivo> tipos = new List<TipoDispositivo>();
            foreach (Dispositivo disp in inst.Dispositivos)
               if(!tipos.Contains(disp.TipoDispositivo))
               {
                   tipos.Add(disp.TipoDispositivo);
                   rcbTipoDispositivo.Items.Add(new RadComboBoxItem(disp.TipoDispositivo.Nombre, disp.TipoDispositivo.TipoId.ToString()));
               }
            rcbTipoDispositivo.Items[0].Selected = true;
        }
        else
            CargarTiposDispositivo(CntLainsaSci.GetEmpresa(int.Parse(rcbEmpresa.SelectedValue), ctx));
    }
}