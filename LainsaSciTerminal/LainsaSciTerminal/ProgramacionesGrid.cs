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
    public partial class ProgramacionesGrid : Form
    {
        private SqlCeConnection conn;
        TUsuario usuario;
        public ProgramacionesGrid(TUsuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.conn = CntSciTerminal.TSqlConnection();
            CargarGrid();
            Cursor.Current = Cursors.Default;
        }
        public void CargarGrid()
        {
            IList<TPrograma> ltp = null;
            CntSciTerminal.TOpen(this.conn);
            if(usuario.TGrupoTrabajo == null)
                ltp = CntSciTerminal.GetTProgramasC(conn);
            else
                ltp = CntSciTerminal.GetTProgramasC(usuario.TGrupoTrabajo.GrupoTrabajoId, conn);
            CntSciTerminal.TClose(this.conn);
            grdProgramas.DataSource = ltp.ToArray<TPrograma>();
            CrearEstiloColumnas();
            MostrarResumen(ltp);
        }
        public void CrearEstiloColumnas()
        {
            DataGridTableStyle prgEstilo = new DataGridTableStyle();
            prgEstilo.MappingName = "TPrograma[]";
            DataGridTextBoxColumn colId = new DataGridTextBoxColumn();
            colId.HeaderText = "ID";
            colId.MappingName = "ProgramaId";
            colId.Width = 40;
            DataGridTextBoxColumn colFecha= new DataGridTextBoxColumn();
            colFecha.HeaderText = "Fecha";
            colFecha.MappingName = "FechaProgramada";
            colFecha.Format = "dd/MM/yyyy";
            colFecha.Width = 60;
            DataGridTextBoxColumn colInstalacion = new DataGridTextBoxColumn();
            colInstalacion.HeaderText = "Instalación";
            colInstalacion.MappingName = "NInstalacion";
            colInstalacion.Width = 120;
            DataGridTextBoxColumn colEstado = new DataGridTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.MappingName = "Estado";
            colEstado.Width = 120;
            DataGridTextBoxColumn colComentario = new DataGridTextBoxColumn();
            colComentario.HeaderText = "Comentarios";
            colComentario.MappingName = "Comentarios";
            colComentario.Width = 200;

            prgEstilo.GridColumnStyles.Add(colId);
            prgEstilo.GridColumnStyles.Add(colFecha);
            prgEstilo.GridColumnStyles.Add(colInstalacion);
            prgEstilo.GridColumnStyles.Add(colEstado);
            prgEstilo.GridColumnStyles.Add(colComentario);
            grdProgramas.TableStyles.Clear();
            grdProgramas.TableStyles.Add(prgEstilo);
        }

        private void grdProgramas_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int i = grdProgramas.CurrentRowIndex;
            if (i >= 0)
            {
                TPrograma[] atp = (TPrograma[])grdProgramas.DataSource;
                TPrograma tp = atp[i];
                RevisionesGrid grdRevisiones = new RevisionesGrid(tp, usuario);
                grdRevisiones.Show();
                this.Close();
            }
            Cursor.Current = Cursors.Default;
        }
        private void MostrarResumen(IList<TPrograma> ltp)
        {
            int nsc = 0; //sin comenzar
            int nec = 0; //en curso
            int nf = 0; // finalizada
            foreach (TPrograma tp in ltp)
            {
                if (tp.Estado.IndexOf("SIN COMENZAR") != -1)
                    nsc++;
                else if (tp.Estado.IndexOf("EN CURSO") != -1)
                    nec++;
                else if (tp.Estado.IndexOf("FINALIZADA") != -1)
                    nf++;
            }
            lblSC.Text = String.Format("SIN COMENZAR: {0}", nsc);
            lblEC.Text = String.Format("EN CURSO: {0}", nec);
            lblF.Text = String.Format("FINALIZADA: {0}", nf);
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            MenuForm frmMenu = new MenuForm(usuario);
            frmMenu.Show();
            this.Close();

        }

        private void mnuProgramaciones_Click(object sender, EventArgs e)
        {
            ProgramacionesGrid prgGrid = new ProgramacionesGrid(usuario);
            prgGrid.Show();
            this.Close();
        }

        private void ProgramacionesGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                grdProgramas_DoubleClick(null, null);
            }

        }

    }
}