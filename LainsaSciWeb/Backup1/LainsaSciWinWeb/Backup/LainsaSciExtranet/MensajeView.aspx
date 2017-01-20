<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MensajeView.aspx.cs" Inherits="MensajeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciExtranetEstilos.css" rel="stylesheet" type="text/css" />
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
      <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Windows7">
      </telerik:RadSkinManager>
	<div>
    <table width="100%">
    <tr>
    <td>
        <div id="Titulo" class="txtNormal">
            <asp:Label ID="lblT1" runat="server" Text="Titulo:" CssClass="txtTitulo" Width="100%"></asp:Label>
            <br />
            <asp:Label ID="lblT2" runat="server" CssClass="txtNormalGrande"></asp:Label>
        </div>
    </td>
    </tr>
    <tr>
    <td>
        <div id="Cuerpo">
            <asp:Label ID="lblM1" runat="server" Text="Mensaje:" CssClass="txtTitulo" Width="100%"></asp:Label>
            <br />
            <asp:Label ID="lblM2" runat="server"></asp:Label>
        </div>
    </td>
    </tr>
    </table>

	</div>
	</form>
</body>
</html>
