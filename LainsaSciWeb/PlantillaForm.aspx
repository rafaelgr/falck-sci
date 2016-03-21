<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlantillaForm.aspx.cs" Inherits="PlantillaForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Plantilla de documento
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
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript">
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td width="20%">
              <div id="PlantillaId" style="padding:5px;">
                <asp:Label ID="lblPlantillaId" runat="server" Text="ID:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPlantillaId" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="Nombre" style="padding:5px;">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtNombre" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valNombre" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtNombre" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita un nombre de Plantilla">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div id="Contenido" style="padding:5px;">
                <asp:Label ID="lblContenido" runat="server" Text="Contenido:"></asp:Label>
                <br />
                <telerik:RadEditor ID="rdeContenido" runat="server" Width="100%" Height="400px" 
                                   ToolsFile="~/Tools/ToolsFile.xml">
                </telerik:RadEditor>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
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
