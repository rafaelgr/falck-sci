using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlServerCe;
using System.Text;

namespace LainsaTerminalLib
{
    public class TDatoRevision
    {
        private int datosId;

        public int DatosId
        {
            get { return datosId; }
            set { datosId = value; }
        }
        private string valor;

        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private int posicion;

        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        private TRevision tRevision;

        public TRevision TRevision
        {
            get { return tRevision; }
            set { tRevision = value; }
        }
    }
    public static partial class CntSciTerminal
    {
        public static TDatoRevision GetTDatoRevision(int id, SqlCeConnection conn)
        {
            TDatoRevision datoRevision = null;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM DatosRevision WHERE datos_id = {0}", id);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    datoRevision = new TDatoRevision()
                    {
                        DatosId = dr.GetInt32(0),
                        TRevision = GetTRevision(dr.GetInt32(1),conn),
                        Valor = dr.GetString(2),
                        Tipo = dr.GetString(3),
                        Posicion = dr.GetInt32(4)
                    };
                }
                if (!dr.IsClosed) dr.Close();
            }
            return datoRevision;
        }
        public static IList<TDatoRevision> GetTDatosRevision(TRevision revision, SqlCeConnection conn) 
        {
            IList<TDatoRevision> datosRevision = new List<TDatoRevision>();
            if (revision == null) return datosRevision;
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = String.Format("SELECT * FROM DatosRevision WHERE revision_id = {0} ORDER BY posicion", 
                    revision.RevisionId);
                SqlCeDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TDatoRevision datoRevision = new TDatoRevision()
                    {
                        DatosId = dr.GetInt32(0),
                        TRevision = GetTRevisionC(dr.GetInt32(1), conn),
                        Valor = dr.GetString(2),
                        Tipo = dr.GetString(3),
                        Posicion = dr.GetInt32(4)
                    };
                    datosRevision.Add(datoRevision);
                }
                if (!dr.IsClosed) dr.Close();
            }
            return datosRevision;
        }
        public static void TSave(TDatoRevision tdr, SqlCeConnection conn)
        {
            string sql = "";
            // primero verificamos que si el elemento está
            TDatoRevision ttdr = GetTDatoRevision(tdr.DatosId, conn);
            if (ttdr == null)
            {
                sql = @"INSERT INTO DatosRevision(datos_id, revision_id, valor, tipo, posicion) 
                        VALUES({0},{1},'{2}','{3}',{4})";
            }
            else
            {
                sql = @"UPDATE Programa SET 
                        revision_id={1},
                        valor='{2}',
                        tipo='{3}', 
                        posicion={4} 
                        WHERE datos_id={0}";
            }
            sql = String.Format(sql,tdr.DatosId, tdr.TRevision.RevisionId, tdr.Valor, tdr.Tipo, tdr.Posicion);
            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                int nrec = cmd.ExecuteNonQuery();
            }
        }
    }
}
