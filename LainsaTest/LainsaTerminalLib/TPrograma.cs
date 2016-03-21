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
                instalacion = "";
                if (revisiones.Count > 0)
                {
                    TRevision tr = revisiones[0];
                    instalacion = tr.Dispositivo.Instalacion;
                }
                return instalacion; 
            }
        }
    }
    public static partial class CntSciTerminal 
    {
        public static void SetEstadoPrograma(TPrograma tp, SqlCeConnection conn)
        {
            int realizadas = 0;
            int totales = 0;
            foreach (TRevision tr in GetTRevisiones(tp,conn))
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
                cmd.CommandText = String.Format("SELECT * FROM Programa WHERE programa_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    programa = new TPrograma()
                    {
                        ProgramaId = dr.GetInt32(0),
                        FechaProgramada = dr.GetDateTime(1),
                        Usuario = GetTUsuario(dr.GetInt32(2), conn),
                        Estado = dr.GetString(3),
                        Comentarios = dr.GetString(4)
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
                        Comentarios = dr.GetString(4)
                    };
                }
                if (!dr.IsClosed) dr.Close();
                if (programa != null)
                {
                    // Ahora buscamos las revisiones asociadas.
                    cmd.CommandText = String.Format("SELECT * FROM Revision WHERE programa_id = {0}", programa.ProgramaId);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TRevision tr = CntSciTerminal.GetTRevision(dr.GetInt32(0), conn);
                        if (tr != null) programa.Revisiones.Add(tr);
                    }
                    if (!dr.IsClosed) dr.Close();
                }
            }
            return programa;
        }
        public static void TSave(TPrograma tp, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TPrograma ttp = GetTPrograma(tp.ProgramaId, conn);
            if (ttp == null)
            {
                sql = @"INSERT INTO Programa(programa_id, usuario_id, estado, comentarios, fecha_programada) VALUES({0},{1},'{2}','{3}','{4:yyyy-MM-dd}')";
            }
            else
            {
                sql = @"UPDATE Programa SET usuario_id={1},estado='{2}',comentarios='{3}', fecha_programada='{4:yyyy-MM-dd}' WHERE programa_id={0}";
            }
            sql = String.Format(sql,tp.ProgramaId,tp.Usuario.UsuarioId,tp.Estado,tp.Comentarios,tp.FechaProgramada);
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
            string sql = "SELECT * FROM Programa";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrograma tp = GetTPrograma(dr.GetInt32(0), conn);
                    if (tp != null) l.Add(tp);
                }
            }
            return l;
        }
        public static IList<TPrograma> GetTProgramasC(SqlCeConnection conn)
        {
            IList<TPrograma> l = new List<TPrograma>();
            string sql = "SELECT * FROM Programa";
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TPrograma tp = GetTProgramaC(dr.GetInt32(0), conn);
                    if (tp != null) l.Add(tp);
                }
            }
            return l;
        }
    }
}
