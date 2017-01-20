<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SustitucionForm.aspx.cs"
    Inherits="SustitucionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sustitucion de dispositivo </title>
    <%-- <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />--%>
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
                var combo;
                if (values[2] == "Dispositivo") {
                    combo = $find("<%=rdcDispositivoOriginal.ClientID %>");
                }
                if (values[2] == "Dispositivo2") {
                    combo = $find("<%=rdcDispositivoSustituto.ClientID %>");
                }
                loadCombo(combo, values);
            }
            function loadCombo(combo, values) {
                var items;
                if (combo != null) {
                    items = combo.get_items();
                    items.clear();
                }
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
            <td></td>
              <td width="10%">
                    <div id="SustitucionId" style="padding: 5px;">
                        <asp:Label ID="lblSustitucionId" runat="server" Text="ID"></asp:Label>
                        <br />
                        <telerik:RadTextBox ID="txtSustitucionId" runat="server" Enabled="false" Width="100%"
                            TabIndex="1">
                        </telerik:RadTextBox>
                    </div>
                </td>
                <td></td>
                <td>
                    <asp:RadioButton ID="rbInt" runat="server" Checked="True" GroupName="ub" 
                        Text="Intercambiar ubicaciones" />
                    <br />
                      <asp:RadioButton ID="rbMant" runat="server" GroupName="ub" 
                        Text="Mantener  ubicaciones" />
                </td>
            </tr>
            <tr>
              <td></td>
                <td>
                    <div id="Fecha" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha sustitución:"></asp:Label>
                        <br />
                        <telerik:RadDatePicker ID="dtpFecha" runat="server" Width="150px" TabIndex="7">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                FastNavigationStep="12">
                            </Calendar>
                            <DateInput DisplayDateFormat="d/MM/yyyy" DateFormat="d/MM/yyyy" TabIndex="7">
                            </DateInput>
                            <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                        </telerik:RadDatePicker>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="dtpFecha" CssClass="normalTextRed" ErrorMessage="Fecha necesaria">
                        </asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div id="Usuario" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcUsuario" Height="100px" CausesValidation="false"
                            Width="150px" ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true"
                            EnableVirtualScrolling="true" TabIndex="5" AutoPostBack="True">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                            ControlToValidate="rdcUsuario" CssClass="normalTextRed" ErrorMessage="Se necesita usuario">
                        </asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div id="Estado" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcEstado" Height="100px" CausesValidation="false"
                            Width="150px" ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true"
                            EnableVirtualScrolling="true" TabIndex="5" AutoPostBack="True">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                            ControlToValidate="rdcEstado" CssClass="normalTextRed" ErrorMessage="Se necesita estado">
                        </asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
                    <div id="DispositivoOriginal" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblDispositivoOriginal" runat="server" Text="Dispositivo a sustituir:"
                            ToolTip="Dispositivo original"></asp:Label>
                        &nbsp;
                        <asp:ImageButton ID="imgDispositivoOriginal" runat="server" CausesValidation="false"
                            ImageUrl="~/images/search_mini.png" OnClientClick="searchDispositivo('SustitucionForm');"
                            ToolTip="Haga clic aquí para buscar DispositivoOriginals" />
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcDispositivoOriginal" Height="100px" CausesValidation="false"
                            Width="100%" ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true"
                            EnableVirtualScrolling="true" EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True"
                            OnItemsRequested="rdcDispositivoOriginal_ItemsRequested" OnSelectedIndexChanged="rdcDispositivoOriginal_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                            ControlToValidate="rdcDispositivoOriginal" CssClass="normalTextRed" ErrorMessage="Se necesita un dispositivo">
                        </asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
                    <div id="DispositivoSustituto" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblDispositivoSustituto" runat="server" Text="Dispositivo sustituto:"
                            ToolTip="Dispositivo sustituto"></asp:Label>
                        &nbsp;
                        <asp:ImageButton ID="imgDispositivoSustituto" runat="server" CausesValidation="false"
                            ImageUrl="~/images/search_mini.png" OnClientClick="searchDispositivo2('SustitucionForm');"
                            ToolTip="Haga clic aquí para buscar dispositivos" />
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcDispositivoSustituto" Height="100px" CausesValidation="false"
                            Width="100%" ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true"
                            EnableVirtualScrolling="true" EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                            ControlToValidate="rdcDispositivoSustituto" CssClass="normalTextRed" ErrorMessage="Se necesita un dispositivo">
                        </asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
                    <div id="Comentarios" class="normalText" style="padding: 5px;">
                        <asp:Label ID="lblComentarios" runat="server" Text="Comentarios"></asp:Label>
                        <br />
                        <telerik:RadTextBox ID="txtComentarios" runat="server" Width="100%" Height="50px"
                            TextMode="MultiLine" TabIndex="1">
                        </telerik:RadTextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="Buttons" class="buttonsFormat">
                        <asp:ImageButton ID="btnAccept" runat="server" ImageUrl="~/images/document_ok.png"
                            OnClick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="3" />
                        &nbsp;
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/document_out.png"
                            CausesValidation="False" OnClick="btnCancel_Click" ToolTip="Salir sin guardar"
                            TabIndex="4" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
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
