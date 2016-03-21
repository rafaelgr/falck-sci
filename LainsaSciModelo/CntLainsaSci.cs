using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;
using System.Security.Cryptography;

namespace LainsaSciModelo
{
    public static partial class CntLainsaSci
    {
        #region Métodos generales del contexto
        public static void CTXAgregar(Object o, LainsaSci ctx)
        {
            ctx.Add(o);
        }

        public static void CTXEliminar(Object o, LainsaSci ctx)
        {
            ctx.Delete(o);
        }

        public static void CTXCerrar(LainsaSci ctx)
        {
            ctx.Dispose();
        }

        public static void CTXGuardar(LainsaSci ctx)
        {
            ctx.SaveChanges();
        }
        #endregion

        #region Encriptación
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

        #endregion

        #region Login
        public static Usuario Login(string password, string login, LainsaSci ctx)
        {
            // first: check if the Usuario exists
            Usuario Usuario = (from u in ctx.Usuarios
                               where u.Login == login
                               select u).FirstOrDefault<Usuario>();
            if (Usuario == null)
                return null; // Usuario doesn't exists
            if (Usuario.Password != GetHashCode(password))
                return null; // incorrect password
            return Usuario;
        }

        public static Usuario EncryptPassword(Usuario Usuario, string plain)
        {
            Usuario.Password = GetHashCode(plain);
            return Usuario;
        }

        #endregion

        #region Métodos de usuarios, procesos y permisos
        public static IList<GrupoUsuario> GetGruposUsuarios(LainsaSci ctx)
        {
            return (from gu in ctx.GrupoUsuarios
                    select gu).ToList<GrupoUsuario>();
        }
        public static IList<GrupoUsuario> GetGruposUsuarios(string nombre, LainsaSci ctx)
        {
            return (from gu in ctx.GrupoUsuarios
                    where gu.Nombre.StartsWith(nombre)
                    select gu).ToList<GrupoUsuario>();
        }
        public static GrupoUsuario GetGrupoUsuario(int id, LainsaSci ctx)
        {
            return (from gu in ctx.GrupoUsuarios
                    where gu.GrupoUsuarioId == id
                    select gu).FirstOrDefault<GrupoUsuario>();
        }

        public static IList<Usuario> GetUsuarios(LainsaSci ctx)
        {
            return (from u in ctx.Usuarios
                    select u).ToList<Usuario>();
        }

        public static Usuario GetUsuario(int id, LainsaSci ctx) {
            return (from u in ctx.Usuarios
                    where u.UsuarioId == id
                    select u).FirstOrDefault<Usuario>();
        }        

        public static UsuarioEmpresa GetUsuarioEmpresa(int id, Usuario u, LainsaSci ctx)
        {
            return (from ue in u.UsuarioEmpresas
                    where ue.Usuario_empresa_id == id
                    select ue).FirstOrDefault<UsuarioEmpresa>();
        }      

        

        public static Usuario GetUsuario(string login, LainsaSci ctx)
        {
            return (from u in ctx.Usuarios
                    where u.Login == login
                    select u).FirstOrDefault<Usuario>();
        }

        public static IList<GrupoTrabajo> GetGruposTrabajos(LainsaSci ctx)
        {
            return (from gt in ctx.GrupoTrabajos
                    select gt).ToList<GrupoTrabajo>();
        }
        public static IList<GrupoTrabajo> GetGruposTrabajos(string nombre, LainsaSci ctx)
        {
            return (from gt in ctx.GrupoTrabajos
                    where gt.Nombre.StartsWith(nombre)
                    select gt).ToList<GrupoTrabajo>();
        }
        public static GrupoTrabajo GetGrupoTrabajo(int id, LainsaSci ctx)
        {
            return (from gt in ctx.GrupoTrabajos
                    where gt.GrupoTrabajoId == id
                    select gt).FirstOrDefault<GrupoTrabajo>();
        }
        public static void DeleteGrupoTrabajo(GrupoTrabajo gt, LainsaSci ctx)
        {
            if (gt.Usuarios != null)
                foreach (Usuario u in gt.Usuarios)
                    u.GrupoTrabajo = null;
            ctx.Delete(gt);
            ctx.SaveChanges();
        }

        public static IList<Proceso> GetProcesos(LainsaSci ctx)
        {
            return (from pr in ctx.Procesos
                    select pr).ToList<Proceso>();
        }

        public static IList<Proceso> GetProcesos(string nombre, LainsaSci ctx)
        {
            return (from pr in ctx.Procesos
                    where pr.Nombre.StartsWith(nombre)
                    select pr).ToList<Proceso>();
        }
        public static Proceso GetProceso(string nombre, LainsaSci ctx)
        {
            return (from pr in ctx.Procesos
                    where pr.Nombre == nombre
                    select pr).FirstOrDefault<Proceso>();
        }

        public static IList<Permiso> GetPermisos(LainsaSci ctx)
        {
            return (from p in ctx.Permisos
                    select p).ToList<Permiso>();
        }
        public static IList<Permiso> GetPermisos(GrupoUsuario gpu, LainsaSci ctx)
        {
            return (from p in ctx.Permisos
                    where p.GrupoUsuario.GrupoUsuarioId == gpu.GrupoUsuarioId
                    select p).ToList<Permiso>();
        }

        public static Permiso GetPermiso(int id, LainsaSci ctx)
        {
            return (from p in ctx.Permisos
                    where p.PermisoId == id
                    select p).FirstOrDefault<Permiso>();
        }

