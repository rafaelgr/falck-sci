using System;
using Telerik.OpenAccess;
using LainsaSciModelo;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LainsaSciExtranet;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class EmpresaGrid : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    UsuarioExtranet uex; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // verify if a Usuario is logged
        uex = CntLainsaSci.GetUsuarioExtranet((int)Session["UsuarioExtranetId"],ctx);
        if (uex == null)
            Response.Redirect("Default.aspx");
        // si llega aquí está autorizado
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CntWinWeb.TranslateRadGridFilters(RadGrid1);
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["EmpresaGrid"] = null;
    }
    #endregion
    #region RadGrid events
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshGrid(false);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {


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
                    Response.Redirect(String.Format("InstalacionGrid.aspx?EmpresaId={0}",id));
                    break;
                case "Edit":
                    break;
                case "Delete":
                    break;
            }
        }
    }
    #endregion
    #region Auxiliary 
    protected void RefreshGrid(bool rebind)
    {
        RadGrid1.DataSource = CntLainsaSci.GetEmpresas(uex,ctx);
        if (rebind)
            RadGrid1.Rebind();
    }
    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
    }

    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
    }
}