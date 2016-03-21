<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisoGrid.aspx.cs" Inherits="PermisoGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Permisos</title>
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
          function editPermiso(id)
          {
              var url = "PermisoForm.aspx?Caller=PermisoGrid" + "&PermisoId=" + id;
              var name = "PermisoForm";
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
              <telerik:AjaxUpdatedControl ControlID="RadTreeList1" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="AreaComun">
        <div id="Titulo">
        </div>
        <div id="Selector" class="normalText" style="padding-bottom:5px">
          <asp:Label runat="server" ID="lblSelector" Text="Grupo de usuarios: "></asp:Label>
          <telerik:RadComboBox ID="rdcGrupoUsuario" runat="server" Width="300px" AutoPostBack="true" 
                               onselectedindexchanged="rdcGrupoUsuario_SelectedIndexChanged">
          </telerik:RadComboBox>
        </div>
        <div id="AreaGrid">
          <telerik:RadTreeList ID="RadTreeList1" runat="server" AutoGenerateColumns="false" 
                               DataKeyNames="ProcessId"  
                               ParentDataKeyNames="ParentProcessId" AllowPaging="true"
                               onitemcommand="RadTreeList1_ItemCommand" 
                               onitemdatabound="RadTreeList1_ItemDataBound" 
                               onneeddatasource="RadTreeList1_NeedDataSource">
            <Columns>
              <telerik:TreeListBoundColumn DataField="PermissionId" DataType="System.Int32" HeaderText="PerID" 
                                           Visible="false" UniqueName="PermissionId">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="ProcessId" DataType="System.Int32" HeaderText="ProID" 
                                           Visible="false" UniqueName="ProcessId">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="ParentProcessId" 
                                           DataType="System.Int32" HeaderText="PaProID" 
                                           Visible="false" UniqueName="ParentProcessID">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Name" DataType="System.String" HeaderText="Proceso" UniqueName="Name" HeaderStyle-Width="30%">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="View" DataType="System.Boolean" HeaderText="Ver" UniqueName="View">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Create" DataType="System.Boolean" HeaderText="Crear" UniqueName="Create">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Modify" DataType="System.Boolean" HeaderText="Modificar" UniqueName="Modify">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Execute" DataType="System.Boolean" HeaderText="Ejecutar" UniqueName="Execute">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListTemplateColumn AllowSorting="false" UniqueName="TemplateEditColumn">
                <ItemTemplate>
                  <asp:ImageButton ID="Edit" runat="server" 
                                   ImageUrl="~/images/document_edit_16.png"  ToolTip="Editar estos registros"/>
                </ItemTemplate>
              </telerik:TreeListTemplateColumn>
            </Columns>
          </telerik:RadTreeList>
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
