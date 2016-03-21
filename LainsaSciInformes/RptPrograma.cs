namespace LainsaSciInformes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using LainsaSciModelo;

    /// <summary>
    /// Summary description for RptPrograma.
    /// </summary>
    public partial class RptPrograma : Telerik.Reporting.Report
    {
        Programa programa = null;
        public RptPrograma()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptPrograma(int programaId, LainsaSci ctx)
            : this()
        {
            programa = CntLainsaSci.GetPrograma(programaId, ctx);
            this.DataSource = programa.Revisions;
        }
    }
}