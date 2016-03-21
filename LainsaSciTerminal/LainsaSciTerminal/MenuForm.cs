using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LainsaTerminalLib;

namespace LainsaSciTerminal
{
    public partial class MenuForm : Form
    {
        private TUsuario usuario;
        public MenuForm(TUsuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            lblMensaje.Text = Mensaje(); 

            Cursor.Current = Cursors.Default;
        }
        private string Mensaje()
        {
            return String.Format("Bienvenido {0}. Para utilizar las diferentes opciones de la aplicación haga clic en el \"Menú\" abajo a la derecha. Le recordamos que usted es responsable del uso adecuado de este dispositivo y su correcta conservación. Gracias.", usuario.Nombre);
        }
        private void mnuProgramaciones_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ProgramacionesGrid prgGrid = new ProgramacionesGrid(usuario);
            prgGrid.Show();
            this.Close();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            LoginForm frmLogin = new LoginForm();
            frmLogin.Show();
            this.Close();
        }

        private void mnuConsulta_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CodBarrasForm frmCodBarras = new CodBarrasForm(usuario, false);
            frmCodBarras.Show();
            this.Close();
        }

        private void mnuCambio_Click(object sender, EventArgs e)
        {
            CambioForm cambForm = new CambioForm(usuario);
            cambForm.Show();
            this.Close();
        }

        private void mnuGeneral_Click(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SustitucionesGrid sustGrid = new SustitucionesGrid(usuario);
            sustGrid.Show();
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IncidenciasGrid incGrid = new IncidenciasGrid(usuario);
            incGrid.Show();
            this.Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DispositivoNew dispNew = new DispositivoNew(usuario);
            dispNew.Show();
            this.Close();
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CodBarrasForm frmCodBarras = new CodBarrasForm(usuario, true);
            frmCodBarras.Show();
            this.Close();
        }
    }
}