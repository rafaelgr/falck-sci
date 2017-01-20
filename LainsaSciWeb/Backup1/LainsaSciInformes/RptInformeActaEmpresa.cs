namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using LainsaSciModelo;

    /// <summary>
    /// Summary description for RptInformeActaEmpresa.
    /// </summary>
    public partial class RptInformeActaEmpresa : Telerik.Reporting.Report
    {
       
        public RptInformeActaEmpresa()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptInformeActaEmpresa(Empresa empresa, string observaciones, string actaNumero, DateTime fechaActa, string tecnicoResponsable, LainsaSciModelo.LainsaSci ctx)
            : this()
        {
           this.DataSource = CntInforme.GetPruebasHisdrostaticasEmpresa(empresa, observaciones, actaNumero, fechaActa, tecnicoResponsable, ctx);
        }
    }
}