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
    public partial class IncidenciasEvolucionGrid : Form
    {
        private SqlCeConnection conn;
        private TUsuario usuario;
        private TIncidencia incidencia;
        private string caller;
                
        public IncidenciasEvolucionGrid(TIncidencia incidencia, TUsuario usuario)
        {
            this.caller = "";
            this.usuario = usuario;
            this.incidencia = incidencia;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            // limpiar las etiquetas
            lblDispositivo.Text = "";
            lblFechas.Text = "";
            lblEstadoPrioridad.Text = "";
            lblResponsable.Text = "";
            // cargar los datos de etiquetas
            lblDispositivo.Text = incidencia.NDispositivo;
            lblFechas.Text = String.Format("FA:{0:dd/MM/yyyy} - FC:{1:dd/MM/yyyy}", incidencia.FechaApertura, incidencia.FechaCierre);
            if (incidencia.TEstado != null && incidencia.TPrioridad != null)
                lblEstadoPrioridad.Text = String.Format("{0} - {1}", incidencia.TEstado.Nombre, incidencia.TPrioridad.Nombre);
            if (incidencia.TResponsable != null)
                lblResponsable.Text = incidencia.TResponsable.Nombre;
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public void CargarGrid()
        {
            IList<TIncidenciaEvolucion> lts = null;
            CntSciTerminal.TOpen(this.conn);
            lts = CntSciTerminal.GetTIncidenciaEvolucions(incidencia, conn);
            CntSciTerminal.TClose(this.conn);
            grdIncidenciaEvolucion.DataSource = lts.ToArray<TIncidenciaEvolucion>();
            CrearEstiloColumnas();
        }
        public void CrearEstiloColumnas()
        {
            DataGridTableStyle prgEstilo = new DataGridTableStyle();
            prgEstilo.MappingName = "TIncidenciaEvolucion[]";
            DataGridTextBoxColumn colFechaApertura = new DataGridTextBoxColumn();
            colFechaApertura.HeaderText = "Fecha";
            colFechaApertura.MappingName = "FechaEvolucion";
            colFechaApertura.Format = "dd/MM/yyyy";
            colFechaApertura.Width = 60;
            DataGridTextBoxColumn colComentarios = new DataGridTextBoxColumn();
            colComentarios.HeaderText = "Comentarios";
            colComentarios.MappingName = "Comentarios";
            colComentarios.Width = 120;
            DataGridTextBoxColumn colUsuario = new DataGridTextBoxColumn();
            colUsuario.HeaderText = "Usuario";
            colUsuario.MappingName = "NUsuario";
            colUsuario.Width = 100;
            DataGridTextBoxColumn colOperativo= new DataGridTextBoxColumn();
            colOperativo.HeaderText = "Operativo";
            colOperativo.MappingName = "Operativo";
            colOperativo.Width = 60;

            prgEstilo.GridColumnStyles.Add(colFechaApertura);
            prgEstilo.GridColumnStyles.Add(colComentarios);
            prgEstilo.GridColumnStyles.Add(colUsuario);
            prgEstilo.GridColumnStyles.Add(colOperativo);
            
            grdIncidenciaEvolucion.TableStyles.Clear();
            grdIncidenciaEvolucion.TableStyles.Add(prgEstilo);
        }
        
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            IncidenciasForm ifrm = new IncidenciasForm(incidencia, "IncidenciaEvolucion", usuario);
            ifrm.Show();
            this.Close();

        }
        
        private void mnuNueva_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IncidenciaEvolucionForm iefrm = new IncidenciaEvolucionForm(incidencia, usuario);
            iefrm.Show();
            this.Close();
        }


        private void grdIncidenciaEvolucion_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = grdIncidenciaEvolucion.CurrentRowIndex;
            if (i >= 0)
            {
                TIncidenciaEvolucion[] atp = (TIncidenciaEvolucion[])grdIncidenciaEvolucion.DataSource;
                TIncidenciaEvolucion tp = atp[i];
                IncidenciaEvolucionForm iefrm = new IncidenciaEvolucionForm(tp);
                iefrm.Show();
                this.Close();
            }
            Cursor.Current = Cursors.Default;
        }

      }
}