using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TGrupoTrabajo
    {
        private int grupoTrabajoId;

        public int GrupoTrabajoId
        {
            get { return grupoTrabajoId; }
            set { grupoTrabajoId = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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
        public static IList<TGrupoTrabajo> GetTGruposTrabajo(SqlCeConnection conn)
        {
            IList<TGrupoTrabajo> l = new List<TGrupoTrabajo>();
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Grupo_Trabajo");
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TGrupoTrabajo tusu = GetTGrupoTrabajo(dr.GetInt32(0), conn);
                    if (tusu != null) l.Add(tusu);
                }
            }
            return l;
        }
        public static TGrupoTrabajo GetTGrupoTrabajo(int id, SqlCeConnection conn)
        {
            TGrupoTrabajo grupo_trabajo = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM Grupo_Trabajo WHERE grupo_trabajo_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    grupo_trabajo = new TGrupoTrabajo()
                    {
                        GrupoTrabajoId= dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Abm = dr.GetByte(2)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return grupo_trabajo;
        }
        public static void TSave(TGrupoTrabajo gt, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TGrupoTrabajo gtst = GetTGrupoTrabajo(gt.GrupoTrabajoId, conn);
            byte abm = gtst.Abm;
            if (abm != 1) abm = 3;
            if (gtst == null)
            {
                sql = "INSERT INTO Grupo_Trabajo(grupo_trabajo_id, nombre, abm) VALUES({0},'{1}',1)";
            }
            else
            {
                sql = "UPDATE Grupo_Trabajo SET nombre='{1}', abm={2} WHERE grupo_trabajo_id={0}";
            }
            sql = String.Format(sql, gt.GrupoTrabajoId, gt.Nombre, abm);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}
