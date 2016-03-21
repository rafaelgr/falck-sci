using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LainsaSciModelo;
using LainsaTerminalLib;
using System.Data.SqlServerCe;


namespace LainsaConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- LAINSA CONSOLE TEST -- PULSA 'INTRO' PARA EMPEZAR");
            Console.ReadLine();

            using (LainsaSci ctx = new LainsaSci("LainsaSciCTX"))
            {
                //Empresa emp = CntLainsaSci.GetEmpresa(28, ctx);
                //ExportarTerminal(emp);
                Prueba(ctx);
            }

            Console.WriteLine("-- FIN PROGRAMA -- PULSA 'INTRO' PARA SALIR");
            Console.ReadLine();
        }
        public static void PruebaSerial() 
        {
            using (LainsaSci ctx = new LainsaSci("LainsaSciCTX"))
            {
                Programa p = CntLainsaSci.GetPrograma(100, ctx);
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
                x.Serialize(Console.Out, p);
                Console.WriteLine();
            }
        }
        public static void ExportarTerminal(Empresa empresa)
        {
            //C:\ProyectosNet\BasesDatos\TerminalFalck
            string pathCE = @"C:\ProyectosNet\BasesDatos\TerminalFalck\terminal.sdf";
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            SqlCeConnection conn = CntSciTerminal.TOpen(pathCE, "");
            // Ahora buscamos primero usuarios
            Console.WriteLine("Borrar todo lo anterior....");
            BorrarTodo(conn);
            Console.WriteLine("Cargar usuarios...");
            CargarUsuarios(empresa, conn, ctx);
            Console.WriteLine("Cargar tipos de anomalias...");
            CargarTipoAnomalias(conn, ctx);
            Console.WriteLine("Cargar dispositivos...");
            CargarDispositivos(empresa, conn, ctx);
            Console.WriteLine("Cargar programas...");
            CargarProgramas(empresa, conn, ctx);
            Console.WriteLine("Cargar otras revisiones...");
            CargarRevisionesPlanificadas(empresa, conn, ctx);
        }
        private static void BorrarTodo(SqlCeConnection conn)
        {
            int nrec = 0;
            string sql = "";

            using (SqlCeCommand cmd = conn.CreateCommand())
            {
                sql = "DELETE FROM DatosRevision";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Dispositivo";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Programa";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Revision";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Sustituciones";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Usuario";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
            }
        }
        private static void CargarUsuarios(Empresa empresa, SqlCeConnection conn, LainsaSci ctx) 
        {
            var rs = from u in ctx.Usuarios
                     where u.Empresa.EmpresaId == empresa.EmpresaId
                     select u;
            foreach (Usuario usu in rs) 
            {
                TUsuario tusu = new TUsuario()
                {
                    UsuarioId = usu.UsuarioId,
                    Nombre = usu.Nombre,
                    Login = usu.Login,
                    Password = usu.Password
                };
                CntSciTerminal.TSave(tusu, conn);
            }
        }
        private static void CargarDispositivos(Empresa empresa, SqlCeConnection conn, LainsaSci ctx)
        {
            var rs = from d in ctx.Dispositivos
                     where d.Instalacion.Empresa.EmpresaId == empresa.EmpresaId
                     select d;
            foreach (Dispositivo dsp in rs)
            {
                TDispositivo tdsp = new TDispositivo()
                {
                   DispositivoId = dsp.DispositivoId,
                   Nombre = dsp.Nombre,
                   Empresa = dsp.Instalacion.Empresa.Nombre,
                   Instalacion = dsp.Instalacion.Nombre,
                   Tipo = dsp.TipoDispositivo.Nombre,
                   Funcion = dsp.Funcion,
                   Estado = dsp.Estado,
                   FechaCaducidad = dsp.FechaCaducidad,
                   Caducado = dsp.Caducado,
                   FechaBaja = dsp.FechaBaja,
                   CodBarras = dsp.CodBarras
                };
                CntSciTerminal.TSave(tdsp, conn);
            }
        }
        private static void CargarProgramas(Empresa empresa, SqlCeConnection conn, LainsaSci ctx)
        {
            var rs = from p in ctx.Programas
                     where p.Estado != "FINALIZADA"
                     && p.Usuario.Empresa.EmpresaId == empresa.EmpresaId
                     select p;
            foreach (Programa p in rs)
            {
                TPrograma tp = new TPrograma()
                {
                    ProgramaId = p.ProgramaId,
                    Usuario = CntSciTerminal.GetTUsuario(p.Usuario.UsuarioId, conn),
                    Estado = p.Estado,
                    FechaProgramada = p.FechaProgramada,
                    Comentarios = p.Comentarios
                };
                CntSciTerminal.TSave(tp, conn);
                foreach (Revision r in p.Revisions)
                {
                    CargarRevision(r, conn, ctx);
                }
                foreach (Sustitucion s in p.Sustitucions)
                {
                    CargarSustitucion(s, conn, ctx);
                }
            }
        }
        private static void CargarTipoAnomalias(SqlCeConnection conn, LainsaSci ctx)
        {
            var rs = from ta in ctx.TipoAnomalias
                     select ta;
            foreach (TipoAnomalia ta in rs)
            {
                TTipoAnomalia tta = new TTipoAnomalia();
                tta.TipoAnomaliaId = ta.TipoAnomaliaId;
                tta.Nombre = ta.Nombre;
                CntSciTerminal.TSave(tta, conn);
            }

        }
        private static void CargarRevision(Revision r, SqlCeConnection conn, LainsaSci ctx)
        {
            TPrograma tpr = null;
            TUsuario tusu = null;
            if (r.Usuario != null) tusu = CntSciTerminal.GetTUsuario(r.Usuario.UsuarioId, conn);
            if (r.Programa != null) tpr =CntSciTerminal.GetTPrograma(r.Programa.ProgramaId, conn);
            TRevision tr = new TRevision()
            {
                RevisionId = r.RevisionId,
                Dispositivo = CntSciTerminal.GetTDispositivo(r.Dispositivo.DispositivoId, conn),
                Usuario = tusu,
                FechaPlanificada = r.FechaPlanificada,
                FechaProgramada = r.FechaProgramada,
                FechaRevision = r.FechaRevision,
                Resultado = r.Resultado,
                Comentario = r.Observaciones,
                Estado = r.Estado,
                TPrograma = tpr,
                Plantilla = r.PlantillaRevision.Descripcion
            };
            if (r.TipoAnomalia != null)
                tr.TTipoAnomalia = CntSciTerminal.GetTTipoAnomalia(r.TipoAnomalia.TipoAnomaliaId, conn);
            CntSciTerminal.TSave(tr, conn);
            foreach (DatosRevision dr in r.DatosRevisions)
            {
                CargarDatoRevision(dr, conn, ctx);
            }
        }
        private static void CargarDatoRevision(DatosRevision dr, SqlCeConnection conn, LainsaSci ctx)
        {
            TDatoRevision tdr = new TDatoRevision()
            {
                DatosId = dr.DatosId,
                TRevision = CntSciTerminal.GetTRevision(dr.Revision.RevisionId, conn),
                Valor = dr.Valor,
                Tipo = dr.Campo.TipoCampo.Descripcion,
                Posicion = dr.Campo.Posicion,
                Nombre = dr.Campo.Nombre
            };
            CntSciTerminal.TSave(tdr, conn);
        }
        private static void CargarRevisionesPlanificadas(Empresa empresa, SqlCeConnection conn, LainsaSci ctx)
        {
            var rs = from r in ctx.Revisions
                     where r.Dispositivo.Instalacion.Empresa.EmpresaId == empresa.EmpresaId
                     && r.Programa == null
                     select r;
            foreach (Revision r in rs)
            {
                CargarRevision(r, conn, ctx);
            }
        }
        private static void CargarSustitucion(Sustitucion s, SqlCeConnection conn, LainsaSci ctx)
        {
            TPrograma tpr = null;
            TUsuario tusu = null;
            TDispositivo tdispo = null;
            TDispositivo tdisps = null;
            if (s.Usuario != null) tusu = CntSciTerminal.GetTUsuario(s.Usuario.UsuarioId, conn);
            if (s.Programa != null) tpr = CntSciTerminal.GetTPrograma(s.Programa.ProgramaId, conn);
            if (s.DispositivoOriginal != null) tdispo = CntSciTerminal.GetTDispositivo(s.DispositivoOriginal.DispositivoId, conn);
            if (s.DispositivoSustituto != null) tdisps = CntSciTerminal.GetTDispositivo(s.DispositivoSustituto.DispositivoId, conn);
            TSustitucion ts = new TSustitucion()
            {
                SustitucionId=s.SustitucionId,
                Comentarios = s.Comentarios,
                Estado = s.Estado,
                TUsuario = tusu,
                TDispositivoOriginal = tdispo,
                TDispositivoSustituto = tdisps,
                TPrograma = tpr
            };
            CntSciTerminal.TSave(ts, conn);
        }

        private static void Prueba(LainsaSci ctx)
        {
            var rs = from r in ctx.Revisions
                     where r.PlantillaRevision.Facturable
                     select r;
            int c = rs.Count();
            foreach (var pr in rs)
            {
            }
        }
    }
}
