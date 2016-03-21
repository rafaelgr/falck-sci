using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Text;

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
        public static TPrioridad GetTPrioridad(int id, SqlCeConnection conn)
        {
            TPrioridad tp = null;
            string sql = String.Format("SELECT * FROM Prioridad WHERE prioridad_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tp = new TPrioridad();
                    tp.PrioridadId = dr.GetInt32(0);
                    tp.Nombre = dr.GetString(1);
                    tp.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return tp;
        }
        public static TPrioridad GetTPrioridad(string nombre, SqlCeConnection conn)
        {
            TPrioridad tp = null;
            string sql = String.Format("SELECT * FROM Prioridad WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tp = new TPrioridad();
                    tp.PrioridadId= dr.GetInt32(0);
                    tp.Nombre = dr.GetString(1);
                    tp.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return tp;
        }

        public static IList<TPrioridad> GetTPrioridads(SqlCeConnection conn)
        {
            IList<TPrioridad> ltp = new List<TPrioridad>();
            string sql = "SELECT * FROM Prioridad";    
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrioridad tp = GetTPrioridad(dr.GetInt32(0), conn);
                    ltp.Add(tp);
                }
            }
            return ltp;
        }
    }
}
