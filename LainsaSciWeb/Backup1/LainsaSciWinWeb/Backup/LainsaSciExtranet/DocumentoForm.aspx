<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentoForm.aspx.cs" Inherits="DocumentoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Documento</title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciExtranetEstilos.css" rel="stylesheet" type="text/css" />
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
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Windows7">
      </telerik:RadSkinManager>
      <div id="Cuerpo" class="txtNormal">
        <telerik:RadSplitter ID="SplMain" runat="server" Width="100%" Height="600px" Orientation="Horizontal">
          <telerik:RadPane ID="SplData" runat="server" Height="95px">
            <div id="Verificador" class="txtData">
              <table width="100%">
                <tr>
                  <td colspan="2">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                  </td>
                </tr>
                <tr>
                  <td colspan="2">
                    <asp:CheckBox ID="chkComprueba" runat="server" Text="" />
                  </td>
                </tr>
                <tr>
                  <td>
                    <asp:Label ID="lblError" runat="server" CssClass="txtDataRojo" Text=""></asp:Label>
                  </td>
                  <td align="right">
                    <telerik:RadButton ID="btnAceptar" runat="server" Text="Aceptar" 
                                       onclick="btnAceptar_Click">
                    </telerik:RadButton>
                  </td>
                </tr>
              </table>
            </div>
          </telerik:RadPane>
          <telerik:RadSplitBar ID="SplBar" runat="server" CollapseMode="Both">
          </telerik:RadSplitBar>
          <telerik:RadPane ID="SplView" runat="server">
          </telerik:RadPane>
        </telerik:RadSplitter>
      </div>

    </form>
  </body>
</html>
