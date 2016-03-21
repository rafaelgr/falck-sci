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
    public partial class CTetraForm : Form
    {
        TRevision tr = null;
        int pos = 0;
        TDatoRevision tdr = null;
        TDispositivo dsp = null;
        TPrograma prg = null;
        string caller = "";
        TUsuario usuario = null;
        private SqlCeConnection conn;
        
        public CTetraForm(TRevision tr, int pos, string caller, TUsuario usuario)
        {
            this.usuario = usuario;
            this.tr = tr;
            this.pos = pos;
            this.caller = caller;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            VerificarPosicion();
            tdr = tr.DatosRevision[pos];
            lblNombre.Text = tdr.Nombre;
            optOk.Checked = true;
            SetValor(tdr.Valor);
            CargarTitulos();
            Cursor.Current = Cursors.Default;
        }

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
                    IList<TRevision> ltr = CntSciTerminal.GetTRevisiones(true, tr.Dispositivo, conn);
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
        private void CargarTitulos()
        {
            lblPlantilla.Text = String.Format("[{0:dd/MM/yy}] {1}",
                tr.FechaPlanificada,
                tr.Plantilla);
            string modelo = "";
            if (tr.Dispositivo.Modelo != null)
                modelo = tr.Dispositivo.Modelo.Nombre;
            lblDispositivo.Text = String.Format("{0} / [{1}]",
                tr.Dispositivo.Nombre,
                modelo);
            lblPosicion.Text = tr.Dispositivo.Posicion;
            label1.Text = String.Format("{0} / {1}",
                pos + 1,
                tr.DatosRevision.Count);
        }
        private void VerificarPosicion()
        {
            if (pos < 0 || pos > tr.DatosRevision.Count)
            {
                MessageBox.Show("Número de campos incorrecto", "AVISO");
            }
            else if (pos == tr.DatosRevision.Count - 1)
            {
                mnuSiguiente.Enabled = false;
                mnuUltimo.Enabled = false;
            }
        }

        private void LlamarDistribuidor()
        {
            Cursor.Current = Cursors.WaitCursor;
            // siemprte antes de la llamada salvamos los datos actuales
            tdr.Valor = GetValor();
           // CntSciTerminal.TSave(tdr, conn);
            DistribuidorForm frmDist = new DistribuidorForm(tr, pos, caller, usuario);
            frmDist.Show();
            this.Close();
        }
        public string GetValor()
        {
            string c1 = "";
            if (optOk.Checked) c1 = "S";
            if (optMAL.Checked) c1 = "N";
            if (optNA.Checked) c1 = "NA";
            return String.Format("{0}|{1}",
                c1,
                txtComentarios.Text);
        }
        public void SetValor(string valor)
        {
            if (valor == null) return;
            // Tiene dos campos
            int pos1 = valor.IndexOf("|");
            if (pos1 < 0) return;
            string c1 = valor.Substring(0, pos1); ;
            string c2 = valor.Substring(pos1 + 1, valor.Length - (pos1 + 1));
            switch (c1)
            {
                case "S":
                    optOk.Checked = true;
                    break;
                case "N":
                    optMAL.Checked = true;
                    break;
                case "NA":
                    optNA.Checked = true;
                    break;
            }
            txtComentarios.Text = c2;
        }

        private void mnuFin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            tdr.Valor = GetValor();
            //CntSciTerminal.TSave(tdr, conn);
            CFinalForm frmFinal = new CFinalForm(tr, tr.DatosRevision.Count, caller, usuario);
            frmFinal.Show();
            this.Close();
        }

        private void CTetraForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                pos++;
                if (pos >= tr.DatosRevision.Count)
                    mnuFin_Click(null, null);
                else
                    LlamarDistribuidor();
            }

        }

    }
}