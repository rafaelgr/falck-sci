namespace LainsaSciInformes
{
    using System;
    using System.Collections.Generic;
    using LainsaSciModelo;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptInfConsultaRevision.
    /// </summary>
    public partial class RptInfConsultaRevision : Telerik.Reporting.Report
    {
        public RptInfConsultaRevision()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptInfConsultaRevision(IList<Revision> lcr, string consulta)
            : this()
        {
            this.DataSource = CntInforme.GetConsultaRevisiones(lcr, consulta);
        }
    }
}