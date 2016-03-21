<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeloTerminalGrid.aspx.cs"
    Inherits="LainsaSciWinWeb.ModeloTerminalGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Exportación de terminal </title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
    <link href="LainsaSciEstilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #Progreso
        {
            height: 241px;
        }
    </style>
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
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GridForm.js">
            //Put your JavaScript code here.
        </script>
        <script type="text/javascript">
            function refreshGrid(arg) {
                $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
            }
            function OnClientProgressStartedHandler(sender, e) {
                alert("entrando en el evento");
                var modalPopupBehavior = $find('ModalPopupExtender1');
                modalPopupBehavior.show();
            }
        </script>
    </telerik:RadCodeBlock>
    <%--   <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1"
        Width="100%">--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" Skin="Simple">
    </telerik:RadSkinManager>
    <div id="MainArea" class="normalText">
        <%--Zona de título--%>
        <div id="Titulo" class="tituloWindow">
            <asp:Label ID="lblTítulo" runat="server" Text="Exportación de empresa"></asp:Label>
        </div>
        <%--Zona de campos--%>
        <div id="FechaInicial" class="conMargen" style="float: left;">
            <asp:Label ID="lblEmpresa" runat="server" CssClass="normalText" Text="Seleccione una empresa:"></asp:Label>
            <br />
            <telerik:RadComboBox runat="server" ID="rdcEmpresa" Height="100px" Width="300px"
                ItemsPerRequest="10" EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="rdcEmpresa_SelectedIndexChanged">
            </telerik:RadComboBox>
            <br />
            <asp:RequiredFieldValidator ID="valFecha" runat="server" Display="Dynamic" ControlToValidate="rdcEmpresa"
                CssClass="normalTextRed" ErrorMessage="Se necesita una  empresa" Type="String">
            </asp:RequiredFieldValidator>
        </div>
        <div id="Salir" class="conMargen" style="float: right">
            <telerik:RadButton ID="btnSalir" runat="server" Text="Salir" CausesValidation="false"
                OnClick="btnSalir_Click">
            </telerik:RadButton>
        </div>
        <div id="Lanzador" class="conMargen" style="float: right">
            <telerik:RadButton ID="btnLanzador" runat="server" Text="Exportar" OnClick="btnLanzador_Click">
            </telerik:RadButton>
        </div>
        <div id="Div1" style="clear: both; height: 1px">
        </div>
        <div id="AreaGrid">
            <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowFilteringByColumn="True"
                AllowSorting="True" ShowGroupPanel="True" AllowMultiRowSelection="true" OnItemDataBound="RadGrid1_ItemDataBound"
                OnPreRender="RadGrid1_PreRender" OnNeedDataSource="RadGrid1_NeedDataSource" GridLines="None"
                Skin="Simple" OnPageIndexChanged="RadGrid1_PageIndexChanged" Culture="(Default)"
                PageSize="5">
                <GroupingSettings CaseSensitive="False" />
                <ClientSettings AllowDragToGroup="True">
                </ClientSettings>
                <MasterTableView ClientDataKeyNames="ProgramaId" AutoGenerateColumns="False" DataKeyNames="ProgramaId">
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <SortExpressions>
                        <telerik:GridSortExpression FieldName="FechaProgramada" SortOrder="Ascending" />
                    </SortExpressions>
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" AllowFiltering="False">
                            <HeaderTemplate>
                                <asp:CheckBox ID="headerChkbox" OnCheckedChanged="ToggleSelectedState" AutoPostBack="True"
                                    runat="server"></asp:CheckBox>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" OnCheckedChanged="ToggleRowSelection" AutoPostBack="True"
                                    runat="server"></asp:CheckBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="ProgramaId" DataType="System.Int32" FilterControlToolTip="Filtrar por ID"
                            FilterImageToolTip="Filtro" HeaderText="Nro. Programa" ReadOnly="True" Visible="true"
                            SortExpression="ProgramaId" UniqueName="ProgramaId">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Usuario.Nombre" FilterControlToolTip="Filtrar por nombre"
                            FilterImageToolTip="Filtro" HeaderText="Usuario" ReadOnly="True" SortExpression="Usuario.Nombre"
                            UniqueName="Usuario.Nombre">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FechaProgramada" FilterControlToolTip="Filtrar por fecha programada"
                            FilterImageToolTip="Filtro" HeaderText="Fecha programada" DataType="System.DateTime"
                            DataFormatString="{0:dd/MM/yyyy}" ReadOnly="True" SortExpression="FechaProgramada"
                            UniqueName="FechaProgramada">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Estado" FilterControlToolTip="Filtrar por estado"
                            FilterImageToolTip="Filtro" HeaderText="Estado" ReadOnly="True" SortExpression="Estado"
                            UniqueName="Estado">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Comentarios" FilterControlToolTip="Filtrar por código AX"
                            FilterImageToolTip="Filtro" HeaderText="Comentarios" ReadOnly="True" SortExpression="Comentarios"
                            UniqueName="Comentarios">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Simple">
                </HeaderContextMenu>
            </telerik:RadGrid>
        </div>
        <div id="Dummy2" style="clear: both; height: 1px; margin-right: 4px;">
        </div>
        <div id="Progreso">
            <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />
            <asp:Panel ID="panel1" runat="server">
                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Width="100%" ProgressIndicators="TotalProgressBar, TotalProgress, TotalProgressPercent, RequestSize, FilesCountBar, FilesCount, FilesCountPercent, SelectedFilesCount, CurrentFileName, TimeElapsed"
                    Height="202px" DisplayCancelButton="False">
                    <Localization Uploaded="Procesado" Cancel="Cancelar"></Localization>
                </telerik:RadProgressArea>
            </asp:Panel>
        </div>
        <%--<div id="Progreso">
            <telerik:RadProgressManager ID="RadProgressManager1" runat="server" OnClientProgressStarted="OnClientProgressStartedHandler" />
            <asp:Panel ID="panel1" runat="server">
                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Width="100%" ProgressIndicators="TotalProgressBar, TotalProgress, TotalProgressPercent, RequestSize, FilesCountBar, FilesCount, FilesCountPercent, SelectedFilesCount, CurrentFileName, TimeElapsed"
                    Height="202px" DisplayCancelButton="False">
                    <Localization Uploaded="Procesado" Cancel="Cancelar"></Localization>
                </telerik:RadProgressArea>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="hiddenTargetControlForModalPopup"
                PopupControlID="panel1" runat="server">
            </cc1:ModalPopupExtender>
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
        </div>--%>
    </div>
    <div id="FooterArea">
        <telerik:RadNotification ID="RadNotification1" runat="server" ContentIcon="images/warning_32.png"
            AutoCloseDelay="0" TitleIcon="images/warning_16.png" EnableRoundedCorners="True"
            EnableShadow="True" Height="158px" Position="Center" Title="WARNING" Width="302px">
        </telerik:RadNotification>
    </div>
    <%-- </telerik:RadAjaxPanel>--%>
    </form>
</body>
</html>
