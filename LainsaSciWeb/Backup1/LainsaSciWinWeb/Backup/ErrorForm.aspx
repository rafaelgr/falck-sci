<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorForm.aspx.cs" Inherits="ErrorForm" %>

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
      <script type="text/javascript" src="GridForm.js"></script>
      <script type="text/javascript">
          function refreshGrid2(arg, frame) {
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
      </telerik:RadSkinManager>
      <div dir="MainArea" class="normalText">
        <table style="width:100%">
          <tr>
            <td colspan="2" class="tituloError">
              <asp:Label ID="lblTitle" runat="server" Text="Se ha producido un error con la siguiente información"></asp:Label>
            </td>
          </tr>  
          <tr>
            <td>
              <asp:Label ID="lblFechaHora" runat="server" Text="Fecha y hora: " CssClass="errorLabel"></asp:Label>
            </td>
            <td>
              <asp:Label  ID="txtFechaHora" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblProceso" runat="server" Text="Proceso: " CssClass="errorLabel"></asp:Label>
            </td>
            <td>
              <asp:Label  ID="txtProceso" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblUsuario" runat="server" Text="Usuario: " CssClass="errorLabel"></asp:Label>
            </td>
            <td>
              <asp:Label  ID="txtUsuario" runat="server"></asp:Label>
            </td>
          </tr>

          <tr>
            <td style="vertical-align:top">
              <asp:Label ID="lblError" runat="server" Text="Datos: " CssClass="errorLabel"></asp:Label>
            </td>
            <td>
              <asp:Label  ID="txtError" runat="server"></asp:Label>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="8" />
              </div>
            </td>
          </tr>
        </table>
      </div>
    </form>
  </body>
</html>
