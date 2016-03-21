using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciInformes
{
    public class ResEmpresaInstalacionView
    {
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
        private string t_disp;

        public string T_disp
        {
            get { return t_disp; }
            set { t_disp = value; }
        }

        private int nrt;

        public int Nrt
        {
            get { return nrt; }
            set { nrt = value; }
        }
        private int nra;

        public int Nra
        {
            get { return nra; }
            set { nra = value; }
        }
        private int nba;

        public int Nba
        {
            get { return nba; }
            set { nba = value; }
        }
        private int nca;

        public int Nca
        {
            get { return nca; }
            set { nca = value; }
        }
        private int nrti;

        public int Nrti
        {
            get { return nrti; }
            set { nrti = value; }
        }
        private int nrai;

        public int Nrai
        {
            get { return nrai; }
            set { nrai = value; }
        }
        private int nbai;

        public int Nbai
        {
            get { return nbai; }
            set { nbai = value; }
        }
        private int ncai;

        public int Ncai
        {
            get { return ncai; }
            set { ncai = value; }
        }

        private DateTime desdeFecha;

        public DateTime DesdeFecha
        {
            get { return desdeFecha; }
            set { desdeFecha = value; }
        }
        private DateTime hastaFecha;

        public DateTime HastaFecha
        {
            get { return hastaFecha; }
            set { hastaFecha = value; }
        }
        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        private string documentoId;

        public string DocumentoId
        {
            get { return documentoId; }
            set { documentoId = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        private string normativa;

        public string Normativa
        {
            get { return normativa; }
            set { normativa = value; }
        }

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

        private string barcodeEmpresa;

        public string BarcodeEmpresa
        {
            get {
                barcodeEmpresa = String.Format("FLKI{0:000000}", instalacionId);
                return barcodeEmpresa; 
            }
        }
        private string barcodeInstalacion;

        public string BarcodeInstalacion
        {
            get {
                barcodeInstalacion = String.Format("FLKI{0:000000}", instalacionId);
                return barcodeInstalacion; }
        }
        private string barcodeTipo;

        public string BarcodeTipo
        {
            get
            {
                barcodeTipo = String.Format("FLKI{0:000000}", tipoId);
                return barcodeTipo;
            }
        }
    }
}
