<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispositivoTab.aspx.cs" Inherits="DispositivoTab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Dispositivo</title>
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
            function loadValues(values) {
                var iframe = document.getElementById("ifTabDispositivo");
                iframe.contentWindow.loadValues(values);
            }
            function refreshGrid2(arg, frame) {
                // search for the iframe (is allways the same)
                var iframe = document.getElementById("ifTabDispositivo");
                iframe.contentWindow.refreshGrid2(arg, frame);
            }
            function refreshGrid(arg) {
                var iframe = document.getElementById("ifTabDispositivo");
                iframe.contentWindow.refreshGrid(arg);
            }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText" style="width:100%">
        <table width="100%">
          <tr>
            <td>
              
            </td><telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
                    ontabclick="RadTabStrip1_TabClick" SelectedIndex="1">
                <Tabs>
                  <telerik:RadTab runat="server" Text="General" Value="general" Selected="True">
                  </telerik:RadTab>
                  <telerik:RadTab runat="server" Text="Accesorios" Value="accesorios">
                  </telerik:RadTab>
                  <telerik:RadTab runat="server" Text="Revisiones" Value="revisiones">
                  </telerik:RadTab>
                  <telerik:RadTab runat="server" Text="Incidencias" Value="incidencias">
                  </telerik:RadTab>
                </Tabs>
              </telerik:RadTabStrip>
          </tr>
          <tr>
            <td>
              <iframe id="ifTabDispositivo" runat="server" frameborder="0" width="100%" height="600px"></iframe>
            </td>
          </tr>
          <tr>
            <td>
              <telerik:RadNotification ID="RadNotification1" runat="server" 
                                       ContentIcon="images/error_32.png" AutoCloseDelay="0" 
                                       TitleIcon="images/error_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                       Height="400px" Position="Center" Title="ERROR" Width="400px">
              </telerik:RadNotification>
            </td>
          </tr>
        </table>
      </div>
    </form>
  </body>
</html>
