using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TModeloDispositivo
    {
        private int modeloDispositivoId;

        public int ModeloDispositivoId
        {
            get { return modeloDispositivoId; }
            set { modeloDispositivoId = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private byte abm;
        public byte Abm
        {
            get { return abm; }
            set { abm = value; }
        }
    }
    public static partial class CntSciTerminal
    {
        public static TModeloDispositivo GetTModeloDispositivo(int id, SqlCeConnection conn)
        {
            TModeloDispositivo ta = null;
            string sql = String.Format("SELECT * FROM ModeloDispositivo WHERE modelo_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TModeloDispositivo();
                    ta.ModeloDispositivoId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static TModeloDispositivo GetTModeloDispositivo(string nombre, SqlCeConnection conn)
        {
            TModeloDispositivo ta = null;
            string sql = String.Format("SELECT * FROM ModeloDispositivo WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TModeloDispositivo();
                    ta.ModeloDispositivoId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }

        public static IList<TModeloDispositivo> GetTModeloDispositivos(SqlCeConnection conn)
        {
            IList<TModeloDispositivo> lttpa = new List<TModeloDispositivo>();
            string sql = "SELECT * FROM ModeloDispositivo";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TModeloDispositivo ta = GetTModeloDispositivo(dr.GetInt32(0), conn);
                    lttpa.Add(ta);
                }
            }
            return lttpa;
        }

    }
}
