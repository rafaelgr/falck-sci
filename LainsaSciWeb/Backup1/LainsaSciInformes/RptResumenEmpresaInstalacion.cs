namespace LainsaSciInformes
{
    using System;
    using LainsaSciModelo;
    using LainsaSciInformes;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptPrograma2.
    /// </summary>
    public partial class RptResumenEmpresaInstalacion : Telerik.Reporting.Report
    {

        public static Empresa empresa = null;
        
        public RptResumenEmpresaInstalacion()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
   
        public RptResumenEmpresaInstalacion(DateTime desdeFecha, DateTime hastaFecha, int empresaId, int instalacionId,LainsaSci ctx)
            : this()
        {
            Instalacion instalacion = null;
            instalacion = CntLainsaSci.GetInstalacion(instalacionId, ctx);
            empresa = CntLainsaSci.GetEmpresa(empresaId, ctx);
            this.DataSource = CntInforme.GetEmpresaInstalacionView(desdeFecha, hastaFecha, empresa, instalacion, false, ctx);
        }
        public static string GetEmpresaInstalacion()
        {
            return "";
        }
        public static string GetBarCodeEmpresa()
        {
            return String.Format("FLKE{0:000000}", empresa.EmpresaId); 
        }

        #region Subreport
        private void subReport1_ItemDataBinding(object sender, EventArgs e)
        {

            Telerik.Reporting.Processing.SubReport subRpt = (Telerik.Reporting.Processing.SubReport)sender;
            //var p1 = subRpt.Report.Parameters["pInstalacionId"].Value;
        }    
        private void subReport1_Disposed(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subRpt = (Telerik.Reporting.Processing.SubReport)sender;
            //var p1 = subRpt.Report.Parameters["pInstalacionId"].Value;
        }

        private void subReport1_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subRpt = (Telerik.Reporting.Processing.SubReport)sender;
            //var p1 = subRpt.Report.Parameters["pInstalacionId"].Value;
        }

        private void subReport1_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subRpt = (Telerik.Reporting.Processing.SubReport)sender;
            //var p1 = subRpt.Report.Parameters["pInstalacionId"].Value;

        }
        #endregion

    }
}