using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class InformeRevision
    {
        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string dispositivo;

        public string Dispositivo
        {
            get { return dispositivo; }
            set { dispositivo = value; }
        }
       private string industria;

        public string Industria
        {
            get { return industria; }
            set { industria = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        private string plantilla;

        public string Plantilla
        {
            get { return plantilla; }
            set { plantilla = value; }
        }
        private string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private string instalacion;

        public string Instalacion
        {
            get { return instalacion; }
            set { instalacion = value; }
        }
        private string fecha_plan;

        public string Fecha_plan
        {
            get { return fecha_plan; }
            set { fecha_plan = value; }
        }
        private string fecha_progr;

        public string Fecha_progr
        {
            get { return fecha_progr; }
            set { fecha_progr = value; }
        }
        private string fecha_rev;

        public string Fecha_rev
        {
            get { return fecha_rev; }
            set { fecha_rev = value; }
        }
        private string resultado;

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
