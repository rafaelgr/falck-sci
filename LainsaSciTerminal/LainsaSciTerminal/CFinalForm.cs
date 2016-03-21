using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using LainsaTerminalLib;

namespace LainsaSciTerminal
{
    public partial class CFinalForm : Form
    {
        #region Definición variables
        
        private TRevision tr = null;
        private int pos = 0;
        private string path;
        private TUsuario usuario = null;
        private TDispositivo dsp = null;
        private TPrograma prg = null;
        private object callObj = null;
        private string caller = "";
        private SqlCeConnection conn;
        
        #endregion  

        public CFinalForm(TRevision tr, int pos, string caller, TUsuario usuario)
        {
            this.usuario = usuario;
            this.tr = tr;
            this.pos = pos;
            this.caller = caller;
            this.conn = CntSciTerminal.TSqlConnection();
                       
            InitializeComponent();
            
            switch (caller)
            {
                case "dispositivo":
                    //mnuAnterior.Enabled = false;
                    //mnuPrimero.Enabled = false;
                    //panel1.Enabled = panel2.Enabled = panel3.Enabled = panel4.Enabled = panel5.Enabled = false;
                    //mnuAceptar.Enabled = false;
                    break;
                default:
                    break;
            }
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            VerificarPosicion();
            CargarTitulos();
            CargarPantalla();
            Cursor.Current = Cursors.Default;
        }

        #region Manejo de menú
        private void mnuPrimero_Click(object sender, EventArgs e)
        {
            pos = 0;
            LlamarDistribuidor();
        }

