<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DireccionForm.aspx.cs" Inherits="DireccionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Direccion</title>
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
            <td colspan="2" style="padding:5px">
              <div id="Propietario">
                <asp:Label ID="lblPropietario" runat="server" Text="" />
                <br />
                <telerik:RadTextBox ID="txtPropietario" runat="server" Enabled="false" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="padding:5px">
              <div id="DirPostal">
                <asp:Label ID="lblDirPostal" runat="server" Text="Direccion postal" />
                <br />
                <telerik:RadTextBox ID="txtDirPostal" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valDirPostal" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtDirPostal" CssClass="normalTextRed"
                                            ErrorMessage="Debe introducir una dirección">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="CoPostal" style="padding:5px">
                <asp:Label ID="Label1" runat="server" Text="Cod.Postal"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtCodPostal" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valCodPostal" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtCodPostal" CssClass="normalTextRed"
                                            ErrorMessage="Debe introducir un código postal">
                </asp:RequiredFieldValidator>
              </div>
            </td>
            <td>
              <div id="Poblacion" style="padding:5px">
                <asp:Label ID="lblPoblacion" runat="server" Text="Poblacion"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPoblacion" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
                <br />
                <asp:RequiredFieldValidator ID="valPoblacion" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtPoblacion" CssClass="normalTextRed"
                                            ErrorMessage="Debe introducir una población">
                </asp:RequiredFieldValidator>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div id="Provicia" style="padding:5px">
                <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtProvincia" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
            <td>
              <div id="Pais" style="padding:5px">
                <asp:Label ID="lblPais" runat="server" Text="Pais"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtPais" runat="server" Width="100%" TabIndex="1">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>          <tr>
            <td colspan="2" style="padding:5px">
              <div id="Descripcion">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <br />
                <telerik:RadTextBox ID="txtDescripcion" runat="server" Width="100%" Height="100px"
                                    TabIndex="2" TextMode="MultiLine">
                </telerik:RadTextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="padding:5px">
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
