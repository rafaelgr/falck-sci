<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermisoForm.aspx.cs" Inherits="PermisoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Permiso</title>
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
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td>
              <div id="PermisoId">
                <asp:Label ID="lblPermisoId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPermisoId" runat="server" Enabled="false" Width="100px">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="Proceso">
                <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtProceso" runat="server" Width="250px" TabIndex="1" 
                      Enabled="False">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="Grupo">
                <asp:Label ID="lblGrupo" runat="server" Text="Grupo"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtGrupo" runat="server" Width="250px" TabIndex="2" 
                      Enabled="False">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
          <td></td>
          <td>
              <asp:CheckBox ID="chkVer" runat="server" TabIndex="3"
               Text="Ver: Se nuestra el proceso en los menús" />
          </td>
          </tr>
          <tr>
          <td></td>
          <td>
              <asp:CheckBox ID="chkCrear" runat="server" TabIndex="4"
               Text="Crear: Se permite crear nuevos registros" />
          </td>
          </tr>
          <tr>
          <td></td>
          <td>
              <asp:CheckBox ID="chkModificar" runat="server" TabIndex="5"
               Text="Modificar: Se permite modificar los registros" />
          </td>
          </tr>
          <tr>
          <td></td>
          <td>
              <asp:CheckBox ID="chkEspecial" runat="server" TabIndex="6"
               Text="Especial: Se aplican permisos especiales" />
          </td>
          </tr>
          <tr>
            <td colspan="2">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="7" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="8" />
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
