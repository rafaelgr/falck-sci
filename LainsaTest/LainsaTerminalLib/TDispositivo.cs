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
            get
            {
                return dispositivoId;
            }
            set
            {
                dispositivoId = value;
            }
        }
        private string nombre;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        private string empresa;

        public string Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
            }
        }
        private string instalacion;

        public string Instalacion
        {
            get
            {
                return instalacion;
            }
            set
            {
                instalacion = value;
            }
        }

        private string tipo;

        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        private string funcion;

        public string Funcion
        {
            get
            {
                return funcion;
            }
            set
            {
                funcion = value;
            }
        }
        private string estado;

        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        private DateTime fechaCaducidad;

        public DateTime FechaCaducidad
        {
            get
            {
                return fechaCaducidad;
            }
            set
            {
                fechaCaducidad = value;
            }
        }
        private bool caducado;

        public bool Caducado
        {
            get
            {
                return caducado;
            }
            set
            {
                caducado = value;
            }
        }
        private DateTime fechaBaja;

        public DateTime FechaBaja
        {
            get
            {
                return fechaBaja;
            }
            set
            {
                fechaBaja = value;
            }
        }

        private string codBarras;

        public string CodBarras
        {
            get { return codBarras; }
            set { codBarras = value; }
        }
    }

    public static partial class CntSciTerminal
    {
        public static void SetTDispositivo(TDispositivo dispositivo, SqlCeDataReader dr)
        {
            dispositivo.DispositivoId = dr.GetInt32(0);
            dispositivo.Nombre = dr.GetString(1);
            dispositivo.Empresa = dr.GetString(2);
            dispositivo.Instalacion = dr.GetString(3);
            dispositivo.Tipo = dr.GetString(4);
            dispositivo.Funcion = dr.GetString(5);
            dispositivo.Estado = dr.GetString(6);
            dispositivo.CodBarras = dr.GetString(7);
            dispositivo.FechaCaducidad = dr.GetDateTime(8);
            dispositivo.Caducado = dr.GetBoolean(9);
            if (!CntSciTerminal.FechaNula(dispositivo.FechaBaja))
                dispositivo.FechaBaja = dr.GetDateTime(10);
        }
        public static TDispositivo GetTDispositivo(int id, SqlCeConnection conn)
        {
            TDispositivo dispositivo = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Dispositivo WHERE dispositivo_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dispositivo = new TDispositivo();
                    SetTDispositivo(dispositivo, dr);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return dispositivo;
        }
        public static TDispositivo GetTDispositivo(string codBarras, SqlCeConnection conn)
        {
            TDispositivo dispositivo = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Dispositivo WHERE codbarras= '{0}'", codBarras);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dispositivo = new TDispositivo();
                    SetTDispositivo(dispositivo, dr);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return dispositivo;
        }
        public static void TSave(TDispositivo td, SqlCeConnection conn)
        {
            string sql = "";
            string fecha_caducidad = "NULL";
            string fecha_baja = "NULL";
            int caducado = 0;
            if (!CntSciTerminal.FechaNula(td.FechaCaducidad)) 
                fecha_caducidad = String.Format("'{0:MM/dd/yyyy}'", td.FechaCaducidad);
            if (!CntSciTerminal.FechaNula(td.FechaBaja))
                fecha_baja = String.Format("'{0:MM/dd/yyyy}'", td.FechaBaja);
            if (td.Caducado) caducado = 1;
            // primero verificamos que si el elemento está
            TDispositivo tdsp = GetTDispositivo(td.DispositivoId, conn);
            if (tdsp == null)
            {
                sql = @"INSERT INTO Dispositivo(dispositivo_id, nombre, 
                            empresa, instalacion, 
                            tipo, funcion, estado,
                            fecha_caducidad, caducado, fecha_baja, codbarras) VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},'{10}')";
            }
            else
            {
                sql = @"UPDATE Dispositivo SET nombre='{1}',empresa='{2}',instalacion='{3}',
                        tipo='{4}, funcion='{5}', estado='{6}'
                        fecha_caducidad='{7}, caducado='{8}', fecha_baja='{9}', codbarras='{10}'
                        WHERE dispositivo_id={0}";
            }
            sql = String.Format(sql, td.DispositivoId, td.Nombre, td.Empresa, td.Instalacion, td.Tipo, td.Funcion, td.Estado,fecha_caducidad,caducado,fecha_baja,td.CodBarras);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}