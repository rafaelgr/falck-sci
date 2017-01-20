<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramarGrid.aspx.cs" Inherits="LainsaSciWinWeb.PrograrGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Programar revisiones
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
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript" src="GridForm.js"></script>
                <script type="text/javascript" src="NewRadConfirm.js"></script>
                <script type="text/javascript">
                    function editRevision(id){
                        var url = "RevisionForm.aspx?Caller=ProgramarGrid&RevisionId=" + id;
                        var name = "RevisionForm";
                        openOutSide(url, name);
                    }
                    function editRevisionFromDispositivo(id, dispositivoId){
                        var url = "RevisionForm.aspx?Caller=DispositivoTab&RevisionId=" + id + "&DispositivoId=" + dispositivoId;
                        var name = "RevisionForm";
                        openOutSide(url, name);
                    }
                    function refreshGrid(arg){
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                    }
                </script>

            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
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
            <div id="MainArea" class="normalText">
                <div id="Titulo">
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblDesde" runat="server" Text="Fecha planificada desde:"></asp:Label>
                            </td>
                            <td>
                                <telerik:raddatepicker id="dateDesde" runat="server" AutoPostBack="True" 
                                                       Culture="es-ES" 
                                                       onselecteddatechanged="dateDesde_SelectedDateChanged">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                                              ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" autopostback="True"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:raddatepicker>
                            </td>
                            <td>
                                <asp:Label ID="lblHasta" runat="server" Text="hasta:"></asp:Label>
                            </td>
                            <td>
                                <telerik:raddatepicker id="dateHasta" runat="server" AutoPostBack="True" 
                                                       Culture="es-ES" 
                                                       onselecteddatechanged="dateHasta_SelectedDateChanged">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                                              ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" autopostback="True"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:raddatepicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="AreaGrid">
                    <telerik:RadGrid ID="RadGrid1" runat="server"
                                     AllowPaging="True" AllowFilteringByColumn="True" 
                                     AllowSorting="True" ShowGroupPanel="True" AllowMultiRowSelection="true"
                                     onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" OnPreRender="RadGrid1_PreRender"
                                     onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                                     Skin="Simple" onpageindexchanged="RadGrid1_PageIndexChanged">
                        <GroupingSettings casesensitive="False" />
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <MasterTableView ClientDataKeyNames="RevisionId" AutoGenerateColumns="False" CommandItemDisplay="TopAndBottom"
                                         DataKeyNames="RevisionId" >
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <SortExpressions>
                                <telerik:GridSortExpression FieldName="FechaProgramada" SortOrder="Ascending" />
                            </SortExpressions>
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" AllowFiltering="False">
                                    <HeaderTemplate>
                                        <asp:CheckBox id="headerChkbox" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True" runat="server"></asp:CheckBox>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox id="CheckBox1" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="RevisionId" DataType="System.Int32"  
                                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                                         HeaderText="ID" 
                                                         ReadOnly="True" Visible="false" 
                                                         SortExpression="RevisionId" UniqueName="RevisionId">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Empresa.Nombre" 
                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Empresa" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.Instalacion.Empresa.Nombre" 
                                                         UniqueName="Empresa">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Nombre" 
                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Instalación" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.Instalacion.Nombre" 
                                                         UniqueName="Instalacion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Nombre" 
                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Dispositivo" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.Nombre" 
                                                         UniqueName="Dispositivo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.TipoDispositivo.Nombre" 
                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Tipo dispositivo" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.TipoDispositivo.Nombre" 
                                                         UniqueName="Dispositivo.TipoDispositivo.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.ModeloDispositivo.Nombre" 
                                                         FilterControlToolTip="Filtrar por modelo" FilterImageToolTip="Filtro"
                                                         HeaderText="Modelo" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.ModeloDispositivo.Nombre" 
                                                         UniqueName="Dispositivo.ModeloDispositivo.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Posicion" 
                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Ubicacion" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.Posicion" 
                                                         UniqueName="Dispositivo.Posicion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlantillaRevision.Descripcion" 
                                                         FilterControlToolTip="Filtrar por plantilla de revision" FilterImageToolTip="Filtro"
                                                         HeaderText="Plantilla de revisión" 
                                                         ReadOnly="True" 
                                                         SortExpression="PlantillaRevision.Descripcion" 
                                                         UniqueName="PlantillaRevision">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaPlanificada" 
                                                         FilterControlToolTip="Filtrar por fecha programada" FilterImageToolTip="Filtro"
                                                         HeaderText="Fecha planificada" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                                         ReadOnly="True" 
                                                         SortExpression="FechaPlanificada" UniqueName="FechaPlanificada">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                                            UniqueName="Template">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Select" runat="server" Visible="false"
                                                         ImageUrl="~/images/document_gear_16.png"
                                                         ToolTip="Seleccionar este registro y volver con su información" />
                                        <asp:ImageButton ID="Edit" runat="server" Visible="true" 
                                                         ImageUrl="~/images/document_edit_16.png"
                                                         ToolTip="Editar este registro" />
                                        <asp:ImageButton ID="Delete" runat="server" Visible="false" 
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
                                <div id="ButtonAdd" style="padding:2px;">
                                    <asp:ImageButton ID="New" runat="server" ImageUrl="~/images/document_add.png" 
                                                     meta:resourceKey="NewResource1" OnClientClick="newRevision();" 
                                                     ToolTip="Añadir un nuevo registro" Visible="false" />
                                    <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                                                     meta:resourceKey="ExitResource1" OnClientClick="closeWindow();" 
                                                     ToolTip="Salir sin cambios" Visible="false" />
                                    <asp:ImageButton ID="Program" runat="server" ImageUrl="~/images/preferences.png" 
                                                     meta:resourceKey="ExitResource1" 
                                                     ToolTip="Programar seleccionadas"/>
                                </div>
                            </CommandItemTemplate>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
                <div id="AreaPie">
                    <telerik:RadNotification ID="RadNotification1" runat="server" Text="No debe mezclar instalaciones" 
                                             ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                                             TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                             Height="100px" Position="Center" Title="WARNING" Width="300px">
                    </telerik:RadNotification>
                </div>
            </div>
        </form>
    </body>
</html>
