﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TelefonoGrid.aspx.cs" Inherits="TelefonoGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Telefonos</title>
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
          function newTelefono(owner, id, caller) 
          {
              //alert("newUsuario");
              var url = "TelefonoForm.aspx?Caller=" + caller;
              switch (owner)
              {
                  case "Empresa":
                      url = url + "&EmpresaId=" + id;
                      break;
                  case "Instalacion":
                      url = url + "&InstalacionId=" + id;
                      break;
              }
              var name = "TelefonoForm";
              openOutSide(url, name);
          }
          function editTelefono(id, caller)
          {
              var url = "TelefonoForm.aspx?Caller=" + caller + "&TelefonoId=" + id;
              var name = "TelefonoForm";
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
                             DataKeyNames="TelefonoId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="TelefonoId" 
                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         ReadOnly="True" 
                                         SortExpression="TelefonoId" UniqueName="TelefonoId" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Numero" 
                                         FilterControlToolTip="Filtrar por número" FilterImageToolTip="Filtro"
                                         HeaderText="Número" 
                                         ReadOnly="True" 
                                         SortExpression="Numero" UniqueName="Numero">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Descripcion" 
                                         FilterControlToolTip="Filtrar por descripción" FilterImageToolTip="Filtro"
                                         HeaderText="Comentarios" 
                                         ReadOnly="True" 
                                         SortExpression="Descripcion" UniqueName="Descripcion">
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
                                   meta:resourceKey="NewResource1" OnClientClick="newTelefono();" 
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
