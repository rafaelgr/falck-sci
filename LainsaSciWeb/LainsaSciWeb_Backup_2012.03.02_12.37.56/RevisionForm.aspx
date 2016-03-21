<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionForm.aspx.cs" Inherits="RevisionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Instalación
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
          function loadValues(values)
          {
              var combo = $find("<%=rdcOperario.ClientID %>");
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

              //alert(frame);
              // search for the iframe
              var iframe = document.getElementById(frame);
              iframe.contentWindow.refreshGrid(arg);
          }
          // confirmación de valores
          function confirmar(mensaje, valor) {
              radprompt(mensaje, retornoPrompt, 330, 160, null, 'AVISO', valor);
              return false;
          }
          function retornoPrompt(arg) {
              if (arg != "") {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("A"+arg);
              }
          }
          function retornoConfirm(arg) {
              if (arg != "") {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("B" + arg);
              }
          }
          function retornoAlert(arg) {
          }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" onajaxrequest="RadAjaxManager1_AjaxRequest">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
      </telerik:RadSkinManager>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td>
              <div id="RevisionId" style="padding:5px;">
                <asp:Label ID="lblRevisionId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtRevisionId" runat="server" Enabled="false" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="FechaPlanificada">
                <asp:Label ID="lblFechaPlanificada" runat="server" Text="Fecha planificada:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdpFechaPlanificada" Runat="server" Enabled="false" TabIndex="2">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                  <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="2"></DateInput>

                  <DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl="" TabIndex="2"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>          
            <td>
              <div id="FechaProgramada">
                <asp:Label ID="lblFechaProgramada" runat="server" Text="Fecha programada:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdpFechaProgramada" Runat="server" Enabled="false" TabIndex="3">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                  <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="3"></DateInput>

                  <DatePopupButton CssClass="rcCalPopup rcDisabled" ImageUrl="" HoverImageUrl="" TabIndex="3"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>
            <td>
              <div id="Status">
                <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtStatus" runat="server" Width="200px">
                </telerik:RadTextBox>
              </div>
            </td>
              
          </tr>
          <tr>
            <td colspan="2">
              <div ID="Dispositivo" class="normalText" style="padding:5px;">
                <asp:Label ID="lblDispositivo" runat="server" Text="Dispositivo:" 
                           ToolTip="Dispositivo que se revisa"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDispositivo" runat="server" Width="100%" 
                      Enabled="False">
                </telerik:RadTextBox>

              </div>

            </td>
            <td colspan="2">
              <div ID="Operario" class="normalText" style="padding:5px;">
                <asp:Label ID="lblOperario" runat="server" Text="Operario:" 
                           ToolTip="Operario que ha hecho la revisión"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgbOperario" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchOperario('RevisionForm');" 
                                 ToolTip="Haga clic aquí para buscar Operarios" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcOperario" TabIndex="4" Height="100px" 
                                     Width="300px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." AutoPostBack="True" 
                                     onitemsrequested="rdcOperario_ItemsRequested" 
                                     onselectedindexchanged="rdcOperario_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>

          </tr>
          <tr>
            <td colspan="2">
              <div id="NomPlantilla" style="padding:5px;">
                <asp:Label ID="lblPlantilla" runat="server" Text="Plantilla"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPlantilla" runat="server" Width="100%" TabIndex="7" Enabled="false" >
                </telerik:RadTextBox>
              </div>
            </td>
            <td colspan="2">
              <div id="FechaRevisión">
                <asp:Label ID="lblFechaRevision" runat="server" Text="Fecha de revisión"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdpFechaRevision" Runat="server" TabIndex="1">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                  <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="3"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="1"></DatePopupButton>
                </telerik:RadDatePicker>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                            ControlToValidate="rdpFechaRevision" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita la fecha en que se hizo la revisión">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
        </table>
        <div id="PPlantilla" class="marcoPlantilla" style="padding:5px">
            <asp:PlaceHolder ID="PlantillaHolder" runat="server">
            </asp:PlaceHolder>
        </div>
        
        <table style="width:100%">
          <tr>
            <td colspan="4">
              <div id="Resultado" style="padding:5px;">
                <asp:Label ID="lblResultado" runat="server" Text="Resultado"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtResultado" runat="server" Width="100%" TabIndex="5" MaxLength="255" TextMode="MultiLine">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valResultado" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtResultado" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita un resultado para la Revisión">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div id="Observaciones" style="padding:5px;">
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtObservaciones" runat="server" Width="100%" TabIndex="6" MaxLength="255" TextMode="MultiLine">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            
          </tr>
          <tr>
            <td>
              &nbsp;
    &nbsp;
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnSustitucion" runat="server" CausesValidation="false" 
                                 ImageUrl="~/images/gear_refresh.png"
                                 ToolTip="Sustituciones asociadas" TabIndex="6" 
                      onclick="btnSustitucion_Click" />
                &nbsp;
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
