using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class ConsultaRevision
    {
        private int id;

        public int Id
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
        private string numIndustria;

        public string NumIndustria
        {
            get { return numIndustria; }
            set { numIndustria = value; }
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
        private string fechaPlanificada;

        public string FechaPlanificada
        {
            get { return fechaPlanificada; }
            set { fechaPlanificada = value; }
        }
        private string fechaProgramada;

        public string FechaProgramada
        {
            get { return fechaProgramada; }
            set { fechaProgramada = value; }
        }
        private string fechaRevision;

        public string FechaRevision
        {
            get { return fechaRevision; }
            set { fechaRevision = value; }
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
        private string resumen;

        public string Resumen
        {
            get { return resumen; }
            set { resumen = value; }
        }
        private string consulta;

        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }
    }
}
