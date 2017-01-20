<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioExtranetGrid.aspx.cs" Inherits="LainsaSciWinWeb.UsuarioExtranetGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Usuarios extranet
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
          function newUsuario() {
              var caller = "UsuarioExtranetGrid";
              if (gup("Caller") != "MainMenu")
                  caller = gup("Caller");
              //alert("newUsuario");
              var url = "UsuarioExtranetTab.aspx?Caller=" + caller;
              var name = "UsuarioExtranetTab";
              openOutSide(url, name);
          }
          function newUsuarioEmpresa(id) {
              //alert("newUsuario");
              var caller = "UsuarioExtranetGrid";
              if (gup("Caller") != "MainMenu")
                  caller = gup("Caller");
              var url = "UsuarioExtranetTab.aspx?Caller=" + caller + "&EmpresaId=" + id;
              var name = "UsuarioExtranetTab";
              openOutSide(url, name);
          }
          function newUsuarioInstalacion(id) {
              //alert("newUsuario");
              var caller = "UsuarioExtranetGrid";
              if (gup("Caller") != "MainMenu")
                  caller = gup("Caller");
              var url = "UsuarioExtranetTab.aspx?Caller=" + caller + "&InstalacionId=" + id;
              var name = "UsuarioExtranetTab";
              openOutSide(url, name);
          }
          function editUsuario(id) {
              var caller = "UsuarioExtranetGrid";
              if (gup("Caller") != "MainMenu")
                  caller = gup("Caller");
              var url = "UsuarioExtranetTab.aspx?Caller=" + caller + "&UsuarioExtranetId=" + id;
              var name = "UsuarioExtranetTab";
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
          <telerik:RadGrid ID="RadGrid1" runat="server" Width="100%"
                           AllowPaging="True" AllowFilteringByColumn="True" 
                           AllowSorting="True" ShowGroupPanel="True"
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                           Skin="Simple" onpageindexchanged="RadGrid1_PageIndexChanged">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                             DataKeyNames="UsuarioExtranetId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="UsuarioExtranetId" DataType="System.Int32" 
                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         ReadOnly="True" 
                                         SortExpression="UsuarioExtranetId" UniqueName="UsuarioExtranetId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Nombre" 
                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Nombre" 
                                         ReadOnly="True" 
                                         SortExpression="Nombre" UniqueName="Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Login" 
                                         FilterControlToolTip="Filtrar por login" FilterImageToolTip="Filtro"
                                         HeaderText="Login" 
                                         ReadOnly="True" 
                                         SortExpression="Login" UniqueName="Login">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Empresa.Nombre" 
                                         FilterControlToolTip="Filtrar por empresa" FilterImageToolTip="Filtro"
                                         HeaderText="Empresa" 
                                         ReadOnly="True" 
                                         SortExpression="Empresa.Nombre" UniqueName="Empresa.Nombre">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Instalacion.Nombre" 
                                         FilterControlToolTip="Filtrar por instalación" FilterImageToolTip="Filtro"
                                         HeaderText="Instalacion" 
                                         ReadOnly="True" 
                                         SortExpression="Instalacion.Nombre" UniqueName="Instalacion.Nombre">
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
                                   meta:resourceKey="NewResource1" OnClientClick="newUsuario();" 
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