        public static Permiso GetPermiso(GrupoUsuario gu, string nomproceso, LainsaSci ctx)
        {
            return (from p in ctx.Permisos
                    where p.GrupoUsuario.GrupoUsuarioId == gu.GrupoUsuarioId && p.Proceso.Nombre == nomproceso
                    select p).FirstOrDefault<Permiso>();
        }
        public static void CrearPermisos(Proceso pro, LainsaSci ctx)
        {
            // Buscamos para todos los grupos de usuarios
            foreach (GrupoUsuario gpu in ctx.GrupoUsuarios)
            {
                Permiso per = GetPermiso(gpu, pro.Nombre, ctx);
                if (per == null)
                {
                    per = new Permiso();
                    per.Proceso = pro;
                    per.GrupoUsuario = gpu;
                    per.Ver = true; // por defecto los usuarios ven
                    per.Crear = false; // no puden crear por defecto
                    per.Modificar = false; // lo mismo para modificar
                    per.Especial = false; // idem para especial
                    ctx.Add(per);
                    ctx.SaveChanges();
                }
            }
        }

        public static Permiso GetPermiso(GrupoUsuario grupoUsuario, Proceso proc, LainsaSci ctx)
        {
            return (from p in ctx.Permisos
                    where p.GrupoUsuario.GrupoUsuarioId == grupoUsuario.GrupoUsuarioId
                    && p.Proceso.Nombre == proc.Nombre
                    select p).FirstOrDefault<Permiso>();
        }

        public static IList<PermissionView> GetPermissionsViews(GrupoUsuario ug)
        {
            IList<PermissionView> perviews = new List<PermissionView>();
            foreach (Permiso per in ug.Permisos)
            {
                PermissionView pw = new PermissionView();
                pw.PermissionId = per.PermisoId;
                pw.Name = per.Proceso.Descripcion;
                pw.ProcessId = per.Proceso.Nombre;
                if (per.Proceso.ProcesoPadre != null)
                    pw.ParentProcessId = per.Proceso.ProcesoPadre.Nombre;
                else
                    pw.ParentProcessId = "";
                pw.View = per.Ver;
                pw.Create = per.Crear;
                pw.Modify = per.Modificar;
                pw.Execute = per.Especial;
                perviews.Add(pw);
            }
            return perviews;
        }

        public static void VerifyPermissions(GrupoUsuario ug, LainsaSci ctx)
        {
            foreach (Proceso pr in ctx.Procesos)
            {
                Permiso per = (from p in ctx.Permisos
                               where p.GrupoUsuario.GrupoUsuarioId == ug.GrupoUsuarioId && p.Proceso.Nombre == pr.Nombre
                               select p).FirstOrDefault<Permiso>();
                if (per == null)
                {
                    // permission doesn't exists for this Usuario group
                    // we create one.
                    per = new Permiso();
                    per.GrupoUsuario = ug;
                    per.Proceso = pr;
                    // default permissions are asigned.
                    per.Ver = true;
                    per.Crear = false;
                    per.Modificar = false;
                    per.Especial = false;
                    ctx.Add(per);
                }
            }
            ctx.SaveChanges();
        }

        public static void DelProceso(Proceso proc, LainsaSci ctx)
        {
            Permiso per = (from p in ctx.Permisos
                           where p.Proceso == proc
                           select p).FirstOrDefault<Permiso>();
            ctx.Delete(per);
            ctx.Delete(proc);
        }
        #endregion

        #region Métodos referidos a clases de AXAPTA
        public static IList<Empresa> GetEmpresas(LainsaSci ctx)
        {
            return (from e in ctx.Empresas
                    select e).ToList<Empresa>();
        }
        //public static IList<Empresa> GetEmpresas(string nomParcial, LainsaSci ctx)
        //{
        //    return (from e in ctx.Empresas
        //            where e.Nombre.StartsWith(nomParcial)
        //            select e).ToList<Empresa>();
        //}

