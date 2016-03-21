<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MensajeGrid.aspx.cs" Inherits="MensajeGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Mensajes</title>
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
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript" src="NewRadConfirm.js"></script>
        <script type="text/javascript">
          function newMensaje() 
          {
              var url = "MensajeForm.aspx?Caller=MensajeGrid";
              var name = "MensajeForm";
              openOutSide(url, name);
          }
          function editMensaje(id)
          {
              var url = "MensajeForm.aspx?Caller=MensajeGrid" + "&MensajeId=" + id;
              var name = "MensajeForm";
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
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Windows7">
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
                           Skin="Windows7" onpageindexchanged="RadGrid1_PageIndexChanged">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                             DataKeyNames="MensajeId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="MensajeId" 
                                         FilterControlToolTip="Filtrar por MensajeId" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         ReadOnly="True" 
                                         SortExpression="MensajeId" UniqueName="MensajeId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Titulo" 
                                         FilterControlToolTip="Filtrar por Nombre" FilterImageToolTip="Filtro"
                                         HeaderText="Título" 
                                         ReadOnly="True" 
                                         SortExpression="Titulo" UniqueName="Titulo">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaInicio" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" 
                                         FilterControlToolTip="Filtrar por fecha inicial" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha inicio" 
                                         ReadOnly="True" 
                                         SortExpression="FechaInicio" UniqueName="FechaInicio">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FechaFinal" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" 
                                         FilterControlToolTip="Filtrar por fecha final" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha fin" 
                                         ReadOnly="True" 
                                         SortExpression="FechaFinal" UniqueName="FechaFinal">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn AllowFiltering="False" 
                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                            UniqueName="Template">
                  <ItemTemplate>
                    <asp:ImageButton ID="Select" runat="server" 
                                     ImageUrl="~/imagenes/selection_view_16.png"
                                     ToolTip="Ver documentos de esta instalacion" />
                  </ItemTemplate>
                </telerik:GridTemplateColumn>
              </Columns>
              <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
              </EditFormSettings>
              <CommandItemTemplate>

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
                                   ContentIcon="imagenes/error_32.png" AutoCloseDelay="0" 
                                   TitleIcon="imagenes/error_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                   Height="400px" Position="Center" Title="ERROR" Width="400px">
          </telerik:RadNotification>
        </div>
      </div>
    </form>
  </body>
</html>
