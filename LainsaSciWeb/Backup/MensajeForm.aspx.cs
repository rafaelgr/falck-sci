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

public partial class MensajeForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Mensaje mensaje = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "mensajegrid", ctx);
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
        // Is it a new record or not?
        if (Request.QueryString["MensajeId"] != null)
        {
            mensaje = CntLainsaSci.GetMensaje(int.Parse(Request.QueryString["MensajeId"]), ctx);
            LoadData(mensaje);
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
            if (!DataOk())
                return;
            if (newRecord)
                mensaje = new Mensaje();
            UnloadData(mensaje);
            if (newRecord)
            {
                ctx.Add(mensaje);
            }
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
        if (rdcGrupoMensajes.SelectedValue == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "GrupoMensajesNeeded"));
            RadNotification1.Show();
            return false;
        }
        if (txtTitulo.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }

    protected void LoadData(Mensaje mensaje)
    {
        CargaGrupoMensajes(mensaje.GrupoMensajes);
        txtTitulo.Text = mensaje.Titulo;
        if (!CntLainsaSci.FechaNula(mensaje.FechaInicio))
            dtFechaInicio.SelectedDate = mensaje.FechaInicio;
        if (!CntLainsaSci.FechaNula(mensaje.FechaFinal))
            dtFechaFin.SelectedDate = mensaje.FechaFinal;
        rdeCuerpo.Content = mensaje.Cuerpo;
    }

    protected void UnloadData(Mensaje mensaje)
    {
        mensaje.Titulo = txtTitulo.Text;
        mensaje.GrupoMensajes = CntLainsaSci.GetGrupoMensajes(int.Parse(rdcGrupoMensajes.SelectedValue), ctx);
        if (dtFechaFin.SelectedDate != null)
            mensaje.FechaFinal = (DateTime)dtFechaFin.SelectedDate;
        if (dtFechaInicio.SelectedDate != null)
            mensaje.FechaInicio = (DateTime)dtFechaInicio.SelectedDate;
        mensaje.Cuerpo = rdeCuerpo.Content;
    }
    #endregion
    protected void CargaGrupoMensajes(GrupoMensajes gm)
    {
        if (gm == null)
            return;
        rdcGrupoMensajes.Items.Clear();
        rdcGrupoMensajes.Items.Add(new RadComboBoxItem(gm.Nombre, gm.GrupoMensajesId.ToString()));
        rdcGrupoMensajes.SelectedValue = gm.GrupoMensajesId.ToString();
        rdcGrupoMensajes.Enabled = false;
    }

    protected void rdcGrupoMensajes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }

    protected void rdcGrupoMensajes_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (GrupoMensajes gm in CntLainsaSci.GetGruposMensajes(e.Text, ctx))
        {
            combo.Items.Add(new RadComboBoxItem(gm.Nombre, gm.GrupoMensajesId.ToString()));
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
}