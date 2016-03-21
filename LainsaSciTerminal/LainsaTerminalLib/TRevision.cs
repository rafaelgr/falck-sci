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
                nDispositivo = "";
                if (Dispositivo != null)
                {
                    nDispositivo = Dispositivo.Nombre;
                }
                return nDispositivo; 
            }
        }
        private string nInstalacion;

        public string NInstalacion
        {
            get 
            {
                nInstalacion = "";
                if (Dispositivo != null)
                {
                    nInstalacion = Dispositivo.Instalacion;
                }
                return nInstalacion; 
            }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string plantilla;

        public string Plantilla
        {
            get { return plantilla; }
            set { plantilla = value; }
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
                        Plantilla = dr.GetString(10)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(4);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(5);
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
                        TPrograma = GetTProgramaC(dr.GetInt32(8),conn)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(3);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(3);
                }
                if (!dr.IsClosed) dr.Close();
            }
            if (revision != null)
                revision.DatosRevision = GetTDatosRevision(revision, conn);
            return revision;
        }
        public static IList<TRevision> GetTRevisiones(TPrograma programa, SqlCeConnection conn)
        {
            List<TRevision> revisiones = new List<TRevision>();
            if (programa == null) return revisiones;
            using (SqlCeCommand cmd = conn.CreateCommand()) 
            {
                cmd.CommandText = String.Format("SELECT * FROM Revision WHERE programa_id = {0}", 
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
                        Plantilla = dr.GetString(10)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(3);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(3);
                    revision.DatosRevision = GetTDatosRevision(revision, conn);
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
                cmd.CommandText = String.Format("SELECT * FROM Revision WHERE programa_id = {0}",
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
                        Plantilla = dr.GetString(10)
                    };
                    // control de nulos en fechas.
                    if (dr[3] != DBNull.Value) revision.FechaPlanificada = dr.GetDateTime(3);
                    if (dr[4] != DBNull.Value) revision.FechaProgramada = dr.GetDateTime(3);
                    if (dr[5] != DBNull.Value) revision.FechaRevision = dr.GetDateTime(3);
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
            if (ttr == null)
            {
                sql = @"INSERT INTO Revision(revision_id, dispositivo_id, usuario_id,
                                fecha_planificada, fecha_programada, fecha_revision,
                                resultado, comentarios, programa_id, estado, plantilla) 
                                VALUES({0},{1},{2},
                                {3}, 
                                {4}, 
                                {5},
                                '{6}','{7}',{8},'{9}','{10}')";
            }
            else
            {
                sql = @"UPDATE Revision SET
                        dispositivo_id={1}, usuario_id={2},
                        fecha_planificada={3},
                        fecha_programada={4}, 
                        fecha_revision={5},
                        resultado='{6}',comentarios='{7}',programa_id={8},
                        estado='{9}', plantilla='{10}'
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
            sql = String.Format(sql, tr.RevisionId, tr.Dispositivo.DispositivoId, v2,fecha3, fecha4, fecha5,tr.Resultado, tr.Comentario, v8,tr.Estado, tr.Plantilla);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }



//        public static void TSave(TRevision revision, SqlCeConnection conn)
//        {
//            using (SqlCeCommand cmd = conn.CreateCommand())
//            {
//                cmd.CommandText = String.Format(@"UPDATE Revision SET
//                        FechaRevision = '{0:yyyy-MM-dd}',
//                        Resultado = '{1}',
//                        Comentario = '{2}'
//                        WHERE revision_id = {3};",
//                        revision.FechaRevision,
//                        revision.Resultado,
//                        revision.Comentario,
//                        revision.RevisionId);
//                int nrec = cmd.ExecuteNonQuery();
//            }
//        }
        
    }
}
