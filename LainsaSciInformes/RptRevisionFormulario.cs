namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using LainsaSciModelo;

    /// <summary>
    /// Summary description for RptRevisionFormulario.
    /// </summary>
    public partial class RptRevisionFormulario : Telerik.Reporting.Report
    {
        Programa programa = null;
        LainsaSci ctx = null;
        public RptRevisionFormulario()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptRevisionFormulario(Programa p, LainsaSci ctx)
            : this()
        {
            programa = p;
            this.ctx = ctx;
        }
        private void RptRevisionFormulario_NeedDataSource(object sender, EventArgs e)
        {
            if (programa != null)
            {
                this.DataSource = CntInforme.GetFormulariosRevision(programa, ctx);
            }
        }
    }
}