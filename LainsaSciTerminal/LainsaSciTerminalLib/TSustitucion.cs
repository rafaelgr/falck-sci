using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TSustitucion
    {
        private int sustitucionId;

        public int SustitucionId
        {
            get
            {
                return sustitucionId;
            }
            set
            {
                sustitucionId = value;
            }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
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
        private string nInstalacion;

        public string NInstalacion
        {
            get
            {
                return nInstalacion;
            }
            set
            {
                nInstalacion = value;
            }
        }
        private TDispositivo tDispositivoOriginal;

        public TDispositivo TDispositivoOriginal
        {
            get
            {
                return tDispositivoOriginal;
            }
            set
            {
                tDispositivoOriginal = value;
            }
        }
        private TDispositivo tDispositivoSustituto;

        public TDispositivo TDispositivoSustituto
        {
            get
            {
                return tDispositivoSustituto;
            }
            set
            {
                tDispositivoSustituto = value;
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
        private TPrograma tPrograma;

        public TPrograma TPrograma
        {
            get
            {
                return tPrograma;
            }
            set
            {
                tPrograma = value;
            }
        }
        private string nDispositivoO;

        public string NDispositivoO
        {
            get
            {
                nDispositivoO = "";
                if (TDispositivoOriginal != null)
                {
                    nDispositivoO = TDispositivoOriginal.Nombre;
                }
                return nDispositivoO;
            }
        }
        private string nDispositivoS;

        public string NDispositivoS
        {
            get
            {
                nDispositivoS = "";
                if (TDispositivoSustituto != null)
                {
                    nDispositivoS = TDispositivoSustituto.Nombre;
                }
                return nDispositivoS;
            }
        }
        // indicador abm
        private byte abm;
        public byte Abm
        {
            get { return abm; }
            set { abm = value; }
        }
    }


    public static partial class CntSciTerminal
    {
        public static IList<TSustitucion> GetTSustituciones(SqlCeConnection conn)
        {
            IList<TSustitucion> l = new List<TSustitucion>();
            string sql = "SELECT * FROM Sustituciones ORDER BY fecha ASC";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TSustitucion tSustitucion = new TSustitucion()
                    {
                        SustitucionId = dr.GetInt32(0),
                        Comentarios = dr.GetString(2),
                        Estado = dr.GetString(3),
                        Abm = dr.GetByte(9)
                    };
                    if (dr[1] != DBNull.Value)
                        tSustitucion.Fecha = dr.GetDateTime(1);
                    if (dr[4] != DBNull.Value)
                        tSustitucion.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                    if (dr[5] != DBNull.Value)
                        tSustitucion.TDispositivoOriginal = GetTDispositivo(dr.GetInt32(5), conn);
                    if (dr[6] != DBNull.Value)
                        tSustitucion.TDispositivoSustituto = GetTDispositivo(dr.GetInt32(6), conn);
                    if (dr[7] != DBNull.Value)
                        tSustitucion.TRevision = GetTRevision(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        tSustitucion.TPrograma = GetTPrograma(dr.GetInt32(8), conn);
                    if (tSustitucion.TDispositivoOriginal != null)
                        tSustitucion.NInstalacion = tSustitucion.TDispositivoOriginal.Instalacion.Nombre;
                    if (tSustitucion != null) l.Add(tSustitucion);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }
        public static IList<TSustitucion> GetTSustituciones(TDispositivo dispositivo, SqlCeConnection conn)
        {
            IList<TSustitucion> l = new List<TSustitucion>();
            string sql = String.Format("SELECT * FROM Sustituciones WHERE dispo_id = {0} ORDER BY fecha ASC",
                    dispositivo.DispositivoId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TSustitucion tSustitucion = new TSustitucion()
                    {
                        SustitucionId = dr.GetInt32(0),
                        Comentarios = dr.GetString(2),
                        Estado = dr.GetString(3),
                        Abm = dr.GetByte(9)
                    };
                    if (dr[1] != DBNull.Value)
                        tSustitucion.Fecha = dr.GetDateTime(1);
                    if (dr[4] != DBNull.Value)
                        tSustitucion.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                    if (dr[5] != DBNull.Value)
                        tSustitucion.TDispositivoOriginal = GetTDispositivo(dr.GetInt32(5), conn);
                    if (dr[6] != DBNull.Value)
                        tSustitucion.TDispositivoSustituto = GetTDispositivo(dr.GetInt32(6), conn);
                    if (dr[7] != DBNull.Value)
                        tSustitucion.TRevision = GetTRevision(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        tSustitucion.TPrograma = GetTPrograma(dr.GetInt32(8), conn);
                    if (tSustitucion.TDispositivoOriginal != null)
                        tSustitucion.NInstalacion = tSustitucion.TDispositivoOriginal.Instalacion.Nombre;

                    l.Add(tSustitucion);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return l;
        }
        public static TSustitucion GetTSustitucion(int id, SqlCeConnection conn)
        {
            TSustitucion tSustitucion = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Sustituciones WHERE sustitucion_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tSustitucion = new TSustitucion()
                    {
                        SustitucionId = id,
                        Comentarios = dr.GetString(2),
                        Estado = dr.GetString(3),
                        Abm = dr.GetByte(9)
                    };
                    if (dr[1] != DBNull.Value)
                        tSustitucion.Fecha = dr.GetDateTime(1);
                    if (dr[4] != DBNull.Value)
                        tSustitucion.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                    if (dr[5] != DBNull.Value)
                        tSustitucion.TDispositivoOriginal = GetTDispositivo(dr.GetInt32(5), conn);
                    if (dr[6] != DBNull.Value)
                        tSustitucion.TDispositivoSustituto = GetTDispositivo(dr.GetInt32(6), conn);
                    if (dr[7] != DBNull.Value)
                        tSustitucion.TRevision = GetTRevision(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        tSustitucion.TPrograma = GetTPrograma(dr.GetInt32(8), conn);
                    if (tSustitucion.TDispositivoOriginal != null)
                        tSustitucion.NInstalacion = tSustitucion.TDispositivoOriginal.Instalacion.Nombre;
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return tSustitucion;
        }
        public static void TSave(bool newRecord, TSustitucion ts, SqlCeConnection conn)
        {
            int usuario_id = 0;
            if (ts.TUsuario != null) usuario_id = ts.TUsuario.UsuarioId;
            int dispo_id = 0;
            if (ts.TDispositivoOriginal != null) dispo_id = ts.TDispositivoOriginal.DispositivoId;
            int dispos_id = 0;
            if (ts.TDispositivoSustituto != null)  dispos_id = ts.TDispositivoSustituto.DispositivoId;
            int programa_id = 0;
            if (ts.TPrograma != null) programa_id = ts.TPrograma.ProgramaId;
            int revision_id = 0;
            if (ts.TRevision != null)
            {
                revision_id = ts.TRevision.RevisionId;
                if (ts.TRevision.TPrograma != null)
                    programa_id = ts.TRevision.TPrograma.ProgramaId; 
            }
            string fecha = "NULL";
            if (!CntSciTerminal.FechaNula(ts.Fecha)) fecha = String.Format("'{0}'", ts.Fecha);
                //fecha_apertura = String.Format("'{0:dd/MM/yyyy}'", ts.Fecha);
            string comentarios = "";
            if (ts.Comentarios != null) comentarios = ts.Comentarios;
            //manejo ss
            byte abm = ts.Abm;
            if (abm != 1) abm = 3;
            string sql = "";
            if(newRecord)
            {
                sql = @"SELECT MAX(sustitucion_id) from sustituciones";
                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SqlCeDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0] != DBNull.Value)
                            ts.SustitucionId = dr.GetInt32(0) + 1;
                        else
                            ts.SustitucionId = 1;
                       break;
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                sql = @"INSERT INTO Sustituciones(sustitucion_id, fecha, comentarios, estado,
                            usuario_id, dispo_id, disps_id, revision_id, programa_id, abm) 
                            VALUES({0},{1},'{2}','{3}',
                            {4},{5},{6},{7},{8},1)";
            }
            else
            {
                sql = @"UPDATE Sustituciones SET fecha={1},comentarios='{2}',estado='{3}',
                        usuario_id={4}, dispo_id={5}, disps_id={6}, revision_id={7}, programa_id={8},
                        abm = {9}
                        WHERE sustitucion_id={0}";
            }
            sql = String.Format(sql, ts.SustitucionId, fecha, comentarios, ts.Estado, 
                usuario_id, dispo_id, dispos_id, revision_id, programa_id, abm);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            //Ahora actualizamos el estado de los dispositivos
            sql = @"UPDATE Dispositivo SET estado='{1}'
                        WHERE dispositivo_id={0}";
            sql = String.Format(sql, ts.TDispositivoOriginal.DispositivoId, ts.TDispositivoOriginal.Estado);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            if (ts.TDispositivoSustituto != null)
            {
                sql = @"UPDATE Dispositivo SET estado='{1}'
                        WHERE dispositivo_id={0}";
                sql = String.Format(sql, ts.TDispositivoSustituto.DispositivoId, ts.TDispositivoSustituto.Estado);
                using (SqlCeCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void TDelete(TSustitucion ts, SqlCeConnection conn)
        {
            string sql = String.Format(@"DELETE FROM Sustituciones WHERE sustitucion_id={0}", ts.SustitucionId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }
    }
}