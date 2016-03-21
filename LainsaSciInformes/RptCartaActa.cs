namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptCartaActa.
    /// </summary>
    public partial class RptCartaActa : Telerik.Reporting.Report
    {
        public RptCartaActa()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptCartaActa(string valor)
            : this()
        {
            txtContenido.Value = valor;
        }
    }
}