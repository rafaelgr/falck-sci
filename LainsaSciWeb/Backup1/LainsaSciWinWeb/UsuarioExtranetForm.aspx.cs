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
    public partial class UsuarioExtranetForm : System.Web.UI.Page
    {
        #region Variables declaration
        LainsaSci ctx = null; // openaccess context used in this page
        Usuario usuariolog = null; // Usuario loged
        Permiso permiso = null; //
        string caller = ""; // who calls the form
        UsuarioExtranet usuarioextranet = null;
        Empresa empresa = null;
        Instalacion instalacion = null;
        bool newRecord = true;
        #endregion
        #region Init, load, unload events
        protected void Page_Init(object sender, EventArgs e)
        {
            // it gets an appropiate context (LainsaSciCTX -> web.config)
            ctx = new LainsaSci("LainsaSciCTX");
            // verify if a Usuario is logged
            usuariolog = CntWinWeb.IsSomeoneLogged(this, ctx);
            if (usuariolog == null)
                Response.Redirect("Default.aspx");
            else
                Session["UsuarioId"] = usuariolog.UsuarioId;
            //
            permiso = CntLainsaSci.GetPermiso(usuariolog.GrupoUsuario, "usuarioextranetgrid", ctx);
            if (permiso == null)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
                RadNotification1.Show();
                RadAjaxManager1.ResponseScripts.Add("closeWindow();");
            }
            btnAccept.Visible = permiso.Modificar;

            if (Request.QueryString["EmpresaId"] != null)
            {
                empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
            }
            if (Request.QueryString["RevisionId"] != null)
            {
                instalacion = CntLainsaSci.GetInstalacion(int.Parse(Request.QueryString["RevisionId"]), ctx);
            }
            // Is it a new record or not?
            if (Request.QueryString["UsuarioExtranetId"] != null)
            {
                usuarioextranet = CntLainsaSci.GetUsuarioExtranet(int.Parse(Request.QueryString["UsuarioExtranetId"]), ctx);
                LoadData(usuarioextranet);
                newRecord = false;
            }
            else
            {
                if (instalacion != null)
                {
                    rdcInstalacion.Items.Clear();
                    rdcInstalacion.Items.Add(new RadComboBoxItem(instalacion.Nombre, instalacion.InstalacionId.ToString()));
                    rdcInstalacion.SelectedValue = instalacion.InstalacionId.ToString();
                    empresa = instalacion.Empresa;
                }
                if (empresa != null)
                {
                    rdcEmpresa.Items.Clear();
                    rdcEmpresa.Items.Add(new RadComboBoxItem(empresa.Nombre, empresa.EmpresaId.ToString()));
                    rdcEmpresa.SelectedValue = empresa.EmpresaId.ToString();
                }

            }
            if (Request.QueryString["Caller"] != null)
            {
                caller = Request.QueryString["Caller"];
                caller = caller.Replace("'", "");
            }
            // control de skin
            if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Title = "Usuario extranet";
            }
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
                    usuarioextranet = new UsuarioExtranet();
                UnloadData(usuarioextranet);
                if (newRecord)
                    ctx.Add(usuarioextranet);
                ctx.SaveChanges();
                if (newRecord)
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
                else
                {
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
                    //RadAjaxManager1.ResponseScripts.Add(String.Format("MyAlert('{0}');", caller));
                }
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

        protected void LoadData(UsuarioExtranet usuarioext)
        {
            txtUsuarioId.Text = usuarioext.UsuarioExtranetId.ToString();
            txtNombre.Text = usuarioext.Nombre;
            // Cargar el grupo al que pertenece el usuario
            if (usuarioext.Empresa != null)
            {
                rdcEmpresa.Items.Clear();
                rdcEmpresa.Items.Add(new RadComboBoxItem(usuarioext.Empresa.Nombre, usuarioext.Empresa.EmpresaId.ToString()));
                rdcEmpresa.SelectedValue = usuarioext.Empresa.EmpresaId.ToString();
            }
            if (usuarioext.Instalacion != null)
            {
                rdcInstalacion.Items.Clear();
                rdcInstalacion.Items.Add(new RadComboBoxItem(usuarioext.Instalacion.Nombre, usuarioext.Instalacion.InstalacionId.ToString()));
                rdcInstalacion.SelectedValue = usuarioext.Instalacion.InstalacionId.ToString();
            }
            // Asignar el Login  
            txtLogin.Text = usuarioext.Login;
            txtEmail.Text = usuarioext.Correo;
        }

        protected void UnloadData(UsuarioExtranet usuarioext)
        {
            usuarioext.Nombre = txtNombre.Text;
            // Grupo de usuario asociado
            //usuarioext.Global = chkGlobal.Checked;
            //if (!usuarioext.Global)
            //{
                usuarioext.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
                if (rdcInstalacion.SelectedValue != "")
                {
                    usuarioext.Instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
                }
                else
                    usuarioext.Instalacion = null;
            //}
            //else
            //{
            //    usuarioext.Empresa = null;
            //    usuarioext.Instalacion = null;
            //}
            usuarioext.Login = txtLogin.Text;
            usuarioext.Correo = txtEmail.Text;
            if (txtPassword.Text != "")
            {
                usuarioext.Password = CntAutenticacion.GetHashCode(txtPassword.Text);
            }
        }
        #endregion

        protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text == "")
                return;
            RadComboBox combo = (RadComboBox)sender;
            combo.Items.Clear();
            foreach (Empresa emp in CntLainsaSci.GetEmpresas(e.Text, usuariolog, ctx))
            {
                combo.Items.Add(new RadComboBoxItem(emp.Nombre, emp.EmpresaId.ToString()));
            }
        }

        protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value != "")
            {
                Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Value), ctx);
                CargaInstalaciones(empresa);
            }
        }

        protected void ControlDeError(Exception ex)
        {
            ErrorControl eC = new ErrorControl();
            eC.ErrorUsuario = usuariolog;
            eC.ErrorProcess = permiso.Proceso;
            eC.ErrorDateTime = DateTime.Now;
            eC.ErrorException = ex;
            Session["ErrorControl"] = eC;
            RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
        }

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            // es llamado desde la selección de una empresa 
            Empresa empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Argument), ctx);
            CargaInstalaciones(empresa);
        }

        protected void CargaInstalaciones(Empresa empresa)
        {
            if (empresa == null)
                return;
            rdcInstalacion.Items.Clear();
            foreach (Instalacion instalacion in empresa.Instalaciones)
            {
                rdcInstalacion.Items.Add(new RadComboBoxItem(instalacion.Nombre, instalacion.InstalacionId.ToString()));
            }
            rdcInstalacion.Items.Add(new RadComboBoxItem("",""));
            rdcInstalacion.SelectedValue = "";
        }
    }
}