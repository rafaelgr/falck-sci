<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramaList.aspx.cs" Inherits="ProgramaList" %>

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
        <table>
          <tr>
            <td style="text-align:left">
              <div id="Usuario" class="textoReducidoMarco">
                <asp:Label ID="lblUsuario" runat="server" text="USUARIO"></asp:Label>
              </div>
            </td>
            <td>
              <div id="Formulario" class="textoReducidoMarco">
                <asp:Label ID="lblFormulario" runat="server" Text="Programas"></asp:Label>
              </div>
            </td>
            <td style="text-align:right">
              <div id="Inicio" class="textoReducidoMarco">
                <telerik:RadButton ID="btnInicio" runat="server" Text="Salir" 
                                   onclick="btnInicio_Click">
                </telerik:RadButton>
              </div>
            </td>
          </tr>

          <tr> 
            <td colspan="3">
              <div id="Panel" class="textoReducidoMarco bordeInferior bordeSuperior">
                <telerik:RadPanelBar ID="RadPanelBar1" Runat="server" Width="200px">
                </telerik:RadPanelBar>
              </div>
            </td>
          </tr>

          <tr>
            <td style="text-align:left">

            </td>
            <td style="text-align:center">
              <div id="Imagen" style="text-align:center">

                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sci_color_50.jpg" Height="20px" />
              </div>

            </td>
            <td style="text-align:right">

            </td>

          </tr>
        </table>
      </div>
    </form>
  </body>
</html>
