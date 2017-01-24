using System;
using System.Web;
using System.Collections.Generic;
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

namespace LainsaSciWinWeb {
    public partial class UsuarioEmpresaForm : System.Web.UI.Page {
        #region Variables declaration
        LainsaSci ctx = null; // openaccess context used in this page
        Usuario Usuario = null; // Usuario loged
        Permiso permiso = null; //
        UsuarioEmpresa ue = null;
        string caller = ""; // who calls the form
        Usuario usuario = null;
        bool newRecord = true;
        Empresa empresa = null;
        Instalacion instalacion = null;
        #endregion
        #region Init, load, unload events
        protected void Page_Init(object sender, EventArgs e) {
            // it gets an appropiate context (LainsaSciCTX -> web.config)
            ctx = new LainsaSci("LainsaSciCTX");
            // verify if a Usuario is logged
            Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
            ue = new UsuarioEmpresa();
            if(Usuario == null)
                Response.Redirect("Default.aspx");
            else
                Session["UsuarioId"] = Usuario.UsuarioId;
            //
            permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "grupousuariogrid", ctx);
            if(permiso == null) {
                
              
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
                RadNotification1.Show();
                RadAjaxManager1.ResponseScripts.Add("closeWindow();");

            }
            btnAccept.Visible = permiso.Modificar;
            // Is it a new record or not?
            if(Request.QueryString["UsuarioId"] != null) {
                usuario = CntLainsaSci.GetUsuario(int.Parse(Request.QueryString["UsuarioId"]), ctx);
                LoadData(usuario);
                newRecord = false;
             
            }
            if(Request.QueryString["Caller"] != null) {
                caller = Request.QueryString["Caller"];
            }
            // control de skin

