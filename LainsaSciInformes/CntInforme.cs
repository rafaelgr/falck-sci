using System;
using System.Collections.Generic;
using System.Linq;
using LainsaSciModelo;
using System.Text;

namespace LainsaSciInformes
{
    public static partial class CntInforme
    {
        public static IList<ConsultaRevision> GetConsultaRevisiones(IList<Revision> revisiones, string consulta)
        {
            IList<ConsultaRevision> l = new List<ConsultaRevision>();
            foreach (Revision r in revisiones)
            {
                ConsultaRevision cr = new ConsultaRevision();
                cr.Id = r.RevisionId;
                cr.Dispositivo = r.Dispositivo.Nombre;
                cr.NumIndustria = r.Dispositivo.NumeroIndustria;
                if (r.Dispositivo.TipoDispositivo != null)
                    cr.Tipo = r.Dispositivo.TipoDispositivo.Nombre;
                if (r.Dispositivo.ModeloDispositivo != null)
                    cr.Modelo = r.Dispositivo.ModeloDispositivo.Nombre;
                if (r.PlantillaRevision != null)
                    cr.Plantilla = r.PlantillaRevision.Descripcion;
                cr.Empresa = r.Dispositivo.Instalacion.Empresa.Nombre;
                cr.Instalacion = r.Dispositivo.Instalacion.Nombre;
                if (!CntLainsaSci.FechaNula(r.FechaPlanificada))
                    cr.FechaPlanificada = String.Format("{0:dd/MM/yy}", r.FechaPlanificada);
                if (!CntLainsaSci.FechaNula(r.FechaProgramada))
                    cr.FechaProgramada = String.Format("{0:dd/MM/yy}", r.FechaProgramada);
                if (!CntLainsaSci.FechaNula(r.FechaRevision))
                    cr.FechaRevision = String.Format("{0:dd/MM/yy}", r.FechaRevision);
                cr.Resultado = r.Resultado;
                cr.Estado = r.Estado;
                //-> Consulta original
                cr.Consulta = consulta;
                //-> Resultado
                cr.Resumen = ResumenRevision(r);
                l.Add(cr);
            }
            return l;
        }
        public static string ResumenRevision(Revision r)
        {
            string resumen = "";
            foreach (DatosRevision dr in r.DatosRevisions)
            {
                resumen = String.Format(resumen + "<b>{0}</b> <i><b>R:</b>{1} <b>C:</b>{2}</i><br/>", 
                    dr.Campo.Nombre, 
                    CntLainsaSci.GetValorCampo(dr.Valor), 
                    CntLainsaSci.GetComentarioCampo(dr.Valor));
            }
            resumen = resumen.Replace('&', ' ');
            resumen = resumen + "<br/>";
            return resumen;
        }

        public static IList<InformePlanta> GetInformePlanta(Programa p)
        {
            IList<InformePlanta> l = new List<InformePlanta>();
            var rs = (from rev in p.Revisions
                      orderby rev.PlantillaRevision.PlantillaId, rev.Dispositivo.Nombre
                      select rev);
            // p.Revisions.OrderBy(x => x.PlantillaRevision.PlantillaId)
            foreach (Revision r in rs)
            {
                // montar el objeto informe de cada revisión
                InformePlanta infpl = new InformePlanta();
                infpl.Plantilla = r.PlantillaRevision.Descripcion;
                infpl.Empresa = r.Dispositivo.Instalacion.Empresa.Nombre;
                infpl.Instalacion = r.Dispositivo.Instalacion.Nombre;
                infpl.Nombre = r.Dispositivo.Nombre;
                infpl.Ubicacion = r.Dispositivo.Posicion;
               
                if (r.Dispositivo.TipoDispositivo != null)
                    infpl.Tipo = r.Dispositivo.TipoDispositivo.Nombre;
                infpl.NIndustria = r.Dispositivo.NumeroIndustria;
                if (r.Dispositivo.ModeloDispositivo != null)
                    infpl.Modelo = r.Dispositivo.ModeloDispositivo.Nombre;
                if (!CntLainsaSci.FechaNula(r.Dispositivo.FechaFabricacion))
                    infpl.Fabricado = String.Format("{0:MM/yy}",r.Dispositivo.FechaFabricacion);
                DateTime? ufecha = GetUltimaQuinquenal(r.Dispositivo);
                if (!CntLainsaSci.FechaNula(ufecha)) infpl.UltQuinquenal = String.Format("{0:MM/yy}",(DateTime)ufecha);
                
                // montaje de la pregunta para mostrar como HTML
                foreach (Campo cmp in r.PlantillaRevision.Campos)
                {
                    infpl.Preguntas = String.Format(infpl.Preguntas + "<b> {0} - {1} </b><br/>", cmp.Posicion, cmp.Nombre);
                }
                l.Add(infpl);
            }
            return l;
        }

        public static DateTime? GetUltimaQuinquenal(Dispositivo disp)
        {
            DateTime? ufecha = null;
            // lo primero es buscar si entre las plantillas
            PlantillaRevision pl = (from p in disp.TipoDispositivo.PlantillaRevisions
                            where p.TipoPeriodo == "A" && p.NumeroPeriodos == 5
                            select p).FirstOrDefault<PlantillaRevision>();
            if (pl != null)
            {
                Revision rev = (from r in disp.Revisiones
                                orderby r.FechaRevision descending
                                where r.PlantillaRevision.PlantillaId == pl.PlantillaId
                                select r).FirstOrDefault<Revision>();
                if (rev != null)
                    if (!CntLainsaSci.FechaNula(rev.FechaRevision))
                        return rev.FechaRevision;
                
                // en esta situación usamos la fecha del resumen
                ResumenRevision rere = (from rr in disp.ResumenesRevisones
                                        where rr.PlantillaRevision.PlantillaId == pl.PlantillaId
                                        select rr).FirstOrDefault<ResumenRevision>();
                if (rere != null)
                    ufecha = rere.FechaUltima;
            }
            return ufecha;
        }

        public static IList<InformeDispositivo> GetInformeDispositivo(List<string> dispositivos, string consulta)
        {
            IList<InformeDispositivo> l = new List<InformeDispositivo>();
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            foreach(string id in dispositivos)
            {
                Dispositivo d = CntLainsaSci.GetDispositivo(int.Parse(id), ctx);
                InformeDispositivo infd = new InformeDispositivo();
               
                infd.Cliente = d.Instalacion.Empresa.Nombre;
                infd.Dispositivo = d.Nombre;
                if (!CntLainsaSci.FechaNula(d.FechaCaducidad))
                    infd.Fecha_cad = String.Format("{0:dd/MM/yy}", d.FechaCaducidad); 
                infd.Industria = d.NumeroIndustria;
                infd.Instalacion = d.Instalacion.Nombre;
                infd.Posicion = d.Posicion;
                infd.Operativo = d.Operativo.ToString();
                if (d.TipoDispositivo != null)
                    infd.Tipo_disp = d.TipoDispositivo.Nombre;
                infd.ID = d.DispositivoId.ToString();
                if(d.ModeloDispositivo != null)
                    infd.Modelo = d.ModeloDispositivo.Nombre;
                infd.Observaciones = d.Comentarios;
                infd.Consulta = consulta;
                
                l.Add(infd);
            }
            return l;
        }

