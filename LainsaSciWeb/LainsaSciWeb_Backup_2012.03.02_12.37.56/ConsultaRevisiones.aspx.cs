﻿using System;
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
                RadGrid1.Columns.FindByDataField("Dispositivo.Nombre").Visible = false;
            }
        }
        if (Request.QueryString["ProgramaId"] != null)
        {
            programa = CntLainsaSci.GetPrograma(int.Parse(Request.QueryString["ProgramaId"]), ctx);
            if (programa != null)
            {
            }
        }
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
        RadGrid1.DataSource = CntLainsaSci.GetRevisiones(usuario, ctx);
        if (rebind)
            RadGrid1.Rebind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (txtFiltro.Text != "")
        {
            Filtro f = CntLainsaSci.GetFiltro("Revision", txtFiltro.Text, ctx);
            if (f == null)
            {
                f = new Filtro();
                ctx.Add(f);
            }
            f.Tipo = "Revision";
            f.Nombre = txtFiltro.Text;
            f.Expresion = RadFilter1.SaveSettings();
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
            Filtro f = CntLainsaSci.GetFiltro("Revision", txtFiltro.Text, ctx);
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
        foreach(Filtro f in CntLainsaSci.GetFiltros("Revision",ctx))
        {
            rdcFiltro.Items.Add(new RadComboBoxItem(f.Nombre,f.FiltroId.ToString()));
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
    }
}