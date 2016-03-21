using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciModelo
{
    public class SalvaProgramacion
    {
        private Programa programa;

        public Programa Programa
        {
            get { return programa; }
            set { programa = value; }
        }
        private DateTime fechaProgramada;

        public DateTime FechaProgramada
        {
            get { return fechaProgramada; }
            set { fechaProgramada = value; }
        }
        private DateTime fechaPlanificada;

        public DateTime FechaPlanificada
        {
            get { return fechaPlanificada; }
            set { fechaPlanificada = value; }
        }
        private Dispositivo dispositivo;

        public Dispositivo Dispositivo
        {
            get { return dispositivo; }
            set { dispositivo = value; }
        }
    }
}
