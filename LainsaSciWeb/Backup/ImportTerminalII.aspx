<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportTerminalII.aspx.cs"
    Inherits="LainsaSciWinWeb.ImportTerminalII" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 247px;
        }
        .style4
        {
            width: 310px;
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
   <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        </telerik:RadWindowManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js">
        </script>
        <script type="text/javascript">
            function noHaceNada() {
            }
            function confirmCallBackFn(arg) {
//                radalert("<strong>radconfirm</strong> returned the following result: <h3 style='color: #ff0000;'>" + arg + "</h3>", null, null, "Result");
                if (arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest();
                } 
            }

        </script>
    </telerik:RadCodeBlock>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple" >
    </telerik:RadSkinManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest" >
    </telerik:RadAjaxManager>
    <%--Needed for JavaScript IntelliSense in VS2010--%>
    <div id="MainArea" class="normalText">
  
        <div id="Div2">
            <table width="100%">
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblPath" runat="server" Text="Label" Visible="False"></asp:Label>
                    </td>
                    <td class="style4">
                     <asp:Label ID="Label1" runat="server" Text="Seleccione el fichero a importar:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                       </td>
                    <td class="style4">

                          <telerik:RadUpload ID="RadUpload2" runat="server" MaxFileInputsCount="1" AllowedFileExtensions=".sdf"
                            OnValidatingFile="RadUpload1_ValidatingFile" ControlObjectsVisibility="None" 
                              Width="371px">
                        </telerik:RadUpload>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Por favor seleccione un fichero."
                            OnServerValidate="CustomValidator1_ServerValidate" CssClass="normalTextRed"></asp:CustomValidator>
                   

                            <asp:Label ID="Label2" runat="server" Text="Formato incorrecto" CssClass="normalTextRed"
                                Visible="False"></asp:Label>

                    </td>
                    <td>
                       
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                      
                      
                    </td>
                    <td class="style4">
                     <telerik:RadButton ID="RadButton2" runat="server" OnClick="RadButton1_Click" Text="Importar">
                        </telerik:RadButton>
                    </td>
                    <td>
                    
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