<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlantillaRevisionForm.aspx.cs" Inherits="PlantillaRevisionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Plantilla de revisión
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
          function loadValues(values) {
              var combo;
              if (values[2] == "Tipo") {
                  combo = $find("<%=rdcTipoDisp.ClientID %>");
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
          function refreshGrid2(arg, frame) {
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
      </telerik:RadSkinManager>
      <telerik:RadNotification ID="RadNotification1" runat="server" 
                               ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                               TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                               Height="100px" Position="Center" Title="WARNING" Width="300px">
      </telerik:RadNotification>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td class="celda">
              <div id="PlantillaId" style="padding:5px;">
                <asp:Label ID="lblPlantillaId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPlantillaId" runat="server" Enabled="false" Width="200px" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
            <td colspan="3">
              <div id="Descripcion" style="padding:5px;">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDescripcion" runat="server" Width="100%" Rows="3" TabIndex="2"
                                    TextMode="MultiLine" MaxLength="254">
                </telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtDescripcion" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita una descripción">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div ID="Tipo" class="normalText" style="padding:5px;">
                <asp:Label ID="lblTipo" runat="server" Text="Tipo:" 
                           ToolTip="Tipo de dispositivo"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgbTipo" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchTipoDispositivo('PlantillaRevisionForm');" 
                                 ToolTip="Haga clic aquí para buscar los tipos de dispositivo" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcTipoDisp" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="4" AutoPostBack="True" 
                                     onitemsrequested="rdcTipoDisp_ItemsRequested" 
                                     onselectedindexchanged="rdcTipoDisp_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>
            <td>
              <div ID="TipoPeriodo" class="normalText" style="padding:5px;">
                <asp:Label ID="lblTipoPeriodo" runat="server" Text="Tipo periodo:" 
                           ToolTip="Tipo de periodo"></asp:Label>
                &nbsp;
                <br />
                <telerik:RadComboBox runat="server" ID="rdcTipoPeriodo" Height="100px" 
                                     Width="250px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="4" AutoPostBack="True" >
                </telerik:RadComboBox>
              </div>
            </td>
            <td>
              <div id="NumeroPeriodos" class="normalText" style="padding:5px;">
                <asp:Label ID="lblNumeroPeriodos" runat="server" Text="Núm. periodos"></asp:Label>
                <br />
                <telerik:RadNumericTextBox ID="txtNumeroPeriodos" runat="server" Width="60px" Culture="es" 
                                           DataType="System.Int32">
                  <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
              </div>
                
            </td>
            <td>
              <div id="ConSustitucion" class="normalText" style="padding:5px;">
                    <asp:CheckBox ID="chkConSustitucion" runat="server" Text="Implica sustitución" />
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div id="Comentarios" style="padding:5px;">
                <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtComentarios" runat="server" Width="100%" Rows="3" TabIndex="3"
                                    TextMode="MultiLine" MaxLength="254">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="4" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="5" />
              </div>
            </td>
          </tr>
        </table>
      </div>
      <div id="FooterArea">

      </div>
    </form>
  </body>
</html>
