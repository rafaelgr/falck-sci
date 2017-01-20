<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentoView.aspx.cs" Inherits="DocumentoView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
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
      <script type="text/javascript" src="GridForm.js">
        //Put your JavaScript code here.
      </script>
      <script type="text/javascript">
        function loadValues(values)
        {
            var splitter = $find("<%= SplMain.ClientID %>");
            var pane = splitter.getPaneById("<%= SplData.ClientID %>");
            var iframe = pane.getExtContentElement();
            var contentWindow = iframe.contentWindow;
            contentWindow.loadValues(values);
        }
        function refreshGrid(arg)
        {
            if (arg == "new")
                closeWindowRefreshGrid("RepositorioTmpForm", "new");
            else
            {
                var cl = gup("Caller");
                closeWindowRefreshGrid(cl, arg);
            }
        }
      </script>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <div id="MainArea" class="normalText">
        <telerik:RadSplitter ID="SplMain" runat="server" Width="100%" Height="600px" Orientation="Vertical">
          <telerik:RadPane ID="SplView" runat="server" Width="30%">
          </telerik:RadPane>
          <telerik:RadSplitBar ID="SplBar" runat="server" CollapseMode="Both">
          </telerik:RadSplitBar>
          <telerik:RadPane ID="SplData" runat="server" Width="70%">
          </telerik:RadPane>
        </telerik:RadSplitter>
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
