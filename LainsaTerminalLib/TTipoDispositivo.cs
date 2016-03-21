using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TTipoDispositivo
    {
        private int tipoId;

        public int TipoId
        {
            get { return tipoId; }
            set { tipoId = value; }
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
        public static TTipoDispositivo GetTTipoDispositivo(int id, SqlCeConnection conn)
        {
            TTipoDispositivo tipodispositivo = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("SELECT * FROM TipoDispositivo WHERE tipo_id = {0}", id);
                using (SqlCeDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tipodispositivo = new TTipoDispositivo();
                        tipodispositivo.TipoId = id;
                        tipodispositivo.Nombre = dr.GetString(1);
                        tipodispositivo.Abm = dr.GetByte(2);
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
            }
            return tipodispositivo;
        }
        public static void TSave(TTipoDispositivo tr, SqlCeConnection conn)
        {
            string sql = "";

            sql = @"INSERT INTO TipoDispositivo(tipo_id, nombre) 
                                VALUES({0},'{1}')";

            sql = String.Format(sql, tr.TipoId, tr.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
