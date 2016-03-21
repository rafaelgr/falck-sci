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
    public partial class GrupoTrabajoForm : System.Web.UI.Page
    {
        #region Variables declaration
        LainsaSci ctx = null; // openaccess context used in this page
        Usuario Usuario = null; // Usuario loged
        Permiso permiso = null;
        string caller = ""; // who calls the form
        GrupoTrabajo TrabajoGroup = null;
        bool newRecord = true;
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
            // si llega aquí está autorizado
            permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "grupotrabajogrid", ctx);
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
            if (Request.QueryString["GrupoTrabajoId"] != null)
            {
                TrabajoGroup= CntLainsaSci.GetGrupoTrabajo(int.Parse(Request.QueryString["GrupoTrabajoId"]), ctx);
                LoadData(TrabajoGroup);
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
                if (!DataOk()) return;
                if (newRecord) TrabajoGroup = new GrupoTrabajo();
                UnloadData(TrabajoGroup);
                if (newRecord) ctx.Add(TrabajoGroup);
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
            if (txtNombre.Text == "")
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                    (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
                RadNotification1.Show();
                return false;
            }
            return true;
        }
        protected void LoadData(GrupoTrabajo gpTrabajo)
        {
            txtGrupoTrabajoId.Text = gpTrabajo.GrupoTrabajoId.ToString();
            txtNombre.Text = gpTrabajo.Nombre;
        }
        protected void UnloadData(GrupoTrabajo gpTrabajo)
        {
            gpTrabajo.Nombre = txtNombre.Text;
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
        #endregion
    }
}