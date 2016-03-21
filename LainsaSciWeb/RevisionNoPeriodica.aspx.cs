using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;

using LainsaSciModelo;
using LainsaSciWinWeb;
using Telerik.Web.UI;

public partial class RevisionNoPeriodica : System.Web.UI.Page
{
    #region Definición de variables
    LainsaSci ctx = null; // conector con la base de datos
    Revision revision = null; // manejar el tipo de revisión.
    Usuario usuario = null; // controla el usuario del login
    Dispositivo dispositivo = null;
    PlantillaRevision plantilla = null;

    #endregion

    #region Carga y descarga de la página
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new LainsaSci("LainsaSciCTX"); // el conector figura en el config
        UsuarioCorrecto(); // control de usuario logado
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // se ejecuta sola en la primera carga, no en recargas
            CargaInicialControles(revision);

            int id = 0;
            try{
                id=int.Parse(Request.Params["DispositivoId"]);
            }catch(Exception){
                id=0;
            }

            if(id>0){
                dispositivo = CntLainsaSci.GetDispositivo(id, ctx);
                string nomLargo = String.Format("({0}) {1} / {2}", dispositivo.Nombre, dispositivo.Instalacion.Empresa.Nombre, dispositivo.Instalacion.Nombre);
                rdcDispositivo.Items.Clear();
                rdcDispositivo.Items.Add(new RadComboBoxItem(nomLargo, dispositivo.DispositivoId.ToString()));
                rdcDispositivo.Items[0].Selected = true;
                CargarPlantillas(dispositivo);

            }

        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        ctx.Dispose(); // evitamos dejar conexiones abiertas.
    }
    #endregion

    #region Manejo combo box
    protected void rdcDispositivo_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return; // no hay texto para buscar
        // cargamos los valores coincidentes con la búsqueda.
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        foreach (Dispositivo dsp in CntLainsaSci.GetDispositivos(e.Text, usuario, false, ctx))
        {
            string nomLargo = String.Format("({0}) {1} / {2}", dsp.Nombre, dsp.Instalacion.Empresa.Nombre, dsp.Instalacion.Nombre);
            combo.Items.Add(new RadComboBoxItem(nomLargo, dsp.DispositivoId.ToString()));
        }

    }

    protected void rdcDispositivo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rdcDispositivo.SelectedValue != "")
        {
            // Veamos qué se ha seleccionado
            dispositivo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivo.SelectedValue), ctx);
            CargarPlantillas(dispositivo);
        }
    }

    protected void rdcUsuario_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }
    #endregion

    #region Botones generales
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        if (!DatosOk()) return;
        DescargarControles(revision);
//        RadAjaxManager1.ResponseScripts.Add(String.Format("closeWindowRefreshGrid('{0}', 'new');","RevisionGrid"));
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
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
    protected void DescargarControles(Revision revision)
    {
        if (revision == null)
        {
            revision = new Revision();
            ctx.Add(revision);
        }
        revision.Dispositivo = CntLainsaSci.GetDispositivo(int.Parse(rdcDispositivo.SelectedValue),ctx);
        revision.PlantillaRevision = CntLainsaSci.GetPlantillaRevision(int.Parse(rdcPlantilla.SelectedValue), ctx);
        revision.FechaPlanificada = (DateTime)rdtFecha.SelectedDate;
        revision.Usuario = CntLainsaSci.GetUsuario(int.Parse(rdcUsuario.SelectedValue), ctx);
        revision.Estado = "PLANIFICADA";
        // Ahora hay que crear los datos asociados a esa revisión
        foreach (Campo c in revision.PlantillaRevision.Campos)
        {
            DatosRevision dr = new DatosRevision();
            dr.Campo = c;
            dr.Revision = revision;
            ctx.Add(dr);
        }
        ctx.SaveChanges();
    }
    /// <summary>
    /// Cuando carga la página prepara los controles para su uso.
    /// </summary>
    /// <param name="revision"></param>
    protected void CargaInicialControles(Revision revision)
    {
        // cargar los dispositivos
        rdcDispositivo.Items.Clear();

        
        // se bloquean las plantillas hasta que se seleccione un dispositivo.
        rdcPlantilla.Items.Clear();

        // cargar los usuarios
        rdcUsuario.Items.Clear();
        foreach (Usuario usu in CntLainsaSci.GetUsuarios(usuario, ctx))
        {
            rdcUsuario.Items.Add(new RadComboBoxItem(usu.Nombre, usu.UsuarioId.ToString()));
        }
    }
    /// <summary>
    ///  Carga las plantillas que corresponden al dispositivo
    ///  sólo las no periódicas.
    /// </summary>
    /// <param name="dsp"> dispositivo </param>
    protected void CargarPlantillas(Dispositivo dsp)
    {
        if (dispositivo != null)
        {
            rdcPlantilla.Items.Clear();
            IList<PlantillaRevision> rs = (from pr in dispositivo.TipoDispositivo.PlantillaRevisions
                     where pr.NoPeriodica == true
                     select pr).ToList<PlantillaRevision>();
            if (rs.Count == 0)
                RadWindowManager1.RadAlert("El dispositivo seleccionado no tiene plantillas no periódicas",
                    null, null, "AVISO", "noHaceNada");
            foreach (PlantillaRevision pl in rs)
            {
                rdcPlantilla.Items.Add(new RadComboBoxItem(pl.Descripcion, pl.PlantillaId.ToString()));
            }
        }
        else
        {
            RadWindowManager1.RadAlert("Debe de seleccionar un dispositivo para cargar sus plantillas", 
                null, null, "AVISO", "noHaceNada");
        }
    }
#endregion

#region Llamado desde JavaScript
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        // Se manda en los argumentos el código del dispositivo
        // hay que cargar las plantillas en consonancia
        Dispositivo dsp = CntLainsaSci.GetDispositivo(int.Parse(e.Argument), ctx);
        CargarPlantillas(dsp);
    }
#endregion
}