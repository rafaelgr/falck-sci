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
    public partial class ProgramaEditViewDialog : Form
    {
        public ProgramaEditViewDialog()
        {
            InitializeComponent();
        }

        private void ProgramaEditViewDialog_Closing(object sender, CancelEventArgs e)
        {
            this.programaBindingSource.EndEdit();

        }
    }
}