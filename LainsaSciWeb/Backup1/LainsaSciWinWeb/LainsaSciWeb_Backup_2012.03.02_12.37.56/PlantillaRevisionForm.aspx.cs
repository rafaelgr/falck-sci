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

public partial class PlantillaRevisionForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null; //
    string caller = ""; // who calls the form
    string inTab = "";
    PlantillaRevision plantillaRevision = null;
    TipoDispositivo tipo = null;
    int tipoId = 0;
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
        // si llega aquí está autorizado
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "PlantillaRevisiongrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;

        // Si esto no va antes de PlantillaRevisionID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        //
        CargarTiposPeriodo("");
        // Is it a new record or not?
        if (Request.QueryString["PlantillaId"] != null)
        {
            plantillaRevision = CntLainsaSci.GetPlantillaRevision(int.Parse(Request.QueryString["PlantillaId"]), ctx);
            LoadData(plantillaRevision);
            this.Title = String.Format("PlantillaRevision: {0}", plantillaRevision.Descripcion);
            newRecord = false;
        }
        if (Request.QueryString["TipoId"] != null)
        {
            tipoId = int.Parse(Request.QueryString["TipoId"]);
            tipo = CntLainsaSci.GetTipoDispositivo(tipoId, ctx);
            if (tipo != null)
            {
                rdcTipoDisp.Items.Clear();
                rdcTipoDisp.Items.Add(new RadComboBoxItem(tipo.Nombre, tipo.TipoId.ToString()));
                rdcTipoDisp.SelectedValue = tipo.TipoId.ToString();
                rdcTipoDisp.Enabled = false;
                imgbTipo.Enabled = false;
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
        try
        {
            if (!DataOk())
                return;
            if (newRecord)
                plantillaRevision = new PlantillaRevision();
            UnloadData(plantillaRevision);
            if (newRecord)
                ctx.Add(plantillaRevision);
            ctx.SaveChanges();
            if (newRecord)
            {
                string url = String.Format("PlantillaRevisionTab.aspx?Caller=PlantillaRevisionGrid&PlantillaId={0}", plantillaRevision.PlantillaId);
                string jCommand = String.Format("closeOpen('{0}','{1}');", url, "PlantillaRevisionTab");
                RadAjaxManager1.ResponseScripts.Add(jCommand);
                //RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');", caller));
            }
            else
                RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');", "PlantillaRevisionGrid"));
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
        if (txtDescripcion.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        if (rdcTipoDisp.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NecTipoDispositivo"));
            RadNotification1.Show();
            return false;
        }
        if (txtNumeroPeriodos.Value == 0)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                      (string)GetGlobalResourceObject("ResourceLainsaSci", "NumeroPeriodosNoCero"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }

    protected void LoadData(PlantillaRevision plantillaRevision)
    {
        txtPlantillaId.Text = plantillaRevision.PlantillaId.ToString();
        txtDescripcion.Text = plantillaRevision.Descripcion;
        // cargar el tipo de dispositivo
        rdcTipoDisp.Items.Clear();
        rdcTipoDisp.Items.Add(new RadComboBoxItem(plantillaRevision.TipoDispositivo.Nombre, plantillaRevision.TipoDispositivo.TipoId.ToString()));
        rdcTipoDisp.SelectedValue = plantillaRevision.TipoDispositivo.TipoId.ToString();
        //
        CargarTiposPeriodo(plantillaRevision.TipoPeriodo);
        txtNumeroPeriodos.Value = plantillaRevision.NumeroPeriodos;
        txtComentarios.Text = plantillaRevision.Comentarios;
        chkConSustitucion.Checked = plantillaRevision.ConSustitucion;
    }

    protected void UnloadData(PlantillaRevision plantillaRevision)
    {
        plantillaRevision.Descripcion = txtDescripcion.Text;
        plantillaRevision.TipoDispositivo = CntLainsaSci.GetTipoDispositivo(int.Parse(rdcTipoDisp.SelectedValue), ctx);
        plantillaRevision.TipoPeriodo = rdcTipoPeriodo.SelectedValue;
        plantillaRevision.NumeroPeriodos = (int)txtNumeroPeriodos.Value;
        plantillaRevision.Comentarios = txtComentarios.Text;
        plantillaRevision.ConSustitucion = chkConSustitucion.Checked;
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
    protected void rdcTipoDisp_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (TipoDispositivo tipo in CntLainsaSci.GetTiposDispositivo(e.Text, usuario,  ctx))
        {
            combo.Items.Add(new RadComboBoxItem(tipo.Nombre, tipo.TipoId.ToString()));
        }
    }

    protected void rdcTipoDisp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void CargarTiposPeriodo(string tipo)
    {
        rdcTipoPeriodo.Items.Clear();
        rdcTipoPeriodo.Items.Add(new RadComboBoxItem("Dias", "D"));
        rdcTipoPeriodo.Items.Add(new RadComboBoxItem("Semanas", "S"));
        rdcTipoPeriodo.Items.Add(new RadComboBoxItem("Meses", "M"));
        rdcTipoPeriodo.Items.Add(new RadComboBoxItem("Años", "A"));
        if (tipo != "") 
        {
            rdcTipoPeriodo.SelectedValue = tipo;
        }
    }
    #endregion
}