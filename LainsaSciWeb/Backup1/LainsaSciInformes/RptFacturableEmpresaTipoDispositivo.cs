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
    /// Summary description for RptFacturableEmpresaTipoDispositivo.
    /// </summary>
    public partial class RptFacturableEmpresaTipoDispositivo : Telerik.Reporting.Report
    {
        public static Empresa empresa = null;
        public RptFacturableEmpresaTipoDispositivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        
        public RptFacturableEmpresaTipoDispositivo(DateTime desdeFecha, DateTime hastaFecha, int empresaId, int tipoId, LainsaSci ctx)
            : this()
        {
            TipoDispositivo tipo = null;
            if (tipoId != -1)
                tipo = CntLainsaSci.GetTipoDispositivo(tipoId, ctx);
            empresa = CntLainsaSci.GetEmpresa(empresaId, ctx);
            this.DataSource = CntInforme.GetEmpresaTipoView(desdeFecha, hastaFecha, empresa, tipo, true, ctx);
        }
        public static string GetBarCodeEmpresa()
        {
            return String.Format("FLKE{0:000000}", empresa.EmpresaId); 
        }
    }
}