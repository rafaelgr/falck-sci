<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerarRevisionesExe.aspx.cs" Inherits="GenerarRevisionesExe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Generar reviones de una instalación
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
                    function noHaceNada() {
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
                            <telerik:AjaxUpdatedControl ControlID="rdcInforme" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" Width="100%">
                <div id="MainArea" class="normalText">
                    <%--Zona de título--%>
                    <div id="Titulo" class="tituloWindow">
                        <asp:Label ID="lblTítulo" runat="server" Text="Generar revisiones de los dispositivos de una instalación"></asp:Label>
                    </div>
                    <%--Zona de campos--%>
                    <div ID="Instalación" class="normalText conMargen" style="float:left">
                        <asp:Label ID="lblInstalación" runat="server" Text="Instalación:" 
                                   ToolTip="Instalación al que pertenece el dispositivo"></asp:Label>
<%--                        &nbsp;
                        <asp:ImageButton ID="imgbInstalacion" runat="server" 
                                         CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                         OnClientClick="searchInstalacion('GenerarRevisionesExe');" 
                                         ToolTip="Haga clic aquí para buscar Instalaciones" />--%>
                        <br />
                        <telerik:RadComboBox runat="server" ID="rdcInstalacion" Height="100px" 
                                             Width="300px" ItemsPerRequest="10" 
                                             EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                             TabIndex="1" AutoPostBack="True">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="valInstalacion" runat="server" Display="Dynamic" 
                                                    ControlToValidate="rdcInstalacion" CssClass="normalTextRed"
                                                    ErrorMessage="Se necesita una instalación">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div id="Salir" class="conMargen" style="float:right">
                        <telerik:RadButton ID="btnSalir" runat="server" Text="Salir" CausesValidation="false" 
                                           onclick="btnSalir_Click">
                        </telerik:RadButton>
                    </div> 
                    <div id="Lanzador" class="conMargen" style="float:right">
                        <telerik:RadButton ID="btnLanzador" runat="server" Text="Generar revisiones" 
                                           onclick="btnLanzador_Click">
                        </telerik:RadButton>
                    </div>

                    <div id="Dummy2" style="clear:both; height:1px"></div>
                    <div id="Progreso">
                        <telerik:RadProgressManager ID="RadProgressManager1" Runat="server" />
                        <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Width="100%">
                            <Localization Uploaded="Procesado" Cancel="Cancelar" ElapsedTime="Tiempo transcurrido: " 
                                          EstimatedTime="Tiempo estimado: "></Localization>
                        </telerik:RadProgressArea>
                    </div>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