        public static IList<InformeResumenRevision> GetInformeResumenRevision(string dispositivo)
        {
            IList<InformeResumenRevision> l = new List<InformeResumenRevision>();
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            Dispositivo d = CntLainsaSci.GetDispositivo(int.Parse(dispositivo), ctx);
          
            foreach (ResumenRevision rr in d.ResumenesRevisones)
            {
                InformeResumenRevision infr = new InformeResumenRevision();
                infr.Dispositivo = rr.Dispositivo.DispositivoId.ToString();
                if(rr.PlantillaRevision != null)
                    infr.Plantilla = rr.PlantillaRevision.Descripcion;
                if (!CntLainsaSci.FechaNula(rr.FechaUltima))
                    infr.Fecha_ultima = String.Format("{0:dd/MM/yy}", rr.FechaUltima);
                if (!CntLainsaSci.FechaNula(rr.FechaSiguiente))
                    infr.Fecha_siguiente = String.Format("{0:dd/MM/yy}", rr.FechaSiguiente);

                l.Add(infr);
            }
            return l;
        }

        public static IList<InformeRevision> GetInformeRevisionesDispositivo(string dispositivo)
        {
            IList<InformeRevision> l = new List<InformeRevision>();
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            Dispositivo d = CntLainsaSci.GetDispositivo(int.Parse(dispositivo), ctx);

            foreach (Revision r in d.Revisiones)
            {
                InformeRevision infr = new InformeRevision();
                infr.ID = r.RevisionId.ToString();
                if (r.PlantillaRevision != null)
                infr.Plantilla = r.PlantillaRevision.Descripcion;
                if (!CntLainsaSci.FechaNula(r.FechaPlanificada))
                    infr.Fecha_plan = String.Format("{0:dd/MM/yy}", r.FechaPlanificada);
                if (!CntLainsaSci.FechaNula(r.FechaProgramada))
                    infr.Fecha_progr = String.Format("{0:dd/MM/yy}", r.FechaProgramada);
                if (!CntLainsaSci.FechaNula(r.FechaRevision))
                    infr.Fecha_rev = String.Format("{0:dd/MM/yy}", r.FechaRevision);
                infr.Resultado = r.Resultado;

                l.Add(infr);
            }
            return l;
        }

        public static IList<InformeRevision> GetInformeRevision(List<string> revisiones)
        {
            IList<InformeRevision> l = new List<InformeRevision>();
            LainsaSci ctx = new LainsaSci("LainsaSciCTX");
            foreach (string id in revisiones)
            {
                Revision r = CntLainsaSci.GetRevision(int.Parse(id), ctx);
                InformeRevision infr = new InformeRevision();
                
                infr.Dispositivo = r.Dispositivo.Nombre;
                infr.Empresa = r.Dispositivo.Instalacion.Empresa.Nombre;
                infr.Estado = r.Estado;
                if (!CntLainsaSci.FechaNula(r.FechaPlanificada))
                    infr.Fecha_plan = String.Format("{0:dd/MM/yy}", r.FechaPlanificada);
                if(!CntLainsaSci.FechaNula(r.FechaProgramada))
                    infr.Fecha_progr = string.Format("{0:dd/MM/yy}", r.FechaProgramada);
                if(!CntLainsaSci.FechaNula(r.FechaRevision))
                    infr.Fecha_rev = string.Format("{0:dd/MM/yy}", r.FechaRevision);
                infr.ID = r.RevisionId.ToString();
                infr.Industria = r.Dispositivo.NumeroIndustria;
                infr.Instalacion = r.Dispositivo.Instalacion.Nombre;
                if(r.Dispositivo.ModeloDispositivo != null)
                    infr.Modelo = r.Dispositivo.ModeloDispositivo.Nombre;
                if(r.PlantillaRevision != null)
                    infr.Plantilla = r.PlantillaRevision.Descripcion;
                infr.Resultado = r.Resultado;
                if(r.Dispositivo.TipoDispositivo != null)
                    infr.Tipo = r.Dispositivo.TipoDispositivo.Nombre;

                l.Add(infr);
            }
            return l;
        }

        public static IList<RevView> GetRevViews(Programa p)
        {
            int i = 1;
            int i2 = 1;
            int pid = 0;
            int grupo = 0;
            IList<Revision> lr = new List<Revision>();
            IList<RevView> l = new List<RevView>();
            foreach (Revision r in p.Revisions.OrderBy(x => x.PlantillaRevision.PlantillaId))
            {
                // Cambio de plantilla o más de 6 elementos
                if (i > 6 || pid != r.PlantillaRevision.PlantillaId)
                {

                    if (lr.Count > 0)
                    {
                        grupo++; 
                        IList<RevView> lr2 = new List<RevView>();
                        bool primero = true;
                        i2 = 1;
                        foreach (Revision r2 in lr)
                        {
                            // Comenzamos por crear todos los RevView de este grupo
                            // siempre son iguales al número de preguntas de la plantilla
                            // o de datos de las respuestas de una revisión
                            if (primero)
                                lr2 = MontajeInicial(r2, p, grupo);
                            // Ahora buscamos acomodar la respuestas de este dispositivo particular
                            CargaRevision(r2, lr2, i2);
                            // y a por otro
                            i2++;
                            primero = false;
                        }
                        // Ahora pasamos el grupo a la prinicipal
                        foreach (RevView r3 in lr2)
                        {
                            l.Add(r3);
                        }
                        lr = new List<Revision>();
                        i = 0;
                    }
                }
                pid = r.PlantillaRevision.PlantillaId; 
                lr.Add(r);
                // Incrementar para el siguiente
                i++;
            }
            if (lr.Count > 0)
            {
                grupo++;
                IList<RevView> lr2 = new List<RevView>();
                bool primero = true;
                i2 = 1;
                foreach (Revision r2 in lr)
                {
                    // Comenzamos por crear todos los RevView de este grupo
                    // siempre son iguales al número de preguntas de la plantilla
                    // o de datos de las respuestas de una revisión
                    if (primero)
                        lr2 = MontajeInicial(r2, p, grupo);
                    // Ahora buscamos acomodar la respuestas de este dispositivo particular
                    CargaRevision(r2, lr2, i2);
                    // y a por otro
                    i2++;
                    primero = false;
                }
                // Ahora pasamos el grupo a la prinicipal
                foreach (RevView r3 in lr2)
                {
                    l.Add(r3);
                }
                lr = new List<Revision>();
                i = 0;
            }
            return l;
        }

