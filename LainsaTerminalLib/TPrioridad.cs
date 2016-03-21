using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TPrioridad
    {
        private int prioridad_id;

        public int PrioridadId
        {
            get { return prioridad_id; }
            set { prioridad_id = value; }
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
        public static IList<TPrioridad> GetTPrioridads(SqlCeConnection conn)
        {
            IList<TPrioridad> l = new List<TPrioridad>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Prioridad");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrioridad tusu = GetTPrioridad(dr.GetInt32(0), conn);
                    if (tusu != null) l.Add(tusu);
                }
            }
            return l;
        }
        public static TPrioridad GetTPrioridad(int id, SqlCeConnection conn)
        {
            TPrioridad Prioridad = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Prioridad WHERE prioridad_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prioridad = new TPrioridad()
                    {
                        PrioridadId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return Prioridad;
        }
        public static TPrioridad GetTPrioridad(string nombre, SqlCeConnection conn)
        {
            TPrioridad Prioridad = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Prioridad WHERE nombre = '{0}'", nombre);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Prioridad = new TPrioridad()
                    {
                        PrioridadId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return Prioridad;
        }
        public static void TSave(TPrioridad tu, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            // TPrioridad tusu = GetTPrioridad(tu.PrioridadId, conn);
            TPrioridad tusu = null;
            if (tusu == null)
            {
                sql = "INSERT INTO Prioridad(prioridad_id, nombre) VALUES({0},'{1}')";
            }
            else
            {
                sql = "UPDATE Prioridad SET nombre='{1}' WHERE prioridad_id={0}";
            }
            sql = String.Format(sql, tu.PrioridadId, tu.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}
