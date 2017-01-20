namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptRevisionDispositivo.
    /// </summary>
    public partial class RptRevisionDispositivo : Telerik.Reporting.Report
    {
        public RptRevisionDispositivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void RptRevisionDispositivo_NeedDataSource_1(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;

            if (rpt.Parameters["dispositivo"].Value != null)
                rpt.DataSource = CntInforme.GetInformeRevisionesDispositivo(rpt.Parameters["dispositivo"].Value.ToString());
        }
    }
}