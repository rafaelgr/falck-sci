using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public static partial class CntInforme
    {
        public static IList<NombreInforme> GetNombresDeInforme()
        {
            NombreInforme ninf = null;
            IList<NombreInforme> lni = new List<NombreInforme>();
            ninf = new NombreInforme() { Informe = "RptResumenEmpresaInstalacion", Nombre="Resumen revisiones / anomalías" };
            lni.Add(ninf);
            ninf = new NombreInforme() { Informe = "RptFacturableEmpresaInstalacion", Nombre = "Revisiones facturables" };
            lni.Add(ninf);
            return lni;
        }
    }
}