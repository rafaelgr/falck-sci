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
                        if (values[2] == "Estado") {
                            combo = $find("<%=rdcEstado.ClientID %>");
                        }
                        if (values[2] == "Prioridad") {
                            combo = $find("<%=rdcPrioridad.ClientID %>");
                        }
                        if (values[2] == "Responsable") {
                            combo = $find("<%=rdcResponsable.ClientID %>");
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

                        addMulti();

                    }
                    function refreshGrid2(arg, frame) {
                        // search for the iframe (is allways the same)
                        var iframe = document.getElementById("ifTabIncidencia");
                        iframe.contentWindow.refreshGrid2(arg, frame);
                    }
                    function refreshGrid(arg) {
                        var iframe = document.getElementById("ifTabIncidencia");
                        iframe.contentWindow.refreshGrid(arg);
                    }
                    function askRevision(arg) {
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                    }

                    function delMulti() {
                        comboMulti = $find("<%=rdcDispositivoMulti.ClientID %>");
                        comboMulti.trackChanges();
                        comboMulti.deleteItem(comboMulti.get_selectedItem());
                        comboItem.select();
                        comboMulti.commitChanges();
                        
                    }

                    function addMulti() {
                        combo = $find("<%=rdcDispositivo.ClientID %>");
                        comboMulti = $find("<%=rdcDispositivoMulti.ClientID %>");

                        if (combo.get_value()!="") {
                            var comboItem = new Telerik.Web.UI.RadListBoxItem();
                            comboItem.set_text(combo.get_text());
                            comboItem.set_value(combo.get_value());
                            comboMulti.trackChanges();
                            comboMulti.get_items().add(comboItem);
                            comboItem.select();
                            comboMulti.commitChanges();


                            combo.trackChanges();
                            combo.get_items().clear();
                            combo.set_text("");
                            combo.set_value("");
                            combo.commitChanges();


                        }



                        /*
                        items.clear();
                        var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                        comboItem.set_text(values[1]);
                        comboItem.set_value(values[0]);
                        items.add(comboItem);
                        combo.commitChanges();
                        comboItem.select();
                        */

                    }

                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"  OnAjaxRequest="RadAjaxManager1_AjaxRequest">
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
            </telerik:RadSkinManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
            <div id="MainArea" class="normalText">
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div id="FechaApertura" class="normalText" style="padding: 5px;">
                                <asp:Label ID="lblFechaApertura" runat="server" Text="Fecha apertura: "></asp:Label>
                                <br />
                                <telerik:RadTextBox ID="txtFechaApertura" runat="server" Enabled="false" Width="200px" TabIndex="1">
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td>
                            <div id="FechaPrevista" class="normalText" style="padding: 5px;">
                                <asp:Label ID="lblFechaPrevista" runat="server" Text="Fecha prevista de cierre: "></asp:Label>
                                <br />
                                <telerik:RadDatePicker ID="rdpFechaPrevista" runat="server" TabIndex="2">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="2">
<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                                    </DateInput>
                                    <DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl="" TabIndex="2">
                                    </DatePopupButton>
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                        <td>
                            <div id="FechaCierre" class="normalText" style="padding: 5px;">
                                <asp:Label ID="lblFechaCierre" runat="server" Text="Fecha cierre: "></asp:Label>
                                <br />
                                <telerik:RadTextBox ID="txtFechaCierre" runat="server" Enabled="false" Width="200px" TabIndex="3">
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td>
                            <div id="Operativo" class="normalText" style="padding: 5px;">
                                <asp:CheckBox ID="chkOperativo" runat="server" Text="Dispositivo inoperativo" Checked="False" TabIndex="4" />
                            </div>
                            <div id="SiguePlan" class="normalText" style="padding: 5px;">
                                <asp:CheckBox ID="chkSiguePlan" runat="server" Text="No sigue planificaciones" Checked="False" TabIndex="4" />
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="Dispositivo" class="normalText" style="padding: 5px;">
                                <asp:Label ID="lblDispositivo" runat="server" Text="Dispositivo:" ToolTip="Dispositivo al que afecta la incidencia"></asp:Label>
                                &nbsp;
                                <asp:ImageButton ID="imgDispositivo" runat="server" CausesValidation="false" ImageUrl="~/images/search_mini.png"
                                                 OnClientClick="searchDispositivo('IncidenciaForm');" ToolTip="Haga clic aquí para buscar dispositivos" />
                                <br />
                                <telerik:RadComboBox runat="server" ID="rdcDispositivo" Height="18px" Width="99%"
                                                     ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </div>
                        </td>
                    </tr>
                    <tr id="multi" runat="server">
                        <td colspan="4">
                            <div id="Div1" class="normalText" style="padding: 5px;">
                                <asp:Label ID="lblDispositivoMult" runat="server" Text="Alta múltimple:" ToolTip="Dispositivos a los que afecta la incidencia"></asp:Label>
                                &nbsp;
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" ImageUrl="~/images/document_delete_16.png"
                                                 OnClientClick="delMulti();" ToolTip="Haga clic aquí para eliminar dispositivos" />
                                <br />
                                <telerik:RadListBox runat="server" ID="rdcDispositivoMulti" Height="150px" Width="99%"
                                                     EmptyMessage="" TabIndex="5" AutoPostBack="True">
                                </telerik:RadListBox>
                            </div>
                        </td>
                    </tr>



                    <tr>
                        <td>
                            <div id="Usuario" class="normalText" style="padding: 5px;">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
                                <br />
                                <telerik:RadTextBox ID="txtUsuario" runat="server" Enabled="false" Width="200px"
                                                    TabIndex="6">
                                </telerik:RadTextBox>
                            </div>
                        </td>
                        <td>
                            <div id="Estado" class="normalText" style="padding:5px;">
                                <asp:Label ID="lblEstado" runat="server" Text="Estado:" ToolTip="Estado en el que se encuentra la incidencia"></asp:Label>
                                &nbsp;
                                <br />
                                <telerik:RadComboBox runat="server" ID="rdcEstado" Height="100px" Width="99%"
                                                     ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                     TabIndex="7" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </div>
                        </td>
                        <td>
                            <div id="Prioridad" class="normalText" style="padding:5px;">
                                <asp:Label ID="lblPrioridad" runat="server" Text="Prioridad:" ToolTip="Prioridad de la incidencia"></asp:Label>
                                &nbsp;
                                <br />
                                <telerik:RadComboBox runat="server" ID="rdcPrioridad" Height="100px" Width="99%"
                                                     ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                     TabIndex="8" AutoPostBack="True">
                                </telerik:RadComboBox>
                            </div>
                        </td>
                        <td>
                            <div id="Responsable" class="normalText" style="padding:5px;">
                                <asp:Label ID="lblResponsable" runat="server" Text="Responsable:" ToolTip="Responsable de la incidencia"></asp:Label>
                                &nbsp;
                                <br />
                                <telerik:RadComboBox runat="server" ID="rdcResponsable" Height="100px" Width="99%"
                                                     ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                     TabIndex="9" AutoPostBack="True" >
                                </telerik:RadComboBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
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
                    <tr id="tr_evoluciones" runat="server">
                        <td colspan="4">
                            <asp:Label ID="lblEvoluciones" runat="server" Text="EVOLUCIONES"></asp:Label>
                            <br />
                            <iframe id="ifTabIncidencia" runat="server" frameborder="0" width="100%" height="300px"></iframe>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
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
