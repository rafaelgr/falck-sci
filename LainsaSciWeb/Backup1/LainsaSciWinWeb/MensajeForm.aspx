<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MensajeForm.aspx.cs" Inherits="MensajeForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Mensaje
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
              var combo = $find("<%=rdcGrupoMensajes.ClientID %>");
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
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td></td>
            <td></td>
            <td></td>
          </tr>
          <tr>
            <td>
              <div id="MensajeId" style="padding:5px;">
                <asp:Label ID="lblMensajeId" runat="server" Text="ID:"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtMensajeId" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
            <td colspan="2">
              <div ID="GrupoMensajes" class="normalText" style="padding:5px;">
                <asp:Label ID="lblGrupoMensajes" runat="server" Text="Grupo mensajes:" 
                           ToolTip="Grupo al que pertenece el mensaje"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgbGrupoMensajes" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchGrupoMensajes('MensajeForm');" 
                                 ToolTip="Haga clic aquí para buscar grupos" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcGrupoMensajes" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="1" AutoPostBack="True" 
                                     onitemsrequested="rdcGrupoMensajes_ItemsRequested" 
                                     onselectedindexchanged="rdcGrupoMensajes_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
            </td>
            <td colspan="2">
              <div id="Titulo" style="padding:5px;">
                <asp:Label ID="lblTitulo" runat="server" Text="Titulo"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtTitulo" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valTitulo" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtTitulo" CssClass="normalTextRed"
                                            ErrorMessage="Se necesita un título para el mensaje"></asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td>
              <div id="FechaInicio" style="padding:5px;">
                <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha inicio:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="dtFechaInicio" runat="server" Width="100px" 
                                       TabIndex="7" Culture="es" MinDate="1000-01-01">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                  <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="7"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>
            <td>
              <div id="FechaFin" style="padding:5px;">
                <asp:Label ID="lblFechaFin" runat="server" Text="Fecha final:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="dtFechaFin" runat="server" Width="100px" 
                                       TabIndex="7" Culture="es" MinDate="1000-01-01">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                  <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="7"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="3">
              <div id="Cuerpo" style="padding:5px;">
                <asp:Label ID="lblCuerpo" runat="server" Text="Cuerpo:"></asp:Label>
                <br />
                <telerik:RadEditor ID="rdeCuerpo" runat="server" Width="100%" Height="400px" 
                                   ToolsFile="~/Tools/ToolsFile.xml">
                </telerik:RadEditor>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="3">
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
                                 Height="100px" Position="Center" Title="WARNING" Width="250px">
        </telerik:RadNotification>
      </div>
    </form>
  </body>
</html>
