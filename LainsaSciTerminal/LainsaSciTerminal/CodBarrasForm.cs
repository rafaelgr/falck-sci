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
    public partial class CodBarrasForm : Form
    {
        TDispositivo dispositivo = null;
        private SqlCeConnection conn;
        TUsuario usuario;
        bool task;
        public CodBarrasForm(TUsuario usuario, bool task)
        {
            this.usuario = usuario;
            this.task = task;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            Cursor.Current = Cursors.Default;
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            MenuForm frmMenu = new MenuForm(usuario);
            frmMenu.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            // miramos si hay algún dispositivo que coincida
            CntSciTerminal.TOpen(this.conn);
            if ((dispositivo = CntSciTerminal.GetTDispositivo(txtCaptura.Text, conn)) == null)
            {
                MessageBox.Show("No hay ningún dispositivo con ese código", "AVISO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Cursor.Current = Cursors.Default;
                return;
            }
            else
            {
                //Miramos si el usuario quiere informaciçon del dispositivo o realizar revisiones
                if (task)
                {
                    IList<TRevision> ltr = CntSciTerminal.GetTRevisiones(true, dispositivo, conn);
                    if (ltr.Count > 0)
                    {
                        if (ltr.Count >= 2)
                        {
                            RevisionesGrid Grid = new RevisionesGrid("dispRev", dispositivo, usuario);
                            Grid.Show();
                        }
                        else
                        { 
                            TRevision tr = CntSciTerminal.GetTRevision(ltr[0].RevisionId, conn);
                            DistribuidorForm frmDist = new DistribuidorForm(tr, 0, "dispRev", usuario);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El dispositivo no tiene revisiones pendientes", "AVISO",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    DispForm frmgrdDispositivo = new DispForm(usuario, dispositivo);
                    frmgrdDispositivo.Show();
                    this.Close();
                }
            }
            CntSciTerminal.TClose(this.conn);
            Cursor.Current = Cursors.Default;
        }
        private bool DatosOk()
        {
            if (txtCaptura.Text == "")
            {
                MessageBox.Show("Debe leer o introducir un código", "AVISO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private void CodBarrasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                btnAceptar_Click(null, null);
            }

        }

       }
}