using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class CambioView
    {
        private int instalacionId;

        public int InstalacionId
        {
            get { return instalacionId; }
            set { instalacionId = value; }
        }
        private int tipoId;

        public int TipoId
        {
            get { return tipoId; }
            set { tipoId = value; }
        }
        private string sustituido;

        public string Sustituido
        {
            get { return sustituido; }
            set { sustituido = value; }
        }
        private string sustituto;

        public string Sustituto
        {
            get { return sustituto; }
            set { sustituto = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
