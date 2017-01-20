<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta name="WebsiteSpark" content="PVdOV8zk8W" />
    <title>FALCK-SCI</title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          .style1
          {
              width: 180px;
              height: 50px;
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
      <script type="text/javascript">
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
      </telerik:RadWindowManager>
    
      <div id="MainArea">
        <div id="AreaTitulo" class="tituloMain">
          <table style="width:100%;">
            <tr>
              <td>
                &nbsp;<%--<asp:Label ID="lblTitulo" runat="server" Text="Lainsa-SCI"></asp:Label>--%><img 
                      alt="logo" class="style1" longdesc="logo" src="images/Falck.JPG"/></td>
              <td class="alineadoDerecha">
                <asp:Label ID="lblVersion" runat="server" Text="Vrs 0.0.0"></asp:Label>
              </td>
            </tr>
          </table>
        </div>
        <div id="LoginArea" class="normalText">
          <table style="width:100%;">
            <tr>
              <td width="20%"></td>
              <td width="60%">
                <div id="Login">
                  <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
                  <br />
                  <telerik:RadTextBox ID="txtLogin" runat="server">
                  </telerik:RadTextBox>
                </div>
              </td>
              <td width="20%"></td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="Password">
                  <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                  <br />
                  <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password">
                  </telerik:RadTextBox>
                </div>
              </td>
              <td></td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="Buttons">
                  <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
                              onclick="btnAceptar_Click" />
                </div>
              </td>
              <td></td>
            </tr>
          </table>
        </div>
        <div id="Pie">
          <telerik:RadNotification ID="RadNotification1" runat="server" 
                                   ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                                   TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                   Height="100px" Position="Center" Title="WARNING" Width="300px">
          </telerik:RadNotification>
        </div>
      </div>
          

    </form>
  </body>
</html>
