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
        private int grupo_trabajo;

        public int Grupo_Trabajo
        {
            get { return grupo_trabajo; }
            set { grupo_trabajo = value; }
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
                        Grupo_Trabajo = dr.GetInt32(4),
                        Abm = dr.GetByte(5)
                    };
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
                        Grupo_Trabajo = dr.GetInt32(4),
                        Abm = dr.GetByte(5)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
        public static void TSave(TUsuario tu, SqlCeConnection conn) 
        {
            string sql = "";
            // primero verificamos que si el elemento está
           // TUsuario tusu = GetTUsuario(tu.UsuarioId, conn);
            TUsuario tusu = null;
            if (tusu == null)
            {
                sql = "INSERT INTO Usuario(usuario_id, nombre, login, password, grupo_trabajo_id) VALUES({0},'{1}','{2}','{3}',{4})";
            }
            else
            {
                sql = "UPDATE Usuario SET nombre='{1}',login='{2}',password='{3}', grupo_trabajo_id={4} WHERE usuario_id={0}";
            }
            int grupot = 0;
            if (tu.Grupo_Trabajo != 0)
               grupot = tu.Grupo_Trabajo;
            sql = String.Format(sql, tu.UsuarioId, tu.Nombre, tu.Login, tu.Password, grupot);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
        public static TUsuario Login(string login, string password, SqlCeConnection conn)
        {
            TUsuario usuario = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Usuarios WHERE login='{0}'", login);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = GetTUsuario(dr.GetInt32(0), conn);
                }
                if (usuario.Password != GetHashCode(password)) usuario = null;
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
    }
}