            if(Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

            this.rdcEmpresa.Items.Clear();
                foreach (Empresa ei in ctx.Empresas)
                {
                    rdcEmpresa.Items.Add(new RadComboBoxItem(ei.Nombre, ei.EmpresaId.ToString()));
                }

        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void Page_Unload(object sender, EventArgs e) {
            // it closes context in order to release resources
            if(ctx != null)
                ctx.Dispose();
        }
        #endregion
        /*
        protected void btnAccept_Click(object sender, ImageClickEventArgs e) {
            try {
                if(!DataOk())
                    return;
                if(newRecord)
                    usuario = new Usuario();
                UnloadData(usuario);
                if(newRecord)
                    ctx.Add(usuario);
                ctx.SaveChanges();
                if(newRecord)
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
                else
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
            } catch(Exception ex) {
                ControlDeError(ex);
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e) {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        */

        SortedList<string, KeyValuePair<string, SortedList<string, string>>> lstEmp = new SortedList<string, KeyValuePair<string, SortedList<string, string>>>();


        #region Auxiliary
        protected bool DataOk() {
       
            //if (rdcGrupoTrabajo.SelectedValue == "")
            //{
            //    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
            //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
            //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "TrabajoGroupNeeded"));
            //    RadNotification1.Show();
            //    return false;
            //}

            /*
            if(txtPassword.Text != "" || txtPassword2.Text != "") {
                if(txtPassword.Text != txtPassword2.Text) {
                    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "PasswordDoesntMatch"));
                    RadNotification1.Show();
                    return false;
                }
            }*/
            return true;
        }

        protected void LoadData(Usuario usuario) {/*
            txtUsuarioId.Text = usuario.UsuarioId.ToString();
            txtNombre.Text = usuario.Nombre;
            // Cargar el grupo al que pertenece el usuario
            rdcGrupo.Items.Clear();
            rdcGrupo.Items.Add(new RadComboBoxItem(usuario.GrupoUsuario.Nombre, usuario.GrupoUsuario.GrupoUsuarioId.ToString()));
            rdcGrupo.SelectedValue = usuario.GrupoUsuario.GrupoUsuarioId.ToString();
            // Cargar el grupo de trabajo al que pertenece el usuario
            if(usuario.GrupoTrabajo != null) {
                rdcGrupoTrabajo.Items.Clear();
                rdcGrupoTrabajo.Items.Add(new RadComboBoxItem(usuario.GrupoTrabajo.Nombre, usuario.GrupoTrabajo.GrupoTrabajoId.ToString()));
                rdcGrupoTrabajo.SelectedValue = usuario.GrupoTrabajo.GrupoTrabajoId.ToString();
            }

            string empresaID = "";
            string instalacionId = "";

            foreach(UsuarioEmpresa ue in usuario.UsuarioEmpresas) {
                if(ue.Empresa != null) {
                    empresaID = ue.Empresa.EmpresaId.ToString();
                } else {
                    empresaID = "";
                }
                if(ue.Instalacion != null) {
                    instalacionId = ue.Instalacion.InstalacionId.ToString();
                } else {
                    instalacionId = "";
                }

                if(empresaID == "") {
                    foreach(Empresa ei in ctx.Empresas) {
                        if(!lstEmp.ContainsKey(ei.EmpresaId.ToString())) {
                            KeyValuePair<string, SortedList<string, string>> p = new KeyValuePair<string, SortedList<string, string>>(ei.Nombre, new SortedList<string, string>());
                            lstEmp.Add(ei.EmpresaId.ToString(), p);
                        }

                        foreach(Instalacion ie in ei.Instalaciones) {
                            if(!lstEmp[ei.EmpresaId.ToString()].Value.ContainsKey(ie.InstalacionId.ToString())) {
                                lstEmp[ei.EmpresaId.ToString()].Value.Add(ie.InstalacionId.ToString(), ie.Nombre);
                            }
                        }
                    }
                } else {
                    if(!lstEmp.ContainsKey(empresaID)) {
                        KeyValuePair<string, SortedList<string, string>> p = new KeyValuePair<string, SortedList<string, string>>(ue.Empresa.Nombre, new SortedList<string, string>());
                        lstEmp.Add(empresaID, p);
                    }

                    if(instalacionId == "") {
                        foreach(Instalacion ie in ue.Empresa.Instalaciones) {
                            if(!lstEmp[empresaID].Value.ContainsKey(ie.InstalacionId.ToString())) {
                                lstEmp[empresaID].Value.Add(ie.InstalacionId.ToString(), ie.Nombre);
                            }
                        }
                    } else {
                        if(!lstEmp[empresaID].Value.ContainsKey(instalacionId)) {
                            lstEmp[empresaID].Value.Add(instalacionId, ue.Instalacion.Nombre);
                        }
                    }

                }

                //
                // Asignar el Login  
                txtLogin.Text = usuario.Login;
            }
                                                   * */
        }

        protected void UnloadData(Usuario usuario) {
         /*   usuario.Nombre = txtNombre.Text;
            // Grupo de usuario asociado
            usuario.GrupoUsuario = CntLainsaSci.GetGrupoUsuario(int.Parse(rdcGrupo.SelectedValue), ctx);
            // Grupo de trabajo asociado
            if(rdcGrupoTrabajo.SelectedValue != "")
                usuario.GrupoTrabajo = CntLainsaSci.GetGrupoTrabajo(int.Parse(rdcGrupoTrabajo.SelectedValue), ctx);
            else
                usuario.GrupoTrabajo = null;
            usuario.Login = txtLogin.Text;/*
            if (rdcInstalacion.SelectedValue != "")
            {
                // La instalación marca la empresa
                instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue),ctx);
                /*
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
            }* *//*
            if(txtPassword.Text != "") {
                usuario.Password = CntAutenticacion.GetHashCode(txtPassword.Text);
            }*/
        }
        #endregion
        /*
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
        
        pr*/
        protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rdcEmpresa.SelectedValue != "")
            {
               empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
            rdcInstalacion.Items.Clear();
            if (empresa != null)
                foreach (Instalacion ins in empresa.Instalaciones)
                {
                    rdcInstalacion.Items.Add(new RadComboBoxItem(ins.Nombre, ins.InstalacionId.ToString()));
                }
            }

        }


        /*
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
        }*/
        protected void btnCancel_Click(object sender, ImageClickEventArgs e) {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }

        protected void btnAccept_Click(object sender, ImageClickEventArgs e) {
            try {

           //     if(!DataOk())
           //         return;
                if(rdcEmpresa.SelectedValue != "") {
                    ue.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
                    if (rdcInstalacion.SelectedValue != "") ue.Instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
                    ue.Usuario = usuario;
                    ctx.Add(ue);
                    ctx.SaveChanges();
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
                }          
                else
                    RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
            } catch(Exception ex) {
                ControlDeError(ex);
            }
        }


        protected void ControlDeError(Exception ex) {
            ErrorControl eC = new ErrorControl();
            eC.ErrorUsuario = Usuario;
            eC.ErrorProcess = permiso.Proceso;
            eC.ErrorDateTime = DateTime.Now;
            eC.ErrorException = ex;
            Session["ErrorControl"] = eC;
            //RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
        }

        protected void rdcGrupoTrabajo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e) {
            if(e.Text == "") return;
            RadComboBox combo = (RadComboBox)sender;
            combo.Items.Clear();
            foreach(GrupoTrabajo gpu in CntLainsaSci.GetGruposTrabajos(e.Text, ctx)) {
                combo.Items.Add(new RadComboBoxItem(gpu.Nombre, gpu.GrupoTrabajoId.ToString()));
            }
        }

     
    }
}