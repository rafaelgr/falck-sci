using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TIncidencia
    {
        private int incidenciaId;

        public int IncidenciaId
        {
            get
            {
                return incidenciaId;
            }
            set
            {
                incidenciaId = value;
            }
        }

        private DateTime fecha_apertura;

        public DateTime FechaApertura
        {
            get
            {
                return fecha_apertura;
            }
            set
            {
                fecha_apertura = value;
            }
        }

        private bool operativo;

        public bool Operativo
        {
            get
            {
                return operativo;
            }
            set
            {
                operativo = value;
            }
        }

        private TDispositivo tdispositivo;

        public TDispositivo TDispositivo
        {
            get
            {
                return tdispositivo;
            }
            set
            {
                tdispositivo = value;
            }
        }

        private TUsuario tusuario;

        public TUsuario TUsuario
        {
            get
            {
                return tusuario;
            }
            set
            {
                tusuario = value;
            }
        }

        private string comentarios;

        public string Comentarios
        {
            get
            {
                return this.comentarios;
            }
            set
            {
                this.comentarios = value;
            }
        }

        private DateTime fecha_cierre;

        public DateTime FechaCierre
        {
            get
            {
                return fecha_cierre;
            }
            set
            {
                fecha_cierre = value;
            }
        }

        private DateTime fecha_prevista;

        public DateTime FechaPrevista
        {
            get
            {
                return fecha_prevista;
            }
            set
            {
                fecha_prevista = value;
            }
        }

        private TEstado tEstado;

        public TEstado TEstado
        {
            get
            {
                return tEstado;
            }
            set
            {
                tEstado = value;
            }
        }

        private TPrioridad tPrioridad;

        public TPrioridad TPrioridad
        {
            get
            {
                return tPrioridad;
            }
            set
            {
                tPrioridad = value;
            }
        }

        private TResponsable tResponsable;

        public TResponsable TResponsable
        {
            get
            {
                return tResponsable;
            }
            set
            {
                tResponsable = value;
            }
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
        public static TIncidencia GetTIncidencia(int id, SqlCeConnection conn)
        {
            TIncidencia incidencia = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Incidencia WHERE incidencia_id = {0}",
                    id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    incidencia = new TIncidencia();
                    incidencia.IncidenciaId = dr.GetInt32(0);
                    incidencia.TDispositivo = GetTDispositivo(dr.GetInt32(1), conn);
                    incidencia.TUsuario = GetTUsuario(dr.GetInt32(2), conn);
                    incidencia.Comentarios = dr.GetString(3);
                    incidencia.Operativo = dr.GetBoolean(4);
                    // control de nulos en fechas.
                    if (dr[5] != DBNull.Value)
                        incidencia.FechaApertura = dr.GetDateTime(5);
                    if (dr[6] != DBNull.Value)
                        incidencia.FechaCierre = dr.GetDateTime(6);
                    // nuevos atributos
                    if (dr[7] != DBNull.Value)
                        incidencia.TEstado = GetTEstado(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        incidencia.TPrioridad = GetTPrioridad(dr.GetInt32(8), conn);
                    if (dr[9] != DBNull.Value)
                        incidencia.TResponsable = GetTResponsable(dr.GetInt32(9), conn);
                    incidencia.Abm = dr.GetByte(10);
                    if (dr[11] != DBNull.Value)
                        incidencia.FechaPrevista = dr.GetDateTime(11);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            // No profundizamos para evitar bucles.
            return incidencia;
        }
      
        public static IList<TIncidencia> GetTIncidencias(TDispositivo dispositivo, SqlCeConnection conn)
        {
            List<TIncidencia> incidencias = new List<TIncidencia>();
            if (dispositivo == null)
                return incidencias;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Incidencia WHERE disp_id = {0}",
                    dispositivo.DispositivoId);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidencia incidencia = GetTIncidencia(dr.GetInt32(0), conn);
                    if (incidencia != null)
                        incidencias.Add(incidencia);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return incidencias;
        }

        public static IList<TIncidencia> GetTIncidencias(SqlCeConnection conn)
        {
            List<TIncidencia> incidencias = new List<TIncidencia>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Incidencia";

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidencia incidencia = GetTIncidencia(dr.GetInt32(0), conn);
                    if (incidencia != null)
                        incidencias.Add(incidencia);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return incidencias;
        }

        public static void TSave(TIncidencia tr, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TIncidencia ttr = GetTIncidencia(tr.IncidenciaId, conn);
            if (ttr == null)
            {
                sql = @"INSERT INTO Incidencia(incidencia_id, fecha_apertura, operativo, disp_id, usuario_id, comentarios, fecha_cierre, fecha_prevista) 
                                VALUES({0},{1},{2},{3},{4},'{5}',{6},{7})";
            }
            else
            {
                sql = @"UPDATE Incidencia SET
                        fecha_apertura={1},
                        operativo={2},
                        disp_id={3}, 
                        usuario_id={4},
                        comentarios='{5}',
                        fecha_cierre={6},
                        fecha_prevista={7}
                        WHERE incidencia_id={0}";
            }
            string fecha;
            string fechac;
            string fechap;
            // fecha apertura
            if (CntSciTerminal.FechaNula(tr.FechaApertura))
                fecha = "NULL";
            else
                fecha = String.Format("'{0:MM/dd/yyyy}'", tr.FechaApertura);
            // fecha cierre
            if (CntSciTerminal.FechaNula(tr.FechaCierre))
                fechac = "NULL";
            else
                fechac = String.Format("'{0:MM/dd/yyyy}'", tr.FechaCierre);
            // fecha prevista
            if (CntSciTerminal.FechaNula(tr.FechaPrevista))
                fechap = "NULL";
            else
                fechap = String.Format("'{0:MM/dd/yyyy}'", tr.FechaPrevista);
            
            int d = 0;
            if (tr.TDispositivo != null)
                d = tr.TDispositivo.DispositivoId;
            int u = 0;
            if (tr.TUsuario != null)
                u = tr.TUsuario.UsuarioId;
            int op = 0;
            if (tr.Operativo)
                op = 1;
            tr.Comentarios = tr.Comentarios.Replace("'", "");
            sql = String.Format(sql, tr.IncidenciaId, fecha, op, d, u, tr.Comentarios, fechac, fechap);

            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}