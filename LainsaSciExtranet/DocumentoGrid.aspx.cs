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
using System.Drawing;

public partial class DocumentoGrid : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    UsuarioExtranet uex; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    Empresa empresa = null;
    Categoria categoria = null;
    Subcategoria subCategoria = null;
    Instalacion instalacion = null;
    int empresaId = 0;
    int categoriaId = 0;
    int instalacionId = 0;
    int subCategoriaId = 0;
    bool revisables = false;
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
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresaId = int.Parse(Request.QueryString["EmpresaId"]);
            empresa = CntLainsaSci.GetEmpresa(empresaId, ctx);
        }
        if (Request.QueryString["CategoriaId"] != null)
        {
            categoriaId = int.Parse(Request.QueryString["CategoriaId"]);
            categoria = CntLainsaSci.GetCategoria(categoriaId, ctx);
        }
        if (Request.QueryString["InstalacionId"] != null)
        {
            instalacionId = int.Parse(Request.QueryString["InstalacionId"]);
            instalacion = CntLainsaSci.GetInstalacion(instalacionId, ctx);
        }
        if (Request.QueryString["SubCategoriaId"] != null)
        {
            subCategoriaId = int.Parse(Request.QueryString["SubCategoriaId"]);
            subCategoria = CntLainsaSci.GetSubcategoria(subCategoriaId, ctx);
        }
        if (Request.QueryString["REVISION"] != null)
        {
            revisables = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CntWinWeb.TranslateRadGridFilters(RadGrid1);
            if (empresa != null) lblTitulo.Text = empresa.Nombre;
            if (instalacion != null) lblTitulo.Text = instalacion.Nombre;
            if (categoria != null) lblTitulo.Text = categoria.Nombre;
            if (subCategoria != null) lblTitulo.Text = subCategoria.Nombre;
            if (revisables) lblTitulo.Text = String.Format("Bienvenido {0}, estos son los documentos pendientes de revisión",uex.Nombre);
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
        //
        //Session["DocumentoGrid"] = null;
    }
    #endregion
    #region RadGrid events
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshGrid(false);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (item["Revisable"].Text == "True" && item["Revisado"].Text == "False")
                item.BackColor = Color.LightSalmon;
            if (CntWinWeb.FechaNula(DateTime.Parse(item["Fecha"].Text)))
            {
                item["Fecha"].Text = "";
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
            if (imgb.ID != "New" && imgb.ID != "Exit")
                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            switch (imgb.ID)
            {
                case "Select":
                    Response.Redirect(String.Format("DocumentoForm.aspx?DocumentoId={0}", id));
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
        //if (!revisables)
        //{
        if (empresa != null)
        {
            RadGrid1.DataSource = CntLainsaSci.GetDocumentos(empresa, uex, ctx);
        }
        if (instalacion != null)
        {
            RadGrid1.DataSource = CntLainsaSci.GetDocumentos(instalacion,uex, ctx);
        }
        if (categoria != null)
        {
            RadGrid1.DataSource = CntLainsaSci.GetDocumentos(categoria, uex, ctx);
        }
        if (subCategoria != null)
        {
            RadGrid1.DataSource = CntLainsaSci.GetDocumentos(subCategoria, uex, ctx);
        }
        //}
        //else
        //{
        //    RadGrid1.DataSource = CntLainsaSci.GetDocumentosRevisables(uex, ctx);
        //}
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