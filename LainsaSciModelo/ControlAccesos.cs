using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LainsaSciModelo
{
    public static partial class CntLainsaSci
    {
        // 
//        public static IList<Empresa> GetEmpresas(Usuario usu, LainsaSci ctx)
//        {
//            if (usu.Empresa == null) return ctx.Empresas.ToList<Empresa>();
//            return (from e in ctx.Empresas
//                    where e.EmpresaId == usu.Empresa.EmpresaId
//                    orderby e.Nombre
//                    select e).ToList<Empresa>();
 //       }
        //
        public static IList<Empresa> GetEmpresas(Usuario usu, LainsaSci ctx)
        {
            IList<Empresa> l = new List<Empresa>();
            List<Empresa> l_ret = new List<Empresa>();
            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas){
                if(ue.Empresa == null) l = ctx.Empresas.ToList<Empresa>();
                else l = (from e in ctx.Empresas
                        where e.EmpresaId == ue.Empresa.EmpresaId
                        orderby e.Nombre
                        select e).ToList<Empresa>();
                l_ret.AddRange(l);
            }
            return l_ret;
        }
 //       public static IList<Instalacion> GetInstalaciones(Usuario usu, LainsaSci ctx) {
 //           if(usu.Empresa == null) return ctx.Instalacions.OrderBy(x => x.Nombre).ToList<Instalacion>();
 //           if(usu.Instalacion == null) {
 //               return usu.Empresa.Instalaciones.OrderBy(x => x.Nombre).ToList<Instalacion>();
 //           } else {
 //               return (from i in ctx.Instalacions
 //                       where i.InstalacionId == usu.Instalacion.InstalacionId
 //                       orderby i.Nombre
 //                       select i).ToList<Instalacion>();
 //           }
 //       }

        public static IList<Instalacion> GetInstalaciones(Usuario usu, LainsaSci ctx) {

            IList<Instalacion> l = new List<Instalacion>();
            List<Instalacion> l_ret = new List<Instalacion>();
            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    l = ctx.Instalacions.OrderBy(x => x.Nombre).ToList<Instalacion>();
                } else if(ue.Instalacion == null) {
                    l = ue.Empresa.Instalaciones.OrderBy(x => x.Nombre).ToList<Instalacion>();
                } else {
                    l = (from i in ctx.Instalacions
                         where i.InstalacionId == ue.Instalacion.InstalacionId
                         orderby i.Nombre
                         select i).ToList<Instalacion>();
                }
                l_ret.AddRange(l);
            }
            return l_ret;
        }

        public static IList<Instalacion> GetInstalacionesEmpresa(Empresa e, Usuario usu, LainsaSci ctx)
        {

            IList<Instalacion> l = new List<Instalacion>();
            List<Instalacion> l_ret = new List<Instalacion>();
            foreach (UsuarioEmpresa ue in usu.UsuarioEmpresas)
            {
                if (ue.Empresa != null && (ue.Empresa.EmpresaId == e.EmpresaId))
                {
                    if (ue.Empresa == null)
                    {
                        l = ctx.Instalacions.OrderBy(x => x.Nombre).ToList<Instalacion>();
                    }
                    else if (ue.Instalacion == null)
                    {
                        l = ue.Empresa.Instalaciones.OrderBy(x => x.Nombre).ToList<Instalacion>();
                    }
                    else
                    {
                        l = (from i in ctx.Instalacions
                             where i.InstalacionId == ue.Instalacion.InstalacionId
                             orderby i.Nombre
                             select i).ToList<Instalacion>();
                    }
                    l_ret.AddRange(l);
                }
            }
            return l_ret;
        }

        public static IList<Dispositivo> GetDispositivos(Usuario u, LainsaSci ctx) {
            IList<Dispositivo> dsps = new List<Dispositivo>();
            List<Dispositivo> dpsps_ret = new List<Dispositivo>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null){ dsps = ctx.Dispositivos.ToList<Dispositivo>();
            }else if(ue.Instalacion == null) {
                   dsps = (from d in ctx.Dispositivos
                                   where d.Instalacion != null && d.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                   select d).ToList<Dispositivo>();
                } else {
                   dsps = (from d in ctx.Dispositivos
                                   where d.Instalacion != null && d.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                   select d).ToList<Dispositivo>();
                }
                dpsps_ret.AddRange(dsps);
            }
            return dpsps_ret;
        }
        public static IList<Dispositivo> GetDispositivos(Usuario usu, bool caducados, LainsaSci ctx)
        {
            IList<Dispositivo> dsps = new List<Dispositivo>();
            List<Dispositivo> dsps_ret = new List<Dispositivo>();
            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null)  dsps = (from d in ctx.Dispositivos
                                                       where d.Caducado == caducados
                                                       select d).ToList<Dispositivo>();
                if(ue.Instalacion == null) {
                     dsps = (from d in ctx.Dispositivos
                                   where d.Instalacion != null && d.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                   && d.Caducado == caducados
                                   select d).ToList<Dispositivo>();
                } else {
                     dsps = (from d in ctx.Dispositivos
                                   where d.Instalacion != null && d.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                   && d.Caducado == caducados
                                   select d).ToList<Dispositivo>();
                }
                dsps_ret.AddRange(dsps);
            }
            return dsps_ret;
        }
        public static IList<Dispositivo> GetDispositivos(string nomParcial, Usuario usu, LainsaSci ctx)
        {
            IList<Dispositivo> dsps = (from d in ctx.Dispositivos
                                           where d.Nombre.StartsWith(nomParcial)
                                           select d).ToList<Dispositivo>();
            List<Dispositivo> dsps_ret = new List<Dispositivo>();

            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null) dsps = (from d in ctx.Dispositivos
                                               where d.Nombre.StartsWith(nomParcial)
                                               select d).ToList<Dispositivo>();
                if(ue.Instalacion == null) {
                     dsps = (from d in dsps
                                   where d.Instalacion != null && d.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                   select d).ToList<Dispositivo>();
                } else {
                     dsps = (from d in dsps
                                   where d.Instalacion != null && d.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                   select d).ToList<Dispositivo>();
                }
                dsps_ret.AddRange(dsps);
            }
            return dsps_ret;
        }
        public static IList<Dispositivo> GetDispositivos(string nomParcial, Usuario usu, bool caducados, LainsaSci ctx)
        {
            IList<Dispositivo> dsps = (from d in ctx.Dispositivos
                                       where d.Nombre.StartsWith(nomParcial)
                                       && d.Caducado == caducados
                                       select d).ToList<Dispositivo>();
            List<Dispositivo> dsps_ret = new List<Dispositivo>();
            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {

                if(ue.Empresa == null) dsps = (from d in ctx.Dispositivos
                                               where d.Nombre.StartsWith(nomParcial)
                                               && d.Caducado == caducados
                                               select d).ToList<Dispositivo>();
                if(ue.Instalacion == null) {
                    dsps = (from d in dsps
                            where d.Instalacion != null && d.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                            && d.Caducado == caducados
                            select d).ToList<Dispositivo>();
                } else {
                    dsps = (from d in dsps
                            where d.Instalacion != null && d.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                            && d.Caducado == caducados
                            select d).ToList<Dispositivo>();
                }
                dsps_ret.AddRange(dsps);
            }
            return dsps_ret;
        }
        public static IList<TipoDispositivo> GetTipoDispositivos(Usuario usu, LainsaSci ctx)
        {

            List<TipoDispositivo> ldp = new List<TipoDispositivo>();
            List<TipoDispositivo> ldp0 = new List<TipoDispositivo>();
            List<TipoDispositivo> ldp1 = new List<TipoDispositivo>();
            List<TipoDispositivo> ldp2 = new List<TipoDispositivo>();
            // Hay tres listas posibles.
            // 0 - No pertenecen a ninguna empresa ni instalacion
            ldp0 = (from tp in ctx.TipoDispositivos
                                           where tp.Empresa == null
                                           && tp.Instalacion == null
                                           select tp).ToList();
            bool esAdmin = false;

            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null && ue.Instalacion == null) {
                    esAdmin = true;
                    break;
                }
            }
            
            // Valoramos los tres casos posibles
            if (esAdmin)
            {
                ldp = ctx.TipoDispositivos.ToList<TipoDispositivo>();
            }
            else
            {

                ldp.AddRange(ldp0);

                foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                    if(ue.Empresa != null && ue.Instalacion == null) {
                        // 1 - Pertenecen a la empresa pero a ninguna instalacion
                        ldp1 = (from tp in ctx.TipoDispositivos
                                where tp.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                select tp).ToList();
                        ldp.AddRange(ldp1);
                    } else {
                        // 2 - Pertenecen a la empresa y a esta instalacion
                        ldp2 = (from tp in ctx.TipoDispositivos
                                where tp.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                && (tp.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                || tp.Instalacion == null)
                                select tp).ToList();
                        ldp.AddRange(ldp2);
                    }

                }

            }
            return ldp;
        }

        public static IList<ModeloDispositivo> GetModeloDispositivos(Usuario usu, LainsaSci ctx)
        {

            List<ModeloDispositivo> ldp = new List<ModeloDispositivo>();
            List<ModeloDispositivo> ldp0 = new List<ModeloDispositivo>();
            List<ModeloDispositivo> ldp1 = new List<ModeloDispositivo>();
            List<ModeloDispositivo> ldp2 = new List<ModeloDispositivo>();
            // Hay tres listas posibles.
            // 0 - No pertenecen a ninguna empresa ni instalacion
            ldp0 = (from tp in ctx.ModeloDispositivos
                    where tp.Empresa == null
                    && tp.Instalacion == null
                    select tp).ToList();

            bool esAdmin = false;

            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null && ue.Instalacion == null) {
                    esAdmin = true;
                    break;
                }
            }

            // Valoramos los tres casos posibles
            if (esAdmin)
            {
                ldp = ctx.ModeloDispositivos.ToList<ModeloDispositivo>();
            }
            else
            {
                ldp.AddRange(ldp0);
                foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                    if(ue.Empresa != null && ue.Instalacion == null) {
                        // 1 - Pertenecen a la empresa pero a ninguna instalacion
                        ldp1 = (from tp in ctx.ModeloDispositivos
                                where tp.Empresa != null && (tp.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                || tp.Instalacion == null)
                                select tp).ToList();
                        ldp = ldp0.Concat(ldp1).ToList<ModeloDispositivo>();

                    } else {
                        // 2 - Pertenecen a la empresa y a esta instalacion
                        ldp2 = (from tp in ctx.ModeloDispositivos
                                where tp.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                && tp.Instalacion != null && tp.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                || tp.Instalacion.InstalacionId == null select tp).ToList();
                        ldp = ldp0.Concat(ldp1).ToList<ModeloDispositivo>().Concat(ldp2).ToList<ModeloDispositivo>();
                    }
                }
            }
            return ldp;
        }
        public static IList<PlantillaRevision> GetPlantillaRevisiones(Usuario usu, LainsaSci ctx)
        {
            IList<PlantillaRevision> pss = new List<PlantillaRevision>();
            foreach (TipoDispositivo td in GetTipoDispositivos(usu, ctx))
            {
                foreach (PlantillaRevision p in td.PlantillaRevisions)
                    pss.Add(p);
            }
            return pss;
        }
        public static IList<PlantillaRevision> GetPlantillaRevisiones(TipoDispositivo tipo, Usuario usu, LainsaSci ctx)
        {
            IList<PlantillaRevision> pss = new List<PlantillaRevision>();
            foreach (PlantillaRevision p in tipo.PlantillaRevisions)
                pss.Add(p);
            return pss;
        }
        //public static IList<Revision> GetRevisiones(Usuario usu, LainsaSci ctx)
        //{
        //    IList<Revision> rss = new List<Revision>();
        //    foreach (Dispositivo dsp in GetDispositivos(usu, ctx)) 
        //    {
        //        foreach (Revision r in dsp.Revisiones)
        //            rss.Add(r);
        //    }
        //    return rss;
        //}
        public static IList<Revision> GetRevisiones(Usuario u, LainsaSci ctx)
        {
            IList<Revision> rss = new List<Revision>();
            foreach (Dispositivo dsp in GetDispositivos(u, ctx))
            {
                foreach (Revision r in dsp.Revisiones)
                    rss.Add(r);
            }
            return rss;
        }
        public static IList<Revision> GetRevisiones(Usuario u, GrupoTrabajo gt, LainsaSci ctx)
        {
            IList<Revision> rss = new List<Revision>();
            foreach (Dispositivo dsp in GetDispositivos(ctx))
            {
                foreach (Revision r in dsp.Revisiones)
                {
                    if (r.Usuario != null)
                        if (r.Usuario.GrupoTrabajo != null)
                            if (r.Usuario.GrupoTrabajo.GrupoTrabajoId == u.GrupoTrabajo.GrupoTrabajoId)
                                rss.Add(r);
                }
            }
            return rss;
        }
        
    }
}
