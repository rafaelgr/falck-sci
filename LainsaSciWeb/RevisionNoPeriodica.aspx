<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionNoPeriodica.aspx.cs" Inherits="RevisionNoPeriodica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Planificar revisión no periodica
        </title>
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
                    //Put your JavaScript code here.
                </script>
                <script type="text/javascript">
                    function noHaceNada() { }

                    function loadValues(values) {
                        var combo = $find("<%=rdcDispositivo.ClientID %>");
                        loadCombo(combo, values);
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(values[0]);
                        
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

                    function refreshGrid2(arg, frame) {
                        // search for the iframe
                        var iframe = document.getElementById(frame);
                        iframe.contentWindow.refreshGrid(arg);
                    }            
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server"></telerik:RadSkinManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="rdcPlantilla" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" Width="100%">
                <div id="MainArea" class="normalText">
                    <%--Zona de título--%>
                    <div id="Titulo" class="tituloWindow">
                        <asp:Label ID="lblTítulo" runat="server" Text="Revisión no periódica"></asp:Label>
                    </div>
                    <%--Zona de campos--%>
                    <div id="ID" class="conMargen" style="float:left; ">
                        <asp:Label ID="lblId" runat="server" Text="ID:"></asp:Label>
                        <br />
                        <telerik:RadNumericTextBox ID="txtId" runat="server" CausesValidation="false" Enabled="false" Width="148px" TabIndex="1">
                        </telerik:RadNumericTextBox>
                    </div>
                    <div id="Dispositivo" class="conMargen" style="float:left; ">
                        <asp:Label ID="lblDispositivo" runat="server" Text="Dispositivo:"></asp:Label>
                        &nbsp;
                        <asp:ImageButton ID="imgDispositivo" runat="server" 
                                         CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                         OnClientClick="searchDispositivo('RevisionNoPeriodica');" 
                                         ToolTip="Haga clic aquí para buscar" />
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcDispositivo" Height="100px" Width="200px" ItemsPerRequest="10" CausesValidation="false" 
                                             EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                             EmptyMessage="Escriba aquí ..." TabIndex="2" AutoPostBack="True" 
                                             onitemsrequested="rdcDispositivo_ItemsRequested" 
                                             onselectedindexchanged="rdcDispositivo_SelectedIndexChanged">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="valDispositivo" runat="server" Display="Dynamic" 
                                                    ControlToValidate="rdcDispositivo" CssClass="normalTextRed"
                                                    ErrorMessage="Se necesita un valor">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div id="Plantilla" class="conMargen" style="float:left; ">
                        <asp:Label ID="lblPlantilla" runat="server" Text="Plantilla"></asp:Label>
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcPlantilla" Height="100px" Width="200px" ItemsPerRequest="10"  CausesValidation="false"
                                             EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                             EmptyMessage="" TabIndex="3" AutoPostBack="True">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                                    ControlToValidate="rdcPlantilla" CssClass="normalTextRed"
                                                    ErrorMessage="Se necesita un valor">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div id="Dummy1" style="clear:both; height:1px"></div>
                    <div id="FechaPlanificada" class="conMargen" style="float:left; "> 
                        <asp:Label ID="lblFecha" runat="server" CssClass="normalText" Text="Fecha planificada:"></asp:Label>
                        <br />
                        <telerik:RadDatePicker ID="rdtFecha" runat="server" TabIndex="4"></telerik:RadDatePicker>
                        <br />
                        <asp:RequiredFieldValidator ID="valFecha" runat="server" Display="Dynamic" 
                                                    ControlToValidate="rdtFecha" CssClass="normalTextRed"
                                                    ErrorMessage="Se necesita una fecha">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div id="Operario" class="conMargen" style="float:left; ">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcUsuario" Height="100px" Width="200px" ItemsPerRequest="10"  CausesValidation="false"
                                             EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                             EmptyMessage="" TabIndex="5" AutoPostBack="True">
                        </telerik:RadComboBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" 
                                                    ControlToValidate="rdcUsuario" CssClass="normalTextRed"
                                                    ErrorMessage="Se necesita un valor">
                        </asp:RequiredFieldValidator>

                    </div>
                    <div id="Dummy2" style="clear:both; height:1px"></div>
                </div>

                <%--Zona de botones--%>
                <div id="BtnSalir" class="conMargen" style="float:right">
                    <asp:ImageButton ID="btnCancel" runat="server"
                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                     TabIndex="7" />
                </div>
                <div id="BtnAceptar" class="conMargen" style="float:right">
                    <asp:ImageButton ID="btnAccept" runat="server" TabIndex="8"
                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                     ToolTip="Guardar y salir"/>
                </div>

            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
