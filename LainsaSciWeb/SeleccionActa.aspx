<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionActa.aspx.cs"
    Inherits="SeleccionActa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Selección para informe </title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
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
            <div id="FechaActa" class="conMargen" style="float: left">
                <asp:Label ID="lblFechaActa" runat="server" CssClass="normalText" Text="Fecha del acta"
                    Width="200px"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdtFechaActa" runat="server">
                </telerik:RadDatePicker>
                <br />
                <asp:RequiredFieldValidator ID="valFechaActa" runat="server" Display="Dynamic" ControlToValidate="rdtFechaActa"
                    CssClass="normalTextRed" ErrorMessage="Se necesita una fecha">
                </asp:RequiredFieldValidator>
            </div>
            <div id="Dummy2" style="clear: both;">
            </div>
            <div id="Empresa" class="conMargen" style="float: left">
                <asp:Label ID="lblEmpresa" runat="server" CssClass="normalText" Text="Empresa"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rcbEmpresa" runat="server" Width="250px" 
                    CausesValidation="False" 
                    onselectedindexchanged="rcbEmpresa_SelectedIndexChanged" AutoPostBack="True">
                </telerik:RadComboBox>
                <br />
                <asp:RequiredFieldValidator ID="valEmpresa" runat="server" Display="Dynamic"
                    ControlToValidate="rcbEmpresa" CssClass="normalTextRed" ErrorMessage="Elija una Empresa">
                </asp:RequiredFieldValidator>
            </div>
            <div id="Instalacion" class="conMargen" style="float: left">
                <asp:Label ID="lblInstalacion" runat="server" CssClass="normalText" Text="Instalación"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rcbInstalacion" runat="server" Width="250px" 
                    CausesValidation="False">
                </telerik:RadComboBox>
                <br />
            </div>
            <div id="Dummy3" style="clear: both;">
            </div>
            <div id="ActaNumero" class="conMargen" style="float: left">
                <asp:Label ID="lblActaNumero" runat="server" CssClass="normalText" Text="Acta número"
                    Width="200px"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtActaNumero" runat="server">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                    ControlToValidate="txtActaNumero" CssClass="normalTextRed" ErrorMessage="Número de acta necesario">
                </asp:RequiredFieldValidator>
            </div>
            <div id="Usuario" class="conMargen" style="float: left">
                <asp:Label ID="lblUsuario" runat="server" CssClass="normalText" Text="Técnico responsable"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rcbUsuario" runat="server" Width="250px" CausesValidation="False">
                </telerik:RadComboBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ControlToValidate="rcbUsuario" CssClass="normalTextRed" ErrorMessage="Elija una usuario">
                </asp:RequiredFieldValidator>
            </div>
            <div id="Dummy4" style="clear: both;">
            </div>
            <div id="Observaciones" class="conMargen" style="float: left">
                <asp:Label ID="lblObservaciones" runat="server" CssClass="normalText" Text="Observaciones"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Width="465px"
                    Height="100px">
                </telerik:RadTextBox>
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
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
