<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioForm.aspx.cs" Inherits="LainsaSciWinWeb.UsuarioForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Usuario</title>
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
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript">
            function loadValues(values) {
                var combo;
                if (values[2] == "Instalacion") {
                    combo = $find("<%=rdcInstalacion.ClientID %>");
                }
                if (values[2] == "Empresa") {
                    combo = $find("<%=rdcEmpresa.ClientID %>");
                }
                if (values[2] == "Grupo") {
                    combo = $find("<%=rdcGrupo.ClientID %>");
                }
                loadCombo(combo, values);
            }
            function loadCombo(combo, values) {
                var items = combo.get_items();
                items.clear();
                var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                comboItem.set_text(values[1]);
                comboItem.set_value(values[0]);
                items.add(comboItem);
                combo.commitChanges();
                comboItem.select();
            }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td>
              <div id="UsuarioId">
                <asp:Label ID="lblUsuarioId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtUsuarioId" runat="server" Enabled="false" Width="100px">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="Nombre">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtNombre" runat="server" Width="250px" TabIndex="1">
                </telerik:RadTextBox>

              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Login">
                <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtLogin" runat="server" Width="250px" TabIndex="2">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Password">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPassword" runat="server" Width="250px" TabIndex="3" TextMode="Password">
                    <PasswordStrengthSettings ShowIndicator="true" />
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Password2">
                <asp:Label ID="lblPassword2" runat="server" Text="Repita contraseña"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPassword2" runat="server" Width="250px" TabIndex="4" TextMode="Password">
                    <PasswordStrengthSettings ShowIndicator="true" />
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
            </td>
            <td>
              <div ID="Grupo" class="normalText">
                <asp:Label ID="lblGrupo" runat="server" Text="Grupo:" 
                           ToolTip="Grupo al que pertenece el usuario"></asp:Label>
                &nbsp;<asp:ImageButton ID="imgbGrupo" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchGrupoUsuario('UsuarioForm');" 
                                 ToolTip="Haga clic aquí para buscar grupos" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcGrupo" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" 
                                     onitemsrequested="rdcGrupo_ItemsRequested" 
                                     onselectedindexchanged="rdcGrupo_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
            </td>
            <td>
              <div ID="Empresa" class="normalText">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" 
                           ToolTip="Empresa a la que pertenece usuario"></asp:Label>
                &nbsp;<asp:ImageButton ID="imgEmpresa" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchEmpresa('UsuarioForm');" 
                                 ToolTip="Haga clic aquí para buscar grupos" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcEmpresa" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" 
                                     onitemsrequested="rdcEmpresa_ItemsRequested" 
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
                           ToolTip="Empresa a la que pertenece usuario"></asp:Label>
                &nbsp;<asp:ImageButton ID="imgInstalacion" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchInstalacion('UsuarioForm');" 
                                 ToolTip="Haga clic aquí para buscar grupos" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcInstalacion" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True" 
                                     onitemsrequested="rdcInstalacion_ItemsRequested" 
                                     onselectedindexchanged="rdcInstalacion_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
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
          <tr>
            <td colspan="2">
              &nbsp;
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
