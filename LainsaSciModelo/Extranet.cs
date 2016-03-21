using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;

namespace LainsaSciModelo
{
    public partial class CntLainsaSci
    {
        #region Métodos de Extranet
        public static IList<Categoria> GetCategorias(LainsaSci ctx)
        {
            return ctx.Categorias.ToList<Categoria>();
        }
        public static IList<Categoria> GetCategorias(string nombreParcial, LainsaSci ctx)
        {
            return (from c in ctx.Categorias
                    where c.Nombre.StartsWith(nombreParcial)
                    select c).ToList<Categoria>();
        }
        public static Categoria GetCategoria(int categoriaId, LainsaSci ctx)
        {
            return (from c in ctx.Categorias
                    where c.CategoriaId == categoriaId
                    select c).FirstOrDefault<Categoria>();
        }
        public static IList<Documento> GetDocumentos(LainsaSci ctx)
        {
            return ctx.Documentos.ToList<Documento>();
        }
        public static IList<Empresa> GetEmpresas(UsuarioExtranet uex, LainsaSci ctx)
        {
            //if (uex.Global)
            //{
            //    return (from e in ctx.Empresas
            //            orderby e.Nombre
            //            select e).ToList<Empresa>();
            //}
            //else
            //{
                return (from e in ctx.Empresas
                        where e.EmpresaId == uex.Empresa.EmpresaId
                        select e).ToList<Empresa>();
            //}
        }
        public static IList<Instalacion> GetInstalaciones(UsuarioExtranet uex, Empresa empresa, LainsaSci ctx)
        {
            if (uex.Instalacion == null)
            {
                return (from i in ctx.Instalacions
                        where i.Empresa.EmpresaId == empresa.EmpresaId
                        select i).ToList<Instalacion>();
            }
            else
            {
                return (from i in ctx.Instalacions
                        where i.Empresa.EmpresaId == empresa.EmpresaId
                        && i.InstalacionId == uex.Instalacion.InstalacionId
                        select i).ToList<Instalacion>();
            }
        }
        public static IList<Documento> GetDocumentos(Categoria categoria, UsuarioExtranet uex, LainsaSci ctx)
        {
            if (uex.Empresa == null)
            {
                return (from d in ctx.Documentos
                        where d.Categoria.CategoriaId == categoria.CategoriaId
                        select d).ToList<Documento>();
            }
            else
            {
                if (uex.Instalacion == null)
                {
                    return (from d in ctx.Documentos
                            where d.Categoria.CategoriaId == categoria.CategoriaId
                            && d.Empresa.EmpresaId == uex.Empresa.EmpresaId
                            select d).ToList<Documento>();
                }
                else
                {
                    return (from d in ctx.Documentos
                            where d.Categoria.CategoriaId == categoria.CategoriaId
                            && d.Empresa.EmpresaId == uex.Empresa.EmpresaId
                            && d.Instalacion.InstalacionId == uex.Instalacion.InstalacionId
                            select d).ToList<Documento>();
                }
            }
        }
        public static IList<Documento> GetDocumentos(Subcategoria subCategoria, UsuarioExtranet uex, LainsaSci ctx)
        {
            if (uex.Empresa == null)
            {
                return (from d in ctx.Documentos
                        where d.Subcategoria.SubcategoriaId == subCategoria.SubcategoriaId
                        select d).ToList<Documento>();
            }
            else
            {
                if (uex.Instalacion == null)
                {
                    return (from d in ctx.Documentos
                            where d.Subcategoria.SubcategoriaId == subCategoria.SubcategoriaId
                            && d.Empresa.EmpresaId == uex.Empresa.EmpresaId
                            select d).ToList<Documento>();
                }
                else
                {
                    return (from d in ctx.Documentos
                            where d.Subcategoria.SubcategoriaId == subCategoria.SubcategoriaId
                            && d.Empresa.EmpresaId == uex.Empresa.EmpresaId
                            && d.Instalacion.InstalacionId == uex.Instalacion.InstalacionId
                            select d).ToList<Documento>();
                }
            }
        }
        public static IList<Documento> GetDocumentos(Instalacion instalacion, LainsaSci ctx)
        {
            return (from d in ctx.Documentos
                    where d.Instalacion.InstalacionId == instalacion.InstalacionId
                    select d).ToList<Documento>();
        }
        public static IList<Documento> GetDocumentos(Instalacion instalacion, UsuarioExtranet uex, LainsaSci ctx)
        {
            IList<Documento> ldocs2 = new List<Documento>();
            IList<Documento> ldocs = (from d in ctx.Documentos
                                      where d.Instalacion.InstalacionId == instalacion.InstalacionId
                                      select d).ToList<Documento>();
            //if (uex.Global)
            //{
            //    foreach (Documento d in ldocs)
            //    {
            //        foreach (PermisoCategoria pc in uex.PermisoCategorias)
            //        {
            //            if (d.Categoria.CategoriaId == pc.Categoria.CategoriaId) ldocs2.Add(d);
            //        }
            //    }

            //}
            //else
            //{
            ldocs2 = ldocs;
            //}
            return ldocs2;
        }
        public static IList<Documento> GetDocumentos(Empresa empresa, UsuarioExtranet uex, LainsaSci ctx)
        {
           IList<Documento> ldocs = (from d in ctx.Documentos
                                     where d.Instalacion == null && d.Empresa.EmpresaId == empresa.EmpresaId
                                      select d).ToList<Documento>();
           return ldocs;
        }
   
