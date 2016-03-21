using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace LainsaTerminalLib
{
    public class TGrupoTrabajo
    {
        private int grupo_trabajo_id;

        public int Grupo_trabajo_id
        {
            get { return grupo_trabajo_id; }
            set { grupo_trabajo_id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
    public static partial class CntSciTerminal
    {
        public static IList<TGrupoTrabajo> GetTGruposTrabajo(SqlCeConnection conn)
        {
            IList<TGrupoTrabajo> l = new List<TGrupoTrabajo>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Grupo_Trabajo");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TGrupoTrabajo tusu = GetGrupoTrabajo(dr.GetInt32(0), conn);
                    if (tusu != null) l.Add(tusu);
                }
            }
            return l;
        }
        public static TGrupoTrabajo GetGrupoTrabajo(int id, SqlCeConnection conn)
        {
            TGrupoTrabajo grupot = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Grupo_Trabajo WHERE grupo_trabajo_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    grupot = new TGrupoTrabajo()
                    {
                        Grupo_trabajo_id = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
                       };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return grupot;
        }
        public static void TSave(TGrupoTrabajo tu, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TGrupoTrabajo tusu = GetGrupoTrabajo(tu.Grupo_trabajo_id, conn);
            if (tusu == null)
            {
                sql = "INSERT INTO Grupo_Trabajo(grupo_trabajo_id, nombre) VALUES({0},'{1}','{2}','{3}',{4})";
            }
            else
            {
                sql = "UPDATE Grupo_Trabajo SET nombre='{1}' WHERE grupo_trabajo_id={0}";
            }
            sql = String.Format(sql, tu.Grupo_trabajo_id, tu.Nombre);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
     }
}
