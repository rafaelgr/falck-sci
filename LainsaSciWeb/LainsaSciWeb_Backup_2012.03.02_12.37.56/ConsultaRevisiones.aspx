<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaRevisiones.aspx.cs" Inherits="ConsultaRevisiones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Consultas revisiones
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
      <script type="text/javascript" src="GridForm.js">
        //Put your JavaScript code here.
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Simple">
    </telerik:RadAjaxLoadingPanel>
    
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Simple">
      </telerik:RadSkinManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
      <div id ="Filtros">
        <table width="100%">
          <tr>
            <td>
              <telerik:RadFilter runat="server" ID="RadFilter1" FilterContainerID="RadGrid1">
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
        </table>

      </div>
      <div id="AreaGrid">
        <telerik:RadGrid ID="RadGrid1" runat="server"
                         AllowPaging="True" AllowFilteringByColumn="false" 
                         AllowSorting="True" ShowGroupPanel="false"
                         onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                         onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                         Skin="Simple" >
          <GroupingSettings CaseSensitive="False" />
          <ClientSettings AllowDragToGroup="True">
          </ClientSettings>
          <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top"
                           DataKeyNames="RevisionId">
            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="true" ShowExportToExcelButton="true"/>
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
              <telerik:GridBoundColumn DataField="PlantillaRevision.Descripcion" 
                                       FilterControlToolTip="Filtrar por plantilla de revision" FilterImageToolTip="Filtro"
                                       HeaderText="Plantilla de revisión" 
                                       ReadOnly="True" 
                                       SortExpression="PlantillaRevision.Descripcion" 
                                       UniqueName="PlantillaRevision">
              </telerik:GridBoundColumn>
              <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Empresa.Nombre" 
                                       FilterControlToolTip="Filtrar por plantilla de revision" FilterImageToolTip="Filtro"
                                       HeaderText="Empresa" 
                                       ReadOnly="True" 
                                       SortExpression="Dispositivo.Instalacion.Empresa.Nombre" 
                                       UniqueName="Dispositivo.Instalacion.Empresa.Nombre">
              </telerik:GridBoundColumn>
              <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Nombre" 
                                       FilterControlToolTip="Filtrar por plantilla de revision" FilterImageToolTip="Filtro"
                                       HeaderText="Instalacion" 
                                       ReadOnly="True" 
                                       SortExpression="Dispositivo.Instalacion.Nombre" 
                                       UniqueName="Dispositivo.Instalacion.Nombre">
              </telerik:GridBoundColumn>
              <telerik:GridBoundColumn DataField="FechaPlanificada" 
                                       FilterControlToolTip="Filtrar por fecha planificada" FilterImageToolTip="Filtro"
                                       HeaderText="Fecha planificada" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                       ReadOnly="True" 
                                       SortExpression="FechaPlanificada" UniqueName="FechaPlanificada">
              </telerik:GridBoundColumn>
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
              <telerik:GridBoundColumn DataField="Resultado" 
                                       FilterControlToolTip="Filtrar por resultado" FilterImageToolTip="Filtro"
                                       HeaderText="Resultado" 
                                       ReadOnly="True" 
                                       SortExpression="Resultado" UniqueName="Resultado">
              </telerik:GridBoundColumn>
              <telerik:GridBoundColumn DataField="Estado" 
                                       FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro"
                                       HeaderText="Estado" ReadOnly="True" SortExpression="Estado" UniqueName="Estado">
              </telerik:GridBoundColumn>
              <telerik:GridBoundColumn DataField="CaduProx" 
                                       FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro" Visible="false"
                                       HeaderText="Caducidad proxima" ReadOnly="True" SortExpression="CaduProx" UniqueName="CaduProx">
              </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn AllowFiltering="False" 
                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                            UniqueName="Template">
                  <ItemTemplate>
                    <asp:ImageButton ID="Edit" runat="server" 
                                     ImageUrl="~/images/document_edit_16.png"
                                     ToolTip="Editar este registro" />
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
