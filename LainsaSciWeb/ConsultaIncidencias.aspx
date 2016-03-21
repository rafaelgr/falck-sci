<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaIncidencias.aspx.cs" Inherits="ComsultaIncidencias" EnableEventValidation="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Consultas incidencias
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .style1
            {
            width: 586px;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">

            <telerik:RadScriptManager ID="RadScriptManager1" runat="server" >

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
                    //         
                    //                function onRequestStart(sender, args) {
                    //                    if (args.get_eventTarget().indexOf("Button1") >= 0) {
                    //                        args.set_enableAjax(false);
                    //                    }
                    //                }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" >
            </telerik:RadAjaxLoadingPanel>

            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" >
            </telerik:RadSkinManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
                <div id ="Filtros">
                    <table width="100%">
                        <tr>
                            <td class="style1">
                                <telerik:RadFilter runat="server" ID="RadFilter1" FilterContainerID="RadGrid1"   OnApplyExpressions="RadFilter1_ApplyExpressions">
                                </telerik:RadFilter>
                            </td>
                            <td style="vertical-align:top; width:350px">
                                <div id="Guardados1" class="normalText" style="padding:2px">
                                    <asp:Label ID="lblFiltro" runat="server" Text="Consultas guardadas:"></asp:Label>
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcFiltro" Height="100px" 
                                                         Width="300px" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         TabIndex="1" AutoPostBack="True" 
                                                         onselectedindexchanged="rdcFiltro_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </div>
                                <div id="Guraddaos2" class="normalText" style="padding:2px">
                                    <telerik:RadTextBox ID="txtFiltro" runat="server" Width="180px">
                                    </telerik:RadTextBox>
                                    &nbsp;
                                    <telerik:RadButton ID="btnAgregar" runat="server" Text="Agregar" 
                                                       onclick="btnAgregar_Click">
                                    </telerik:RadButton>
                                    &nbsp;
                                    <telerik:RadButton ID="btnEliminar" runat="server" Text="Eliminar" 
                                                       onclick="btnEliminar_Click">
                                    </telerik:RadButton>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <div id="Botons">
                                    <telerik:RadButton ID="btnInforme" runat="server" Text="Informe general" Visible="false" 
                                                       onclick="btnInforme_Click">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButton1" runat="server" onclick="RadButton1_Click" 
                                                       Text="Informe detallado" Visible="False">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="pnlBtnExcel" Text="Exportar Excel" OnClick="btnExcel_Click"
                                                       runat="server">
                                    </telerik:RadButton>
                                </div>
                            </td>
                            <td></td>
                            <td>
                            </td>
                        </tr>
                    </table>

                </div>
                <div id="AreaGrid">
                    <telerik:RadGrid ID="RadGrid1" runat="server" EnableLinqExpressions="false"
                                     AllowPaging="True" AllowFilteringByColumn="false" 
                                     AllowSorting="True" ShowGroupPanel="false"
                                     onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                                     onneeddatasource="RadGrid1_NeedDataSource" GridLines="None">
                        <GroupingSettings CaseSensitive="False" />
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="None"
                                         DataKeyNames="IncidenciaId">
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IncidenciaId" DataType="System.Int32" FilterControlToolTip="Filtrar por ID"
                                                         FilterImageToolTip="Filtro" HeaderText="ID" ReadOnly="True" Visible="false" SortExpression="IncidenciaId"
                                                         UniqueName="IncidenciaId">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="Dispositivo.CodBarras" 
                                         FilterControlToolTip="Filtrar por código de barras" FilterImageToolTip="Filtro"
                                         HeaderText="Cod. Barras" 
                                         ReadOnly="True" 
                                         SortExpression="CodBarras" UniqueName="CodBarras">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Nombre" FilterControlToolTip="Filtrar por Dispositivo"
                                                         FilterImageToolTip="Filtro" HeaderText="Dispositivo" ReadOnly="True" Visible="True" SortExpression="Dispositivo.Nombre"
                                                         UniqueName="Dispositivo.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Nombre" FilterControlToolTip="Filtrar por Dispositivo"
                                                         FilterImageToolTip="Filtro" HeaderText="Instalación" ReadOnly="True" Visible="True" SortExpression="Dispositivo.Instalacion.Nombre"
                                                         UniqueName="Dispositivo.Instalacion.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Dispositivo.Posicion" FilterControlToolTip="Filtrar por ubicación"
                                                         FilterImageToolTip="Filtro" HeaderText="Ubicación" ReadOnly="True" Visible="True" SortExpression="Dispositivo.Posicion"
                                                         UniqueName="Dispositivo.Posicion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Estado.Nombre" FilterControlToolTip="Filtrar por Estado"
                                                         FilterImageToolTip="Filtro" HeaderText="Estado" ReadOnly="True" Visible="True" SortExpression="Estado.Nombre"
                                                         UniqueName="Estado.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaApertura" FilterControlToolTip="Filtrar por fecha" DataFormatString="{0:dd/MM/yyyy}"
                                                         FilterImageToolTip="Filtro" HeaderText="Fecha apertura" ReadOnly="True" SortExpression="FechaApertura"
                                                         UniqueName="FechaApertura" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaPrevista" FilterControlToolTip="Filtrar por fecha" DataFormatString="{0:dd/MM/yyyy}"
                                                         FilterImageToolTip="Filtro" HeaderText="Fecha prevista" ReadOnly="True" SortExpression="FechaPrevista"
                                                         UniqueName="FechaPrevista" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FechaCierre" FilterControlToolTip="Filtrar por fecha" DataFormatString="{0:dd/MM/yyyy}"
                                                         FilterImageToolTip="Filtro" HeaderText="Fecha cierre" ReadOnly="True" SortExpression="FechaCierre"
                                                         UniqueName="FechaCierre" DataType="System.DateTime">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Prioridad.Nombre" FilterControlToolTip="Filtrar por prioridad"
                                                         FilterImageToolTip="Filtro" HeaderText="Prioridad" ReadOnly="True" SortExpression="Prioridad.Nombre"
                                                         UniqueName="Prioridad.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Responsable.Nombre" FilterControlToolTip="Filtrar por responsable"
                                                         FilterImageToolTip="Filtro" HeaderText="Responsable" ReadOnly="True" SortExpression="Responsable.Nombre"
                                                         UniqueName="Responsable.Nombre">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Comentarios" FilterControlToolTip="Filtrar por comentarios"
                                                         FilterImageToolTip="Filtro" HeaderText="Comentarios" ReadOnly="True" SortExpression="Comentarios"
                                                         UniqueName="Comentarios">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Operativo" FilterControlToolTip="Filtrar por operatividad"
                                                         FilterImageToolTip="Filtro" HeaderText="Operativo" ReadOnly="True" SortExpression="Operativo"
                                                         UniqueName="Operativo">
                                </telerik:GridBoundColumn>

                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                                            UniqueName="Template">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="Edit" runat="server" 
                                                         ImageUrl="~/images/document_edit_16.png"
                                                         ToolTip="Ver este registro" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
                <div id="Zona aviso">
                    <telerik:RadNotification ID="RadNotification1" runat="server" Text="El filtro ha sido agregado, lo puede ver en el desplegable" 
                                             ContentIcon="images/information_32.png" AutoCloseDelay="0" 
                                             TitleIcon="images/information_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                             Height="400px" Position="Center" Title="ERROR" Width="400px">
                    </telerik:RadNotification>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
