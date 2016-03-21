using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TTipoAnomalia
    {
        private int tipoAnomaliaId;

        public int TipoAnomaliaId
        {
            get { return tipoAnomaliaId; }
            set { tipoAnomaliaId = value; }
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
        public static TTipoAnomalia GetTTipoAnomalia(int id, SqlCeConnection conn)
        {
            TTipoAnomalia ta = null;
            string sql = String.Format("SELECT * FROM TipoAnomalia WHERE tipo_anomalia_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TTipoAnomalia();
                    ta.TipoAnomaliaId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static IList<TTipoAnomalia> GetTTipoAnomalias(SqlCeConnection conn)
        {
            IList<TTipoAnomalia> lttpa = new List<TTipoAnomalia>();
            string sql = "SELECT * FROM TipoAnomalia";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TTipoAnomalia ta = GetTTipoAnomalia(dr.GetInt32(0), conn);
                    lttpa.Add(ta);
                }
            }
            return lttpa;
        }
        public static void TSave(TTipoAnomalia ta, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TTipoAnomalia tta = GetTTipoAnomalia(ta.TipoAnomaliaId, conn);
            if (tta == null)
            {
                sql = @"INSERT INTO TipoAnomalia(tipo_anomalia_id, nombre) VALUES({0},'{1}')";
            }
            else
            {
                sql = @"UPDATE TipoAnomalia SET tipo_anomalia_id={1},nombre='{2}' WHERE tipo_anomalia_id={0}";
            }
            sql = String.Format(sql, ta.TipoAnomaliaId, ta.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }

    }
    
}
