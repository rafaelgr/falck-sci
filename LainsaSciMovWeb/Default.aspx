<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta name="viewport" content="width=240" />
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="EstiloMovil.css" rel="stylesheet" type="text/css" />
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
      <script type="text/javascript">
        //Put your JavaScript code here.
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <div id="Marco" class="marcoMobil">
        <table width="100%">
          <tr>
            <td>
              <div id="Imagen" style="text-align:center">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sci_color_50.jpg" />
              </div>
            </td>
          </tr>

          <tr>
            <td>
              <div id="Titulo" class="textoTituloMarco">
                <asp:Label ID="lblTitulo" runat="server" Text="Revisión DCI VRS 2003">
                </asp:Label>
              </div>
            </td>
          </tr>
          <tr>
            <td style="padding-left:10%">
              <div id="Usuario" class="textoNormalMarco">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:">
                </asp:Label>
                <br />
                <telerik:RadTextBox ID="txtUsuario" runat="server">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="valUsuario"  runat="server" ControlToValidate="txtUsuario" CssClass="textoNormalRojo" 
                                            ErrorMessage="Introduzca un usuario">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
                    <tr>
            <td style="padding-left:10%">
              <div id="Password" class="textoNormalMarco">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:">
                </asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  runat="server" ControlToValidate="txtPassword" CssClass="textoNormalRojo" 
                                            ErrorMessage="Introduzca una contraseña">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
        <tr>
            <td style="text-align:right">
                <div id="Botones" class="textoNormalMarco">
                    <telerik:RadButton ID="btnAceptar" runat="server" Text="Aceptar" 
                        onclick="btnAceptar_Click">
                    </telerik:RadButton>
                </div>
            </td>
          </tr>
        </table>
      </div>
              <div id="Pie">
          <telerik:RadNotification ID="RadNotification1" runat="server" 
                                   ContentIcon="imagenes/warning_32.png" AutoCloseDelay="0" 
                                   TitleIcon="imagenes/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                   Height="300px" Position="Center" Title="WARNING" Width="200px">
          </telerik:RadNotification>
        </div>
    </form>
  </body>
</html>
