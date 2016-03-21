using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TEstado
    {
        private int estado_id;

        public int EstadoId
        {
            get { return estado_id; }
            set { estado_id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private bool en_apertura;

        public bool EnApertura
        {
            get { return en_apertura; }
            set { en_apertura = value; }
        }
        private bool en_cierre;

        public bool EnCierre
        {
            get { return en_cierre; }
            set { en_cierre = value; }
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
        public static IList<TEstado> GetTEstados(SqlCeConnection conn)
        {
            IList<TEstado> l = new List<TEstado>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Estado");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TEstado tusu = GetTEstado(dr.GetInt32(0), conn);
                    if (tusu != null) l.Add(tusu);
                }
            }
            return l;
        }
        public static TEstado GetTEstado(int id, SqlCeConnection conn)
        {
            TEstado Estado = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Estado WHERE estado_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Estado = new TEstado()
                    {
                        EstadoId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(4)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return Estado;
        }
        public static TEstado GetTEstado(string nombre, SqlCeConnection conn)
        {
            TEstado Estado = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Estado WHERE nombre = '{0}'", nombre);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Estado = new TEstado()
                    {
                        EstadoId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(4)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return Estado;
        }
        public static void TSave(TEstado tu, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            // TEstado tusu = GetTEstado(tu.EstadoId, conn);
            TEstado tusu = null;
            if (tusu == null)
            {
                sql = "INSERT INTO Estado(estado_id, nombre, en_cierre, en_apertura) VALUES({0},'{1}',{2},{3})";
            }
            else
            {
                sql = "UPDATE Estado SET nombre='{1}', en_cierre={2}, en_apertura={3} WHERE Estado_id={0}";
            }
            int b_cierre = 0;
            if (tu.EnCierre) b_cierre = 1;
            int b_apertura = 0;
            if (tu.EnApertura) b_apertura = 1;
            sql = String.Format(sql, tu.EstadoId, tu.Nombre, b_cierre, b_apertura);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}
