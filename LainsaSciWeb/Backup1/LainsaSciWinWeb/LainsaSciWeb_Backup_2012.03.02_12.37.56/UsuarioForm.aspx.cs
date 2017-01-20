using System;
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

namespace LainsaSciWinWeb
{
    public partial class UsuarioForm : System.Web.UI.Page
    {
        #region Variables declaration
        LainsaSci ctx = null; // openaccess context used in this page
        Usuario Usuario = null; // Usuario loged
        Permiso permiso = null; //
        string caller = ""; // who calls the form
        Usuario usuario = null;
        bool newRecord = true;
        Empresa empresa = null;
        Instalacion instalacion = null;
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
            btnAccept.Visible = permiso.Modificar;
            // Is it a new record or not?
            if (Request.QueryString["UsuarioId"] != null)
            {
                usuario = CntLainsaSci.GetUsuario(int.Parse(Request.QueryString["UsuarioId"]), ctx);
                LoadData(usuario);
                newRecord = false;
            }
            if (Request.QueryString["Caller"] != null)
            {
                caller = Request.QueryString["Caller"];
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
                    usuario = new Usuario();
                UnloadData(usuario);
                if (newRecord)
                    ctx.Add(usuario);
                ctx.SaveChanges();
                if (newRecord)
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
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
            if (txtLogin.Text == "")
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "LoginNeeded"));
                RadNotification1.Show();
                return false;
            }
            if (rdcGrupo.SelectedValue == "")
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "UsuarioGroupNeeded"));
                RadNotification1.Show();
                return false;
            }
            if (txtPassword.Text != "" || txtPassword2.Text != "")
            {
                if (txtPassword.Text != txtPassword2.Text)
                {
                    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "PasswordDoesntMatch"));
                    RadNotification1.Show();
                    return false;
                }
            }
            return true;
        }

        protected void LoadData(Usuario usuario)
        {
            txtUsuarioId.Text = usuario.UsuarioId.ToString();
            txtNombre.Text = usuario.Nombre;
            // Cargar el grupo al que pertenece el usuario
            rdcGrupo.Items.Clear();
            rdcGrupo.Items.Add(new RadComboBoxItem(usuario.GrupoUsuario.Nombre, usuario.GrupoUsuario.GrupoUsuarioId.ToString()));
            rdcGrupo.SelectedValue = usuario.GrupoUsuario.GrupoUsuarioId.ToString();
            //
            if (usuario.Empresa != null)
            {
                rdcEmpresa.Items.Clear();
                rdcEmpresa.Items.Add(new RadComboBoxItem(usuario.Empresa.Nombre, usuario.Empresa.EmpresaId.ToString()));
                rdcEmpresa.SelectedValue = usuario.Empresa.EmpresaId.ToString();
                if (usuario.Instalacion != null)
                {
                    rdcInstalacion.Items.Clear();
                    rdcInstalacion.Items.Add(new RadComboBoxItem(usuario.Instalacion.Nombre, usuario.Instalacion.InstalacionId.ToString()));
                    rdcInstalacion.SelectedValue = usuario.Instalacion.InstalacionId.ToString();
                }
            }
            //
            // Asignar el Login  
            txtLogin.Text = usuario.Login;
        }

        protected void UnloadData(Usuario usuario)
        {
            usuario.Nombre = txtNombre.Text;
            // Grupo de usuario asociado
            usuario.GrupoUsuario = CntLainsaSci.GetGrupoUsuario(int.Parse(rdcGrupo.SelectedValue), ctx);
            usuario.Login = txtLogin.Text;
            if (rdcInstalacion.SelectedValue != "")
            {
                // La instalación marca la empresa
                instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue),ctx);
                if (instalacion != null) 
                {
                    usuario.Instalacion = instalacion;
                    usuario.Empresa = instalacion.Empresa;
                }
            }
            else
            {
                if (rdcEmpresa.SelectedValue != "")
                {
                    empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
                    usuario.Empresa = empresa;
                    usuario.Instalacion = null;
                }
            }
            if (txtPassword.Text != "")
            {
                usuario.Password = CntAutenticacion.GetHashCode(txtPassword.Text);
            }
        }
        #endregion

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

        protected void rdcGrupo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text == "") return;
            RadComboBox combo = (RadComboBox)sender;
            combo.Items.Clear();
            foreach (GrupoUsuario gpu in CntLainsaSci.GetGruposUsuarios(e.Text, ctx))
            {
                combo.Items.Add(new RadComboBoxItem(gpu.Nombre, gpu.GrupoUsuarioId.ToString()));
            }
        }

        protected void rdcGrupo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
        }
        
        protected void ControlDeError(Exception ex)
        {
            ErrorControl eC = new ErrorControl();
            eC.ErrorUsuario = Usuario;
            eC.ErrorProcess = permiso.Proceso;
            eC.ErrorDateTime = DateTime.Now;
            eC.ErrorException = ex;
            Session["ErrorControl"] = eC;
            RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
        }
    }
}