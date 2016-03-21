namespace LainsaSciInformes
{
    using LainsaSciModelo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptConsultaRevision.
    /// </summary>
    public partial class RptConsultaRevisionGeneral : Telerik.Reporting.Report
    {
        List<string> filtro = null;

        public RptConsultaRevisionGeneral()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptConsultaRevisionGeneral(string filtro) : this()
        {
            string[] split = filtro.Split('_');
         
            this.ReportParameters[0].Value = split;
        }

        public RptConsultaRevisionGeneral(List<string> filtro) : this()
        {
            this.filtro = filtro;
        }

        private void RptConsultaRevisionGeneral_NeedDataSource_1(object sender, EventArgs e)
        {
            if (filtro != null)
            {
                this.DataSource = CntInforme.GetInformeRevision(filtro);
                //this.subReport1.Parameters.Add("dispositivo", filtro);
            }
        }
    }
}