        public static IList<Empresa> GetEmpresas(string nomParcial, Usuario u, LainsaSci ctx) {
            IList<Empresa> le = new List<Empresa>();
            List<Empresa> le_ret = new List<Empresa>();
            le = (from e in ctx.Empresas
                        where e.Nombre.StartsWith(nomParcial)
                        select e).ToList<Empresa>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa != null) {
                    le = (from e in le
                          where e.EmpresaId == ue.Empresa.EmpresaId
                          select e).ToList<Empresa>();
                }
                le_ret.AddRange(le);
            }
            return le_ret;
        }


        public static Empresa GetEmpresa(int id, LainsaSci ctx)
        {
            return (from e in ctx.Empresas
                    where e.EmpresaId == id
                    select e).FirstOrDefault<Empresa>();
        }
        public static UTPParametros GetUTPParametros(LainsaSci ctx)
        {
            return (from utpp in ctx.UTPParametros
                    select utpp).FirstOrDefault<UTPParametros>();
        }
        #endregion

        #region Utilidades
        public static bool FechaNula(DateTime? fecha)
        {
            if (fecha == null || fecha.ToString() == "01/01/0001 0:00:00" || fecha.ToString() == "0000-00-00 00:00:00")
                return true;
            else
                return false;
        }

        public enum TipoPeriodo
        {
            días = 1, semanas, meses, años
        };

        public enum EstadoRevision
        {
            Planificada = 1, Programada, Realizada
        };

        public enum TipoCampoP
        {
            Campo_Si_No = 1, Texto, Memo, Numerico, Fecha
        };

        #endregion

        public static Direccion GetDireccion(int DireccionId, LainsaSci ctx)
        {
            return (from a in ctx.Direccions
                    where a.DireccionId == DireccionId
                    select a).FirstOrDefault<Direccion>();
        }
        public static IList<Direccion> GetDirecciones(LainsaSci ctx)
        {
            return ctx.Direccions.ToList<Direccion>();
        }
        public static IList<Direccion> GetDirecciones(Empresa empresa, LainsaSci ctx)
        {
            return (from d in ctx.Direccions
                    where d.Empresa.EmpresaId == empresa.EmpresaId
                    select d).ToList<Direccion>();
        }
        public static IList<Direccion> GetDirecciones(Instalacion instalacion, LainsaSci ctx)
        {
            return (from d in ctx.Direccions
                    where d.Instalacion.InstalacionId == instalacion.InstalacionId
                    select d).ToList<Direccion>();
        }
        public static IList<DireccionView> GetDireccionesView(LainsaSci ctx)
        {
            IList<DireccionView> dwl = new List<DireccionView>();
            foreach (Direccion d in GetDirecciones(ctx))
            {
                DireccionView dw = new DireccionView();
                dw.Direccion = d;
                if (d.Empresa != null) dw.Poseedor = d.Empresa.Nombre;
                if (d.Instalacion != null) dw.Poseedor = d.Instalacion.Nombre;
            }
            return dwl;
        }
        public static Email GetEmail(int EmailId, LainsaSci ctx)
        {
            return (from e in ctx.Emails
                    where e.EmailId == EmailId
                    select e).FirstOrDefault<Email>();
        }
        public static Telefono GetTelefono(int TelefonoId, LainsaSci ctx)
        {
            return (from t in ctx.Telefonos
                    where t.TelefonoId == TelefonoId
                    select t).FirstOrDefault<Telefono>();
        }
        public static Instalacion GetInstalacion(int id, LainsaSci ctx)
        {
            return (from i in ctx.Instalacions
                    where i.InstalacionId == id
                    select i).FirstOrDefault<Instalacion>();
        }
        public static IList<Instalacion> GetInstalaciones(LainsaSci ctx)
        {
            return ctx.Instalacions.ToList<Instalacion>();

        }
        public static Instalacion GetInstalacion(string nomParcial, LainsaSci ctx)
        {
            return (from i in ctx.Instalacions
                    where i.Nombre == nomParcial
                    select i).FirstOrDefault<Instalacion>();
        }
        public static IList<Instalacion> GetInstalaciones(string nomParcial, LainsaSci ctx)
        {
            return (from i in ctx.Instalacions
                    where i.Nombre.StartsWith(nomParcial)
                    select i).ToList<Instalacion>();
        }


        public static IList<Instalacion> GetInstalaciones(Empresa e, Usuario u, LainsaSci ctx){

            IList<Instalacion> l = new List<Instalacion>();
            IList<Instalacion> l2 = new List<Instalacion>();
            List<Instalacion> l_ret = new List<Instalacion>();
            l = (from i in ctx.Instalacions
                 where i.Empresa.EmpresaId == e.EmpresaId
                 select i).ToList<Instalacion>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    l2 = l;
                }else if(ue.Instalacion == null) {
                    l2 = (from i in l
                         where i.Empresa.EmpresaId == ue.Empresa.EmpresaId
                         select i).ToList<Instalacion>();
                }else{
                    l2 = (from i in l
                         where i.InstalacionId == ue.Instalacion.InstalacionId
                         select i).ToList<Instalacion>();
                }
                foreach(Instalacion i in l2) {
                    if(!l_ret.Contains(i)) {
                        l_ret.Add(i);
                    }
                }
            }
            return l_ret;
             
        }

        public static IList<Instalacion> GetInstalaciones(string nomParcial, Usuario u, LainsaSci ctx)
        {
            IList<Instalacion> l = new List<Instalacion>();
            List<Instalacion> l_ret = new List<Instalacion>();
            l = (from i in ctx.Instalacions
                 where i.Nombre.StartsWith(nomParcial)
                 select i).ToList<Instalacion>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa != null) {
                    l = (from i in l
                         where i.Empresa.EmpresaId == ue.Empresa.EmpresaId
                         select i).ToList<Instalacion>();
                }
                if(ue.Instalacion != null) {
                    l = (from i in l
                         where i.InstalacionId == ue.Instalacion.InstalacionId
                         select i).ToList<Instalacion>();
                }
                l_ret.AddRange(l);
            }
            return l_ret;
        }
        public static IList<Instalacion> GetInstalacionesSinEmpresa(LainsaSci ctx)
        {
            return (from i in ctx.Instalacions
                    where i.Empresa == null
                    select i).ToList<Instalacion>();
        }
        public static Operario GetOperario(int idOperario, LainsaSci ctx)
        {
            return (from i in ctx.Operarios
                    where i.OperarioId == idOperario
                    select i).FirstOrDefault<Operario>();
        }
        public static IList<Operario> GetOperarios(LainsaSci ctx)
        {
            return ctx.Operarios.ToList<Operario>();

        }
        //public static IList<TipoDispositivo> GetTiposDispositivo(string nomParcial, LainsaSci ctx)
        //{
        //    return (from t in ctx.TipoDispositivos
        //            where t.Nombre.StartsWith(nomParcial)
        //            select t).ToList<TipoDispositivo>();
        //}
        public static IList<TipoDispositivo> GetTiposDispositivo(string nomParcial, Usuario u, LainsaSci ctx)
        {

            IList<TipoDispositivo> l = new List<TipoDispositivo>();
            List<TipoDispositivo> l_ret = new List<TipoDispositivo>();
            l = (from t in ctx.TipoDispositivos
                 where t.Nombre.StartsWith(nomParcial)
                 select t).ToList<TipoDispositivo>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa != null) l = (from t in l
                                           where t.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                           select t).ToList<TipoDispositivo>();
                if(ue.Instalacion != null) l = (from t in l
                                               where t.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                                               select t).ToList<TipoDispositivo>();
                l_ret.AddRange(l);
            }
            return l_ret;
        }
        public static IList<TipoDispositivo> GetTiposDispositivo(LainsaSci ctx)
        {
            return (from t in ctx.TipoDispositivos
                    select t).ToList<TipoDispositivo>();
        }
        public static TipoDispositivo GetTiposDispositivo(int id, LainsaSci ctx)
        {
            return (from t in ctx.TipoDispositivos
                    where t.TipoId == id
                    select t).FirstOrDefault<TipoDispositivo>();
        }
        public static IList<ModeloDispositivo> GetModelodispositivos(string nomParcial, LainsaSci ctx)
        {
            return (from m in ctx.ModeloDispositivos
                    where m.Nombre.StartsWith(nomParcial)
                    select m).ToList<ModeloDispositivo>();
        }
        public static IList<ModeloDispositivo> GetModelodispositivo(LainsaSci ctx)
        {
            return (from m in ctx.ModeloDispositivos
                    select m).ToList<ModeloDispositivo>();
        }
        public static ModeloDispositivo GetModelodispositivo(int id, LainsaSci ctx)
        {
            return (from m in ctx.ModeloDispositivos
                    where m.ModeloId == id
                    select m).FirstOrDefault<ModeloDispositivo>();
        }
        public static ModeloDispositivo GetModelodispositivo(string nomParcial, LainsaSci ctx)
        {
            return (from m in ctx.ModeloDispositivos
                    where m.Nombre == nomParcial
                    select m).FirstOrDefault<ModeloDispositivo>();
        }
        public static Dispositivo GetDispositivo(int id, LainsaSci ctx)
        {
            return (from d in ctx.Dispositivos
                    where d.DispositivoId == id
                    select d).FirstOrDefault<Dispositivo>();
        }
        public static List<Dispositivo> GetDispositivos(LainsaSci ctx)
        {
            return (from d in ctx.Dispositivos
                    where d.DispositivoPadre == null
                    select d).ToList<Dispositivo>();
        }
        public static Incidencia GetIncidencia(int id, LainsaSci ctx)
        {
            return (from i in ctx.Incidencias
                    where i.IncidenciaId== id
                    select i).FirstOrDefault<Incidencia>();
        }
        public static IList<Incidencia> GetIncidencias(LainsaSci ctx) {
            return (from i in ctx.Incidencias
                    select i).ToList<Incidencia>();
        }

        public static IncidenciaEvolucion GetIncidenciaEvolucionComentario(Incidencia i, LainsaSci ctx) {
            IncidenciaEvolucion ultimaEvolucion = new IncidenciaEvolucion();
            foreach(IncidenciaEvolucion r in i.IncidenciaEvolucions) {
                if(ultimaEvolucion.FechaEvolucion == null || ultimaEvolucion.FechaEvolucion <= r.FechaEvolucion) {
                    ultimaEvolucion = r;
                }
            }
            return ultimaEvolucion;
        }

        public static IList<Incidencia> GetIncidenciaComentario(Usuario u, LainsaSci ctx) {


            IList<Incidencia> li = new List<Incidencia>();
            List<Incidencia> li_ret = new List<Incidencia>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    // usuario general, los tiene todos.
                    foreach(Incidencia e in (from i in ctx.Incidencias select i).ToList<Incidencia>()) {
                        Incidencia eaux = new Incidencia();
                        eaux.Comentarios = GetIncidenciaEvolucionComentario(e, ctx).Comentarios;
                        if(eaux.Comentarios != null) {
                            e.Comentarios = eaux.Comentarios;
                        } else {
                            e.Comentarios = "No hay Evoluciones";
                        }
                        li.Add(e);
                    }
                } else {
                    foreach(Incidencia e in (from i in ctx.Incidencias where i.Dispositivo.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                             select i).ToList<Incidencia>()) {
                        Incidencia eaux = new Incidencia();
                        eaux.Comentarios = GetIncidenciaEvolucionComentario(e, ctx).Comentarios;
                        if(eaux.Comentarios != null) {
                            e.Comentarios = eaux.Comentarios;
                        } else {
                            e.Comentarios = "No hay Evoluciones";
                        }
                        li.Add(e);
                    }
                }
                foreach(Incidencia i in li) {
                    if(!li_ret.Contains(i)) {
                        li_ret.Add(i);
                    }
                }
