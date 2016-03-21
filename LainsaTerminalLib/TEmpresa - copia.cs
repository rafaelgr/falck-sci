using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    public static partial class CntSciTerminal
    {
        public static TEmpresa GetTEmpresa(int id, SqlCeConnection conn)
        {
            TEmpresa empresa = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("SELECT * FROM Empresa WHERE empresa_id = {0}", id);
                using (SqlCeDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        empresa = new TEmpresa();
                        empresa.EmpresaId = id;
                        empresa.Nombre = dr.GetString(1);
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
            }
            return empresa;
        }
        public static TEmpresa GetTEmpresa(SqlCeConnection conn)
        {
            TEmpresa empresa = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("SELECT * FROM Empresa");
                using (SqlCeDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        empresa = new TEmpresa();
                        empresa.EmpresaId = dr.GetInt32(0);
                        empresa.Nombre = dr.GetString(1);
                        break;
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
            }
            return empresa;
        }
        public static void TSave(TEmpresa tr, SqlCeConnection conn)
        {
            string sql = "";

            sql = @"INSERT INTO Empresa(empresa_id, nombre) 
                                VALUES({0},'{1}')";

            sql = String.Format(sql, tr.EmpresaId, tr.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
