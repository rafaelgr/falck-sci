<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelefonoForm.aspx.cs" Inherits="TelefonoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Telefono</title>
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
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js"></script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td colspan="2" style="padding:5px">
              <div id="Propietario">
                <asp:Label ID="lblPropietario" runat="server" Text="" />
                <br />
                <telerik:RadTextBox ID="txtPropietario" runat="server" Enabled="false" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div id="Numero" style="padding:5px">
                <asp:Label ID="Label1" runat="server" Text="Número de teléfono"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtNumero" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valNumero" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtNumero" CssClass="normalTextRed"
                                            ErrorMessage="Debe introducir un número de teléfono">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="padding:5px">
              <div id="Descripcion">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDescripcion" runat="server" Width="100%" Height="100px"
                                    TabIndex="2" TextMode="MultiLine">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="padding:5px">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="4" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="5" />
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              &nbsp;
            </td>
          </tr>
        </table>
      </div>
      <div id="FooterArea">
        <telerik:RadNotification ID="RadNotification1" runat="server" 
                                 ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                                 TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                 Height="100px" Position="Center" Title="WARNING" Width="250px">
        </telerik:RadNotification>
      </div>
    </form>
  </body>
</html>