        private static IList<RevView> MontajeInicial(Revision r, Programa p, int g)
        {
            string norma = "EMPRESA INSTALADORA Y MANTENEDORA DE INSTALACIONES CONTRA INCENDIOS D.R. A-46205431";
            IList<RevView> l2 = new List<RevView>();
            foreach (DatosRevision dr in r.DatosRevisions.OrderBy(x => x.Campo.Posicion))
            {
                RevView rev = new RevView();
                rev.Empresa = r.Dispositivo.Instalacion.Empresa.Nombre;
                rev.Instalacion = r.Dispositivo.Instalacion.Nombre;
                rev.Normativa = norma;
                rev.Plantilla = r.PlantillaRevision.Descripcion;
                rev.Fecha = p.FechaProgramada;
                rev.Usuario = p.Usuario.Nombre;
                rev.Observaciones = p.Comentarios;
                rev.Pregunta = dr.Campo.Nombre;
                rev.Grupo = g;
                l2.Add(rev);
            }
            // ahora hay que añadir dos campos más: Resultado y Observaciones
            if (l2.Count > 0)
            {
                RevView rev = new RevView();
                rev.Empresa = r.Dispositivo.Instalacion.Empresa.Nombre;
                rev.Instalacion = r.Dispositivo.Instalacion.Nombre;
                rev.Normativa = norma;
                rev.Plantilla = r.PlantillaRevision.Descripcion;
                rev.Fecha = p.FechaProgramada;
                rev.Usuario = p.Usuario.Nombre;
                rev.Observaciones = p.Comentarios;
                rev.Pregunta = "RESULTADO";
                rev.Grupo = g;
                l2.Add(rev);
                //
                rev = new RevView();
                rev.Empresa = r.Dispositivo.Instalacion.Empresa.Nombre;
                rev.Instalacion = r.Dispositivo.Instalacion.Nombre;
                rev.Normativa = norma;
                rev.Plantilla = r.PlantillaRevision.Descripcion;
                rev.Fecha = p.FechaProgramada;
                rev.Usuario = p.Usuario.Nombre;
                rev.Observaciones = p.Comentarios;
                rev.Pregunta = "OBSERVACIONES";
                rev.Grupo = g;
                l2.Add(rev);
            }
            return l2;
        }

        private static void CargaRevision(Revision r, IList<RevView> l, int pos)
        {
            RevView rev;
            foreach (DatosRevision dr in r.DatosRevisions)
            {
                rev = (from rv in l where rv.Pregunta == dr.Campo.Nombre select rv).FirstOrDefault<RevView>();
                CargarDato(rev, r.Dispositivo.Nombre, ValorEnInforme(dr.Valor), pos);
            }
            // Y ahora hay que hacer los mismo para RESULTADO y OBSERVACIONES
            rev = (from rv in l where rv.Pregunta == "RESULTADO" select rv).FirstOrDefault<RevView>();
            CargarDato(rev, r.Dispositivo.Nombre, r.Resultado, pos);
            rev = (from rv in l where rv.Pregunta == "OBSERVACIONES" select rv).FirstOrDefault<RevView>();
            CargarDato(rev, r.Dispositivo.Nombre, r.Observaciones, pos);
        }

        private static void CargarDato(RevView rev, string nombre, string valor, int pos)
        {
            if (rev != null)
            {
                switch (pos)
                {
                    case 1:
                        rev.D1 = nombre;
                        rev.R1 = valor;
                        break;
                    case 2:
                        rev.D2 = nombre;
                        rev.R2 = valor;
                        break;
                    case 3:
                        rev.D3 = nombre;
                        rev.R3 = valor;
                        break;
                    case 4:
                        rev.D4 = nombre;
                        rev.R4 = valor;
                        break;
                    case 5:
                        rev.D5 = nombre;
                        rev.R5 = valor;
                        break;
                    case 6:
                        rev.D6 = nombre;
                        rev.R6 = valor;
                        break;
                }
            }
        }

        private static string ValorEnInforme(string valor)
        {
            string res = "";
            if (valor == null)
                return "";
            // Tiene dos campos
            int pos1 = valor.IndexOf("|");
            if (pos1 < 0)
                return "";
            string c1 = valor.Substring(0, pos1);
            string c2 = valor.Substring(pos1 + 1, valor.Length - (pos1 + 1));
            if (c1 == "True" || c1 == "S")
                c1 = "OK";
            if (c1 == "False" || c1 == "N")
                c1 = "MAL";
            res = String.Format("<b>R: </b>{0}<br/><b>C: </b>{1}", c1, c2);
            return res;
        }

        public static IList<ResEmpresaInstalacionView> GetEmpresaInstalacionView(DateTime desdeFecha, DateTime hastaFecha, Empresa empresa, Instalacion inst, bool facturable, LainsaSci ctx)
        {
            int nrt = 0;
            int nra = 0;
            int nba = 0;
            int nca = 0;
            int nrti = nrt;
            int nrai = nra;
            int nbai = nba;
            int ncai = nca;
            // creamos la lista a devolver
            IList<ResEmpresaInstalacionView> l = new List<ResEmpresaInstalacionView>();
            if (inst == null)
            {
               foreach (Instalacion instalacion in empresa.Instalaciones.OrderBy(x => x.Nombre))
                {
                    // cada bucle crea un objeto
                    ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                    {
                        Empresa = empresa.Nombre,
                        Instalacion = instalacion.Nombre,
                        InstalacionId = instalacion.InstalacionId,
                    };
                    // calculamos los valores para esta instalacion
                    nrti = NumeroRevisionesInstalacion(desdeFecha, hastaFecha, instalacion, facturable, ctx);
                    nrai = NumeroRevisionesInstalacionConAnomalia(desdeFecha, hastaFecha, instalacion, ctx);
                    nbai = NumeroBajasInstalacion(desdeFecha, hastaFecha, instalacion, ctx);
                    ncai = NumeroCambiosInstalacion(desdeFecha, hastaFecha, instalacion, ctx);
                    nrt += nrti;
                    nra += nrai;
                    nba += nbai;
                    nca += ncai;
                    reiW.DesdeFecha = desdeFecha;
                    reiW.HastaFecha = hastaFecha;
                    reiW.Nrti = nrti;
                    reiW.Nrai = nrai;
                    reiW.Nbai = nbai;
                    reiW.Ncai = ncai;
                    // lo agregamos a la lista
                    l.Add(reiW);
                }
            }
            else 
            {
                ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                {
                    Empresa = empresa.Nombre,
                    Instalacion = inst.Nombre,
                    InstalacionId = inst.InstalacionId,
                };
                // calculamos los valores para esta instalacion
                nrti = NumeroRevisionesInstalacion(desdeFecha, hastaFecha, inst, facturable, ctx);
                nrai = NumeroRevisionesInstalacionConAnomalia(desdeFecha, hastaFecha, inst, ctx);
                nbai = NumeroBajasInstalacion(desdeFecha, hastaFecha, inst, ctx);
                ncai = NumeroCambiosInstalacion(desdeFecha, hastaFecha, inst,  ctx);
                nrt += nrti;
                nra += nrai;
                nba += nbai;
                nca += ncai;
                reiW.DesdeFecha = desdeFecha;
                reiW.HastaFecha = hastaFecha;
                reiW.Nrti = nrti;
                reiW.Nrai = nrai;
                reiW.Nbai = nbai;
                reiW.Ncai = ncai;
                // lo agregamos a la lista
                l.Add(reiW);
                }
            // montanos los totales
            foreach (ResEmpresaInstalacionView reiW in l)
            {
                reiW.Nrt = nrt;
                reiW.Nra = nra;
                reiW.Nba = nba;
                reiW.Nca = nca;
            }
            return l;
        }

