<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentoGrid.aspx.cs" Inherits="DocumentoGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Empresas
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciExtranetEstilos.css" rel="stylesheet" type="text/css" />
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
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Windows7">
      </telerik:RadSkinManager>
      <div id="AreaComun">
        <div id="Titulo" class="txtTitulo">
            <asp:Label ID="lblTitulo" runat="server" Text="Documentoes"></asp:Label>
        </div>
        <div>&nbsp;&nbsp;</div>
        <div id="AreaGrid">
          <telerik:RadGrid ID="RadGrid1" runat="server"
                           AllowPaging="True" AllowFilteringByColumn="True" 
                           AllowSorting="True" ShowGroupPanel="false" PageSize="15"
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                           onpageindexchanged="RadGrid1_PageIndexChanged">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False"  DataKeyNames="DocumentoId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="DocumentoId" DataType="System.Int32" 
                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         ReadOnly="True" 
                                         SortExpression="DocumentoId" UniqueName="DocumentoId" Visible="false">
                </telerik:GridBoundColumn>
               <telerik:GridBoundColumn DataField="Fecha" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" 
                                         FilterControlToolTip="Filtrar por fecha" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha" 
                                         ReadOnly="True" 
                                         SortExpression="Fecha" UniqueName="Fecha">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nombre" 
                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Documento" 
                                         ReadOnly="True" 
                                         SortExpression="Nombre" UniqueName="Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Empresa.Nombre" 
                                         FilterControlToolTip="Filtrar por Empresa.Nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Empresa" 
                                         ReadOnly="True" 
                                         SortExpression="Empresa.Nombre" UniqueName="Empresa.Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Instalacion.Nombre" 
                                         FilterControlToolTip="Filtrar por Instalacion.Nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Instalacion" 
                                         ReadOnly="True" 
                                         SortExpression="Instalacion.Nombre" UniqueName="Instalacion.Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Categoria.Nombre" 
                                         FilterControlToolTip="Filtrar por Categoria.Nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Categoria" 
                                         ReadOnly="True" 
                                         SortExpression="Categoria.Nombre" UniqueName="Categoria.Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SubCategoria.Nombre" 
                                         FilterControlToolTip="Filtrar por SubCategoria.Nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Subcategoria" 
                                         ReadOnly="True" 
                                         SortExpression="SubCategoria.Nombre" UniqueName="SubCategoria.Nombre">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Revisable" 
                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Revisable" 
                                         ReadOnly="True" Visible="false" 
                                         SortExpression="Revisable" UniqueName="Revisable">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Revisado" 
                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Revisado" 
                                         ReadOnly="True" Visible="false" 
                                         SortExpression="Revisado" UniqueName="Revisado">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn AllowFiltering="False" 
                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                            UniqueName="Template">
                  <ItemTemplate>
                    <asp:ImageButton ID="Select" runat="server" 
                                     ImageUrl="~/imagenes/selection_view_16.png"
                                     ToolTip="Ver documentos de esta Documento" />
                  </ItemTemplate>
                </telerik:GridTemplateColumn>
              </Columns>
              <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
              </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
            </HeaderContextMenu>
          </telerik:RadGrid>
        </div>
        <div id="AreaPie">
          <telerik:RadNotification ID="RadNotification1" runat="server" 
                                   ContentIcon="imagenes/error_32.png" AutoCloseDelay="0" 
                                   TitleIcon="imagenes/error_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                   Height="400px" Position="Center" Title="ERROR" Width="400px">
          </telerik:RadNotification>
        </div>
      </div>
    </form>
  </body>
</html>
