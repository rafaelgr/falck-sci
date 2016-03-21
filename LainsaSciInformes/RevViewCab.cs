using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class RevView
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string plantilla;

        public string Plantilla
        {
            get { return plantilla; }
            set { plantilla = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string normativa;

        public string Normativa
        {
            get { return normativa; }
            set { normativa = value; }
        }
        private string d1;

        public string D1
        {
            get { return d1; }
            set { d1 = value; }
        }
        private string d2;

        public string D2
        {
            get { return d2; }
            set { d2 = value; }
        }
        private string d3;

        public string D3
        {
            get { return d3; }
            set { d3 = value; }
        }
        private string d4;

        public string D4
        {
            get { return d4; }
            set { d4 = value; }
        }
        private string d5;

        public string D5
        {
            get { return d5; }
            set { d5 = value; }
        }
        private string d6;

        public string D6
        {
            get { return d6; }
            set { d6 = value; }
        }
        private string r1;

        public string R1
        {
            get { return r1; }
            set { r1 = value; }
        }
        private string r2;

        public string R2
        {
            get { return r2; }
            set { r2 = value; }
        }
        private string r3;

        public string R3
        {
            get { return r3; }
            set { r3 = value; }
        }
        private string r4;

        public string R4
        {
            get { return r4; }
            set { r4 = value; }
        }
        private string r5;

        public string R5
        {
            get { return r5; }
            set { r5 = value; }
        }
        private string r6;

        public string R6
        {
            get { return r6; }
            set { r6 = value; }
        }
        private string pregunta;

        public string Pregunta
        {
            get { return pregunta; }
            set { pregunta = value; }
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

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private int idCampo;

        public int IdCampo
        {
            get { return idCampo; }
            set { idCampo = value; }
        }

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        private string empresaInstalacion;

        public string EmpresaInstalacion
        {
            get { return empresa + " / " + instalacion; }
        }

        private int grupo;

        public int Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
    }
}