        public static IList<ResEmpresaInstalacionView> GetEmpresaTipoView(DateTime desdeFecha, DateTime hastaFecha, Empresa empresa, TipoDispositivo tipo, bool facturable, LainsaSci ctx)
        {
            int nrt = 0;
            int nra = 0;
            int nba = 0;
            int nca = 0;
            int nrti = nrt;
            int nrai = nra;
            int nbai = nba;
            int ncai = nca;
            // creamos la lista a devolver
            IList<ResEmpresaInstalacionView> l = new List<ResEmpresaInstalacionView>();
          
            if (tipo == null)
            {
                foreach (TipoDispositivo t in empresa.TipoDispositivos.OrderBy(x => x.Nombre))
                {
                    // cada bucle crea un objeto
                    ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                    {
                        Empresa = empresa.Nombre,
                        T_disp = t.Nombre,
                        TipoId = t.TipoId,
                    };
                 
                    // calculamos los valores para esta instalacion
                    nrti = NumeroRevisionesTipo(desdeFecha, hastaFecha, t, facturable, ctx);
                    nrai = NumeroRevisionesTipoConAnomalia(desdeFecha, hastaFecha, t, ctx);
                    nbai = NumeroBajasTipo(desdeFecha, hastaFecha, t, ctx);
                    ncai = NumeroCambiosTipo(desdeFecha, hastaFecha, t, ctx);
                    nrt += nrti;
                    nra += nrai;
                    nba += nbai;
                    nca += ncai;
                    reiW.DesdeFecha = desdeFecha;
                    reiW.HastaFecha = hastaFecha;
                    reiW.Nrti = nrti;
                    reiW.Nrai = nrai;
                    reiW.Nbai = nbai;
                    reiW.Ncai = ncai;
                    // lo agregamos a la lista
                    l.Add(reiW);
                }
            }
            else
            {
                ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                {
                    Empresa = empresa.Nombre,
                    T_disp = tipo.Nombre,
                    TipoId = tipo.TipoId,
                };
                // calculamos los valores para este tipo de dispositivo
                nrti = NumeroRevisionesTipo(desdeFecha, hastaFecha, tipo, facturable, ctx);
                nrai = NumeroRevisionesTipoConAnomalia(desdeFecha, hastaFecha, tipo, ctx);
                nbai = NumeroBajasTipo(desdeFecha, hastaFecha, tipo, ctx);
                ncai = NumeroCambiosTipo(desdeFecha, hastaFecha, tipo, ctx);
                nrt += nrti;
                nra += nrai;
                nba += nbai;
                nca += ncai;
                reiW.DesdeFecha = desdeFecha;
                reiW.HastaFecha = hastaFecha;
                reiW.Nrti = nrti;
                reiW.Nrai = nrai;
                reiW.Nbai = nbai;
                reiW.Ncai = ncai;
                // lo agregamos a la lista
                l.Add(reiW);
            }
            // montanos los totales
            foreach (ResEmpresaInstalacionView reiW in l)
            {
                reiW.Nrt = nrt;
                reiW.Nra = nra;
                reiW.Nba = nba;
                reiW.Nca = nca;
            }
            return l;
        }

        public static IList<ResEmpresaInstalacionView> GetEmpresaView(DateTime desdeFecha, DateTime hastaFecha, Empresa empresa, Instalacion instalacion, TipoDispositivo tipo, bool facturable, LainsaSci ctx)
        {
            int nrt = 0;
            int nra = 0;
            int nba = 0;
            int nca = 0;
            int nrti = nrt;
            int nrai = nra;
            int nbai = nba;
            int ncai = nca;
            List<TipoDispositivo> tipos_dispositivo = new List<TipoDispositivo>();
            // creamos la lista a devolver
            IList<ResEmpresaInstalacionView> l = new List<ResEmpresaInstalacionView>();
            if (instalacion == null)
            {
                foreach (Instalacion inst in empresa.Instalaciones.OrderBy(x => x.Nombre))
                {
                    if (tipo == null)
                    {
                         tipos_dispositivo.Clear();
                         foreach (Dispositivo disp in inst.Dispositivos.OrderBy(x => x.TipoDispositivo.Nombre))
                         {
                             if(!tipos_dispositivo.Contains(disp.TipoDispositivo))
                             {
                                 TipoDispositivo t = disp.TipoDispositivo;
                                 tipos_dispositivo.Add(t);
                                // cada bucle crea un objeto
                                ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                                {
                                    Empresa = empresa.Nombre,
                                    T_disp = t.Nombre,
                                    TipoId = t.TipoId,
                                    Instalacion = inst.Nombre,
                                    InstalacionId = inst.InstalacionId,
                                };
                            
                                // calculamos los valores para esta instalacion
                                nrti = NumeroRevisiones(desdeFecha, hastaFecha, inst, t, facturable, ctx);
                                nrai = NumeroRevisionesConAnomalia(desdeFecha, hastaFecha, inst, t, ctx);
                                nbai = NumeroBajas(desdeFecha, hastaFecha, inst, t, ctx);
                                ncai = NumeroCambios(desdeFecha, hastaFecha, inst, t, ctx);
                                nrt += nrti;
                                nra += nrai;
                                nba += nbai;
                                nca += ncai;
                                reiW.DesdeFecha = desdeFecha;
                                reiW.HastaFecha = hastaFecha;
                                reiW.Nrti = nrti;
                                reiW.Nrai = nrai;
                                reiW.Nbai = nbai;
                                reiW.Ncai = ncai;
                                // lo agregamos a la lista
                                l.Add(reiW);
                             }
                        }
                    }
                    else
                    {
                        ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                        {
                            Empresa = empresa.Nombre,
                            T_disp = tipo.Nombre,
                            TipoId = tipo.TipoId,
                            Instalacion = inst.Nombre,
                            InstalacionId = inst.InstalacionId,
                        };
                        // calculamos los valores para este tipo de dispositivo
                        nrti = NumeroRevisiones(desdeFecha, hastaFecha, inst, tipo, facturable, ctx);
                        nrai = NumeroRevisionesConAnomalia(desdeFecha, hastaFecha, inst, tipo, ctx);
                        nbai = NumeroBajas(desdeFecha, hastaFecha, inst, tipo, ctx);
                        ncai = NumeroCambios(desdeFecha, hastaFecha, inst, tipo, ctx);
                        nrt += nrti;
                        nra += nrai;
                        nba += nbai;
                        nca += ncai;
                        reiW.DesdeFecha = desdeFecha;
                        reiW.HastaFecha = hastaFecha;
                        reiW.Nrti = nrti;
                        reiW.Nrai = nrai;
                        reiW.Nbai = nbai;
                        reiW.Ncai = ncai;
                        // lo agregamos a la lista
                        l.Add(reiW);
                    }
                }
            }
            else
            { 
                if (tipo == null)
                {
                    tipos_dispositivo.Clear();
                    foreach (Dispositivo disp in instalacion.Dispositivos.OrderBy(x => x.TipoDispositivo.Nombre))
                    {
                        if(!tipos_dispositivo.Contains(disp.TipoDispositivo))
                        {
                            TipoDispositivo t = disp.TipoDispositivo;
                            tipos_dispositivo.Add(t);
                            // cada bucle crea un objeto
                            ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                            {
                                Empresa = empresa.Nombre,
                                T_disp = t.Nombre,
                                TipoId = t.TipoId,
                                Instalacion = instalacion.Nombre,
                                InstalacionId = instalacion.InstalacionId,
                            };
                        
                            // calculamos los valores para esta instalacion
                            nrti = NumeroRevisiones(desdeFecha, hastaFecha, instalacion, t, facturable, ctx);
                            nrai = NumeroRevisionesConAnomalia(desdeFecha, hastaFecha, instalacion, t, ctx);
                            nbai = NumeroBajas(desdeFecha, hastaFecha, instalacion, t, ctx);
                            ncai = NumeroCambios(desdeFecha, hastaFecha, instalacion, t, ctx);
                            nrt += nrti;
                            nra += nrai;
                            nba += nbai;
                            nca += ncai;
                            reiW.DesdeFecha = desdeFecha;
                            reiW.HastaFecha = hastaFecha;
                            reiW.Nrti = nrti;
                            reiW.Nrai = nrai;
                            reiW.Nbai = nbai;
                            reiW.Ncai = ncai;
                            // lo agregamos a la lista
                            l.Add(reiW);
                        }
                    }
                }
                else
                {
                    ResEmpresaInstalacionView reiW = new ResEmpresaInstalacionView()
                    {
                        Empresa = empresa.Nombre,
                        T_disp = tipo.Nombre,
                        TipoId = tipo.TipoId,
                        Instalacion = instalacion.Nombre,
                        InstalacionId = instalacion.InstalacionId,
                    };
                    // calculamos los valores para este tipo de dispositivo
                    nrti = NumeroRevisiones(desdeFecha, hastaFecha, instalacion, tipo, facturable, ctx);
                    nrai = NumeroRevisionesConAnomalia(desdeFecha, hastaFecha, instalacion, tipo, ctx);
                    nbai = NumeroBajas(desdeFecha, hastaFecha, instalacion, tipo, ctx);
                    ncai = NumeroCambios(desdeFecha, hastaFecha, instalacion, tipo, ctx);
                    nrt += nrti;
                    nra += nrai;
                    nba += nbai;
                    nca += ncai;
                    reiW.DesdeFecha = desdeFecha;
                    reiW.HastaFecha = hastaFecha;
                    reiW.Nrti = nrti;
                    reiW.Nrai = nrai;
                    reiW.Nbai = nbai;
                    reiW.Ncai = ncai;
                    // lo agregamos a la lista
                    l.Add(reiW);
                }
            }
        
            // montanos los totales
            foreach (ResEmpresaInstalacionView reiW in l)
            {
                reiW.Nrt = nrt;
                reiW.Nra = nra;
                reiW.Nba = nba;
                reiW.Nca = nca;
            }
            return l;
        }
       
