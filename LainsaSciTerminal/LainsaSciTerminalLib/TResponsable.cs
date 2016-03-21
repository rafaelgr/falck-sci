using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TResponsable
    {
        private int responsable_id;

        public int ResponsableId
        {
            get { return responsable_id; }
            set { responsable_id = value; }
        }
        private String nombre;

        public String Nombre
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
        public static TResponsable GetTResponsable(int id, SqlCeConnection conn)
        {
            TResponsable tr = null;
            string sql = String.Format("SELECT * FROM Responsable WHERE responsable_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tr = new TResponsable();
                    tr.ResponsableId = dr.GetInt32(0);
                    tr.Nombre = dr.GetString(1);
                    tr.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return tr;
        }
        public static TResponsable GetTResponsable(string nombre, SqlCeConnection conn)
        {
            TResponsable tr = null;
            string sql = String.Format("SELECT * FROM Responsable WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tr = new TResponsable();
                    tr.ResponsableId = dr.GetInt32(0);
                    tr.Nombre = dr.GetString(1);
                    tr.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return tr;
        }

        public static IList<TResponsable> GetTResponsables(SqlCeConnection conn)
        {
            IList<TResponsable> ltr = new List<TResponsable>();
            string sql = "SELECT * FROM Responsable";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TResponsable tr = GetTResponsable(dr.GetInt32(0), conn);
                    ltr.Add(tr);
                }
            }
            return ltr;
        }
    }
}
