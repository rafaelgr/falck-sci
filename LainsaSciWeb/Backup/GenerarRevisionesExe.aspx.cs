using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;

using LainsaSciModelo;
using LainsaSciWinWeb;
using LainsaSciInformes;
using Telerik.Web.UI;
using System.Configuration;

public partial class GenerarRevisionesExe : System.Web.UI.Page
{
    #region Definición de variables
    LainsaSci ctx = null; // conector con la base de datos
    Usuario usuario = null; // controla el usuario del login
    ProgramacionInforme prgInf = null;
    Dispositivo dispositivo = null;
    Instalacion instalacion = null;

    #endregion

    #region Carga y descarga de la página
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new LainsaSci("LainsaSciCTX"); // el conector figura en el config
        UsuarioCorrecto(); // control de usuario logado

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadProgressArea1.Localization.UploadedFiles = "Registros procesado: ";
            RadProgressArea1.Localization.CurrentFileName = "Registro: ";
            RadProgressArea1.Localization.TotalFiles = "Total registros:";
            CargarInstalaciones(null);
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        ctx.Dispose(); // evitamos dejar conexiones abiertas.
    }
    #endregion

#region Manejo combo box

#endregion

#region Botones generales
    protected void btnLanzador_Click(object sender, EventArgs e)
    {
        if (!DatosOk()) return;
        int pT = 0; // primary total
        int pV = 0; // primary value
        int pP = 0; // primary percent

        int sT = 0; // secondary total
        int sV = 0; // secondary value
        int sP = 0; // secondary percent
        // this happens for every company
        RadProgressContext context = RadProgressContext.Current;
        sT = instalacion.Dispositivos.Count;
        context.SecondaryTotal = pT;
        context.CurrentOperationText = "Generando las revisiones...";

        foreach (Dispositivo dsp in instalacion.Dispositivos)
        {
            if (dsp.Operativo == true)
            {
                sV++;
                sP = (int)(decimal)((sV / sT) * 100.0);
                context.SecondaryValue = sV;
                context.SecondaryPercent = sP;
                // por cada dispositivo sacar las revisiones
                CntLainsaSci.ProgramarRevisiones(dsp, ctx);
            }
        }
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
#endregion

#region Funciones auxiliares
    /// <summary>
    /// Comprueba que los campos son correctos
    /// antes de asignarlos
    /// </summary>
    /// <returns></returns>
    protected bool DatosOk()
    {
        bool res = true;
        if (rdcInstalacion.SelectedValue == "")
        {
            string m = "Debe seleccionar una instalacion";
            RadWindowManager1.RadAlert(m, null, null, "ATENCION", "noHaceNada");
            res = false;
        }
        else
        {
            instalacion = CntLainsaSci.GetInstalacion(int.Parse(rdcInstalacion.SelectedValue), ctx);
            if (instalacion == null)
            {
                string m = "No existe el objeto instalación referido a la selección";
                RadWindowManager1.RadAlert(m, null, null, "ATENCION", "noHaceNada");
                res = false;
            }
        }
        return res;
    }
    /// <summary>
    /// Comprueba si hay un usuario logado
    /// si no se va a la página de Login (Default.aspx)
    /// </summary>
    protected void UsuarioCorrecto()
    {
        usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
        if (usuario == null)
            Response.Redirect("Default.aspx");
    }
    protected void rdcInstalacion_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        //if (e.Text == "")
        //    return;
        //RadComboBox combo = (RadComboBox)sender;
        //combo.Items.Clear();
        //foreach (Instalacion Instalacion in CntLainsaSci.GetInstalaciones(e.Text, usuario, ctx))
        //{
        //    combo.Items.Add(new RadComboBoxItem(Instalacion.Nombre, Instalacion.InstalacionId.ToString()));
        //}
    }

    protected void rdcInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }
    protected void CargarInstalaciones(Instalacion i)
    {
        rdcInstalacion.Items.Clear();
        foreach (Instalacion i1 in CntLainsaSci.GetInstalaciones(usuario, ctx))
        {
            rdcInstalacion.Items.Add(new RadComboBoxItem(i1.Nombre, i1.InstalacionId.ToString()));
        }
        rdcInstalacion.Items.Add(new RadComboBoxItem(" ", ""));
        rdcInstalacion.SelectedValue = "";
        if (i != null)
            rdcInstalacion.SelectedValue = i.InstalacionId.ToString();
    }
#endregion

#region Llamado desde JavaScript
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }
#endregion




}