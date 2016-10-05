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
            if(Request.QueryString["UsuarioId"] != null) {
                Grupo.Visible = true;
                GrupoTrabajo.Visible = true;
                AreaGrid.Visible = true;
                usuario = CntLainsaSci.GetUsuario(int.Parse(Request.QueryString["UsuarioId"]), ctx);
                LoadData(usuario);
                newRecord = false;
                RefreshGrid(true);
            } else {
                Grupo.Visible = false;
                GrupoTrabajo.Visible = false;
                AreaGrid.Visible = false;
            }
            if(Request.QueryString["new"] != null) {
                RefreshGrid(true);
            }
            if (Request.QueryString["Caller"] != null)
            {
                //RefreshGrid(true);
                caller = Request.QueryString["Caller"];
            }
            // control de skin
            
            if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

      

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
                RefreshGrid(true);
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
            RefreshGrid(true);
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        #endregion

        SortedList<string, KeyValuePair<string, SortedList<string, string>>> lstEmp = new SortedList<string, KeyValuePair<string, SortedList<string, string>>>();

        protected void RefreshGrid(bool rebind) {
            RadGrid1.DataSource = usuario.UsuarioEmpresas;
            if(rebind) RadGrid1.Rebind();
        }
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
            if(rdcGrupo.SelectedValue == "" && txtUsuarioId.Text != "")
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "UsuarioGroupNeeded"));
                RadNotification1.Show();
                return false;
            }
            //if (rdcGrupoTrabajo.SelectedValue == "")
            //{
            //    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
            //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
            //                                          (string)GetGlobalResourceObject("ResourceLainsaSci", "TrabajoGroupNeeded"));
            //    RadNotification1.Show();
            //    return false;
            //}
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

        protected void LoadData(Usuario usuario) {
            txtUsuarioId.Text = usuario.UsuarioId.ToString();
            txtNombre.Text = usuario.Nombre;
            // Cargar el grupo al que pertenece el usuario
            if(usuario.GrupoUsuario != null) {
                rdcGrupo.Items.Clear();
                rdcGrupo.Items.Add(new RadComboBoxItem(usuario.GrupoUsuario.Nombre, usuario.GrupoUsuario.GrupoUsuarioId.ToString()));
                rdcGrupo.SelectedValue = usuario.GrupoUsuario.GrupoUsuarioId.ToString();
            }// Cargar el grupo de trabajo al que pertenece el usuario
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
        }
        /*
        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e) {
            // we only process commands with a datasource (our image buttons)
            if(e.CommandSource == null)
                return;
            string typeOfControl = e.CommandSource.GetType().ToString();
            if(typeOfControl.Equals("System.Web.UI.WebControls.ImageButton")) {
                int id = 0;
                ImageButton imgb = (ImageButton)e.CommandSource;
                if(imgb.ID != "New" && imgb.ID != "Exit" && imgb.ID != "Generar")
                    id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
                switch(imgb.ID) {
                    case "Select":
                        break;
                    case "Edit":
                        break;
                    case "Delete":
                        try {
                            Revision revision = CntLainsaSci.GetRevision(id, ctx);
                            //PlanificacionRevision plan = revision.PlanificacionRevision;
                            //plan.Revisions.Remove(revision);
                            foreach(DatosRevision item in revision.DatosRevisions) {
                                CntLainsaSci.CTXEliminar(item, ctx);
                            }
                            CntLainsaSci.CTXEliminar(revision, ctx);
                            //plan.FechaUltimaRevision = CntLainsaSci.GetFUltimarevision(plan, ctx);
                            CntLainsaSci.CTXGuardar(ctx);

                            //RefreshGrid(true);
                    
                        } catch(Exception ex) {
                            ControlDeError(ex);
                        }
                        break;
                }
            }
        }*/

        protected void UnloadData(Usuario usuario)
        {
            usuario.Nombre = txtNombre.Text;
            // Grupo de usuario asociado
            if(rdcGrupo.SelectedValue != "") {
                usuario.GrupoUsuario = CntLainsaSci.GetGrupoUsuario(int.Parse(rdcGrupo.SelectedValue), ctx);
            } else {
                usuario.GrupoTrabajo = null;
            }
            // Grupo de trabajo asociado
            if (rdcGrupoTrabajo.SelectedValue != "")
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
            }* */
            if (txtPassword.Text != "")
            {
                usuario.Password = CntAutenticacion.GetHashCode(txtPassword.Text);
            }
        }
        #endregion

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

        protected void rdcGrupoTrabajo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text == "") return;
            RadComboBox combo = (RadComboBox)sender;
            combo.Items.Clear();
            foreach (GrupoTrabajo gpu in CntLainsaSci.GetGruposTrabajos(e.Text, ctx))
            {
                combo.Items.Add(new RadComboBoxItem(gpu.Nombre, gpu.GrupoTrabajoId.ToString()));
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e) {
            if(e.CommandSource == null)
                return;
            string typeOfControl = e.CommandSource.GetType().ToString();
            if(typeOfControl.Equals("System.Web.UI.WebControls.ImageButton")) {
                int id = 0;
                ImageButton imgb = (ImageButton)e.CommandSource;
                if(imgb.ID != "New" && imgb.ID != "Exit")
                    id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
                switch(imgb.ID) {
                    case "Select":
                        break;
                    case "Edit":
                        break;
                    case "Delete":
                        try {
                            UsuarioEmpresa ue = CntLainsaSci.GetUsuarioEmpresa(id,usuario, ctx);
                            CntLainsaSci.CTXEliminar(ue, ctx);
                            CntLainsaSci.CTXGuardar(ctx);
                            RefreshGrid(true);
                        } catch(Exception ex) {
                            ControlDeError(ex);
                        }
                        break;
                }
            }
        }
    }
}