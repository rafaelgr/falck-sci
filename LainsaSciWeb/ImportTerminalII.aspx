<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportTerminalII.aspx.cs"
Inherits="LainsaSciWinWeb.ImportTerminalII" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
            </telerik:RadWindowManager>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript" src="GridForm.js">
                </script>
                <script type="text/javascript">
                    function noHaceNada() {
                        closeWindow();
                    }
                    function confirmCallBackFn(arg) {
                        //                radalert("<strong>radconfirm</strong> returned the following result: <h3 style='color: #ff0000;'>" + arg + "</h3>", null, null, "Result");
                        if (arg) {
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest('callback1');
                        } 
                    }
                    function onClientFileUploaded(sender, args) {
                        //var contentType = args.get_fileInfo().ContentType;
                        //alert(contentType);
                        //console.log(args.get_fileInfo());
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(args.get_fileName());
                    }

                    function callLog(arg) {
                        console.log(arg);
                    }

                </script>
            </telerik:RadCodeBlock>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server"  >
            </telerik:RadSkinManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" >
            </telerik:RadAjaxManager>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <div id="MainArea" class="normalText">

                <div id="Div2">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblPath" runat="server" Text="Label" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Seleccione el fichero a importar:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>

                                <telerik:RadAsyncUpload ID="RadUpload2" runat="server" MaxFileInputsCount="1" AllowedFileExtensions=".sdf"
                                                   OnValidatingFile="RadUpload1_ValidatingFile" ControlObjectsVisibility="None"  PostbackTriggers="btnCargar"
                                                   Width="371px" TemporaryFolder="~/TermFiles" OnClientFileUploaded="onClientFileUploaded">
                                </telerik:RadAsyncUpload>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Por favor seleccione un fichero."
                                                     OnServerValidate="CustomValidator1_ServerValidate" CssClass="normalTextRed"></asp:CustomValidator>

                                <asp:Label ID="Label2" runat="server" Text="Formato incorrecto" CssClass="normalTextRed"
                                           Visible="False"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td >
                                <telerik:RadButton ID="btnCargar" runat="server" OnClick="btnCargar_Click" Text="Cargar">
                                </telerik:RadButton>
                                <telerik:RadButton ID="btnImportOK" runat="server" Text="Importar" Visible="false" OnClick="ImportOK_Click"></telerik:RadButton>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="lbInf" runat="server" Text="Mensajes"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtInf" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="panel1" runat="server">
                    <div id="Div1">
                        <telerik:RadProgressManager ID="RadProgressManager2" runat="server" />
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
                                         EnableShadow="True" Height="138px" Position="Center" Title="WARNING" 
                                         Width="302px">
                </telerik:RadNotification>
                <telerik:RadNotification ID="RadNotification2" runat="server" ContentIcon="images/warning_32.png"
                                         AutoCloseDelay="0" TitleIcon="images/warning_16.png" EnableRoundedCorners="True"
                                         EnableShadow="True" Height="353px" Position="Center" Title="WARNING" 
                                         Width="302px">
                </telerik:RadNotification>
            </div>
        </form>
    </body>
</html>
<%--  <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
</telerik:RadWindowManager>--%>