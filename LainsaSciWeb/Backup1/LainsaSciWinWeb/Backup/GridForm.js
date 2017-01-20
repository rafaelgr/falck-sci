/*
GridForm.js
Author: Rafael Garcia
Copyright: Ariadna Software S.L.
-------------------------------------------------------------------------------------
First update: 2011-07-28
(*) GetRadWindow
it takes the current window
(*) openOutSide(name)
it opens the ID = name window, outside the current one.
-------------------------------------------------------------------------------------
*/
function noHaceNada() { }
// gup stands from Get Url Parameters
function gup(name)
{
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}

//function refreshGrid2(arg, frame) {
//    // search for the iframe
//    var iframe = document.getElementById(frame);
//    iframe.contentWindow.refreshGrid(arg);
//}

function getUrlEmpresaForm()
{
    return window.location.protocol + "://" + window.location.host + "/" + 'EmpresaForm.aspx';
}

function GetRadWindow()
{
    var oWindow = null;
    if (window.radWindow) oWindow = window.radWindow;
    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
    return oWindow;
}

function closeOpen(url, name) {
    closeWindow();
    openOutSide(url, name);
}

function openOutSide(url, name)
{
    //alert("openOutSide");
    if (gup("InFrame") == "S" || gup("InTab") == "S")
    {
        parent.openOutSide(url, name);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.openWindow(url, name);
        else
            alert("openOutSide(name): no current window");
    }
}

function closeWindow()
{
    if (gup("InTab") == "S")
    {
        parent.closeWindow();
    }
    else
    {
        var oWnd = GetRadWindow();
        //see: CntWinWeb.VisibleOnPageLoadAllWindows in code behind
        oWnd.close();
    }
}

function setWindowTitle(title)
{
    var oWnd = GetRadWindow();
    oWnd.set_title(title);
}
//function closeWindow(id)
//{
//    var oManager = GetRadWindowManager();
//    if (oManager)
//        var oWnd = oManager.GetWindowByName(id);
//    alert(id);
//    oWnd.close();
//}

function closeWindowNewRecord(caller, id)
{
    if (gup("InTab" == "S"))
    {
        parent.closeWindowNewRecord(caller, id);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callNewRecordInGrid(caller, id);
        else
            alert("closeWindowNewRecord(caller, id): no current window");
        oWnd.close();
    }
}

function closeWindowRefreshGrid(caller, arg) 
{
    if (gup("InTab") == "S") {
        if (caller == "PlantillaRevisionGridT") caller = "TipoTab";
        if (caller == "ResumenRevisionGrid") caller = "DispositivoTab";
        parent.closeWindowRefreshGrid(caller, arg);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callRefreshGrid(caller, arg);
        else
        {
            alert("closeWindowRefreshGrid(" + caller + "," + arg + "): no current window");
        }
        oWnd.close();
    }
}

function closeWindowRefreshGrid2(caller, arg, frame)
{
    if (gup("InTab") == "S") {
        if (caller == "PlantillaRevisionGrid") caller = "TipoTab";
        if (caller == "ResumenRevisionGrid") caller = "DispositivoTab";
        parent.closeWindowRefreshGrid2(caller, arg, frame);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callRefreshGrid2(caller, arg, frame);
        else
        {
            alert("closeWindowRefreshGrid2(" + caller + "," + arg + "," + frame + "): no current window");
        }
        oWnd.close();
    }
}

function callShowError(message)
{
    alert("callShowError");
    var oWnd = GetRadWindow();
    if (oWnd)
        oWnd.BrowserWindow.showError(message);
    else
        alert("callShowError(message): no current window");
}

function returnValuesGeneral(caller, values)
{
    var oWnd = GetRadWindow();
    if (oWnd)
    {
        oWnd.BrowserWindow.callLoadValues(caller, values);
        oWnd.close();
    }
    else
        alert("returnValuesGeneral(caller, values): no current window");
}

function returnValues2(v1, v2)
{
    var values = new Array();
    values[0] = v1;
    values[1] = v2;
    returnValuesGeneral(gup("Caller"), values);
}
function returnValues3(v1, v2, v3)
{
    var values = new Array();
    values[0] = v1;
    values[1] = v2;
    values[2] = v3;
    returnValuesGeneral(gup("Caller"), values);
}
function resizeWindow()
{
    var oWnd = GetRadWindow();
    if (oWnd) oWnd.autoSize();
}
function resizeIframe(id)
{
    var iframe = document.getElementById(id);
    iframe.height = iframe.document.body.scrollHeight + 2;
}
//-- Search area
function searchGrupoUsuario(caller)
{
    var oWnd = GetRadWindow();
    if (oWnd)
        oWnd.BrowserWindow.callGrupoUsuarioGrid(caller);
    else
        alert("searchGrupoUsuario(caller): no current window");
}

