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
    /// Summary description for Test1.
    /// </summary>
    public partial class RptTipoPlantilla : Telerik.Reporting.Report
    {
        public RptTipoPlantilla()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void Test1_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report rpt = (Telerik.Reporting.Processing.Report)sender;
            int c = rpt.Parameters.Count;
            int tipoId = Convert.ToInt32(rpt.Parameters["pTipoId"].Value);
            int instalacionId = Convert.ToInt32(rpt.Parameters["pInstalacionId"].Value);
            DateTime desdeFecha = Convert.ToDateTime(rpt.Parameters["pDesdeFecha"].Value);
            DateTime hastaFecha = Convert.ToDateTime(rpt.Parameters["pHastaFecha"].Value);
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            Instalacion instalacion = CntLainsaSci.GetInstalacion(instalacionId, ctx);
            TipoDispositivo tipo = CntLainsaSci.GetTipoDispositivo(tipoId, ctx);
            IList<ResTipoPlantillaView> l = null;
             if(instalacion != null)
            {
                if (tipo != null)
                {
                    l = CntInforme.GetTipoPlantillaViews(
                       desdeFecha,
                       hastaFecha,
                       instalacion,
                       tipo,
                       ctx);
                }
                else
                {
                    l = CntInforme.GetTipoPlantillaViews(
                          desdeFecha,
                          hastaFecha,
                          instalacion,
                          ctx);
                }
            }
            else
            {
                textBox1.Value = "Revisiones por instalación";
                l = CntInforme.GetTipoPlantillaViews(
                   desdeFecha,
                   hastaFecha,
                   tipo,
                   ctx);
            }
           
           
            if (l.Count == 0)
            {
                rpt.Visible = false;
            }
            else
            {
                rpt.DataSource = l;
                MontaGrafico(l);
            }
        }
        private void MontaGrafico(IList<ResTipoPlantillaView> ltpw)
        {
            chart1.Series.Clear();
            var rs = from item in ltpw
                     group item by item.Plantilla
                         into g
                         select new { Plantilla = g.Key, Numero = g.Sum(x=>x.Numero) };
            foreach (var p in rs)
            {
                Telerik.Reporting.Charting.ChartSeries serie = new Telerik.Reporting.Charting.ChartSeries(p.Plantilla);
                serie.Items.Clear();
                serie.Items.Add(new Telerik.Reporting.Charting.ChartSeriesItem(0, (double)p.Numero));
                chart1.Series.Add(serie);
            }


        }
    }
}