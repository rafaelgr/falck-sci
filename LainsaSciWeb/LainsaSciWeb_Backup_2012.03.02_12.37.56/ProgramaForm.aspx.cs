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

public partial class ProgramaForm : System.Web.UI.Page
{
    #region Variables declaration
    LainsaSci ctx = null; // openaccess context used in this page
    Usuario usuario = null; // Usuario loged
    Permiso permiso = null;
    string caller = ""; // who calls the form
    Programa programa = null;
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
        permiso = CntLainsaSci.GetPermiso(usuario.GrupoUsuario, "programagrid", ctx);
        if (permiso == null)
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
            RadNotification1.Show();
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        btnAccept.Visible = permiso.Modificar;
        // Si esto no va antes de ProgramaID tendrás problemas.
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
            caller = caller.Replace("'", "");
        }
        // Is it a new record or not?

        if (Request.QueryString["ProgramaId"] != null)
        {
            programa = CntLainsaSci.GetPrograma(int.Parse(Request.QueryString["ProgramaId"]), ctx);
            LoadData(programa);
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
            if (newRecord) programa = new Programa();
            UnloadData(programa);
            if (newRecord) ctx.Add(programa);
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
        RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'edit');"
                    , caller));
        //RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
    #endregion
    #region Auxiliary
    protected bool DataOk()
    {
        if (txtComentarios.Text == "")
        {
            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                (string)GetGlobalResourceObject("ResourceLainsaSci", "NombreNeeded"));
            RadNotification1.Show();
            return false;
        }
        return true;
    }
    protected void LoadData(Programa programa)
    {
        txtProgramaId.Text = programa.ProgramaId.ToString();
        if (!CntLainsaSci.FechaNula(programa.FechaProgramada))
            dtpFechaProgramada.SelectedDate = programa.FechaProgramada;
        txtComentarios.Text = programa.Comentarios;
        CargarUsuarios(programa.Usuario);
        // carga del frame de direcciones
        HtmlControl frm = (HtmlControl)this.FindControl("ifRevisiones");
        HtmlControl frm2 = (HtmlControl)this.FindControl("ifSustituciones");
        // este lio del caller igual se puede solucionar con el InTab;
        string caller2 = "ProgramaForm";
        //if (caller == "ProgramaGrid") caller2 = "ProgramaTab";
        frm.Attributes["src"] = String.Format("RevisionGrid.aspx?ProgramaId={0}&Caller={1}&InFrame=S", programa.ProgramaId, caller2);
        frm2.Attributes["src"] = String.Format("SustitucionGrid.aspx?ProgramaId={0}&Caller={1}&InFrame=S", programa.ProgramaId, caller2);
        //RadAjaxManager1.ResponseScripts.Add("resizeIframe('ifDirecciones');");
    }
    protected void UnloadData(Programa programa)
    {
        programa.Comentarios = txtComentarios.Text;
        programa.Usuario = CntLainsaSci.GetUsuario(int.Parse(rdcUsuario.SelectedValue), ctx);
        if (dtpFechaProgramada.SelectedDate != null)
        {
            programa.FechaProgramada = (DateTime)dtpFechaProgramada.SelectedDate;
            foreach (Revision r in programa.Revisions)
                r.FechaProgramada = programa.FechaProgramada;
        }
        programa.Estado = CntLainsaSci.EstadoPrograma(programa);
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
    protected void CargarUsuarios(Usuario u)
    {
        rdcUsuario.Items.Clear();
        foreach (Usuario usu in CntLainsaSci.GetUsuarios(usuario, ctx))
        {
            rdcUsuario.Items.Add(new RadComboBoxItem(usu.Nombre, usu.UsuarioId.ToString()));
        }
        if (u != null)
            rdcUsuario.SelectedValue = u.UsuarioId.ToString();
        else
        {
            rdcUsuario.Items.Add(new RadComboBoxItem(" ",""));
            rdcUsuario.SelectedValue = "";
        }
    }
    #endregion

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (programa != null)
        {
            foreach (Revision r in programa.Revisions) 
            {
                r.ResumenInforme = CntLainsaSci.GetResumenInforme(r, ctx);
            }
            ctx.SaveChanges();
            string url = String.Format("VisorInforme.aspx?ProgramaId={0}", programa.ProgramaId);
            string jCommand = String.Format("openOutSide('{0}','{1}');", url, "VisorInforme");
            RadAjaxManager1.ResponseScripts.Add(jCommand);
        }
    }
}
