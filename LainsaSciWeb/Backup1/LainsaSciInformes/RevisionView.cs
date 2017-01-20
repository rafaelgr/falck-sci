using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class RevisionView
    {
        private int revisionId;

        public int RevisionId
        {
            get { return revisionId; }
            set { revisionId = value; }
        }
        private string anomalia;

        public string Anomalia
        {
            get { return anomalia; }
            set { anomalia = value; }
        }
        private DateTime? fecha;

        public DateTime? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string FechaRev {
            get {
                return "AAAAA";
                /*
                if(fecha == null) {
                    return this.revisionId.ToString();
                   return "";
                } else {
                    return this.revisionId.ToString();
                    return ((DateTime)fecha).ToString("dd/MM/yyyy");
                }
                 * */
            }

        }

        private string resultado;

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        private string comentarios;

        public string Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string barCode;

        public string BarCode
        {
            get {
                barCode = String.Format("FLKR{0:000000000}", revisionId);
                return barCode; }

        }

        private string dispositivo;

        public string Dispositivo
        {
            get { return dispositivo; }
            set { dispositivo = value; }
        }
        private string tipoRevision;

        public string TipoRevision
        {
            get { return tipoRevision; }
            set { tipoRevision = value; }
        }

        private DateTime fechaPlanificada;

        public DateTime FechaPlanificada
        {
            get { return fechaPlanificada; }
            set { fechaPlanificada = value; }
        }
        private DateTime fechaProgramada;

        public DateTime FechaProgramada
        {
            get { return fechaProgramada; }
            set { fechaProgramada = value; }
        }
        private string campo;

        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }
    }
}
