using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TInstalacion
    {
        private int instalacionId;

        public int InstalacionId
        {
            get { return instalacionId; }
            set { instalacionId = value; }
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
        public static TInstalacion GetTInstalacion(int id, SqlCeConnection conn)
        {
            TInstalacion ta = null;
            string sql = String.Format("SELECT * FROM Instalacion WHERE instalacion_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TInstalacion();
                    ta.InstalacionId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static TInstalacion GetTInstalacion(string nombre, SqlCeConnection conn)
        {
            TInstalacion ta = null;
            string sql = String.Format("SELECT * FROM Instalacion WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TInstalacion();
                    ta.InstalacionId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }

        public static IList<TInstalacion> GetTInstalaciones(SqlCeConnection conn)
        {
            IList<TInstalacion> lttpa = new List<TInstalacion>();
            string sql = "SELECT * FROM Instalacion";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TInstalacion ta = GetTInstalacion(dr.GetInt32(0), conn);
                    lttpa.Add(ta);
                }
            }
            return lttpa;
        }
    }
}
