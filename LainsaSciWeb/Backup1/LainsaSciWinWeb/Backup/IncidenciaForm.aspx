<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncidenciaForm.aspx.cs"
    Inherits="LainsaSciWinWeb.IncidenciaForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incidencia</title>
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
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript">
            function newIncidencia(id) {
                var url = "DispositivoTab.aspx?Caller=IncidenciaGrid" + "&DispositivoId=" + id;
                var name = "DispositivoTab";
                openOutSide(url, name);
            }
            function newIncidenciaRevision(id) {
                var url = "IncidenciaGrid.aspx?Caller=IncidenciaGrid" + "&DispositivoId=" + id;
                var name = "IncidenciaGrid";
                openOutSide(url, name);
            }
            function loadValues(values) {
                var combo;
                if (values[2] == "Dispositivo") {
                    combo = $find("<%=rdcDispositivo.ClientID %>");
                }
                loadCombo(combo, values);
            }
            function loadCombo(combo, values) {
                var items = combo.get_items();
                items.clear();
                var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                comboItem.set_text(values[1]);
                comboItem.set_value(values[0]);
                items.add(comboItem);
                combo.commitChanges();
                comboItem.select();
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
    </telerik:RadSkinManager>
    <div id="MainArea" class="normalText">
        <table style="width: 100%;">
            <tr>
                <td>
                    <div id="Fecha" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
                        <br />
                        <telerik:RadTextBox ID="txtFecha" runat="server" Enabled="false" Width="200px" TabIndex="2">
                        </telerik:RadTextBox>
                    </div>
                </td>
                <td>
                    <div id="Usuario" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
                        <br />
                        <telerik:RadTextBox ID="txtUsuario" runat="server" Enabled="false" Width="200px"
                            TabIndex="2">
                        </telerik:RadTextBox>
                    </div>
                </td>
                <td>
                    <div id="Operativo" class="normalText" style="padding: 5px;">
                        <asp:CheckBox ID="chkOperativo" runat="server" Text="Dispositivo inoperativo" Checked="False" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Dispositivo" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblDispositivo" runat="server" Text="Dispositivo:" ToolTip="Dispositivo al que afecta la incidencia"></asp:Label>
                        &nbsp;
                        <asp:ImageButton ID="imgDispositivo" runat="server" CausesValidation="false" ImageUrl="~/images/search_mini.png"
                            OnClientClick="searchDispositivo('IncidenciaForm');" ToolTip="Haga clic aquí para buscar dispositivos" />
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcDispositivo" Height="18px" Width="385px"
                            ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                            EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" OnItemsRequested="rdcDispositivo_ItemsRequested">
                        </telerik:RadComboBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="Comentarios" style="padding: 5px;">
                        <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                        <br />
                        <telerik:RadTextBox ID="txtComentarios" runat="server" Width="100%" Rows="3" TabIndex="10"
                            TextMode="MultiLine" MaxLength="254">
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Rellenar campo" 
                            ControlToValidate="txtComentarios" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div id="Buttons" class="buttonsFormat">
                        &nbsp;
                        <asp:ImageButton ID="btnAccept" runat="server" ImageUrl="~/images/document_ok.png"
                            OnClick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="11" />
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/document_out.png"
                            CausesValidation="False" OnClick="btnCancel_Click" ToolTip="Salir sin guardar"
                            TabIndex="12" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="FooterArea">
        <telerik:RadNotification ID="RadNotification1" runat="server" ContentIcon="images/warning_32.png"
            AutoCloseDelay="0" TitleIcon="images/warning_16.png" EnableRoundedCorners="True"
            EnableShadow="True" Height="100px" Position="Center" Title="WARNING" Width="300px">
        </telerik:RadNotification>
    </div>
    </form>
</body>
</html>
