using System;
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

public partial class IncidenciaEvolucionGrid : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    Dispositivo dispositivo = null;
    Incidencia incidencia = null;
    IncidenciaEvolucion incidenciaEvolucion = null;
    Programa programa = null;
   //IncidenciaEvolucion IncidenciaEvolucion = null;
    bool crear = true;
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "IncidenciaGrid", ctx);
        //usuario.GrupoTrabajo = CntLainsaSci.GetGrupoTrabajo(1, ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        CntWinWeb.TranslateRadGridFilters(RadGrid1);
        if (Request.QueryString["InTab"] != null)
            mode = Request.QueryString["InTab"];
        if (Request.QueryString["Caller"] != null)
            caller = Request.QueryString["Caller"];
        if (Request.QueryString["IncidenciaId"] != null)
        {
            incidencia = CntLainsaSci.GetIncidencia(int.Parse(Request.QueryString["IncidenciaId"]), ctx);
        }
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["IncidenciaEvolucionGrid"] = null;
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
            if (crear)
                img.Visible = permiso.Crear;
            else
                img.Visible = false;
            if (incidencia != null)
            {
                img.OnClientClick = String.Format("newIncidenciaEvolucion('{0}');", incidencia.IncidenciaId);
            }
            // si la incidencia está cerrada no se pueden anotar evoluciones.
            if (incidencia != null && !CntLainsaSci.FechaNula(incidencia.FechaCierre))
            {
                img.Visible = false;
            }
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string jCommand = "";
            GridDataItem item = (GridDataItem)e.Item;
            string strKey = item.GetDataKeyValue("IncidenciaEvolucionId").ToString();
            IncidenciaEvolucion incidenciaEvolucion = CntLainsaSci.GetIncidenciaEvolucion(int.Parse(strKey), ctx);

            if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaEvolucion"].Text)))
            {
                item["FechaEvolucion"].Text = "";
            }
            // when it returns from form with new record
            if (Session["NewRecordId"] != null)
            {
                if (strKey == Session["NewRecordId"] as String)
                {
                    item.Selected = true;
                    Session["NewRecordId"] = null;
                }
            }
            
            // in order to assign the appropiate javascript function to select button
            imgb = (ImageButton)item.FindControl("Select");
            //jCommand = String.Format("returnValues3('{0}','{1}','{2}');", strKey, item["Nombre"].Text,"IncidenciaEvolucion");
            //imgb.OnClientClick = jCommand;
            //if (mode == "S")
            //    imgb.Visible = true;
            //else
            imgb.Visible = false;

            // assign the appropiate javascript function to edit button
            imgb = (ImageButton)item.FindControl("Edit");
            jCommand = String.Format("editIncidenciaEvolucion({0});", strKey);
            imgb.OnClientClick = jCommand;
            imgb.Visible = permiso.Ver;
            // assign to delete button (not needed by now)
            imgb = (ImageButton)item.FindControl("Delete");
            jCommand = String.Format("return radconfirm('{0}',event,300,100,'','{1}');", Resources.ResourceLainsaSci.DeleteRecordQuestion + " " + item["IncidenciaEvolucionId"].Text, Resources.ResourceLainsaSci.DeleteRecord);
            imgb.OnClientClick = jCommand;
            imgb.Visible = permiso.Crear;
            // si la incidencia está cerrada no se pueden eliminar evoluciones.
            if (incidencia != null && !CntLainsaSci.FechaNula(incidencia.FechaCierre))
            {
                imgb.Visible = false;
            }
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
            if (imgb.ID != "New" && imgb.ID != "Exit" && imgb.ID != "Generar")
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
                        IncidenciaEvolucion incidenciaEvolucion = CntLainsaSci.GetIncidenciaEvolucion(id, ctx);
                        CntLainsaSci.CTXEliminar(incidenciaEvolucion, ctx);
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
        if (incidencia != null)
            RadGrid1.DataSource = incidencia.IncidenciaEvolucions;
        if (rebind)
            RadGrid1.Rebind();
    }
    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "check")
        {
        }
        else
        {
            //if (e.Argument == "new")
            //    RadGrid1.CurrentPageIndex = RadGrid1.PageCount - 1;
            RefreshGrid(true);
            RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
        }
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
}