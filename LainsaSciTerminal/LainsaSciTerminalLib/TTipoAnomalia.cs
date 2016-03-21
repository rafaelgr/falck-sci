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
        private byte abm;
        public byte Abm
        {
            get { return abm; }
            set { abm = value; }
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
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static TTipoAnomalia GetTTipoAnomalia(string nombre, SqlCeConnection conn)
        {
            TTipoAnomalia ta = null;
            string sql = String.Format("SELECT * FROM TipoAnomalia WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TTipoAnomalia();
                    ta.TipoAnomaliaId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
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
        public static IList<TTipoAnomalia> GetTTipoAnomalias(TDispositivo dispositivo, SqlCeConnection conn)
        {
            IList<TTipoAnomalia> lttpa = new List<TTipoAnomalia>();
            string sql = String.Format("SELECT * FROM TipoAnomalia t INNER JOIN Revision r on t.tipo_anomalia_id = r.tipo_anomalia_id where r.dispositivo_id = {0}", dispositivo.DispositivoId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TTipoAnomalia ta = new TTipoAnomalia()
                    {
                        TipoAnomaliaId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                    lttpa.Add(ta);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return lttpa;
        }
        public static void TSave(TTipoAnomalia ta, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TTipoAnomalia tta = GetTTipoAnomalia(ta.TipoAnomaliaId, conn);
            byte abm = tta.Abm;
            if (abm != 1) abm = 3;
            if (tta == null)
            {
                sql = @"INSERT INTO TipoAnomalia(tipo_anomalia_id, nombre, abm) VALUES({0},'{1}',1)";
            }
            else
            {
                sql = @"UPDATE TipoAnomalia SET nombre='{1}', abm={2} WHERE tipo_anomalia_id={0}";
            }
            sql = String.Format(sql, ta.TipoAnomaliaId, ta.Nombre, abm);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }

    }
    
}
