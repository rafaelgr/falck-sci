<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionFormF.aspx.cs" Inherits="RevisionFormF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta name="viewport" content="width=240" />
        <title></title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="EstiloMovil.css" rel="stylesheet" type="text/css" />
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
                //Put your JavaScript code here.
            </script>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <div id="Marco" class="marcoMobil">
                <table>
                    <tr>
                        <td style="text-align:left;width:20%">
                            <div id="Usuario" class="textoReducidoMarco">
                                <asp:Label ID="lblUsuario" runat="server" text="USUARIO"></asp:Label>
                            </div>
                        </td>
                        <td style="text-align:center;width:80%">
                            <div id="Formulario" class="textoReducidoMarco">
                                <asp:Label ID="lblFormulario" runat="server" Text="Revision"></asp:Label>
                            </div>
                        </td>
                        <td style="text-align:right;width:20%">
                            <div id="Inicio" class="textoReducidoMarco">
                                <telerik:RadButton ID="btnInicio" runat="server" Text="Inicio" 
                                                   onclick="btnInicio_Click" CausesValidation="false">
                                </telerik:RadButton>
                            </div>
                        </td>
                    </tr>
                    <tr> 
                        <td colspan="3">
                            <div id="Titulo" class="textoReducidoMarco bordeInferior bordeSuperior">
                                <asp:Label ID="lblTitulo" runat="server" Text="Titulo"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr> 
                        <td colspan="3">
                            <div id="FechaRevisión" class="textoReducidoMarco">
                                <asp:Label ID="lblFechaRevision" runat="server" Text="Fecha de revisión"></asp:Label>
                                <br />
                                <telerik:RadDatePicker ID="rdpFechaRevision" Runat="server" TabIndex="1">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" TabIndex="3"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="1"></DatePopupButton>
                                </telerik:RadDatePicker>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" 
                                                            ControlToValidate="rdpFechaRevision" CssClass="textoNormalRojo"
                                                            ErrorMessage="Se necesita la fecha en que se hizo la revisión">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
<tr>
                        <td colspan="3" class="textoReducidoMarco">
                            <div id="Status">
                                <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
                                <br />
                                <telerik:RadTextBox ID="txtStatus" runat="server">
                                </telerik:RadTextBox>
                            </div>
                        </td></tr>
                    <tr>
                        <td colspan="3">
                            <div id="Resultado" class="textoReducidoMarco">
                                <asp:Label ID="lblResultado" runat="server" Text="Resultado"></asp:Label>
                                <br />
                                <telerik:RadTextBox ID="txtResultado" runat="server" TabIndex="5" TextMode="MultiLine" Width="170px">
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
                        <td colspan="3">
                            <div id="Observaciones" class="textoReducidoMarco">
                                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                                <br />
                                <telerik:RadTextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Width="170px">
                                </telerik:RadTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;width:20%">
                            <div id="1" class="textoReducidoMarco">
                                <telerik:RadButton ID="btnAnterior" runat="server" Text="<" 
                                                   onclick="btnAnterior_Click" CausesValidation="false">
                                </telerik:RadButton>
                            </div>
                        </td>
                        <td style="text-align:center;width:60%">
                            <div id="Imagen" style="text-align:center">

                                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sci_color_50.jpg" Height="20px" />
                            </div>

                        </td>
                        <td style="text-align:right;width:20%">
                            <div id="Div1" class="textoReducidoMarco">

                                                                <telerik:RadButton ID="btnFin" runat="server" 
                                    Text="ACEPTAR" onclick="btnFin_Click">
                                </telerik:RadButton>
                            </div>
                        </td>

                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>
