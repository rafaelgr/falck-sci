using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LainsaSciModelo;
using Telerik.Reporting.Processing;



namespace LainsaSciInformes
{
    public static partial class CntInforme
    {
        /// <summary>
        /// Obtner todas las programaciones de informe del sistema
        /// </summary>
        /// <param name="ctx">Conector a la base de datos</param>
        /// <returns>Lista con las programaciones de informe</returns>
        public static IList<ProgramacionInforme> GetProgramacionInformes(LainsaSci ctx)
        {
            return (from pi in ctx.ProgramacionInformes
                    select pi).ToList<ProgramacionInforme>();
        }
        /// <summary>
        /// Obtener las programaciones de un determiando informe
        /// </summary>
        /// <param name="informe">Informe del que se quieren las programaciones</param>
        /// <param name="ctx">Conector a la basede datos</param>
        /// <returns>Lista con las programaciones pedidas</returns>
        public static IList<ProgramacionInforme> GetProgramacionInformes(string informe, LainsaSci ctx)
        {
            return (from pi in ctx.ProgramacionInformes
                    where pi.Informe == informe
                    select pi).ToList<ProgramacionInforme>();
        }

        /// <summary>
        /// Obtener una programación de informe determinada
        /// </summary>
        /// <param name="id">Identificador único de la programación</param>
        /// <param name="ctx">Conector a la base de datos</param>
        /// <returns>Si el programa exite, el programa; si no null</returns>
        public static ProgramacionInforme GetProgramacionInforme(int id, LainsaSci ctx)
        {
            return (from pi in ctx.ProgramacionInformes
                    where pi.ProgramacionInformeId == id
                    select pi).FirstOrDefault<ProgramacionInforme>();
        }

        /// <summary>
        /// Obtiene una programacion de informe referida a un informe y periodicida concreta
        /// </summary>
        /// <param name="informe">Informe</param>
        /// <param name="periodicidad">Pepriodo</param>
        /// <param name="ctx">Conector con la BD</param>
        /// <returns>La programción buscada, si existe, o null, si no existe</returns>
        public static ProgramacionInforme GetProgramacionInforme(string informe, string periodicidad, LainsaSci ctx)
        {
            return (from pi in ctx.ProgramacionInformes
                    where pi.Informe == informe
                    && pi.Periodicidad == periodicidad
                    select pi).FirstOrDefault<ProgramacionInforme>();
        }