        public static Documento GetDocumento(int documentoId, LainsaSci ctx)
        {
            return (from d in ctx.Documentos
                    where d.DocumentoId == documentoId
                    select d).FirstOrDefault<Documento>();
        }
        public static IList<UsuarioExtranet> GetUsuariosExtranet(LainsaSci ctx)
        {
            return ctx.UsuarioExtranets.ToList<UsuarioExtranet>();
        }
        public static UsuarioExtranet GetUsuarioExtranet(int id, LainsaSci ctx)
        {
            return (from uex in ctx.UsuarioExtranets
                    where uex.UsuarioExtranetId == id
                    select uex).FirstOrDefault<UsuarioExtranet>();
        }
        public static UsuarioExtranet GetUsuarioExtranet(string login, LainsaSci ctx)
        {
            return (from uex in ctx.UsuarioExtranets
                    where uex.Login == login
                    select uex).FirstOrDefault<UsuarioExtranet>();
        }
        public static IList<GrupoMensajes> GetGruposMensajes(LainsaSci ctx)
        {
            return (from gm in ctx.GrupoMensajes
                    select gm).ToList<GrupoMensajes>();
        }
        public static IList<GrupoMensajes> GetGruposMensajes(string nombreParcial, LainsaSci ctx)
        {
            return (from gm in ctx.GrupoMensajes
                    where gm.Nombre.StartsWith(nombreParcial)
                    select gm).ToList<GrupoMensajes>();
        }
        public static GrupoMensajes GetGrupoMensajes(int id, LainsaSci ctx)
        {
            return (from gm in ctx.GrupoMensajes
                    where gm.GrupoMensajesId == id
                    select gm).FirstOrDefault<GrupoMensajes>();
        }
        public static IList<Mensaje> GetMensajes(LainsaSci ctx)
        {
            return (from m in ctx.Mensajes
                    select m).ToList<Mensaje>();
        }
        public static Mensaje GetMensaje(int id, LainsaSci ctx)
        {
            return (from m in ctx.Mensajes
                    where m.MensajeId == id
                    select m).FirstOrDefault<Mensaje>();
        }

        public static Documento GetDocumento(string nombre, LainsaSci ctx)
        {
            return (from d in ctx.Documentos
                    where d.Nombre == nombre
                    select d).FirstOrDefault<Documento>();
        }
        public static IList<Mensaje> GetMensajesActivos(DateTime fecha, LainsaSci ctx)
        {
            return (from m in ctx.Mensajes
                    where m.FechaFinal <= fecha
                    && m.FechaInicio >= fecha
                    select m).ToList<Mensaje>();
        }
        public static IList<Subcategoria> GetSubcategorias(LainsaSci ctx)
        {
            return (from sc in ctx.Subcategorias
                    select sc).ToList<Subcategoria>();
        }
        public static IList<Subcategoria> GetSubcategorias(string nombreparcial, LainsaSci ctx)
        {
            return (from sc in ctx.Subcategorias
                    where sc.Nombre.StartsWith(nombreparcial)
                    select sc).ToList<Subcategoria>();
        }

        public static Subcategoria GetSubcategoria(int id, LainsaSci ctx)
        {
            return (from sc in ctx.Subcategorias
                    where sc.SubcategoriaId == id
                    select sc).FirstOrDefault<Subcategoria>();
        }
        #endregion
    }
}
