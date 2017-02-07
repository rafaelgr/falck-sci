<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorInformeCompuesto.aspx.cs" Inherits="VisorInformeCompuesto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
	<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		<Scripts>
			<%--Needed for JavaScript IntelliSense in VS2010--%>
			<%--For VS2008 replace RadScriptManager with ScriptManager--%>
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			<asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		</Scripts>
	</telerik:RadScriptManager>
	<script type="text/javascript" src="GridForm.js">
		//Put your JavaScript code here.
    </script>
    <script type="text/javascript">
        function CargaInformeInstalacion(informe, par1, par2, par3, par4) {
            var panel = $find("<%= SplReport.ClientID %>");
            var url = "";
            switch (informe) {
                case "RptResumenEmpresaInstalacion":
                    url = "VisorInforme.aspx?Informe=RptResumenEmpresaInstalacion&DesdeFecha=" + par1
                    + "&HastaFecha=" + par2
                    + "&EmpresaId=" + par3
                    + "&InstId=" + par4;
                    panel.set_contentUrl(url);
                    break;
                case "RptFacturableEmpresaInstalacion":
                    url = "VisorInforme.aspx?Informe=RptFacturableEmpresaInstalacion&DesdeFecha=" + par1
                    + "&HastaFecha=" + par2
                    + "&EmpresaId=" + par3
                    + "&InstId=" + par4;
                    panel.set_contentUrl(url);
                    break;
            }
        } function CargaInformeTipo(informe, par1, par2, par3, par4) {
            var panel = $find("<%= SplReport.ClientID %>");
            var url = "";
            switch (informe) {
                case "RptResumenEmpresaTipoDispositivo":
                    url = "VisorInforme.aspx?Informe=RptResumenEmpresaTipoDispositivo&DesdeFecha=" + par1
                    + "&HastaFecha=" + par2
                    + "&EmpresaId=" + par3
                    + "&TipoDispId=" + par4;
                    panel.set_contentUrl(url);
                    break;
                case "RptFacturableEmpresaTipoDispositivo":
                    url = "VisorInforme.aspx?Informe=RptFacturableEmpresaTipoDispositivo&DesdeFecha=" + par1
                    + "&HastaFecha=" + par2
                    + "&EmpresaId=" + par3
                    + "&TipoDispId=" + par4;
                    panel.set_contentUrl(url);
                    break;
            }
        }
        function CargaInformeEmpresa(informe, par1, par2, par3, par4, par5) {
            var panel = $find("<%= SplReport.ClientID %>");
            var url = "";
            switch (informe) {
                case "RptResumenEmpresa":
                    url = "VisorInforme.aspx?Informe=RptResumenEmpresa&DesdeFecha=" + par1
                    + "&HastaFecha=" + par2
                    + "&EmpresaId=" + par3
                    + "&InstId=" + par4
                    + "&TipoDispId=" + par5;
                    panel.set_contentUrl(url);
                    break;
                case "RptFacturableEmpresa":
                    url = "VisorInforme.aspx?Informe=RptFacturableEmpresa&DesdeFecha=" + par1
                    + "&HastaFecha=" + par2
                    + "&EmpresaId=" + par3
                    + "&InstId=" + par4
                    + "&TipoDispId=" + par5;
                    panel.set_contentUrl(url);
                    break;
            }
        }
        function CargaActa(informe, par1, par2, par3, par4, par5, par6) {
            var panel = $find("<%= SplReport.ClientID %>");
            var url = "";
            url = "VisorInforme.aspx?Informe=RptActa&FechaActa=" + par1
                    + "&ActaNumero=" + par2
                    + "&TecnicoResponsable=" + par3
                    + "&Observaciones=" + par4
                    + "&InstalacionId=" + par5
                    + "&EmpresaId=" + par6;
            panel.set_contentUrl(url);
            CollapseDataPanel();
        }
        function ResizeReportPanel(newHeight) {
            var splitter = $find("<%= SplMain.ClientID %>");
            var pane = splitter.getPaneById("SplReport");
            var heightDelta = newHeight - pane.get_height(); //calculate the delta
            pane.resize(heightDelta, 1);
        }
        function CollapseDataPanel() {
            var splitter = $find("<%= SplMain.ClientID %>");
            var pane = splitter.getPaneById("SplData");
            pane.collapse(2);
        }
    </script>

	<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
        onajaxrequest="RadAjaxManager1_AjaxRequest">
	</telerik:RadAjaxManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
	<telerik:RadSkinManager ID="RadSkinManager1" Runat="server" >
	</telerik:RadSkinManager>
	<div id="MainArea" class="normalText">
         <telerik:RadSplitter ID="SplMain" runat="server" Width="100%" Height="750px" Orientation="Horizontal">
            <telerik:RadPane ID="SplData" runat="server" Height="200px"></telerik:RadPane>
            <telerik:RadSplitBar ID="SplBar" runat="server" CollapseMode="Both"></telerik:RadSplitBar>
            <telerik:RadPane ID="SplReport" runat="server"></telerik:RadPane>
         </telerik:RadSplitter>
	</div>
	</form>
</body>
</html>
