using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
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
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private bool en_cierre;

        public bool EnCierre
        {
            get { return en_cierre; }
            set { en_cierre = value; }
        }
        private bool en_apertura;

        public bool EnApertura
        {
            get { return en_apertura; }
            set { en_apertura = value; }
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
        public static TEstado GetTEstado(int id, SqlCeConnection conn)
        {
            TEstado te = null;
            string sql = String.Format("SELECT * FROM Estado WHERE estado_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    te = new TEstado();
                    te.EstadoId = dr.GetInt32(0);
                    te.Nombre = dr.GetString(1);
                    te.EnCierre = dr.GetBoolean(2);
                    te.EnApertura = dr.GetBoolean(3);
                    te.Abm = dr.GetByte(4);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return te;
        }
        public static TEstado GetTEstadoCierre(SqlCeConnection conn)
        {
            TEstado te = null;
            string sql = "SELECT * FROM Estado WHERE en_cierre = 1";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    te = new TEstado();
                    te.EstadoId = dr.GetInt32(0);
                    te.Nombre = dr.GetString(1);
                    te.EnCierre = dr.GetBoolean(2);
                    te.EnApertura = dr.GetBoolean(3);
                    te.Abm = dr.GetByte(4);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return te;
        }
        public static TEstado GetTEstado(string nombre, SqlCeConnection conn)
        {
            TEstado te = null;
            string sql = String.Format("SELECT * FROM Estado WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    te = new TEstado();
                    te.EstadoId = dr.GetInt32(0);
                    te.Nombre = dr.GetString(1);
                    te.EnCierre = dr.GetBoolean(2);
                    te.EnApertura = dr.GetBoolean(3);
                    te.Abm = dr.GetByte(4);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return te;
        }

        public static IList<TEstado> GetTEstados(SqlCeConnection conn)
        {
            IList<TEstado> lte = new List<TEstado>();
            string sql = "SELECT * FROM Estado";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TEstado te = GetTEstado(dr.GetInt32(0), conn);
                    lte.Add(te);
                }
            }
            return lte;
        }
    }
}