        /// <summary>
        /// Obtener los informes programados (hechos en base a una programación)
        /// </summary>
        /// <param name="ctx">Conector a la base de datos</param>
        /// <returns>Lista de informes programados</returns>
        public static IList<InformeProgramado> GetInformeProgramados(LainsaSci ctx)
        {
            return (from ip in ctx.InformeProgramados
                    select ip).ToList<InformeProgramado>();
        }
        /// <summary>
        /// Obtener un informe programado en concreto
        /// </summary>
        /// <param name="id">Identificador único de informe</param>
        /// <param name="ctx">Conector a la base de datos</param>
        /// <returns>El informe buscado o null si no se encuentra</returns>
        public static InformeProgramado GetInformeProgramado(int id, LainsaSci ctx)
        {
            return (from ip in ctx.InformeProgramados
                    where ip.InformeProgramadoId == id
                    select ip).FirstOrDefault<InformeProgramado>();
        }
        /// <summary>
        /// Obtener el informe programado que coincide con los criterios
        /// de búsqueda
        /// </summary>
        /// <param name="desdeFecha">Fecha inicial</param>
        /// <param name="hastaFecha">Fecha final</param>
        /// <param name="periodicidad"></param>
        /// <param name="empresa"></param>
        /// <param name="informe"></param>
        /// <param name="ctx">Conector base de datos</param>
        /// <returns></returns>
        public static InformeProgramado GetInformeProgramado(DateTime desdeFecha, DateTime hastaFecha, string periodicidad, Empresa empresa, string informe, LainsaSci ctx)
        {
            return (from ip in ctx.InformeProgramados
                    where ip.Empresa.EmpresaId == empresa.EmpresaId
                    && ip.FechaInicial == desdeFecha && ip.FechaFinal == hastaFecha
                    && ip.ProgramacionInforme.Informe == informe
                    && ip.ProgramacionInforme.Periodicidad == periodicidad
                    select ip).FirstOrDefault<InformeProgramado>();
        }
        /// <summary>
        /// Obtener el informe programado que coincide con los criterios
        /// de búsqueda
        /// </summary>
        /// <param name="desdeFecha">Fecha inicial</param>
        /// <param name="hastaFecha">Fecha final</param>
        /// <param name="periodicidad"></param>
        /// <param name="instalacion"></param>
        /// <param name="informe"></param>
        /// <param name="ctx">Conector base de datos</param>
        /// <returns></returns>
        public static InformeProgramado GetInformeProgramado(DateTime desdeFecha, DateTime hastaFecha, string periodicidad, Instalacion instalacion, string informe, LainsaSci ctx)
        {
            return (from ip in ctx.InformeProgramados
                    where ip.Instalacion.InstalacionId == instalacion.InstalacionId
                    && ip.FechaInicial == desdeFecha && ip.FechaFinal == hastaFecha
                    && ip.ProgramacionInforme.Informe == informe
                    && ip.ProgramacionInforme.Periodicidad == periodicidad
                    select ip).FirstOrDefault<InformeProgramado>();
        }
        /// <summary>
        /// Procesa un informe en el sentido de crear, o recrear el documento asociado.
        /// </summary>
        /// <param name="ip">Informe programado</param>
        /// <param name="desdeFecha">Desde fecha</param>
        /// <param name="hastaFecha">Hasta fecha</param>
        /// <param name="periodicidad">Periodicidad</param>
        /// <param name="instalacion">Instalacion</param>
        /// <param name="informe">Informe</param>
        /// <param name="repositorio">repositorio</param>
        /// <param name="ctx">Conector a la base de datos</param>
        public static void ProcesarUnInforme(InformeProgramado ip, DateTime desdeFecha, DateTime hastaFecha, string periodicidad, 
            Instalacion instalacion, string informe, string repositorio, LainsaSci ctx)
        {
            Documento documento = new Documento();
            if (ip != null)
            {
                documento = ip.Documento;
            }
            else
            {
                ip = new InformeProgramado();
                ip.Empresa = instalacion.Empresa;
                ip.Instalacion = instalacion;
                ip.Instalacion = null;
                ip.FechaInicial = desdeFecha;
                ip.FechaFinal = hastaFecha;
                ip.ProgramacionInforme = GetProgramacionInforme(informe, periodicidad,ctx);
                ctx.Add(ip);
                documento.Empresa = instalacion.Empresa;
                documento.Instalacion = instalacion;
                documento.Fecha = DateTime.Now;
                documento.Comentarios = "Informe generado automáticamente";
                documento.Extension = "PDF";
                ctx.Add(documento);
                ip.Documento = documento;
                ctx.SaveChanges();
            }
            // en cualquier caso hay que generar el documento y a ello vamos.
            string directorio = repositorio;
            string nombreFichero = String.Format("{0:000000000}", documento.DocumentoId) + ".PDF";
            string fichero = String.Format("{0}\\{1}", directorio, nombreFichero);
            ReportProcessor reportProcessor = new ReportProcessor();
            RenderingResult renderingResult = null;

            switch (informe)
            {
                case "RptResumenEmpresaInstalacion":
                    RptResumenEmpresaInstalacion rptR = new RptResumenEmpresaInstalacion(desdeFecha, hastaFecha, instalacion.Empresa.EmpresaId, instalacion.InstalacionId, ctx);
                    documento.Nombre = String.Format("Resumen Revisiones {0:dd/MM/yyyy} {1:dd/MM/yyyy} (Programado)", desdeFecha, hastaFecha);
                    renderingResult = reportProcessor.RenderReport("PDF", rptR, null);
                    break;
                case "RptFacturableEmpresaInstalacion":
                    RptFacturableEmpresaInstalacion rptF = new RptFacturableEmpresaInstalacion(desdeFecha, hastaFecha, instalacion.Empresa.EmpresaId, instalacion.InstalacionId, ctx);
                    documento.Nombre = String.Format("Revisiones facturables {0:dd/MM/yyyy} {1:dd/MM/yyyy} (Programado)", desdeFecha, hastaFecha);
                    renderingResult = reportProcessor.RenderReport("PDF", rptF, null);
                    break;
            }
            FileStream fs = new FileStream(fichero, FileMode.Create);
            fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
            fs.Close();

        }

