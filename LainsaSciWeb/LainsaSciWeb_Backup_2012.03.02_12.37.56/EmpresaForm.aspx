<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpresaForm.aspx.cs" Inherits="EmpresaForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Grupo usuario
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
          function refreshGrid2(arg, frame)
          {
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td width="20%">
              <div id="EmpresaId" style="padding:5px;">
                <asp:Label ID="lblEmpresaId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtEmpresaId" runat="server" Enabled="false" Width="100%">
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
                                            ErrorMessage="Se necesita un nombre para la empresa">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="CodAx" style="padding:5px;">
                <asp:Label ID="lblCodAx" runat="server" Text="Código Ax"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtCodAx" runat="server" Width="100%">
                </telerik:RadTextBox>
                <br />
              </div>
            </td>
            <td>
              <div id="PersonaContacto" style="padding:5px;">
                <asp:Label ID="lblPersonaContacto" runat="server" Text="Persona de contacto"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPersonaContacto" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div id="Direcciones" class="frameConMarco">
                <asp:Label ID="lblDirecciones" runat="server" Text="Direcciones"></asp:Label>
                <br />
                <iframe id="ifDirecciones" runat="server" frameborder="0" width="100%" height="220px"></iframe>
              </div>
            </td>
          </tr>
          <tr>
            <td width="50%">
              <div id="Emails" class="frameConMarco">
                <asp:Label ID="lblEmails" runat="server" Text="Correos electronicos"></asp:Label>
                <br />
                <iframe id="ifEmails" runat="server" frameborder="0" width="100%" height="220px"></iframe>
              </div>
            </td>
            <td>
              <div id="Telefonos" class="frameConMarco">
                <asp:Label ID="Label1" runat="server" Text="Teléfonos"></asp:Label>
                <br />
                <iframe id="ifTelefonos" runat="server" frameborder="0" width="100%" height="220px"></iframe>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="2" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="3" />
              </div>
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
        </table>

      </div>
      <div id="FooterArea">
        <telerik:RadNotification ID="RadNotification1" runat="server" 
                                 ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                                 TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                 Height="100px" Position="Center" Title="WARNING" Width="300px">
        </telerik:RadNotification>
      </div>
    </form>
  </body>
</html>
