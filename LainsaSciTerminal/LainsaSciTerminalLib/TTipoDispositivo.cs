using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TTipoDispositivo
    {
        private int tipoDispositivoId;

        public int TipoDispositivoId
        {
            get { return tipoDispositivoId; }
            set { tipoDispositivoId = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
    public static partial class CntSciTerminal
    {
        public static TTipoDispositivo GetTTipoDispositivo(int id, SqlCeConnection conn)
        {
            TTipoDispositivo ta = null;
            string sql = String.Format("SELECT * FROM TipoDispositivo WHERE tipo_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TTipoDispositivo();
                    ta.TipoDispositivoId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static TTipoDispositivo GetTTipoDispositivo(string nombre, SqlCeConnection conn)
        {
            TTipoDispositivo ta = null;
            string sql = String.Format("SELECT * FROM TipoDispositivo WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TTipoDispositivo();
                    ta.TipoDispositivoId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }

        public static IList<TTipoDispositivo> GetTTipoDispositivos(SqlCeConnection conn)
        {
            IList<TTipoDispositivo> lttpa = new List<TTipoDispositivo>();
            string sql = "SELECT * FROM TipoDispositivo";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TTipoDispositivo ta = GetTTipoDispositivo(dr.GetInt32(0), conn);
                    lttpa.Add(ta);
                }
            }
            return lttpa;
        }
    }
}
