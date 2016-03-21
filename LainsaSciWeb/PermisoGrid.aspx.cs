using System;
using Telerik.OpenAccess;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class PermisoGrid : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario Usuario; // Usuario loged
    Permiso permiso;
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (Usuario == null)
            Response.Redirect("Default.aspx");
        else
            Session["UsuarioId"] = Usuario.UsuarioId;
        //
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "grupousuariogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        if (Request.QueryString["Mode"] != null)
            mode = Request.QueryString["Mode"];
        if (Request.QueryString["Caller"] != null)
            caller = Request.QueryString["Caller"];
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadGruposUsuario(rdcGrupoUsuario);
        //RadTreeList1.ExpandAllItems();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["PermisoGrid"] = null;
    }
    #endregion
    #region RadGrid events

    protected void RadTreeList1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RefreshTreeList(false);
    }

    protected void RadTreeList1_ItemDataBound(object sender, TreeListItemDataBoundEventArgs e)
    {
        if (e.Item is TreeListDataItem)
        {
            TreeListDataItem item = (TreeListDataItem)e.Item;
            // assign the appropiate javascript function to edit button
            ImageButton imgb = (ImageButton)item.FindControl("Edit");
            string jCommand = String.Format("editPermiso('{0}');", Int32.Parse(item["PermissionId"].Text));
            imgb.OnClientClick = jCommand;
            imgb.Visible = permiso.Modificar;
        }
    }

    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
    }
    #endregion
    #region Auxiliary 
    protected void RefreshTreeList(bool rebind)
    {
        if (rdcGrupoUsuario.SelectedValue != "")
        {
            GrupoUsuario gpu = CntLainsaSci.GetGrupoUsuario(int.Parse(rdcGrupoUsuario.SelectedValue), ctx);
            CntLainsaSci.VerifyPermissions(gpu, ctx);
            RadTreeList1.DataSource = CntLainsaSci.GetPermissionsViews(gpu);
        }
        else
        {
            RadTreeList1.DataSource = new List<PermissionView>();
        }
        if (rebind) RadTreeList1.Rebind();

    }
    protected void LoadGruposUsuario(RadComboBox combo)
    {
        if (combo.Items.Count > 0) return;
        combo.Items.Clear();
        foreach (GrupoUsuario gpu in CntLainsaSci.GetGruposUsuarios(ctx))
        {
            combo.Items.Add(new RadComboBoxItem(gpu.Nombre, gpu.GrupoUsuarioId.ToString()));
        }
        combo.Items.Add(new RadComboBoxItem("",""));
        combo.SelectedValue = "";
    }
    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshTreeList(true);
        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
    }

    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
    }

    protected void rdcGrupoUsuario_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RefreshTreeList(true);
    }


}