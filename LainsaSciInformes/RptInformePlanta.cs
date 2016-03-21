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
    /// Summary description for RptInformePlanta.
    /// </summary>
    public partial class RptInformePlanta : Telerik.Reporting.Report
    {
        Programa programa = null;
        LainsaSci ctx = null;
        public RptInformePlanta()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptInformePlanta(Programa p, LainsaSci ctx)
            : this()
        {
            programa = p;
            this.ctx = ctx;
        }

        private void RptInformePlanta_NeedDataSource(object sender, EventArgs e)
        {
            if (programa != null)
            {
                this.DataSource = CntInforme.GetInformePlanta(programa);
            }
        }
    }
}