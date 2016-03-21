using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TUsuario
    {
        private int usuarioId;

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private TGrupoTrabajo tGrupoTrabajo;
        public TGrupoTrabajo TGrupoTrabajo
        {

            get
            {
                return tGrupoTrabajo;
            }
            set
            {
                tGrupoTrabajo = value;
            }
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
       public static IList<TUsuario> GetTUsuarios(SqlCeConnection conn)
        {
            IList<TUsuario> l = new List<TUsuario>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Usuario");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TUsuario tusu = GetTUsuario(dr.GetInt32(0), conn);
                    if (tusu != null) l.Add(tusu);
                }
            }
            return l;
        }
        public static TUsuario GetTUsuario(int id, SqlCeConnection conn)
        {
            TUsuario usuario = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Usuario WHERE usuario_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new TUsuario()
                    {
                        UsuarioId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Login = dr.GetString(2),
                        Password = dr.GetString(3),
                        Abm = dr.GetByte(5)
                    };
                    if (dr[4] != DBNull.Value)
                        usuario.TGrupoTrabajo = GetTGrupoTrabajo(dr.GetInt32(4), conn);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
        public static TUsuario GetTUsuario(string nombre, SqlCeConnection conn)
        {
            TUsuario usuario = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Usuario WHERE nombre = '{0}'", nombre);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new TUsuario()
                    {
                        UsuarioId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Login = dr.GetString(2),
                        Password = dr.GetString(3),
                        Abm = dr.GetByte(5)
                    };
                    if (dr[4] != DBNull.Value)
                        usuario.TGrupoTrabajo = GetTGrupoTrabajo(dr.GetInt32(4), conn);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
        public static TUsuario GetTUsuarioID(string nombre, SqlCeConnection conn)
        {
            TUsuario usuario = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT usuario_id, nombre, abm FROM Usuario WHERE nombre = '{0}'", nombre);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new TUsuario()
                    {
                        UsuarioId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
        public static TUsuario GetTUsuarioLog(string login, SqlCeConnection conn)
        {
            TUsuario usuario = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Usuario WHERE login = '{0}'", login);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new TUsuario()
                    {
                        UsuarioId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Login = dr.GetString(2),
                        Password = dr.GetString(3),
                        Abm = dr.GetByte(5)
                    };
                    if (dr[4] != DBNull.Value)
                        usuario.TGrupoTrabajo = GetTGrupoTrabajo(dr.GetInt32(4), conn);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
        public static void TSave(TUsuario tu, SqlCeConnection conn) 
        {
            int grupo_trabajo_id = 0;
            if (tu.TGrupoTrabajo != null) grupo_trabajo_id = tu.TGrupoTrabajo.GrupoTrabajoId;
            byte abm = tu.Abm;
            if (abm != 1) abm = 3;
            string sql = "";
            // primero verificamos que si el elemento está
            TUsuario tusu = GetTUsuario(tu.UsuarioId, conn);
            if (tusu == null)
            {
                sql = "INSERT INTO Usuario(usuario_id, nombre, login, password, grupo_trabajo_id, abm) VALUES({0},'{1}','{2}','{3}',{4},1)";
            }
            else
            {
                sql = "UPDATE Usuario SET nombre='{1}',login='{2}',password='{3}', grupo_trabajo_id={4}, abm={5} WHERE usuario_id={0}";
            }
            sql = String.Format(sql, tu.UsuarioId, tu.Nombre, tu.Login, tu.Password, grupo_trabajo_id, abm);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}
