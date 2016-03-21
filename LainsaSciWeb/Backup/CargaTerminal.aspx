<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargaTerminal.aspx.cs" Inherits="LainsaSciWinWeb.CargaTerminal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head2" runat="server">
        <title>
            Carga de terminales
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager2" runat="server" />
        <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <form id="form2" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
                <Scripts>
                    <%--Needed for JavaScript IntelliSense in VS2010--%>
                    <%--For VS2008 replace RadScriptManager with ScriptManager--%>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>
            <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                <script type="text/javascript" src="GridForm.js"></script>
                <script type="text/javascript" src="NewRadConfirm.js"></script>
                    <script type="text/javascript">
                        function newModeloTerminal() {
                            //alert("newUsuario");
                            var url = "CargaTerminalForm.aspx?Caller=CargaTerminal";
                            var name = "CargaTerminalForm";
                            openOutSide(url, name);
                        }
                        function editModeloTerminal(url) {
                            var url = "/BDII/" + url;
                            window.open(url);
                        }
                        function refreshGrid(arg) {
                            $find("<%= RadAjaxManager2.ClientID %>").ajaxRequest(arg);
                        }
                </script>

            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
            </telerik:RadSkinManager>
            <div id="AreaComun">
                <div id="Div1">
                </div>
                <div id="AreaGrid">
                    <telerik:RadGrid ID="RadGrid1" runat="server"
                                     AllowPaging="True" AllowFilteringByColumn="True" 
                                     AllowSorting="True" ShowGroupPanel="True"
                                     onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                                     onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                                     Skin="Simple" onpageindexchanged="RadGrid1_PageIndexChanged" 
                                     CellSpacing="0" Culture="es-ES">
                        <GroupingSettings CaseSensitive="False" />
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                                         DataKeyNames="Id">
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Id" 
                                                         FilterControlToolTip="Filtrar por Id" FilterImageToolTip="Filtro"
                                                         HeaderText="ID" 
                                                         ReadOnly="True" 
                                                         SortExpression="Id" UniqueName="Id" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Empresa.Nombre" 
                                                         FilterControlToolTip="Filtrar por Empresa" FilterImageToolTip="Filtro"
                                                         HeaderText="Empresa" 
                                                         ReadOnly="True" 
                                                         SortExpression="Empresa.Nombre" UniqueName="Empresa.Nombre" 
                                    FilterControlAltText="Filter Empresa column">
                                </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="Fecha" 
                                                         FilterControlToolTip="Filtrar por Fecha" FilterImageToolTip="Filtro"
                                                         HeaderText="Fecha de exportación" 
                                                         ReadOnly="True" 
                                                         SortExpression="Fecha" UniqueName="Fecha" 
                                    FilterControlAltText="Filter Fecha column" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Archivo" 
                                                         FilterControlToolTip="Filtrar por Archivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Archivo" 
                                                         ReadOnly="True" 
                                                         SortExpression="Archivo" UniqueName="Archivo" 
                                    FilterControlAltText="Filter Archivo column">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                                            UniqueName="Template">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Select" runat="server" 
                                                         ImageUrl="~/images/document_gear_16.png"
                                                         ToolTip="Seleccionar este registro y volver con su información" />
                                        <asp:ImageButton ID="Edit" runat="server" 
                                                         ImageUrl="~/images/sort_descending.png"
                                                         ToolTip="Descargar este registro" />
                                        <asp:ImageButton ID="Delete" runat="server" 
                                                         ImageUrl="~/images/document_delete_16.png"
                                                         ToolTip="Eliminar este registro" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <CommandItemTemplate>
                                <div ID="ButtonAdd" style="padding:2px;">
                                   <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                                                     meta:resourceKey="ExitResource1" OnClientClick="closeWindow();" 
                                                     ToolTip="Salir sin cambios" />
                                </div>
                            </CommandItemTemplate>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                            <WebServiceSettings>
                                <ODataSettings InitialContainerName=""></ODataSettings>
                            </WebServiceSettings>
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
                            <WebServiceSettings>
                                <ODataSettings InitialContainerName=""></ODataSettings>
                            </WebServiceSettings>
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
              <%--  <div id="Botons">
                    <telerik:RadButton ID="btnInforme" runat="server" Text="Informe" 
                                       onclick="btnInforme_Click">
                    </telerik:RadButton>
                </div>--%>
                <div id="AreaPie">
                    <telerik:RadNotification ID="RadNotification1" runat="server" 
                                             ContentIcon="images/error_32.png" AutoCloseDelay="0" 
                                             TitleIcon="images/error_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                             Height="400px" Position="Center" Title="ERROR" Width="400px">
                    </telerik:RadNotification>
                </div>
            </div>
        </form>
    </body>
</html>

