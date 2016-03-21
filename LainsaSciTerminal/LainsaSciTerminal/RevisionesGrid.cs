using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlServerCe;
using LainsaTerminalLib;
using System.Windows.Forms;
using PaintCells;
namespace LainsaSciTerminal
{
    public partial class RevisionesGrid : Form
    {
        private string caller;
        private SqlCeConnection conn;
        public TPrograma vPrograma;
        private TUsuario usuario;
        private TDispositivo vDispositivo;
        public RevisionesGrid(TPrograma prg, TUsuario usuario)
        {
            this.caller = "programa";
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            vPrograma = prg;
            CargarGrid();
            lblInst.Text = vPrograma.NInstalacion;
            Cursor.Current = Cursors.Default;
        }
        public RevisionesGrid(string caller, TDispositivo dsp, TUsuario usuario)
        {
            this.caller = caller;
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            vDispositivo = dsp;
            CargarGrid();
            lblInst.Text = dsp.Instalacion.Nombre;
            Cursor.Current = Cursors.Default;
        }
        public void CargarGrid()
        {
            IList<TRevision> ltr;
            CntSciTerminal.TOpen(this.conn);
            if (vPrograma != null)
                ltr = CntSciTerminal.GetTRevisiones(vPrograma, conn);
            else
                ltr = CntSciTerminal.GetTRevisiones(false, vDispositivo, conn);
            CntSciTerminal.TClose(this.conn); 
            grdRevisiones.DataSource = ltr.ToArray<TRevision>();
            CrearEstiloColumnas();
            MostrarResumen(ltr);
           
        }
        public void CrearEstiloColumnas()
        {
            DataGridTableStyle prgEstilo = new DataGridTableStyle();
            prgEstilo.MappingName = "TRevision[]";
            DataGridTextBoxColumn colId = new DataGridTextBoxColumn();
            colId.HeaderText = "ID";
            colId.MappingName = "RevisionId";
            colId.Width = 40;
            DataGridTextBoxColumn colFecha = new DataGridTextBoxColumn();
            colFecha.HeaderText = "Fecha Pl.";
            colFecha.MappingName = "FechaPlanificada";
            colFecha.Format = "dd/MM/yyyy";
            colFecha.Width = 60;
            DataGridTextBoxColumn colInstalacion = new DataGridTextBoxColumn();
            colInstalacion.HeaderText = "Instalación";
            colInstalacion.MappingName = "NInstalacion";
            colInstalacion.Width = 120;
            DataGridTextBoxColumn colEstado = new DataGridTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.MappingName = "Estado";
            colEstado.Width = 60;
            //DataSet myDataSet = new DataSet();
            //PropertyDescriptorCollection pcol = this.BindingContext[myDataSet, "Table1"].GetItemProperties();
            //DataGridTextBoxColumn colEstado = new ColumnStyle(pcol["Table1"] as PropertyDescriptor);

            DataGridTextBoxColumn colDispositivo = new DataGridTextBoxColumn();
            colDispositivo.HeaderText = "Dispositivo";
            colDispositivo.MappingName = "NDispositivo";
            colDispositivo.Width = 120;
            DataGridTextBoxColumn colPosicion = new DataGridTextBoxColumn();
            colPosicion.HeaderText = "Ubicación";
            colPosicion.MappingName = "Posicion";
            colPosicion.Width = 120;
            prgEstilo.GridColumnStyles.Add(colEstado);
            prgEstilo.GridColumnStyles.Add(colFecha);
            prgEstilo.GridColumnStyles.Add(colDispositivo);
            prgEstilo.GridColumnStyles.Add(colPosicion);
            prgEstilo.GridColumnStyles.Add(colId);
            //prgEstilo.GridColumnStyles.Add(colInstalacion);
            grdRevisiones.TableStyles.Clear();
            grdRevisiones.TableStyles.Add(prgEstilo);
         
        }

        private void grdRevisiones_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = grdRevisiones.CurrentRowIndex;
            if (i >= 0)
            {
                TRevision[] atr = (TRevision[])grdRevisiones.DataSource;
                TRevision tr = atr[i];
                CntSciTerminal.TOpen(this.conn);
                tr = CntSciTerminal.GetTRevision(tr.RevisionId, conn);
                CntSciTerminal.TClose(this.conn);
                if (tr.TPrograma == null)
                {
                    MessageBox.Show("Sólo se puede hacer revisones programadas", "AVISO",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    Cursor.Current = Cursors.Default;
                    return;
                }
                //if (tr.DatosRevision.Count > 0)
                //{
                DistribuidorForm frmDist = new DistribuidorForm(tr, 0, caller, usuario);
                frmDist.Show();
                this.Close();
                //}
            }
            Cursor.Current = Cursors.Default;
        }
        private void MostrarResumen(IList<TRevision> ltr)
        {
            int npla = 0; //sin comenzar
            int npro = 0; //en curso
            int nrea = 0; // finalizada
            foreach (TRevision tr in ltr)
            {
                switch (tr.Estado)
                {
                    case "PLANIFICADA":
                        npla++;
                        break;
                    case "PROGRAMADA":
                        npro++;
                        break;
                    case "REALIZADA":
                        nrea++;
                        break;
                }
            }
            lblPLA.Text = String.Format("PLANIFICADA: {0}", npla);
            lblPRO.Text = String.Format("PROGRAMADA: {0}", npro);
            lblREA.Text = String.Format("REALIZADA: {0}", nrea);
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            switch (caller)
            {
                case "dispositivoGrid":
                    DispForm frmgrdDispositivo = new DispForm(usuario, vDispositivo);
                    frmgrdDispositivo.Show();
                    break;
                case "programa":
                    ProgramacionesGrid prgGrid = new ProgramacionesGrid(usuario);
                    prgGrid.Show();
                    break;
                case "dispRev":
                    CodBarrasForm frmCodBarras = new CodBarrasForm(usuario, true);
                    frmCodBarras.Show();
                    break;
                default:
                   break;
            }

            Cursor.Current = Cursors.Default;
            this.Close();

        }

        private void RevisionesGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                grdRevisiones_DoubleClick(null, null);
            }

        }

        private void grdRevisiones_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void grdRevisiones_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        
    }
}