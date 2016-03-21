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
    public partial class DistribuidorForm : Form
    {
        TRevision tr = null;
        int pos = 0;
        string caller = "";
        TPrograma prg = null;
        TDispositivo dsp = null;
        TUsuario usuario;
        
        public DistribuidorForm(TRevision tr, int pos, string caller, TUsuario usuario)
        {
            this.usuario = usuario;
            this.tr = tr;
            this.pos = pos;
            this.caller = caller;
           
            InitializeComponent();
            QueFormularioAbroRevision();
        }
        public DistribuidorForm(string pantalla)
        {
            switch (pantalla)
            {
                case "Programaciones":
                    ProgramacionesGrid prgGrid = new ProgramacionesGrid(usuario);
                    prgGrid.Show();
                    this.Close();
                    break;
            }
        }
        private bool ControlDePosicion()
        {
            bool res = true;
            if (pos < 0 || pos > tr.DatosRevision.Count)
            {
                MessageBox.Show("Datos de posición incorrectos", "AVISO");
                res = false;
            }
            return res;
        }
        private void QueFormularioAbroRevision()
        {
            
            switch (tr.DatosRevision[pos].Tipo)
            {
                case "Campo OK/MAL":
                    CSNForm frmCSN = new CSNForm(tr, pos, caller, usuario);
                    frmCSN.Show();
                    break;
                case "Texto":
                    CTextoForm frmCTexto = new CTextoForm(tr, pos, caller, usuario);
                    frmCTexto.Show();
                    break;
                case "Tetra":
                    CTetraForm frmCTetra = new CTetraForm(tr, pos, caller, usuario);
                    frmCTetra.Show();
                    break;
                case "Numerico":
                    CNumericoForm frmCNumerico = new CNumericoForm(tr, pos, caller, usuario);
                    frmCNumerico.Show();
                    break;
                case "Fecha":
                    CFechaForm frmCFecha = new CFechaForm(tr, pos, caller, usuario);
                    frmCFecha.Show();
                    break;
            }
            this.Close();
        }


    }
}