        private static int NumeroBajasInstalacion(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            int numero = 0;
            numero = (from d in ctx.Dispositivos where d.Instalacion.InstalacionId == instalacion.InstalacionId &&
                                                       d.FechaBaja >= desdeFecha &&
                                                       d.FechaBaja <= hastaFecha select d).Count();
          
            return numero;
        }

        private static int NumeroBajasTipo(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, LainsaSci ctx)
        {
            int numero = 0;
            numero = (from d in ctx.Dispositivos
                      where d.TipoDispositivo.TipoId == tipo.TipoId &&
                            d.FechaBaja >= desdeFecha &&
                            d.FechaBaja <= hastaFecha
                      select d).Count();

            return numero;
        }

        private static int NumeroBajas(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            int numero = 0;
            numero = (from d in ctx.Dispositivos
                      where d.Instalacion.InstalacionId == instalacion.InstalacionId &&
                            d.TipoDispositivo.TipoId == tipo.TipoId &&
                            d.FechaBaja >= desdeFecha &&
                            d.FechaBaja <= hastaFecha
                      select d).Count();

            return numero;
        }

        public static IList<BajaView> GetBajasView(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            IList<BajaView> lbw = new List<BajaView>();
            var rs = from d in ctx.Dispositivos
                     orderby d.FechaBaja descending
                     where d.Instalacion.InstalacionId == instalacion.InstalacionId &&
                           d.FechaBaja >= desdeFecha &&
                           d.FechaBaja <= hastaFecha
                     select d;
            foreach (Dispositivo dsp in rs)
            {
                BajaView bw = new BajaView()
                {
                    Dispositivo = dsp.Nombre,
                    FechaBaja = dsp.FechaBaja
                };
                lbw.Add(bw);
            }
            return lbw;
        }

        public static IList<BajaView> GetBajasView(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, LainsaSci ctx)
        {
            IList<BajaView> lbw = new List<BajaView>();
            var rs = from d in ctx.Dispositivos
                     orderby d.FechaBaja descending
                     where d.TipoDispositivo.TipoId == tipo.TipoId &&
                           d.FechaBaja >= desdeFecha &&
                           d.FechaBaja <= hastaFecha
                     select d;
            foreach (Dispositivo dsp in rs)
            {
                BajaView bw = new BajaView()
                {
                    Dispositivo = dsp.Nombre,
                    FechaBaja = dsp.FechaBaja
                };
                lbw.Add(bw);
            }
            return lbw;
        }
        
        public static IList<BajaView> GetBajasView(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            IList<BajaView> lbw = new List<BajaView>();
            var rs = from d in ctx.Dispositivos
                     orderby d.FechaBaja descending
                     where d.Instalacion.InstalacionId == instalacion.InstalacionId &&
                           d.TipoDispositivo.TipoId == tipo.TipoId &&
                           d.FechaBaja >= desdeFecha &&
                           d.FechaBaja <= hastaFecha
                     select d;
            foreach (Dispositivo dsp in rs)
            {
                BajaView bw = new BajaView()
                {
                    Dispositivo = dsp.Nombre,
                    FechaBaja = dsp.FechaBaja
                };
                lbw.Add(bw);
            }
            return lbw;
        }
        
        public static IList<CambioView> GetCambiosView(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            IList<CambioView> lbw = new List<CambioView>();
            var rs = from s in ctx.Sustitucions
                     orderby s.Fecha descending
                     where
                          (s.DispositivoOriginal.Instalacion.InstalacionId == instalacion.InstalacionId ||
                           s.DispositivoSustituto.Instalacion.InstalacionId == instalacion.InstalacionId) &&
                          s.Fecha >= desdeFecha &&
                          s.Fecha <= hastaFecha
                     select s;
            foreach (Sustitucion sust in rs)
            {
                CambioView cw = new CambioView()
                {
                    InstalacionId = sust.DispositivoOriginal.Instalacion.InstalacionId,
                    Sustituido = sust.DispositivoOriginal.Nombre,
                    Sustituto = sust.DispositivoSustituto.Nombre,
                    Fecha = sust.Fecha
                };
                lbw.Add(cw);
            }
            return lbw;
        }
        
