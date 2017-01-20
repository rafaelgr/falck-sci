namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptConsultaDispositivo.
    /// </summary>
    public partial class RptConsultaDispositivo : Telerik.Reporting.Report
    {
        public RptConsultaDispositivo()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptConsultaDispositivo(string filtro)
            : this()
        {
            string[] split = filtro.Split('_');
         
            this.ReportParameters[0].Value = split;
         }
        public RptConsultaDispositivo(List<string> filtro)
              : this()
          {
            this.ReportParameters[0].Value = filtro;
          }
    }
}