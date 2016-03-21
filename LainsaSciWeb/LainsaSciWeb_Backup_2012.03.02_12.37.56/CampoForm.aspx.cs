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

public partial class CampoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario Usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    PlantillaRevision plantilla = null;
    Campo campo = null;
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
        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "campogrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;

        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }

        if (Request.QueryString["PlantillaId"] != null)
        {
            plantilla = CntLainsaSci.GetPlantillaRevision(int.Parse(Request.QueryString["PlantillaId"]), ctx);
            CargaPlantilla(plantilla);
        }
        CargaTipos(new TipoCampo());
        // Is it a new record or not?
        if (Request.QueryString["CampoId"] != null)
        {
            campo = CntLainsaSci.GetCampo(int.Parse(Request.QueryString["CampoId"]), ctx);
            LoadData(campo);
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
            if (newRecord) campo = new Campo();
            UnloadData(campo);
            if (newRecord) ctx.Add(campo);
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
    protected void LoadData(Campo campo)
    {
        txtCampoId.Text = campo.CampoId.ToString();
        txtNombre.Text = campo.Nombre;
        txtPosicion.Text = campo.Posicion.ToString();
        CargaPlantilla(campo.PlantillaRevision);
        CargaTipos(campo.TipoCampo);
    }
    protected void UnloadData(Campo campo)
    {
        campo.Nombre = txtNombre.Text;
        campo.Posicion = int.Parse(txtPosicion.Text);

        campo.PlantillaRevision = CntLainsaSci.GetPlantillaRevision(int.Parse(rdcPlantilla.SelectedValue), ctx);
        campo.TipoCampo = CntLainsaSci.GetTipoCampo(int.Parse(rdcTipoCampo.SelectedValue), ctx);
        
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
    protected void CargaPlantilla(PlantillaRevision plantilla)
    {
        if (plantilla == null)
        {

            rdcPlantilla.DataSource = CntLainsaSci.GetPlantillaRevisiones(ctx);
            rdcPlantilla.DataTextField = "Nombre";
            rdcPlantilla.DataValueField = "PlantillaId";
        }
        rdcPlantilla.Items.Clear();
        rdcPlantilla.Items.Add(new RadComboBoxItem(plantilla.Descripcion, plantilla.PlantillaId.ToString()));
        rdcPlantilla.SelectedValue = plantilla.PlantillaId.ToString();
        if (caller.Equals("PlantillaRevisionTab"))
        {
            ImageButton1.Enabled = false;
            rdcPlantilla.Enabled = false;
        }
    }
    protected void CargaTipos(TipoCampo tipo)
    {
        rdcTipoCampo.Items.Clear();
        rdcTipoCampo.SelectedValue = null;
        rdcTipoCampo.DataTextField = "Descripcion";
        rdcTipoCampo.DataValueField = "TipoId";
        rdcTipoCampo.DataSource = CntLainsaSci.GetTiposCampo(ctx);
        rdcTipoCampo.DataBind();

        if (tipo != null)
        {
            //rdcTipoCampo.Items.Add(new RadComboBoxItem(tipo.Descripcion, tipo.TipoId.ToString()));
            rdcTipoCampo.SelectedValue = tipo.TipoId.ToString();
        }

    }
    
    #endregion

    //protected void rdcTipoCampo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    //{

    //}

    //protected void rdcTipoCampo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    //{
    //    if (e.Text == "") return;
    //    RadComboBox combo = (RadComboBox)sender;
    //    combo.Items.Clear();
    //    foreach (TipoCampo tipocampo in CntLainsaSci.GetTiposCampo(e.Text, ctx))
    //    {
    //        combo.Items.Add(new RadComboBoxItem(tipocampo.Descripcion, tipocampo.TipoId.ToString()));
    //    }
    //}

    protected void rdcPlantilla_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (PlantillaRevision plantilla in CntLainsaSci.GetPlantillaRevisiones(e.Text, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(plantilla.Descripcion, plantilla.PlantillaId.ToString()));
        }
    }

    protected void rdcPlantilla_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
}
