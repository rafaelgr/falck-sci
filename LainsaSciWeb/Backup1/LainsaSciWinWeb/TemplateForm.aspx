<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateForm.aspx.cs" Inherits="TemplateForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Planificar revisión no periodica
    </title>
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
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <div id="MainArea">
          <div id="Numerico" class="normalText">
            <asp:Label ID="lblNumerico" runat="server" Text="Numero"></asp:Label>
            <br />
            <telerik:RadNumericTextBox ID="txtNumero" runat="server" CausesValidation="false">
            </telerik:RadNumericTextBox>
            <br />
            <asp:RequiredFieldValidator ID="valNumerico" runat="server" Display="Dynamic" 
                                        ControlToValidate="txtNumero" CssClass="normalTextRed"
                                        ErrorMessage="Se necesita un número">
            </asp:RequiredFieldValidator>
          </div>
        </div>
        <div id="Texto" class="normalText">
            <asp:Label ID="lblTexto" runat="server" Text="Texto"></asp:Label>
            <br />
            <telerik:RadTextBox ID="txtTexto" runat="server" CausesValidation="false">
            </telerik:RadTextBox>
            <br />
            <asp:RequiredFieldValidator ID="vaTexto" runat="server" Display="Dynamic" 
                                        ControlToValidate="txtTexto" CssClass="normalTextRed"
                                        ErrorMessage="Se necesita un valor">
            </asp:RequiredFieldValidator>
        </div>
        <div id="ComboBox" class="normalText">
                <asp:Label ID="lblCombo" runat="server" Text="Combo:"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgCombo" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchCombos('TemplateForm');" 
                                 ToolTip="Haga clic aquí para buscar" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcCombo" Height="100px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" 
                                     onitemsrequested="rdcCombo_ItemsRequested" 
                                     onselectedindexchanged="rdcCombo_SelectedIndexChanged">
                </telerik:RadComboBox>
                            <br />
            <asp:RequiredFieldValidator ID="valCombo" runat="server" Display="Dynamic" 
                                        ControlToValidate="rdcCombo" CssClass="normalTextRed"
                                        ErrorMessage="Se necesita un valor">
            </asp:RequiredFieldValidator>
        </div>
        <div id="Fecha">
            <asp:Label ID="lblFecha" runat="server" CssClass="normalText" Text="Hasta fecha"></asp:Label>
            <br />
            <telerik:RadDatePicker ID="rdtFecha" runat="server"></telerik:RadDatePicker>
            <br />
            <asp:RequiredFieldValidator ID="valFecha" runat="server" Display="Dynamic" 
                                        ControlToValidate="rdtFecha" CssClass="normalTextRed"
                                        ErrorMessage="Se necesita una fecha">
            </asp:RequiredFieldValidator>
        </div>
        <div id="MultiLinea">
        </div>
        <div id="Estado">
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
