namespace LainsaSciInformes
{
    using System;
    using LainsaSciModelo;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptPrograma2.
    /// </summary>
    public partial class RptPrograma2 : Telerik.Reporting.Report
    {
        Programa programa = null;
        public RptPrograma2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptPrograma2(int programaId, LainsaSci ctx)
            : this()
        {
            programa = CntLainsaSci.GetPrograma(programaId, ctx);
            this.DataSource = CntInforme.GetRevViews(programa);
        }
        public static string GetEmpresaInstalacion()
        {
            return "";
        }
    }
}