function searchGrupoTrabajo(caller) {
    var oWnd = GetRadWindow();
    if (oWnd)
        oWnd.BrowserWindow.callGrupoTrabajoGrid(caller);
    else
        alert("searchGrupoTrabajo(caller): no current window");
}

function searchProceso(caller)
{
    var oWnd = GetRadWindow();
    if (oWnd)
        oWnd.BrowserWindow.callProcesoGrid(caller);
    else
        alert("searchProceso(caller): no current window");
}

function searchEmpresa(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "InstalacionForm") caller = "InstalacionTab";
        if (caller == "UsuarioForm") caller = "UsuarioTab";
        if (caller == "DocumentoForm") caller = "DocumentoView";
        if (caller == "UsuarioExtranetForm") caller = "UsuarioExtranetTab";
        parent.searchEmpresa(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callEmpresaGrid(caller);
        else
            alert("searchProceso(" + caller + "): no current window");
    }
}
function searchInstalacion(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "DispositivoForm") caller = "DispositivoTab";
        if (caller == "UsuarioForm") caller = "UsuarioTab";
        if (caller == "DocumentoForm") caller = "DocumentoView";
        parent.searchInstalacion(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callInstalacionGrid(caller);
        else
            alert("searchInstalacion(" + caller + "): no current window");
    }
}
function searchTipoDispositivo(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "DispositivoForm") caller = "DispositivoTab";
        if (caller == "PlantillaRevisionForm") caller = "PlantillaRevisionTab";
        parent.searchTipoDispositivo(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callTipoDispositivoGrid(caller);
        else
            alert("searchTipoDispositivo(" + caller + "): no current window");
    }
}
function searchModeloDispositivo(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchModeloDispositivo(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callModeloDispositivoGrid(caller);
        else
            alert("searchModeloDispositivo(" + caller + "): no current window");
    }
}

function searchAccesorio(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "AccesorioForm") caller = "DispositivoTab";
        parent.searchAccesorio(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callAccesorioGrid(caller);
        else
            alert("searchAccesorio(" + caller + "): no current window");
    }
}

function searchDispositivo(caller) {
    if (gup("InTab") == "S") {
        parent.searchAccesorio(caller);
    }
    else {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callDispositivoGrid(caller);
        else
            alert("searchDispositivo(" + caller + "): no current window");
    }
}
function searchDispositivo2(caller) {
    if (gup("InTab") == "S") {
        parent.searchAccesorio(caller);
    }
    else {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callDispositivoGrid2(caller);
        else
            alert("searchDispositivo2(" + caller + "): no current window");
    }
}


function searchPlantilla(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "PlantillaGrid") caller = "PlantillaRevisionTab";
        parent.searchPlantilla(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callPlantillaGrid(caller);
        else
            alert("searchPlantilla(" + caller + "): no current window");
    }
}

function searchTipoCampo(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "PlantillaGrid") caller = "PlantillaRevisionTab";
        parent.searchTipoCampo(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callTipocampoGrid(caller);
        else
            alert("searchTipoCampo(" + caller + "): no current window");
    }
}

function searchFabricante(caller)
{
    if (gup("InTab") == "S") 
    {
        if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchFabricante(caller);
    } 
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callFabricanteGrid(caller);
        else
            alert("searchFabricante(" + caller + "): no current window");
    }
}

function searchAgenteExtintor(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchAgenteExtintor(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callAgenteExtintorGrid(caller);
        else
            alert("searchAgenteExtintor(" + caller + "): no current window");
    }
}

function searchOperario(caller)
{
    if (gup("InTab") == "S")
    {
        if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchOperario(caller);
    }
    else
    {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callUsuarioGrid(caller);
        else
            alert("searchOperario(" + caller + "): no current window");
    }
}

function searchSubcategoria(caller) {
    if (gup("InTab") == "S") {
        //if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchOperario(caller);
    }
    else {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callSubcategoriaGrid(caller);
        else
            alert("searchOperario(" + caller + "): no current window");
    }
}
function searchCategoria(caller) {
    if (gup("InTab") == "S") {
        //if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchCategoria(caller);
    }
    else {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callCategoriaGrid(caller);
        else
            alert("searchCategoria(" + caller + "): no current window");
    }
}
function searchGrupoMensajes(caller) {
    if (gup("InTab") == "S") {
        //if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchGrupoMensajes(caller);
    }
    else {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callGrupoMensajesGrid(caller);
        else
            alert("searchGrupoMensajes(" + caller + "): no current window");
    }
}
function searchTipoAnomalia(caller) {
    if (gup("InTab") == "S") {
        //if (caller == "DispositivoForm") caller = "DispositivoTab";
        parent.searchTipoAnomalia(caller);
    }
    else {
        var oWnd = GetRadWindow();
        if (oWnd)
            oWnd.BrowserWindow.callTipoAnomaliaGrid(caller);
        else
            alert("searchTipoAnomalia(" + caller + "): no current window");
    }
}

//-- End search area

