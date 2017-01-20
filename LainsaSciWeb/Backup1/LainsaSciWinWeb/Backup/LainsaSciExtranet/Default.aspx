<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciExtranetEstilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .style1
      {
      width: 141px;
      height: 50px;
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
      <script type="text/javascript" src="MainMenu.js">
        //Put your JavaScript code here.
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager Runat="server" Skin="Metro">
      </telerik:RadSkinManager>
      <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
      <div id="MainArea">
        <div id="Superior" class="txtTitulo">
          <table width="100%">
            <tr>
              <td align="left">
                <img alt="logo50" class="style1" longdesc="logo50" 
                     src="imagenes/Falck%20sci.JPG" />
              </td>
              <td align="right">
                <asp:Label ID="lblTituloDerecho" runat="server" Text="EXTRANET FALCK"></asp:Label>
                <br />
                <asp:Label ID="LblTituloDerechoInferior" runat="server" Text="VRS 1.0.1"></asp:Label>
              </td>
            </tr>
          </table>
        </div>
        <div id="Medio" class="txtNormal">
          <table width="100%">
            <tr>
              <td width="20%"></td>
              <td>
                <div id="Login" style="padding:5px;">
                  <asp:Label ID="lblLogin" runat="server" Text="Usuario:"></asp:Label>
                  <br />
                  <telerik:RadTextBox ID="txtLogin" runat="server" Width="200px">
                  </telerik:RadTextBox>
                  <br />
                  <asp:RequiredFieldValidator ID="valLogin" runat="server" Display="Dynamic" 
                                              ControlToValidate="txtLogin" CssClass="txtNormalRojo"
                                              ErrorMessage="Se necesita un login">
                  </asp:RequiredFieldValidator>
                </div>
              </td>
              <td width="50%"></td>
            </tr>
            <tr>
              <td width="20%"></td>
              <td>
                <div id="Password" style="padding:5px;">
                  <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                  <br />
                  <telerik:RadTextBox ID="txtPassword" runat="server" Width="200px" TextMode="Password">
                  </telerik:RadTextBox>
                  <br />
                  <asp:RequiredFieldValidator ID="valPassword" runat="server" Display="Dynamic" 
                                              ControlToValidate="txtPassword" CssClass="txtNormalRojo"
                                              ErrorMessage="Se necesita una contraseña">
                  </asp:RequiredFieldValidator>
                </div>
              </td>
              <td width="50%"></td>
            </tr>
            <tr>
              <td width="20%"></td>
              <td>
                <div id="Botones" style="padding:5px; text-align:right">
                  <telerik:RadButton ID="btnAceptar" runat="server" Text="Entrar" 
                                     onclick="btnAceptar_Click">
                  </telerik:RadButton>
                  <br />
                  <br />
                  <asp:HyperLink ID="hyperOlvido" runat="server" NavigateUrl="~/Olvido.aspx">He olvidado mi nombre de usuario y/o contraseña.
                  </asp:HyperLink>
                </div>
              </td>
              <td width="50%"></td>
            </tr>
          </table>

        </div>
        <div id="Inferior">
          <telerik:RadNotification ID="RadNotification1" runat="server" 
                                   ContentIcon="imagenes/warning_32.png" AutoCloseDelay="0" 
                                   TitleIcon="imagenes/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                   Height="100px" Position="Center" Title="Atención" Width="300px">
          </telerik:RadNotification>
        </div>

      </div>
    </form>
  </body>
</html>
