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

public partial class ResumenRevisionForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    ResumenRevision resumenRevision = null;
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
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "dispositivogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de ResumenRevisionID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        
        // Is it a new record or not?
        if (Request.QueryString["ResumenRevisionId"] != null)
        {
            resumenRevision = CntLainsaSci.GetResumenRevision(int.Parse(Request.QueryString["ResumenRevisionId"]), ctx);
            LoadData(resumenRevision);
            if (CntLainsaSci.HayRevisionesHechas(resumenRevision, ctx)) 
            {
                rdtFechaUltima.Enabled = false;
            }
            newRecord = false;
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
                resumenRevision = new ResumenRevision();
            UnloadData(resumenRevision);
            if (newRecord)
                ctx.Add(resumenRevision);
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
        return true;
    }

    protected void LoadData(ResumenRevision rr)
    {
        txtResumenRevisionId.Text = rr.ResumenRevisionId.ToString();
        txtDispositivo.Text = rr.Dispositivo.Nombre;
        txtPlantilla.Text = rr.PlantillaRevision.Descripcion;
        if (!CntLainsaSci.FechaNula(rr.FechaInicio))
            txtFechaInicio.Text = String.Format("{0:dd/MM/yyyy}", rr.FechaUltima);
        if (!CntLainsaSci.FechaNula(rr.FechaUltima))
            rdtFechaUltima.SelectedDate = rr.FechaUltima;
        if (!CntLainsaSci.FechaNula(rr.FechaSiguiente))
            txtFechaSiguiente.Text = String.Format("{0:dd/MM/yyyy}", rr.FechaSiguiente);
    }

    protected void UnloadData(ResumenRevision rr)
    {
        if (rdtFechaUltima.SelectedDate != null)
        {
            rr.FechaUltima = (DateTime)rdtFechaUltima.SelectedDate;
            if (CntLainsaSci.FechaNula(rr.FechaSiguiente)) rr.FechaInicio = rr.FechaUltima;
            CntLainsaSci.PlanificarRevisiones(rr, ctx);
        }
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