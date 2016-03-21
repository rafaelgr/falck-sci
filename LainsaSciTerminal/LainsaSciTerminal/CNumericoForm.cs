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
    public partial class CNumericoForm : Form
    {
        TRevision tr = null;
        int pos = 0;
        TDatoRevision tdr = null;
        TUsuario usuario = null;
        TDispositivo dsp = null;
        TPrograma prg = null;
        string caller = "";
        private SqlCeConnection conn;
        
        public CNumericoForm(TRevision tr, int pos, string caller, TUsuario usuario)
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
            lblPlantilla.Text = String.Format("[{0:dd/MM/yy}] {1} ({2}/{3})",
                tr.FechaPlanificada,
                tr.Plantilla,
                pos + 1,
                tr.DatosRevision.Count);
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
        public string GetValor()
        {
            return String.Format("{0}|{1}",
                txtValor.Text,
                txtComentarios.Text);
        }
        public void SetValor(string valor)
        {
            if (valor == null) return;
            // Tiene dos campos
            int pos1 = valor.IndexOf("|");
            if (pos1 < 0) return;
            string c1 = valor.Substring(0, pos1);
            string c2 = valor.Substring(pos1 + 1, valor.Length - (pos1 + 1));
            txtValor.Text = c1;
            txtComentarios.Text = c2;
        }
        private void LlamarDistribuidor()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!DatosOk()) return;
            // siemprte antes de la llamada salvamos los datos actuales
            tdr.Valor = GetValor();
            //CntSciTerminal.TSave(tdr, conn);
            DistribuidorForm frmDist = new DistribuidorForm(tr, pos,caller, usuario);
            frmDist.Show();
            this.Close();
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
        private bool DatosOk()
        {
            if (txtValor.Text != "")
            {
                try
                {
                    double d = Double.Parse(txtValor.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El valor debe ser numérico", "AVISO");
                    return false;
                }
            }
            return true;
        }

        private void CNumericoForm_KeyDown(object sender, KeyEventArgs e)
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