using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Security.Cryptography;


namespace LainsaTerminalLib
{
    public static partial class CntSciTerminal
    {
        public static string filename;
        public static string GetMensajeText()
        {
            return @"\\Storage card\\lblMensaje.txt";
        }
        public static string GetPathDb()
        {
            return @"\\Storage card\\terminal.sdf";
        }
        public static void SetFileName(string name)
        {
            filename = name;
        }
        
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
        public static void TOpen(SqlCeConnection conn)
        {
            if(conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }
        public static SqlCeConnection TSqlConnection()
        {
            SqlCeConnection conn = null;
            //string connectionString = String.Format("Data source={0};Password =;Persist Security Info=True", pathDb);
            //string connectionString = "Data Source = \\Storage card\\busturistic.sdf;Password =aritel;Persist Security Info=True";
            //string connectionString = "Data Source = \\Storage card\\terminal.sdf;Password =;Persist Security Info=True";
            string connectionString = String.Format(@"Data Source = {0};Password =;Persist Security Info=True", filename);
            //string connectionString = "Data Source = C:\\Proyectos\\lainsa_sci\\LainsaSciTerminal\\LainsaSciTerminal\\24_28_03_2012.sdf;Password =;Persist Security Info=True";
            //string connectionString = "Data Source=C:\\ProyectosNet\\BasesDatos\\TerminalFalck\\terminal.sdf;Password =;Persist Security Info=True";
            
            conn = new SqlCeConnection(connectionString);
            return conn;
        }
        public static void TClose(SqlCeConnection conn)
        {
            if(conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }
        public static bool FechaNula(DateTime? fecha)
        {
            if (fecha == null) return true;
            string fc = String.Format("{0:dd/MM/yyyy}", fecha);
            if (fc == "01/01/0001") return true;
            return false;
            //if (fecha.ToString() == "01/01/0001 0:00:00" || fecha == null || fecha.ToString() == "1/1/01 12:00:00 AM")
            //    return true;
            //else
            //    return false;
        }
        public static TUsuario Login(string login, string password, SqlCeConnection conn)
        {
            // (1) Leemos el usuario al que pertenece ese login
            TUsuario u = GetTUsuarioLog(login, conn);
            // (1.1) Si no existe devolvemos nulo
            if (u == null) return null;
            // (2) Comprobamos si la contraseña coincide.
            if (u.Password == GetHashCode(password))
                return u; // (2.1) contraseña correcta
            else
                return null; // (2.2) contraseña incorrecta
        }
    }
     public class FileName
    {
        private string file;

        public string File
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
            }
        }
     }
}
