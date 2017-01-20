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
                this.Title = String.Format("Incidencia");
                newRecord = false;
            }
            else
            {
                 txtUsuario.Text = usuario.Nombre;
                 txtFecha.Text = DateTime.Now.ToString();
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
            if (newRecord)
                incidencia = new Incidencia();
            UnloadData(incidencia);
            if (newRecord)
            {
               ctx.Add(incidencia);
            }
            ctx.SaveChanges();

            if (newRecord)
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
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
            lblFecha.Visible = true;
            txtFecha.Visible = true;
            if (!CntLainsaSci.FechaNula(incidencia.Fecha))
                txtFecha.Text = incidencia.Fecha.ToString();
            txtUsuario.Text = incidencia.Usuario.Nombre;
            txtComentarios.Text = incidencia.Comentarios;
            chkOperativo.Checked = !incidencia.Operativo;
            if (dispositivo != null)
            {
                rdcDispositivo.Items.Clear();
                rdcDispositivo.Items.Add(new RadComboBoxItem(CntLainsaSci.GetNomLargoModelo(dispositivo), dispositivo.DispositivoId.ToString()));
                rdcDispositivo.SelectedValue = dispositivo.DispositivoId.ToString();
                rdcDispositivo.Enabled = false;
                imgDispositivo.Enabled = false;
                imgDispositivo.Visible = false;
            }
        }
        protected bool DataOk()
        {

            if (rdcDispositivo.SelectedValue == "")
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "NcDispositivo"));
                RadNotification1.Show();
                return false;
            }
            return true;
        }

        protected void UnloadData(Incidencia incidencia)
        {
            if (rdcDispositivo.SelectedValue != "")
                dispositivo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivo.SelectedValue), ctx);
       
            incidencia.Usuario = usuario;
            incidencia.Fecha = DateTime.Now;
            incidencia.Dispositivo = dispositivo;
            incidencia.Comentarios = txtComentarios.Text;
            incidencia.Operativo = !chkOperativo.Checked;
            dispositivo.Operativo = !chkOperativo.Checked;
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

       #endregion

        protected void rdcDispositivo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {

        }
    }
}