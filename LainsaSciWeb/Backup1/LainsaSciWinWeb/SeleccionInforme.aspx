<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionInforme.aspx.cs"
    Inherits="SeleccionInforme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Selección para informe </title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #Radio1
        {
            height: 17px;
            width: 21px;
        }
    </style>
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
    </script>
    <script type="text/javascript">
        //Put your JavaScript code here.
        function noHaceNada() {
        }
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
    </telerik:RadSkinManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div id="MainArea" style="margin: auto;">
            <div id="FromDate" class="conMargen" style="float: left">
                <asp:Label ID="lblFromDate" runat="server" CssClass="normalText" Text="Desde fecha"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdtFromDate" runat="server">
                </telerik:RadDatePicker>
                <br />
                <asp:RequiredFieldValidator ID="valFromDate" runat="server" Display="Dynamic" ControlToValidate="rdtFromDate"
                    CssClass="normalTextRed" ErrorMessage="Se necesita una fecha">
                </asp:RequiredFieldValidator>
            </div>
            <div id="ToDate" class="conMargen" style="float: left">
                <asp:Label ID="lblToDate" runat="server" CssClass="normalText" Text="Hasta fecha"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdtToDate" runat="server">
                </telerik:RadDatePicker>
                <br />
                <asp:RequiredFieldValidator ID="valToDate" runat="server" Display="Dynamic" ControlToValidate="rdtToDate"
                    CssClass="normalTextRed" ErrorMessage="Se necesita una fecha">
                </asp:RequiredFieldValidator>
            </div>
            <div id="Dummy9" style="clear: both">
            </div>
            <div id="Empresa" class="conMargen" style="float: left">
                <asp:Label ID="lblEmpresa" runat="server" CssClass="normalText" Text="Empresa"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rcbEmpresa" runat="server" Width="250px" CausesValidation="False"
                    OnSelectedIndexChanged="rcbEmpresa_SelectedIndexChanged" AutoPostBack="True">
                </telerik:RadComboBox>
                <br />
                <asp:RequiredFieldValidator ID="valEmpresa" runat="server" Display="Dynamic" ControlToValidate="rcbEmpresa"
                    CssClass="normalTextRed" ErrorMessage="Elija una empresa">
                </asp:RequiredFieldValidator>
            </div>
            <div id="Instalacion" class="conMargen" style="float: left">
                <asp:Label ID="lblInstalacion" runat="server" CssClass="normalText" Text="Instalación"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rcbInstalacion" runat="server" Width="250px" CausesValidation="False"
                    OnSelectedIndexChanged="rcbInstalacion_SelectedIndexChanged" AutoPostBack="True">
                </telerik:RadComboBox>
                <br />
            </div>
            <div id="TipoDispositivo" class="conMargen" style="float: left">
                <asp:Label ID="lblTipoDispositivo" runat="server" CssClass="normalText" Text="Tipo de dispositivo"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rcbTipoDispositivo" runat="server" Width="250px" CausesValidation="False"
                    OnSelectedIndexChanged="rcbTipoDispositivo_SelectedIndexChanged" 
                    AutoPostBack="True">
                </telerik:RadComboBox>
                <br />
            </div>
            <div id="Dummy1" style="clear: both">
            </div>
            <div id="Exit" class="conMargen" style="float: right">
                <telerik:RadButton ID="btnExit" runat="server" Text="Salir" Visible="false" OnClick="btnExit_Click"
                    CausesValidation="False">
                </telerik:RadButton>
            </div>
            <div id="Preview" class="conMargen" style="float: right">
                <telerik:RadButton ID="btnPreview" runat="server" Text="Vista previa" OnClick="btnPreview_Click">
                </telerik:RadButton>
            </div>
            <div id="Export" class="conMargen" style="float: right">
                <telerik:RadButton ID="btnExport" runat="server" Text="Exportar a documento" OnClick="btnExport_Click">
                </telerik:RadButton>
            </div>
        </div>
         <div id="FooterArea">
        <telerik:RadNotification ID="RadNotification1" runat="server" ContentIcon="images/warning_32.png"
            AutoCloseDelay="0" TitleIcon="images/warning_16.png" EnableRoundedCorners="True"
            EnableShadow="True" Height="100px" Position="Center" Title="WARNING" Width="300px">
        </telerik:RadNotification>
    </div>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
