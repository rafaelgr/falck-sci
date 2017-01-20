namespace LainsaSciInformes
{
    using System;
    using LainsaSciModelo;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Test1.
    /// </summary>
    public partial class Test1 : Telerik.Reporting.Report
    {
        public Test1()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //LoadDataSource();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        private void LoadDataSource()
        {
            int pInstalacionId = (int)this.ReportParameters["pInstalacionId"].Value;
            DateTime dFecha = (DateTime)this.ReportParameters["pDesdeFecha"].Value;
            DateTime hFecha = (DateTime)this.ReportParameters["pHastaFecha"].Value;
            LainsaSci ctx = new LainsaSci();
            this.DataSource = CntInforme.GetTipoPlantillaViews(
                dFecha,
                hFecha,
                CntLainsaSci.GetInstalacion(pInstalacionId, ctx),
                ctx);
        }

        private void Test1_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;
            int c = rpt.Parameters.Count;
            int instalacionId = Convert.ToInt32(rpt.Parameters["pInstalacionId"].Value);
            DateTime desdeFecha  = Convert.ToDateTime(rpt.Parameters["pDesdeFecha"].Value);
            DateTime hastaFecha = Convert.ToDateTime(rpt.Parameters["pHastaFecha"].Value);
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            rpt.DataSource = CntInforme.GetTipoPlantillaViews(
                desdeFecha,
                hastaFecha,
                CntLainsaSci.GetInstalacion(instalacionId, ctx),
                ctx);
        }
    }
}