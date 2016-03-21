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

public partial class ProcesoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Proceso proceso = null;
    bool newRecord = true;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "grupousuariogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // load the combo
        LoadProcesoPadreCombo();
        // Is it a new record or not?
        if (Request.QueryString["Nombre"] != null)
        {
            proceso = CntLainsaSci.GetProceso(Request.QueryString["Nombre"].ToString(), ctx);
            LoadData(proceso);
            newRecord = false;
        }
        if (Request.QueryString["Caller"] != null)
        {
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
                proceso = new Proceso();
            UnloadData(proceso);
            if (newRecord)
            {
                ctx.Add(proceso);
            }
            CntLainsaSci.CrearPermisos(proceso, ctx);
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
        return true;
    }

    protected void LoadData(Proceso proceso)
    {
        txtNombre.Text = proceso.Nombre;
        txtDescripcion.Text = proceso.Descripcion;
        // Cargar el ProcesoPadre al que pertenece el Proceso
        if (proceso.ProcesoPadre != null)
        {
            rdcProcesoPadre.SelectedValue = proceso.ProcesoPadre.Nombre;
        }
    }

    protected void UnloadData(Proceso Proceso)
    {
        Proceso.Nombre = txtNombre.Text;
        proceso.Descripcion = txtDescripcion.Text;
        // ProcesoPadre de Proceso asociado
        if (rdcProcesoPadre.SelectedValue != "")
            Proceso.ProcesoPadre = CntLainsaSci.GetProceso(rdcProcesoPadre.SelectedValue.ToString(), ctx);
    }
    #endregion

    protected void rdcProcesoPadre_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Proceso pp in CntLainsaSci.GetProcesos(e.Text,ctx))
        {
            combo.Items.Add(new RadComboBoxItem(pp.Nombre, pp.Nombre));
        }
    }

    protected void rdcProcesoPadre_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }
    protected void LoadProcesoPadreCombo()
    {
        rdcProcesoPadre.Items.Clear();
        foreach (Proceso p in CntLainsaSci.GetProcesos(ctx))
        {
            rdcProcesoPadre.Items.Add(new RadComboBoxItem(p.Nombre, p.Nombre));
        }
        rdcProcesoPadre.Items.Add(new RadComboBoxItem("",""));
        rdcProcesoPadre.SelectedValue = "";
    }

    protected void rdcProcesoPadre_SelectedIndexChanged1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
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
}