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
    public partial class Carga : Form
    {
        public Carga()
        {
            InitializeComponent();
        }

        private void Carga_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialogEx ofd = new OpenFileDialogEx();
           ofd.Filter = "*.sdf";
            try
            {
                 if (ofd.ShowDialog() == DialogResult.OK)
                 {
                     MessageBox.Show("Cargado: " + ofd.FileName, "Fichero");

                     CntSciTerminal.SetFileName(ofd.FileName);
                     txtLogin.Text = ofd.FileName;
                   
                  }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("No se pudo leer el fichero del disco. Error original: " + ex.Message, "ERROR");
             }

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = @"\\Storage card\\";
            //openFileDialog1.Filter = "sdf files (*.sdf)|*.sdf";
            //openFileDialog1.FilterIndex = 1;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        CntSciTerminal.SetFileName(openFileDialog1.FileName);
            //        txtLogin.Text = openFileDialog1.FileName;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("No se pudo leer el fichero del disco. Error original: " + ex.Message, "ERROR");
            //    }
            //}
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text != "" && System.IO.File.Exists(txtLogin.Text))
            {
                LoginForm form = new LoginForm();
                form.Show();
            }
            else
                MessageBox.Show("El fichero no existe en el disco", "AVISO");
        }

        private void Carga_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                menuItem1_Click(null, null);
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}