using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using LainsaSciModelo;
using LainsaSciWinWeb;
using Telerik.OpenAccess;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class ModeloForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    ModeloDispositivo modeloDispositivo = null;
    Empresa empresa = null;
    Instalacion instalacion = null;
    TipoDispositivo tipo = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "Modelogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de ModeloDispositivoID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        if (Request.QueryString["TipoId"] != null)
        {
            tipo = CntLainsaSci.GetTipoDispositivo(int.Parse(Request.QueryString["TipoId"]), ctx);
            rdcTipo.Items.Clear();
            rdcTipo.Items.Add(new RadComboBoxItem(tipo.Nombre, tipo.TipoId.ToString()));
            rdcTipo.SelectedValue = tipo.TipoId.ToString();
            imgTipo.Enabled = false;
            rdcTipo.Enabled = false;
            if (tipo.Empresa != null)
            {
                rdcEmpresa.Items.Clear();
                rdcEmpresa.Items.Add(new RadComboBoxItem(tipo.Empresa.Nombre, tipo.Empresa.EmpresaId.ToString()));
                rdcEmpresa.SelectedValue = tipo.Empresa.EmpresaId.ToString();
                imgEmpresa.Enabled = false;
                rdcEmpresa.Enabled = false;
            }
            if (tipo.Instalacion != null)
            {
                rdcInstalacion.Items.Clear();
                rdcInstalacion.Items.Add(new RadComboBoxItem(tipo.Instalacion.Nombre, tipo.Instalacion.InstalacionId.ToString()));
                rdcInstalacion.SelectedValue = tipo.Instalacion.InstalacionId.ToString();
                imgInstalacion.Enabled = false;
                rdcInstalacion.Enabled = false;
            }
        }
        
        // Is it a new record or not?
        if (Request.QueryString["ModeloId"] != null)
        {
            modeloDispositivo = CntLainsaSci.GetModeloDispositivo(int.Parse(Request.QueryString["ModeloId"]), ctx);
            LoadData(modeloDispositivo);
            newRecord = false;
        }
        else
        {
            newRecord = true;
            if (usuario.Empresa != null)
            {
                rdcEmpresa.Items.Clear();
                rdcEmpresa.Items.Add(new RadComboBoxItem(usuario.Empresa.Nombre, usuario.Empresa.EmpresaId.ToString()));
                rdcEmpresa.SelectedValue = usuario.Empresa.EmpresaId.ToString();
                imgEmpresa.Enabled = false;
                rdcEmpresa.Enabled = false;
            }
            if (usuario.Instalacion != null)
            {
                rdcInstalacion.Items.Clear();
                rdcInstalacion.Items.Add(new RadComboBoxItem(usuario.Instalacion.Nombre, usuario.Instalacion.InstalacionId.ToString()));
                rdcInstalacion.SelectedValue = usuario.Instalacion.InstalacionId.ToString();
                imgInstalacion.Enabled = false;
                rdcInstalacion.Enabled = false;
            }
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
            if (!DataOk()) return;
            if (newRecord) modeloDispositivo = new ModeloDispositivo();
            UnloadData(modeloDispositivo);
            if (newRecord) ctx.Add(modeloDispositivo);
            ctx.SaveChanges();
            if (newRecord)
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');"
                    , caller));
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');"
                    , caller));
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
        return true;
    }
    protected void LoadData(ModeloDispositivo modelo)
    {
        txtModeloId.Text = modelo.ModeloId.ToString();
        txtNombre.Text = modelo.Nombre;
        if (modelo.Empresa != null)
        {
            rdcEmpresa.Items.Clear();
            rdcEmpresa.Items.Add(new RadComboBoxItem(modelo.Empresa.Nombre, modelo.Empresa.EmpresaId.ToString()));
            rdcEmpresa.SelectedValue = modelo.Empresa.EmpresaId.ToString();
            imgEmpresa.Enabled = false;
            rdcEmpresa.Enabled = false;
        }
        if (modelo.Instalacion != null)
        {
            rdcInstalacion.Items.Clear();
            rdcInstalacion.Items.Add(new RadComboBoxItem(modelo.Instalacion.Nombre, modelo.Instalacion.InstalacionId.ToString()));
            rdcInstalacion.SelectedValue = modelo.Instalacion.InstalacionId.ToString();
            imgInstalacion.Enabled = false;
            rdcInstalacion.Enabled = false;
        }
        if (modelo.TipoDispositivo != null)
        {
            rdcTipo.Items.Clear();
            rdcTipo.Items.Add(new RadComboBoxItem(modelo.TipoDispositivo.Nombre, modelo.TipoDispositivo.TipoId.ToString()));
            rdcTipo.SelectedValue = modelo.TipoDispositivo.TipoId.ToString();
            imgTipo.Enabled = false;
            rdcTipo.Enabled = false;
        }
    }
    protected void UnloadData(ModeloDispositivo modelo)
    {
        modelo.Nombre = txtNombre.Text;
        if (rdcEmpresa.SelectedValue != "")
            modelo.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
        if (rdcInstalacion.SelectedValue != "")
        {
            modelo.Instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
            modelo.Empresa = modelo.Instalacion.Empresa;
        }
        if (rdcTipo.SelectedValue != "")
            modelo.TipoDispositivo = CntLainsaSci.GetTipoDispositivo(int.Parse(rdcTipo.SelectedValue), ctx);
    }


    protected void rdcTipo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (TipoDispositivo tpd in CntLainsaSci.GetTiposDispositivo(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(tpd.Nombre, tpd.TipoId.ToString()));
        }
    }

    protected void rdcTipo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }


    
    
    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Empresa emp in CntLainsaSci.GetEmpresas(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(emp.Nombre, emp.EmpresaId.ToString()));
        }
    }

    protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    protected void rdcInstalacion_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Instalacion ins in CntLainsaSci.GetInstalaciones(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(ins.Nombre, ins.InstalacionId.ToString()));
        }
    }

    protected void rdcInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rdcInstalacion.SelectedValue != "")
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
            if (instalacion != null)
            {
                rdcEmpresa.Items.Clear();
                rdcEmpresa.Items.Add(new RadComboBoxItem(instalacion.Empresa.Nombre, instalacion.Empresa.EmpresaId.ToString()));
                rdcEmpresa.SelectedValue = instalacion.Empresa.EmpresaId.ToString();
            }
        }
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
    
    #endregion

    #region Empresas - Instalaciones
    protected void CargarEmpresas(Empresa e)
    {
        rdcEmpresa.Items.Clear();
        foreach (Empresa e1 in CntLainsaSci.GetEmpresas(usuario, ctx))
        {
            rdcEmpresa.Items.Add(new RadComboBoxItem(e1.Nombre, e1.EmpresaId.ToString()));
        }
        if (e == null)
        {
            rdcEmpresa.Items.Add(new RadComboBoxItem(" ", ""));
            rdcEmpresa.SelectedValue = "";
        }
        else
            rdcEmpresa.SelectedValue = e.EmpresaId.ToString();

    }
    protected void CargarInstalaciones(Empresa e)
    {
        rdcInstalacion.Items.Clear();
        IList<Instalacion> l = CntLainsaSci.GetInstalaciones(usuario, ctx);
        l = (from i in l
             where i.Empresa.EmpresaId == e.EmpresaId
             select i).ToList<Instalacion>();

        foreach (Instalacion i1 in l)
        {
            rdcInstalacion.Items.Add(new RadComboBoxItem(i1.Nombre, i1.InstalacionId.ToString()));
        }
        rdcInstalacion.Items.Add(new RadComboBoxItem(" ", ""));
        rdcInstalacion.SelectedValue = "";
        rdcInstalacion.Text = "";
    }
    protected void CargarInstalaciones(Instalacion i)
    {
        rdcInstalacion.Items.Clear();
        rdcInstalacion.Items.Add(new RadComboBoxItem(i.Nombre, i.InstalacionId.ToString()));
        rdcInstalacion.SelectedValue = i.InstalacionId.ToString();
    }
    #endregion
}
