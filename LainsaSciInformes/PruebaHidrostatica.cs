using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class PruebaHidrostatica
    {
        private string instalacion;

        public string Instalacion
        {
            get { return instalacion; }
            set { instalacion = value; }
        }
        private string fabricante;

        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }
        private string agenteExtintor;

        public string AgenteExtintor
        {
            get { return agenteExtintor; }
            set { agenteExtintor = value; }
        }
        private string numIndustria;

        public string NumIndustria
        {
            get { return numIndustria; }
            set { numIndustria = value; }
        }
        private DateTime fechaFabricacion;

        public DateTime FechaFabricacion
        {
            get { return fechaFabricacion; }
            set { fechaFabricacion = value; }
        }
        private DateTime ultimoRetimbrado;

        public DateTime UltimoRetimbrado
        {
            get { return ultimoRetimbrado; }
            set { ultimoRetimbrado = value; }
        }
        private DateTime proximoRetimbrado;

        public DateTime ProximoRetimbrado
        {
            get { return proximoRetimbrado; }
            set { proximoRetimbrado = value; }
        }
        private int presTimbre;

        public int PresTimbre
        {
            get { return presTimbre; }
            set { presTimbre = value; }
        }
        private int presPrueba;

        public int PresPrueba
        {
            get { return presPrueba; }
            set { presPrueba = value; }
        }
        private string resultado;

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        private string cliente;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        private string numOrden;

        public string NumOrden
        {
            get { return numOrden; }
            set { numOrden = value; }
        }

        private string carga;

        public string Carga
        {
            get { return carga; }
            set { carga = value; }
        }

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        private string actaNumero;

        public string ActaNumero
        {
            get { return actaNumero; }
            set { actaNumero = value; }
        }
        private DateTime fechaActa;

        public DateTime FechaActa
        {
            get { return fechaActa; }
            set { fechaActa = value; }
        }
        private string tecnicoResponsable;

        public string TecnicoResponsable
        {
            get { return tecnicoResponsable; }
            set { tecnicoResponsable = value; }
        }
    }
}
