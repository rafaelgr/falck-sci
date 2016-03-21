namespace LainsaSciInformes
{
    using System;
    using LainsaSciModelo;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Test1.
    /// </summary>
    public partial class RptCambiosInstalacion : Telerik.Reporting.Report
    {
        public RptCambiosInstalacion()
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
            DateTime desdeFecha  = Convert.ToDateTime(rpt.Parameters["pDesdeFecha"].Value);
            DateTime hastaFecha = Convert.ToDateTime(rpt.Parameters["pHastaFecha"].Value);
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            Instalacion instalacion = CntLainsaSci.GetInstalacion(instalacionId, ctx);
            TipoDispositivo tipo = CntLainsaSci.GetTipoDispositivo(tipoId, ctx);
            IList<CambioView> l = null;
            if (instalacion!= null)
            {
                if (tipo != null)
                {
                    l = CntInforme.GetCambiosView(
                            desdeFecha,
                            hastaFecha,
                            instalacion,
                            tipo,
                            ctx);
                }
                else
                {
                    l = CntInforme.GetCambiosView(
                             desdeFecha,
                             hastaFecha,
                             instalacion,
                             ctx);
                }
            }
            else
            {
               l = CntInforme.GetCambiosView(
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
            }
        }
    }
}