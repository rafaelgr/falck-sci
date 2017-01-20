using System;
using System.Web;
using System.Web.UI;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.IO;
using Telerik.OpenAccess;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Linq;

public partial class DocumentoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null; //
    Instalacion instalacion = null;
    TipoDispositivo tipo = null;
    Categoria categoria = null;
    string nombre = "";
    string caller = ""; // who calls the form
    string inTab = "";
    string fileName = "";
    Documento documento = null;
    bool newRecord = true;
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
        //
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "repositoriotmpform", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        if (Request.QueryString["InTab"] != null)
        {
            inTab = Request.QueryString["InTab"];
        }
        // Si esto no va antes de DocumentoID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Mirar si se ha pasado una empresa
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
            CargaEmpresa(empresa);
        }
        if (Request.QueryString["InstalacionId"] != null)
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["InstalacionId"]), ctx);
            CargaInstalacion(instalacion);
        }
        if (Request.QueryString["TipoDispositivoId"] != null)
        {
            tipo = CntLainsaSci.GetTipoDispositivo(int.Parse(Request.QueryString["TipoDispositivoId"]), ctx);
            CargaTipo(tipo);
        }
        if (Request.QueryString["Nombre"] != null)
        {
            nombre = Request.QueryString["Nombre"];
            nombre.Replace("'", "");
            fileName = nombre;
        }
        // MIrar si se ha pasado una instalacion
        if (Request.QueryString["RevisionId"] != null)
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["RevisionId"]), ctx);
            CargaInstalacion(instalacion);
        }

        // Is it a new record or not?
        if (Request.QueryString["DocumentoId"] != null)
        {
            documento = CntLainsaSci.GetDocumento(int.Parse(Request.QueryString["DocumentoId"]), ctx);
            LoadData(documento);
            this.Title = String.Format("Documento: {0}", documento.Nombre);
            newRecord = false;
        }
        else
        {
            // cunado se crea uno nuevo se cargan todas las categorias
            CargaCategorias();
            txtNombre.Text = fileName;
        }
        if (Request.QueryString["FileName"] != null)
        {
            fileName = Request.QueryString["FileName"];
            //CargaAutomatica(fileName);
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
    }
    #endregion
    #region Actions
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!DataOk())
                return;
            if (newRecord)
                documento = new Documento();
            UnloadData(documento);
            if (newRecord)
                ctx.Add(documento);
            ctx.SaveChanges();
            //---
            
            if (newRecord)
            {
                // Aqui hay que copiar el fichero del directorio temporal al definitivo
                // (1) Obtener la extensión
                int pos = fileName.LastIndexOf('.');
                if (pos != -1)
                {
                    string extension = fileName.Substring(pos);
                    string newFileName = String.Format("{0:000000000}", documento.DocumentoId) + extension;
                    string origen = MapPath("/") + "Repo\\" + fileName;
                    string repodir = ConfigurationManager.AppSettings["Repositorio"];
                    string destino = repodir + "\\" + newFileName;
                    File.Copy(origen, destino, true);
                    File.Delete(origen);
                    documento.Extension = extension;
                    ctx.SaveChanges();
                }
            }
            //---
            if (newRecord)
            {
                if (empresa != null)
                {
                    // cuando hay una generación automática, al menos la empresa se pasa
                    RadAjaxManager1.ResponseScripts.Add("closeWindow();");
                }
                else
                {
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
                }
            }
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
        }
        catch (Exception ex)
        {
            ControlDeError(ex);
        }
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
    #endregion
    #region Auxiliary
    protected bool DataOk()
    {
        if (txtNombre.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        if (rdcEmpresa.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "EmpresaNeeded"));
            RadNotification1.Show();
            return false;
        }
        //if (rdcInstalacion.SelectedValue == "")
        //{
        //    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
        //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
        //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "InstalacionNeeded"));
        //    RadNotification1.Show();
        //    return false;
        //}
        if (rdcCategoria.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "CategoriaNeeded"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }

    protected void LoadData(Documento documento)
    {
        txtDocumentoId.Text = documento.DocumentoId.ToString();
        txtNombre.Text = documento.Nombre;
        CargaInstalacion(documento.Instalacion);
        CargaTipo(documento.TipoDispositivo);
        CargaCategoria(documento.Categoria);
        CargaSubcategoria(documento.Subcategoria);
        if (!CntLainsaSci.FechaNula(documento.Fecha))
            dtFecha.SelectedDate = documento.Fecha;
        rdeComentarios.Content = documento.Comentarios;
    }

    protected void UnloadData(Documento documento)
    {
        documento.Nombre = txtNombre.Text;
        documento.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
        if (rdcInstalacion.SelectedValue != "")
            documento.Instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
        if (rdcTipo.SelectedValue != "")
            documento.TipoDispositivo = CntLainsaSci.GetTipoDispositivo(int.Parse(rdcTipo.SelectedValue), ctx);
        documento.Categoria = CntLainsaSci.GetCategoria(int.Parse(rdcCategoria.SelectedValue), ctx);
        if (rdcSubcategoria.SelectedValue != "")
            documento.Subcategoria = CntLainsaSci.GetSubcategoria(int.Parse(rdcSubcategoria.SelectedValue), ctx);
        if (dtFecha.SelectedDate != null)
            documento.Fecha = (DateTime)dtFecha.SelectedDate;
        documento.Comentarios = rdeComentarios.Content;
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

    protected void CargaEmpresa(Empresa empresa)
    {
        if (empresa == null)
            return;
        rdcEmpresa.Items.Clear();
        rdcEmpresa.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
        rdcEmpresa.SelectedValue = empresa.EmpresaId.ToString();
        rdcEmpresa.Enabled = false;
    }

    protected void CargaInstalacion(Instalacion instalacion)
    {
        if (instalacion == null)
            return;
        rdcInstalacion.Items.Clear();
        rdcInstalacion.Items.Add(new RadComboBoxItem(instalacion.Nombre, instalacion.InstalacionId.ToString()));
        rdcInstalacion.Enabled = false;
        rdcTipo.Enabled = false;
        CargaEmpresa(instalacion.Empresa);
   }

    protected void CargaTipo(TipoDispositivo tipo)
    {
        if (tipo == null)
            return;
        rdcTipo.Items.Clear();
        rdcTipo.Items.Add(new RadComboBoxItem(tipo.Nombre, tipo.TipoId.ToString()));
        rdcTipo.Enabled = false;
        rdcInstalacion.Enabled = false;
        CargaEmpresa(tipo.Empresa);
    }

    protected void CargaInstalaciones(Empresa empresa)
    {
        if (empresa == null)
            return;
        rdcInstalacion.Items.Clear();
        rdcInstalacion.Items.Add(new RadComboBoxItem("", ""));
        foreach (Instalacion instalacion in empresa.Instalaciones)
        {
            rdcInstalacion.Items.Add(new RadComboBoxItem(instalacion.Nombre, instalacion.InstalacionId.ToString()));
        }
    }

    protected void CargaCategoria(Categoria categoria)
    {
        if (categoria == null)
            return;
        rdcCategoria.Items.Clear();
        rdcCategoria.Items.Add(new RadComboBoxItem(categoria.Nombre, categoria.CategoriaId.ToString()));
        rdcCategoria.SelectedValue = categoria.CategoriaId.ToString();
    }

    protected void CargaCategorias()
    {
        string catid = "";
        rdcCategoria.Items.Clear();
        foreach (Categoria c in CntLainsaSci.GetCategorias(ctx))
        {
            rdcCategoria.Items.Add(new RadComboBoxItem(c.Nombre, c.CategoriaId.ToString()));
            catid = c.CategoriaId.ToString();
        }
        //rdcCategoria.SelectedValue = catid;
        //categoria = CntLainsaSci.GetCategoria(int.Parse(catid), ctx);
        //CargaSubcategorias(categoria);
        rdcCategoria.Items.Add(new RadComboBoxItem(" ",""));
        rdcCategoria.SelectedValue = "";
    }

    protected void CargaSubcategoria(Subcategoria Subcategoria)
    {
        if (Subcategoria == null)
            return;
        rdcSubcategoria.Items.Clear();
        rdcSubcategoria.Items.Add(new RadComboBoxItem(Subcategoria.Nombre, Subcategoria.SubcategoriaId.ToString()));
        rdcSubcategoria.SelectedValue = Subcategoria.SubcategoriaId.ToString();
    }

    protected void CargaSubcategorias(Categoria categoria)
    {
        if (categoria == null) return;
        rdcSubcategoria.Items.Clear();
        foreach (Subcategoria Subcategoria in categoria.Subcategorias)
        {
            rdcSubcategoria.Items.Add(new RadComboBoxItem(Subcategoria.Nombre, Subcategoria.SubcategoriaId.ToString()));
        }
    }
    #endregion

    protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value != "")
        {
            Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Value), ctx);
            CargaInstalaciones(empresa);
        }
    }

    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Empresa empresa in CntLainsaSci.GetEmpresas(e.Text,usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
        }
    }

    protected void rdcCategoria_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value != "")
        {
            Categoria categoria = CntLainsaSci.GetCategoria(int.Parse(e.Value), ctx);
            CargaSubcategorias(categoria);
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        // es llamado desde la selección de una empresa 
        Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Argument), ctx);
        CargaInstalaciones(empresa);
    }


}