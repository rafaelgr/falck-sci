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

public partial class TerminalForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    Empresa empresa = null; //
    string caller = ""; // who calls the form
    Terminal terminal = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "terminalgrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de TerminalID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Mirar si se ha pasado una Instalacion
        if (Request.QueryString["EmpresaId"] != null)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(Request.QueryString["EmpresaId"]), ctx);
            CargarEmpresas(empresa);
        }
        else
        {
            CargarEmpresas(null);
        }
        // Is it a new record or not?
        if (Request.QueryString["TerminalId"] != null)
        {
            terminal = CntLainsaSci.GetTerminal(int.Parse(Request.QueryString["TerminalId"]), ctx);
            LoadData(terminal);
            newRecord = false;
        }
        else
        {
            CargarTipo("");
            if (empresa != null)
            {
                CargarEmpresas(empresa);
            }
            else
            {
                CargarEmpresas(null);
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
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!DataOk())
                return;
            if (newRecord)
                terminal = new Terminal();
            UnloadData(terminal);
            if (newRecord)
            {
                ctx.Add(terminal);
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

    protected void LoadData(Terminal terminal)
    {
        txtTerminalId.Text = terminal.TerminalId.ToString();
        CargarEmpresas(terminal.Empresa);
        CargarTipo(terminal.Tipo);
        txtComentarios.Text = terminal.Observaciones;
        txtNombre.Text = terminal.Nombre;
        txtNumeroSerie.Text = terminal.NumeroSerie;
        rdcTipo.SelectedValue = terminal.Tipo;
    }

    protected void UnloadData(Terminal Terminal)
    {
        terminal.Empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
        terminal.Observaciones = txtComentarios.Text;
        terminal.Nombre = txtNombre.Text;
        txtNombre.Text = terminal.Nombre;
        terminal.NumeroSerie =txtNumeroSerie.Text ;
        terminal.Tipo = rdcTipo.SelectedValue;
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

    protected void rdcEmpresa_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Instalacion Instalacion in CntLainsaSci.GetInstalaciones(e.Text, usuario, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(Instalacion.Nombre, Instalacion.InstalacionId.ToString()));
        }
    }

    protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    protected void CargarEmpresas(Empresa e) 
    { 
        rdcEmpresa.Items.Clear();
        foreach (Empresa e1 in CntLainsaSci.GetEmpresas(usuario, ctx))
        {
            rdcEmpresa.Items.Add(new RadComboBoxItem(e1.Nombre,e1.EmpresaId.ToString()));
        }
        rdcEmpresa.Items.Add(new RadComboBoxItem(" ",""));
        rdcEmpresa.SelectedValue = "";
        if (e != null)
            rdcEmpresa.SelectedValue = e.EmpresaId.ToString();
    }
    protected void CargarTipo(string tipo)
    {
        rdcTipo.Items.Clear();
        rdcTipo.Items.Add(new RadComboBoxItem("WINDOWS MOBILE", "WINDOWS MOBILE"));
        if (tipo != "")
        {
            rdcTipo.SelectedValue = tipo;
        }
        else
        {
            rdcTipo.Items.Add(new RadComboBoxItem(" ", ""));
            rdcTipo.SelectedValue = "";
        }

    }
}