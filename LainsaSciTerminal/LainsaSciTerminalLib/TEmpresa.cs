using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TEmpresa
    {
        private int empresaId;

        public int EmpresaId
        {
            get { return empresaId; }
            set { empresaId = value; }
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
        public static TEmpresa GetTEmpresa(int id, SqlCeConnection conn)
        {
            TEmpresa ta = null;
            string sql = String.Format("SELECT * FROM Empresa WHERE empresa_id={0}", id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TEmpresa();
                    ta.EmpresaId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static TEmpresa GetTEmpresa(SqlCeConnection conn)
        {
            TEmpresa ta = null;
            string sql = "SELECT * FROM Empresa";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TEmpresa();
                    ta.EmpresaId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                    break;
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
        public static TEmpresa GetTEmpresa(string nombre, SqlCeConnection conn)
        {
            TEmpresa ta = null;
            string sql = String.Format("SELECT * FROM Empresa WHERE nombre='{0}'", nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ta = new TEmpresa();
                    ta.EmpresaId = dr.GetInt32(0);
                    ta.Nombre = dr.GetString(1);
                    ta.Abm = dr.GetByte(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return ta;
        }
    }
}