        /// <summary>
        /// Elabora todas las programaciones de informe para la  empresa indicada
        /// </summary>
        /// <param name="fechaActual">Fecha de referencia en torno a la cual se definen los periodicos</param>
        /// <param name="informe"> el informe del que se obtienen las programaciones</param>
        /// <param name="empresa"></param>
        /// <param name="repositorio"></param>
        /// <param name="ctx"></param>
        public static void ElaborarInformesProgramados(DateTime fechaActual, string informe, Instalacion instalacion,string repositorio, LainsaSci ctx)
        {
            // primero hay que comprobar que programaciones tiene este informe
            IList<ProgramacionInforme> lpi = GetProgramacionInformes(informe, ctx);
            // Revisamos por cada programación
            foreach (ProgramacionInforme pi in lpi)
            {

                DateTime desdeFecha = DateTime.Now; 
                DateTime hastaFecha = DateTime.Now;
                // valoramos de que periodicidad se trata
                // TODO: Hay que incluir las periodicidades (Trimestral y Semestral)
                switch (pi.Periodicidad)
                {
                    case "S": // semanal
                        desdeFecha = GetPrimerDiaSemana(fechaActual);
                        hastaFecha = GetUltimoDiaSemana(fechaActual);
                        break;
                    case "M": // mensual
                        desdeFecha = GetPrimerDiaMes(fechaActual);
                        hastaFecha = GetUltimoDiaMes(fechaActual);
                        break;
                    case "T": // trimestral
                        desdeFecha = GetPrimerDiaTrimestre(fechaActual);
                        hastaFecha = GetUltimoDiaTrimestre(fechaActual);
                        break;
                    case "SM": // semestral
                        desdeFecha = GetPrimerDiaSemestre(fechaActual);
                        hastaFecha = GetUltimoDiaSemestre(fechaActual);
                        break;
                    case "A": // anual
                        desdeFecha = GetPrimerDiaAno(fechaActual);
                        hastaFecha = GetUltimoDiaAno(fechaActual);
                        break;
                }
                // buscamos si ya existe un informe con esas características.
                InformeProgramado ip = GetInformeProgramado(desdeFecha, hastaFecha, pi.Periodicidad, instalacion, pi.Informe, ctx);
                ProcesarUnInforme(ip, desdeFecha, hastaFecha, pi.Periodicidad, instalacion, pi.Informe, repositorio, ctx);


            }
        }

        #region Funciones auxiliares de fechas
        /// <summary>
        /// Devuelve la fecha qiue corresponde al primer dia de la semana
        /// en la que se encuentra la fecha pasada
        /// </summary>
        /// <param name="fecha">Fecha origen del cálculo</param>
        /// <returns>La fecha del priemr dia de la semana en curso (siempre lunes)</returns>
        public static DateTime GetPrimerDiaSemana(DateTime fecha)
        {
            int dif = fecha.DayOfWeek - DayOfWeek.Monday;
            if (dif < 0) dif += 7;
            return fecha.AddDays(-1 * dif).Date;
        }
        /// <summary>
        /// Devuelve la fecha que corresponde al último dia de la semana
        /// en la que se encuentra la fecha pasada
        /// </summary>
        /// <param name="fecha">Fecha origen del cálculo</param>
        /// <returns>La fecha del último dia de la semana en curso (siempre domingo)</returns>
        public static DateTime GetUltimoDiaSemana(DateTime fecha)
        {
            int dif = DayOfWeek.Sunday - fecha.DayOfWeek;
            if (dif < 0) dif += 7;
            return fecha.AddDays(dif).Date;
        }

