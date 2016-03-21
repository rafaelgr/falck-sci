using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TModeloDispositivo
    {
        private int modeloId;

        public int ModeloId
        {
            get { return modeloId; }
            set { modeloId = value; }
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
        public static TModeloDispositivo GetTModeloDispositivo(int id, SqlCeConnection conn)
        {
            TModeloDispositivo mdispositivo = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("SELECT * FROM ModeloDispositivo WHERE modelo_id = {0}", id);
                using (SqlCeDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        mdispositivo = new TModeloDispositivo();
                        mdispositivo.ModeloId = id;
                        mdispositivo.Nombre = dr.GetString(1);
                        mdispositivo.Abm = dr.GetByte(2);
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
            }
            return mdispositivo;
        }
        public static void TSave(TModeloDispositivo tr, SqlCeConnection conn)
        {
            string sql = "";

            sql = @"INSERT INTO ModeloDispositivo(modelo_id, nombre) 
                                VALUES({0},'{1}')";

            sql = String.Format(sql, tr.ModeloId, tr.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
