using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
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
        private TIncidencia tIncidencia;

        public TIncidencia TIncidencia
        {
            get { return tIncidencia; }
            set { tIncidencia = value; }
        }
        private DateTime fecha_evolucion;

        public DateTime FechaEvolucion
        {
            get { return fecha_evolucion; }
            set { fecha_evolucion = value; }
        }
        private String comentarios;

        public String Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }
        private TUsuario tUsuario;

        public TUsuario TUsuario
        {
            get { return tUsuario; }
            set { tUsuario = value; }
        }
        private bool operativo;

        public bool Operativo
        {
            get { return operativo; }
            set { operativo = value; }
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
        public static IList<TIncidenciaEvolucion> GetTIncidenciaEvolucions(SqlCeConnection conn)
        {
            IList<TIncidenciaEvolucion> l = new List<TIncidenciaEvolucion>();
            string sql = "SELECT * FROM IncidenciaEvolucion WHERE abm <> 2 ORDER BY incidencia_id DESC";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidenciaEvolucion tIncidenciaEvolucion = new TIncidenciaEvolucion()
                    {
                        IncidenciaEvolucionId = dr.GetInt32(0),
                        Comentarios = dr.GetString(3),
                        Operativo = dr.GetBoolean(5)
                    };
                    if (dr[2] != DBNull.Value)
                        tIncidenciaEvolucion.FechaEvolucion = dr.GetDateTime(2);
                    if (dr[4] != DBNull.Value)
                        tIncidenciaEvolucion.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                    tIncidenciaEvolucion.Abm = dr.GetByte(6);
                    if (tIncidenciaEvolucion != null) l.Add(tIncidenciaEvolucion);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }
        public static IList<TIncidenciaEvolucion> GetTIncidenciaEvolucions(TIncidencia incidencia, SqlCeConnection conn)
        {
            IList<TIncidenciaEvolucion> l = new List<TIncidenciaEvolucion>();
            if (incidencia == null) return l;
            string sql = String.Format("SELECT * FROM IncidenciaEvolucion WHERE incidencia_id = {0} AND abm <> 2 ORDER BY incidencia_evolucion_id DESC",
                    incidencia.IncidenciaId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidenciaEvolucion tIncidenciaEvolucion = new TIncidenciaEvolucion()
                    {
                        IncidenciaEvolucionId = dr.GetInt32(0),
                        Comentarios = dr.GetString(3),
                        Operativo = dr.GetBoolean(5)
                    };
                    if (dr[1] != DBNull.Value)
                        tIncidenciaEvolucion.TIncidencia = GetTIncidencia(dr.GetInt32(1),conn);
                    if (dr[2] != DBNull.Value)
                        tIncidenciaEvolucion.FechaEvolucion = dr.GetDateTime(2);
                    if (dr[4] != DBNull.Value)
                        tIncidenciaEvolucion.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                    if (tIncidenciaEvolucion != null) l.Add(tIncidenciaEvolucion);
                    tIncidenciaEvolucion.Abm = dr.GetByte(6);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }
        public static TIncidenciaEvolucion GetTIncidenciaEvolucion(int id, SqlCeConnection conn)
        {
            TIncidenciaEvolucion tIncidenciaEvolucion = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM IncidenciaEvolucion WHERE incidencia_evolucion_id = {0} AND abm <> 2", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tIncidenciaEvolucion = new TIncidenciaEvolucion()
                    {
                        IncidenciaEvolucionId = dr.GetInt32(0),
                        Comentarios = dr.GetString(3),
                        Operativo = dr.GetBoolean(5),
                        Abm = dr.GetByte(6)
                    };
                    if (dr[2] != DBNull.Value)
                        tIncidenciaEvolucion.FechaEvolucion = dr.GetDateTime(2);
                    if (dr[4] != DBNull.Value)
                        tIncidenciaEvolucion.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return tIncidenciaEvolucion;
        }
        public static void TSave(bool newRecord, TIncidenciaEvolucion te, SqlCeConnection conn)
        {
            int usuario_id = 0;
            if (te.TUsuario != null) usuario_id = te.TUsuario.UsuarioId;
            int incidencia_id = 0;
            if (te.TIncidencia != null) incidencia_id = te.TIncidencia.IncidenciaId;
            string fecha_evolucion = "NULL";
            if (!CntSciTerminal.FechaNula(te.FechaEvolucion)) fecha_evolucion = String.Format("'{0}'", te.FechaEvolucion);
            string comentarios = "";
            if (te.Comentarios != null) comentarios = te.Comentarios;
            int operativo = 0;
            if (te.Operativo) operativo = 1;
            // leemos el indicador
            byte abm = te.Abm;
            // si ha sido dado de alta hay que evitar que la importación lo considere como 
            // modifiación, porque el ID puede coincidir con otro.
            if (abm != 1) abm = 3;
            string sql = "";
            // primero verificamos que si el elemento está
            if (newRecord)
            {
                //Seleccionamos el id con una unidad mayor que el máximo de la base de datos
                sql = @"SELECT MAX(incidencia_evolucion_id) from IncidenciaEvolucion";
                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            te.IncidenciaEvolucionId = dr.GetInt32(0) + 1;
                        else
                            te.IncidenciaEvolucionId = 1;
                        break;
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                sql = @"INSERT INTO IncidenciaEvolucion(incidencia_evolucion_id,incidencia_id, fecha_evolucion, comentarios,
                            usuario_id, operativo, abm) 
                            VALUES({0},{1},{2},'{3}',{4},{5},1)";

            }
            else
            {
                sql = @"UPDATE IncidenciaEvolucion SET incidencia_id={1}, fecha_evolucion={2}, comentarios='{3}',
                        usuario_id={4}, operativo={5}, abm={6}
                        WHERE incidencia_evolucion_id={0}";
            }
            sql = String.Format(sql, te.IncidenciaEvolucionId, incidencia_id, fecha_evolucion, comentarios,
               usuario_id, operativo, abm);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            // hay que considerar en esta zona el cierre de la incidencia mayor si hay una evolución de cierre.
        }
        public static void TDelete(TIncidenciaEvolucion te, SqlCeConnection conn)
        {
            string sql = String.Format(@"UPDATE IncidenciaEvolucion SET abm = 2 WHERE incidencia_evolucion_id={0}", te.IncidenciaEvolucionId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
