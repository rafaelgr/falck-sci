using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class Usuario
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
    }
    public static partial class CntSciTerminal
    {
        public static Usuario GetUsuario(int id, SqlCeConnection conn)
        {
            Usuario usuario = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Usuario WHERE usuario_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario = new Usuario()
                    {
                        UsuarioId = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Login = dr.GetString(2),
                        Password = dr.GetString(3)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return usuario;
        }
    }
}
