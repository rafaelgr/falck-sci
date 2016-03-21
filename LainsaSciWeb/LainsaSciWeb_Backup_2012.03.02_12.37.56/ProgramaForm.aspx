<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramaForm.aspx.cs" Inherits="ProgramaForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Programa revisiones
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
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js"></script>
        <script type="text/javascript">
          function refreshGrid2(arg, frame){
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
          function refreshGrid(arg) {
              refreshGrid2(arg, "ifRevisiones");
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
            <td width="20%">
              <div id="ProgramaId" style="padding:5px;">
                <asp:Label ID="lblProgramaId" runat="server" Text="Nro. Programa"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtProgramaId" runat="server" Enabled="false" Width="100%">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="Usuario" style="padding:5px;">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcUsuario" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="5" AutoPostBack="True"></telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td class="celda">
              <div id="FechaProgramada" style="padding:5px;">
                <asp:Label ID="lblFechaProgramada" runat="server" Text="Fecha programada:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="dtpFechaProgramada" runat="server" Width="150px" TabIndex="7">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                  <DateInput DisplayDateFormat="d/MM/yyyy" DateFormat="d/MM/yyyy" TabIndex="7"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                </telerik:RadDatePicker>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                            ControlToValidate="dtpFechaProgramada" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita una fecha de programación">
                </asp:RequiredFieldValidator>
              </div>
            </td>
            <td>
              <div id="Comentarios" style="padding:5px;">
                <asp:Label ID="lblComentarios" runat="server" Text="Comentarios"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtComentarios" runat="server" Width="100%" Height="50px" TextMode="MultiLine" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div id="Revisiones" class="frameConMarco">
                <asp:Label ID="lblRevisiones" runat="server" Text="Revisiones"></asp:Label>
                <br />
                <iframe id="ifRevisiones" runat="server" frameborder="0" width="100%" height="200px"></iframe>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div id="Susutituciones" class="frameConMarco">
                <asp:Label ID="lblSustituciones" runat="server" Text="Sustituciones"></asp:Label>
                <br />
                <iframe id="ifSustituciones" runat="server" frameborder="0" width="100%" height="150px"></iframe>
              </div>
            </td>
          </tr>

          <tr>
            <td colspan="2">
              <div ID="Buttons" class="buttonsFormat">
                              <asp:ImageButton ID="btnPrint" runat="server" 
                                 ImageUrl="~/images/printer_24.png"
                                 ToolTip="Imprimir revisiones" TabIndex="2" onclick="btnPrint_Click" />
                &nbsp;
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="2" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="3" />
              </div>
            </td>
          </tr>
          <tr>
            <td>
              &nbsp;
            </td>
            <td>
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
