using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciModelo
{
    /// <summary>
    /// Esta clase es de utilidad para retornar los valores
    /// que se calculan para las fechas de timbrado a partir de una revisión
    /// </summary>
    public class Timbre
    {
        DateTime fechaUltima;
        DateTime fechaSiguiente;
        int pTimbre;
        int pPrueba;

        public int PTimbre
        {
            get
            {
                return this.pTimbre;
            }
            set
            {
                this.pTimbre = value;
            }
        }

        public int PPrueba
        {
            get
            {
                return this.pPrueba;
            }
            set
            {
                this.pPrueba = value;
            }
        }

        public DateTime FechaUltima
        {
            get
            {
                return this.fechaUltima;
            }
            set
            {
                this.fechaUltima = value;
            }
        }

        public DateTime FechaSiguiente
        {
            get
            {
                return this.fechaSiguiente;
            }
            set
            {
                this.fechaSiguiente = value;
            }
        }
    }
    public static partial class CntLainsaSci
    {
        public static Timbre GetTimbre(Dispositivo dsp, LainsaSci ctx)
        {
            Timbre tim = new Timbre();
            // el primer paso es mirar en el dispositivo la última quinquenal realizada.
            //Dispositivo dsp = rev.Dispositivo;
            var rs = from r in dsp.Revisiones
                     orderby r.FechaRevision descending
                     where r.PlantillaRevision.TipoPeriodo == "A" && r.PlantillaRevision.NumeroPeriodos == 5
                     && r.Estado == "REALIZADA"
                     select r;
            if (rs.Count() > 0)
            {
                // la fecha del último timbrado será la de esa revisión
                tim.FechaUltima = rs.FirstOrDefault<Revision>().FechaRevision;
                tim.PPrueba = 0;
                tim.PTimbre = 0;
            }
            else
            {
                // si no se utiliza la fecha de fabricación.
                tim.FechaUltima = dsp.FechaFabricacion;
                Revision rev = rs.FirstOrDefault<Revision>();
                if (rev != null)
                {
                    DatosRevision dar = (from dr in rev.DatosRevisions
                                         where dr.Campo.InformaDe == "PPrueba"
                                         select dr).FirstOrDefault<DatosRevision>();
                    if (dar != null) tim.PPrueba = int.Parse(GetValorCampo(dar.Valor)); else tim.PPrueba = 0;
                    dar = (from dr in rs.FirstOrDefault<Revision>().DatosRevisions
                           where dr.Campo.InformaDe == "PTimbre"
                           select dr).FirstOrDefault<DatosRevision>();
                    if (dar != null) tim.PTimbre = int.Parse(GetValorCampo(dar.Valor)); else tim.PTimbre = 0;
                }
            }
            // la siguiente será 5 años después
            tim.FechaSiguiente = tim.FechaUltima.AddYears(5);
            return tim;
        }
    }
}
