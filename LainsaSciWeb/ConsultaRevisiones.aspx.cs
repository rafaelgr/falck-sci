using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.Collections.Generic;
using System.IO;

public partial class ConsultaRevisiones : System.Web.UI.Page
{
    #region Global variables declaration
    LainsaSci ctx; // openaccess context used in this page
    Usuario usuario; // Usuario loged
    Permiso permiso; // permisos del usuario segun su grupo
    Dispositivo dispositivo = null;
    Programa programa = null;
    string filtroVacio = "";
    //Revision revision = null;
    string mode = ""; // the way it's called, S = for search
    string caller = ""; // who's calling the grid form
    string consulta = "";
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
            }
        }
        RadScriptManager1.RegisterPostBackControl(this.FindControl("pnlBtnExcel"));
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarFiltros(null);
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

    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
        // we only process commands with a datasource (our image buttons)
        if (e.CommandSource == null)
            return;
        //if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName)
        //{
        //    RadGrid1.ExportSettings.OpenInNewWindow = true;
        //    RadGrid1.ExportSettings.ExportOnlyData = true;
        //    RadGrid1.ExportSettings.IgnorePaging = true;

        //    RadGrid1.MasterTableView.ExportToExcel();

        //}
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
                    string url = String.Format("RevisionForm.aspx?RevisionId={0}&Modo=S", id);
                    string jCommand = String.Format("openOutSide('{0}', 'RevisionForm');", url);
                    RadAjaxManager1.ResponseScripts.Add(jCommand);
                    break;
                case "Delete":
                    break;
                case "Generar":
                    break;
            }
        }
    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        RefreshGrid(false);
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            GridDataItem item = (GridDataItem)e.Item;
            string strKey = item.GetDataKeyValue("RevisionId").ToString();
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
                item.BackColor = System.Drawing.Color.AliceBlue;
            }

        }

    }
    protected void RefreshGrid(bool rebind)
    {
        if(usuario != null)
            RadGrid1.DataSource = CntLainsaSci.GetRevisiones(usuario, ctx);
        else
            RadGrid1.DataSource = CntLainsaSci.GetRevisiones(ctx);
        if (rebind)
            RadGrid1.Rebind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (txtFiltro.Text != "")
        {
            Filtro f = CntLainsaSci.GetFiltro("Revision", txtFiltro.Text, usuario, ctx);
            if (f == null)
            {
                f = new Filtro();
                ctx.Add(f);
            }
            f.Tipo = "Revision";
            f.Nombre = txtFiltro.Text;
            f.Expresion = RadFilter1.SaveSettings();
            f.Usuario = usuario;
            ctx.SaveChanges();
            txtFiltro.Text = "";
            CargarFiltros(f);
            rdcFiltro.SelectedValue = f.FiltroId.ToString();
            RadNotification1.Text = String.Format("El filtro '{0}' ha sido agregado, lo puede ver en el desplegable", f.Nombre);
            RadNotification1.Show();
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (txtFiltro.Text != "")
        {
            Filtro f = CntLainsaSci.GetFiltro("Revision", txtFiltro.Text, usuario, ctx);
            if (f != null)
            {
                string nom = f.Nombre;
                ctx.Delete(f);
                ctx.SaveChanges();
                CargarFiltros(null);
                rdcFiltro.SelectedValue = "";
                RadNotification1.Text = String.Format("El filtro '{0}' ha sido eliminado", nom);
                RadNotification1.Show();
            }
        }
    }
    protected void CargarFiltros(Filtro fil)
    {
        rdcFiltro.Items.Clear();
        foreach (Filtro f in CntLainsaSci.GetFiltros("Revision", usuario, ctx))
        {
            rdcFiltro.Items.Add(new RadComboBoxItem(f.Nombre, f.FiltroId.ToString()));
        }
        rdcFiltro.Items.Add(new RadComboBoxItem(" ", ""));
        if (fil != null)
        {
            rdcFiltro.SelectedValue = fil.FiltroId.ToString();
        }
        else
        {
            rdcFiltro.SelectedValue = "";
            txtFiltro.Text = "";
        }
    }

    protected void rdcFiltro_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        RadFilter1.RootGroup.Expressions.Clear();
        RadFilter1.RecreateControl();
        txtFiltro.Text = "";
        if (rdcFiltro.SelectedValue != "")
        {
            Filtro f = CntLainsaSci.GetFiltro(int.Parse(rdcFiltro.SelectedValue), ctx);
            txtFiltro.Text = f.Nombre;
            RadFilter1.LoadSettings(f.Expresion);
        }
        RadFilter1.FireApplyCommand();
        if (rdcFiltro.SelectedValue != "") consulta = rdcFiltro.Text;
    }

    //protected void Button1_Click(object sender, System.EventArgs e)
    //{
    //    RadGrid1.ExportSettings.OpenInNewWindow = true;
    //    RadGrid1.ExportSettings.ExportOnlyData = true;
    //    RadGrid1.ExportSettings.IgnorePaging = true;
    //    RadGrid1.MasterTableView.ExportToExcel();
    //}
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        RadGrid1.ExportSettings.ExportOnlyData = true;
        RadGrid1.ExportSettings.IgnorePaging = true;
        RadGrid1.ExportSettings.OpenInNewWindow = true;
        RadGrid1.MasterTableView.ExportToExcel();
    }

    protected void btnInforme_Click(object sender, EventArgs e)
    {
        string mode = "G";
        List<string> revisiones = new List<string>();
        RadGrid1.AllowPaging = false;// disabling paging
        RadGrid1.Rebind();
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            revisiones.Add(item["RevisionId"].Text);
        }
        Session["Filtro"] = revisiones;
        RadGrid1.AllowPaging = true;// disabling paging
        RadGrid1.Rebind();
        //for (int i = 0; i < RadGrid1.MasterTableView.PageCount; i++)
        //{
        //    RadGrid1.CurrentPageIndex = i;
        //    RadGrid1.Rebind();
        //    foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        //    {
        //        revisiones.Add(item["RevisionId"].Text);
        //    }

        //}
        string filtro = "";
        if (rdcFiltro.SelectedValue != "") consulta = rdcFiltro.Text;
        Session["Consulta"] = consulta;
        //string url = String.Format("VisorInforme.aspx?Informe=RptConsultaRevision&Filtro=Y");
        string url = String.Format("VisorInforme.aspx?Informe=RptInfConsultaRevision&Filtro=Y");
        //string url = String.Format("VisorInforme.aspx?Informe=RptConsultaRevision&mode={1}&Filtro={0}", filtro, mode);
        string jCommand = String.Format("openOutSide('{0}','{1}');", url, "VisorInforme");
        RadAjaxManager1.ResponseScripts.Add(jCommand);
    }
    protected void RadFilter1_ApplyExpressions(object sender, RadFilterApplyExpressionsEventArgs e)
    {

        // RadFilterDynamicLinqQueryProvider provider = new RadFilterDynamicLinqQueryProvider();
        RadFilterSqlQueryProvider provider = new RadFilterSqlQueryProvider();
        provider.ProcessGroup(e.ExpressionRoot);
        // btnInforme.Text = provider.Result;

    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        string mode = "D";
        List<string> revisiones = new List<string>();
        RadGrid1.AllowPaging = false;// disabling paging
        RadGrid1.Rebind();
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            revisiones.Add(item["RevisionId"].Text);
        }
        Session["Filtro"] = revisiones;
        RadGrid1.AllowPaging = true;// disabling paging
        RadGrid1.Rebind();

        string filtro = "";
        if (RadFilter1 != null)
            filtro = RadGrid1.MasterTableView.FilterExpression;
        //string url = String.Format("VisorInforme.aspx?Informe=RptConsultaRevision&Filtro={0}", filtro);
        string url = String.Format("VisorInforme.aspx?Informe=RptConsultaRevision&Mode={1}&Filtro={0}", filtro, mode);
        string jCommand = String.Format("openOutSide('{0}','{1}');", url, "VisorInforme");
        RadAjaxManager1.ResponseScripts.Add(jCommand);
    }

    protected void RadButton2_Click(object sender, EventArgs e)
    {
         Exportar3();
        //Exportar3();
        //ExportGridView();
    }
    public void Exportar3()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        StringWriter sw = new StringWriter(sb);

        HtmlTextWriter htw = new HtmlTextWriter(sw);



        Page page = new Page();

        HtmlForm form = new HtmlForm();



        RadGrid1.EnableViewState = false;



        // Deshabilitar la validación de eventos, sólo asp.net 2

        page.EnableEventValidation = false;



        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.

        page.DesignerInitialize();



        page.Controls.Add(form);

        form.Controls.Add(RadGrid1);



        page.RenderControl(htw);



        Response.Clear();

        Response.Buffer = true;

        Response.ContentType = "application/vnd.ms-excel";

        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");

        Response.Charset = "UTF-8";

        Response.ContentEncoding = System.Text.Encoding.Default;

        Response.Write(sb.ToString());
    }
    
}
