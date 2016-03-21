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
    public partial class LoginForm : Form
    {
        private TUsuario usuario;
        private SqlCeConnection conn;
        public LoginForm()
        {
            //usuario = new TUsuario
            //{
            //    UsuarioId = 2,
            //    Nombre = "Administrador",
            //    Login = "admin",
            //    TGrupoTrabajo = LainsaTerminalLib.CntSciTerminal.GetTGrupoTrabajo(1, conn),
            //    Password = LainsaTerminalLib.CntSciTerminal.GetHashCode("admin")
            //};
            //LainsaTerminalLib.CntSciTerminal.TSave(usuario, conn);
            usuario = null;
            this.conn = CntSciTerminal.TSqlConnection();
            InitializeComponent();
            string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "VRS " + strVersion;
            Cursor.Current = Cursors.Default;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            Carga frm = new Carga();
            frm.Show();
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (!DatosOk()) return;
            
            MenuForm mfrm = new MenuForm(usuario);
            mfrm.Show();
        }
        protected bool DatosOk()
        {
            if (txtLogin.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Se necesita un login y contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
                return false;
            }
            // Comprobación del login
            CntSciTerminal.TOpen(this.conn);
            usuario = CntSciTerminal.Login(txtLogin.Text, txtPassword.Text, conn);
            CntSciTerminal.TClose(this.conn);
            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }
        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                menuItem2_Click(null, null);
            }

        }
    }
}