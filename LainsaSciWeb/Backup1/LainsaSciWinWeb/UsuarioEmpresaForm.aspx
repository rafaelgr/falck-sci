<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UsuarioEmpresaForm.aspx.cs" Inherits="LainsaSciWinWeb.UsuarioEmpresaForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title>UsuarioEmpresa</title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          .style1
          {
              height: 29px;
          }
      </style>
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
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript" src="NewRadConfirm.js"></script>
      </telerik:RadCodeBlock>
      
        
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
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
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          
          <tr>
            <td>
            </td>
            <td>
              <div ID="Empresa" class="normalText">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" 
                           ToolTip="La empresa a la que pertenece"></asp:Label>
                &nbsp;<asp:ImageButton ID="empresas" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchUsuarioEmpresa('Empresa');" 
                                 ToolTip="Haga clic aquí para buscar empresas" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcEmpresa" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" 
                                     
                                     onselectedindexchanged="rdcEmpresa_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
		  
           <tr>
            <td>
            </td>
            <td>
              <div ID="Instalacion" class="normalText">
                <asp:Label ID="lblInstalacion" runat="server" Text="Instalacion:" 
                           ToolTip="Instalacion que pertenece al usuario"></asp:Label>
                &nbsp;<asp:ImageButton ID="btn_Instalacion" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchUsuarioEmpresa('Instalacion');" 
                                 ToolTip="Haga clic aquí para buscar instalaciones" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcInstalacion" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" 
                                     onitemsrequested="rdcGrupoTrabajo_ItemsRequested">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
            </td>
                </tr>
          <tr>
            <td colspan="2">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="6" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="7" />
              </div>
            </td>

          </tr>
        </table>

      </div>
        <div id="FooterArea">
        <telerik:RadNotification ID="RadNotification1" runat="server" 
                                 ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                                 TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                 Height="100px" Position="Center" Title="WARNING" Width="300px">
        </telerik:RadNotification>
      </div>
    </form>
  </body>
</html>
