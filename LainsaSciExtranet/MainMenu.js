/*
MainMenu.js
Author: Rafael Garcia
Copyright: Ariadna Software S.L.
-------------------------------------------------------------------------------------
First update: 2011-07-28
(*) openWindow(name) 
to open de RadWindow with ID = name in RadWindowManager1
(*) callLoadValues(wName, values) 
to send values array to the ASP.NET named wName, calling LoadValues() at destination.
-------------------------------------------------------------------------------------
*/
function noHaceNada(arg) { }
function openWindow(url, name)
{
    //alert("openWindow");
    var oWnd = radopen(url, name);
    if (oWnd)
    {
        //alert("name: " + name);
        oWnd.setUrl(url);
        //windowDetails(oWnd, name);
        //oWnd.show();
        // showed window is back by default
        // this send it to front.
        window.setTimeout(function ()
                          {
                              oWnd.setActive(true);
                          }, 0);
    }
    else
    {
        alert("openWindow(name): " + name + " doesn't exists");
    }
}

function openWindowFromMenu(url, name)
{
    var oManager = GetRadWindowManager();
    if (oManager)
    {
        var oWnd = oManager.getWindowByName(name);
        if (oWnd) openWindow(url, name);
    }
}

function windowTile() 
{
    var oManager = GetRadWindowManager();
    if (oManager) 
    {
        oManager.tile();
    }
}

function windowCascade()
 {
    var oManager = GetRadWindowManager();
    if (oManager) 
    {
        oManager.cascade();
    }
}

function openMenuItem(sender, args)
{
    var itemValue = args.get_item().get_value();
    switch (itemValue) {
        case "tile":
            windowTile();
            break;
        case "cascade":
            windowCascade();
            break;
        default:
            var url = itemValue + ".aspx?Caller=MainMenu";
            openWindowFromMenu(url, itemValue);
            break;
    }
}

function callLoadValues(wName, values)
{
    // it gets the window inside the manager
    var oWnd = GetRadWindowManager().getWindowByName(wName);
    if (oWnd)
    // it calls loadValues() inside the page, inside the window
        oWnd.get_contentFrame().contentWindow.loadValues(values);
    else
    {
        alert("callLoadValues(wName,values): " + wName + " doesn't exists");
    }
}

function callNewRecordInGrid(caller, id)
{
    // it gets the window inside the manager
    var oWnd = GetRadWindowManager().getWindowByName(caller);
    if (oWnd)
    // it calls loadValues() inside the page, inside the window
        oWnd.get_contentFrame().contentWindow.newRecordInGrid(id);
    else
    {
        alert("callNewRecordInGrid(caller, id): " + wName + " doesn't exists");
    }
}

function callRefreshGrid(caller, arg) {
    // it gets the window inside the manager
    var oWnd = GetRadWindowManager().getWindowByName(caller);
    if (oWnd) {
        // it calls loadValues() inside the page, inside the window
        oWnd.get_contentFrame().contentWindow.refreshGrid(arg);
    }
    else {
        alert("callRefreshGrid(caller, arg): " + caller + " doesn't exists");
    }
}
function callRefreshGrid2(caller, arg, frame) {
    // it gets the window inside the manager
    var oWnd = GetRadWindowManager().getWindowByName(caller);
    if (oWnd) {
        // it calls loadValues() inside the page, inside the window
        oWnd.get_contentFrame().contentWindow.refreshGrid2(arg, frame);
    }
    else {
        alert("callRefreshGrid2(caller, arg, frame): " + caller + " doesn't exists");
    }
}

function callGrupoUsuarioGrid(caller)
{
    var url = "GrupoUsuarioGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "GrupoUsuarioGrid");
}
function callGrupoTrabajoGrid(caller) {
    var url = "GrupoTrabajoGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "GrupoTrabajoGrid");
}
function callCategoriaGrid(caller) {
    var url = "CategoriaGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "CategoriaGrid");
}
function callGrupoMensajesGrid(caller) {
    var url = "GrupoMensajesGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "GrupoMensajesGrid");
}
function callTipoAnomaliaGrid(caller) {
    var url = "TipoAnomaliaGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "TipoAnomaliaGrid");
}
function callProcesoGrid(caller)
{
    var url = "ProcesoGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "ProcesoGrid");
}

function callEmpresaGrid(caller) 
{
    var url = "EmpresaGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "EmpresaGrid");
}

