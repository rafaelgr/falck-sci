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
    /// Summary description for RptResumenEmpresaTipoDispositivo.
    /// </summary>
    public partial class RptResumenEmpresaTipoDispositivo : Telerik.Reporting.Report
    {
        public static Empresa empresa = null;
        public RptResumenEmpresaTipoDispositivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptResumenEmpresaTipoDispositivo(DateTime desdeFecha, DateTime hastaFecha, int empresaId, int tipoId, LainsaSci ctx)
            : this()
        {
           TipoDispositivo tipo = null;
           tipo = CntLainsaSci.GetTipoDispositivo(tipoId, ctx);
           empresa = CntLainsaSci.GetEmpresa(empresaId, ctx);
            this.DataSource = CntInforme.GetEmpresaTipoView(desdeFecha, hastaFecha, empresa, tipo, false, ctx);
        }
        public static string GetEmpresaInstalacion()
        {
            return "";
        }
        public static string GetBarCodeEmpresa()
        {
            return String.Format("FLKE{0:000000}", empresa.EmpresaId); 
        }

        private void subReport1_NeedDataSource(object sender, EventArgs e)
        {

        }

        private void subReport1_ItemDataBinding(object sender, EventArgs e)
        {

        }

        private void subReport1_ItemDataBound(object sender, EventArgs e)
        {

        }

        private void subReport1_Disposed(object sender, EventArgs e)
        {

        }
    }
}