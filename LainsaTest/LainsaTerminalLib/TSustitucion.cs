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
    }

    public static partial class CntSciTerminal
    {
        public static TSustitucion GetTSustitucion(int id, SqlCeConnection conn)
        {
            TSustitucion tSustitucion = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Sustituciones WHERE sustitucion_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TSustitucion ts = new TSustitucion()
                    {
                        Comentarios = dr.GetString(2),
                        Estado = dr.GetString(3),
                    };
                    if (dr[1] != DBNull.Value) 
                        ts.Fecha = dr.GetDateTime(1);
                    if (dr[4] != DBNull.Value) 
                        ts.TUsuario = GetTUsuario(dr.GetInt32(4), conn);
                    if (dr[5] != DBNull.Value) 
                        ts.TDispositivoOriginal = GetTDispositivo(dr.GetInt32(5), conn);
                    if (dr[6] != DBNull.Value)
                        ts.TDispositivoSustituto = GetTDispositivo(dr.GetInt32(6), conn);
                    if (dr[7] != DBNull.Value)
                        ts.TRevision = GetTRevision(dr.GetInt32(7), conn);
                    if (dr[8] != DBNull.Value)
                        ts.TPrograma = GetTPrograma(dr.GetInt32(8), conn);
                }
                if (!dr.IsClosed)
                    dr.Close();
            }
            return tSustitucion;
        }
        public static void TSave(TSustitucion ts, SqlCeConnection conn)
        {
            int usuario_id = 0;
            if (ts.TUsuario != null) usuario_id = ts.TUsuario.UsuarioId;
            int dispo_id = 0;
            if (ts.TDispositivoOriginal != null) dispo_id = ts.TDispositivoOriginal.DispositivoId;
            int dispos_id = 0;
            if (ts.TDispositivoSustituto != null) dispos_id = ts.TDispositivoSustituto.DispositivoId;
            int programa_id = 0;
            if (ts.TPrograma != null) programa_id = ts.TPrograma.ProgramaId;
            int revision_id = 0;
            if (ts.TRevision != null) revision_id = ts.TRevision.RevisionId;
            string fecha = "NULL";
            if (!CntSciTerminal.FechaNula(ts.Fecha)) fecha = String.Format("'{0:yyyy/MM/dd}'", ts.Fecha);
            string comentarios = "";
            if (ts.Comentarios != null) comentarios = ts.Comentarios;
            string sql = "";
            // primero verificamos que si el elemento está
            TSustitucion tss = GetTSustitucion(ts.SustitucionId, conn);
            if (tss == null)
            {
                sql = @"INSERT INTO Sustituciones(sustitucion_id, fecha, comentarios, estado,
                            usuario_id, dispo_id, disps_id, revision_id, programa_id) 
                            VALUES({0},{1},'{2}','{3}',
                            {4},{5},{6},{7},{8})";
            }
            else
            {
                sql = @"UPDATE Sustituciones SET fecha={1},comentarios='{2}',estado='{3}',
                        usuario_id={4}, dispo_id={5}, dispos_id={6}, revision_id={7}, programa_id={8}
                        WHERE dispositivo_id={0}";
            }
            sql = String.Format(sql, ts.SustitucionId, fecha, comentarios, ts.Estado, 
                usuario_id, dispo_id, dispos_id, revision_id, programa_id);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}