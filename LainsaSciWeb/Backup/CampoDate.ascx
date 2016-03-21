<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CampoDate.ascx.cs" Inherits="LainsaSciWinWeb.CampoDate" %>
<link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
<div id="Marco" class="areaCampo">
  <div id="Nombre">
    <asp:Label ID="lblNombre" runat="server" Text="Campo S/N:"></asp:Label>
    <br />
      <telerik:RadDatePicker ID="txtValor" runat="server">
      </telerik:RadDatePicker>
  </div>
  <div id="Comentario">
    <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label>
    <br />
    <telerik:RadTextBox ID="txtComentario" runat="server" TextMode="MultiLine" Width="100%">
    </telerik:RadTextBox>
  </div>
</div>