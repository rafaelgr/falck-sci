<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarTerminal.aspx.cs"
    Inherits="LainsaSciWinWeb.ImportarTerminal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
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
                var oExplorer = $find("<%= RadFileExplorer1.ClientID %>");
                var oAjaxPanel = $find("<%= RadAjaxPanel1.ClientID %>");
                var selectedItem = oExplorer.get_selectedItem();
                if (selectedItem) {
                    var itemPath = selectedItem.get_path(); // get the path of the current item  
                    oAjaxPanel.ajaxRequest(itemPath); // Call the RadAjaxPanel1_AjaxRequest function on the server ;  
                }
            }
            function refreshGrid() {
                // refresca el esplorador de ficheros.
                $find("<%= RadFileExplorer1.ClientID %>").refresh();
            }
            function confirmCallBackFn(arg) {
                if (arg != "") {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("B" + arg);
                } else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("X" + arg);
                }
            }
            function OnClientProgressStartedHandler(sender, e) {
                var modalPopupBehavior = $find('ModalPopupExtender1');
                modalPopupBehavior.show();
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
    </telerik:RadSkinManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <%--  <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>--%>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
        Width="100%" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <div id="MainArea" class="normalText">
            <div id="Div2">
                <table width="100%">
                    <tr>
                        <td>
                            <telerik:RadFileExplorer ID="RadFileExplorer1" runat="server" Width="100%" OnClientFileOpen="OnClientFileOpen"
                                EnableCreateNewFolder="false" EnableCopy="True" Style="margin-top: 0px" InitialPath="/BD"
                                EnableOpenFile="False" Height="176px">
                                <Configuration ViewPaths="/BD" UploadPaths="/BD" DeletePaths="/BD" SearchPatterns="*.sdf"
                                    MaxUploadFileSize="80480000" />
                            </telerik:RadFileExplorer>
                            <%--  <asp:Button ID="btn_hidden" Visible="False" runat="server"/>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="panel1" runat="server">
                <div id="Div1">
                    <telerik:RadProgressManager ID="RadProgressManager2" runat="server"/>
                    <telerik:RadProgressArea ID="RadProgressArea2" runat="server" Width="100%" ProgressIndicators="TotalProgressBar, TotalProgress, TotalProgressPercent, RequestSize, FilesCountBar, FilesCount, FilesCountPercent, SelectedFilesCount, CurrentFileName, TimeElapsed">
                        <Localization Uploaded="Procesado" Cancel="Cancelar" ElapsedTime="Tiempo transcurrido: ">
                        </Localization>
                    </telerik:RadProgressArea>
                  
               <%--   <cc1:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="btn_hidden" PopupControlID="panel1"
                        runat="server" DropShadow="True">
                    </cc1:ModalPopupExtender>--%>
                </div>
            </asp:Panel>
        </div>
        <div id="FooterArea">
            <telerik:RadNotification ID="RadNotification1" runat="server" ContentIcon="images/warning_32.png"
                AutoCloseDelay="0" TitleIcon="images/warning_16.png" EnableRoundedCorners="True"
                EnableShadow="True" Height="138px" Position="Center" Title="WARNING" Width="302px">
            </telerik:RadNotification>
            <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
                Text="RadButton">
            </telerik:RadButton>
            <telerik:RadUpload ID="RadUpload1" Runat="server">
            </telerik:RadUpload>
        </div>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
<%--<div id="Div1">
            <telerik:RadProgressManager ID="RadProgressManager2" runat="server" />
            <telerik:RadProgressArea ID="RadProgressArea2" runat="server" Width="100%" ProgressIndicators="TotalProgressBar, TotalProgress, TotalProgressPercent, RequestSize, FilesCountBar, FilesCount, FilesCountPercent, SelectedFilesCount, CurrentFileName, TimeElapsed">
                <Localization Uploaded="Procesado" Cancel="Cancelar" ElapsedTime="Tiempo transcurrido: ">
                </Localization>
            </telerik:RadProgressArea>
        </div>--%>