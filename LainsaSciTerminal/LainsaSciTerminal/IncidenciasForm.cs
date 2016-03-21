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
    public partial class IncidenciasForm : Form
    {
        private TIncidencia incidencia;
        private TUsuario usuario;
        private TDispositivo dispositivo;
        private TRevision revision;
        private SqlCeConnection conn;
        private string caller;
        private object callObj;
               
        public IncidenciasForm(TIncidencia incidencia, string caller, TUsuario usuario)
        {
            this.incidencia = incidencia;
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            this.caller = caller;
            this.revision = incidencia.TRevision;
            InitializeComponent();
            dispositivo = incidencia.TDisp;
            CargarPantalla();
            //txtDispO.Enabled = false;
            //btnDO.Enabled = false;
            Cursor.Current = Cursors.Default;
            dtFechaPrevista.Format = DateTimePickerFormat.Custom;
            dtFechaPrevista.CustomFormat = "dd/MM/yyyy";
        }

        public IncidenciasForm(string caller, object callObj, TUsuario usuario)
        {
            this.callObj = callObj;
            this.incidencia = null;
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            this.caller = caller;
            InitializeComponent();
            CargarEstados(null);
            CargarPrioridades(null);
            CargarResponsables(null);
            txtUser.Text = usuario.Nombre;
            txtFechaApertura.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            dtFechaPrevista.Value = DateTime.Now.AddDays(7);
            btnEliminar.Visible = false;
            switch (caller)
            {
                case "dispositivoGrid":
                case "programa":
                case "dispRev":
                    revision =(TRevision)callObj;
                    dispositivo = revision.Dispositivo;
                    CargarDispositivo();
                    break;
                case "dispositivo":
                    dispositivo = (TDispositivo)callObj;
                    CargarDispositivo();
                    break;
                default:
                    panel1.Enabled = true;
                    break;
            }
            Cursor.Current = Cursors.Default;
            dtFechaPrevista.Format = DateTimePickerFormat.Custom;
            dtFechaPrevista.CustomFormat = "dd/MM/yyyy";
        }
        
        public void CargarDispositivo()
        {
            txtDispO.Text = dispositivo.CodBarras;
            lblDOId.Text = txtDispO.Text;
            if (lblDOId.Text != "")
                txtDispODatos.Text = String.Format("{0}({1})[{2}] Operativo:{3}",
                    dispositivo.Nombre, dispositivo.Instalacion.Nombre, dispositivo.Tipo.Nombre, dispositivo.Operativo);
        }
        
        private void CargarPantalla()
        {
            txtUser.Text = incidencia.NUsuario;
            if (!CntSciTerminal.FechaNula(incidencia.FechaApertura))
            {
                txtFechaApertura.Text = String.Format("{0:dd/MM/yyyy}", incidencia.FechaApertura);
                dtFechaPrevista.Value = incidencia.FechaApertura.AddDays(7);
            }
            if (!CntSciTerminal.FechaNula(incidencia.FechaCierre))
                txtFechaCierre.Text = String.Format("{0:dd/MM/yyyy}", incidencia.FechaCierre);
            if (!CntSciTerminal.FechaNula(incidencia.FechaPrevista))
                dtFechaPrevista.Value = (DateTime)incidencia.FechaPrevista;
            txtComentario.Text = incidencia.Comentarios;
            chkOperativo.Checked = !incidencia.Operativo;
            CargarDispositivo();
            CargarEstados(incidencia.TEstado);
            CargarPrioridades(incidencia.TPrioridad);
            CargarResponsables(incidencia.TResponsable);
        }
        
        private void mnuAceptar_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            bool newRecord = false;
            if (incidencia == null)
            {
                newRecord = true;
                incidencia = new TIncidencia();
            }
            DescargarPantalla(newRecord);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Incidencia guardada", "AVISO");
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasGrid inGrid;
            switch (caller)
            {
                case "dispositivo":
                    inGrid = new IncidenciasGrid(caller, dispositivo, usuario);
                    inGrid.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    inGrid = new IncidenciasGrid(caller, revision, usuario);
                    inGrid.Show();
                    break;
                default:
                    inGrid = new IncidenciasGrid(usuario);
                    inGrid.Show();
                    break;
            }
            this.Close();
        }
        
        private bool DatosOk()
        {
            // Verificar que hay un dispositivo original asignado
            CntSciTerminal.TOpen(this.conn);
            if (lblDOId.Text == "" || LainsaTerminalLib.CntSciTerminal.GetTDispositivo(lblDOId.Text, conn) == null)
            {
                MessageBox.Show("Se necesita un dispositivo.", "AVISO");
                return false;
            }
            CntSciTerminal.TClose(this.conn);
            if (txtComentario.Text == "")
            {
                MessageBox.Show("Se necesita un comentario", "AVISO");
                return false;
            }
            if (cmbEstado.Text=="")
            {
                MessageBox.Show("Se necesita un estado", "AVISO");
                return false;
            }
            if (cmbPrioridad.Text=="")
            {
                MessageBox.Show("Se necesita una prioridad", "AVISO");
                return false;
            }
            if (cmbResponsable.Text=="")
            {
                MessageBox.Show("Se necesita un responsable", "AVISO");
                return false;
            }
            return true;

        }
        
        private void DescargarPantalla(bool newRecord)
        {
            CntSciTerminal.TOpen(this.conn);
            if (newRecord)
                incidencia.TUsuario = usuario;
            incidencia.TDisp = CntSciTerminal.GetTDispositivo(lblDOId.Text, conn);
            if (txtFechaApertura.Text != null)
                if(newRecord)
                    incidencia.FechaApertura = DateTime.Now;
            // Fecha prevista de cierre
            if (dtFechaPrevista.Value != null)
                incidencia.FechaPrevista = dtFechaPrevista.Value;
            // ligamos el estado con la fecha de cierre
            TEstado estado = CntSciTerminal.GetTEstado(cmbEstado.Text, conn);
            incidencia.TEstado = estado;
            if (estado.EnCierre)
                incidencia.FechaCierre = DateTime.Now;
            // prioridades
            incidencia.TPrioridad = CntSciTerminal.GetTPrioridad(cmbPrioridad.Text, conn);
            // responsables
            incidencia.TResponsable = CntSciTerminal.GetTResponsable(cmbResponsable.Text, conn);
            incidencia.Comentarios = txtComentario.Text;
            incidencia.Operativo = !chkOperativo.Checked;
            if (dispositivo != null)
                dispositivo.Operativo = incidencia.Operativo;
            CntSciTerminal.TSave(newRecord, incidencia, conn);
            CntSciTerminal.TClose(this.conn);
        }
        
        private void btnDO_Click(object sender, EventArgs e)
        {
            if (txtDispO.Text != "")
            {
                CntSciTerminal.TOpen(this.conn);
                TDispositivo d = LainsaTerminalLib.CntSciTerminal.GetTDispositivo(txtDispO.Text, conn);
                CntSciTerminal.TClose(this.conn);
                if (d != null)
                {
                    lblDOId.Text = txtDispO.Text;
                    txtDispODatos.Text = String.Format("{0} ({1}) [{2}] Operativo:{3}",
                         d.Nombre, d.Instalacion.Nombre, d.Tipo.Nombre, d.Operativo);

                }
                else{
                MessageBox.Show("No hay ningún dispositivo con ese código", "AVISO",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasGrid inGrid;
            switch (caller)
            {
                case "dispositivo":
                    inGrid = new IncidenciasGrid(caller, dispositivo, usuario);
                    inGrid.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    inGrid = new IncidenciasGrid(caller, revision, usuario);
                    inGrid.Show();
                    break;
                default:
                    inGrid = new IncidenciasGrid(usuario);
                    inGrid.Show();
                    break;
            }
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Seguro que desea eliminar la incidencia?", "Eliminar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CntSciTerminal.TOpen(this.conn);
                    CntSciTerminal.TDelete(incidencia, conn);
                    CntSciTerminal.TClose(this.conn);
                    IncidenciasGrid inGrid;
                    switch (caller)
                    {
                        case "dispositivo":
                            inGrid = new IncidenciasGrid(caller, dispositivo, usuario);
                            inGrid.Show();
                            break;
                        case "programa":
                        case "dispositivoGrid":
                        case "dispRev":
                            inGrid = new IncidenciasGrid(caller, revision, usuario);
                            inGrid.Show();
                            break;
                        default:
                            inGrid = new IncidenciasGrid(usuario);
                            inGrid.Show();
                            break;
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al intentar eliminar la incidencia.\n{0}", ex.Message) , "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void IncidenciasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                mnuAceptar_Click(null, null);
            }

        }
        
        private void CargarEstados(TEstado estado)
        {
            cmbEstado.Items.Clear();
            // cargamos el desplegable.
            CntSciTerminal.TOpen(this.conn);
            foreach (TEstado e in CntSciTerminal.GetTEstados(conn))
            {
                cmbEstado.Items.Add(e.Nombre);
            }
            if (estado != null)
            {
                cmbEstado.Text = estado.Nombre;
            }
            else
            {
                cmbEstado.Items.Add("");
                cmbEstado.Text = "";
            }
            CntSciTerminal.TClose(this.conn);
        }
        private void CargarPrioridades(TPrioridad prioridad)
        {
            cmbPrioridad.Items.Clear();
            // cargamos el desplegable.
            CntSciTerminal.TOpen(this.conn);
            foreach (TPrioridad p in CntSciTerminal.GetTPrioridads(conn))
            {
                cmbPrioridad.Items.Add(p.Nombre);
            }
            if (prioridad != null)
            {
                cmbPrioridad.Text = prioridad.Nombre;
            }
            else
            {
                cmbPrioridad.Text = "";
            }
            CntSciTerminal.TClose(this.conn);
        }
        private void CargarResponsables(TResponsable responsable)
        {
            cmbResponsable.Items.Clear();
            // cargamos el desplegable.
            CntSciTerminal.TOpen(this.conn);
            foreach (TResponsable r in CntSciTerminal.GetTResponsables(conn))
            {
                cmbResponsable.Items.Add(r.Nombre);
            }
            if (responsable != null)
            {
                cmbResponsable.Text = responsable.Nombre;
            }
            else
            {
                cmbResponsable.Text = "";
            }
            CntSciTerminal.TClose(this.conn);
        }

        private void btnEvolucion_Click(object sender, EventArgs e)
        {
            // Habrá que llamar a un grid de evolución.
            IncidenciasEvolucionGrid iegrd = new IncidenciasEvolucionGrid(incidencia, usuario);
            iegrd.Show();
            this.Close();
        }
     }
}