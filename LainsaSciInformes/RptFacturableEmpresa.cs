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
    public partial class RptFacturableEmpresa : Telerik.Reporting.Report
    {
        public static Empresa empresa = null;
        public RptFacturableEmpresa()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        
        public RptFacturableEmpresa(DateTime desdeFecha, DateTime hastaFecha, int empresaId, int instId, int tipoId, LainsaSci ctx)
            : this()
        {
            Instalacion instalacion = null;
            TipoDispositivo tipo = null;
            if (instId != -1)
                instalacion = CntLainsaSci.GetInstalacion(instId, ctx);
            if (tipoId != -1)
                tipo = CntLainsaSci.GetTipoDispositivo(tipoId, ctx);
            empresa = CntLainsaSci.GetEmpresa(empresaId, ctx);
            this.DataSource = CntInforme.GetEmpresaView(desdeFecha, hastaFecha, empresa, instalacion, tipo, true, ctx);
        }
        public static string GetBarCodeEmpresa()
        {
            return String.Format("FLKE{0:000000}", empresa.EmpresaId); 
        }
    }
}