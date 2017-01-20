<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionGrid.aspx.cs" Inherits="RevisionGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Revisiones
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
            
                    function newRevision(){
                        //alert("newInstalacion");
                        var url = "RevisionNoPeriodica.aspx?Caller=DispositivoTab";
                        var name = "RevisionNoPeriodica";
                        openOutSide(url, name);
                    }
                    function newRevisionFromDispositivo(dispositivoId) {
                        //alert("newInstalacion");
                        var url = "RevisionNoPeriodica.aspx?Caller=DispositivoTab&DispositivoId=" + dispositivoId;
                        var name = "RevisionNoPeriodica";
                        openOutSide(url, name);
                    }
                    function editRevision(id) {
                        var caller = gup("Caller");
                        var url = "";
                        if (caller == "MainMenu")
                            url = "RevisionForm.aspx?Caller=RevisionGrid&RevisionId=" + id;
                        else
                            url = "RevisionForm.aspx?Caller=" + caller + "&RevisionId=" + id;
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
            <div id="AreaComun">
                <div id="Titulo">
                </div>
                <div id="AreaGrid">
                    <telerik:RadGrid ID="RadGrid1" runat="server"
                                     AllowPaging="True" AllowFilteringByColumn="True" 
                                     AllowSorting="True" ShowGroupPanel="True"
                                     onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                                     onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                                     Skin="Simple" onpageindexchanged="RadGrid1_PageIndexChanged">
                        <GroupingSettings CaseSensitive="False" />
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top"
                                         DataKeyNames="RevisionId">
                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="RevisionId" DataType="System.Int32" 
                                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                                         HeaderText="ID" 
                                                         ReadOnly="True" 
                                                         SortExpression="RevisionId" UniqueName="RevisionId">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Nombre" 
                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Dispositivo" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.Nombre" 
                                                         UniqueName="Dispositivo">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.TipoDispositivo.Nombre" 
                                                         FilterControlToolTip="Filtrar por tipo de dispositivo" FilterImageToolTip="Filtro"
                                                         HeaderText="Tipo dispositivo" 
                                                         ReadOnly="True" 
                                                         SortExpression="Dispositivo.TipoDispositivo.Nombre" 
                                                         UniqueName="Dispositivo.TipoDispositivo.Nombre">
                                </telerik:GridBoundColumn>
                               <%-- <telerik:GridBoundColumn DataField="PlantillaRevision.Descripcion" 
                                                         FilterControlToolTip="Filtrar por plantilla de revision" FilterImageToolTip="Filtro"
                                                         HeaderText="Plantilla de revisión" 
                                                         ReadOnly="True" 
                                                         SortExpression="PlantillaRevision.Descripcion" 
                                                         UniqueName="PlantillaRevision">
                                </telerik:GridBoundColumn>--%>
                             <%--   <telerik:GridBoundColumn DataField="FechaPlanificada" 
                                                         FilterControlToolTip="Filtrar por fecha planificada" FilterImageToolTip="Filtro"
                                                         HeaderText="Fecha planificada" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                                         ReadOnly="True" 
                                                         SortExpression="FechaPlanificada" UniqueName="FechaPlanificada">
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn DataField="FechaProgramada" 
                                                         FilterControlToolTip="Filtrar por fecha programada" FilterImageToolTip="Filtro"
                                                         HeaderText="Fecha programada" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                                         ReadOnly="True" 
                                                         SortExpression="FechaProgramada" UniqueName="FechaProgramada">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaRevision" 
                                                         FilterControlToolTip="Filtrar por fecha de revisión" FilterImageToolTip="Filtro"
                                                         HeaderText="Fecha de revisión" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                                         ReadOnly="True" 
                                                         SortExpression="FechaRevision" UniqueName="FechaRevision">
                                </telerik:GridBoundColumn>
                              <%--  <telerik:GridBoundColumn DataField="Resultado" 
                                                         FilterControlToolTip="Filtrar por resultado" FilterImageToolTip="Filtro"
                                                         HeaderText="Resultado" 
                                                         ReadOnly="True" 
                                                         SortExpression="Resultado" UniqueName="Resultado">
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn DataField="Estado" 
                                                         FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro"
                                                         HeaderText="Estado" ReadOnly="True" SortExpression="Estado" UniqueName="Estado">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CaduProx" 
                                                         FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro" Visible="false"
                                                         HeaderText="CaduProx" ReadOnly="True" SortExpression="CaduProx" UniqueName="CaduProx">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PlantillaRevision.NoPeriodica" Visible="false" 
                                                         FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro"
                                                         HeaderText="NP" ReadOnly="True" SortExpression="PlantillaRevision.NoPeriodica" UniqueName="PlantillaRevision.NoPeriodica">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                                            UniqueName="Template">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Select" runat="server" 
                                                         ImageUrl="~/images/document_gear_16.png"
                                                         ToolTip="Seleccionar este registro y volver con su información" />
                                        <asp:ImageButton ID="Edit" runat="server" 
                                                         ImageUrl="~/images/document_edit_16.png"
                                                         ToolTip="Editar este registro" />
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
                                    <asp:ImageButton ID="New" runat="server" ImageUrl="~/images/document_attachment.png" 
                                                     meta:resourceKey="NewResource1" OnClientClick="newRevision();" 
                                                     ToolTip="Añadir nueva revision no periódica"/>
                                    <asp:ImageButton ID="Generar" runat="server" ImageUrl="~/images/magic-wand.png" 
                                                     meta:resourceKey="ExitResource1"
                                                     ToolTip="Generar revisiones" />
                                    <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                                                     meta:resourceKey="ExitResource1" OnClientClick="closeWindow();" 
                                                     ToolTip="Salir sin cambios" />
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

                    <telerik:RadNotification ID="RadNotification1" runat="server" 
                                             ContentIcon="images/error_32.png" AutoCloseDelay="0" 
                                             TitleIcon="images/error_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                             Height="400px" Position="Center" Title="INFORMACIÓN" Width="400px">
                    </telerik:RadNotification>
                </div>
            </div>
        </form>
    </body>
</html>
