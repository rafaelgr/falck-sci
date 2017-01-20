namespace LainsaSciInformes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using System.Collections.Generic;
    using LainsaSciModelo;

    /// <summary>
    /// Summary description for RptConsultaDispositivos.
    /// </summary>
    public partial class RptConsultaDispositivos : Telerik.Reporting.Report
    {
        List<string> filtro = null;
        string consulta = null;
        
        public RptConsultaDispositivos()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptConsultaDispositivos(List<string> filtro, string consulta)
              : this()
          {
                this.filtro = filtro;
                this.consulta = consulta;
          }
     
        private void RptConsultaDispositivos_NeedDataSource_1(object sender, EventArgs e)
        {
            if (filtro != null)
            {
                this.DataSource = CntInforme.GetInformeDispositivo(filtro, consulta);
            }
       }
    }
}