        public static DateTime GetPrimerDiaMes(DateTime fecha)
        {
            return new DateTime(fecha.Year, fecha.Month, 1);
        }
        public static DateTime GetUltimoDiaMes(DateTime fecha)
        {
            DateTime dto = fecha;
            dto = dto.AddMonths(1);
            dto = dto.AddDays(-(fecha.Day));
            return dto;
        }
        public static DateTime GetPrimerDiaAno(DateTime fecha)
        {
            return new DateTime(fecha.Year, 1, 1);
        }
        public static DateTime GetUltimoDiaAno(DateTime fecha)
        {
            return new DateTime(fecha.Year, 12, 31);
        }
        public static DateTime GetPrimerDiaTrimestre(DateTime fecha)
        {
            Periodo p = (from t in CargaTrimestres(fecha)
                         where t.FechaInicio <= fecha
                         && t.FechaFin >= fecha
                         select t).FirstOrDefault<Periodo>();
            return p.FechaInicio;
        }
        public static DateTime GetUltimoDiaTrimestre(DateTime fecha)
        {
            Periodo p = (from t in CargaTrimestres(fecha)
                         where t.FechaInicio <= fecha
                         && t.FechaFin >= fecha
                         select t).FirstOrDefault<Periodo>();
            return p.FechaFin;
        }
        public static DateTime GetPrimerDiaSemestre(DateTime fecha)
        {
            Periodo p = (from t in CargaSemestres(fecha)
                         where t.FechaInicio <= fecha
                         && t.FechaFin >= fecha
                         select t).FirstOrDefault<Periodo>();
            return p.FechaInicio;
        }
        public static DateTime GetUltimoDiaSemestre(DateTime fecha)
        {
            Periodo p = (from t in CargaSemestres(fecha)
                         where t.FechaInicio <= fecha
                         && t.FechaFin >= fecha
                         select t).FirstOrDefault<Periodo>();
            return p.FechaFin;
        }
        public static IList<Periodo> CargaTrimestres(DateTime fecha)
        {
            IList<Periodo> l = new List<Periodo>();
            l.Add(new Periodo()
            {
                Numero=1,
                FechaInicio = new DateTime(fecha.Year,1,1),
                FechaFin = new DateTime(fecha.Year ,3,31)
            });
            l.Add(new Periodo()
            {
                Numero = 2,
                FechaInicio = new DateTime(fecha.Year, 4, 1),
                FechaFin = new DateTime(fecha.Year, 6, 30)
            });
            l.Add(new Periodo()
            {
                Numero = 3,
                FechaInicio = new DateTime(fecha.Year, 7, 1),
                FechaFin = new DateTime(fecha.Year, 9, 30)
            });
            l.Add(new Periodo()
            {
                Numero = 4,
                FechaInicio = new DateTime(fecha.Year, 10, 1),
                FechaFin = new DateTime(fecha.Year, 12, 31)
            });
            return l;
        }
        public static IList<Periodo> CargaSemestres(DateTime fecha)
        {
            IList<Periodo> l = new List<Periodo>();
            l.Add(new Periodo()
            {
                Numero = 1,
                FechaInicio = new DateTime(fecha.Year, 1, 1),
                FechaFin = new DateTime(fecha.Year, 6, 30)
            });
            l.Add(new Periodo()
            {
                Numero = 2,
                FechaInicio = new DateTime(fecha.Year, 7, 1),
                FechaFin = new DateTime(fecha.Year, 12, 31)
            });
            return l;
        }
        #endregion
    }
}
