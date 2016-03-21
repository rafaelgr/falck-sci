using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TDispositivo
    {
        private int dispositivoId;

        public int DispositivoId
        {
            get { return dispositivoId; }
            set { dispositivoId = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private string instalacion;

        public string Instalacion
        {
            get { return instalacion; }
            set { instalacion = value; }
        }
    }
    public static partial class CntSciTerminal
    {
        public static TDispositivo GetTDispositivo(int id, SqlCeConnection conn)
        {
            TDispositivo dispositivo = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Dispositivo WHERE dispositivo_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dispositivo = new TDispositivo()
                    {
                        DispositivoId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Empresa = dr.GetString(2),
                        Instalacion = dr.GetString(3)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return dispositivo;
        }
        public static void TSave(TDispositivo td, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TDispositivo tdsp = GetTDispositivo(td.DispositivoId, conn);
            if (tdsp == null)
            {
                sql = "INSERT INTO Dispositivo(dispositivo_id, nombre, empresa, instalacion) VALUES({0},'{1}','{2}','{3}')";
            }
            else
            {
                sql = "UPDATE Dispositivo SET nombre='{1}',empresa='{2}',instalacion='{3}' WHERE dispositivo_id={0}";
            }
            sql = String.Format(sql, td.DispositivoId,td.Nombre,td.Empresa,td.Instalacion);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }

    }
}
