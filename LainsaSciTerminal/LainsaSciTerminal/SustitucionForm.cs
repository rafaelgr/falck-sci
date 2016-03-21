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
    public partial class SustitucionForm : Form
    {
        private TSustitucion sustitucion;
        private TUsuario usuario;
        private SqlCeConnection conn;
        private TRevision revision;
        private TDispositivo dispositivo;
        private string caller;
        private object callObj;
        
        public SustitucionForm(TSustitucion sustitucion, string caller, TUsuario usuario)
        {
            this.sustitucion = sustitucion;
            this.usuario = usuario;
            this.caller = caller;
            this.revision = sustitucion.TRevision;
            this.dispositivo = sustitucion.TDispositivoOriginal;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            CargarPantalla();
            Cursor.Current = Cursors.Default;
        }
        
        public SustitucionForm(string caller, object callObj, TUsuario usuario)
        {
            this.sustitucion = null;
            this.usuario = usuario;
            this.callObj = callObj;
            this.caller = caller;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            btnEliminar.Visible = false;
            CargarUsuarios(usuario);
            CargarEstados(null);
            switch (caller)
            {
                case "dispositivoGrid": 
                case "programa":
                case "dispRev":
                    revision = (TRevision)callObj;
                    dispositivo = revision.Dispositivo;
                    CargarDispositivoO();
                    break;
                case "dispositivo":
                    dispositivo = (TDispositivo)callObj;
                    CargarDispositivoO();
                    break;
                default:
                    panel1.Enabled = true;
                    break;
            }
            Cursor.Current = Cursors.Default;
        }
       
        private void CargarPantalla()
        {
            CargarUsuarios(sustitucion.TUsuario);
            CargarEstados(sustitucion.Estado);
            if (sustitucion.TDispositivoSustituto != null)
            {
                txtDispS.Text = sustitucion.TDispositivoSustituto.CodBarras;
                lblDSId.Text = txtDispS.Text;
                txtDispSDatos.Text = String.Format("{0}({1})[{2}]",
                   sustitucion.TDispositivoSustituto.Nombre, sustitucion.NInstalacion, sustitucion.TDispositivoSustituto.Tipo.Nombre);
            }
            if (!CntSciTerminal.FechaNula(sustitucion.Fecha))
                dtpFecha.Value = sustitucion.Fecha;
            txtComentario.Text = sustitucion.Comentarios;
            CargarDispositivoO();
        }
        public void CargarDispositivoO()
        {
            txtDispO.Text = dispositivo.CodBarras;
            lblDOId.Text = txtDispO.Text;
            txtDispODatos.Text = String.Format("{0}({1})[{2}]",
                dispositivo.Nombre, dispositivo.Instalacion.Nombre, dispositivo.Tipo.Nombre);
            
        }
        private void CargarUsuarios(TUsuario usuario)
        {
            cmbUsuario.Items.Clear();
            // cargamos el desplegable de usuarios
            CntSciTerminal.TOpen(this.conn);
            foreach (TUsuario tus in CntSciTerminal.GetTUsuarios(conn))
            {
                cmbUsuario.Items.Add(tus.Nombre);
            }
            CntSciTerminal.TClose(this.conn);
            if (usuario == null)
            {
                cmbUsuario.Items.Add("");
            }
            else
            {
                int res = BuscarEnCombo(usuario.Nombre, cmbUsuario);
                if (res >= 0)
                {
                    cmbUsuario.SelectedIndex = res;
                }
            }
        }
        private void CargarEstados(string estado)
        {
            cmbEstado.Items.Clear();
            // cargamos el desplegable de usuarios
            cmbEstado.Items.Add("PROGRAMADA");
            cmbEstado.Items.Add("REALIZADA");
            int res = BuscarEnCombo(estado, cmbEstado);
            if (res >= 0)
            {
                cmbEstado.SelectedIndex = res;
            }
        }
      
        private int BuscarEnCombo(string texto, ComboBox cmb)
        {
            int res = -1;
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if ((string)cmb.Items[i] == texto)
                {
                    res = i;
                    break;
                }
            }
            return res;
        }
        private void mnuAceptar_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            bool newRecord = false;
            if (sustitucion == null)
            {
                newRecord = true;
                sustitucion = new TSustitucion();
            }
            DescargarPantalla(newRecord);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Sustitución guardada", "AVISO");
            Cursor.Current = Cursors.WaitCursor;
            SustitucionesGrid sGrid;
            switch (caller)
            {
                case "dispositivo":
                    sGrid = new SustitucionesGrid(caller, dispositivo, usuario);
                    sGrid.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    sGrid = new SustitucionesGrid(caller, revision, usuario);
                    sGrid.Show();
                    break;
                default:
                    sGrid = new SustitucionesGrid(usuario);
                    sGrid.Show();
                    break;
            }
            this.Close();
        }
        private bool DatosOk()
        {
            // verificar que se ha seleccionado al menos un usuario.
            if ((string)cmbUsuario.SelectedItem == "" || cmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Se necesita un usuario", "AVISO");
                return false;
            }
            // Verificar que hay un dispositivo original asignado
            CntSciTerminal.TOpen(this.conn);
            if (lblDOId.Text == "" || CntSciTerminal.GetTDispositivo(lblDOId.Text, conn) == null)
            {
                MessageBox.Show("Se necesita un dispositivo a sustituir", "AVISO");
                return false;
            }
            CntSciTerminal.TClose(this.conn);
            // Verificar que hay un dispositivo sustituto asignado
            //if (lblDSId.Text == "" || LainsaTerminalLib.CntSciTerminal.GetTDispositivo(lblDSId.Text, conn) == null)
            //{
            //    MessageBox.Show("Se necesita un dispositivo sustituto", "AVISO");
            //    return false;
            //}
            // Verificar que hay una fecha_apertura seleccionada
            if (dtpFecha.Value == null)
            {
                MessageBox.Show("Se necesita una fecha_apertura", "AVISO");
                return false;
            }
            if ((string)cmbEstado.SelectedItem == "" || cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Se necesita un estado", "AVISO");
                return false;
            }
            // si llega aquí se supone que esta todo ok
            return true;

        }
        private void DescargarPantalla(bool newRecord)
        {
            CntSciTerminal.TOpen(this.conn);
            sustitucion.TUsuario = CntSciTerminal.GetTUsuario((string)cmbUsuario.SelectedItem, conn);
            if (dtpFecha.Value != null)
                sustitucion.Fecha = dtpFecha.Value;
            sustitucion.Estado = (string)cmbEstado.SelectedItem;
            sustitucion.TDispositivoOriginal = CntSciTerminal.GetTDispositivo(lblDOId.Text, conn);
            string estado_sust = "A";
            if (sustitucion.Estado == "REALIZADA")
            {
                sustitucion.TDispositivoOriginal.Estado = "A";
                estado_sust = "N";
                sustitucion.Fecha = DateTime.Now;
            }
            TDispositivo dispS = null;
            if ((dispS = CntSciTerminal.GetTDispositivo(lblDSId.Text, conn)) != null)
            {
                sustitucion.TDispositivoSustituto = dispS;
                sustitucion.TDispositivoSustituto.Estado = estado_sust;
            }
            if (this.revision != null)
                sustitucion.TRevision = this.revision;
            sustitucion.Comentarios = txtComentario.Text;
            CntSciTerminal.TSave(newRecord, sustitucion, conn);
            CntSciTerminal.TClose(this.conn);
        }
        private void btnDO_Click(object sender, EventArgs e)
        {
            if (txtDispO.Text != "")
            {
                CntSciTerminal.TOpen(this.conn);
                TDispositivo d = LainsaTerminalLib.CntSciTerminal.GetTDispositivo(txtDispO.Text, conn);
                if (d == null)
                {
                    MessageBox.Show("No hay ningún dispositivo con ese código", "AVISO",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                

                }
                else if (d.Estado != "N")
                {
                    MessageBox.Show("El dispositivo que ha introducido existe pero no es correcto.\nSu estado es de ALMACÉN / SUSTITUTO.", "AVISO",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    lblDOId.Text = txtDispO.Text;
                    txtDispODatos.Text = String.Format("{0} ({1}) [{2}]",
                         d.Nombre, d.Instalacion.Nombre, d.Tipo.Nombre);
                }
                CntSciTerminal.TClose(this.conn);
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            if (txtDispS.Text != "")
            {
                CntSciTerminal.TOpen(this.conn);
                TDispositivo d = LainsaTerminalLib.CntSciTerminal.GetTDispositivo(txtDispS.Text, conn);
                if (d == null)
                {
                      MessageBox.Show("No hay ningún dispositivo con ese código", "AVISO",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else if (d.Estado == "N")
                {
                    MessageBox.Show("El dispositivo que ha introducido existe pero no es correcto.\nSu estado NO es de ALMACÉN ni SUSTITUTO.", "AVISO",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                     lblDSId.Text = txtDispS.Text;
                    txtDispSDatos.Text = String.Format("{0} ({1}) [{2}]",
                         d.Nombre, d.Instalacion.Nombre, d.Tipo.Nombre);
                }
                CntSciTerminal.TClose(this.conn);
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SustitucionesGrid sGrid;
            switch (caller)
            {
                case "dispositivo":
                    sGrid = new SustitucionesGrid(caller, dispositivo, usuario);
                    sGrid.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    sGrid = new SustitucionesGrid(caller, revision, usuario);
                    sGrid.Show();
                    break;
                default:
                    sGrid = new SustitucionesGrid(usuario);
                    sGrid.Show();
                    break;
            }
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Seguro que desea eliminar la sustitución?", "Eliminar", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                Cursor.Current = Cursors.WaitCursor;
                if (result == DialogResult.Yes)
                {
                    CntSciTerminal.TOpen(this.conn);
                    CntSciTerminal.TDelete(sustitucion, conn);
                    CntSciTerminal.TClose(this.conn);
                    SustitucionesGrid sGrid;
                    switch (caller)
                    {
                        case "dispositivo":
                            sGrid = new SustitucionesGrid(caller, dispositivo, usuario);
                            sGrid.Show();
                            break;
                        case "programa":
                        case "dispositivoGrid":
                        case "dispRev":
                            sGrid = new SustitucionesGrid(caller, revision, usuario);
                            sGrid.Show();
                            break;
                        default:
                            sGrid = new SustitucionesGrid(usuario);
                            sGrid.Show();
                            break;
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al intentar eliminar la sustitución.\n{0}", ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void SustitucionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                mnuAceptar_Click(null, null);
            }

        }
    }
}