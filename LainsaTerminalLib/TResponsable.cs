using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;

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
        public static IList<TResponsable> GetTResponsables(SqlCeConnection conn)
        {
            IList<TResponsable> l = new List<TResponsable>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Responsable");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TResponsable tusu = GetTResponsable(dr.GetInt32(0), conn);
                    if (tusu != null) l.Add(tusu);
                }
            }
            return l;
        }
        public static TResponsable GetTResponsable(int id, SqlCeConnection conn)
        {
            TResponsable Responsable = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Responsable WHERE responsable_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Responsable = new TResponsable()
                    {
                        ResponsableId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return Responsable;
        }
        public static TResponsable GetTResponsable(string nombre, SqlCeConnection conn)
        {
            TResponsable Responsable = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Responsable WHERE nombre = '{0}'", nombre);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Responsable = new TResponsable()
                    {
                        ResponsableId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return Responsable;
        }
        public static void TSave(TResponsable tu, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            // TResponsable tusu = GetTResponsable(tu.ResponsableId, conn);
            TResponsable tusu = null;
            if (tusu == null)
            {
                sql = "INSERT INTO Responsable(responsable_id, nombre) VALUES({0},'{1}')";
            }
            else
            {
                sql = "UPDATE Responsable SET nombre='{1}' WHERE responsable_id={0}";
            }
            sql = String.Format(sql, tu.ResponsableId, tu.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }

}
