using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    public static partial class CntSciTerminal
    {
        public static TInstalacion GetTInstalacion(int id, SqlCeConnection conn)
        {
            TInstalacion instalacion = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("SELECT * FROM Instalacion WHERE instalacion_id = {0}", id);
                using (SqlCeDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        instalacion = new TInstalacion();
                        instalacion.InstalacionId = id;
                        instalacion.Nombre = dr.GetString(1);
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
            }
            return instalacion;
        }
        public static void TSave(TInstalacion tr, SqlCeConnection conn)
        {
            string sql = "";
            
            sql = @"INSERT INTO Instalacion(instalacion_id, nombre) 
                                VALUES({0},'{1}')";
          
            sql = String.Format(sql, tr.InstalacionId, tr.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
