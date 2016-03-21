<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentoForm.aspx.cs" Inherits="DocumentoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Documento
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
              var combo = $find("<%=rdcEmpresa.ClientID %>");
              loadCombo(combo, values);
              $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(values[0]);
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
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" >
      </telerik:RadSkinManager>
      <div id="MainArea" class="normalText">
        <table style="width:100%;">
          <tr>
            <td colspan="4">
              <div ID="Empresa" class="normalText" style="padding:5px;">
                <asp:Label ID="lblEmpresa" runat="server" Text="Empresa:" 
                           ToolTip="Empresa al que pertenece la instalación"></asp:Label>
                &nbsp;
                <asp:ImageButton ID="imgbEmpresa" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchEmpresa('DocumentoForm');" 
                                 ToolTip="Haga clic aquí para buscar Empresas" />
                <br />
                <telerik:RadComboBox runat="server" ID="rdcEmpresa" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     EmptyMessage="Escriba aquí ..." TabIndex="1" AutoPostBack="True"
                                     OnItemsRequested="rdcEmpresa_ItemsRequested"  
                                     OnSelectedIndexChanged= "rdcEmpresa_SelectedIndexChanged">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div ID="Instalacion" class="normalText" style="padding:5px;">
                <asp:Label ID="lblInstalacion" runat="server" Text="Instalacion:" 
                           ToolTip="Instalación con la que se realaciona el documento"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcInstalacion" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="2" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div ID="Tipo" class="normalText" style="padding:5px;">
                <asp:Label ID="lblTipo" runat="server" Text="Tipo de dispositivo:" 
                           ToolTip="Tipo de dispositivo con el que se realaciona el documento"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcTipo" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="2" AutoPostBack="True" Enabled="false">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <div ID="Categoria" class="normalText" style="padding:5px;">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria:" 
                           ToolTip="Categoria a la que pertenece el documento"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcCategoria" Height="100px" 
                                     Width="100%" ItemsPerRequest="10"
                                     OnSelectedIndexChanged= "rdcCategoria_SelectedIndexChanged" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="3" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
                        <td colspan="2">
              <div ID="Subcategoria" class="normalText" style="padding:5px;">
                <asp:Label ID="Label1" runat="server" Text="Subcategoria:" 
                           ToolTip="Subcategoria a la que pertenece el documento"></asp:Label>
                <br />
                <telerik:RadComboBox runat="server" ID="rdcSubcategoria" Height="100px" 
                                     Width="100%" ItemsPerRequest="10" 
                                     EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                     TabIndex="3" AutoPostBack="True">
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="DocumentoId" style="padding:5px;">
                <asp:Label ID="lblDocumentoId" runat="server" Text="ID"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDocumentoId" runat="server" Enabled="false" Width="100%" TabIndex="2">
                </telerik:RadTextBox>
              </div>
            </td>
            <td colspan="3">
              <div id="Nombre" style="padding:5px;">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtNombre" runat="server" Width="100%" TabIndex="3">
                </telerik:RadTextBox>
                <br />
              <%--                <asp:RequiredFieldValidator ID="valNombre" runat="server" Display="Dynamic" 
              ControlToValidate="txtNombre" CssClass="normalTextRed"
              ErrorMessage="Se necesita un nombre para la Documento">
              </asp:RequiredFieldValidator>--%>
              </div>
            </td>
          </tr>
          <tr>
            <td  width="25%">
            </td>
            <td width="25%">
              <div id="Fecha" style="padding:5px;">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha documento:"></asp:Label>
                <br />
                <telerik:RadDatePicker ID="dtFecha" runat="server" Width="100%" 
                                       TabIndex="7" Culture="es" MinDate="1000-01-01">
                  <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                  <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="7"></DateInput>

                  <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                </telerik:RadDatePicker>
              </div>
            </td>
            <td width="25%">
              <div id="Revisable" style="padding:5px;">
                <%--<asp:CheckBox ID="chkRevisable" runat="server" Text="Necesita revisión" />--%>
              </div>
            </td>
            <td width="25%">
              <div id="Revisado" style="padding:5px;">
               <%-- <asp:CheckBox ID="chkRevisado" runat="server" Text="Ha sido revisado" />--%>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
                <div id="Comentarios" style="padding:5px;">
                    <asp:Label ID="lblComentarios" runat="server" Text="Comentarios:"></asp:Label>
                    <br />
                    <telerik:RadEditor ID="rdeComentarios" runat="server" Width="100%" Height="200px" 
                        ToolsFile="~/ToolsFile.xml">
                    </telerik:RadEditor>
                </div>
            </td>
          </tr>
          <tr>
            <td colspan="4">
              <div ID="Buttons" class="buttonsFormat">
                <asp:ImageButton ID="btnAccept" runat="server" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                 ToolTip="Guardar y salir" TabIndex="8" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                 TabIndex="9" />
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
                                 Height="100px" Position="Center" Title="Atención" Width="300px">
        </telerik:RadNotification>
      </div>
    </form>
  </body>
</html>
