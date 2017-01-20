<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramacionExe.aspx.cs" Inherits="ProgramacionExe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Ejecutar una programación
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
                <script type="text/javascript" src="GridForm.js">
                    //Put your JavaScript code here.
                </script>
                <script type="text/javascript">
                    function noHaceNada() {
                    }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadSkinManager ID="RadSkinManager1" runat="server"></telerik:RadSkinManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="rdcInforme" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" Width="100%">
                <div id="MainArea" class="normalText">
                    <%--Zona de título--%>
                    <div id="Titulo" class="tituloWindow">
                        <asp:Label ID="lblTítulo" runat="server" Text="Programación de informes"></asp:Label>
                    </div>

                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
                            MultiPageID="RadMultiPage1" SelectedIndex="0">
                            <Tabs>
                                <telerik:RadTab runat="server" Text="P1" PageViewID="RadPageView1" Selected="true">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="P2" PageViewID="RadPageView2" Visible="false">
                                </telerik:RadTab>
                                <telerik:RadTab runat="server" Text="P3" PageViewID="RadPageView3" Visible="false">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>

                          <%--Zona de campos--%>
                            <div id="FechaInicial" class="conMargen" style="float:left; "> 
                                <asp:Label ID="lblFecha" runat="server" CssClass="normalText" Text="Fecha de referencia:"></asp:Label>
                                <br />
                                <telerik:RadDatePicker ID="rdtFecha" runat="server" TabIndex="4"></telerik:RadDatePicker>
                                <br />
                                <asp:RequiredFieldValidator ID="valFecha" runat="server" Display="Dynamic" 
                                                            ControlToValidate="rdtFecha" CssClass="normalTextRed"
                                                            ErrorMessage="Se necesita una fecha">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div id="Salir" class="conMargen" style="float:right">
                                <telerik:RadButton ID="btnSalir" runat="server" Text="Salir" CausesValidation="false" 
                                                   onclick="btnSalir_Click">
                                </telerik:RadButton>
                            </div> 
                            <div id="Lanzador" class="conMargen" style="float:right">
                                <telerik:RadButton ID="btnLanzador" runat="server" Text="Ejecutar programación" 
                                                   onclick="btnLanzador_Click">
                                </telerik:RadButton>
                            </div>

                            <div id="Dummy2" style="clear:both; height:81px">
                                <asp:Label ID="lblFiltros" runat="server" CssClass="normalText" Text="Filtros:"></asp:Label>
                                <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" Culture="es-ES" 
                                                 GridLines="None" onneeddatasource="RadGrid1_NeedDataSource1">
                                    <MasterTableView AutoGenerateColumns="False">

                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                                                            Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                                              Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Nombre" 
                                                                     FilterControlAltText="Filter Nombre column" HeaderText="Nombre" 
                                                                     SortExpression="Nombre" UniqueName="Nombre">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tipo" 
                                                                     FilterControlAltText="Filter Tipo column" HeaderText="Tipo" 
                                                                     SortExpression="Tipo" UniqueName="Tipo">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>

                            </div>
                            <div id="Progreso">
                                <telerik:RadProgressManager ID="RadProgressManager1" Runat="server" />
                                <telerik:RadProgressArea ID="RadProgressArea1" runat="server" Width="100%">
                                    <Localization Cancel="Cancelar" ElapsedTime="Tiempo transcurrido: " 
                                                  EstimatedTime="Tiempo estimado: " Uploaded="Procesado" />
                                </telerik:RadProgressArea>
                            </div>                             
  


                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="RadPageView1" runat="server">
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <asp:Panel ID="Panel1" runat="server" Visible = "true">
                                <div >  

                                    <telerik:RadFilter runat="server" ID="RadFilter1" FilterContainerID="ConsRev" 
                                                       Visible ="True">
                                    </telerik:RadFilter>
                                    <telerik:RadFilter runat="server" ID="RadFilter2" FilterContainerID="ConsDisp" 
                                                       Visible ="True">
                                    </telerik:RadFilter>

                                </div>
                                <div id="Consultas">
                                    <telerik:RadGrid ID="ConsRev" runat="server" 
                                                     onneeddatasource="ConsRev_NeedDataSource" 
                                                     onitemdatabound="ConsRev_ItemDataBound">

                                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                                                         DataKeyNames="RevisionId">
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="RevisionId" DataType="System.Int32" 
                                                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro" 
                                                                         HeaderText="ID" ReadOnly="True" SortExpression="RevisionId" 
                                                                         UniqueName="RevisionId">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Dispositivo.Nombre" 
                                                                         FilterControlToolTip="Filtrar por dispositivo" FilterImageToolTip="Filtro" 
                                                                         HeaderText="Dispositivo" ReadOnly="True" SortExpression="Dispositivo.Nombre" 
                                                                         UniqueName="Dispositivo">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Dispositivo.NumeroIndustria" 
                                                                         FilterControlToolTip="Filtrar por numero industria" FilterImageToolTip="Filtro" 
                                                                         HeaderText="Numero industria" ReadOnly="True" 
                                                                         SortExpression="Dispositivo.NumeroIndustria" UniqueName="NumeroIndustria">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Dispositivo.TipoDispositivo.Nombre" 
                                                                         FilterControlToolTip="Filtrar por tipo de dispositivo" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Tipo dispositivo" ReadOnly="True" 
                                                                         SortExpression="Dispositivo.TipoDispositivo.Nombre" 
                                                                         UniqueName="Dispositivo.TipoDispositivo.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Dispositivo.ModeloDispositivo.Nombre" 
                                                                         FilterControlToolTip="Filtrar por modelo de dispositivo" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Modelo dispositivo" ReadOnly="True" 
                                                                         SortExpression="Dispositivo.ModeloDispositivo.Nombre" 
                                                                         UniqueName="Dispositivo.ModeloDispositivo.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="PlantillaRevision.Descripcion" 
                                                                         FilterControlToolTip="Filtrar por plantilla de revision" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Plantilla de revisión" ReadOnly="True" 
                                                                         SortExpression="PlantillaRevision.Descripcion" UniqueName="PlantillaRevision">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Empresa.Nombre" 
                                                                         FilterControlToolTip="Filtrar por plantilla de revision" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Empresa" ReadOnly="True" 
                                                                         SortExpression="Dispositivo.Instalacion.Empresa.Nombre" 
                                                                         UniqueName="Dispositivo.Instalacion.Empresa.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Dispositivo.Instalacion.Nombre" 
                                                                         FilterControlToolTip="Filtrar por plantilla de revision" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Instalacion" ReadOnly="True" 
                                                                         SortExpression="Dispositivo.Instalacion.Nombre" 
                                                                         UniqueName="Dispositivo.Instalacion.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaPlanificada" 
                                                                         DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" 
                                                                         FilterControlToolTip="Filtrar por fecha planificada" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Fecha planificada" ReadOnly="True" 
                                                                         SortExpression="FechaPlanificada" UniqueName="FechaPlanificada">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaProgramada" 
                                                                         DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" 
                                                                         FilterControlToolTip="Filtrar por fecha programada" FilterImageToolTip="Filtro" 
                                                                         HeaderText="Fecha programada" ReadOnly="True" SortExpression="FechaProgramada" 
                                                                         UniqueName="FechaProgramada">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaRevision" 
                                                                         DataFormatString="{0:dd/MM/yyyy}" DataType="System.DateTime" 
                                                                         FilterControlToolTip="Filtrar por fecha de revisión" 
                                                                         FilterImageToolTip="Filtro" HeaderText="Fecha de revisión" ReadOnly="True" 
                                                                         SortExpression="FechaRevision" UniqueName="FechaRevision">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Resultado" 
                                                                         FilterControlToolTip="Filtrar por resultado" FilterImageToolTip="Filtro" 
                                                                         HeaderText="Resultado" ReadOnly="True" SortExpression="Resultado" 
                                                                         UniqueName="Resultado">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Estado" 
                                                                         FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro" 
                                                                         HeaderText="Estado" ReadOnly="True" SortExpression="Estado" UniqueName="Estado">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="CaduProx" 
                                                                         FilterControlToolTip="Filtrar por estado" FilterImageToolTip="Filtro" 
                                                                         HeaderText="Caducidad proxima" ReadOnly="True" SortExpression="CaduProx" 
                                                                         UniqueName="CaduProx" Visible="false">
                                                </telerik:GridBoundColumn>

                                            </Columns>
                                        </MasterTableView>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>

                                    </telerik:RadGrid>
                                    <telerik:RadGrid ID="ConsDisp" runat="server" onneeddatasource="ConsDisp_NeedDataSource" 
                                                     Visible="True">

                                        <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                                                         DataKeyNames="DispositivoId">
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="DispositivoId" DataType="System.Int32" 
                                                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                                                         HeaderText="ID" 
                                                                         ReadOnly="True" Visible="false" 
                                                                         SortExpression="DispositivoId" UniqueName="DispositivoId">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Nombre" 
                                                                         FilterControlToolTip="Filtrar por nombre" FilterImageToolTip="Filtro"
                                                                         HeaderText="Nombre" 
                                                                         ReadOnly="True" 
                                                                         SortExpression="Nombre" UniqueName="Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="NumeroIndustria" 
                                                                         FilterControlToolTip="Filtrar por número de industria" FilterImageToolTip="Filtro"
                                                                         HeaderText="Numero de industria" 
                                                                         ReadOnly="True" 
                                                                         SortExpression="NumeroIndustria" UniqueName="NumeroIndustria">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Instalacion.Empresa.Nombre" 
                                                                         FilterControlToolTip="Filtrar por cliente" FilterImageToolTip="Filtro"
                                                                         HeaderText="Cliente" 
                                                                         ReadOnly="True" 
                                                                         SortExpression="Instalacion.Empresa.Nombre" UniqueName="Instalacion.Empresa.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Instalacion.Nombre" 
                                                                         FilterControlToolTip="Filtrar por instalación" FilterImageToolTip="Filtro"
                                                                         HeaderText="Instalación" 
                                                                         ReadOnly="True" 
                                                                         SortExpression="Instalacion.Nombre" UniqueName="Instalacion.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="TipoDispositivo.Nombre" 
                                                                         FilterControlToolTip="Filtrar por modelo" FilterImageToolTip="Filtro"
                                                                         HeaderText="Tipo" 
                                                                         ReadOnly="True" 
                                                                         SortExpression="TipoDispositivo.Nombre" UniqueName="TipoDispositivo.Nombre">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Posicion" 
                                                                         FilterControlToolTip="Filtrar por instalación" FilterImageToolTip="Filtro"
                                                                         HeaderText="Ubicación" 
                                                                         ReadOnly="True" 
                                                                         SortExpression="Posicion" UniqueName="Posicion">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="FechaCaducidad" 
                                                                         FilterControlToolTip="Filtrar por la fecha de caducidad" FilterImageToolTip="Filtro"
                                                                         HeaderText="Fecha de caducidad" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}"
                                                                         ReadOnly="True" 
                                                                         SortExpression="FechaCaducidad" UniqueName="FechaCaducidad">
                                                </telerik:GridBoundColumn>

                                                <telerik:GridBoundColumn DataField="Caducado" 
                                                                         FilterControlToolTip="Filtrar por cliente" FilterImageToolTip="Filtro"
                                                                         HeaderText="Caducado" 
                                                                         ReadOnly="True" Visible="false" 
                                                                         SortExpression="Caducado" UniqueName="Caducado">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                                                            UniqueName="Template">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Edit" runat="server" 
                                                                         ImageUrl="~/images/document_edit_16.png"
                                                                         ToolTip="Ver este registro" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                    </telerik:RadGrid>

                                </div>
                            </asp:Panel>                            
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView3" runat="server">
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>


                </div>

            </telerik:RadAjaxPanel>

        </form>
    </body>
</html>
