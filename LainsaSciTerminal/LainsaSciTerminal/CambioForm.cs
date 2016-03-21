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
    public partial class CambioForm : Form
    {
        TDispositivo dispositivo = null;
        TDispositivo dspOriginal = null;
        TDispositivo dspSustituto = null;
        TUsuario usuario = null;
        TSustitucion sustitucion = null;
        SqlCeConnection conn;
        public CambioForm(TUsuario usuario)
        {
            this.usuario = usuario;
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
            dispositivo = CntSciTerminal.GetTDispositivo(txtCaptura.Text, conn);
            CntSciTerminal.TClose(this.conn);
            if (dispositivo == null)
            {
                MessageBox.Show("No hay ningún dispositivo con ese código", "AVISO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (dispositivo.Estado != "N")
            {
                MessageBox.Show("El dispositivo que ha introducido existe pero no es correcto.\nSu estado es de ALMACÉN / SUSTITUTO.", "AVISO",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                // ya tenemos el terminal y vamos a mostrarlo.
                dspOriginal = dispositivo;
                string modelo = String.Empty;
                if (dspOriginal.Modelo != null)
                    modelo = dspOriginal.Modelo.Nombre;
                lblInfOriginal.Text = String.Format("{0} ({1}) [{2}]", dspOriginal.Nombre, dspOriginal.Tipo.Nombre, modelo);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            Cursor.Current = Cursors.WaitCursor;
            // miramos si hay algún dispositivo que coincida
            CntSciTerminal.TOpen(this.conn);
            dispositivo = CntSciTerminal.GetTDispositivo(txtSustituto.Text, conn);
            CntSciTerminal.TClose(this.conn);
            if (dispositivo == null)
            {
                MessageBox.Show("No existe ningún dispositivo con ese código", "AVISO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (dispositivo.Estado == "N")
            {
                MessageBox.Show("El dispositivo que ha introducido existe pero no es correcto.\nSu estado NO es de ALMACÉN ni SUSTITUTO.", "AVISO",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                // ya tenemos el terminal y vamos a mostrarlo.
                dspSustituto = dispositivo;
                string modelo = String.Empty;
                if (dspSustituto.Modelo != null)
                    modelo = dspSustituto.Modelo.Nombre;
                lblInfSustituto.Text = String.Format("{0} ({1}) [{2}]", dspSustituto.Nombre, dspSustituto.Tipo.Nombre, modelo);
            }
            Cursor.Current = Cursors.Default;
        }
        
        private void mnuGeneral_Click(object sender, EventArgs e)
        {
            if (dspOriginal != null && dspSustituto != null)
            {
                sustitucion = new TSustitucion();
                CntSciTerminal.TOpen(this.conn);
                DescargarPantalla();
                CntSciTerminal.TClose(this.conn);
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Sustitución guardada", "AVISO");
                MenuForm frmMenu = new MenuForm(usuario);
                frmMenu.Show();
                this.Close();
            }
            else
                MessageBox.Show("Debe seleccionar un dispositivo a sustituir y otro sustituto", "AVISO",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        private void DescargarPantalla()
        {
            sustitucion.TUsuario = usuario;
            sustitucion.Estado = "REALIZADA";
            dspOriginal.Estado = "A";
            dspSustituto.Estado = "N";
            sustitucion.TDispositivoOriginal = dspOriginal;
            sustitucion.TDispositivoSustituto = dspSustituto;
            sustitucion.Comentarios = txtComentario.Text.Replace('\'', ' ');
            sustitucion.Fecha = DateTime.Now;
            CntSciTerminal.TSave(true, sustitucion, conn);
        }
    }
}