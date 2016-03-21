<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CampoTetra.ascx.cs" Inherits="LainsaSciWinWeb.CampoTetra" %>
<link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
<div id="Marco" class="areaCampo">
  <div id="Nombre">
    <asp:Label ID="lblNombre" runat="server" Text="Campo S/N:"></asp:Label>
    <br />
      <asp:RadioButtonList ID="rdbLista" runat="server">
          <asp:ListItem Value="S">Si</asp:ListItem>
          <asp:ListItem Value="N">No</asp:ListItem>
          <asp:ListItem Value="NA">No aplica</asp:ListItem>
      </asp:RadioButtonList>
  </div>
  <div id="Comentario">
    <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label>
    <br />
    <telerik:RadTextBox ID="txtComentario" runat="server" TextMode="MultiLine" Width="100%">
    </telerik:RadTextBox>
  </div>
</div>