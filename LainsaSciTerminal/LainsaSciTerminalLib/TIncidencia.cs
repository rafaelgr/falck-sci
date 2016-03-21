using System;
using System.Linq;
using System.Collections.Generic;
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
            get { return fecha_apertura; }
            set { fecha_apertura = value; }
        }
        private string comentarios;

        public string Comentarios
        {
            get
            {
                return comentarios;
            }
            set
            {
                comentarios = value;
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
        private TUsuario tUsuario;

        public TUsuario TUsuario
        {
            get
            {
                return tUsuario;
            }
            set
            {
                tUsuario = value;
            }
        }
        private TDispositivo tDisp;

        public TDispositivo TDisp
        {
            get
            {
                return tDisp;
            }
            set
            {
                tDisp = value;
            }
        }
        private TRevision tRevision;

        public TRevision TRevision
        {
            get
            {
                return tRevision;
            }
            set
            {
                tRevision = value;
            }
        }
        private string nDispositivo;

        public string NDispositivo
        {
            get
            {
                nDispositivo = "";
                if (TDisp != null)
                {
                    nDispositivo = TDisp.Nombre;
                }
                return nDispositivo;
            }
        }
        private string nUsuario;

        public string NUsuario
        {
            get
            {
                nUsuario = "";
                if (TUsuario != null)
                {
                    nUsuario = TUsuario.Nombre;
                }
                return nUsuario;
            }
        }

        private DateTime? fecha_cierre;

        public DateTime? FechaCierre
        {
            get { return fecha_cierre; }
            set { fecha_cierre = value; }
        }

        private TEstado tEstado;

        public TEstado TEstado
        {
            get { return tEstado; }
            set { tEstado = value; }
        }
        private TPrioridad tPrioridad;

        public TPrioridad TPrioridad
        {
            get { return tPrioridad; }
            set { tPrioridad = value; }
        }
        private TResponsable tResponsable;

        public TResponsable TResponsable
        {
            get { return tResponsable; }
            set { tResponsable = value; }
        }
        private byte abm;
        public byte Abm
        {
            get { return abm; }
            set { abm = value; }
        }
        private DateTime? fecha_prevista;

        public DateTime? FechaPrevista
        {
            get { return fecha_prevista; }
            set { fecha_prevista = value; }
        }
    }
    public static partial class CntSciTerminal
    {
        public static IList<TIncidencia> GetTIncidencias(SqlCeConnection conn)
        {
            IList<TIncidencia> l = new List<TIncidencia>();
            string sql = "SELECT * FROM Incidencia WHERE abm <> 2 ORDER BY incidencia_id DESC";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidencia tIncidencia = new TIncidencia()
                    {
                        IncidenciaId = dr.GetInt32(0),
                        Comentarios = dr.GetString(3),
                        Operativo = dr.GetBoolean(4)
                    };
                    if (dr[5] != DBNull.Value)
                        tIncidencia.FechaApertura = dr.GetDateTime(5);
                    if (dr[6] != DBNull.Value)
                        tIncidencia.FechaCierre = dr.GetDateTime(6);
                    else
                        tIncidencia.FechaCierre = null;
                    if (dr[2] != DBNull.Value)
                        tIncidencia.TUsuario = GetTUsuario(dr.GetInt32(2), conn);
                    if (dr[1] != DBNull.Value)
                        tIncidencia.TDisp = GetTDispositivo(dr.GetInt32(1), conn);
                    if (dr[7] != DBNull.Value)
                        tIncidencia.TEstado = GetTEstado(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        tIncidencia.TPrioridad = GetTPrioridad(dr.GetInt32(8), conn);
                    if (dr[9] != DBNull.Value)
                        tIncidencia.TResponsable = GetTResponsable(dr.GetInt32(9), conn);
                    tIncidencia.Abm = dr.GetByte(10);
                    if (dr[11] != DBNull.Value)
                        tIncidencia.FechaPrevista = dr.GetDateTime(11);
                    else
                        tIncidencia.FechaPrevista = null;
                    if (tIncidencia != null) l.Add(tIncidencia);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }
        public static IList<TIncidencia> GetTIncidencias(TDispositivo dispositivo, SqlCeConnection conn)
        {
            IList<TIncidencia> l = new List<TIncidencia>();
            if (dispositivo == null) return l;
            string sql = String.Format("SELECT * FROM Incidencia WHERE disp_id = {0} AND abm<>2 ORDER BY incidencia_id DESC",
                    dispositivo.DispositivoId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TIncidencia tIncidencia = new TIncidencia()
                    {
                        IncidenciaId = dr.GetInt32(0),
                        Comentarios = dr.GetString(3),
                        Operativo = dr.GetBoolean(4)
                    };
                    if (dr[5] != DBNull.Value)
                        tIncidencia.FechaApertura = dr.GetDateTime(5);
                    if (dr[6] != DBNull.Value)
                        tIncidencia.FechaCierre = dr.GetDateTime(6);
                    else
                        tIncidencia.FechaCierre = null;
                    if (dr[2] != DBNull.Value)
                        tIncidencia.TUsuario = GetTUsuario(dr.GetInt32(2), conn);
                    if (dr[1] != DBNull.Value)
                        tIncidencia.TDisp = GetTDispositivo(dr.GetInt32(1), conn);
                    if (dr[7] != DBNull.Value)
                        tIncidencia.TEstado = GetTEstado(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        tIncidencia.TPrioridad = GetTPrioridad(dr.GetInt32(8), conn);
                    if (dr[9] != DBNull.Value)
                        tIncidencia.TResponsable = GetTResponsable(dr.GetInt32(9), conn);
                    tIncidencia.Abm = dr.GetByte(10);
                    if (dr[11] != DBNull.Value)
                        tIncidencia.FechaPrevista = dr.GetDateTime(11);
                    else
                        tIncidencia.FechaPrevista = null;
                    l.Add(tIncidencia);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }
        public static TIncidencia GetTIncidencia(int id, SqlCeConnection conn)
        {
            TIncidencia tIncidencia = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Incidencia WHERE incidencia_id = {0} AND abm <> 2", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tIncidencia = new TIncidencia()
                    {
                        IncidenciaId = dr.GetInt32(0),
                        Comentarios = dr.GetString(3),
                        Operativo = dr.GetBoolean(4)
                    };
                    if (dr[5] != DBNull.Value)
                        tIncidencia.FechaApertura = dr.GetDateTime(5);
                    if (dr[6] != DBNull.Value)
                        tIncidencia.FechaCierre = dr.GetDateTime(6);
                    else
                        tIncidencia.FechaCierre = null;
                    if (dr[2] != DBNull.Value)
                        tIncidencia.TUsuario = GetTUsuario(dr.GetInt32(2), conn);
                    if (dr[1] != DBNull.Value)
                        tIncidencia.TDisp = GetTDispositivo(dr.GetInt32(1), conn);
                    if (dr[7] != DBNull.Value)
                        tIncidencia.TEstado = GetTEstado(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        tIncidencia.TPrioridad = GetTPrioridad(dr.GetInt32(8), conn);
                    if (dr[9] != DBNull.Value)
                        tIncidencia.TResponsable = GetTResponsable(dr.GetInt32(9), conn);
                    if (dr[11] != DBNull.Value)
                        tIncidencia.FechaPrevista = dr.GetDateTime(11);
                    else
                        tIncidencia.FechaPrevista = null;
                    tIncidencia.Abm = dr.GetByte(10);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return tIncidencia;
        }
        public static void TSave(bool newRecord, TIncidencia ts, SqlCeConnection conn)
        {
            int usuario_id = 0;
            if (ts.TUsuario != null) usuario_id = ts.TUsuario.UsuarioId;
            int dispo_id = 0;
            if (ts.TDisp != null) dispo_id = ts.TDisp.DispositivoId;
            int estado_id = 0;
            if (ts.TEstado != null) estado_id = ts.TEstado.EstadoId;
            int prioridad_id = 0;
            if (ts.TPrioridad != null) prioridad_id = ts.TPrioridad.PrioridadId;
            int responsable_id = 0;
            if (ts.TResponsable != null) responsable_id = ts.TResponsable.ResponsableId;
            string fecha_apertura = "NULL";
            if (!CntSciTerminal.FechaNula(ts.FechaApertura)) fecha_apertura = String.Format("'{0:MM/dd/yyyy}'", ts.FechaApertura);
            string fecha_prevista = "NULL";
            if (!CntSciTerminal.FechaNula(ts.FechaPrevista)) fecha_prevista = String.Format("'{0:MM/dd/yyyy}'", ts.FechaPrevista);
            string fecha_cierre = "NULL";
            if (!CntSciTerminal.FechaNula(ts.FechaCierre)) fecha_cierre = String.Format("'{0:MM/dd/yyyy}'", ts.FechaCierre);
            string comentarios = "";
            if (ts.Comentarios != null) comentarios = ts.Comentarios;
            int operativo = 0;
            if (ts.Operativo) operativo = 1;
            byte abm = ts.Abm;
            if (abm != 1) abm = 3;
            string sql = "";
            // primero verificamos que si el elemento está
            if (newRecord)
            {
                //Seleccionamos el id con una unidad mayor que el máximo de la base de datos
                sql = @"SELECT MAX(incidencia_id) from incidencia";
                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            ts.IncidenciaId = dr.GetInt32(0) + 1;
                        else
                            ts.IncidenciaId = 1;
                        break;
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                sql = @"INSERT INTO Incidencia(incidencia_id, fecha_apertura, comentarios,
                            usuario_id, disp_id, operativo, fecha_cierre, estado_id, prioridad_id, responsable_id, abm, fecha_prevista) 
                            VALUES({0},{1},'{2}',{3},
                            {4},{5},{6},{7},{8},{9},1,{11})";
                
            }
            else
            {
                sql = @"UPDATE Incidencia SET fecha_apertura={1},comentarios='{2}',
                        usuario_id={3}, disp_id={4}, operativo={5}, fecha_cierre={6}, estado_id={7}, prioridad_id={8}, responsable_id={9},
                        abm={10}, fecha_prevista={11}
                        WHERE incidencia_id={0}";
            }

            sql = String.Format(sql, ts.IncidenciaId, fecha_apertura, comentarios,
               usuario_id, dispo_id, operativo, fecha_cierre, estado_id, prioridad_id, responsable_id,abm,fecha_prevista);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            //Modificamos la operatividad del dispositivo según la incidencia
            sql = String.Format(@"UPDATE Dispositivo SET operativo={1}
                        WHERE dispositivo_id={0}", ts.TDisp.DispositivoId, operativo);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            // hay que actualizar el dispositivo
            TDispositivo d = ts.TDisp;
            d.Operativo = ts.Operativo;
            CntSciTerminal.TSave(d, conn);
        }
        public static void TDelete(TIncidencia ts, SqlCeConnection conn)
        {
            string sql = String.Format(@"UPDATE Incidencia SET abm=2 WHERE incidencia_id={0}", ts.IncidenciaId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
