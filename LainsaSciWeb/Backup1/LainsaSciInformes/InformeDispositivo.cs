using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class InformeDispositivo
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
        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private string instalacion;

        public string Instalacion
        {
            get { return instalacion; }
            set { instalacion = value; }
        }
        private string tipo_disp;

        public string Tipo_disp
        {
            get { return tipo_disp; }
            set { tipo_disp = value; }
        }
        private string posicion;

        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        private string fecha_cad;

        public string Fecha_cad
        {
            get { return fecha_cad; }
            set { fecha_cad = value; }
        }
        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        private string operativo;

        public string Operativo
        {
            get { return operativo; }
            set { operativo = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        private string consulta;

        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }
    }
}
