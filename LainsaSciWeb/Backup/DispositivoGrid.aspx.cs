using System;
using System.Collections.Generic;
using Telerik.OpenAccess;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class DispositivoGrid : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    Instalacion instalacion;
    Dispositivo dispositivo;
    Dispositivo dispositivoOriginal;
    string LL = "";
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    string inTab = "";
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (usuario == null)
            Response.Redirect("Default.aspx");
        else
            Session["UsuarioId"] = usuario.UsuarioId;
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "dispositivogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        CntWinWeb.TranslateRadGridFilters(RadGrid1);
        if (Request.QueryString["Mode"] != null)
            mode = Request.QueryString["Mode"];

        if (Request.QueryString["InTab"] != null)
            inTab = Request.QueryString["InTab"];
        if (Request.QueryString["Caller"] != null)
            caller = Request.QueryString["Caller"];
        if (Request.QueryString["LL"] != null)
        {
            LL = "2";
            if (Session["DispositivoOriginal"] != null)
                dispositivoOriginal = (Dispositivo)Session["DispositivoOriginal"];
        }
        if (Request.QueryString["RevisionId"] != null)
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["RevisionId"]), ctx);
            if (instalacion != null)
            {
                RadGrid1.Columns.FindByDataField("Instalacion.Nombre").Visible = false;
            }
        }
        if (Request.QueryString["DispositivoId"] != null)
        {
            dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
            if (dispositivo != null)
            {
                RadGrid1.Columns.FindByDataField("Instalacion.Nombre").Visible = false;
                RadGrid1.Columns.FindByDataField("Instalacion.Empresa.Nombre").Visible = false;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["DispositivoGrid"] = null;
    }
    #endregion
    #region RadGrid events
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshGrid(false);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            GridCommandItem item = (GridCommandItem)e.Item;
            ImageButton img = (ImageButton)item.FindControl("New");
            img.Visible = permiso.Crear;
            if (instalacion != null)
            {
                img.OnClientClick = String.Format("newDispositivoFromInstalacion('{0}');", instalacion.InstalacionId);
            }

            if (dispositivo !=null) // antes mode.Equals("S")
            {
                img.OnClientClick = String.Format("newAccesorioFromDispositivo('{0}');", dispositivo.DispositivoId);

                img = (ImageButton)item.FindControl("Exit");
                img.Visible = false;
            }
            
        }
        
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string jCommand = "";
            GridDataItem item = (GridDataItem)e.Item;
            if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaCaducidad"].Text)))
            {
                item["FechaCaducidad"].Text = "";
            }

            string strKey = item.GetDataKeyValue("DispositivoId").ToString();
            
            // when it returns from form with new record
            if (Session["NewRecordId"] != null)
            {
                if (strKey == Session["NewRecordId"] as String)
                {
                    item.Selected = true;
                    Session["NewRecordId"] = null;
                }
            }
            if (item["Caducado"].Text == "True")
            {
                item.BackColor = System.Drawing.Color.DeepPink;
            }
            // in order to assign the appropiate javascript function to select button
            imgb = (ImageButton)item.FindControl("Select");
            string nomLargo = String.Format("({0}) [{3}] {1} / {2} ", item["Nombre"].Text, item["Instalacion.Empresa.Nombre"].Text, item["Instalacion.Nombre"].Text, item["ModeloDispositivo.Nombre"].Text);
            if (LL == "")
                jCommand = String.Format("returnValues3('{0}','{1}','{2}');", strKey, nomLargo,"Dispositivo");
            else
                jCommand = String.Format("returnValues3('{0}','{1}','{2}');", strKey, nomLargo, "Dispositivo2");
            imgb.OnClientClick = jCommand;
            if (caller == "RevisionNoPeriodica" && item["Operativo"].Text == "False")
               imgb.Visible = false;
            else if (mode == "S")
                imgb.Visible = true;
            else
                imgb.Visible = false;
               

            // assign the appropiate javascript function to edit button
            imgb = (ImageButton)item.FindControl("Edit");
            jCommand = String.Format("editDispositivo({0});", strKey);
            if (instalacion != null)
                jCommand = String.Format("editDispositivoFromInstalacion({0});", strKey);
            if(mode.Equals("S"))
                jCommand = String.Format("editAccesorioFromDispositivo('{0}');", strKey);
            imgb.OnClientClick = jCommand;
            imgb.Visible = permiso.Ver;

            // assign to delete button (not needed by now)
            imgb = (ImageButton)item.FindControl("Delete");
            jCommand = String.Format("return radconfirm('{0}',event,300,100,'','{1}');", Resources.ResourceLainsaSci.DeleteRecordQuestion + " " + item["DispositivoId"].Text, Resources.ResourceLainsaSci.DeleteRecord);
            imgb.OnClientClick = jCommand;
            imgb.Visible = permiso.Crear;
        }
    }

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        // we only process commands with a datasource (our image buttons)
        if (e.CommandSource == null)
            return;
        string typeOfControl = e.CommandSource.GetType().ToString();
        if (typeOfControl.Equals("System.Web.UI.WebControls.ImageButton"))
        {
            int id = 0;
            ImageButton imgb = (ImageButton)e.CommandSource;
            if (imgb.ID != "New" && imgb.ID != "Exit")
                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            switch (imgb.ID)
            {
                case "Select":
                    break;
                case "Edit":
                    break;
                case "Delete":
                    try
                    {
                        Dispositivo dispositivo = CntLainsaSci.GetDispositivo(id, ctx);
                        if (dispositivo.Revisiones != null)
                        {
                            if (dispositivo.Revisiones.Count > 0)
                            {
                                ControlDeError(new Exception(string.Format("No se puede borrar el dispositivo con ID = {0}.\nTiene revisiones asignadas.", dispositivo.DispositivoId)));
                                break;
                            }
                        }
                       
                        CntLainsaSci.BorrarDispositivo(dispositivo, ctx);
                        CntLainsaSci.CTXGuardar(ctx);
                        RefreshGrid(true);
                    }
                    catch (Exception ex)
                    {
                        ControlDeError(ex);
                    }
                    break;
            }
        }
    }
    #endregion
    #region Auxiliary 
    protected void RefreshGrid(bool rebind)
    {
        IList<Dispositivo> l = new List<Dispositivo>();
        if (dispositivo != null)
            l = dispositivo.Accesorios;
        else if (instalacion != null)
            l = instalacion.Dispositivos;
        else
        {
            if (usuario != null)
                l = CntLainsaSci.GetDispositivos(usuario, ctx);
            else
                l = CntLainsaSci.GetDispositivos(ctx);
        }
       // if (caller == "RevisionNoPeriodica")
          //  l = CntLainsaSci.Operativos(l);
        if (LL != "" && dispositivoOriginal != null)
            l = CntLainsaSci.GetPosiblesSustitutos(usuario, dispositivoOriginal, ctx);
        if (!chkCaducados.Checked) 
            l = CntLainsaSci.NoCaducados(l);
      
        RadGrid1.DataSource = l;
        if (rebind)
            RadGrid1.Rebind();

    }
    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "new")
            RadGrid1.CurrentPageIndex = RadGrid1.PageCount - 1;
        RefreshGrid(true);
        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
    }

    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
    }

    protected void ControlDeError(Exception ex)
    {
        ErrorControl eC = new ErrorControl();
        eC.ErrorUsuario = usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }

    protected void chkCaducados_CheckedChanged(object sender, EventArgs e)
    {
        RefreshGrid(true);
    }
}