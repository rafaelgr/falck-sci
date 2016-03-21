<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispositivoForm.aspx.cs" Inherits="DispositivoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Dispositivo
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
          function loadValues(values){
              var combo;
              if (values[2] == "Instalacion"){
                  combo = $find("<%=rdcInstalacion.ClientID %>");
              }
              if (values[2] == "Tipo"){
                  combo = $find("<%=rdcTipoDisp.ClientID %>");
              }
              if (values[2] == "Modelo"){
                  combo = $find("<%=rdcModelos.ClientID %>");
              }
              if (values[2] == "AgenteExtintor"){
                  combo = $find("<%=rdcAgenteExtintor.ClientID %>");
              }
              if (values[2] == "Fabricante"){
                  combo = $find("<%=rdcFabricante.ClientID %>");
              }
              loadCombo(combo, values);
          }
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
          function refreshGrid(arg) {
              var iframe = document.getElementById("ifRevisiones");
              iframe.contentWindow.refreshGrid(arg);
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
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td>
              <div ID="Instalación" class="normalText" style="padding:5px;">
                <asp:Label ID="lblInstalación" runat="server" Text="Instalación:" 
                           ToolTip="Instalación al que pertenece el dispositivo"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgbInstalacion" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchInstalacion('DispositivoForm');" 
                                 ToolTip="Haga clic aquí para buscar Instalaciones" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcInstalacion" Height="100px" 
                                     Width="200px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="1" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
            <td>
              <div ID="Funcion" class="normalText" style="padding:5px;">
                <asp:Label ID="lblFuncion" runat="server" Text="Función:" 
                           ToolTip="Funcion que cumple el dispositivo"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcFuncion" Height="100px" 
                                     Width="200px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="1" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
            <td>
              <div id="Caducado" class="normalText" style="padding:5px;">
                <asp:CheckBox ID="chkCaducado" runat="server" Text="Dispositivo caducado" 
                              oncheckedchanged="chkCaducado_CheckedChanged" />
                <br />
                <asp:Label ID="lblCaducado" runat="server" Text="Fecha de baja:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="rdtFechaBaja" runat="server" Width="200px" 
                                       TabIndex="6" Culture="es-ES">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                            ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                  <DateInput DisplayDateFormat="d/MM/yyyy" DateFormat="d/MM/yyyy" TabIndex="6"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="6"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="CodBarras" style="padding:5px;">
                <asp:Label ID="lblCodBarras" runat="server" Text="Código de barras"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtCodBarras" runat="server" Width="200px" TabIndex="3">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtCodBarras" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita un código">
                </asp:RequiredFieldValidator>
              </div>
            </td>
            <td colspan="2">
              <div id="DispositivoId" style="padding:5px; visibility:hidden; height:0px">
                <asp:Label ID="lblDispositivoId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDispositivoId" runat="server" Enabled="false" Width="200px" TabIndex="2" Visible="false">
                </telerik:RadTextBox>
              </div>
            </td>

          </tr>
          <tr>
            <td>
              <div id="Nombre" style="padding:5px;">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre [Identificador del cliente]"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtNombre" runat="server" Width="100%" TabIndex="3">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtNombre" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita un nombre">
                </asp:RequiredFieldValidator>
              </div>
            </td>
            <td>
              <div ID="Estado" class="normalText" style="padding:5px;">
                <asp:Label ID="lblEstado" runat="server" Text="Estado:" 
                           ToolTip="Estado"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcEstado" Height="100px" 
                                     Width="200px" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="1" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
            <td width="20%">
              <div id="NumIndustria" style="padding:5px;">
                <asp:Label ID="lblNumIndustria" runat="server" Text="Número de industria:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtNumIndustria" runat="server" Width="100%" TabIndex="2">
                </telerik:RadTextBox>
                <br />
              </div>
            </td>
          </tr>
          <tr>
            <td >
              <div ID="Tipo" class="normalText" style="padding:5px;">
                <asp:Label ID="lblTipo" runat="server" Text="Tipo:" 
                           ToolTip="Tipo de dispositivo"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgTipo" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchTipoDispositivo('DispositivoForm');" 
                                 ToolTip="Haga clic aquí para buscar tipos" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcTipoDisp" Height="100px" 
                                     Width="200px" ItemsPerRequest="10" CausesValidation="false" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="4" AutoPostBack="True" 
                                     onselectedindexchanged="rdcTipoDisp_SelectedIndexChanged" >
                </telerik:RadComboBox>
              </div>
            </td>
            <td >
              <div ID="Modelo" class="normalText" style="padding:5px;">
                <asp:Label ID="lblModelo" runat="server" Text="Modelo:" 
                           ToolTip="Modelo de dispositivo"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgModelo" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchModeloDispositivo('DispositivoForm');" 
                                 ToolTip="Haga clic aquí para buscar modelos" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcModelos" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" CausesValidation="false"
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="5" AutoPostBack="True" 
                                     onselectedindexchanged="rdcModelos_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>
            <td width="20%">
              <div id="Ffabricacion" style="padding:5px;">
                <asp:Label ID="lblFfabricacion" runat="server" Text="Fabricado:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="dateFfabricacion" runat="server" Width="200px" 
                                       TabIndex="6" Culture="en-US">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                            ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                  <DateInput DisplayDateFormat="d/MM/yyyy" DateFormat="d/MM/yyyy" TabIndex="6"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="6"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>
          </tr>
          <tr>
            <td >
              <div ID="Fabricante" class="normalText" style="padding:5px;">
                <asp:Label ID="lblFabricante" runat="server" Text="Fabricante:" 
                           ToolTip="Fabricante del dispositivo."></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgFabricante" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchFabricante('DispositivoForm');" 
                                 ToolTip="Haga clic aquí para buscar fabricantes" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcFabricante" Height="100px" 
                                     Width="200px" ItemsPerRequest="10" CausesValidation="false"
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="4" AutoPostBack="True" >
                </telerik:RadComboBox>
              </div>
            </td>
            <td >
              <div ID="AgenteExtintor" class="normalText" style="padding:5px;">
                <asp:Label ID="lblAgenteExtintor" runat="server" Text="Agente extintor:" 
                           ToolTip="Agente extintor del dispositivo"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgAgente" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchAgenteExtintor('DispositivoForm');" 
                                 ToolTip="Haga clic aquí para buscar agentes" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcAgenteExtintor" Height="100px" 
                                     Width="200px" ItemsPerRequest="10" CausesValidation="false"
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="5" AutoPostBack="True" >
                </telerik:RadComboBox>
              </div>
            </td>
            <td width="20%">
              <div id="FCaducidad" style="padding:5px;">
                <asp:Label ID="lblFcaducidad" runat="server" Text="Caducidad:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="dateFCaducidad" runat="server" Width="200px" 
                                       TabIndex="7" Enabled="False" Culture="en-US">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
                            ViewSelectorText="x" FastNavigationStep="12"></Calendar>

                  <DateInput DisplayDateFormat="d/MM/yyyy" DateFormat="d/MM/yyyy" TabIndex="7"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                </telerik:RadDatePicker>
                <br />
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <div id="Revisones" class="frameConMarco">
                <asp:Label ID="lblRevisiones" runat="server" Text="Revisiones (resumen)"></asp:Label>
                <br />
                <iframe id="ifRevisiones" runat="server" frameborder="0" width="100%" height="150px"></iframe>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="Posicion" style="padding:5px;">
                <asp:Label ID="lblPosicion" runat="server" Text="Ubicación:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPosicion" runat="server" Width="100%" Rows="3" TabIndex="9"
                                    TextMode="MultiLine" MaxLength="254">
                </telerik:RadTextBox>
              </div>
            </td>
            <td colspan="2">
              <div id="Comentarios" style="padding:5px;">
                <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtComentarios" runat="server" Width="100%" Rows="3" TabIndex="10"
                                    TextMode="MultiLine" MaxLength="254">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <div ID="Buttons" class="buttonsFormat">

                &nbsp;
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="11" />
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="12" />
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
