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

public partial class RevisionGrid : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    Dispositivo dispositivo = null;
    Programa programa = null;
   //Revision revision = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "dispositivogrid", ctx);
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
        if (Request.QueryString["DispositivoId"] != null)
        {
            dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
            if (dispositivo != null)
            {
                RadGrid1.Columns.FindByDataField("dispositivo.Nombre").Visible = false;
            }
        }
        if (Request.QueryString["ProgramaId"] != null)
        {
            programa = CntLainsaSci.GetPrograma(int.Parse(Request.QueryString["ProgramaId"]), ctx);
            if (programa != null)
            {
                // Modificar la altura del grid para que quepan otros
                RadGrid1.PageSize = 7;
                RadGrid1.ShowGroupPanel = false;
            }
        }
        if (Request.QueryString["InFrame"] != null)
        {
            if (Request.QueryString["InFrame"] == "S")
            {
                crear = false;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (RadGrid1.MasterTableView.SortExpressions.Count == 0)
            {
                GridSortExpression expression = new GridSortExpression();
                expression.FieldName = "FechaProgramada";
                expression.SortOrder = GridSortOrder.Ascending;
                RadGrid1.MasterTableView.SortExpressions.AddSortExpression(expression);
            }
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["RevisionGrid"] = null;
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
            if (dispositivo != null)
            {
                img.OnClientClick = String.Format("newRevisionFromDispositivo('{0}');", dispositivo.DispositivoId);
            }
            if (mode.Equals("S"))
            {
                img = (ImageButton)item.FindControl("Exit");
                img.Visible = false;
            }
            img = (ImageButton)item.FindControl("Generar");
            if (img != null && dispositivo == null)
                img.Visible = false;

            img = (ImageButton)item.FindControl("Exit");
            if (!crear)
                img.Visible = false;
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string jCommand = "";
            GridDataItem item = (GridDataItem)e.Item;
            string strKey = item.GetDataKeyValue("RevisionId").ToString();
            Revision revision = CntLainsaSci.GetRevision(int.Parse(strKey), ctx);

            if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaRevision"].Text)))
            {
                item["FechaRevision"].Text = "";
            }
            if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaProgramada"].Text)))
            {
                item["FechaProgramada"].Text = "";
            }
            if (item["CaduProx"].Text == "True")
            {
                item.BackColor = System.Drawing.Color.DeepPink;
            }
            if (item["PlantillaRevision.NoPeriodica"].Text == "True")
            {
                item.BackColor = System.Drawing.Color.LightBlue;
            }

            //item["dispositivo"].Text = revision.PlanificacionRevision.dispositivo.Nombre;
            //item["PlantillaRevision"].Text=revision.PlanificacionRevision.PlantillaRevision.Descripcion;
            //item["FechaProgramada"].Text = String.Format("{0:dd/MM/yyyy}", revision.FechaProgramada);
            
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
            //jCommand = String.Format("returnValues3('{0}','{1}','{2}');", strKey, item["Nombre"].Text,"Revision");
            //imgb.OnClientClick = jCommand;
            //if (mode == "S")
            //    imgb.Visible = true;
            //else
            imgb.Visible = false;

            // assign the appropiate javascript function to edit button
            imgb = (ImageButton)item.FindControl("Edit");
            if (revision.Estado == CntLainsaSci.EstadoRevision.Planificada.ToString())
                imgb.Visible = false;
            else
            {
                jCommand = String.Format("editRevision({0});", strKey);
                if (dispositivo != null)
                    jCommand = String.Format("editRevisionFromDispositivo({0},{1});", strKey, dispositivo.DispositivoId);
                imgb.OnClientClick = jCommand;
                imgb.Visible = permiso.Ver;
            }
            // assign to delete button (not needed by now)
            imgb = (ImageButton)item.FindControl("Delete");
            jCommand = String.Format("return radconfirm('{0}',event,300,100,'','{1}');", Resources.ResourceLainsaSci.DeleteRecordQuestion + " " + item["RevisionId"].Text, Resources.ResourceLainsaSci.DeleteRecord);
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
                        Revision revision = CntLainsaSci.GetRevision(id, ctx);
                        //PlanificacionRevision plan = revision.PlanificacionRevision;
                        //plan.Revisions.Remove(revision);
                        foreach (DatosRevision item in revision.DatosRevisions)
                        {
                            CntLainsaSci.CTXEliminar(item, ctx);
                        }
                        CntLainsaSci.CTXEliminar(revision, ctx);
                        //plan.FechaUltimaRevision = CntLainsaSci.GetFUltimarevision(plan, ctx);
                        CntLainsaSci.CTXGuardar(ctx);
                       
                        RefreshGrid(true);
                    }
                    catch (Exception ex)
                    {
                        ControlDeError(ex);
                    }
                    break;
                case "Generar":
                    CntLainsaSci.ProgramarRevisiones(dispositivo, ctx);
                    RefreshGrid(true);
                    break;
            }
        }
    }
    #endregion
    #region Auxiliary 
    protected void RefreshGrid(bool rebind)
    {
        if (dispositivo != null)
            RadGrid1.DataSource = dispositivo.Revisiones;
        else
        {
            if (usuario == null)
                RadGrid1.DataSource = CntLainsaSci.GetRevisiones(ctx);
            else
            {
                if (programa != null)
                    RadGrid1.DataSource = programa.Revisions;
                else if(usuario.GrupoTrabajo != null)
                     RadGrid1.DataSource = CntLainsaSci.GetRevisiones(usuario, usuario.GrupoTrabajo, ctx);
                else
                    RadGrid1.DataSource = CntLainsaSci.GetRevisiones(usuario, ctx);
            }
       }

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