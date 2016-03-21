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
    public partial class SustitucionesGrid : Form
    {
        private SqlCeConnection conn;
        private TUsuario usuario;
        private TRevision revision;
        private TDispositivo dispositivo;
        private string caller;

        public SustitucionesGrid(TUsuario usuario)
        {
            this.caller = "";
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public SustitucionesGrid(string caller, TRevision revision, TUsuario usuario)
        {
            this.usuario = usuario;
            this.caller = caller;
            this.revision = revision;
            this.dispositivo = revision.Dispositivo;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public SustitucionesGrid(string caller, TDispositivo dispositivo, TUsuario usuario)
        {
            this.usuario = usuario;
            this.caller = caller;
            this.dispositivo = dispositivo;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public void CargarGrid()
        {
            IList<TSustitucion> lts = null;
            CntSciTerminal.TOpen(this.conn);
            if (caller != "")
                lts = CntSciTerminal.GetTSustituciones(dispositivo, conn);
            else
                lts = CntSciTerminal.GetTSustituciones(conn);
            CntSciTerminal.TClose(this.conn);
            grdSustituciones.DataSource = lts.ToArray<TSustitucion>();
            CrearEstiloColumnas();
        }
        public void CrearEstiloColumnas()
        {
            DataGridTableStyle prgEstilo = new DataGridTableStyle();
            prgEstilo.MappingName = "TSustitucion[]";
            //DataGridTextBoxColumn colId = new DataGridTextBoxColumn();
            //colId.HeaderText = "ID";
            //colId.MappingName = "SustitucionId";
            //colId.Width = 40;
            DataGridTextBoxColumn colFecha = new DataGridTextBoxColumn();
            colFecha.HeaderText = "Fecha";
            colFecha.MappingName = "Fecha";
            colFecha.Format = "dd/MM/yyyy";
            colFecha.Width = 60;
            DataGridTextBoxColumn colInstalacion = new DataGridTextBoxColumn();
            colInstalacion.HeaderText = "Instalación";
            colInstalacion.MappingName = "NInstalacion";
            colInstalacion.Width = 120;
            DataGridTextBoxColumn colDispositivoO = new DataGridTextBoxColumn();
            colDispositivoO.HeaderText = "D.Original";
            colDispositivoO.MappingName = "NDispositivoO";
            colDispositivoO.Width = 120;
            DataGridTextBoxColumn colDispositivoS = new DataGridTextBoxColumn();
            colDispositivoS.HeaderText = "D.Sustituto";
            colDispositivoS.MappingName = "NDispositivoS";
            colDispositivoS.Width = 120;

            //prgEstilo.GridColumnStyles.Add(colId);
            prgEstilo.GridColumnStyles.Add(colFecha);
            prgEstilo.GridColumnStyles.Add(colInstalacion);
            if (revision == null)
                prgEstilo.GridColumnStyles.Add(colDispositivoO);
            prgEstilo.GridColumnStyles.Add(colDispositivoS);
            grdSustituciones.TableStyles.Clear();
            grdSustituciones.TableStyles.Add(prgEstilo);
        }
        private void grdSustituciones_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = grdSustituciones.CurrentRowIndex;
            if (i >= 0)
            {
                TSustitucion[] atp = (TSustitucion[])grdSustituciones.DataSource;
                TSustitucion tp = atp[i];
                tp.TRevision = this.revision;
                SustitucionForm sustform = new SustitucionForm(tp, caller, usuario);
                sustform.Show();
                this.Close();
            }
            Cursor.Current = Cursors.Default;
        }
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            switch (caller)
            {
                case "dispositivo":
                    DispForm form = new DispForm(usuario, dispositivo);
                    form.Show();
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

           this.Close();
        }

        private void mnuCambio_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SustitucionForm sustform;
            switch (caller)
            {
                case "dispositivo":
                    sustform = new SustitucionForm(caller, dispositivo, usuario);
                    sustform.Show();
                    break;
                case "programa":
                case "dispositivoGrid":
                case "dispRev":
                    sustform = new SustitucionForm(caller, revision, usuario);
                    sustform.Show();
                    break;
                default:
                    sustform = new SustitucionForm("main", null, usuario);
                    sustform.Show();
                    break;
            }

            //if (caller == "")
            //    sustform = new SustitucionForm("main", null, usuario);
            //else if (revision != null)
            //    sustform = new SustitucionForm(caller, revision, usuario);
            //else
            //    sustform = new SustitucionForm(caller, dispositivo, usuario);
            //sustform.Show();
            this.Close();
        }

        private void SustitucionesGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                grdSustituciones_DoubleClick(null, null);
            }

        }
    }
}