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
    public partial class IncidenciaForm : System.Web.UI.Page
    {
        #region Variables declaration
        
        LainsaSci ctx = null; // openaccess context used in this page
        Usuario usuario = null; // Usuario loged
        Permiso permiso = null;
        string caller = ""; // who calls the form
        Dispositivo dispositivo = null;
        Incidencia incidencia = null;
        bool newRecord = true;
        string modo = "";
        
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
            permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "Dispositivogrid", ctx);
            if (permiso == null)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
                RadNotification1.Show();
                RadAjaxManager1.ResponseScripts.Add("closeWindow();");
            }
            btnAccept.Visible = permiso.Modificar;
            // Si esto no va antes de DispositivoID tendrás problemas.
            if (Request.QueryString["Caller"] != null)
            {
                caller = Request.QueryString["Caller"];
                caller = caller.Replace("'", "");
            }
            // Is it a new record or not?
            if (Request.QueryString["IncidenciaId"] != null)
            {
                incidencia = CntLainsaSci.GetIncidencia(int.Parse(Request.QueryString["IncidenciaId"]), ctx);
                dispositivo = incidencia.Dispositivo;
                
                LoadData(incidencia);
                Title = String.Format("Incidencia ID:{0}",incidencia.IncidenciaId);
                LoadIncidenciaEvolucionFrame(incidencia);
                newRecord = false;
            }
            else
            {
                txtUsuario.Text = usuario.Nombre;
                txtFechaApertura.Text = DateTime.Now.ToString();
                LoadIncidenciaEvolucionFrame(null);
                CargarEstados(null);
                CargarPrioridades(null);
                CargarResponsables(null);
            }
            if (Request.QueryString["DispositivoId"] != null)
            {
                dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
                rdcDispositivo.Items.Clear();
                rdcDispositivo.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(dispositivo), dispositivo.DispositivoId.ToString()));
                rdcDispositivo.SelectedValue = dispositivo.DispositivoId.ToString();
                rdcDispositivo.Enabled = false;
                imgDispositivo.Enabled = false;
                imgDispositivo.Visible = false;
            }
            if (Request.QueryString["Modo"] != null)
            {
                modo = Request.QueryString["Modo"];
                if (modo == "S")
                {
                    // en silencio
                    btnAccept.Visible = false;
                }
            }
            // control de skin
            if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

            if(newRecord) {
                this.multi.Visible = true;
                tr_evoluciones.Visible = false;
            } else {
                this.multi.Visible = false;
                tr_evoluciones.Visible = true;
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
            if (!DataOk())
                return;

            if(rdcDispositivoMulti.Items.Count > 0) {
                for(int i = 0;i<rdcDispositivoMulti.Items.Count;i++){
                    incidencia = new Incidencia();
                    UnloadData(incidencia,i);
                    ctx.Add(incidencia);
                    ctx.SaveChanges();

                    }

            } else {
                if(newRecord) {
                    incidencia = new Incidencia();
                }
                UnloadData(incidencia,-1);
                if(newRecord) {
                    ctx.Add(incidencia);
                }
                ctx.SaveChanges();
            }

            if (!incidencia.Operativo && !incidencia.SiguePlan)
            {
                RadWindowManager1.RadConfirm("Ha elegido no seguir planificando revisiones para este dispositivo. ¿Quiere borrar las no realizadas?", "askRevision", null, null, null, "AVISO");
                return;
            }                
            if (newRecord)
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
            }
            else
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
            }
        }
            
        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        
        #endregion
        
        #region Auxiliary
            
        protected void LoadData(Incidencia incidencia)
        {
            lblFechaApertura.Visible = true;
            txtFechaApertura.Visible = true;
            if (!CntLainsaSci.FechaNula(incidencia.FechaApertura))
                txtFechaApertura.Text = incidencia.FechaApertura.ToString();
            if (!CntLainsaSci.FechaNula(incidencia.FechaCierre))
                txtFechaCierre.Text = incidencia.FechaCierre.ToString();
            if (!CntLainsaSci.FechaNula(incidencia.FechaPrevista))
                rdpFechaPrevista.SelectedDate = incidencia.FechaPrevista; 
            txtUsuario.Text = incidencia.Usuario.Nombre;
            txtComentarios.Text = incidencia.Comentarios;
            chkOperativo.Checked = !incidencia.Operativo;
            chkSiguePlan.Checked = !incidencia.SiguePlan;
            if (dispositivo != null)
            {
                rdcDispositivo.Items.Clear();
                rdcDispositivo.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(dispositivo), dispositivo.DispositivoId.ToString()));
                rdcDispositivo.SelectedValue = dispositivo.DispositivoId.ToString();
                rdcDispositivo.Enabled = false;
                imgDispositivo.Enabled = false;
                imgDispositivo.Visible = false;
            }
            CargarEstados(incidencia);
            CargarPrioridades(incidencia);
            CargarResponsables(incidencia);
        }
            
        protected bool DataOk()
        {
            string m = ""; // para mensajes
            if (rdcDispositivo.SelectedValue == "" && rdcDispositivoMulti.Items.Count==0)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "NcDispositivo"));
                RadNotification1.Show();
                return false;
            }
            if (rdcEstado.SelectedValue == "")
            {
                m = "Debe escoger un estado";
                RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                return false;
            }
            else
            {
                Estado nuevoEstado = CntLainsaSci.GetEstado(int.Parse(rdcEstado.SelectedValue), ctx);

                if(txtFechaCierre.Text != "" && !nuevoEstado.EnCierre ) // && (rdcEstado.SelectedValue != CntLainsaSci.GetEstadoCierre(ctx, incidencia.Dispositivo.Instalacion.Empresa).EstadoId.ToString()))
                {
                    m = "No se puede asignar este estado a una incidencia cerrada";
                    RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                    return false;
                }
/*                if(txtFechaCierre.Text == "" && nuevoEstado.EnCierre ) // && (rdcEstado.SelectedValue == CntLainsaSci.GetEstadoCierre(ctx, incidencia.Dispositivo.Instalacion.Empresa).EstadoId.ToString()))
                {
                    m = "No se puede asignar este estado a una incidencia abierta";
                    RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                    return false;
                }
 * */
            }
            if (rdcPrioridad.SelectedValue == "")
            {
                m = "Debe escoger una prioridad";
                RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                return false;
            }
            if (rdcResponsable.SelectedValue == "")
            {
                m = "Debe escoger un responsable";
                RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                return false;
            }
        
            return true;
        }
                
        protected void UnloadData(Incidencia incidencia,int i)
        {

            if(i >= 0) {
                    dispositivo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivoMulti.Items[i].Value), ctx);
            } else {
                if(rdcDispositivo.SelectedValue != "")
                    dispositivo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivo.SelectedValue), ctx);
            }

            if (rdcDispositivo.SelectedValue != "")
                dispositivo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivo.SelectedValue), ctx);
            if (rdpFechaPrevista.SelectedDate != null)
                incidencia.FechaPrevista = (DateTime)rdpFechaPrevista.SelectedDate;
            incidencia.Usuario = usuario;
            if (CntLainsaSci.FechaNula(incidencia.FechaApertura))
                incidencia.FechaApertura = DateTime.Now;
            incidencia.Dispositivo = dispositivo;
            incidencia.Comentarios = txtComentarios.Text;
            incidencia.Operativo = !chkOperativo.Checked;
            dispositivo.Operativo = !chkOperativo.Checked;
            incidencia.SiguePlan = !chkSiguePlan.Checked;
            dispositivo.SiguePlan = incidencia.SiguePlan;
            Estado nuevoEstado = CntLainsaSci.GetEstado(int.Parse(rdcEstado.SelectedValue), ctx);

            if(incidencia.Estado != nuevoEstado && nuevoEstado.EnCierre) {
                incidencia.FechaCierre= DateTime.Now;
            }
            incidencia.Estado = nuevoEstado;
            incidencia.Prioridad = CntLainsaSci.GetPrioridad(int.Parse(rdcPrioridad.SelectedValue), ctx);
            incidencia.Responsable = CntLainsaSci.GetResponsable(int.Parse(rdcResponsable.SelectedValue), ctx);
        }

        protected void UnloadDispositivo()
        {
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
            
        protected void LoadIncidenciaEvolucionFrame(Incidencia i)
        {
            // si no hay incidencia no hay nada que cargar
            if (i == null)
                return;
            // obtenemos el frame en el que se muestran las páginas.
            HtmlControl frame = (HtmlControl)this.FindControl("ifTabIncidencia");
            string url;
            url = String.Format("IncidenciaEvolucionGrid.aspx?Caller='IncidenciaForm'&InFrame=S&IncidenciaId={0}", i.IncidenciaId);
            frame.Attributes["src"] = url;
        }
        
        #endregion
            
        #region Manejo de combos
            
        protected void CargarEstados(Incidencia i)
        {
            rdcEstado.Items.Clear();
            foreach (Estado e in CntLainsaSci.GetEstados(usuario,ctx))
            {
                rdcEstado.Items.Add(new RadComboBoxItem(e.Nombre + " (" + e.Empresa.Nombre + ")", e.EstadoId.ToString()));
            }
            rdcEstado.Items.Add(new RadComboBoxItem(" ", ""));
            rdcEstado.SelectedValue = "";
            if (i != null && i.Estado != null)
                rdcEstado.SelectedValue = i.Estado.EstadoId.ToString();
        }
            
        protected void CargarPrioridades(Incidencia i)
        {
            rdcPrioridad.Items.Clear();
            foreach (Prioridad e in CntLainsaSci.GetPrioridads(usuario,ctx))
            {
                rdcPrioridad.Items.Add(new RadComboBoxItem(e.Nombre + " (" + e.Empresa.Nombre + ")", e.PrioridadId.ToString()));
            }
            rdcPrioridad.Items.Add(new RadComboBoxItem(" ", ""));
            rdcPrioridad.SelectedValue = "";
            if (i != null && i.Prioridad != null)
                rdcPrioridad.SelectedValue = i.Prioridad.PrioridadId.ToString();
        }
            
        protected void CargarResponsables(Incidencia i)
        {
            rdcResponsable.Items.Clear();
            foreach (Responsable e in CntLainsaSci.GetResponsables(usuario,ctx))
            {
                rdcResponsable.Items.Add(new RadComboBoxItem(e.Nombre + " (" + e.Empresa.Nombre + ")", e.ResponsableId.ToString()));
            }
            rdcResponsable.Items.Add(new RadComboBoxItem(" ", ""));
            rdcResponsable.SelectedValue = "";
            if (i != null && i.Responsable != null)
                rdcResponsable.SelectedValue = i.Responsable.ResponsableId.ToString();
        }

        #endregion
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            // llamado si hay que eliminar revisiones pendientes.
            if (e.Argument == "true")
            {
                dispositivo = incidencia.Dispositivo;
                dispositivo.Operativo = false;
                dispositivo.SiguePlan = false;
                CntLainsaSci.EliminarRevisionesPendientes(dispositivo, ctx);
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", caller));
            }
        }
    }
}