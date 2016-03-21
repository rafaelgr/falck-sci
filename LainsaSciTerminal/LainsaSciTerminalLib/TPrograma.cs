using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TPrograma
    {
        private int programaId;

        public int ProgramaId
        {
            get { return programaId; }
            set { programaId = value; }
        }
        private DateTime fechaProgramada;

        public DateTime FechaProgramada
        {
            get { return fechaProgramada; }
            set { fechaProgramada = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
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
        private string nUsuario;

        public string NUsuario
        {
            get { return nUsuario; }
            set { nUsuario = value; }
        }
        private IList<TRevision> revisiones;

        public IList<TRevision> Revisiones
        {
            get { return revisiones; }
            set { revisiones = value; }
        }

        public TPrograma() { revisiones = new List<TRevision>(); }

        private string instalacion;

        public string NInstalacion
        {
            get 
            {
                return instalacion; 
            }
            set { instalacion = value; }
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
        public static void SetEstadoPrograma(TPrograma tp, SqlCeConnection conn)
        {
            int realizadas = 0;
            int totales = 0;
            foreach (TRevision tr in GetTRevisionesEstado(tp, conn))
            {
                totales++;
                if (tr.Estado == "REALIZADA") realizadas++;
            }
            if (realizadas == 0)
                tp.Estado = "SIN COMENZAR";
            else
            {
                if (realizadas < totales)
                    tp.Estado = "EN CURSO";
                else
                    tp.Estado = "FINALIZADA";
            }
            TSave(tp, conn);
        }
        public static TPrograma GetTProgramaC(int id, SqlCeConnection conn)
        {
            TPrograma programa = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT p.programa_id, p.fecha_programada, u.nombre, p.estado, p.comentarios, p.abm FROM Programa p LEFT JOIN usuario u on p.usuario_id = u.usuario_id WHERE programa_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    programa = new TPrograma()
                    {
                        ProgramaId = dr.GetInt32(0),
                        FechaProgramada = dr.GetDateTime(1),
                        NUsuario = dr.GetString(2),
                        Estado = dr.GetString(3),
                        Comentarios = dr.GetString(4),
                        Abm = dr.GetByte(5)
                    };
                }
                if (!dr.IsClosed) dr.Close();
                // Ahora NO buscamos las revisiones asociadas para evitar bucles.
                // o reducir el tiempo de carga
            }
            return programa;
        }
        public static TPrograma GetTPrograma(int id, SqlCeConnection conn)
        {
            TPrograma programa = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Programa WHERE programa_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    programa = new TPrograma()
                    {
                        ProgramaId = dr.GetInt32(0),
                        FechaProgramada = dr.GetDateTime(1),
                        Usuario = GetTUsuario(dr.GetInt32(2),conn),
                        Estado = dr.GetString(3),
                        Comentarios = dr.GetString(4),
                        Abm = dr.GetByte(5)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return programa;
        }
        public static void TSave(TPrograma tp, SqlCeConnection conn)
        {
            string sql = "";
           
            sql = @"UPDATE Programa SET estado='{1}, abm=3' WHERE programa_id={0}";
            
            sql = String.Format(sql, tp.ProgramaId, tp.Estado);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Devuelve todos los programas que figuran en la base de datos
        /// </summary>
        /// <param name="conn">Conector a la base de datos</param>
        /// <returns></returns>
        public static IList<TPrograma> GetTProgramas(SqlCeConnection conn)
        {
            IList<TPrograma> l = new List<TPrograma>();
            string sql = "SELECT * FROM Programa ORDER BY fecha_programada ASC";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrograma tp = GetTPrograma(dr.GetInt32(0), conn);
                    if (tp != null) l.Add(tp);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return l;
        }
        public static IList<TPrograma> GetTProgramasC(SqlCeConnection conn)
        {
            IList<TPrograma> l = new List<TPrograma>();
            string sql = "SELECT DISTINCT p.programa_id, p.fecha_programada, u.nombre, p.estado, p.comentarios, i.nombre, p.abm FROM Programa p LEFT JOIN usuario u on p.usuario_id = u.usuario_id LEFT JOIN Revision r ON p.programa_id = r.programa_id LEFT JOIN Dispositivo d ON r.dispositivo_id = d.dispositivo_id  LEFT JOIN Instalacion i ON d.instalacion = i.instalacion_id ORDER BY fecha_programada ASC";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrograma tp = new TPrograma()
                    {
                        ProgramaId = dr.GetInt32(0),
                        FechaProgramada = dr.GetDateTime(1),
                        NUsuario = dr.GetString(2),
                        Estado = dr.GetString(3),
                        Comentarios = dr.GetString(4),
                        NInstalacion = dr.GetString(5),
                        Abm = dr.GetByte(6)
                    };
                    if (tp != null) l.Add(tp);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return l;
        }
        public static IList<TPrograma> GetTProgramasC(int gtId, SqlCeConnection conn)
        {
            IList<TPrograma> l = new List<TPrograma>();
            string sql = String.Format("SELECT DISTINCT p.programa_id, p.fecha_programada, u.nombre, p.estado, p.comentarios, i.nombre, p.abm  FROM programa p LEFT JOIN USUARIO u ON u.usuario_id = p.usuario_id LEFT JOIN Revision r ON p.programa_id = r.programa_id LEFT JOIN Dispositivo d ON r.dispositivo_id = d.dispositivo_id  LEFT JOIN Instalacion i ON d.instalacion = i.instalacion_id WHERE u.grupo_trabajo_id = {0} ORDER BY fecha_programada ASC", gtId);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrograma tp = new TPrograma()
                    {
                        ProgramaId = dr.GetInt32(0),
                        FechaProgramada = dr.GetDateTime(1),
                        NUsuario = dr.GetString(2),
                        Estado = dr.GetString(3),
                        Comentarios = dr.GetString(4),
                        NInstalacion = dr.GetString(5),
                        Abm = dr.GetByte(6)
                    };
                    if (tp != null) 
                       l.Add(tp);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return l;
        }
    }
}
