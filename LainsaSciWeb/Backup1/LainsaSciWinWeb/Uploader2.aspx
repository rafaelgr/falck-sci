<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploader2.aspx.cs" Inherits="Uploader2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    </head>
    <body>
        <form id="form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>
            <script type="text/javascript">
            </script>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server"></telerik:RadSkinManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
            <div>
                <div id="TitleZone" class="row-fluid table-header">
                    <asp:Label ID="lblTitle" runat="server" Text="Cargar ficheros"></asp:Label>
                </div>
                <div>
                    <table id="TLoader">
                        <tr>
                            <td>
                                <div>
                                    <asp:Label ID="lblAddtionalInformation" runat="server" Text="Información adicional:"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <telerik:RadAsyncUpload ID="rdUploader" runat="server" MaxFileInputsCount="1" ControlObjectsVisibility="None" InputSize="100" Skin="Simple" >
                                        <Localization Select="Seleccionar..." />
                                    </telerik:RadAsyncUpload>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align:right;">
                                    <telerik:RadButton ID="btnLoader" runat="server" Text="Cargar Fichero" OnClick="btnLoader_Click"></telerik:RadButton>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div>
                                    <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />
                                    <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Width="400px"></telerik:RadProgressArea>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
    </body>
</html>