//                li_ret.AddRange(li);
            }
            return li_ret;
        }
//        public static IList<Incidencia> GetIncidenciaComentario(Usuario u, LainsaSci ctx) {


//            IList<Incidencia> li = new List<Incidencia>();
    //        if(u.Empresa == null) {
                // usuario general, los tiene todos.
      //          li = (from i in ctx.Incidencias
                   //   select i).ToList<Incidencia>();
        //    } else {
          //      li = (from i in ctx.Incidencias
            //          where i.Dispositivo.Instalacion.Empresa.EmpresaId == u.Empresa.EmpresaId
              //        select i).ToList<Incidencia>();
           // }

            //return li;
//        }

        public static IList<Incidencia> GetIncidencias(Usuario u, LainsaSci ctx) {


            IList<Incidencia> li = new List<Incidencia>();
            List<Incidencia> li_ret = new List<Incidencia>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    // usuario general, los tiene todos.
                    li = (from i in ctx.Incidencias
                          select i).ToList<Incidencia>();
                }else if(ue.Instalacion==null){
                    li = (from i in ctx.Incidencias
                          where i.Dispositivo.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                          select i).ToList<Incidencia>();

                } else {
                    li = (from i in ctx.Incidencias
                          where i.Dispositivo.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                          select i).ToList<Incidencia>();
                }
                foreach(Incidencia i in li) {
                    if(!li_ret.Contains(i)) {
                        li_ret.Add(i);
                    }
                }
            }
            return li;
        }

        public static List<IncidenciaEvolucion> GetIncidenciaEvolucions(LainsaSci ctx)
        {
            return (from i in ctx.IncidenciaEvolucions
                    select i).ToList<IncidenciaEvolucion>();
        }
        public static IncidenciaEvolucion GetIncidenciaEvolucion(int id, LainsaSci ctx)
        {
            return (from i in ctx.IncidenciaEvolucions
                    where i.IncidenciaEvolucionId == id
                    select i).FirstOrDefault<IncidenciaEvolucion>();
        }

        
        
        public static ModeloDispositivo GetModeloDispositivo(int id, LainsaSci ctx)
        {
            return (from d in ctx.ModeloDispositivos
                    where d.ModeloId == id
                    select d).FirstOrDefault<ModeloDispositivo>();
        }

        public static List<ModeloDispositivo> GetModeloDispositivos(LainsaSci ctx)
        {
            return (from d in ctx.ModeloDispositivos
                    select d).ToList<ModeloDispositivo>();
        }

        public static TipoDispositivo GetTipoDispositivo(int id, LainsaSci ctx)
        {
            return (from d in ctx.TipoDispositivos
                    where d.TipoId == id
                    select d).FirstOrDefault<TipoDispositivo>();
        }
        public static TipoDispositivo GetTipoDispositivo(string nom, LainsaSci ctx)
        {
            return (from d in ctx.TipoDispositivos
                    where d.Nombre == nom
                    select d).FirstOrDefault<TipoDispositivo>();
        }
        public static List<TipoDispositivo> GetTipoDispositivos(LainsaSci ctx)
        {
            return (from d in ctx.TipoDispositivos
                    select d).ToList<TipoDispositivo>();
        }

        public static List<Dispositivo> GetDispositivo(string nomParcial, LainsaSci ctx)
        {
            return (from d in ctx.Dispositivos
                    where d.Nombre.StartsWith(nomParcial)
                    select d).ToList<Dispositivo>();
        }
        public static Dispositivo GetLastDispositivo(LainsaSci ctx)
        {
            return ctx.Dispositivos.Last();
        }

        //public static List<Accesorio> getAccesorio(string nomParcial, LainsaSci ctx)
        //{
        //    return (from a in ctx.Accesorios
        //            where a.Descripcion.StartsWith(nomParcial)
        //            select a).ToList<Accesorio>();
        //}

        //public static IList<Accesorio> GetAccesorios(LainsaSci ctx)
        //{
        //    return ctx.Accesorios.ToList<Accesorio>();
        //}

        //public static Accesorio GetAccesorio(int id, LainsaSci ctx)
        //{
        //    return (from a in ctx.Accesorios
        //            where a.AccesorioId == id
        //            select a).FirstOrDefault<Accesorio>();
        //}

        //public static AccesorioAsignado getAccesorioAsignado(Dispositivo dispositivo, Accesorio accesorio)
        //{
        //    return (from a in dispositivo.AccesorioAsignados
        //            where a.Accesorio.AccesorioId == accesorio.AccesorioId
        //            select a).FirstOrDefault<AccesorioAsignado>();
        //}

        //public static List<Accesorio> getAccesorios(Dispositivo dispositivo, LainsaSci ctx)
        //{
        //    return (from acc in dispositivo.AccesorioAsignados
        //            select acc.Accesorio).ToList<Accesorio>();
        //}

        public static PlantillaRevision GetPlantillaRevision(int idPlantilla, LainsaSci ctx)
        {
            return (from a in ctx.PlantillaRevisions
                    where a.PlantillaId == idPlantilla
                    select a).FirstOrDefault<PlantillaRevision>();
        }

        public static List<PlantillaRevision> GetPlantillaRevisiones(LainsaSci ctx)
        {
            return (from a in ctx.PlantillaRevisions
                    select a).ToList<PlantillaRevision>();
        }

        public static List<PlantillaRevision> GetPlantillaRevisiones(string nomParcial, LainsaSci ctx)
        {
            return (from p in ctx.PlantillaRevisions
                    where p.Descripcion.StartsWith(nomParcial)
                    select p).ToList<PlantillaRevision>();
        }

        public static List<TipoCampo> GetTiposCampo(LainsaSci ctx)
        {
            return (from a in ctx.TipoCampos
                    select a).ToList<TipoCampo>();
        }

        public static List<TipoCampo> GetTiposCampo(string nomParcial, LainsaSci ctx)
        {
            return (from t in ctx.TipoCampos
                    where t.Descripcion.StartsWith(nomParcial)
                    select t).ToList<TipoCampo>();
        }

        public static TipoCampo GetTipoCampo(int idTipoCampo, LainsaSci ctx)
        {
            return (from t in ctx.TipoCampos
                    where t.TipoId == idTipoCampo
                    select t).FirstOrDefault<TipoCampo>();
        }

        public static Campo GetCampo(int idCampo, LainsaSci ctx)
        {
            return (from c in ctx.Campos
                    where c.CampoId == idCampo
                    select c).FirstOrDefault<Campo>();
        }

        public static List<Campo> GetCampos(LainsaSci ctx)
        {
            return (from c in ctx.Campos
                    select c).ToList<Campo>();
        }

        public static List<Fabricante> GetFabricante(string nomParcial, LainsaSci ctx)
        {
            return (from t in ctx.Fabricantes
                    where t.Nombre.StartsWith(nomParcial)
                    select t).ToList<Fabricante>();
        }

        public static Fabricante GetFabricante(int idFabricante, LainsaSci ctx)
        {
            return (from t in ctx.Fabricantes
                    where t.FabricanteId == idFabricante
                    select t).FirstOrDefault<Fabricante>();
        }

        public static List<Fabricante> GetFabricantes(LainsaSci ctx)
        {
            return (from t in ctx.Fabricantes
                    select t).ToList<Fabricante>();
        }

        public static List<Fabricante> GetFabricantes(Usuario usu, LainsaSci ctx) {
            List<Fabricante> rtn = new List<Fabricante>();
            List<Fabricante> rtn_ret = new List<Fabricante>();
            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    rtn = (from t in ctx.Fabricantes
                           select t).ToList<Fabricante>();
                } else {
                    rtn = (from t in ctx.Fabricantes
                           where t.Empresa == null || t.Empresa.EmpresaId == ue.Empresa.EmpresaId
                           select t).ToList<Fabricante>();
                }
                rtn_ret.AddRange(rtn);
            }
            return rtn_ret;
        }


        public static List<AgenteExtintor> GetAgenteExtintor(string nomParcial, LainsaSci ctx)
        {
            return (from t in ctx.AgenteExtintors
                    where t.Descripcion.StartsWith(nomParcial)
                    select t).ToList<AgenteExtintor>();
        }
        public static AgenteExtintor GetAgenteExtintor(int idAgenteExtintor, LainsaSci ctx)
        {
            return (from t in ctx.AgenteExtintors
                    where t.AgenteExtintorId == idAgenteExtintor
                    select t).FirstOrDefault<AgenteExtintor>();
        }

        public static List<AgenteExtintor> GetAgenteExtintors(LainsaSci ctx)
        {
            return (from t in ctx.AgenteExtintors
                    select t).ToList<AgenteExtintor>();
        }

        public static List<AgenteExtintor> GetAgenteExtintors(Usuario usu, LainsaSci ctx) {
            List<AgenteExtintor> rtn = new List<AgenteExtintor>();
            List<AgenteExtintor> rtn_ret = new List<AgenteExtintor>();
            foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    rtn = (from t in ctx.AgenteExtintors
                           select t).ToList<AgenteExtintor>();
                } else {
                    rtn = (from t in ctx.AgenteExtintors
                           where t.Empresa == null || t.Empresa.EmpresaId == ue.Empresa.EmpresaId 
                           select t).ToList<AgenteExtintor>();
                }
                foreach(AgenteExtintor ae in rtn) {
                    if(!rtn_ret.Contains(ae)) {
                        rtn_ret.Add(ae);
                    }
                }
            }
            return rtn_ret;
        }


        //public static ProgramacionRevision GetProgramacionRevision(int idProgramacion, LainsaSci ctx)
        //{
        //    return (from p in ctx.ProgramacionRevisions
        //            where p.ProgramacionId == idProgramacion
        //            select p).FirstOrDefault<ProgramacionRevision>();
        //}

        //public static List<ProgramacionRevision> GetProgramacionRevisiones(LainsaSci ctx)
        //{
        //    return (from p in ctx.ProgramacionRevisions
        //            select p).ToList<ProgramacionRevision>();
        //}



        //public static List<ProgramacionRevision> GetProgramacionRevisiones(Dispositivo dispositivo, LainsaSci ctx)
        //{
        //    return (from p in ctx.ProgramacionRevisions
        //            where p.PlanificacionRevision.Dispositivo == dispositivo
        //            select p).ToList<ProgramacionRevision>();
        //}



        public static List<Revision> GetRevisiones(LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    select r).ToList<Revision>();
        }

        public static List<Revision> GetRevisionesPorEstado(string estado, LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    where r.Estado.Equals(estado)
                    select r).ToList<Revision>();
        }

        public static List<Revision> GetRevisionesPorEstado(string estado, DateTime desde, DateTime hasta, LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    where r.Estado.Equals(estado) && r.FechaProgramada >= desde && r.FechaProgramada <= hasta
                    select r).ToList<Revision>();
        }

        public static Revision GetRevision(int idRevision, LainsaSci ctx)
        {
            return (from r in ctx.Revisions
                    where r.RevisionId == idRevision
                    select r).FirstOrDefault<Revision>();
        }

        public static void BorrarDispositivo(Dispositivo dsp, LainsaSci ctx)
        {
            foreach (Revision rev in dsp.Revisiones)
            {
                ctx.Delete(rev.DatosRevisions);
            }
            ctx.Delete(dsp.Revisiones);
            ctx.Delete(dsp.ResumenesRevisones);
            ctx.Delete(dsp);
            ctx.SaveChanges();
        }
        public static string GetResumenInforme(Revision r, LainsaSci ctx)
        {
            string resumen = "";
            foreach (DatosRevision dr in r.DatosRevisions.OrderBy(f => f.Campo.Posicion))
            {
                switch (dr.Campo.TipoCampo.Descripcion)
                {
                    case "Campo Si/No":
                        resumen += dr.Campo.Nombre + ": " + dr.Valor + "<br/>";
                        break;
                    case "Texto":
                        resumen += dr.Campo.Nombre + ": " + dr.Valor + "<br/>";
                        break;
                    case "Memo":
                        resumen += dr.Campo.Nombre + ": " + dr.Valor + "<br/>";
                        break;
                    case "Numerico":
                        resumen += dr.Campo.Nombre + ": " + dr.Valor + "<br/>";
                        break;
                    case "Fecha":
                        resumen += dr.Campo.Nombre + ": " + dr.Valor + "<br/>";
                        break;
                }
                
            }
            return resumen;
        }
        public static IList<Filtro> GetFiltros(string tipo, Usuario usuario, LainsaSci ctx)
        {
            return (from f in ctx.Filtros
                    where f.Tipo == tipo
                    && f.Usuario.UsuarioId == usuario.UsuarioId
                    select f).ToList<Filtro>();
        }
        public static Filtro GetFiltro(string tipo, string nombre, Usuario usuario, LainsaSci ctx)
        {
            return (from f in ctx.Filtros
                    where f.Nombre == nombre
                    && f.Tipo == tipo
                    && f.Usuario.UsuarioId == usuario.UsuarioId
                    select f).FirstOrDefault<Filtro>();
        }
        public static Filtro GetFiltro(int id, LainsaSci ctx)
        {
            return (from f in ctx.Filtros
                    where f.FiltroId == id
                    select f).FirstOrDefault<Filtro>();
        }
        public static void DeleteGrupoUsuario(GrupoUsuario gu, LainsaSci ctx)
        {
            ctx.Delete(gu.Permisos);
            ctx.Delete(gu);
            ctx.SaveChanges();
        }
        public static IList<Sustitucion> GetSustitucions(LainsaSci ctx)
        {
            return (from s in ctx.Sustitucions
                    select s).ToList<Sustitucion>();
        }
        public static IList<Sustitucion> GetSustitucions(Usuario usu, LainsaSci ctx)
        {
            
            bool EsAdmin= false;

            if(usu.UsuarioEmpresas.Count == 0) {
                EsAdmin = true;
            } else {
                foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                    if(ue.Empresa == null) {
                        EsAdmin = true;
                        break;
                    }
                }
            }
                        

            List<Sustitucion> ls = new List<Sustitucion>();

            if (EsAdmin)
            {
                ls = (from s in ctx.Sustitucions
                      select s).ToList<Sustitucion>();
            }
            else
            {
                foreach(UsuarioEmpresa ue in usu.UsuarioEmpresas) {
                    IList<Sustitucion> ls_tmp = new List<Sustitucion>();
                    if(ue.Empresa != null && ue.Instalacion == null) {
                        ls_tmp = (from s in ctx.Sustitucions
                                  where s.DispositivoOriginal.Instalacion != null && s.DispositivoOriginal.Instalacion.Empresa.EmpresaId == ue.Empresa.EmpresaId
                                  select s).ToList<Sustitucion>();
                    }else if(ue.Instalacion != null) {
                        ls_tmp= (from s in ctx.Sustitucions
                              where s.DispositivoOriginal.Instalacion != null && s.DispositivoOriginal.Instalacion.InstalacionId == ue.Instalacion.InstalacionId
                              select s).ToList<Sustitucion>();
                    }
                    if(ls_tmp.Count > 0) {
                        ls.AddRange(ls_tmp);
                    }
                
                }


            }
            return ls;
        }

        
        public static Sustitucion GetSustitucion(int id, LainsaSci ctx)
        {
            return (from s in ctx.Sustitucions
                    where s.SustitucionId == id
                    select s).FirstOrDefault<Sustitucion>();
        }
        public static string GetNomLargo(Dispositivo dsp)
        {
            if (dsp == null) return "";
            return String.Format("({0}) {1} / {2}", dsp.Nombre, dsp.Instalacion.Empresa.Nombre, dsp.Instalacion.Nombre);
        }

        public static string GetNomLargoModelo(Dispositivo dsp)
        {
            if (dsp == null) return "";
            string modelo = string.Empty;
            if (dsp.ModeloDispositivo != null)
                modelo = dsp.ModeloDispositivo.Nombre;
            return String.Format("({0}) [{3}] {1} / {2}", dsp.Nombre, dsp.Instalacion.Empresa.Nombre, dsp.Instalacion.Nombre, modelo);
        }


        public static IList<TipoAnomalia> GetTipoAnomalias(LainsaSci ctx)
        {
            return (from ta in ctx.TipoAnomalias
                    select ta).ToList<TipoAnomalia>();
        }
        public static TipoAnomalia GetTipoAnomalia(int id, LainsaSci ctx)
        {
            return (from ta in ctx.TipoAnomalias
                    where ta.TipoAnomaliaId == id
                    select ta).FirstOrDefault<TipoAnomalia>();
        }
        //
        public static Plantilla GetPlantilla(int id, LainsaSci ctx)
        {
            return (from p in ctx.Plantillas
                    where p.PlantillaId == id
                    select p).FirstOrDefault<Plantilla>();
        }
        public static IList<Plantilla> GetPlantillas(LainsaSci ctx)
        {
            return (from p in ctx.Plantillas
                    select p).ToList<Plantilla>();
        }
        public static string GetValorCampo(string valor)
        {
            if (valor == null) return "";
            // Tiene dos campos
            int pos1 = valor.IndexOf("|");
            if (pos1 < 0) return "";
            string c1 = valor.Substring(0, pos1);
            return c1;
        }
        public static string GetComentarioCampo(string valor)
        {
            if (valor == null) return "";
            // Tiene dos campos
            int pos1 = valor.IndexOf("|");
            if (pos1 < 0) return "";
            string c2 = valor.Substring(pos1 + 1, valor.Length - (pos1 + 1));
            return c2;
            
        }
        public static IList<CargaTerminales> GetCargaTerminales(Usuario u, LainsaSci ctx) {
            IList<CargaTerminales> l = new List<CargaTerminales>();
            List<CargaTerminales> l_ret = new List<CargaTerminales>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null) 
                    l = ctx.CargaTerminales.ToList<CargaTerminales>();
                else
                    l = (from ct in ctx.CargaTerminales
                        where ue.Empresa.EmpresaId == ct.Empresa.EmpresaId
                        select ct).ToList<CargaTerminales>();
                l_ret.AddRange(l);
            }
            return l_ret;
        }
        //public static IList<CargaTerminales> GetCargaTerminales(Usuario u, LainsaSci ctx) {
        //    if(u.Empresa == null) return ctx.CargaTerminales.ToList<CargaTerminales>();
        //    return (from ct in ctx.CargaTerminales
        //            where u.Empresa.EmpresaId == ct.Empresa.EmpresaId
        //            select ct).ToList<CargaTerminales>();
        //}

        public static CargaTerminales GetCargaTerminal(string cargaterminalId, LainsaSci ctx)
        {
            return (from c in ctx.CargaTerminales
                    where c.Archivo == cargaterminalId
                    select c).FirstOrDefault<CargaTerminales>();
        }
        public static CargaTerminales GetCargaTerminal(int cargaterminalId, LainsaSci ctx)
        {
            return (from c in ctx.CargaTerminales
                    where c.Id == cargaterminalId
                    select c).FirstOrDefault<CargaTerminales>();
        }

        // Manejo de estados
        public static Estado GetEstado(int id, LainsaSci ctx)
        {
            return (from e in ctx.Estados
                    where e.EstadoId == id
                    select e).FirstOrDefault<Estado>();
        }
        public static IList<Estado> GetEstados(LainsaSci ctx)
        {
            return (from e in ctx.Estados
                    select e).ToList<Estado>();
        }
        public static IList<Estado> GetEstados(Usuario u,LainsaSci ctx)
        {
            IList<Estado> le = new List<Estado>();
            List<Estado> le_ret = new List<Estado>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas){
            if (ue.Empresa == null)
            {
                // usuario general, los tiene todos.
                le = (from e in ctx.Estados
                      select e).ToList<Estado>();
            }
            else
            {
                le = (from e in ctx.Estados
                      where e.Empresa.EmpresaId == ue.Empresa.EmpresaId
                      select e).ToList<Estado>();
            }
                le_ret.AddRange(le);
            }
            return le_ret;
        }
 
        public static Estado GetEstadoApertura(LainsaSci ctx)
        {
            return (from e in ctx.Estados
                    where e.EnApertura == true
                    select e).FirstOrDefault<Estado>();
        }
        public static Estado GetEstadoCierre(LainsaSci ctx,Empresa empresa)
        {
            return (from e in ctx.Estados
                    where e.EnCierre == true
                    && e.Empresa.EmpresaId == empresa.EmpresaId
                    select e).FirstOrDefault<Estado>();
        }
        // Manejo de prioridades
        public static Prioridad GetPrioridad(int id, LainsaSci ctx)
        {
            return (from e in ctx.Prioridads
                    where e.PrioridadId == id
                    select e).FirstOrDefault<Prioridad>();
        }
        public static IList<Prioridad> GetPrioridads(LainsaSci ctx)
        {
            return (from e in ctx.Prioridads
                    select e).ToList<Prioridad>();
        }
        public static IList<Prioridad> GetPrioridads(Usuario u, LainsaSci ctx) {
            IList<Prioridad> lp = new List<Prioridad>();
            List<Prioridad> lp_ret = new List<Prioridad>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    // usuario general, los tiene todos.
                    lp = (from e in ctx.Prioridads
                          select e).ToList<Prioridad>();
                } else {
                    lp = (from e in ctx.Prioridads
                          where e.Empresa.EmpresaId == ue.Empresa.EmpresaId
                          select e).ToList<Prioridad>();
                }
                lp_ret.AddRange(lp);
            }
            return lp_ret;
        }
        // Manejo de responsables
        public static Responsable GetResponsable(int id, LainsaSci ctx)
        {
            return (from e in ctx.Responsables
                    where e.ResponsableId == id
                    select e).FirstOrDefault<Responsable>();
        }
        public static IList<Responsable> GetResponsables(LainsaSci ctx)
        {
            return (from e in ctx.Responsables
                    select e).ToList<Responsable>();
        }
        public static IList<Responsable> GetResponsables(Usuario u, LainsaSci ctx) {
            List<Responsable> lr = new List<Responsable>();
            IList<Responsable> lraux = new List<Responsable>();
            foreach(UsuarioEmpresa ue in u.UsuarioEmpresas) {
                if(ue.Empresa == null) {
                    // usuario general, los tiene todos.
                    lraux = (from e in ctx.Responsables
                          select e).ToList<Responsable>();
                } else {
                    lraux = (from e in ctx.Responsables
                          where e.Empresa.EmpresaId == ue.Empresa.EmpresaId
                          select e).ToList<Responsable>();
                }
                lr.AddRange(lraux);
            }
            return lr;
        }
        //public static ilist<responsable> getresponsables(usuario u, lainsasci ctx) {
        //    ilist<responsable> lr = new list<responsable>();
        //    if(u.empresa == null) {
        //         usuario general, los tiene todos.
        //        lr = (from e in ctx.responsables
        //              select e).tolist<responsable>();
        //    } else {
        //        lr = (from e in ctx.responsables
        //              where e.empresa.empresaid == u.empresa.empresaid
        //              select e).tolist<responsable>();
        //    }
        //    return lr;
        //}
        public static void EliminarRevisionesPendientes(Dispositivo d, LainsaSci ctx)
        {
            var rs = (from r in ctx.Revisions
                      where r.Dispositivo.DispositivoId == d.DispositivoId
                      && r.Estado != "REALIZADA"
                      select r);
            foreach (Revision r in rs)
            {
                ctx.Delete(r.DatosRevisions);
                ctx.Delete(r.Sustitucions);
            }
            ctx.Delete(rs);
            // al haber eliminado todas las revisiones lo lógico es que los resúmenes 
            // tengan fecha de siguiente nula
            foreach (ResumenRevision rr in d.ResumenesRevisones)
            {
                rr.FechaSiguiente = new DateTime(1, 1, 1);
            }
            ctx.SaveChanges();
        }
    }

}