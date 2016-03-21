using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class ResTipoPlantillaView
    {
        private int instalacionId;

        public int InstalacionId
        {
            get { return instalacionId; }
            set { instalacionId = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string plantilla;

        public string Plantilla
        {
            get { return plantilla; }
            set { plantilla = value; }
        }
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
    }
}