        public static IList<CambioView> GetCambiosView(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, LainsaSci ctx)
        {
            IList<CambioView> lbw = new List<CambioView>();
            var rs = from s in ctx.Sustitucions
                     orderby s.Fecha descending
                     where
                          (s.DispositivoOriginal.TipoDispositivo.TipoId == tipo.TipoId||
                           s.DispositivoSustituto.TipoDispositivo.TipoId == tipo.TipoId) &&
                          s.Fecha >= desdeFecha &&
                          s.Fecha <= hastaFecha
                     select s;
            foreach (Sustitucion sust in rs)
            {
                CambioView cw = new CambioView()
                {
                    TipoId = sust.DispositivoOriginal.TipoDispositivo.TipoId,
                    Sustituido = sust.DispositivoOriginal.Nombre,
                    Sustituto = sust.DispositivoSustituto.Nombre,
                    Fecha = sust.Fecha
                };
                lbw.Add(cw);
            }
            return lbw;
        }
        
        public static IList<CambioView> GetCambiosView(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            IList<CambioView> lbw = new List<CambioView>();
            var rs = from s in ctx.Sustitucions
                     orderby s.Fecha descending
                     where (s.DispositivoOriginal.Instalacion.InstalacionId == instalacion.InstalacionId ||
                           s.DispositivoSustituto.Instalacion.InstalacionId == instalacion.InstalacionId) &&
                          (s.DispositivoOriginal.TipoDispositivo.TipoId == tipo.TipoId ||
                           s.DispositivoSustituto.TipoDispositivo.TipoId == tipo.TipoId) &&
                          s.Fecha >= desdeFecha &&
                          s.Fecha <= hastaFecha
                     select s;
            foreach (Sustitucion sust in rs)
            {
                CambioView cw = new CambioView()
                {
                    InstalacionId = sust.DispositivoOriginal.Instalacion.InstalacionId,
                    TipoId = sust.DispositivoOriginal.TipoDispositivo.TipoId,
                    Sustituido = sust.DispositivoOriginal.Nombre,
                    Sustituto = sust.DispositivoSustituto.Nombre,
                    Fecha = sust.Fecha
                };
                lbw.Add(cw);
            }
            return lbw;
        }
        
        private static int NumeroRevisionesInstalacion(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, bool facturable, LainsaSci ctx)
        {
            int numero = 0;
            if (facturable)
            {
                numero = (from r in ctx.Revisions
                            where r.Estado == "REALIZADA" &&
                                r.PlantillaRevision.Facturable == true &&
                                r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId
                            select r).Count();
            }
            else
            {
                numero = (from r in ctx.Revisions
                            where r.Estado == "REALIZADA" &&
                                r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId
                            select r).Count();
            }
            return numero;
        }
        
        private static int NumeroRevisionesTipo(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, bool facturable, LainsaSci ctx)
        {
            int numero = 0;
            if (facturable)
            {
                numero = (from r in ctx.Revisions
                          where r.Estado == "REALIZADA" &&
                              r.PlantillaRevision.Facturable == true &&
                              r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                              r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId
                          select r).Count();
            }
            else
            {
                numero = (from r in ctx.Revisions
                          where r.Estado == "REALIZADA" &&
                              r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                               r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId
                          select r).Count();
            }
            return numero;
        }
        
        private static int NumeroRevisiones(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, bool facturable, LainsaSci ctx)
        {
            int numero = 0;
            if (facturable)
            {
                numero = (from r in ctx.Revisions
                          where r.Estado == "REALIZADA" &&
                              r.PlantillaRevision.Facturable == true &&
                              r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                              r.Dispositivo.TipoDispositivo.TipoId== tipo.TipoId &&
                              r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId
                          select r).Count();
            }
            else
            {
                numero = (from r in ctx.Revisions
                          where r.Estado == "REALIZADA" &&
                              r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                              r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId &&
                              r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId
                          select r).Count();
            }
            return numero;
        }
        
        public static IList<RevisionView> GetRevisionesView(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, bool facturable, LainsaSci ctx)
        {
            IList<RevisionView> lrw = new List<RevisionView>();
            IList<Revision> lr = (from r in ctx.Revisions
                                  where r.Estado == "REALIZADA" &&
                                        r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                        r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId
                                  select r).ToList<Revision>();

            if (facturable)
            {
                lr = (from r in lr where r.PlantillaRevision.Facturable select r).ToList<Revision>();
            }
            foreach (Revision r in lr)
            {
                RevisionView rw = new RevisionView()
                {
                    RevisionId = r.RevisionId,
                    Dispositivo = r.Dispositivo.Nombre,
                    TipoRevision = r.PlantillaRevision.Descripcion,
                    Resultado = r.Resultado,
                    Comentarios = r.RevisionId.ToString()
                    //                    Comentarios = r.Observaciones

                };
                if (CntLainsaSci.FechaNula(r.FechaRevision))
                    rw.Fecha = null;
                else
                    rw.Fecha = r.FechaRevision;
                if (r.Usuario != null)
                    rw.Usuario = r.Usuario.Nombre;
                if (r.TipoAnomalia != null)
                    rw.Anomalia = r.TipoAnomalia.Nombre;
                else
                    rw.Anomalia = "--- SIN ANOMALIA --- ";
                lrw.Add(rw);
            }
            return lrw;
        }
        
        public static IList<RevisionView> GetRevisionesTipoView(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, bool facturable, LainsaSci ctx)
        {
            IList<RevisionView> lrw = new List<RevisionView>();
            IList<Revision> lr = (from r in ctx.Revisions
                                  where r.Estado == "REALIZADA" &&
                                        r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                        r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId
                                  select r).ToList<Revision>();

            if (facturable)
            {
                lr = (from r in lr where r.PlantillaRevision.Facturable select r).ToList<Revision>();
            }
            foreach (Revision r in lr)
            {
                RevisionView rw = new RevisionView()
                {
                    RevisionId = r.RevisionId,
                    Dispositivo = r.Dispositivo.Nombre,
                    TipoRevision = r.PlantillaRevision.Descripcion,
                    Resultado = r.Resultado,
                    Comentarios = r.Observaciones
                };

                if (r.Usuario != null)
                    rw.Usuario = r.Usuario.Nombre;
                if (r.TipoAnomalia != null)
                    rw.Anomalia = r.TipoAnomalia.Nombre;
                else
                    rw.Anomalia = "--- SIN ANOMALIA --- ";
                lrw.Add(rw);
            }
            return lrw;
        }
        
