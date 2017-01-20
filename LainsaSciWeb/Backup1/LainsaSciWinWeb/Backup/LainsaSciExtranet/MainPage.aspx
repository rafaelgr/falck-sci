<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciExtranetEstilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
      .style1
      {
      width: 125px;
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
      <script type="text/javascript">
        //Put your JavaScript code here.
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager Runat="server" Skin="Windows7">
      </telerik:RadSkinManager>
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
      </telerik:RadAjaxLoadingPanel>
      <div id="MainArea">
        <div id="Superior" class="txtTitulo">
          <table width="100%">
            <tr>
              <td align="left">

                <img alt="logo50" class="style1" longdesc="logo50" 
                     src="imagenes/Falck%20sci.JPG" />
              </td>
              <td align="right">
                <asp:Label ID="lblTituloDerecho" runat="server" Text="FALCK EXTRANET"></asp:Label>
                <br />
                <asp:Label ID="LblTituloDerechoInferior" runat="server" Text="VRS 1.0.1"></asp:Label>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <telerik:RadMenu ID="RadMenu1" Runat="server" Width="100%" 
                                 onitemclick="RadMenu1_ItemClick" 
                      style="top: 0px; left: 0px; height: 41px; margin-bottom: 29px">
                  <Items>
                    <telerik:RadMenuItem runat="server" Text="Salir" Value="salir">
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem runat="server" Text="Documentos a revisar" Value="revisar" 
                          Visible="False">
                    </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Text="Información de usuario" 
                          Value="usuario">
                      </telerik:RadMenuItem>
                  </Items>

<WebServiceSettings>
<ODataSettings InitialContainerName=""></ODataSettings>
</WebServiceSettings>
                </telerik:RadMenu>
              </td>
            </tr>
          </table>
        </div>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="700px" 
                              Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
          <div id="Medio" class="txtNormal">
            <telerik:RadSplitter ID="SplMain" runat="server" Width="100%" Height="600px" Orientation="Vertical">
              <telerik:RadPane ID="SplView" runat="server" Width="30%">
                <telerik:RadPanelBar ID="RadPanelBar1" runat="server" Width="100%" 
                      onitemclick="RadPanelBar1_ItemClick">
                  <Items>
                    <telerik:RadPanelItem Text="Documentos" Expanded="true">
                      <ItemTemplate>
                        <telerik:RadTreeView ID="RadTreeView1" runat="server" 
                                             onnodeclick="RadTreeView1_NodeClick">
                        </telerik:RadTreeView>
                      </ItemTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Text="Mensajes" Expanded="true">
                        <Items>

                        </Items>
                    </telerik:RadPanelItem>
                  </Items>
                </telerik:RadPanelBar>
              </telerik:RadPane>
              <telerik:RadSplitBar ID="SplBar" runat="server" CollapseMode="Both">
              </telerik:RadSplitBar>
              <telerik:RadPane ID="SplData" runat="server" Width="70%">
              </telerik:RadPane>
            </telerik:RadSplitter>
      
          </div>
        </telerik:RadAjaxPanel>
        <div id="Inferior">
        </div>

      </div>
    </form>
  </body>
</html>