        private void mnuAnterior_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0) pos = 0;
            LlamarDistribuidor();
        }

        private void mnuSiguiente_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= tr.DatosRevision.Count) pos = tr.DatosRevision.Count - 1;
            LlamarDistribuidor();
        }

        private void mnuUltimo_Click(object sender, EventArgs e)
        {
            pos = tr.DatosRevision.Count - 1;
            LlamarDistribuidor();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            switch (caller)
            {
                case "programa":
                    RevisionesGrid revGrid = new RevisionesGrid(tr.TPrograma, usuario);
                    revGrid.Show();
                    break;
                case "dispositivoGrid":
                    DispForm dspFormGrid = new DispForm(usuario, tr.Dispositivo);
                    dspFormGrid.Show();
                    break;
                case "dispRev":
                    CntSciTerminal.TOpen(this.conn);
                    IList<TRevision> ltr = CntSciTerminal.GetTRevisiones(true, tr.Dispositivo, this.conn);
                    CntSciTerminal.TClose(this.conn);
                    if (ltr.Count >= 2)
                    {
                        RevisionesGrid Grid = new RevisionesGrid("dispRev", tr.Dispositivo, usuario);
                        Grid.Show();
                    }
                    else
                    { 
                        Cursor.Current = Cursors.WaitCursor;
                        CodBarrasForm frmCodBarras = new CodBarrasForm(usuario, true);
                        frmCodBarras.Show();
                        this.Close();
                    }
                    this.Close();
                    break;
            }
            this.Close();
        }
        private void mnuAceptar_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            CntSciTerminal.TOpen(this.conn);
            SaveDatosRevision(conn);
            if (!DescargarPantalla()) return;
            if (!SaveRevision(conn)) return;
            CntSciTerminal.TClose(this.conn);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Revisión guardada", "AVISO");
            Cursor.Current = Cursors.WaitCursor;  
            switch (caller)
            {
                case "programa":
                    RevisionesGrid revGrid = new RevisionesGrid(tr.TPrograma, usuario);
                    revGrid.Show();
                    break;
                case "dispositivoGrid":
                    DispForm dspFormGrid = new DispForm(usuario, tr.Dispositivo);
                    dspFormGrid.Show();
                    break;
                case "dispRev":
                    CntSciTerminal.TOpen(this.conn);
                    IList<TRevision> ltr = CntSciTerminal.GetTRevisiones(true, tr.Dispositivo, conn);
                    CntSciTerminal.TClose(this.conn);
                    if (ltr.Count > 0)
                    {
                        RevisionesGrid Grid = new RevisionesGrid("dispRev", tr.Dispositivo, usuario);
                        Grid.Show();
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        CodBarrasForm frmCodBarras = new CodBarrasForm(usuario, true);
                        frmCodBarras.Show();
                        this.Close();
                    }
                    this.Close();
                    break;
            }
            this.Close();
        }
        #endregion
        private void CargarTitulos()
        {
            lblPlantilla.Text = String.Format("[{0:dd/MM/yy}] {1} ({2})",
                tr.FechaPlanificada,
                tr.Plantilla,
                "F");
            string modelo = "";
            if (tr.Dispositivo.Modelo != null)
                modelo = tr.Dispositivo.Modelo.Nombre;
            lblDispositivo.Text = String.Format("{0} / [{1}]",
                tr.Dispositivo.Nombre,
                modelo);
            lblPosicion.Text = tr.Dispositivo.Posicion;
        }
        private void VerificarPosicion()
        {

        }
        private void CargarPantalla()
        {
            CntSciTerminal.TOpen(this.conn);
            CargarUsuarios(tr.Usuario);
            CargarTipoAnomalias(tr.TTipoAnomalia);
            CntSciTerminal.TClose(this.conn);
            if (CntSciTerminal.FechaNula(tr.FechaRevision))
                dtpFecha.Value = DateTime.Now;
            else
                dtpFecha.Value = tr.FechaRevision;
            txtResultado.Text = tr.Resultado;
            txtComentario.Text = tr.Comentario;
        }
        private void SaveDatosRevision(SqlCeConnection conn)
        {
            foreach (TDatoRevision tdr in tr.DatosRevision)
                CntSciTerminal.TSave(tdr, conn);
        }
        private bool SaveRevision(SqlCeConnection conn)
        {
            try
            {
                //tr.FechaRevision = DateTime.Now; // ahora no se guarda la que el técnico diga
                tr.Estado = "REALIZADA";
                CntSciTerminal.TSave(tr, conn);

                if (tr.TPrograma != null)
                    CntSciTerminal.SetEstadoPrograma(tr.TPrograma, conn);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR de guardado: " + ex.Message, "ERROR");
                return false;
            }
        }
        private bool DescargarPantalla()
        {
            try
            {
                string nomUsu = (string)cmbUsuario.SelectedItem;
                if (nomUsu != "")
                {
                    tr.Usuario = CntSciTerminal.GetTUsuarioID(nomUsu, conn);
                }
                string nomAnomalia = (string)cmbTipoAnomalia.SelectedItem;
                if (nomAnomalia != "")
                {
                    tr.TTipoAnomalia = CntSciTerminal.GetTTipoAnomalia(nomAnomalia, conn);
                }
                if (dtpFecha.Value != null)
                    tr.FechaRevision = dtpFecha.Value;
                tr.Resultado = txtResultado.Text;
                tr.Comentario = txtComentario.Text;

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR de descarga: " + ex.Message, "ERROR");
                return false;
            }
        }
        private void CargarUsuarios(TUsuario usuario)
        {
            cmbUsuario.Items.Clear();
            // cargamos el desplegable de usuarios
            foreach (TUsuario tus in CntSciTerminal.GetTUsuarios(conn))
            {
                cmbUsuario.Items.Add(tus.Nombre);
            }
            if (usuario == null)
            {
                //cmbUsuario.Items.Add("");
                usuario = this.usuario;
            }
            //else
            //{
                int res = BuscarEnCombo(usuario.Nombre, cmbUsuario);
                if (res >= 0)
                {
                    cmbUsuario.SelectedIndex = res;
                }
            //}
        }
        private void CargarTipoAnomalias(TTipoAnomalia tpa)
        {
            cmbTipoAnomalia.Items.Clear();
            // cargamos el desplegable.
            foreach (TTipoAnomalia ttpa in CntSciTerminal.GetTTipoAnomalias(conn))
            {
                cmbTipoAnomalia.Items.Add(ttpa.Nombre);
            }
            if (tpa == null)
            {
                cmbTipoAnomalia.Items.Add("");
            }
            else
            {
                int res = BuscarEnCombo(tpa.Nombre, cmbTipoAnomalia);
                if (res >= 0)
                    cmbTipoAnomalia.SelectedIndex = res;
            }
        }
        private void LlamarDistribuidor()
        {
            // siemprte antes de la llamada salvamos los datos actuales para recuperarlos
            CntSciTerminal.TOpen(this.conn);
            DescargarPantalla();
            CntSciTerminal.TClose(this.conn);
            DistribuidorForm frmDist = new DistribuidorForm(tr, pos, caller, usuario);
            frmDist.Show();
            this.Close();
        }
        private int BuscarEnCombo(string texto, ComboBox cmb)
        {
            for (int i= 0; i < cmb.Items.Count; i++)
            {
                if ((string)cmb.Items[i] == texto) return i;
            }
            return -1;
        }
        private bool DatosOk() 
        { 
            // verificar que se ha seleccionado al menos un usuario.
            if ((string)cmbUsuario.SelectedItem == "" || cmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Se necesita un usuario", "AVISO");
                return false;
            }
            // Verificar que hay una fecha_apertura seleccionada
            if (dtpFecha.Value == null)
            {
                MessageBox.Show("Se necesita una fecha_apertura", "AVISO");
                return false;
            }
            // y por último que haya un resultado.
            if (txtResultado.Text == "")
            {
                MessageBox.Show("Debe indicar un resultado", "AVISO");
                return false;
            }
            // si llega aquí se supone que esta todo ok
            return true;

        }
        private void btnIncidencias_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CntSciTerminal.TOpen(this.conn);
            DescargarPantalla();
            CntSciTerminal.TClose(this.conn);
            IncidenciasGrid incGrid = new IncidenciasGrid(caller, tr, usuario);
            incGrid.Show();
            this.Close();
        }

        private void btnSustituciones_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CntSciTerminal.TOpen(this.conn);
            DescargarPantalla();
            CntSciTerminal.TClose(this.conn);
            SustitucionesGrid sustGrid = new SustitucionesGrid(caller, tr, usuario);
            sustGrid.Show();
            this.Close();
        }

        private void CFinalForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {   
                //if (btnIncidencias.Focused)
            //        btnIncidencias_Click(null, null);
            //    else if (btnIncidencias.Focused)
            //        btnSustituciones_Click(null, null);
            //    else if(!dtpFecha.Focused 
                mnuAceptar_Click(null, null);
            }

        }

        private void lblDispositivo_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}