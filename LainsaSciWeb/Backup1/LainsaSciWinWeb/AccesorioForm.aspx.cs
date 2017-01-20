using System;
using System.Web;
using System.Web.UI;
using DosimetriaModelo;
using DosimetriaWinWeb;
using Telerik.OpenAccess;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class AccesorioForm : System.Web.UI.Page
{
    #region Variables declaration
    Dosimetria ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Accesorio accesorio = null;
    //Dispositivo dispositivo = null;
    bool newRecord = true;
    #endregion
    #region Init, load, unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (DosimetriaCTX -> web.config)
        ctx = new Dosimetria("DosimetriaCTX");
        // verify if a Usuario is logged
        Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (Usuario == null)
            Response.Redirect("Deafult.aspx");
        else
            Session["UsuarioId"] = Usuario.UsuarioId;
        //
        // si llega aquí está autorizado
        permiso = CntDosimetria.GetPermiso(Usuario.GrupoUsuario, "Accesoriogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceDosimetria", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de AccesorioID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        //if (Request.QueryString["DispositivoId"] != null)
        //{
        //    dispositivo = CntDosimetria.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
        //}
        // Is it a new record or not?
        if (Request.QueryString["AccesorioId"] != null)
        {
            accesorio = CntDosimetria.GetAccesorio(int.Parse(Request.QueryString["AccesorioId"]), ctx);
            LoadData(accesorio);
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
            if (!DataOk()) return;
            if (newRecord) accesorio = new Accesorio();
            UnloadData(accesorio);
            if (newRecord)
            {
                ctx.Add(accesorio);
                //if (dispositivo != null)
                //{
                //    AccesorioAsignado accAsignado = new AccesorioAsignado();
                //    accAsignado.Accesorio = accesorio;
                //    ctx.Add(accAsignado);
                //    dispositivo.AccesorioAsignados.Add(accAsignado);
                //}
            }
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
    protected void LoadData(Accesorio Accesorio)
    {
        txtAccesorioId.Text = Accesorio.AccesorioId.ToString();
        txtDesc.Text = Accesorio.Descripcion;
        // este lio del caller igual se puede solucionar con el InTab;
    }
    protected void UnloadData(Accesorio Accesorio)
    {
        Accesorio.Descripcion = txtDesc.Text;
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