function callInstalacionGrid(caller)
{
    var url = "InstalacionGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "InstalacionGrid");
}
function callTipoDispositivoGrid(caller) {
    var url = "TipoGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "TipoGrid");
}
function callModeloDispositivoGrid(caller) {
    var url = "ModeloGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "ModeloGrid");
}
function callAccesorioGrid(caller) {
    var url = "AccesorioGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "AccesorioGrid");
}
function callDispositivoGrid(caller) {
    var url = "DispositivoGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "DispositivoGrid");
}

function callDispositivoGrid2(caller) {
    var url = "DispositivoGrid.aspx?Caller=" + caller + "&LL=2" + "&Mode=S";
    openWindow(url, "DispositivoGrid");
}


function callOperarioGrid(caller)
{
    var url = "OperarioGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "OperarioGrid");
}
function callPlantillaGrid(caller) {
    var url = "PlantillaRevisionGrid.aspx?Caller=" + caller; // + "&Mode=S";
    openWindow(url, "PlantillaRevisionGrid");
}
function callTipocampoGrid(caller) {
    var url = "TipoCampoGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "TipoCampoGrid");
}
function callAgenteExtintorGrid(caller) {
    var url = "AgenteExtintorGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "AgenteExtintorGrid");
}
function callFabricanteGrid(caller) {
    var url = "FabricanteGrid.aspx?Caller=" + caller + "&Mode=S";
    openWindow(url, "FabricanteGrid");
}
// --------------------------------------------------------------
function windowDetails(oWnd, name)
{
    var exist = true;
    switch (name)
    {
        case "GrupoUsuarioGrid", "GrupoTrabajoGrid", "UsuarioGrid", "ProcesoGrid", "EmpresaGrid", "InstalacionGrid", "OperarioGrid":
            oWnd.setSize(850, 600);
            //oWnd.set_autoSize(true);
            //oWnd.autoSize();
            break;
        case "UsuarioForm":
            oWnd.setSize(650, 450);
            oWnd.set_modal(true);
            break;
        case "ProcesoForm":
            oWnd.setSize(300, 400);
            oWnd.set_modal(true);
            break;
        case "PermisoForm":
            oWnd.setSize(450, 300);
            oWnd.set_modal(true);
            break;
        case "ErrorForm":
            oWnd.setSize(650, 350);
            oWnd.set_modal(true);
            break;
        case "InstalacionForm", "EmpresaTabs", "OperarioTabs":
            oWnd.setSize(750, 600);
            oWnd.set_modal(true);
            break;
        case "TelefonoForm":
            oWnd.setSize(555, 245);
            oWnd.set_modal(true);
            break;
        case "DireccionForm":
            oWnd.setSize(450, 500);
            oWnd.set_modal(true);
            break;
        case "EmpresaForm":
            oWnd.setSize(900, 600);
            oWnd.set_modal(true);
            break;
        case "EmpresaTab":
            oWnd.setSize(1000, 700);
            oWnd.set_modal(true);
            break;
        case "InstalacionForm":
            oWnd.setSize(900, 600);
            oWnd.set_modal(true);
            break;
        case "InstalacionTab":
            oWnd.setSize(1000, 700);
            oWnd.set_modal(true);
            break;
        case "EmailForm":
            oWnd.setSize(500, 400);
            oWnd.set_modal(true);
            break;
        case "OperarioForm":
            oWnd.setSize(650, 400);
            oWnd.set_modal(true);
        case "PlantillaRevisionTab":
            oWnd.setSize(850, 500);
            oWnd.set_modal(true);
            break;
        case "PlantillaRevisionForm":
            oWnd.setSize(850, 450);
            oWnd.set_modal(true);
            break;
        case "ResumenRevisionForm":
            oWnd.setSize(700, 500);
            oWnd.set_modal(true);
            break;
        case "TipoTab":
            oWnd.setSize(850, 500);
            oWnd.set_modal(true);
            break;
        default:
            exist = false;
            break;
    }
    return exist;
}

//-- Window control Area
function wOnClientCommand(sender, eventArgs)
{
    //    var arg = eventArgs.get_commandName();
    //    var oWnd = sender;
    //    switch (arg) {
    //        case "Maximize":
    //            oWnd.autoSize();
    //            break;
    //    }
    //    return false;
}