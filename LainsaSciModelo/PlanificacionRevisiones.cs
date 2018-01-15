using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciModelo
{
    public static partial class CntLainsaSci
    {
        public static void ProgramarRevisiones(Dispositivo disp, LainsaSci ctx)
        {
            if (disp == null)
                return;
            if (!disp.Operativo && !disp.SiguePlan)
                return;
            foreach (ResumenRevision rr in disp.ResumenesRevisones)
            {
                PlanificarRevisiones(rr, ctx);
            }
        }

        public static void ProgramarSiguienteRevision(Revision rev, LainsaSci ctx, bool controlSuperiores)
        {
            // si la plantilla no es periódica no hay nada que planificar
            if (rev.PlantillaRevision.NoPeriodica)
                return;
            // si el dispositivo está caducado no hay nada que planificar.
            if (rev.Dispositivo.Caducado)
                return;
            // si la revisión actual no tiene fecha tampoco podemos planificar.
            if (CntLainsaSci.FechaNula(rev.FechaRevision))
                return;
            Dispositivo dsp = rev.Dispositivo;
            // controlamos si el dispositivo en el intermedio no está operativo y no se planifican
            if (!dsp.Operativo && !dsp.SiguePlan)
                return;
            PlantillaRevision pr = rev.PlantillaRevision;
            ResumenRevision rr = (from rsr in dsp.ResumenesRevisones
                                  where rsr.PlantillaRevision.PlantillaId == pr.PlantillaId
                                  select rsr).FirstOrDefault<ResumenRevision>();
            // lo primero es conocer cuando tocaría la siguiente.
            DateTime fechaFin = SiguienteFecha(rev.FechaRevision, pr);
            // controlar que no hay una revisión de periodo mayor que coincida con ella
            //if (controlSuperiores)
            //{
            //    if (HayPlanificadaSuperior(fechaFin, rev, ctx))
            //        return;
            //}

            // buscamos si ya había una revisión que exactamente [fecha y tipo] 
            // coi-ncida con la que vamos a dar de alta
            Revision rev2 = (from r in ctx.Revisions
                             where r.Dispositivo.DispositivoId == dsp.DispositivoId &&
                                   r.PlantillaRevision.PlantillaId == pr.PlantillaId &&
                                   r.FechaPlanificada == fechaFin
                             select r).FirstOrDefault<Revision>();
            if (rev2 == null)
            {
                rev2 = new Revision();
                rev2.Dispositivo = rev.Dispositivo;
                rev2.FechaPlanificada = fechaFin;
                rev2.PlantillaRevision = pr;
                rev2.Estado = "PLANIFICADA";
                // Comprobamos si caemos en caducidad
                if (fechaFin >= dsp.FechaCaducidad)
                {
                    rev2.CaduProx = true;
                }
                else
                {
                    // calculamos en que fecha caerá la siguiente y si es fuera de caducidad
                    DateTime fechaSS = SiguienteFecha(fechaFin, pr);
                    if (fechaSS >= dsp.FechaCaducidad)
                        rev2.CaduProx = true;
                }
            
                ctx.Add(rev2);
                foreach (Campo c in pr.Campos)
                {
                    DatosRevision dr = new DatosRevision();
                    dr.Campo = c;
                    // Miramos los valores de campo en la anterior para copiarlos
                    DatosRevision dr2 = (from d in rev.DatosRevisions
                                         where d.Campo.Nombre == c.Nombre
                                         select d).FirstOrDefault<DatosRevision>();
                    if (dr2 != null)
                        dr.Valor = dr2.Valor;

                    dr.Revision = rev2;
                    ctx.Add(dr);
                }
                // Eliminmos las posibles inferiores a la planificada.
                if (controlSuperiores) EliminarInferiores(rev2, ctx); // esto ya se ha hecho antes
                ctx.SaveChanges();
            }
            // Por último actulaizar la fecha en resumen
            rr.FechaUltima = rev.FechaRevision;
            rr.FechaSiguiente = fechaFin;

            ctx.SaveChanges();
        }
        //
        public static DateTime SiguienteFecha(DateTime fechaBase, PlantillaRevision pr)
        {
            DateTime fechaFin = fechaBase;
            switch (pr.TipoPeriodo)
            {
                case "D":
                    fechaFin = fechaBase.AddDays((double)pr.NumeroPeriodos);
                    break;
                case "S":
                    fechaFin = fechaBase.AddDays((double)pr.NumeroPeriodos * 7);
                    break;
                case "M":
                    fechaFin = fechaBase.AddMonths(pr.NumeroPeriodos);
                    break;
                case "A":
                    fechaFin = fechaBase.AddYears(pr.NumeroPeriodos);
                    break;
            }
            return fechaFin;
        }
        public static IList<ResumenRevision> GetResumenRevisions(Dispositivo d, LainsaSci ctx, int status) {
            IList<ResumenRevision> rtn = new List<ResumenRevision>();

            foreach(ResumenRevision r in d.ResumenesRevisones) {
                if(r.estadoDispositivo == status) {
                    rtn.Add(r);
                }
            }

            
            return rtn;
        }
        public static IList<ResumenRevision> GetResumenRevisions(LainsaSci ctx)
        {
            return (from rs in ctx.ResumenRevisions
                    select rs).ToList<ResumenRevision>();
        }

        public static ResumenRevision GetResumenRevision(int id, LainsaSci ctx)
        {
            return (from rs in ctx.ResumenRevisions
                    where rs.ResumenRevisionId == id
                    select rs).FirstOrDefault<ResumenRevision>();
        }

        public static void CrearResumenesRevision(Dispositivo dsp, LainsaSci ctx)
        {
            if (dsp == null)
                return;
            IList<PlantillaRevision> lpr = (from p in dsp.TipoDispositivo.PlantillaRevisions
                                            where p.NoPeriodica == false 
                                            select p).ToList<PlantillaRevision>();
            foreach (PlantillaRevision pr in lpr)
            {
                ResumenRevision rr = (from rsr in dsp.ResumenesRevisones
                                      where rsr.PlantillaRevision != null &&  rsr.PlantillaRevision.PlantillaId == pr.PlantillaId
                                      select rsr).FirstOrDefault<ResumenRevision>();
                if (rr == null)
                {
                    rr = new ResumenRevision();
                    rr.Dispositivo = dsp;
                    rr.PlantillaRevision = pr;
                    ctx.Add(rr);
                }
            }
            ctx.SaveChanges();
        }

        public static bool HayRevisionesHechas(ResumenRevision rr, LainsaSci ctx)
        {
            bool res = false;
            // Eliminar todas las revisiones de ese dispositivo para esa plantilla, no realizadas
            var rs = from r in rr.Dispositivo.Revisiones
                     where r.PlantillaRevision.PlantillaId == rr.PlantillaRevision.PlantillaId
                     select r;
            foreach (Revision r in rs)
            {
                if (!CntLainsaSci.FechaNula(r.FechaRevision))
                {
                    res = true;
                }
            }
            return res;
        }

        public static void PlanificarRevisionesAccesorios(ResumenRevision rr, LainsaSci ctx)
        {
            foreach (Dispositivo d in rr.Dispositivo.Accesorios)
                foreach (ResumenRevision r in d.ResumenesRevisones)
                {
                    if (r.PlantillaRevision.PlantillaId == rr.PlantillaRevision.PlantillaId)
                    {
                        r.FechaUltima = rr.FechaUltima;
                        PlanificarRevisiones(r, ctx);
                    }
                }
            return;
        }

        public static void PlanificarRevisiones(ResumenRevision rr, LainsaSci ctx)
        {
            // Hay que evitar que un dispositivo que no sigue planificación planifique.
            if (!rr.Dispositivo.Operativo && !rr.Dispositivo.SiguePlan)
                return;
            // NO se planifican dispositivos caducados
            if (rr.Dispositivo.Caducado) return;
            // Eliminar todas las revisiones de ese dispositivo para esa plantilla, no realizadas
            var rs = from r in rr.Dispositivo.Revisiones
                     where r.PlantillaRevision.PlantillaId == rr.PlantillaRevision.PlantillaId
                     select r;
            IList<Revision> revisiones = new List<Revision>();
            foreach (Revision r in rs)
            {
                if (CntLainsaSci.FechaNula(r.FechaRevision))
                {
                    // hay que salvar las programadas para poder recargarlas
                    if (r.Programa != null)
                    {
                        Revision rev = new Revision
                        {
                            Dispositivo = r.Dispositivo,
                            PlantillaRevision = r.PlantillaRevision,
                            FechaPlanificada = r.FechaPlanificada,
                            Programa = r.Programa,
                            FechaProgramada = r.FechaPlanificada
                        };
                        revisiones.Add(rev);
                    }
                    ctx.Delete(r.DatosRevisions);
                    ctx.Delete(r.Sustitucions);
                    ctx.Delete(r);
                }
            }
            ctx.SaveChanges();
            if (CntLainsaSci.FechaNula(rr.FechaUltima))
                return;
            DateTime fechaBase = rr.FechaUltima;
            DateTime fechaSiguiente = SiguienteFecha(fechaBase, rr.PlantillaRevision);
            // buscamos si ya había una revisión que coincida con la que vamos a dar de alta
            Revision rev2 = (from r in ctx.Revisions
                             where r.Dispositivo.DispositivoId == rr.Dispositivo.DispositivoId && r.PlantillaRevision.PlantillaId == rr.PlantillaRevision.PlantillaId && r.FechaRevision == fechaSiguiente && r.Dispositivo.Operativo == true
                             select r).FirstOrDefault<Revision>();
            
            if (rev2 == null)
            {
                rev2 = new Revision();
                rev2.Dispositivo = rr.Dispositivo;
                rev2.FechaPlanificada = fechaSiguiente;
                // Comprobamos si caemos en caducidad
                if (fechaSiguiente >= rev2.Dispositivo.FechaCaducidad)
                {
                    rev2.CaduProx = true;
                }
                else
                {
                    // calculamos en que fecha caerá la siguiente y si es fuera de caducidad
                    DateTime fechaSS = SiguienteFecha(fechaSiguiente, rr.PlantillaRevision);
                    if (fechaSS >= rev2.Dispositivo.FechaCaducidad)
                        rev2.CaduProx = true;
                }
                rev2.PlantillaRevision = rr.PlantillaRevision;
                rev2.Estado = "PLANIFICADA";
                
                //Respetamos la programación en función de las revisiones anteriores
                foreach (Revision r in revisiones)
                {
                    if (r.Dispositivo.DispositivoId == rev2.Dispositivo.DispositivoId && r.PlantillaRevision.PlantillaId == rev2.PlantillaRevision.PlantillaId && r.FechaPlanificada == rev2.FechaPlanificada)
                    {
                        rev2.Programa = r.Programa;
                        rev2.FechaProgramada = r.FechaProgramada;
                        rev2.Estado = "PROGRAMADA";
                        r.Programa.Revisions.Add(rev2);
                    }
                }
                ctx.Add(rev2);
                foreach (Campo c in rr.PlantillaRevision.Campos)
                {
                    DatosRevision dr = new DatosRevision();
                    dr.Campo = c;
                    dr.Revision = rev2;
                    ctx.Add(dr);
                }
               
                ctx.SaveChanges();
            }
            // Actualizamos la fecha siguiente en esta plantilla
            rr.FechaSiguiente = fechaSiguiente;
            ctx.SaveChanges();
        }

        public static void CambioCaducidad(int nCaduca, TipoDispositivo tdp, LainsaSci ctx)
        {
            var rs = (from d in ctx.Dispositivos
                      where d.TipoDispositivo.TipoId == tdp.TipoId
                      select d);
            foreach (Dispositivo d in rs)
            {
                if (!CntLainsaSci.FechaNula(d.FechaFabricacion))
                {
                    d.FechaCaducidad = d.FechaFabricacion.AddYears(nCaduca);
                }
            }
        }

        //public static IList<Programa> GetProgramas(Usuario u, LainsaSci ctx) 
        //{
        //    IList<Programa> l = new List<Programa>();
        //    if (u.Empresa == null && u.Instalacion == null)
        //    {
        //        l = (from p in ctx.Programas
        //             select p).ToList<Programa>();
        //    }
        //    else
        //    {
        //        if (u.Empresa != null)
        //        l = (from p in ctx.Programas
        //             where p.Usuario.Empresa.EmpresaId == u.Empresa.EmpresaId
        //             select p).ToList<Programa>();
        //        if (u.Instalacion != null)
        //            l = (from p in ctx.Programas
        //                 where p.Usuario.Instalacion.InstalacionId == u.Instalacion.InstalacionId
        //                 select p).ToList<Programa>();
        //    }
        //    return l;
        //}
        public static IList<Programa> GetProgramas(Usuario u, LainsaSci ctx) 
        {
            IList<Programa> l = new List<Programa>();
            IList<Programa> aux = new List<Programa>();
            aux = (from p in ctx.Programas
                   select p).ToList<Programa>();
            if(u != null) {


                if(u.GrupoTrabajo != null) {
                    foreach(Programa p in aux)
                        if(p.Usuario != null)
                            if(p.Usuario.GrupoTrabajo != null)
                                if(p.Usuario.GrupoTrabajo.GrupoTrabajoId == u.GrupoTrabajo.GrupoTrabajoId)
                                    l.Add(p);
                    return l;
                } else {

                    List<string> l_aux = new List<string>();

                    foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                        if(ue.Empresa == null) {
                            return aux;
                        } else {
                            if (ue.Instalacion == null)
                            {
                                l_aux.Add(ue.Empresa.EmpresaId.ToString() + '_');
                            }
                            else
                            {
                                l_aux.Add(ue.Empresa.EmpresaId.ToString() + '_' + ue.Instalacion.InstalacionId.ToString());
                            }
                            
                            
                        }
                    }

                    foreach(Programa p in aux) {
                        string pp = "";
                        foreach(UsuarioEmpresa ue in p.Usuario.UsuarioEmpresas) {
                            if(ue.Empresa != null) {
                                pp = ue.Empresa.EmpresaId.ToString();
                                pp += "_";
                                if(ue.Instalacion != null) {
                                    pp += ue.Instalacion.InstalacionId.ToString();
                                }
                            } else {
                                pp = "_";
                            }
                            if(l_aux.Contains(pp)) {
                                l.Add(p);
                                break;
                            }
                        }

                        return l;

                    }
                }
            }
            return l;
        }


        public static IList<Programa> GetProgramas(Empresa e, Usuario u, LainsaSci ctx)
        { 
            IList<Programa> l = new List<Programa>();

            if (e != null)
            {
                bool empresaOk = false;
                foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) { 
                    if(ue.Empresa == null || ue.Empresa.EmpresaId == e.EmpresaId ){
                        empresaOk = true;
                        break;
                    }

                }

                if(!empresaOk) {
                    return l;
                }
                IList<Programa> aux = new List<Programa>();
                //aux = (from p in ctx.Programas
                //       where p.Estado != "FINALIZADA"
                //       select p).ToList<Programa>();

                aux = (from p in ctx.Programas
                       from r in p.Revisions
                       where p.Estado != "FINALIZADA" &&
                             r.Dispositivo.Instalacion.Empresa.EmpresaId == e.EmpresaId &&
                             r.Programa.ProgramaId == p.ProgramaId
                       select p).ToList<Programa>();
               
                aux = aux.Distinct().ToList<Programa>();

                if (u != null && u.GrupoTrabajo != null)
                {
                    foreach (Programa p in aux)
                    {
                        if (p.Usuario != null)
                        {
                            if (p.Usuario.GrupoTrabajo != null)
                            {

                                if (p.Usuario.GrupoTrabajo.GrupoTrabajoId == u.GrupoTrabajo.GrupoTrabajoId && p.Usuario != null)
                                    l.Add(p);
                            }
                        }
                    }
                }
                else 
                {
                    l = aux;
                    //foreach (Programa pr in aux)
                    //{
                    //    if (pr.Revisions != null && pr.Revisions.Count > 0)
                    //        if (pr.Revisions[0].Dispositivo.Instalacion.Empresa.EmpresaId == e.EmpresaId)
                    //            l.Add(pr);
                    //}
                }
            }
            return l;
        }

        public static Programa GetPrograma(int id, LainsaSci ctx)
        {
            return (from p in ctx.Programas
                    where p.ProgramaId == id
                    select p).FirstOrDefault<Programa>(); 
        }

        public static void DeletePrograma(Programa p, LainsaSci ctx)
        {
            // buscamos las revisiones programadas que corresponde a
            // este programa
            var rs = (from rev1 in p.Revisions
                      where rev1.Estado == "PROGRAMADA"
                      select rev1);
            // primero desprogramamos las revisiones
            foreach (Revision r in rs)
            {
                r.Estado = "PLANIFICADA";
                r.Programa = null;
                ctx.SaveChanges();
                // ahora buscamos revisiones del mismo dispositivo programadas
                var rs2 = (from rev2 in r.Dispositivo.Revisiones
                           where rev2.Estado == "PROGRAMADA"
                           select rev2);
                foreach (Revision r2 in rs2)
                {
                    r2.Estado = "PLANIFICADA";
                    r2.Programa = null;
                    ctx.SaveChanges();
                }
            }
            foreach (Sustitucion s in p.Sustitucions)
            {
                ctx.Delete(s);
            }
            ctx.Delete(p);
            ctx.SaveChanges();
        }

        public static IList<Usuario> GetUsuarios(Usuario u, LainsaSci ctx) {
            IList<Usuario> l = new List<Usuario>();
            List<string> ei = new List<string>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa != null && ue.Instalacion != null) {
                    ei.Add(ue.Empresa.EmpresaId.ToString() + "_" + ue.Instalacion.InstalacionId.ToString());
                    ei.Add(ue.Empresa.EmpresaId.ToString() + "_");
                } else if(ue.Empresa == null) {
                    ei.Add("_");
                } else {
                    ei.Add(ue.Empresa.EmpresaId.ToString() + "_");
                }
            }
            foreach(Usuario usu in (from usu in ctx.Usuarios
                                    select usu).ToList<Usuario>()) {
                bool yaAgregado = false;

                if(ei.Contains("_"))
                    l.Add(usu);
                else {
                    foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                        string auxue = "";
                        if(ue.Empresa != null && ue.Instalacion != null) {
                            auxue = ue.Empresa.EmpresaId.ToString() + "_" + ue.Instalacion.InstalacionId.ToString();
                        } else if(ue.Empresa == null) {
                            auxue = "_";
                        } else {
                            auxue = ue.Empresa.EmpresaId.ToString() + "_";
                        }
                        if(ei.Contains(auxue) || auxue == "_") {
                            l.Add(usu);
                            break;
                        }
                    }
                }
            }
            return l;
        }
        //public static IList<Usuario> GetUsuarios(Usuario u, LainsaSci ctx) {
        //    IList<Usuario> l = new List<Usuario>();
        //    foreach(Usuario usu in (from usu in ctx.Usuarios
        //                            select usu).ToList<Usuario>()) {
        //        bool yaAgregado = false;
        //        if(u.Empresa == null && u.Instalacion == null)
        //            l.Add(usu);
        //        else {
        //            Empresa e = usu.Empresa;
        //            Instalacion i = usu.Instalacion;
        //            if(u.Empresa != null) {
        //                if(e != null)
        //                    if(u.Empresa.EmpresaId == e.EmpresaId) {
        //                        l.Add(usu);
        //                        yaAgregado = true;
        //                    }
        //            }
        //            if(u.Instalacion != null) {
        //                if(i != null)
        //                    if(u.Instalacion.InstalacionId == i.InstalacionId && !yaAgregado)
        //                        l.Add(usu);
        //            }
        //        }
        //    }
        //    return l;
        //}

        //public static IList<Revision> GetRevisionesPlanificadas(Usuario u, LainsaSci ctx)
        //{
        //    IList<Revision> l = (from r in ctx.Revisions
        //                         where r.Estado == "PLANIFICADA"
        //                         select r).ToList<Revision>();
        //    if (u.Empresa != null)
        //    {
        //        l = (from r in l
        //             where r.Dispositivo.Instalacion.Empresa.EmpresaId == u.Empresa.EmpresaId
        //             select r).ToList<Revision>();
        //    }
        //    if (u.Instalacion != null)
        //    {
        //        l = (from r in l
        //             where r.Dispositivo.Instalacion.InstalacionId == u.Instalacion.InstalacionId
        //             select r).ToList<Revision>();
        //    }
        //    return l;
        //}
        public static IList<Revision> GetRevisionesPlanificadas(Usuario u, LainsaSci ctx)
        {
            //IList<Revision> l = (from r in ctx.Revisions
            //                     where r.Estado == "PLANIFICADA" && r.Dispositivo.Operativo == true
            //                     select r).ToList<Revision>();
            List<Revision> l = (from r in ctx.Revisions
                                 where r.Estado == "PLANIFICADA"
                                 select r).ToList<Revision>();

            if (u.GrupoTrabajo != null)
            {
                IList<Revision> aux = new List<Revision>();
                foreach (Revision r in l)
                    if (r.Usuario != null && r.Usuario.GrupoTrabajo != null)
                        if (r.Usuario.GrupoTrabajo.GrupoTrabajoId == u.GrupoTrabajo.GrupoTrabajoId)
                            aux.Add(r);
                return aux;
            }
            else 
            {
                List<Revision> aux = new List<Revision>();
                foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                    IList<Revision> lr_tmp = new List<Revision>();
                    if(ue.Empresa != null && ue.Instalacion == null)
                        lr_tmp = (from r in l
                             where r.Dispositivo.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                             select r).ToList<Revision>();
                    else if(ue.Instalacion != null) {
                                  lr_tmp = (from r in l
                                  where r.Dispositivo.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                  select r).ToList<Revision>();
                    }
                    aux.AddRange(lr_tmp);
                }
                return aux;
            }
        }

        public static IList<Revision> GetRevisionesPlanificadas(Usuario u, DateTime? df, DateTime? hf, LainsaSci ctx)
        {
            IList<Revision> l = GetRevisionesPlanificadas(u, ctx);

            if (df != null)
            {
                l = (from r in l
                     where r.FechaPlanificada >= df
                     select r).ToList<Revision>();
                if (hf != null)
                {
                    l = (from r in l
                         where r.FechaPlanificada <= hf
                         select r).ToList<Revision>();
                }
            }
            else
            {
                if (hf != null)
                {
                    l = (from r in l
                         where r.FechaPlanificada <= hf
                         select r).ToList<Revision>();
                }
            }

            return l;
        }

        public static string EstadoPrograma(Programa p)
        {
            string estado = "";
            int i = 0; // contador de realizadas
            foreach (Revision r in p.Revisions)
            {
                if (r.Estado == "REALIZADA")
                    i++;
            }
            if (i == 0)
                estado = "SIN COMENZAR";
            else
            {
                if (i == p.Revisions.Count)
                    estado = "FINALIZADA";
                else
                    estado = "EN CURSO";
            }
            return estado;
        }

        public static IList<Dispositivo> NoCaducados(IList<Dispositivo> ldsp)
        {
            return (from d in ldsp
                    where d.Caducado == false
                    select d).ToList<Dispositivo>();
        }

        public static IList<Dispositivo> Operativos(IList<Dispositivo> ldsp)
        {
            return (from d in ldsp
                    where d.Operativo == true
                    select d).ToList<Dispositivo>();
        }

        public static Boolean ProgramaMezclado(Programa p)
        {
            if (p == null)
                return false;
            int id = 0;
            int provid = 0;
            bool primero = true;
            bool res = false;
            foreach (Revision r in p.Revisions)
            {
                id = r.Dispositivo.Instalacion.InstalacionId;
                if (provid != id && !primero)
                    res = true;
                provid = id;
                primero = false;
            }
            return res;
        }

        public static void EliminarRevisionesPendientes(Dispositivo dsp, LainsaSci ctx, Revision revision) 
        {
            foreach (Revision r in dsp.Revisiones)
            {
                if (r.Estado != "REALIZADA")
                    DeleteRevision(r, ctx);
            }
            ctx.SaveChanges();
        }

        public static int SiguienteGrupoProgramacion(LainsaSci ctx)
        {
            int valor = (from r in ctx.Revisions
                         select r.GrupoProgramacion).Max();
            return ++valor;
        }

        public static void AgruparCompanyeros(Revision r, Programa p, LainsaSci ctx)
        {
            if (r.GrupoProgramacion > 0)
                return;
            // buscamos otras revisones planificadas para el mismo dispositivo en un entorno de 15 dias
            DateTime minFecha = r.FechaPlanificada.AddDays(-15);
            DateTime maxFecha = r.FechaPlanificada.AddDays(15);
            var rs = (from r1 in r.Dispositivo.Revisiones
                      where r1.Estado == "PLANIFICADA" &&
                            (r1.FechaPlanificada >= minFecha && r1.FechaPlanificada <= maxFecha)
                      select r1);
            if (rs.Count() > 0)
            {
                int grpro = CntLainsaSci.SiguienteGrupoProgramacion(ctx);
                r.GrupoProgramacion = grpro;
                foreach (Revision r2 in rs)
                {
                    r2.GrupoProgramacion = grpro;
                    r2.Programa = p;
                }
            }
        }

        public static bool HayPlanificadaSuperior(DateTime fechaPlan, Revision rev, LainsaSci ctx)
        {
            bool res = false;
            int peso = 0;
            // 
            peso = CalculoPeso(rev.PlantillaRevision.TipoPeriodo);
            peso = peso * rev.PlantillaRevision.NumeroPeriodos;
            // buscamos que para la fecha indicada no haya planificada una de periodicidad superior
            int peso2 = 0;
            foreach (PlantillaRevision pr in rev.Dispositivo.TipoDispositivo.PlantillaRevisions)
            {
                peso2 = CalculoPeso(pr.TipoPeriodo) * pr.NumeroPeriodos;
                if (peso2 > peso)
                {
                    Revision rev2 = (from r in ctx.Revisions
                                     where r.Dispositivo.DispositivoId == rev.Dispositivo.DispositivoId &&
                                           r.PlantillaRevision.PlantillaId == pr.PlantillaId &&
                                           r.Estado == "PLANIFICADA" &&
                                           r.FechaPlanificada <= fechaPlan
                                     select r).FirstOrDefault<Revision>();
                    if (rev2 != null)
                        res = true;
                }
            }
            return res;
        }

        public static int CalculoPeso(string periodo)
        {
            int peso = 0;
            switch (periodo)
            {
                case "D":
                    peso = 1;
                    break;
                case "S":
                    peso = 7;
                    break;
                case "M":
                    peso = 30;
                    break;
                case "A":
                    peso = 365;
                    break;
            }
            return peso;
        }

        public static void ProgramarInferiores(Revision rev, LainsaSci ctx)
        {
            int peso = 0;
            // 
            peso = CalculoPeso(rev.PlantillaRevision.TipoPeriodo);
            peso = peso * rev.PlantillaRevision.NumeroPeriodos;
            // buscamos que para la fecha indicada no haya planificada una de periodicidad superior
            int peso2 = 0;
            foreach (PlantillaRevision pr in rev.Dispositivo.TipoDispositivo.PlantillaRevisions)
            {
                peso2 = CalculoPeso(pr.TipoPeriodo) * pr.NumeroPeriodos;
                if (peso2 < peso)
                {
                    // fake: una revisión de periodo inferior como si se hubiera hecho en la misma fecha
                    Revision rev2 = new Revision()
                    {
                        FechaRevision = rev.FechaRevision,
                        Dispositivo = rev.Dispositivo,
                        PlantillaRevision = pr,
                        Estado = "REALIZADA"
                    };
                    // Eliminar las anteriormente planificadas
                    var rs = from rx in ctx.Revisions
                             where rx.Dispositivo.DispositivoId == rev.Dispositivo.DispositivoId &&
                                   rx.PlantillaRevision.PlantillaId == pr.PlantillaId &&
                                   rx.FechaPlanificada > rev.FechaRevision &&
                                   rx.Estado != "REALIZADA"
                             select rx;
                    foreach (Revision rx in rs)
                    {
                        CntLainsaSci.DeleteRevision(rx, ctx);
                    }
                    ProgramarSiguienteRevision(rev2, ctx, false);
                }
            }
        }

        public static void EliminarInferiores(Revision rev, LainsaSci ctx)
        {
            int peso = 0;
            // 
            peso = CalculoPeso(rev.PlantillaRevision.TipoPeriodo);
            peso = peso * rev.PlantillaRevision.NumeroPeriodos;
            int peso2 = 0;
            foreach (PlantillaRevision pr in rev.Dispositivo.TipoDispositivo.PlantillaRevisions)
            {
                peso2 = CalculoPeso(pr.TipoPeriodo) * pr.NumeroPeriodos;
                if (peso2 < peso)
                {
                    Revision rev2 = (from r in ctx.Revisions
                                     where r.Dispositivo.DispositivoId == rev.Dispositivo.DispositivoId &&
                                           r.PlantillaRevision.PlantillaId == pr.PlantillaId &&
                                           r.FechaPlanificada < rev.FechaPlanificada &&
                                           r.Estado != "REALIZADA"
                                     select r).FirstOrDefault<Revision>();
                    if (rev2 != null)
                        DeleteRevision(rev2, ctx);
                }
            }
        }

        public static void EliminarPendientesDispositivo(Dispositivo dsp, LainsaSci ctx)
        {
            if (!dsp.Caducado)
                return;
            if (CntLainsaSci.FechaNula(dsp.FechaBaja))
                return;
            var rs = (from r in dsp.Revisiones
                      where r.FechaPlanificada >= dsp.FechaBaja
                      select r);
            foreach (Revision r in rs)
                DeleteRevision(r, ctx);
        }

        public static void DeleteRevision(Revision r, LainsaSci ctx)
        {
            // primero eliminamos sus datos
            ctx.Delete(r.DatosRevisions);
            // y ahora la revisón
            ctx.Delete(r);
            // ok y guardamos
            ctx.SaveChanges();
        }

        public static void EliminarProgramadasInferiores(Programa prog)
        {
            IList<Revision> lr = new List<Revision>(); // estas seran las menores
            int peso1 = 0;
            int peso2 = 0;
            foreach (Revision r in prog.Revisions)
            {
                peso1 = CalculoPeso(r.PlantillaRevision.TipoPeriodo);
                peso1 = peso1 * r.PlantillaRevision.NumeroPeriodos;
                // Hay alguno de peso inferior?
                foreach (Revision r2 in prog.Revisions)
                {
                    if (r2.Dispositivo.DispositivoId == r.Dispositivo.DispositivoId)
                    {
                        peso2 = CalculoPeso(r2.PlantillaRevision.TipoPeriodo);
                        peso2 = peso2 * r2.PlantillaRevision.NumeroPeriodos;
                        if (peso2 < peso1)
                            lr.Add(r2);
                    }
                }
            }
            foreach (Revision r in lr)
            {
                r.Programa = null;
            }
        }

        public static void 
        ProgramarSustituciones(Programa prog, LainsaSci ctx)
        {
            // primero buscamos si hay revisiones con marca de sustitución
            var rs = from r in prog.Revisions
                     where r.PlantillaRevision.ConSustitucion == true
                     select r;
            foreach (Revision rev in rs)
            {
                Sustitucion s = new Sustitucion()
                {
                    Fecha = prog.FechaProgramada,
                    DispositivoOriginal = rev.Dispositivo,
                    Estado = "PROGRAMADA",
                    Revision = rev,
                    Programa = prog
                };
                ctx.Add(s);
            }
        }

        public static IList<Dispositivo> GetPosiblesSustitutos(string nomParcial, Usuario usuario, Dispositivo dspOriginal, LainsaSci ctx)
        {
            IList<Dispositivo> dispositivos = GetDispositivos(nomParcial, usuario, ctx);
            return (from d in dispositivos
                    where d.Instalacion.Empresa.EmpresaId == dspOriginal.Instalacion.Empresa.EmpresaId &&
                          d.Estado == "A"
                    select d).ToList<Dispositivo>();
        }

        public static IList<Dispositivo> GetPosiblesSustitutos(Usuario usuario, Dispositivo dspOriginal, LainsaSci ctx)
        {
            IList<Dispositivo> dispositivos = GetDispositivos(usuario, ctx);
            dispositivos = (from d in dispositivos
                            where d.Instalacion.Empresa.EmpresaId == dspOriginal.Instalacion.Empresa.EmpresaId &&
                                  d.Estado == "A"
                            select d).ToList<Dispositivo>();
            return dispositivos;
        }

        public static IList<Dispositivo> GetPosiblesSustitutos(Dispositivo dspOriginal, LainsaSci ctx)
        {
            IList<Dispositivo> dispositivos = GetDispositivos(ctx);
            dispositivos = (from d in dispositivos
                            where d.Instalacion != null && d.Instalacion.Empresa.EmpresaId == dspOriginal.Instalacion.Empresa.EmpresaId &&
                                  d.Estado == "A"
                            select d).ToList<Dispositivo>();
            return dispositivos;
        }
    }
}