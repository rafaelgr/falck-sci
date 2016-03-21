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

        private TDispositivo dispositivo;

        public TDispositivo Dispositivo
        {
            get
            {
                return dispositivo;
            }
            set
            {
                dispositivo = value;
            }
        }

        private TUsuario usuario;

        public TUsuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
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

        private TEstado estado;

        public TEstado Estado
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

        private TPrioridad prioridad;

        public TPrioridad Prioridad
        {
            get
            {
                return prioridad;
            }
            set
            {
                prioridad = value;
            }
        }

        private TResponsable responsable;

        public TResponsable Responsable
        {
            get
            {
                return responsable;
            }
            set
            {
                responsable = value;
            }
        }

        public TEstado TEstado
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TPrioridad TPrioridad
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TResponsable TResponsable
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TDispositivo TDispositivo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public TUsuario TUsuario
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
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
                    incidencia.Dispositivo = GetTDispositivo(dr.GetInt32(1), conn);
                    incidencia.Usuario = GetTUsuario(dr.GetInt32(2), conn);
                    incidencia.Comentarios = dr.GetString(3);
                    incidencia.Operativo = dr.GetBoolean(4);
                    // control de nulos en fechas.
                    if (dr[5] != DBNull.Value)
                        incidencia.FechaApertura = dr.GetDateTime(5);
                    if (dr[6] != DBNull.Value)
                        incidencia.FechaCierre = dr.GetDateTime(6);
                    // nuevos atributos
                    if (dr[7] != DBNull.Value)
                        incidencia.Estado = GetTEstado(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        incidencia.Prioridad = GetTPrioridad(dr.GetInt32(8), conn);
                    if (dr[9] != DBNull.Value)
                        incidencia.Responsable = GetTResponsable(dr.GetInt32(9), conn);
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
                    TIncidencia incidencia = new TIncidencia()
                    {
                        IncidenciaId = dr.GetInt32(0),
                        Operativo = dr.GetBoolean(5),
                        Usuario = GetTUsuario(dr.GetInt32(3), conn),
                        Dispositivo = GetTDispositivo(dr.GetInt32(2), conn),
                        Comentarios = dr.GetString(4)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value)
                        incidencia.FechaApertura = dr.GetDateTime(1);
                        
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
                    TIncidencia incidencia = new TIncidencia()
                    {
                        IncidenciaId = dr.GetInt32(0),
                        Dispositivo = GetTDispositivo(dr.GetInt32(2), conn),
                    };
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
                sql = @"INSERT INTO Incidencia(incidencia_id, fecha_apertura, operativo, disp_id, usuario_id, comentarios) 
                                VALUES({0},{1},{2},{3},{4},'{5}')";
            }
            else
            {
                sql = @"UPDATE Incidencia SET
                        fecha_apertura={1},
                        operativo={2},
                        disp_id={3}, 
                        usuario_id={4},
                        comentarios='{5}'
                        WHERE incidencia_id={0}";
            }
            string fecha;
            if (CntSciTerminal.FechaNula(tr.FechaApertura))
                fecha = "NULL";
            else
                fecha = String.Format("'{0:MM/dd/yyyy}'", tr.FechaApertura);
            int d = 0;
            if (tr.Dispositivo != null)
                d = tr.Dispositivo.DispositivoId;
            int u = 0;
            if (tr.Usuario != null)
                u = tr.Usuario.UsuarioId;
            int op = 0;
            if (tr.Operativo)
                op = 1;
            tr.Comentarios = tr.Comentarios.Replace("'", "");
            sql = String.Format(sql, tr.IncidenciaId, fecha, op, d, u, tr.Comentarios);

            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}