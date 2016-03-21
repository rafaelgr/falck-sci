<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionFormC.aspx.cs" Inherits="RevisionFormC" %>

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
            <td style="text-align:left;width:25%">
              <div id="Usuario" class="textoReducidoMarco">
                <asp:Label ID="lblUsuario" runat="server" text="USUARIO"></asp:Label>
              </div>
            </td>
            <td style="text-align:center;width:40%">
              <div id="Formulario" class="textoReducidoMarco">
                <asp:Label ID="lblFormulario" runat="server" Text="Revision"></asp:Label>
              </div>
            </td>
            <td style="text-align:right;width:35%">
              <div id="Inicio" class="textoReducidoMarco">
                <telerik:RadButton ID="btnInicio" runat="server" Text="Inicio" 
                                   onclick="btnInicio_Click" CausesValidation="false">
                </telerik:RadButton>
              </div>
            </td>
          </tr>
                    <tr> 
            <td colspan="3">
              <div id="Titulo" class="textoReducidoMarco bordeInferior bordeSuperior">
              <asp:Label ID="lblTitulo" runat="server" Text="Titulo"></asp:Label>
              </div>
            </td>
          </tr>
          <tr> 
            <td colspan="3">
              <div id="Panel" class="textoReducidoMarco bordeInferior bordeSuperior">
              <asp:PlaceHolder ID="PlantillaHolder" runat="server">
                </asp:PlaceHolder>
              </div>
            </td>
          </tr>

          <tr>
            <td style="text-align:left">
            <div id="1" class="textoReducidoMarco">
                <telerik:RadButton ID="btnAnterior" runat="server" Text="<" 
                    onclick="btnAnterior_Click" CausesValidation="false">
                </telerik:RadButton>
                </div>
            </td>
            <td style="text-align:center">
              <div id="Imagen" style="text-align:center">

                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sci_color_30.jpg" Height="20px" />
              </div>

            </td>
            <td style="text-align:right">
            <div id="Div1" class="textoReducidoMarco">
                <telerik:RadButton ID="btnSiguiente" runat="server" Text=">" 
                    onclick="btnSiguiente_Click">
                </telerik:RadButton>
                <telerik:RadButton ID="btnF" runat="server" Text="*" 
                    onclick="btnF_Click">
                </telerik:RadButton>
                </div>
            </td>

          </tr>
        </table>
      </div>
    </form>
  </body>
</html>
