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
    public partial class IncidenciaEvolucionForm : Form
    {
        private TIncidencia incidencia;
        private TIncidenciaEvolucion incidenciaEvolucion;
        private TUsuario usuario;
        private SqlCeConnection conn;
        private string caller;
        private object callObj;
        private bool newRecord = false;

        public IncidenciaEvolucionForm(TIncidenciaEvolucion incidenciaEvolucion)
        {
            newRecord = false;
            this.incidencia = incidenciaEvolucion.TIncidencia;
            this.incidenciaEvolucion = incidenciaEvolucion;
            this.usuario = incidenciaEvolucion.TUsuario;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            CargarPantalla();
            Cursor.Current = Cursors.Default;
        }

        public IncidenciaEvolucionForm(TIncidencia incidencia, TUsuario usuario)
        {
            newRecord = true;
            this.incidencia = incidencia;
            this.incidenciaEvolucion = new TIncidenciaEvolucion();
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            CargarPantalla();
            Cursor.Current = Cursors.Default;
        }

        private void CargarPantalla()
        {
            txtUser.Text = usuario.Nombre;
            if (newRecord)
            {
                txtFechaEvolucion.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            }
            else
            {
                if (!CntSciTerminal.FechaNula(incidenciaEvolucion.FechaEvolucion))
                    txtFechaEvolucion.Text = String.Format("{0:dd/MM/yyyy}", incidenciaEvolucion.FechaEvolucion);
                txtComentario.Text = incidenciaEvolucion.Comentarios;
                chkOperativo.Checked = !incidenciaEvolucion.Operativo;
            }
        }
        private void mnuAceptar_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            DescargarPantalla(newRecord);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Evolución guardada", "AVISO");
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasEvolucionGrid inGrid;
            inGrid = new IncidenciasEvolucionGrid(incidencia, usuario);
            inGrid.Show();
            this.Close();
        }
        private bool DatosOk()
        {
            // Verificar que hay un dispositivo original asignado
            if (txtComentario.Text == "")
            {
                MessageBox.Show("Se necesita un comentario", "AVISO");
                return false;
            }
            return true;
        }
        private void DescargarPantalla(bool newRecord)
        {
            CntSciTerminal.TOpen(this.conn);
            if (newRecord)
            {
                incidenciaEvolucion.TIncidencia = incidencia;
                incidenciaEvolucion.TUsuario = usuario;
            }
            if (txtFechaEvolucion.Text != null)
                if(newRecord)
                    incidenciaEvolucion.FechaEvolucion = DateTime.Now;
            incidenciaEvolucion.Comentarios = txtComentario.Text;
            incidenciaEvolucion.Operativo = !chkOperativo.Checked;
            CntSciTerminal.TSave(newRecord, incidenciaEvolucion, conn);
            CntSciTerminal.TClose(this.conn);
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasEvolucionGrid iegrd = new IncidenciasEvolucionGrid(incidencia,usuario);
            iegrd.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Seguro que desea eliminar la evolución?", "Eliminar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CntSciTerminal.TOpen(this.conn);
                    CntSciTerminal.TDelete(incidenciaEvolucion, conn);
                    CntSciTerminal.TClose(this.conn);
                    IncidenciasEvolucionGrid iegrd = new IncidenciasEvolucionGrid(incidencia, usuario);
                    iegrd.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al intentar eliminar la evolución.\n{0}", ex.Message) , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            DescargarPantalla(newRecord);
            // la conexión esta cerrada, se reabre aqui.
            CntSciTerminal.TOpen(conn);
            // incidencia padre
            TIncidencia incidencia = incidenciaEvolucion.TIncidencia;
            // al cerrar hay que tomar una fecha de cierre
            incidencia.FechaCierre = DateTime.Now;
            // indicar como quedará el dispositivo
            incidencia.Operativo = incidenciaEvolucion.Operativo;
            // asignar a la incidencia padre el estado en cierre
            incidencia.TEstado = CntSciTerminal.GetTEstadoCierre(conn);
            // guardamos la incidencia padre
            CntSciTerminal.TSave(false, incidencia, conn);
            // podemos cerrar la conexion
            CntSciTerminal.TClose(conn);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Evolución guardada", "AVISO");
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasEvolucionGrid inGrid;
            inGrid = new IncidenciasEvolucionGrid(incidencia, usuario);
            inGrid.Show();
            this.Close();
        }
     }
}