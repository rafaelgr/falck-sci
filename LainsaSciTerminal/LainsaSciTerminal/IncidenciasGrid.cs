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
    public partial class IncidenciasGrid : Form
    {
        private SqlCeConnection conn;
        private TUsuario usuario;
        private TRevision revision;
        private TDispositivo disposit;
        private string caller;
                
        public IncidenciasGrid(TUsuario usuario)
        {
            this.caller = "";
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public IncidenciasGrid(string caller, TDispositivo disposit, TUsuario usuario)
        {
            this.conn = CntSciTerminal.TSqlConnection();
            this.usuario = usuario;
            this.caller = caller;
            this.disposit = disposit;
            InitializeComponent();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public IncidenciasGrid(string caller, TRevision revision, TUsuario usuario)
        {
            this.conn = CntSciTerminal.TSqlConnection();
            this.usuario = usuario;
            this.caller = caller;
            this.revision = revision;
            disposit = revision.Dispositivo;
            InitializeComponent();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public void CargarGrid()
        {
            IList<TIncidencia> lts = null;
            CntSciTerminal.TOpen(this.conn);
            if (caller == "")
                lts = CntSciTerminal.GetTIncidencias(conn);
            else
                lts = CntSciTerminal.GetTIncidencias(disposit, conn);
            CntSciTerminal.TClose(this.conn);
            grdIncidencias.DataSource = lts.ToArray<TIncidencia>();
            CrearEstiloColumnas();
        }
        public void CrearEstiloColumnas()
        {
            DataGridTableStyle prgEstilo = new DataGridTableStyle();
            prgEstilo.MappingName = "TIncidencia[]";
            DataGridTextBoxColumn colFechaApertura = new DataGridTextBoxColumn();
            colFechaApertura.HeaderText = "Apertura";
            colFechaApertura.MappingName = "FechaApertura";
            colFechaApertura.Format = "dd/MM/yyyy";
            colFechaApertura.Width = 60;
            DataGridTextBoxColumn colFechaPrevista = new DataGridTextBoxColumn();
            colFechaPrevista.HeaderText = "Prevista";
            colFechaPrevista.MappingName = "FechaPrevista";
            colFechaPrevista.Format = "dd/MM/yyyy";
            colFechaPrevista.Width = 60;
            DataGridTextBoxColumn colFechaCierre = new DataGridTextBoxColumn();
            colFechaCierre.HeaderText = "Cierre";
            colFechaCierre.MappingName = "FechaCierre";
            colFechaCierre.Format = "dd/MM/yyyy";
            colFechaCierre.Width = 60;
            DataGridTextBoxColumn colEstado = new DataGridTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.MappingName = "Estado";
            colEstado.Width = 60;
            DataGridTextBoxColumn colDispositivoO = new DataGridTextBoxColumn();
            colDispositivoO.HeaderText = "Dispositivo";
            colDispositivoO.MappingName = "NDispositivo";
            colDispositivoO.Width = 120;
            DataGridTextBoxColumn colUsuario = new DataGridTextBoxColumn();
            colUsuario.HeaderText = "Usuario";
            colUsuario.MappingName = "NUsuario";
            colUsuario.Width = 100;
            DataGridTextBoxColumn colOperativo= new DataGridTextBoxColumn();
            colOperativo.HeaderText = "Operativo";
            colOperativo.MappingName = "Operativo";
            colOperativo.Width = 60;

            prgEstilo.GridColumnStyles.Add(colFechaApertura);
            prgEstilo.GridColumnStyles.Add(colFechaPrevista);
            prgEstilo.GridColumnStyles.Add(colFechaCierre);
            prgEstilo.GridColumnStyles.Add(colEstado);
            prgEstilo.GridColumnStyles.Add(colUsuario);
            prgEstilo.GridColumnStyles.Add(colOperativo);

            if (revision == null)
                prgEstilo.GridColumnStyles.Add(colDispositivoO);
            
            grdIncidencias.TableStyles.Clear();
            grdIncidencias.TableStyles.Add(prgEstilo);
        }
        
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            switch (caller)
            {
                case "dispositivo":
                    DispForm dspFormGrid = new DispForm(usuario, disposit);
                    dspFormGrid.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    CFinalForm frmFinal = new CFinalForm(revision, revision.DatosRevision.Count, caller, usuario);
                    frmFinal.Show();
                    break;
                default:
                    MenuForm frmMenu = new MenuForm(usuario);
                    frmMenu.Show();
                    break;
            }
            //if (caller == "")
            //{
            //    MenuForm frmMenu = new MenuForm(usuario);
            //    frmMenu.Show();
            //}
            //else if (revision != null)
            //{
            //    CFinalForm frmFinal = new CFinalForm(revision, revision.DatosRevision.Count, caller, usuario);
            //    frmFinal.Show();
            //}
            //else
            //{
            //    DispForm form = new DispForm(usuario, disposit);
            //    form.Show();
            //}
            this.Close();

        }

        private void grdIncidencias_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = grdIncidencias.CurrentRowIndex;
            if (i >= 0)
            {
                TIncidencia[] atp = (TIncidencia[])grdIncidencias.DataSource;
                TIncidencia tp = atp[i];
                tp.TRevision = this.revision;
                IncidenciasForm inform = new IncidenciasForm(tp, caller, usuario);
                inform.Show();
                this.Close();
            }
            Cursor.Current = Cursors.Default;
        }
      

        private void mnuNueva_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasForm inform;
            switch (caller)
            {
                case "dispositivo":
                    inform = new IncidenciasForm(caller, disposit, usuario);
                    inform.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    inform = new IncidenciasForm(caller, revision, usuario);
                    inform.Show();
                    break;
                default:
                     inform = new IncidenciasForm("main", null, usuario);
                    inform.Show();
                    break;
            }

            this.Close();
        }

        private void IncidenciasGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                grdIncidencias_DoubleClick(null, null);
            }

        }
        public string FormatFechaNula(DateTime f)
        {
            string s = String.Format("dd/MM/yyyy", f);
            if (s == "01/01/0001") s = "";
            return s;
        }

      }
}