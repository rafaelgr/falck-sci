using System;
using System.Linq;
using LainsaSciModelo;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class MainPage : System.Web.UI.Page 
{
    #region Definición de variables generales
    LainsaSci ctx = null; // contexto para acceso a datos
    UsuarioExtranet uex = null; // usuario logado
    #endregion
    #region Eventos iniciales de carga de página
    protected void Page_Init(object sender, EventArgs e)
    {
        // lo primero es cargar el contexto
        ctx = new LainsaSci("LainsaSciCTX"); // (LainsaSciCTX -> web.config)
        // Comprobar si hay un usuario logado
        if (Session["UsuarioExtranetId"] != null)
        {
            int id = (int)Session["UsuarioExtranetId"];
            uex = CntLainsaSci.GetUsuarioExtranet(id, ctx);
            if (uex == null)
                Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        // mostrar la versión del programa
        String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        LblTituloDerechoInferior.Text = String.Format("VRS {0}", strVersion);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarGruposMensajes();
            CargarNodosRaiz();
            //if (uex.Global)
            //{
            //    SplData.ContentUrl = "BienvenidaForm.aspx";
            //    foreach (RadMenuItem item in RadMenu1.Items)
            //    {
            //        if (item.Value == "revisar") item.Visible = false;
            //    }
            //}
            //else
            //    SplData.ContentUrl = String.Format("DocumentoGrid.aspx?REVISION=S");
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion
    #region Eventos disparados por controles
    protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "salir":
                Response.Redirect("Default.aspx");
                break;
            case "revisar":
                SplData.ContentUrl = String.Format("DocumentoGrid.aspx?REVISION=S");
                break;
            case "usuario":
                SplData.ContentUrl = String.Format("UsuarioExtranetForm.aspx?UsuarioExtranetId={0}", uex.UsuarioExtranetId);
                break;
        }
    }

    protected void RadTreeView1_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        switch (e.Node.Category)
        {
            case "Empresas":
                CargarEmpresas(e.Node);
                SplData.ContentUrl = "EmpresaGrid.aspx";
                break;
            case "Empresa":
                CargarInstalaciones(e.Node);
                //SplData.ContentUrl = String.Format("InstalacionGrid.aspx?EmpresaId={0}", e.Node.Value);
                SplData.ContentUrl = String.Format("DocumentoGrid.aspx?EmpresaId={0}", e.Node.Value);
                break;
            case "Instalaciones":
                break;
            case "Instalacion":
                //CargarDocumentosInstalacion(e.Node);
                SplData.ContentUrl = String.Format("DocumentoGrid.aspx?InstalacionId={0}", e.Node.Value);
                break;
            case "Categorias":
                CargarCategorias(e.Node);
                SplData.ContentUrl = "CategoriaGrid.aspx";
                break;
            case "Categoria":
                CargarSubCategorias(e.Node);
                SplData.ContentUrl = String.Format("DocumentoGrid.aspx?CategoriaId={0}", e.Node.Value);
                break;
            case "SubCategoria":
                //CargarDocumentosSubCategoria(e.Node);
                SplData.ContentUrl = String.Format("DocumentoGrid.aspx?SubCategoriaId={0}", e.Node.Value);
                break;
            case "Documento":
                SplData.ContentUrl = String.Format("DocumentoForm.aspx?DocumentoId={0}", e.Node.Value);
                break;
        }
        e.Node.ExpandChildNodes();
    }
    #endregion
    #region Funciones auxiliares
    protected void CargarGruposMensajes()
    {
        RadPanelItem rdpb = RadPanelBar1.Items[1];
        foreach (GrupoMensajes gm in CntLainsaSci.GetGruposMensajes(ctx))
        {
            RadPanelItem item = new RadPanelItem(gm.Nombre);
            item.Value = gm.GrupoMensajesId.ToString();
            rdpb.Items.Add(item);
        }
    }

    protected void CargarNodosRaiz()
    {
        RadTreeView rdt1 = (RadTreeView) RadPanelBar1.Items[0].FindControl("RadTreeView1");   
        rdt1.Nodes.Clear(); // limpia todos los nodos
        RadTreeNode node = new RadTreeNode("Empresas");
        node.Value = "Empresas";
        node.Category = "Empresas";
        node.ImageUrl = "imagenes/office-building_16.png";
        //CargarEmpresas(node);
        rdt1.Nodes.Add(node);
        node = new RadTreeNode("Categorias");
        node.Value = "Categorias";
        node.Category = "Categorias";
        node.ImageUrl = "imagenes/folder_cubes_16.png";
        //CargarCategorias(node);
        rdt1.Nodes.Add(node);
        rdt1.ExpandAllNodes();
    }

    protected void CargarEmpresas(RadTreeNode node)
    {
        node.Nodes.Clear();
        if (uex.Empresa == null)
        {
            // cargamos todas las empresas
            var rs = from e in ctx.Empresas
                     orderby e.Nombre
                     select e;
            foreach (Empresa empresa in rs)
            {
                RadTreeNode childNode = new RadTreeNode(empresa.Nombre);
                childNode.Category = "Empresa";
                childNode.Value = empresa.EmpresaId.ToString();
                childNode.ImageUrl = "imagenes/office-building_16.png";
                node.Nodes.Add(childNode);
            }
        }
        else
        {
            Empresa empresa = uex.Empresa;
            RadTreeNode childNode = new RadTreeNode(empresa.Nombre);
            childNode.Category = "Empresa";
            childNode.Value = empresa.EmpresaId.ToString();
            childNode.ImageUrl = "imagenes/office-building_16.png";
            node.Nodes.Add(childNode);
        }
    }

    protected void CargarCategorias(RadTreeNode node)
    {
        node.Nodes.Clear();
        IList<Categoria> categorias;
        // cargamos todas las categorias
        //if (uex.Global)
        //{
        //    categorias = new List<Categoria>();
        //    foreach (PermisoCategoria pcat in uex.PermisoCategorias)
        //    {
        //        categorias.Add(pcat.Categoria);
        //    }
        //}
        //else
        //{
            categorias = (from c in ctx.Categorias
                          orderby c.Nombre
                          select c).ToList<Categoria>();
        //}
        foreach (Categoria categoria in categorias)
        {
            RadTreeNode childNode = new RadTreeNode(categoria.Nombre);
            childNode.Category = "Categoria";
            childNode.Value = categoria.CategoriaId.ToString();
            childNode.ImageUrl = "imagenes/cube_blue_16.png";
            node.Nodes.Add(childNode);
        }
    }
    
    protected void CargarSubCategorias(RadTreeNode node)
    {
        int id = int.Parse(node.Value);
        node.Nodes.Clear();
        // cargamos todas las categoras
        var rs = from sc in ctx.Subcategorias
                 where sc.Categoria.CategoriaId == id
                 select sc;
        foreach (Subcategoria subCategoria in rs)
        {
            RadTreeNode childNode = new RadTreeNode(subCategoria.Nombre);
            childNode.Category = "SubCategoria";
            childNode.Value = subCategoria.SubcategoriaId.ToString();
            childNode.ImageUrl = "imagenes/cube_blue_16.png";
            node.Nodes.Add(childNode);
        }
    }

    protected void CargarInstalaciones(RadTreeNode node)
    {
        if (node.Category != "Empresa")
            return;
        Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(node.Value), ctx);
        if (empresa == null)
            return;
        if (uex.Instalacion != null)
        {
            if (uex.Instalacion.Empresa.EmpresaId != empresa.EmpresaId)
                return;
            else
            {
                node.Nodes.Clear();
                Instalacion instalacion = uex.Instalacion;
                RadTreeNode childNode = new RadTreeNode(instalacion.Nombre);
                childNode.Category = "Instalacion";
                childNode.Value = instalacion.InstalacionId.ToString();
                childNode.ImageUrl = "imagenes/factory_16.png";
                node.Nodes.Add(childNode);
            }
        }
        else
        {
            node.Nodes.Clear();
            // cargamos todas las categoras
            foreach (Instalacion instalacion in empresa.Instalaciones)
            {
                RadTreeNode childNode = new RadTreeNode(instalacion.Nombre);
                childNode.Category = "Instalacion";
                childNode.Value = instalacion.InstalacionId.ToString();
                childNode.ImageUrl = "imagenes/factory_16.png";
                node.Nodes.Add(childNode);
            }
        }
    }

    protected void CargarDocumentosInstalacion(RadTreeNode node)
    {
        if (node.Category != "Instalacion")
            return;
        Instalacion instalacion = CntLainsaSci.GetInstalacion(int.Parse(node.Value), ctx);
        if (instalacion == null)
            return;
        node.Nodes.Clear();
        foreach (Documento documento in instalacion.Documentos)
        {
            RadTreeNode childNode = new RadTreeNode(documento.Nombre);
            childNode.Category = "Documento";
            childNode.Value = documento.DocumentoId.ToString();
            childNode.ImageUrl = "imagenes/document_16.png";
            node.Nodes.Add(childNode);
            //if (!uex.Global)
            //    node.Nodes.Add(childNode);
            //else
            //{
            //    // buscamos si está entre las categorias permitidas.
            //    PermisoCategoria pcat = (from pc in uex.PermisoCategorias
            //                             where pc.Categoria.CategoriaId == documento.Categoria.CategoriaId
            //                             select pc).FirstOrDefault<PermisoCategoria>();
            //    if (pcat != null)
            //    {
            //        node.Nodes.Add(childNode);
            //    }
            //}
        }
    }

    protected void CargarDocumentosSubCategoria(RadTreeNode node)
    {
        if (node.Category != "SubCategoria")
            return;
        Subcategoria subCategoria = CntLainsaSci.GetSubcategoria(int.Parse(node.Value), ctx);
        if (subCategoria == null)
            return;
        node.Nodes.Clear();
        foreach (Documento documento in subCategoria.Documentos)
        {
            RadTreeNode childNode = new RadTreeNode(documento.Nombre);
            childNode.Category = "Documento";
            childNode.Value = documento.DocumentoId.ToString();
            childNode.ImageUrl = "imagenes/document_16.png";
            node.Nodes.Add(childNode);
            //if (!uex.Global)
            //{
            //    if (uex.Empresa != null && documento.Empresa != null)
            //    {
            //        if (documento.Empresa.EmpresaId == uex.Empresa.EmpresaId)
            //        {
            //            if (uex.Instalacion != null && documento.Instalacion != null)
            //            {
            //                if (documento.Instalacion.InstalacionId == uex.Instalacion.InstalacionId)
            //                    node.Nodes.Add(childNode);
            //            }
            //            else
            //            {
            //                node.Nodes.Add(childNode);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    // buscamos si está entre las categorias permitidas.
            //    PermisoCategoria pcat = (from pc in uex.PermisoCategorias
            //                             where pc.Categoria.CategoriaId == documento.Categoria.CategoriaId
            //                             select pc).FirstOrDefault<PermisoCategoria>();
            //    if (pcat != null)
            //    {
            //        node.Nodes.Add(childNode);
            //    }
            //}
        }
    }

    protected void CargarDocumentosCategoria(RadTreeNode node)
    {
        if (node.Category != "Categoria")
            return;
        Categoria categoria = CntLainsaSci.GetCategoria(int.Parse(node.Value), ctx);
        if (categoria == null)
            return;
        node.Nodes.Clear();
        foreach (Documento documento in CntLainsaSci.GetDocumentos(categoria, uex, ctx))
        {
            RadTreeNode childNode = new RadTreeNode(documento.Nombre);
            childNode.Category = "Documento";
            childNode.Value = documento.DocumentoId.ToString();
            childNode.ImageUrl = "imagenes/document_16.png";
            node.Nodes.Add(childNode);
        }
    }
    #endregion

    protected void RadPanelBar1_ItemClick(object sender, RadPanelBarEventArgs e)
    {
        if (e.Item.Owner is RadPanelItem)
        {
            RadPanelItem parentItem = (RadPanelItem)e.Item.Owner;

            switch (parentItem.Text)
            {
                case "Mensajes":
                    RadPanelItem item = e.Item;
                    SplData.ContentUrl = String.Format("MensajeGrid.aspx?GrupoMensajesId={0}", item.Value);
                    break;
            }
        }
    }
}