        public static IList<RevisionView> GetRevisionesEmpresaView(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, bool facturable, LainsaSci ctx)
        {
            IList<RevisionView> lrw = new List<RevisionView>();
            IList<Revision> lr = (from r in ctx.Revisions
                                  where r.Estado == "REALIZADA" &&
                                        r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                        r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId &&
                                        r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId
                                  select r).ToList<Revision>();

            if (facturable)
            {
                lr = (from r in lr where r.PlantillaRevision.Facturable select r).ToList<Revision>();
            }
            foreach (Revision r in lr)
            {
                RevisionView rw = new RevisionView()
                {
                    RevisionId = r.RevisionId,
                    Dispositivo = r.Dispositivo.Nombre,
                    TipoRevision = r.PlantillaRevision.Descripcion,
                    Resultado = r.Resultado,
                    Comentarios = r.Observaciones
                };

                if (r.Usuario != null)
                    rw.Usuario = r.Usuario.Nombre;
                if (r.TipoAnomalia != null)
                    rw.Anomalia = r.TipoAnomalia.Nombre;
                else
                    rw.Anomalia = "--- SIN ANOMALIA --- ";
                lrw.Add(rw);
            }
            return lrw;
        }
        
        private static int NumeroRevisionesInstalacionConAnomalia(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            int numero = 0;
           numero = (from r in ctx.Revisions where r.Estado == "REALIZADA" &&
                                                        r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                                        r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId &&
                                                        r.TipoAnomalia != null select r).Count();
        
            return numero;
        }
        
        private static int NumeroRevisionesTipoConAnomalia(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, LainsaSci ctx)
        {
            int numero = 0;
            numero = (from r in ctx.Revisions
                      where r.Estado == "REALIZADA" &&
                                 r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                 r.Dispositivo.TipoDispositivo.TipoId== tipo.TipoId &&
                                 r.TipoAnomalia != null
                      select r).Count();

            return numero;
        }
        
        private static int NumeroRevisionesConAnomalia(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            int numero = 0;
            numero = (from r in ctx.Revisions
                      where r.Estado == "REALIZADA" &&
                                 r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha &&
                                 r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId &&
                                 r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId &&
                                 r.TipoAnomalia != null
                      select r).Count();

            return numero;
        }
        
        private static int NumeroCambiosInstalacion(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            int numero;
            numero = (from s in ctx.Sustitucions where
                                                      (s.DispositivoOriginal.Instalacion.InstalacionId == instalacion.InstalacionId ||
                                                       s.DispositivoSustituto.Instalacion.InstalacionId == instalacion.InstalacionId) &&
                                                      s.Fecha >= desdeFecha &&
                                                      s.Fecha <= hastaFecha select s).Count();
          return numero;
        }
        
        private static int NumeroCambiosTipo(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, LainsaSci ctx)
        {
            int numero;
            numero = (from s in ctx.Sustitucions
                      where
                           (s.DispositivoOriginal.TipoDispositivo.TipoId == tipo.TipoId ||
                            s.DispositivoSustituto.TipoDispositivo.TipoId == tipo.TipoId) &&
                           s.Fecha >= desdeFecha &&
                           s.Fecha <= hastaFecha
                      select s).Count();
            return numero;
        }
        
        private static int NumeroCambios(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            int numero;
            numero = (from s in ctx.Sustitucions
                      where
                           (s.DispositivoOriginal.Instalacion.InstalacionId == instalacion.InstalacionId ||
                            s.DispositivoSustituto.Instalacion.InstalacionId == instalacion.InstalacionId) &&
                             (s.DispositivoOriginal.TipoDispositivo.TipoId == tipo.TipoId ||
                            s.DispositivoSustituto.TipoDispositivo.TipoId == tipo.TipoId) &&
                           s.Fecha >= desdeFecha &&
                           s.Fecha <= hastaFecha
                      select s).Count();
            return numero;
        }
        
        private static IList<Revision> GetRevisions(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    where r.Estado == "REALIZADA" &&
                          r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId &&
                          r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha
                    select r).ToList<Revision>();
        }
        
