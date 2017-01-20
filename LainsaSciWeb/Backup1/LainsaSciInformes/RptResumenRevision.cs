namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using LainsaSciModelo;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptResumenRevision.
    /// </summary>
    public partial class RptResumenRevision : Telerik.Reporting.Report
    {
        LainsaSci ctx = null;
        public RptResumenRevision()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptResumenRevision(LainsaSci ctx)
              : this()
          {
           this.ctx = ctx;
          }
  
        private void RptResumenRevision_NeedDataSource_1(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;
            
            if (rpt.Parameters["dispositivo"].Value != null)
                rpt.DataSource = CntInforme.GetInformeResumenRevision(rpt.Parameters["dispositivo"].Value.ToString());
        }
    }
}