namespace LainsaSciInformes
{
    using System;
    using LainsaSciModelo;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptTipoPlantillaChart.
    /// </summary>
    public partial class RptTipoPlantillaChart : Telerik.Reporting.Report
    {
        public RptTipoPlantillaChart()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void RptTipoPlantillaChart_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;
            int c = rpt.Parameters.Count;
            int instalacionId = Convert.ToInt32(rpt.Parameters["pInstalacionId"].Value);
            DateTime desdeFecha = Convert.ToDateTime(rpt.Parameters["pDesdeFecha"].Value);
            DateTime hastaFecha = Convert.ToDateTime(rpt.Parameters["pHastaFecha"].Value);
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            IList<ResTipoPlantillaView> l = CntInforme.GetTipoPlantillaViews(
                    desdeFecha,
                    hastaFecha,
                    CntLainsaSci.GetInstalacion(instalacionId, ctx),
                    ctx);
            if (l.Count == 0)
            {
                rpt.Visible = false;
            }
            else
            {
                MontaCarta(l);
            }
        }
        private void MontaCarta(IList<ResTipoPlantillaView> ltpw)
        {
            chart1.Series.Clear();
            var rs = from item in ltpw
                    group item by item.Plantilla
                        into g
                        select new { Plantilla = g.Key, Numero = g.Count() };
            foreach (var p in rs)
            {
                Telerik.Reporting.Charting.ChartSeries serie = new Telerik.Reporting.Charting.ChartSeries(p.Plantilla);
                serie.Items.Clear();
                serie.Items.Add(new Telerik.Reporting.Charting.ChartSeriesItem(0,(double)p.Numero));
            }
            
                      
        }


    }
}