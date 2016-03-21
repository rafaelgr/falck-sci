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
using System.Collections;

namespace LainsaSciWinWeb
{
    public partial class PrograrGrid : System.Web.UI.Page
    {
        #region Global variables declaration
        LainsaSci ctx; // openaccess context used in this page
        Usuario usuario; // Usuario loged
        Permiso permiso; // permisos del usuario segun su grupo
        Dispositivo dispositivo = null;
        //Revision revision = null;
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
            if (permiso == null)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
                RadNotification1.Show();
                RadAjaxManager1.ResponseScripts.Add("closeWindow();");
            }
            CntWinWeb.TranslateRadGridFilters(RadGrid1);
            if (Request.QueryString["Intab"] != null)
                mode = Request.QueryString["Intab"];
            if (Request.QueryString["Caller"] != null)
                caller = Request.QueryString["Caller"];
            if (Request.QueryString["DispositivoId"] != null)
            {
                dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
                if (dispositivo != null)
                {
                    RadGrid1.Columns.FindByDataField("PlanificacionRevision.dispositivo.Nombre").Visible = false;
                }
            }
            //Inicializamos la primera vez que entramos al grid de revisiones a programar, la variable de sesión que almacenará las revisiones seleccionadas
            if(!IsPostBack)
                Session["selectedItems"] = null;
            // control de skin
            if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
                if(RadGrid1.MasterTableView.SortExpressions.Count == 0) {
                    GridSortExpression expression = new GridSortExpression();
                    expression.FieldName = "FechaPlanificada";
                    expression.SortOrder = GridSortOrder.Descending;
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
            }
            if (e.Item is GridDataItem)
            {
                ImageButton imgb = null;
                string jCommand = "";
                GridDataItem item = (GridDataItem)e.Item;
                string strKey = item.GetDataKeyValue("RevisionId").ToString();
                Revision revision = CntLainsaSci.GetRevision(int.Parse(strKey), ctx);

                if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaPlanificada"].Text)))
                {
                    item["FechaPlanificada"].Text = "";
                }

                //item["dispositivo"].Text = revision.PlanificacionRevision.dispositivo.Nombre;
                //item["PlantillaRevision"].Text = revision.PlanificacionRevision.PlantillaRevision.Descripcion;
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
                //imgb = (ImageButton)item.FindControl("Select");
                //jCommand = String.Format("returnValues3('{0}','{1}','{2}');", strKey, item["Nombre"].Text,"Revision");
                //imgb.OnClientClick = jCommand;
                //if (mode == "S")
                //    imgb.Visible = true;
                //else
                //imgb.Visible = false;

                // assign the appropiate javascript function to edit button
                imgb = (ImageButton)item.FindControl("Edit");
                jCommand = String.Format("editRevision({0});", strKey);
                if (dispositivo != null)
                    jCommand = String.Format("editRevisionFromDispositivo({0},{1});", strKey, dispositivo.DispositivoId);
                imgb.OnClientClick = jCommand;
                imgb.Visible = permiso.Ver;
                // assign to delete button (not needed by now)
                //imgb = (ImageButton)item.FindControl("Delete");
                //jCommand = String.Format("return radconfirm('{0}',event,300,100,'','{1}');", Resources.ResourceLainsaSci.DeleteRecordQuestion + " " + item["RevisionId"].Text, Resources.ResourceLainsaSci.DeleteRecord);
                //imgb.OnClientClick = jCommand;
                //imgb.Visible = permiso.Crear;
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
                if (imgb.ID != "New" && imgb.ID != "Exit" && imgb.ID != "Program")
                    id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
                switch (imgb.ID)
                {
                    case "Select":
                        break;
                    case "Edit":
                        break;
                    case "Program":
                        bool firstTime = true;
                        Programa prog = null;
                        string jCommand = "";
                        ArrayList selectedItems = GetSelectedItems();
                        Int16 stackIndex;
                        for (stackIndex = 0; stackIndex <= selectedItems.Count - 1; stackIndex++)
                        {
                            string curItem = selectedItems[stackIndex].ToString();
                            if (firstTime)
                            {
                                // Creamos el programa
                                prog = new Programa();
                                prog.Usuario = usuario;
                                prog.Comentarios = String.Format("Programación creada el {0:dd/MM/yyyy hh:mm:ss}", DateTime.Now);
                                firstTime = false;
                            }
                            id = int.Parse(curItem);
                            Revision r = CntLainsaSci.GetRevision(id, ctx);
                            if (r != null)
                            {
                                r.Programa = prog;
                                r.Estado = "PROGRAMADA";
                                prog.Revisions.Add(r);
                                CntLainsaSci.AgruparCompanyeros(r, prog, ctx);
                                //Las revisiones de los accesorios con la misma plantilla formarán parte del nuevo Programa
                                foreach (Dispositivo d in r.Dispositivo.Accesorios)
                                    foreach (Revision rev in d.Revisiones)
                                        if (rev.PlantillaRevision.PlantillaId == r.PlantillaRevision.PlantillaId)
                                        {
                                            rev.Programa = prog;
                                            rev.Estado = "PROGRAMADA";
                                            prog.Revisions.Add(rev);
                                            CntLainsaSci.AgruparCompanyeros(rev, prog, ctx);
                                        }
                            }
                         }

                        //foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
                        //{
                        //    if (dataItem.Selected == true)
                        //    {
                        //        if (firstTime)
                        //        {
                        //            // Creamos el programa
                        //            prog = new Programa();
                        //            prog.Usuario = usuario;
                        //            prog.Comentarios = String.Format("Programación creada el {0:dd/MM/yyyy hh:mm:ss}", DateTime.Now);
                        //            firstTime = false;
                        //        }
                        //        id = (int)dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex][dataItem.OwnerTableView.DataKeyNames[0]];
                        //        Revision r = CntLainsaSci.GetRevision(id, ctx);
                        //        if (r != null)
                        //        {
                        //            r.Programa = prog;
                        //            r.Estado = "PROGRAMADA";
                        //            prog.Revisions.Add(r);
                        //            CntLainsaSci.AgruparCompanyeros(r, prog, ctx);
                        //        }
                        //    }
                        //}
                        CntLainsaSci.EliminarProgramadasInferiores(prog);
                        CntLainsaSci.ProgramarSustituciones(prog, ctx);
                        if (!CntLainsaSci.ProgramaMezclado(prog))
                        {
                            CntLainsaSci.CTXGuardar(ctx);
                            if (!firstTime)
                            {
                                //var url = "RevisionForm.aspx?Caller=ProgramarGrid&RevisionId=" + id;
                                //var name = "RevisionForm";
                                //openOutSide(url, name);
                                string url = String.Format("ProgramaForm.aspx?Caller=ProgramarGrid&ProgramaId={0}", prog.ProgramaId);
                                jCommand = String.Format("openOutSide('{0}','{1}');", url, "ProgramaForm");
                                RadAjaxManager1.ResponseScripts.Add(jCommand);
                            }
                        }
                        else
                        {
                            RadNotification1.Text = "No debe mezclar instalaciones";
                            RadNotification1.Show();
                        }
                        Session["selectedItems"] = null;
                        RefreshGrid(true);
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
                }
            }
        }

        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridDataItem dataItem = (GridDataItem)chk.NamingContainer;
            dataItem.Selected = chk.Checked;
            string revisionId = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["RevisionId"].ToString();
            ArrayList selectedItems = GetSelectedItems();
            if (chk.Checked)
                selectedItems.Add(revisionId);
            else
            {
                selectedItems.Remove(revisionId);
                dataItem.Selected = false;
               System.Drawing.Color ARG =  dataItem.BackColor;
            }
            Session["selectedItems"] = selectedItems;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            ArrayList selectedItems = GetSelectedItems();
            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = headerCheckBox.Checked;
                dataItem.Selected = headerCheckBox.Checked;
                string revisionId = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["RevisionId"].ToString();
                if (headerCheckBox.Checked)
                {
                    if(!selectedItems.Contains(revisionId))
                        selectedItems.Add(revisionId);
                }
                else 
                {
                    selectedItems.Remove(revisionId);
                    dataItem.Selected = false;
                }
            }
            Session["selectedItems"] = selectedItems;
        }
        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (GetSelectedItems() != null)
            {
                ArrayList selectedItems = GetSelectedItems();
                Int16 stackIndex;
                for (stackIndex = 0; stackIndex <= selectedItems.Count - 1; stackIndex++)
                {
                    string curItem = selectedItems[stackIndex].ToString();
                    foreach (GridItem item in RadGrid1.MasterTableView.Items)
                    {
                        if (item is GridDataItem)
                        {
                            GridDataItem dataItem = (GridDataItem)item;
                            if (curItem.Equals(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["RevisionId"].ToString()))
                            {
                                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = true;
                                dataItem.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region Auxiliary
        protected ArrayList GetSelectedItems()
        {
            ArrayList selectedItems;
            if (Session["selectedItems"] == null)
            {
                selectedItems = new ArrayList();
            }
            else
            {
                selectedItems = (ArrayList)Session["selectedItems"];
            }
            return selectedItems;
        }
        protected void RefreshGrid(bool rebind)
        {
            string estado = CntLainsaSci.EstadoRevision.Planificada.ToString();
            if (dateDesde.SelectedDate != null || dateHasta.SelectedDate != null)
            {
                RadGrid1.DataSource = CntLainsaSci.GetRevisionesPlanificadas(usuario, dateDesde.SelectedDate, dateHasta.SelectedDate, ctx);
            }
            else
                RadGrid1.DataSource = CntLainsaSci.GetRevisionesPlanificadas(usuario, ctx);
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

        protected void dateDesde_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            DateTime desde = DateTime.Now, hasta = DateTime.Now;

            if (dateDesde.SelectedDate != null)
                desde = dateDesde.SelectedDate.Value;
            if (dateHasta.SelectedDate != null)
                hasta = dateHasta.SelectedDate.Value;

            if (desde <= hasta)
                RefreshGrid(true);
            else
            {
                RadNotification1.Text = "Introduzca un periodo correcto.";
                RadNotification1.Show();
            }
        }

        protected void dateHasta_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            DateTime desde = DateTime.Now, hasta = DateTime.Now;

            if (dateDesde.SelectedDate != null)
                desde = dateDesde.SelectedDate.Value;
            if (dateHasta.SelectedDate != null)
                hasta = dateHasta.SelectedDate.Value;

            if (desde <= hasta)
                RefreshGrid(true);
            else
            {
                RadNotification1.Text = "Introduzca un periodo correcto.";
                RadNotification1.Show();
            }
        }

        protected void btnPagina_Click(object sender, EventArgs e)
        {
            int pages = 0;
            pages = (int)txtPagina.Value;
            RadGrid1.PageSize = pages;
            RadGrid1.MasterTableView.Rebind();
        }
    }
}