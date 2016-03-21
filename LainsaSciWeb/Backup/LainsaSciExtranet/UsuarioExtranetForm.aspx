<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioExtranetForm.aspx.cs" Inherits="LainsaSciWinWeb.UsuarioExtranetForm" %>

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
          function loadValues(values)
          {
              var combo = $find("<%=rdcEmpresa.ClientID %>");
              loadCombo(combo, values);
          }
          function loadCombo(combo, values)
          {
              var items = combo.get_items();
              items.clear();
              var comboItem = new Telerik.Web.UI.RadComboBoxItem();
              comboItem.set_text(values[1]);
              comboItem.set_value(values[0]);
              items.add(comboItem);
              combo.commitChanges();
              comboItem.select();
          }
          function refreshGrid2(arg, frame)
          {
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
          function abrirPlantilla()
          {
              var w1 = window.open("VisorInformeForm.aspx?PlantillaId=1", "PLANTILLA", "width=800, height=600,resizable=1");
              w1.focus();
          }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"
                              onajaxrequest="RadAjaxManager1_AjaxRequest">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Windows7">
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
                <telerik:RadTextBox ID="txtNombre" runat="server" Width="250px" TabIndex="1" Enabled="false">
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
                <telerik:RadTextBox ID="txtLogin" runat="server" Width="250px" TabIndex="2" Enabled="false">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Email">
                <asp:Label ID="lblEmail" runat="server" Text="Correo electrónico"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtEmail" runat="server" Width="250px" TabIndex="3">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Global">
                <asp:CheckBox ID="chkGlobal" runat="server" Text="Usuario global (institucional)" TabIndex="4" Visible="false" />
              </div>
            </td>
          </tr>
          <tr>
            <td>
            </td>
            <td>
              <div ID="Empresa" class="normalText" style="visibility:hidden; height:0px">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" 
                           ToolTip="Empresa al que pertenece el usuario"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgbGrupo" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchEmpresa('UsuarioExtranetForm');" 
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
              <div ID="Instalacion" class="normalText" style="visibility:hidden; height:0px">
                <asp:Label ID="lblInstalacion" runat="server" Text="Instalacion:" 
                           ToolTip="Instalacion a la que tiene acceso el usuario"></asp:Label>
                &nbsp;
                <br />
                <telerik:RadComboBox runat="server" ID="rdcInstalacion" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="" TabIndex="5" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Password">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPassword" runat="server" Width="250px" TabIndex="6" TextMode="Password">
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
                <telerik:RadTextBox ID="txtPassword2" runat="server" Width="250px" TabIndex="7" TextMode="Password">
                  <PasswordStrengthSettings ShowIndicator="true" />
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>

          <tr>
            <td colspan="2">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnGenerar" runat="server" CausesValidation="False"
                                 ImageUrl="~/images/check.png" Visible="false"
                                 ToolTip="Generar passwords y carta" TabIndex="6" 
                                 onclick="btnGenerar_Click" />
                &nbsp;
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/imagenes/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="6" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/imagenes/document_out.png" CausesValidation="False" 
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
                                 ContentIcon="imagenes/graduate_32.png" AutoCloseDelay="0" 
                                 TitleIcon="imagenes/graduation_hat2_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                 Height="100px" Position="Center" Title="INFORMACION" Width="300px">
        </telerik:RadNotification>
      </div>
    </form>
  </body>
</html>
