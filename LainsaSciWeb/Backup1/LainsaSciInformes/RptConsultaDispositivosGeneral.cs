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
    /// Summary description for RptConsultaDispositivosGeneral.
    /// </summary>
    public partial class RptConsultaDispositivosGeneral : Telerik.Reporting.Report
    {
        List<string> filtro = null;
        string consulta = null;
        public RptConsultaDispositivosGeneral()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptConsultaDispositivosGeneral(List<string> filtro, string consulta)
              : this()
          {
                this.filtro = filtro;
                this.consulta = consulta;
          }

        private void RptConsultaDispositivosGeneral_NeedDataSource_1(object sender, EventArgs e)
        {
            if (filtro != null)
            {
                this.DataSource = CntInforme.GetInformeDispositivo(filtro, consulta);
            }
        }
    }
}