<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResumenRevisionForm.aspx.cs" Inherits="ResumenRevisionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      ResumenRevision de dispositivo
    </title>
    <%-- <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />--%>
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

          function loadCombo(combo, values){
              var items = combo.get_items();
              items.clear();
              var comboItem = new Telerik.Web.UI.RadComboBoxItem();
              comboItem.set_text(values[1]);
              comboItem.set_value(values[0]);
              items.add(comboItem);
              combo.commitChanges();
              comboItem.select();
          }
          function refreshGrid2(arg, frame){
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td colspan="3">
              <div id="ResumenRevisionId" style="padding:5px;">
                <asp:Label ID="lblResumenRevisionId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtResumenRevisionId" runat="server" Enabled="false" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <div id="Dispositivo" style="padding:5px;">
                <asp:Label ID="lblDispositivo" runat="server" Text="Dispositivo:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDispositivo" runat="server" Width="100%" TabIndex="2" Enabled="false">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <div id="Plantilla" style="padding:5px;">
                <asp:Label ID="lblPlantilla" runat="server" Text="Plantilla:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPlantilla" runat="server" Width="100%" TabIndex="2" Enabled="false">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="FechaInicio" style="padding:5px;">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha inicial:" Visible="false"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtFechaInicio" runat="server" Width="150px" TabIndex="2" Enabled="false" Visible="false">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="FechaUltima" style="padding:5px;">
                <asp:Label ID="lblFechaUltima" runat="server" Text="Fecha ultima:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdtFechaUltima" runat="server" Width="150px" TabIndex="7">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                  <DateInput DisplayDateFormat="d/MM/yyyy" DateFormat="d/MM/yyyy" TabIndex="7"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                </telerik:RadDatePicker>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                            ControlToValidate="rdtFechaUltima" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita una fecha">
                </asp:RequiredFieldValidator>
              </div>
            </td>
            <td>
              <div id="FechaSiguiente" style="padding:5px;">
                <asp:Label ID="lblFechaSiguiente" runat="server" Text="Fecha siguiente:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtFechaSiguiente" runat="server" Width="150px" TabIndex="2" Enabled="false">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="3" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="4" />
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
