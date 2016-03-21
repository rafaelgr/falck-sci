using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class InformeResumenRevision
    {
        private string dispositivo;

        public string Dispositivo
        {
            get { return dispositivo; }
            set { dispositivo = value; }
        }
        private string plantilla;

        public string Plantilla
        {
            get { return plantilla; }
            set { plantilla = value; }
        }
        private string fecha_ultima;

        public string Fecha_ultima
        {
            get { return fecha_ultima; }
            set { fecha_ultima = value; }
        }
        private string fecha_siguiente;

        public string Fecha_siguiente
        {
            get { return fecha_siguiente; }
            set { fecha_siguiente = value; }
        }
    }
}
