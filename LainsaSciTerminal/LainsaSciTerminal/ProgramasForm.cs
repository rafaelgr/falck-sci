using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LainsaSciTerminal
{
    public partial class ProgramasForm : Form
    {
        public ProgramasForm()
        {
            InitializeComponent();
           
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            MenuForm mfrm = new MenuForm();
            mfrm.Show();
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            ProgramasForm progfrm = new ProgramasForm();
            progfrm.Show();
        }

        private void newMenuItemMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            

        }
    }
}