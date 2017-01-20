<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispositivoGrid.aspx.cs" Inherits="DispositivoGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Dispositivos
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
          function newDispositivo()
          {
              //alert("newInstalacion");
              var url = "DispositivoTab.aspx?Caller=DispositivoGrid";
              var name = "DispositivoTab";
              openOutSide(url, name);
          }
          function editDispositivo(id)
          {
              var url = "DispositivoTab.aspx?Caller=DispositivoGrid" + "&DispositivoId=" + id;
              var name = "DispositivoTab";
              openOutSide(url, name);
          }
          function newAccesorioFromDispositivo(id) {
              var url = "DispositivoTab.aspx?Caller=DispositivoTab" + "&DispositivoPadreId=" + id;
              var name = "AccesorioTab";
              openOutSide(url, name);
          }
          function editAccesorioFromDispositivo(id) {
              var url = "DispositivoTab.aspx?Caller=DispositivoTab" + "&DispositivoId=" + id;
              var name = "AccesorioTab";
              openOutSide(url, name);
          }
          function newDispositivoFromInstalacion(id) 
          {
              //alert("newInstalacion");
              var url = "DispositivoTab.aspx?Caller=InstalacionTab&InstalacionId=" + id;
              var name = "DispositivoTab";
              openOutSide(url, name);
          }
          function editDispositivoFromInstalacion(id) 
          {
              var url = "DispositivoTab.aspx?Caller=InstalacionTab&InstalacionId=" + gup("InstalacionId") + "&DispositivoId=" + id;
              var name = "DispositivoTab";
              openOutSide(url, name);
          }
          function refreshGrid(arg)
          {
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
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="AreaComun">
        <div id="Titulo" class="normalText" style="text-align:right; padding:5px">
            <asp:CheckBox ID="chkCaducados" runat="server" AutoPostBack="true" 
                Text="Mostrar los dispositivos caducados" 
                oncheckedchanged="chkCaducados_CheckedChanged" />
        </div>
        <div id="AreaGrid">
          <telerik:RadGrid ID="RadGrid1" runat="server" EnableLinqExpressions="false" Width="100%"
                           AllowPaging="True" AllowFilteringByColumn="True" 
                           AllowSorting="True" ShowGroupPanel="True"
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                            onpageindexchanged="RadGrid1_PageIndexChanged">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                             DataKeyNames="DispositivoId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="DispositivoId" DataType="System.Int32" 
                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         ReadOnly="True"  Visible="false" 
                                         SortExpression="DispositivoId" UniqueName="DispositivoId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NumeroIndustria" 
                                         FilterControlToolTip="Filtrar por número de industria" FilterImageToolTip="Filtro"
                                         HeaderText="Numero de industria" 
                                         ReadOnly="True" 
                                         SortExpression="NumeroIndustria" UniqueName="NumeroIndustria">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="CodBarras" 
                                         FilterControlToolTip="Filtrar por código de barras" FilterImageToolTip="Filtro"
                                         HeaderText="Cod. Barras" 
                                         ReadOnly="True" 
                                         SortExpression="CodBarras" UniqueName="CodBarras">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nombre" 
                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Nombre" 
                                         ReadOnly="True" 
                                         SortExpression="Nombre" UniqueName="Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TipoDispositivo.Nombre" 
                                         FilterControlToolTip="Filtrar por modelo" FilterImageToolTip="Filtro"
                                         HeaderText="Tipo" 
                                         ReadOnly="True" 
                                         SortExpression="TipoDispositivo.Nombre" UniqueName="TipoDispositivo.Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ModeloDispositivo.Nombre" 
                                         FilterControlToolTip="Filtrar por modelo" FilterImageToolTip="Filtro"
                                         HeaderText="Modelo" 
                                         ReadOnly="True" 
                                         SortExpression="ModeloDispositivo.Nombre" UniqueName="ModeloDispositivo.Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Posicion" 
                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Ubicación" 
                                         ReadOnly="True" 
                                         SortExpression="Posicion" UniqueName="Posicion">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaCaducidad" 
                                         FilterControlToolTip="Filtrar por la fecha de caducidad" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha de caducidad" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                         ReadOnly="True" 
                                         SortExpression="FechaCaducidad" UniqueName="FechaCaducidad">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Instalacion.Nombre" 
                                         FilterControlToolTip="Filtrar por instalación" FilterImageToolTip="Filtro"
                                         HeaderText="Instalación" 
                                         ReadOnly="True" 
                                         SortExpression="Instalacion.Nombre" UniqueName="Instalacion.Nombre">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="Instalacion.Empresa.Nombre" 
                                         FilterControlToolTip="Filtrar por cliente" FilterImageToolTip="Filtro"
                                         HeaderText="Cliente" 
                                         ReadOnly="True" 
                                         SortExpression="Instalacion.Empresa.Nombre" UniqueName="Instalacion.Empresa.Nombre">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="Operativo" 
                                         FilterControlToolTip="Filtrar por operatividad" FilterImageToolTip="Filtro"
                                         HeaderText="Operativo" 
                                         ReadOnly="True" 
                                         SortExpression="Operativo" UniqueName="Operativo">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="Caducado" 
                                         FilterControlToolTip="Filtrar por cliente" FilterImageToolTip="Filtro"
                                         HeaderText="Caducado" 
                                         ReadOnly="True" Visible="false" 
                                         SortExpression="Caducado" UniqueName="Caducado">
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
                  <asp:ImageButton ID="New" runat="server" ImageUrl="~/images/document_add.png" 
                                   meta:resourceKey="NewResource1" OnClientClick="newDispositivo();" 
                                   ToolTip="Añadir un nuevo registro" />
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
                                   Height="400px" Position="Center" Title="ERROR" Width="400px">
          </telerik:RadNotification>
        </div>
      </div>
    </form>
  </body>
</html>
