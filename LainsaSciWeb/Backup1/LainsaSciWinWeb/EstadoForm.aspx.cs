using System;
using System.Web;
using System.Web.UI;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.Linq;
using Telerik.OpenAccess;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class EstadoForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Estado estado = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "EstadoGrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de EstadoID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        
        // Is it a new record or not?
        if (Request.QueryString["EstadoId"] != null)
        {
            estado = CntLainsaSci.GetEstado(int.Parse(Request.QueryString["EstadoId"]), ctx);
            LoadData(estado);
            newRecord = false;
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
            if (!DataOk()) return;
            if (newRecord) estado = new Estado();
            UnloadData(estado);
            if (newRecord) ctx.Add(estado);
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
        string m = ""; // mensajes
        // hay que comprobar que ambos check no está activos
        bool enApertura = chkEnApertura.Checked;
        bool enCierre = chkEnCierre.Checked;
        if (enApertura && enCierre)
        {
            m = "No puede seleccionar usado en apertura y cierre simultáneamente";
            RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
            return false;
        }
        // para llevar una referencia en modificaciones
        int id = 0;
        if (estado != null) id = estado.EstadoId;
        // comprobar que no hay otro estado con ese check

        Empresa emp = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);

        if (enApertura)
        {
            Estado est = (from e in ctx.Estados
                          where e.EnApertura == true
                          && e.EstadoId != id
                          && e.Empresa.EmpresaId == emp.EmpresaId
                          select e).FirstOrDefault<Estado>();
            if (est != null)
            {
                m = String.Format("Ya existe un estado ({0}) seleccionado para apertura. Debe modificarlo y volver a este para marcar la opción", est.Nombre);
                RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                return false;
            }
        }
        // idem para cierre
        if (enCierre)
        {
            Estado est = (from e in ctx.Estados
                          where e.EnCierre == true
                          && e.EstadoId != id
                          && e.Empresa.EmpresaId == emp.EmpresaId
                          select e).FirstOrDefault<Estado>();
            if (est != null)
            {
                m = String.Format("Ya existe un estado ({0}) seleccionado para cierre. Debe modificarlo y volver a este para marcar la opción", est.Nombre);
                RadWindowManager1.RadAlert(m, null, null, "Aviso", "doNothing");
                return false;
            }
        }
        return true;
    }
    protected void LoadData(Estado estado)
    {
        txtEstadoId.Text = estado.EstadoId.ToString();
        txtNombre.Text = estado.Nombre;
        chkEnApertura.Checked = estado.EnApertura;
        chkEnCierre.Checked = estado.EnCierre;
        if (estado.Empresa != null)
        {
            rdcEmpresa.Items.Clear();
            rdcEmpresa.Items.Add(new RadComboBoxItem(estado.Empresa.Nombre, estado.Empresa.EmpresaId.ToString()));
            rdcEmpresa.SelectedValue = estado.Empresa.EmpresaId.ToString();
        }
    }
    protected void UnloadData(Estado estado)
    {
        estado.Nombre = txtNombre.Text;
        estado.EnApertura = chkEnApertura.Checked;
        estado.EnCierre = chkEnCierre.Checked;
        if (rdcEmpresa.SelectedValue != "")
        {
            estado.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
        }
        else
        {
            estado.Empresa = null;
        }
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

    #region Control de combos
    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Empresa emp in CntLainsaSci.GetEmpresas(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(emp.Nombre, emp.EmpresaId.ToString()));
        }
    }
    #endregion 


}
