using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using DosimetriaModelo;

namespace DosimetriaWinWeb
{
    public partial class AccesorioAsignadoForm : System.Web.UI.Page
    {
        #region Variables declaration
        Dosimetria ctx = null; // openaccess context used in this page
        Usuario Usuario = null; // Usuario loged
        Permiso permiso = null;
        string caller = ""; // who calls the form
        Dispositivo dispositivo = null;
        AccesorioAsignado accAsignado = null;
        //Accesorio accesorio = null;

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
            permiso = CntDosimetria.GetPermiso(Usuario.GrupoUsuario, "Dispositivogrid", ctx);
            if (permiso == null)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                      (string)GetGlobalResourceObject("ResourceDosimetria", "Warning"),
                                                      (string)GetGlobalResourceObject("ResourceDosimetria", "NoPermissionsAssigned"));
                RadNotification1.Show();
                RadAjaxManager1.ResponseScripts.Add("closeWindow();");
            }
            btnAccept.Visible = permiso.Modificar;
            // Si esto no va antes de DispositivoID tendrás problemas.
            if (Request.QueryString["Caller"] != null)
            {
                caller = Request.QueryString["Caller"];
                caller = caller.Replace("'", "");
            }
            // Mirar si se ha pasado una Dispositivo
            if (Request.QueryString["DispositivoId"] != null)
            {
                dispositivo = CntDosimetria.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
                CargaDispositivo(dispositivo);
            }
            // Is it a new record or not?
            //if (Request.QueryString["DispositivoId"] != null)
            //{
            //    Dispositivo = CntDosimetria.GetDispositivo(int.Parse(Request.QueryString["DispositivoId"]), ctx);
            //    LoadData(Dispositivo);
            //    newRecord = false;
            //}
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
                    accAsignado = new AccesorioAsignado();
                UnloadData(accAsignado);
                if (newRecord)
                    ctx.Add(accAsignado);
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
        protected void LoadData(Dispositivo Dispositivo)
        {
            // este lio del caller igual se puede solucionar con el InTab;
        }
        protected void UnloadData(AccesorioAsignado accAsignado)
        {

            accAsignado.Dispositivo = CntDosimetria.GetDispositivo(int.Parse(rdcDispositivo.SelectedValue), ctx);
            accAsignado.Accesorio = CntDosimetria.GetAccesorio(int.Parse(rdcAccesorios.SelectedValue), ctx);

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
        protected void CargaDispositivo(Dispositivo Dispositivo)
        {
            if (Dispositivo == null)
            {
                rdcDispositivo.DataSource = CntDosimetria.GetDispositivos(ctx);
                rdcDispositivo.DataTextField = "Nombre";
                rdcDispositivo.DataValueField = "DispositivoId";
            }
            rdcDispositivo.Items.Clear();
            rdcDispositivo.Items.Add(new RadComboBoxItem(Dispositivo.Nombre, Dispositivo.DispositivoId.ToString()));
            rdcDispositivo.SelectedValue = Dispositivo.DispositivoId.ToString();
            if (caller.Equals("DispositivoTab"))
                rdcDispositivo.Enabled = false;
        }
        protected void CargaAccesorios(Accesorio accesorio)
        {
            rdcAccesorios.DataSource = CntDosimetria.GetTiposDispositivo(ctx);
            rdcAccesorios.DataTextField = "Nombre";
            rdcAccesorios.DataValueField = "TipoId";

            if (accesorio != null)
            {
                rdcAccesorios.Items.Add(new RadComboBoxItem(accesorio.Descripcion, accesorio.AccesorioId.ToString()));
                rdcAccesorios.SelectedValue = accesorio.AccesorioId.ToString();
            }

        }
        #endregion
        protected void rdcDispositivo_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
        }

        protected void rdcDispositivo_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text == "")
                return;
            RadComboBox combo = (RadComboBox)sender;
            combo.Items.Clear();
            foreach (Dispositivo dispositivo in CntDosimetria.GetDispositivo(e.Text, ctx))
            {
                combo.Items.Add(new RadComboBoxItem(dispositivo.Nombre, dispositivo.DispositivoId.ToString()));
            }
        }

        protected void rdcAccesorio_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
        }

        protected void rdcAccesorio_ItemsRequested(object sender, Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text == "")
                return;
            RadComboBox combo = (RadComboBox)sender;
            combo.Items.Clear();
            foreach (Accesorio accesorio in CntDosimetria.getAccesorio(e.Text, ctx))
            {
                combo.Items.Add(new RadComboBoxItem(accesorio.Descripcion, accesorio.AccesorioId.ToString()));
            }
        }
    }
}