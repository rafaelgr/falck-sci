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
        public static string GetPathDb()
        {
            return @"\\Storage card\\terminal.sdf";
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
        public static SqlCeConnection TOpen(string pathDb, string password)
        {
            SqlCeConnection conn = null;
            //string connectionString = String.Format("Data source={0};Password =;Persist Security Info=True", pathDb);
            //string connectionString = "Data Source = \\Storage card\\busturistic.sdf;Password =aritel;Persist Security Info=True";
            //string connectionString = "Data Source = \\Storage card\\terminal.sdf;Password =;Persist Security Info=True";
            string connectionString = "Data Source=C:\\ProyectosNet\\BasesDatos\\TerminalFalck\\terminal.sdf;Password =;Persist Security Info=True";

            conn = new SqlCeConnection(connectionString);
            conn.Open();
            return conn;
        }
        public static void TClose(SqlCeConnection conn)
        {
            conn.Close();
        }
        public static bool FechaNula(DateTime fecha)
        {
            if (fecha.ToString() == "01/01/0001 0:00:00" || fecha == null)
                return true;
            else
                return false;
        }
    }
}
