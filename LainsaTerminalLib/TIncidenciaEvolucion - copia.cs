using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TIncidenciaEvolucion
    {
        private int incidencia_evolucion_id;

        public int IncidenciaEvolucionId
        {
            get { return incidencia_evolucion_id; }
            set { incidencia_evolucion_id = value; }
        }
        private TIncidencia incidencia;

        public TIncidencia Incidencia
        {
            get { return incidencia; }
            set { incidencia = value; }
        }
        private DateTime fecha_evolucion;

        public DateTime FechaEvolucion
        {
            get { return fecha_evolucion; }
            set { fecha_evolucion = value; }
        }
        private string comentarios;

        public string Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }
        private TUsuario usuario;

        public TUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private bool operativo;

        public bool Operativo
        {
            get { return operativo; }
            set { operativo = value; }
        }

    }

    public static partial class CntSciTerminal
    {
        public static TIncidenciaEvolucion GetTIncidenciaEvolucion(int id, SqlCeConnection conn)
        {
            TIncidenciaEvolucion incidenciaEvolucion = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM IncidenciaEvolucion WHERE incidencia_evolucion_id = {0}",
                    id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    incidenciaEvolucion = new TIncidenciaEvolucion()
                    {
                        IncidenciaEvolucionId = dr.GetInt32(0),
                        Operativo = dr.GetBoolean(5),
                        Usuario = GetTUsuario(dr.GetInt32(4), conn),
                        Incidencia = GetTIncidencia(dr.GetInt32(1), conn),
                        Comentarios = dr.GetString(3)
                    };
                    // control de nulos en fechas.
                    if (dr[2] != DBNull.Value) incidenciaEvolucion.FechaEvolucion = dr.GetDateTime(2);
                }
                if (!dr.IsClosed) dr.Close();
            }
            // No profundizamos para evitar bucles.
            return incidenciaEvolucion;
        }

        public static IList<TIncidenciaEvolucion> GetTIncidenciaEvolucions(TIncidencia incidencia, SqlCeConnection conn)
        {
            List<TIncidenciaEvolucion> incidenciaEvolucions = new List<TIncidenciaEvolucion>();
            if (incidencia == null) return incidenciaEvolucions;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM IncidenciaEvolucion WHERE incidencia_id = {0}",
                    incidencia.IncidenciaId);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidenciaEvolucion IncidenciaEvolucion = new TIncidenciaEvolucion()
                    {
                        IncidenciaEvolucionId = dr.GetInt32(0),
                        Operativo = dr.GetBoolean(5),
                        Usuario = GetTUsuario(dr.GetInt32(3), conn),
                        Incidencia = GetTIncidencia(dr.GetInt32(1), conn),
                        Comentarios = dr.GetString(4)
                    };
                    // control de nulos en fechas.
                    if (dr[2] != DBNull.Value) IncidenciaEvolucion.FechaEvolucion = dr.GetDateTime(2);

                    if (IncidenciaEvolucion != null)
                        incidenciaEvolucions.Add(IncidenciaEvolucion);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return incidenciaEvolucions;
        }

        public static IList<TIncidenciaEvolucion> GetTIncidenciaEvolucions(SqlCeConnection conn)
        {
            List<TIncidenciaEvolucion> incidenciaEvolucions = new List<TIncidenciaEvolucion>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM IncidenciaEvolucion";

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidenciaEvolucion IncidenciaEvolucion = new TIncidenciaEvolucion()
                    {
                        IncidenciaEvolucionId = dr.GetInt32(0),
                        Incidencia = GetTIncidencia(dr.GetInt32(1), conn),
                    };
                    if (IncidenciaEvolucion != null)
                        incidenciaEvolucions.Add(IncidenciaEvolucion);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return incidenciaEvolucions;
        }

        public static void TSave(TIncidenciaEvolucion tr, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TIncidenciaEvolucion ttr = GetTIncidenciaEvolucion(tr.IncidenciaEvolucionId, conn);
            if (ttr == null)
            {
                sql = @"INSERT INTO IncidenciaEvolucion(incidencia_evolucion_id, incidencia_id, fecha_evolucion, comentarios, usuario_id, operativo) 
                                VALUES({0},{1},{2},'{3}',{4},{5})";
            }
            else
            {
                sql = @"UPDATE IncidenciaEvolucion SET
                        incidencia_id={1},
                        fecha_evolucion={2},
                        comentarios='{3}', 
                        usuario_id={4},
                        operativo={5}
                        WHERE incidencia_evolucion_id={0}";
            }
            string fecha;
            if (CntSciTerminal.FechaNula(tr.FechaEvolucion))
                fecha = "NULL";
            else
                fecha = String.Format("'{0:MM/dd/yyyy}'", tr.FechaEvolucion);
            int i = 0;
            if (tr.Incidencia != null)
                i = tr.Incidencia.IncidenciaId;
            int u = 0;
            if (tr.Usuario != null)
                u = tr.Usuario.UsuarioId;
            int op = 0;
            if (tr.Operativo)
                op = 1;

            sql = String.Format(sql, tr.IncidenciaEvolucionId, i, fecha, tr.Comentarios, u, op);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

    }
}
