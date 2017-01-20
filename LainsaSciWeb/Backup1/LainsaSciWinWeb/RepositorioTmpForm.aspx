<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepositorioTmpForm.aspx.cs" Inherits="RepositorioTmpForm" %>

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
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js">
        </script>
        <script type="text/javascript">
            function OnClientFileOpen(sender, args) {
                var name = args.get_item().get_name();
                var url = "DocumentoView.aspx?FileName=" + name;
                args.set_cancel(true); // evitamos que abra su propia ventana
                openOutSide(url, "DocumentoView");
            }
            function refreshGrid() {
                // refresca el esplorador de ficheros.
                $find("<%= RadFileExplorer1.ClientID %>").refresh();
            }
        </script>
    </telerik:RadCodeBlock>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <div id="MainArea" class="normalText">
        <table width="100%">
          <tr>
            <td>
              <telerik:RadFileExplorer ID="RadFileExplorer1" Runat="server" Width="100%" 
                                       OnClientFileOpen="OnClientFileOpen" EnableCreateNewFolder="false"
                                       EnableCopy="True" style="margin-top: 0px">
                <Configuration ViewPaths="/Repo" UploadPaths="/Repo"
                               DeletePaths="/Repo" />
              </telerik:RadFileExplorer>
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
