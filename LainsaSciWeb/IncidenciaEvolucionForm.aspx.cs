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
    public partial class IncidenciaEvolucionForm : System.Web.UI.Page
    {
        #region Variables declaration
        LainsaSci ctx = null; // openaccess context used in this page
        Usuario usuario = null; // Usuario loged
        Permiso permiso = null;
        string caller = ""; // who calls the form
        Dispositivo dispositivo = null;
        Incidencia incidencia = null;
        IncidenciaEvolucion incidenciaEvo = null;
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
            permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "IncidenciaGrid", ctx);
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
            if (Request.QueryString["IncidenciaEvolucionId"] != null)
            {
                incidenciaEvo= CntLainsaSci.GetIncidenciaEvolucion(int.Parse(Request.QueryString["IncidenciaEvolucionId"]), ctx);
                incidencia = incidenciaEvo.Incidencia;
                dispositivo = incidencia.Dispositivo;
                LoadData(incidenciaEvo);
                Title = String.Format("Inc. Evolución ID:{0}",incidenciaEvo.IncidenciaEvolucionId);
                newRecord = false;
            }
            else
            {
                 txtUsuario.Text = usuario.Nombre;
                 txtFechaEvolucion.Text = DateTime.Now.ToString();
            }
            if (Request.QueryString["IncidenciaId"] != null)
            {
                incidencia = CntLainsaSci.GetIncidencia(int.Parse(Request.QueryString["IncidenciaId"]), ctx);
                dispositivo = incidencia.Dispositivo;
                txtDispositivo.Text = dispositivo.Nombre;

            }
            if (Request.QueryString["DispositivoId"] != null)
            {
                dispositivo = CntLainsaSci.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
                txtDispositivo.Text = dispositivo.Nombre;
                
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
        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            if (!DataOk())
                return;
            if (newRecord)
                incidenciaEvo = new IncidenciaEvolucion();
            UnloadData(incidenciaEvo);
            if (newRecord)
            {
                ctx.Add(incidenciaEvo);
            }
            ctx.SaveChanges();
            // si han accedido por esta opción quiere decir que la incidencia se cerrará
            incidencia = incidenciaEvo.Incidencia;
            incidencia.FechaCierre = incidenciaEvo.FechaEvolucion;
            incidencia.Operativo = incidenciaEvo.Operativo;
            incidencia.Estado = CntLainsaSci.GetEstadoCierre(ctx,incidencia.Dispositivo.Instalacion.Empresa);
            // hay que tocar el dispositivo si lo vamos a dejar operativo
            incidencia.Dispositivo.Operativo = incidencia.Operativo;
            ctx.SaveChanges();
            // si ha cerrado querra cargar toda la incidencia para ver el efecto (OpenOutside)
            string url = String.Format("IncidenciaForm.aspx?Caller=IncidenciaGrid&IncidenciaId={0}", incidencia.IncidenciaId);
            string name = "IncidenciaForm";
            string js = String.Format("openOutSideClose('{0}', '{1}');", url, name);
            RadAjaxManager1.ResponseScripts.Add(js);
        }
        protected void btnAccept_Click(object sender, ImageClickEventArgs e)
        {
            if (!DataOk())
                return;
            if (newRecord)
                incidenciaEvo = new IncidenciaEvolucion();
            UnloadData(incidenciaEvo);
            if (newRecord)
            {
               ctx.Add(incidenciaEvo);
            }
            ctx.SaveChanges();

            if (newRecord)
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", "IncidenciaForm"));
            }
            else
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", "IncidenciaEvolucionForm"));
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        #endregion
        #region Auxiliary
        protected void LoadData(IncidenciaEvolucion incidenciaEvo)
        {
            lblFechaEvolucion.Visible = true;
            txtFechaEvolucion.Visible = true;
            if (!CntLainsaSci.FechaNula(incidenciaEvo.FechaEvolucion))
                txtFechaEvolucion.Text = incidenciaEvo.FechaEvolucion.ToString();
            txtUsuario.Text = incidenciaEvo.Usuario.Nombre;
            txtComentarios.Text = incidenciaEvo.Comentarios;
            chkOperativo.Checked = !incidenciaEvo.Operativo;
            if (dispositivo != null)
            {
                txtDispositivo.Text = dispositivo.Nombre;
            }
        }
        protected bool DataOk()
        {
            // TODO: hay que controlar las verificaciones de este formulario

            return true;
        }

        protected void UnloadData(IncidenciaEvolucion incidenciaEvo)
        {
            incidenciaEvo.Usuario = usuario;
            incidenciaEvo.FechaEvolucion = DateTime.Now;
            incidenciaEvo.Comentarios = txtComentarios.Text;
            incidenciaEvo.Operativo = !chkOperativo.Checked;
            incidenciaEvo.Incidencia = incidencia;
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