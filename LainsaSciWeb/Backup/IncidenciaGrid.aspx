<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncidenciaGrid.aspx.cs"
    Inherits="LainsaSciWinWeb.IncidenciaGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incidencias</title>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript" src="NewRadConfirm.js"></script>
        <script type="text/javascript">
            function newIncidencia() {
                var url = "IncidenciaForm.aspx?Caller=IncidenciaGrid";
                var name = "IncidenciaForm";
                openOutSide(url, name);
            }
            function newIncidenciaDispositivo(id) {
                var url = "IncidenciaForm.aspx?Caller=DispositivoTab&DispositivoId=" + id;
                var name = "IncidenciaForm";
                openOutSide(url, name);
            }
            function editIncidenciaFromDispositivo(id, dispositivoId) {
                var url = "IncidenciaForm.aspx?Caller=DispositivoTab&IncidenciaId=" + id + "&DispositivoId=" + dispositivoId;
                var name = "IncidenciaForm";
                openOutSide(url, name);
            }
            function newIncidenciaRevision(id) {
                var url = "IncidenciaForm.aspx?Caller=IncidenciaGrid&DispositivoId=" + id;
                var name = "IncidenciaForm";
                openOutSide(url, name);
            }
            function editIncidenciaFromRevision(id, dispositivoId) {
                var url = "IncidenciaForm.aspx?Caller=IncidenciaGrid&IncidenciaId=" + id + "&DispositivoId=" + dispositivoId;
                var name = "IncidenciaForm";
                openOutSide(url, name);
            }
            function editIncidencia(id) {
                var url = "IncidenciaForm.aspx?Caller=IncidenciaGrid" + "&IncidenciaId=" + id;
                var name = "IncidenciaForm";
                openOutSide(url, name);
            }
            function refreshGrid(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
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
        <div id="AreaGrid">
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowFilteringByColumn="True"
                AllowSorting="True" ShowGroupPanel="True" OnItemCommand="RadGrid1_ItemCommand"
                OnItemDataBound="RadGrid1_ItemDataBound" OnNeedDataSource="RadGrid1_NeedDataSource"
                GridLines="None" Skin="Simple" OnPageIndexChanged="RadGrid1_PageIndexChanged">
                <GroupingSettings CaseSensitive="False" />
                <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
                <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" DataKeyNames="IncidenciaId">
                    <CommandItemSettings ExportToPdfText="Export to Pdf" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="IncidenciaId" DataType="System.Int32" FilterControlToolTip="Filtrar por ID"
                            FilterImageToolTip="Filtro" HeaderText="ID" ReadOnly="True" Visible="false" SortExpression="IncidenciaId"
                            UniqueName="IncidenciaId">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Fecha" FilterControlToolTip="Filtrar por fecha"
                            FilterImageToolTip="Filtro" HeaderText="Fecha" ReadOnly="True" SortExpression="Fecha"
                            UniqueName="Fecha" DataType="System.DateTime">
                        </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="Dispositivo.Nombre" FilterControlToolTip="Filtrar por Dispositivo"
                            FilterImageToolTip="Filtro" HeaderText="Dispositivo" ReadOnly="True" Visible="True" SortExpression="Dispositivo.Nombre"
                            UniqueName="Dispositivo.Nombre">
                        </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Usuario.Nombre" FilterControlToolTip="Filtrar por usuario"
                            FilterImageToolTip="Filtro" HeaderText="Usuario" ReadOnly="True" SortExpression="Usuario.UsuarioId"
                            UniqueName="Usuario.UsuarioId">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Comentarios" FilterControlToolTip="Filtrar por Comentarios"
                            FilterImageToolTip="Filtro" HeaderText="Comentarios" ReadOnly="True" SortExpression="Comentarios"
                            UniqueName="Comentarios">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Operativo" FilterControlToolTip="Filtrar por operatividad"
                            FilterImageToolTip="Filtro" HeaderText="Operativo" ReadOnly="True" SortExpression="Operativo"
                            UniqueName="Operativo">
                        </telerik:GridBoundColumn>
                       
                        <telerik:GridTemplateColumn AllowFiltering="False" FilterControlAltText="Filter Template column"
                            HeaderText="Acciones" UniqueName="Template">
                            <ItemTemplate>
                                <asp:ImageButton ID="Select" runat="server" ImageUrl="~/images/document_gear_16.png"
                                    ToolTip="Seleccionar este registro y volver con su información" />
                                <asp:ImageButton ID="Edit" runat="server" ImageUrl="~/images/document_edit_16.png"
                                    ToolTip="Editar este registro" />
                                <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/images/document_delete_16.png"
                                    ToolTip="Eliminar este registro" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                    <CommandItemTemplate>
                        <div id="ButtonAdd" style="padding: 2px;">
                            <asp:ImageButton ID="New" runat="server" ImageUrl="~/images/document_add.png" meta:resourceKey="NewResource1"
                                OnClientClick="newDispositivo();" ToolTip="Añadir un nuevo registro" />
                            <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" meta:resourceKey="ExitResource1"
                                OnClientClick="closeWindow();" ToolTip="Salir" />
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
            <telerik:RadNotification ID="RadNotification1" runat="server" ContentIcon="images/error_32.png"
                AutoCloseDelay="0" TitleIcon="images/error_16.png" EnableRoundedCorners="True"
                EnableShadow="True" Height="400px" Position="Center" Title="ERROR" Width="400px">
            </telerik:RadNotification>
        </div>
    </div>
    </form>
</body>
</html>
