namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using LainsaSciModelo;
    using LainsaSciInformes;

    /// <summary>
    /// Summary description for RptInformeActa.
    /// </summary>
    public partial class RptInformeActa : Telerik.Reporting.Report
    {
        public RptInformeActa()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptInformeActa(Instalacion instalacion, string observaciones, string actaNumero, DateTime fechaActa, string tecnicoResponsable, LainsaSci ctx)
            : this()
        {
            this.DataSource = CntInforme.GetPruebasHisdrostaticas(instalacion, observaciones, actaNumero, fechaActa, tecnicoResponsable, ctx);
        }
    }
}