        private static IList<Revision> GetRevisionsTipo(DateTime desdeFecha, DateTime hastaFecha, TipoDispositivo tipo, LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    where r.Estado == "REALIZADA" &&
                          r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId &&
                          r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha
                    select r).ToList<Revision>();
        }
        
        private static IList<Revision> GetRevisionsTipo(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    where r.Estado == "REALIZADA" &&
                          r.Dispositivo.Instalacion.InstalacionId == instalacion.InstalacionId &&
                          r.Dispositivo.TipoDispositivo.TipoId == tipo.TipoId &&
                          r.FechaRevision >= desdeFecha && r.FechaRevision <= hastaFecha
                    select r).ToList<Revision>();
        }
        
        public static IList<ResTipoPlantillaView> GetTipoPlantillaViews(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, LainsaSci ctx)
        {
            IList<ResTipoPlantillaView> iltp = new List<ResTipoPlantillaView>();
            IList<Revision> ilr = GetRevisions(desdeFecha, hastaFecha, instalacion, ctx);
            var rs = from r in ilr
                     group r by new
                     {
                         r.Dispositivo.Instalacion.InstalacionId,
                         r.Dispositivo.TipoDispositivo.Nombre,
                         r.PlantillaRevision.Descripcion
                     }
                     into grp
                     select new
                     {
                         grp.Key.InstalacionId,
                         grp.Key.Nombre,
                         grp.Key.Descripcion,
                         numero = grp.Count()
                     };
            foreach (var line in rs)
            {
                ResTipoPlantillaView rtpW = new ResTipoPlantillaView()
                {
                    InstalacionId = line.InstalacionId,
                    Tipo = line.Nombre,
                    Plantilla = line.Descripcion,
                    Numero = line.numero
                };
                iltp.Add(rtpW);
            }
            return iltp;
        }
        
        public static IList<ResTipoPlantillaView> GetTipoPlantillaViews(DateTime desdeFecha, DateTime hastaFecha,TipoDispositivo tipo, LainsaSci ctx)
        {
            IList<ResTipoPlantillaView> iltp = new List<ResTipoPlantillaView>();
            IList<Revision> ilr = GetRevisionsTipo(desdeFecha, hastaFecha, tipo, ctx);
            var rs = from r in ilr
                     group r by new
                     {
                         r.Dispositivo.Instalacion.InstalacionId,
                         r.Dispositivo.TipoDispositivo.Nombre,
                         r.PlantillaRevision.Descripcion
                     }
                         into grp
                         select new
                         {
                             grp.Key.InstalacionId,
                             grp.Key.Nombre,
                             grp.Key.Descripcion,
                             numero = grp.Count()
                         };
            foreach (var line in rs)
            {
                ResTipoPlantillaView rtpW = new ResTipoPlantillaView()
                {
                    InstalacionId = line.InstalacionId,
                    Tipo = line.Nombre,
                    Plantilla = line.Descripcion,
                    Numero = line.numero
                };
                iltp.Add(rtpW);
            }
            return iltp;
        }
        
        public static IList<ResTipoPlantillaView> GetTipoPlantillaViews(DateTime desdeFecha, DateTime hastaFecha, Instalacion instalacion, TipoDispositivo tipo, LainsaSci ctx)
        {
            IList<ResTipoPlantillaView> iltp = new List<ResTipoPlantillaView>();
            IList<Revision> ilr = GetRevisionsTipo(desdeFecha, hastaFecha,instalacion, tipo, ctx);

            var rs = from r in ilr
                     group r by new
                     {
                         r.Dispositivo.Instalacion.InstalacionId,
                         r.Dispositivo.TipoDispositivo.Nombre,
                         r.PlantillaRevision.Descripcion
                     }
                         into grp
                         select new
                         {
                             grp.Key.InstalacionId,
                             grp.Key.Nombre,
                             grp.Key.Descripcion,
                             numero = grp.Count()
                         };
            foreach (var line in rs)
            {
                ResTipoPlantillaView rtpW = new ResTipoPlantillaView()
                {
                    InstalacionId = line.InstalacionId,
                    Tipo = line.Nombre,
                    Plantilla = line.Descripcion,
                    Numero = line.numero
                };
                iltp.Add(rtpW);
            }
            return iltp;
        }
        
        /// <summary>
        /// Esta operación sirve para montar  los formularios vacíos para que los rellene el usuario
        /// </summary>
        /// <param name="programa"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        /// 
        
        public static IList<RevisionView> GetFormulariosRevision(Programa programa, LainsaSci ctx)
        {
            IList<RevisionView> lrw = new List<RevisionView>();
            RevisionView rw = null;
            string miCampo = "";
            string bigCampo = "";
            foreach (Revision r in programa.Revisions)
            {
                foreach (DatosRevision dr in r.DatosRevisions)
                {
                    rw = new RevisionView();
                    rw.RevisionId = r.RevisionId;
                    if (!CntLainsaSci.FechaNula(r.FechaRevision))
                        rw.Fecha = r.FechaRevision;
                    rw.FechaPlanificada = r.FechaPlanificada;
                    rw.FechaProgramada = r.FechaProgramada;
                    
                    if (r.Usuario != null)
                        rw.Usuario = r.Usuario.Nombre;
                    else
                        rw.Usuario = "................";
                    rw.Dispositivo = String.Format("{0} ({1}) {2} [UBICACION: {3}]",r.Dispositivo.Nombre, r.Dispositivo.Instalacion.Nombre, r.Dispositivo.Instalacion.Empresa.Nombre, r.Dispositivo.Posicion);
                    string comenta = "";
                    string valor = dr.Valor;
                    if (valor == "" || valor == null)
                    {
                        switch (dr.Campo.TipoCampo.Descripcion)
                        {
                            case "Campo OK/MAL":
                                miCampo = "[ ]";
                                break;
                            case "Texto":
                                miCampo = "(Texto)";
                                break;
                            case "Tetra":
                                miCampo = "[SI] [NO] [NO APLICA]";
                                break;
                            case "Numerico":
                                miCampo = "(Número):";
                                break;
                            case "Fecha":
                                miCampo = "(Fecha):";
                                break;
                        }
                    }
                    else
                    {
                        int pos1 = valor.IndexOf("|");
                        if (pos1 < 0) break;
                        string c1 = valor.Substring(0, pos1); 
                        string c2 = valor.Substring(pos1 + 1, valor.Length - (pos1 + 1));
                        miCampo = c1;
                        comenta = c2;
                    }
                    
                    bigCampo = String.Format("<b>{0}</b><br/><i>{1}</i><br/><br/><b>Comentarios: </b>{2}<br/>", dr.Campo.Nombre, miCampo, comenta);
                    rw.Campo = bigCampo;
                    lrw.Add(rw);
                }
            }

            return lrw;
        }

        public static IList<PruebaHidrostatica> GetPruebasHisdrostaticas(Instalacion instalacion, string observaciones, string actaNumero, DateTime fechaActa, string tecnicoResponsable, LainsaSci ctx)
        {
            IList<PruebaHidrostatica> lph = new List<PruebaHidrostatica>();
            foreach (Dispositivo dsp in instalacion.Dispositivos)
            {
                PruebaHidrostatica ph = new PruebaHidrostatica();
                if (ph.Fabricante != null)
                    ph.Fabricante = dsp.Fabricante.Nombre;
                if (ph.AgenteExtintor !=null)
                ph.AgenteExtintor = dsp.AgenteExtintor.Descripcion;
                ph.Carga = String.Format("{0:##,####,##0.00}", dsp.CargaKg);
                ph.NumIndustria = dsp.NumeroIndustria;
                ph.FechaFabricacion = dsp.FechaFabricacion;
                Timbre tim = CntLainsaSci.GetTimbre(dsp, ctx);
                ph.UltimoRetimbrado = tim.FechaUltima;
                ph.ProximoRetimbrado = tim.FechaSiguiente;
                ph.PresPrueba = tim.PPrueba;
                ph.PresTimbre = tim.PTimbre;
                ph.Resultado = "---";
                ph.Cliente = dsp.Instalacion.Empresa.Nombre;
                ph.NumOrden = "---";
                ph.Observaciones = observaciones;
                ph.ActaNumero = actaNumero;
                ph.FechaActa = fechaActa;
                ph.TecnicoResponsable = tecnicoResponsable;
                lph.Add(ph);
            }
            return lph;
        }

        public static IList<PruebaHidrostatica> GetPruebasHisdrostaticasEmpresa(Empresa empresa, string observaciones, string actaNumero, DateTime fechaActa, string tecnicoResponsable, LainsaSci ctx)
        {
            IList<PruebaHidrostatica> lph = new List<PruebaHidrostatica>();
            foreach (Instalacion instalacion in empresa.Instalaciones)
            {
                foreach (Dispositivo dsp in instalacion.Dispositivos)
                {
                    PruebaHidrostatica ph = new PruebaHidrostatica();
                    if (ph.Fabricante != null)
                        ph.Fabricante = dsp.Fabricante.Nombre;
                    if (ph.AgenteExtintor != null)
                        ph.AgenteExtintor = dsp.AgenteExtintor.Descripcion;
                    ph.Carga = String.Format("{0:##,####,##0.00}", dsp.CargaKg);
                    ph.NumIndustria = dsp.NumeroIndustria;
                    ph.FechaFabricacion = dsp.FechaFabricacion;
                    Timbre tim = CntLainsaSci.GetTimbre(dsp, ctx);
                    ph.UltimoRetimbrado = tim.FechaUltima;
                    ph.ProximoRetimbrado = tim.FechaSiguiente;
                    ph.PresPrueba = tim.PPrueba;
                    ph.PresTimbre = tim.PTimbre;
                    ph.Resultado = "---";
                    ph.Cliente = dsp.Instalacion.Empresa.Nombre;
                    ph.NumOrden = "---";
                    ph.Observaciones = observaciones;
                    ph.ActaNumero = actaNumero;
                    ph.FechaActa = fechaActa;
                    ph.TecnicoResponsable = tecnicoResponsable;
                    ph.Instalacion = instalacion.Nombre;
                    lph.Add(ph);
                }
            }
            return lph;
        }
        
        public static String GetFecha(DateTime f)
        {
            int y = f.Year;
            int m = f.Month;
            int d = f.Day;
            string f2 = String.Format("{0:00}/{1:00}/{2:0000}", d,m,y);
            if (f2 == "01/01/0001")
            {
                f2 = "";
            }
            return f2;
        }
    }
}