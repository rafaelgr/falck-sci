using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;

using LainsaSciModelo;
using LainsaSciWinWeb;
using LainsaSciInformes;
using Telerik.Web.UI;

public partial class ProgramacionInformeForm : System.Web.UI.Page
{
    #region Definición de variables
    LainsaSci ctx = null; // conector con la base de datos
    Usuario usuario = null; // controla el usuario del login
    ProgramacionInforme prgInf = null;
    Dispositivo dispositivo = null;

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
            if (Request.QueryString["ProgramacionInformeId"] != null)
            {
                prgInf = CntInforme.GetProgramacionInforme(int.Parse(Request.QueryString["ProgramacionInformeId"]), ctx);
                CargaControles(prgInf);
            }
            else
            {
                CargaControles(null);
            }
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
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        if (!DatosOk()) return;
        DescargarControles(prgInf);
        RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');","ProgramacionInformeGrid"));
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
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
    /// <summary>
    /// Descarga los controles y los asigna a los atributos
    /// </summary>
    protected void DescargarControles(ProgramacionInforme prgInf)
    {
        if (prgInf == null)
        {
            prgInf = new ProgramacionInforme();
            ctx.Add(prgInf);
        }
        prgInf.Informe = rdcInforme.SelectedValue;
        prgInf.Periodicidad = rdcPeriodicidad.SelectedValue;
        prgInf.FechaInicial = (DateTime)rdtFecha.SelectedDate;
        ctx.SaveChanges();
    }
    /// <summary>
    /// Cuando carga la página prepara los controles para su uso.
    /// </summary>
    /// <param name="revision"></param>
    protected void CargaControles(ProgramacionInforme prgInf)
    {
        if (prgInf != null)
        {
            txtId.Text = prgInf.ProgramacionInformeId.ToString();
            CargarInformes(prgInf.Informe);
            CargarPeriodicidad(prgInf.Periodicidad);
            rdtFecha.SelectedDate = prgInf.FechaInicial;
        }
        else
        {
            CargarInformes(null);
            CargarPeriodicidad(null);
        }

    }

    protected void CargarInformes(string informe)
    {
        // limpiamos y cargamos
        rdcInforme.Items.Clear();
        foreach (NombreInforme ninf in CntInforme.GetNombresDeInforme())
        {
            rdcInforme.Items.Add(new RadComboBoxItem(ninf.Nombre, ninf.Informe));
        }
        if (informe != null)
        {
            rdcInforme.SelectedValue = informe;
        }
        else
        {
            rdcInforme.Items.Add(new RadComboBoxItem(" ",""));
            rdcInforme.SelectedValue = "";
        }
    }

    protected void CargarPeriodicidad(string periodicidad)
    {
        // limpiamos y cargamos
        rdcPeriodicidad.Items.Clear();
        rdcPeriodicidad.Items.Add(new RadComboBoxItem("Semanal","S"));
        rdcPeriodicidad.Items.Add(new RadComboBoxItem("Mensual", "M"));
        rdcPeriodicidad.Items.Add(new RadComboBoxItem("Trimestral", "T"));
        rdcPeriodicidad.Items.Add(new RadComboBoxItem("Semestral", "SM"));
        rdcPeriodicidad.Items.Add(new RadComboBoxItem("Anual", "A"));
        //
        if (periodicidad != null)
        {
            rdcPeriodicidad.SelectedValue = periodicidad;
        }
        else
        {
            rdcPeriodicidad.Items.Add(new RadComboBoxItem(" ", ""));
            rdcPeriodicidad.SelectedValue = "";
        }
    }

#endregion

#region Llamado desde JavaScript
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }
#endregion
}