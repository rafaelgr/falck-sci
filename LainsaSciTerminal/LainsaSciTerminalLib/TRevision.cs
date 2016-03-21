using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TRevision
    {
        private int revisionId;

        public int RevisionId
        {
            get { return revisionId; }
            set { revisionId = value; }
        }
        private TUsuario usuario;

        public TUsuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private DateTime fechaPlanificada;

        public DateTime FechaPlanificada
        {
            get { return fechaPlanificada; }
            set { fechaPlanificada = value; }
        }
        private DateTime fechaRevision;

        public DateTime FechaRevision
        {
            get { return fechaRevision; }
            set { fechaRevision = value; }
        }
        private DateTime fechaProgramada;

        public DateTime FechaProgramada
        {
            get { return fechaProgramada; }
            set { fechaProgramada = value; }
        }
        private string resultado;

        public string Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }
        private string comentario;

        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        private TDispositivo dispositivo;

        public TDispositivo Dispositivo
        {
            get { return dispositivo; }
            set { dispositivo = value; }
        }

        private IList<TDatoRevision> datosRevision;

        public IList<TDatoRevision> DatosRevision
        {
            get { return datosRevision; }
            set { datosRevision = value; }
        }

        private TPrograma tPrograma;

        public TPrograma TPrograma
        {
            get { return tPrograma; }
            set { tPrograma = value; }
        }

        public TRevision()
        {
            datosRevision = new List<TDatoRevision>();
        }

        private string nDispositivo;

        public string NDispositivo
        {
            get 
            {
                //nDispositivo = "";
                //if (Dispositivo != null)
                //{
                //    nDispositivo = Dispositivo.Nombre;
                //}
                return nDispositivo; 
            }
            set { nDispositivo = value; }
        }
        private string nInstalacion;

        public string NInstalacion
        {
            get 
            {
                //nInstalacion = "";
                //if (Dispositivo != null)
                //{
                //    nInstalacion = Dispositivo.Instalacion.Nombre;
                //}
                return nInstalacion; 
            }
            set { nInstalacion = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string posicion;

        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }


        private string plantilla;

        public string Plantilla
        {
            get { return plantilla; }
            set { plantilla = value; }
        }

        private TTipoAnomalia tTipoAnomalia;

        public TTipoAnomalia TTipoAnomalia
        {
            get { return tTipoAnomalia; }
            set { tTipoAnomalia = value; }
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
        public static TRevision GetTRevisionC(int id, SqlCeConnection conn)
        {
            TRevision revision = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Revision WHERE revision_id = {0}",
                    id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    revision = new TRevision()
                    {
                        RevisionId = dr.GetInt32(0),
                        Usuario = GetTUsuario(dr.GetInt32(2), conn),
                        Dispositivo = GetTDispositivo(dr.GetInt32(1), conn),
                        Resultado = dr.GetString(6),
                        Comentario = dr.GetString(7),
                        TPrograma = GetTProgramaC(dr.GetInt32(8), conn),
                        Estado = dr.GetString(9),
                        Plantilla = dr.GetString(10),
                        Abm = dr.GetByte(11)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(4);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(5);
                    if (dr.GetInt32(11) == 0)
                        revision.TTipoAnomalia = null;
                    else
                        revision.TTipoAnomalia = GetTTipoAnomalia(dr.GetInt32(11), conn);
                    break;
                }
                if (!dr.IsClosed) dr.Close();
            }
            // No profundizamos para evitar bucles.
            return revision;
        }
        public static TRevision GetTRevision(int id, SqlCeConnection conn)
        {
            TRevision revision = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Revision WHERE revision_id = {0}", 
                    id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    revision = new TRevision()
                    {
                        RevisionId = dr.GetInt32(0),
                        Usuario = GetTUsuario(dr.GetInt32(2),conn),
                        Dispositivo = GetTDispositivo(dr.GetInt32(1),conn),
                        Resultado = dr.GetString(6),
                        Comentario = dr.GetString(7),
                        TPrograma = GetTProgramaC(dr.GetInt32(8),conn),
                        Estado = dr.GetString(9),
                        Plantilla = dr.GetString(10),
                        Abm = dr.GetByte(12)
                    };
                    revision.NInstalacion = revision.Dispositivo.Instalacion.Nombre;
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(4);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(5);
                    if (dr.GetInt32(11) == 0)
                        revision.TTipoAnomalia = null;
                    else
                        revision.TTipoAnomalia = GetTTipoAnomalia(dr.GetInt32(11), conn);
                    revision.DatosRevision = GetTDatosRevision(revision, conn);
                    break;
                }
                if (!dr.IsClosed) dr.Close();
            }
            return revision;
        }
        public static IList<TRevision> GetTRevisiones(TPrograma programa, SqlCeConnection conn)
        {
            List<TRevision> revisiones = new List<TRevision>();
            if (programa == null) return revisiones;
            using (SqlCeCommand cmd = conn.CreateCommand()) 
            {
                cmd.CommandText = String.Format("SELECT DISTINCT r.revision_id, r.fecha_planificada, d.nombre, r.estado, d.posicion, r.abm FROM Revision r INNER JOIN Dispositivo d ON d.dispositivo_id = r.dispositivo_id  WHERE programa_id = {0} ORDER BY fecha_planificada ASC", 
                    programa.ProgramaId);
                
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TRevision revision = new TRevision()
                    {
                        RevisionId = dr.GetInt32(0),
                        NDispositivo = dr.GetString(2),
                        TPrograma = programa,
                        Estado = dr.GetString(3),
                        NInstalacion = programa.NInstalacion,
                        Posicion = dr.GetString(4),
                        Abm = dr.GetByte(5)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(1);
                    revisiones.Add(revision);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return revisiones;
        }
        public static IList<TRevision> GetTRevisionesEstado(TPrograma programa, SqlCeConnection conn)
        {
            List<TRevision> revisiones = new List<TRevision>();
            if (programa == null) return revisiones;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT estado FROM Revision  WHERE programa_id = {0}",
                    programa.ProgramaId);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TRevision revision = new TRevision()
                    {
                        Estado = dr.GetString(0),
                    };
                    revisiones.Add(revision);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return revisiones;
        }
        public static IList<TRevision> GetTRevisiones(bool estado, TDispositivo dispositivo, SqlCeConnection conn)
        {
            List<TRevision> revisiones = new List<TRevision>();
            if (dispositivo == null) return revisiones;
            string sql = String.Format("SELECT DISTINCT r.revision_id, r.fecha_planificada, d.nombre, r.estado, d.posicion, r.abm FROM Revision r INNER JOIN Dispositivo d ON d.dispositivo_id = r.dispositivo_id  WHERE d.dispositivo_id = {0} ORDER BY fecha_planificada ASC",
                    dispositivo.DispositivoId);
            if(estado)
                sql = String.Format("SELECT DISTINCT r.revision_id, r.fecha_planificada, d.nombre, r.estado, d.posicion, r.abm FROM Revision r INNER JOIN Dispositivo d ON d.dispositivo_id = r.dispositivo_id  WHERE d.dispositivo_id = {0} AND r.estado = '{1}' ORDER BY fecha_planificada ASC",
                    dispositivo.DispositivoId,
                    "PROGRAMADA");
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TRevision revision = new TRevision()
                    {
                        RevisionId = dr.GetInt32(0),
                        NDispositivo = dr.GetString(2),
                        Dispositivo = dispositivo,
                        Estado = dr.GetString(3),
                        NInstalacion = dispositivo.Instalacion.Nombre,
                        Posicion = dr.GetString(4),
                        Abm = dr.GetByte(5)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(1);
                    revisiones.Add(revision);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return revisiones;
        }
        public static IList<TRevision> GetTRevisionesC(TPrograma programa, SqlCeConnection conn)
        {
            List<TRevision> revisiones = new List<TRevision>();
            if (programa == null) return revisiones;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Revision WHERE programa_id = {0} ORDER BY fecha_planificada DESC",
                    programa.ProgramaId);

                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TRevision revision = new TRevision()
                    {
                        RevisionId = dr.GetInt32(0),
                        Usuario = GetTUsuario(dr.GetInt32(2), conn),
                        Dispositivo = GetTDispositivo(dr.GetInt32(1), conn),
                        Resultado = dr.GetString(6),
                        Comentario = dr.GetString(7),
                        TPrograma = GetTProgramaC(dr.GetInt32(8), conn),
                        Estado = dr.GetString(9),
                        Plantilla = dr.GetString(10),
                        Abm = dr.GetByte(12)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(4);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(5);
                    if (dr.GetInt32(11) == 0)
                        revision.TTipoAnomalia = null;
                    else
                        revision.TTipoAnomalia = GetTTipoAnomalia(dr.GetInt32(11), conn);
                    //revision.DatosRevision = GetTDatosRevision(revision, conn);
                    revisiones.Add(revision);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return revisiones;
        }

        public static void TSave(TRevision tr, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TRevision ttr = GetTRevision(tr.RevisionId, conn);
            byte abm = ttr.Abm;
            if (abm != 1) abm = 3;
            if (ttr == null)
            {
                sql = @"INSERT INTO Revision(revision_id, dispositivo_id, usuario_id,
                                fecha_planificada, fecha_programada, fecha_revision,
                                resultado, comentarios, programa_id, estado, plantilla, tipo_anomalia_id, abm) 
                                VALUES({0},{1},{2},
                                {3}, 
                                {4}, 
                                {5},
                                '{6}','{7}',{8},'{9}','{10}',{11},1)";
            }
            else
            {
                sql = @"UPDATE Revision SET
                        dispositivo_id={1}, usuario_id={2},
                        fecha_planificada={3},
                        fecha_programada={4}, 
                        fecha_revision={5},
                        resultado='{6}',comentarios='{7}',programa_id={8},
                        estado='{9}', plantilla='{10}', tipo_anomalia_id={11},
                        abm={12}
                        WHERE revision_id={0}";
            }
            string fecha3;
            string fecha4;
            string fecha5;
            if (CntSciTerminal.FechaNula(tr.FechaPlanificada)) 
                fecha3 = "NULL";
            else 
                fecha3 = String.Format("'{0:yyyy/MM/dd}'",tr.FechaPlanificada);
            if (CntSciTerminal.FechaNula(tr.FechaProgramada))
                fecha4 = "NULL";
            else
                fecha4 = String.Format("'{0:yyyy/MM/dd}'", tr.FechaProgramada);
            if (CntSciTerminal.FechaNula(tr.FechaRevision))
                fecha5 = "NULL";
            else
                fecha5 = String.Format("'{0:yyyy/MM/dd}'", tr.FechaRevision);

            string v8 = "";
            if (tr.TPrograma == null)
                v8 = "0";
            else
                v8 = tr.TPrograma.ProgramaId.ToString();
            string v2 = "";
            if (tr.Usuario == null)
                v2 = "0";
            else
                v2 = tr.Usuario.UsuarioId.ToString();
            string resultado = "";
            if (tr.Resultado != null) resultado = tr.Resultado;
            string comentario = "";
            if (tr.Comentario != null) comentario = tr.Comentario;
            string v11 = "";
            if (tr.TTipoAnomalia == null)
                v11 = "0";
            else
                v11 = tr.TTipoAnomalia.TipoAnomaliaId.ToString();

            sql = String.Format(sql,tr.RevisionId, tr.Dispositivo.DispositivoId, v2, fecha3, fecha4, fecha5,
                    resultado, comentario, v8, tr.Estado, tr.Plantilla, v11,abm);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
        
    }
}
