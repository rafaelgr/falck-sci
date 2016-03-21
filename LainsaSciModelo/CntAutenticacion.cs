using System.Security.Cryptography;
using System.Text;
using Telerik.OpenAccess;

namespace LainsaSciModelo
{
    public static class CntAutenticacion
    {
        #region Criptography
        public static string GetHashCode(string password)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            return ByteArrayToString(tmpHash);
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        #endregion Criptography
        #region Autenticacion
        public static Usuario Login(string login, string password, LainsaSci ctx)
        {
            // (1) Leemos el usuario al que pertenece ese login
            Usuario u = CntLainsaSci.GetUsuario(login, ctx);
            // (1.1) Si no existe devolvemos nulo
            if (u == null) return null;
            // (2) Comprobamos si la contraseña coincide.
            if (u.Password == GetHashCode(password))
                return u; // (2.1) contraseña correcta
            else
                return null; // (2.2) contraseña incorrecta
        }
        public static UsuarioExtranet LoginExtranet(string login, string password, LainsaSci ctx)
        {
            UsuarioExtranet uex = null;
            uex = CntLainsaSci.GetUsuarioExtranet(login, ctx);
            if (uex != null)
            {
                if (uex.Password != GetHashCode(password)) uex = null;
            }
            return uex;
        }
        #endregion
    }

    public static class CopyOfCntAutenticacion
    {
        #region Criptography
        public static string GetHashCode(string password)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            return ByteArrayToString(tmpHash);
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
        #endregion Criptography
        #region Autenticacion
        public static Usuario Login(string login, string password, LainsaSci ctx)
        {
            // (1) Leemos el usuario al que pertenece ese login
            Usuario u = CntLainsaSci.GetUsuario(login, ctx);
            // (1.1) Si no existe devolvemos nulo
            if (u == null) return null;
            // (2) Comprobamos si la contraseña coincide.
            if (u.Password == GetHashCode(password))
                return u; // (2.1) contraseña correcta
            else
                return null; // (2.2) contraseña incorrecta
        }
        #endregion
    }
}
