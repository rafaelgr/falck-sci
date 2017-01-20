using System;
using Telerik.OpenAccess;
using DosimetriaModelo;
using DosimetriaWinWeb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class AccesorioGrid : System.Web.UI.Page
{
    #region Global variables declaration
    Dosimetria ctx; // openaccess context used in this page
    Usuario Usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    Dispositivo dispositivo=null;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (DosimetriaCTX -> web.config)
        ctx = new Dosimetria("DosimetriaCTX");
        // verify if a Usuario is logged
        Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (Usuario == null)
            Response.Redirect("Default.aspx");
        else
            Session["UsuarioId"] = Usuario.UsuarioId;
        // si llega aquí está autorizado
        permiso = CntDosimetria.GetPermiso(Usuario.GrupoUsuario, "accesoriogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        CntWinWeb.TranslateRadGridFilters(RadGrid1);
        if (Request.QueryString["InTab"] != null)
            mode = Request.QueryString["InTab"];
        if (Request.QueryString["Caller"] != null)
            caller = Request.QueryString["Caller"];
        if (Request.QueryString["DispositivoId"] != null)
        {
            dispositivo = CntDosimetria.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
            
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
        //Session["AccesorioGrid"] = null;
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
            if (dispositivo != null)
            {
                img.OnClientClick = String.Format("newAccesorioFromDispositivo('{0}');", dispositivo.DispositivoId);
            }
            if (mode.Equals("S"))
            {
                img = (ImageButton)item.FindControl("Exit");
                img.Visible = false;
            }
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string jCommand = "";
            GridDataItem item = (GridDataItem)e.Item;
            string strKey = item.GetDataKeyValue("AccesorioId").ToString();
            
            // when it returns from form with new record
            if (Session["NewRecordId"] != null)
            {
                if (strKey == Session["NewRecordId"] as String)
                {
                    item.Selected = true;
                    Session["NewRecordId"] = null;
                }
            }

            imgb = (ImageButton)item.FindControl("Select");
            jCommand = String.Format("returnValues2('{0}','{1}');", strKey, item["Descripcion"].Text);
            imgb.OnClientClick = jCommand;
            if (caller =="AccesorioAsignadoForm")
                imgb.Visible = true;


            // assign the appropiate javascript function to edit button
            imgb = (ImageButton)item.FindControl("Edit");
            if (mode == "S")
            {
                imgb.Visible = false;
            }
            else
            {
                jCommand = String.Format("editAccesorio({0});", strKey);
                if (dispositivo != null)
                    jCommand = String.Format("editAccesorioFromDispositivo({0});", strKey);
                imgb.OnClientClick = jCommand;
                imgb.Visible = permiso.Ver;
            }

            // assign to delete button (not needed by now)
            imgb = (ImageButton)item.FindControl("Delete");
            jCommand = String.Format("return radconfirm('{0}',event,300,100,'','{1}');", Resources.ResourceDosimetria.DeleteRecordQuestion + " " + item["Descripcion"].Text, Resources.ResourceDosimetria.DeleteRecord);
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
            if (imgb.ID != "New" && imgb.ID != "Exit" && imgb.ID != "Search")
                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            switch (imgb.ID)
            {
                case "Select":
                   // dispositivo.AccesorioAsignados.Accesorios.Add(CntDosimetria.GetAccesorio(id, ctx));
                   // CntDosimetria.CTXGuardar(ctx);
                   // RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');"
                   //, caller));
                   break;
                case "Edit":
                    break;
                case "Delete":
                    try
                    {
                        Accesorio accesorio = CntDosimetria.GetAccesorio(id, ctx);
                        if (dispositivo != null)
                        {
                            AccesorioAsignado accAsignado = CntDosimetria.getAccesorioAsignado(dispositivo, accesorio);
                            CntDosimetria.CTXEliminar(accAsignado, ctx);
                        }
                        else
                            CntDosimetria.CTXEliminar(accesorio, ctx);
                        CntDosimetria.CTXGuardar(ctx);
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
        if (mode.Equals("S") && dispositivo!=null)
            RadGrid1.DataSource = CntDosimetria.getAccesorios(dispositivo, ctx);
        else
            RadGrid1.DataSource = CntDosimetria.GetAccesorios(ctx);

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
        eC.ErrorUsuario = Usuario;
        eC.ErrorProcess = permiso.Proceso;
        eC.ErrorDateTime = DateTime.Now;
        eC.ErrorException = ex;
        Session["ErrorControl"] = eC;
        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
    }
}