<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CampoSN.ascx.cs" Inherits="LainsaSciWinWeb.CampoSN" %>
<link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
<div id="Marco" class="areaCampo">
  <div id="Nombre">
    <asp:Label ID="lblNombre" runat="server" Text="Campo OK/MAL:"></asp:Label>
    <br />
    <asp:CheckBox ID="chkValor" runat="server" />
  </div>
  <div id="Comentario">
    <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label>
    <br />
    <telerik:RadTextBox ID="txtComentario" runat="server" TextMode="MultiLine" Width="100%">
    </telerik:RadTextBox>
  </div>
</div>