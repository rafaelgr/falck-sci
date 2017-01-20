using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;
using LainsaSciModelo;
using LainsaSciWinWeb;
using LainsaSciInformes;
using Telerik.Web.UI;
using LainsaTerminalLib;
using System.Data.SqlServerCe;
using System.IO;
using System.Text;

namespace LainsaSciWinWeb
{
    public partial class ImportTerminalII : System.Web.UI.Page
    {
        #region Definición de variables
        
        LainsaSci ctx = null; // conector con la base de datos
        Usuario usuario = null; // controla el usuario del login
        private static string path = null;
        private static string archivo = null;
        private CargaTerminales terminal = null;
        private FileInfo file;
        private Empresa empresa;
        private StringBuilder pantalla;
        
        #endregion
        
        #region Carga y descarga de la página
        
        protected void Page_Init(object sender, EventArgs e)
        {
            ctx = new LainsaSci("LainsaSciCTX"); // el conector figura en el config
            path = this.MapPath("/");
            UsuarioCorrecto(); // control de usuario logado
            // control de skin
            if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //RadProgressArea1.Localization.UploadedFiles = "Registro procesado: ";
                //RadProgressArea1.Localization.CurrentFileName = "Registro: ";
                //RadProgressArea1.Localization.TotalFiles = "Total registros:";
            }
        }
        
        protected void Page_Unload(object sender, EventArgs e)
        {
            ctx.Dispose(); // evitamos dejar conexiones abiertas.
        }
        
        #endregion
        
        /// <summary>
        /// Comprueba si hay un usuario logado
        /// si no se va a la página de Login (Default.aspx)
        /// </summary>
        protected void UsuarioCorrecto()
        {
            usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
            if (usuario == null)
                Response.Redirect("Default.aspx");
        }
        
        protected void ControlDeError(Exception ex)
        {
            ErrorControl eC = new ErrorControl();
            eC.ErrorUsuario = usuario;
            eC.ErrorDateTime = DateTime.Now;
            eC.ErrorException = ex;
            Session["ErrorControl"] = eC;
            RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
        }
        
        protected void btnLanzador_Click(object sender, EventArgs e)
        {
            // string path = path = this.MapPath("/");
            // file = new System.IO.FileInfo(string.Format("{0}BD\\24_prueba.sdf", path));
            // //string curTempFileName = Path.GetTempFileName();
            // //FileInfo f = new FileInfo(curTempFileName);
            // //string s = FileUpload1.FileName;
            // //s = FileUpload1.PostedFile.FileName;
            // //   s= Path.GetFullPath(FileUpload1.PostedFile.FileName);
            ////if (FileUpload1.HasFile)
            //// {
            ////     //file = new FileInfo(FileUpload1.FileName);
            //     int empresa_id = int.Parse(file.Name.Split('_')[0]);
            //     empresa = CntLainsaSci.GetEmpresa(empresa_id, ctx); 
            //     AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            //     SqlCeConnection conn = GetConnection();
            //     if (!GetEmpresa(conn))
            //     {
            //         GuardarDispositivos(conn);
            //         ctx.SaveChanges();
            //     }
            //     else
            //     {
            //         RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
            //                                                 (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
            //                                                 (string)GetGlobalResourceObject("ResourceLainsaSci", "ImportEmpresa"));
            //         RadNotification1.Show();
            //         return;
            //     }
            // //}
        }
        
        private SqlCeConnection GetConnection()
        {
            //int empresa_id = int.Parse(file.Name.Split('_')[0]);
            //empresa = CntLainsaSci.GetEmpresa(empresa_id, ctx);
            //AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            //SqlCeConnection conn = GetConnection();
            //GuardarDispositivos(conn);
            //ctx.SaveChanges();
            string conn = string.Format("Data Source={0};Password =;Persist Security Info=True", file);
            SqlCeEngine DBDatabase = new SqlCeEngine(conn);
            SqlCeConnection vCon = new System.Data.SqlServerCe.SqlCeConnection(conn);
            
            try
            {
                vCon.Open();
                
                return vCon;
            }
            catch (Exception VError)
            {
                ControlDeError(VError);
            }
            finally
            {
                DBDatabase.Dispose();
            }
            return null;
        }
        
        private bool GetEmpresa(SqlCeConnection conn)
        {
            TEmpresa emp = CntSciTerminal.GetTEmpresa(conn);
            var rs = (from d in ctx.Empresas
                      where d.EmpresaId == emp.EmpresaId
                      select d).FirstOrDefault<Empresa>();
            if (rs != null)
            {
                empresa = rs;
                return true;
            }
            return false;
        }
        
        private void GuardarIncidencias(Dispositivo dispositivo, TDispositivo disp, SqlCeConnection conn)
        {
            IList<TIncidencia> incis = CntSciTerminal.GetTIncidencias(disp, conn);
            foreach (TIncidencia inc in incis)
            {
                Incidencia incidencia;
                var rs = (from d in ctx.Incidencias
                          where d.IncidenciaId == inc.IncidenciaId && d.Dispositivo.DispositivoId == dispositivo.DispositivoId
                          select d).FirstOrDefault<Incidencia>();
                if (rs == null)
                {
                    // Segunda búsqueda por problema de duplicidades.
                    rs = (from d in ctx.Incidencias
                          where d.FechaApertura == inc.FechaApertura && d.Dispositivo.DispositivoId == dispositivo.DispositivoId && d.Usuario.UsuarioId == inc.TUsuario.UsuarioId
                          select d).FirstOrDefault<Incidencia>();
                }
                if (rs != null)
                {
                    //incidencia = rs;
                    rs.Operativo = inc.Operativo;
                    rs.Comentarios = inc.Comentarios;
                }
                else
                {
                    incidencia = new Incidencia()
                    {
                        FechaApertura = inc.FechaApertura,
                        Comentarios = inc.Comentarios,
                        Dispositivo = dispositivo,
                        Operativo = inc.Operativo,
                        Usuario = CntLainsaSci.GetUsuario(inc.TUsuario.UsuarioId, ctx)
                    };
                    dispositivo.Operativo = incidencia.Operativo;
                    ctx.Add(incidencia);
                }
                ctx.SaveChanges();
            }
        }
        
        // lee secuancialmente las incidencias del fichero de terminal y las guarda en la base de datos
        private void GuardarIncidencias(SqlCeConnection conn, LainsaSci ctx)
        {
            IList<TIncidencia> lti = CntSciTerminal.GetTIncidencias(conn);
            Incidencia incidencia;
            foreach (TIncidencia ti in lti)
            {
                // no ha sufrido cambios
                if (ti.Abm == 0)
                    continue;
                switch (ti.Abm)
                {
                    case 1:
                        // alta
                        // comprobar que no se ha dado de alta previamente
                        // es el caso de recarga del mismo fichero
                        Incidencia inci = (from i in ctx.Incidencias
                                           where i.Dispositivo.DispositivoId == ti.TDispositivo.DispositivoId
                                           && i.FechaApertura == ti.FechaApertura
                                           && i.Comentarios == ti.Comentarios
                                           select i).FirstOrDefault<Incidencia>();
                        if (inci != null) break;
                        incidencia = new Incidencia();
                        incidencia.FechaApertura = ti.FechaApertura;
                        incidencia.FechaPrevista = ti.FechaPrevista;
                        incidencia.FechaCierre = ti.FechaCierre;
                        incidencia.Dispositivo = CntLainsaSci.GetDispositivo(ti.TDispositivo.DispositivoId, ctx);
                        if (ti.TEstado != null)
                            incidencia.Estado = CntLainsaSci.GetEstado(ti.TEstado.EstadoId, ctx);
                        if (ti.TPrioridad != null)
                            incidencia.Prioridad = CntLainsaSci.GetPrioridad(ti.TPrioridad.PrioridadId, ctx);
                        if (ti.TResponsable != null)
                            incidencia.Responsable = CntLainsaSci.GetResponsable(ti.TResponsable.ResponsableId, ctx);
                        incidencia.Usuario = CntLainsaSci.GetUsuario(ti.TUsuario.UsuarioId, ctx);
                        incidencia.Comentarios = ti.Comentarios;
                        incidencia.Operativo = ti.Operativo;
                        incidencia.SiguePlan = true; // hasta que no se cambie el programa de terminal para que contemple ese campo.
                        ctx.Add(incidencia);
                        ctx.SaveChanges();
                        // Si es un alta hay que verificar que las evoluciones asociadas se cree contra
                        // la incidencia de servidor correcta.
                        GuardarIncidenciaEvolucions(ti, incidencia, conn, ctx);
                        break;
                    case 2:
                        incidencia = CntLainsaSci.GetIncidencia(ti.IncidenciaId, ctx);
                        if (incidencia != null)
                        {
                            ctx.Delete(incidencia.IncidenciaEvolucions);
                            ctx.SaveChanges();
                            ctx.Delete(incidencia);
                            ctx.SaveChanges();
                        }
                        break;
                    case 3:
                        incidencia = CntLainsaSci.GetIncidencia(ti.IncidenciaId, ctx);
                        incidencia.FechaApertura = ti.FechaApertura;
                        incidencia.FechaPrevista = ti.FechaPrevista;
                        incidencia.FechaCierre = ti.FechaCierre;
                        incidencia.Dispositivo = CntLainsaSci.GetDispositivo(ti.TDispositivo.DispositivoId, ctx);
                        if (ti.TEstado != null)
                            incidencia.Estado = CntLainsaSci.GetEstado(ti.TEstado.EstadoId, ctx);
                        if (ti.TPrioridad != null)
                            incidencia.Prioridad = CntLainsaSci.GetPrioridad(ti.TPrioridad.PrioridadId, ctx);
                        if (ti.TResponsable != null)
                            incidencia.Responsable = CntLainsaSci.GetResponsable(ti.TResponsable.ResponsableId, ctx);
                        incidencia.Usuario = CntLainsaSci.GetUsuario(ti.TUsuario.UsuarioId, ctx);
                        incidencia.Comentarios = ti.Comentarios;
                        incidencia.Operativo = ti.Operativo;
                        break;
                    default:
                        break;
                }
                ctx.SaveChanges();
            }
        }

        // 
        private void GuardarIncidenciaEvolucions(SqlCeConnection conn, LainsaSci ctx)
        {
            IList<TIncidenciaEvolucion> ltie = CntSciTerminal.GetTIncidenciaEvolucions(conn);
            foreach (TIncidenciaEvolucion tie in ltie)
            {
                if (tie.Abm == 0) continue; // no cambiada
                if (tie.Incidencia.Abm == 1) continue; // las evoluciones de las incidencias creadas ya han sido procesadas (GuardarIncidencias)
                switch (tie.Abm)
                {
                    case 1:
                        // alta
                        // primero evitar un doble procesamiento
                        IncidenciaEvolucion ie1 = (from ine in ctx.IncidenciaEvolucions
                                                   where ine.Incidencia.IncidenciaId == tie.Incidencia.IncidenciaId
                                                   && ine.FechaEvolucion == tie.FechaEvolucion
                                                   && ine.Comentarios == tie.Comentarios
                                                   select ine).FirstOrDefault<IncidenciaEvolucion>();
                        if (ie1 != null) break; // la evolución entendemos que ya ha sido dada de alta
                        IncidenciaEvolucion ie = new IncidenciaEvolucion();
                        Incidencia i = CntLainsaSci.GetIncidencia(tie.Incidencia.IncidenciaId, ctx);
                        ie.Incidencia = i;
                        ie.FechaEvolucion = tie.FechaEvolucion;
                        ie.Usuario = CntLainsaSci.GetUsuario(tie.Usuario.UsuarioId, ctx);
                        ie.Comentarios = tie.Comentarios;
                        ie.Operativo = tie.Operativo;
                        ctx.Add(ie);
                        break;
                    case 2:
                        // baja
                        IncidenciaEvolucion ie2 = CntLainsaSci.GetIncidenciaEvolucion(tie.IncidenciaEvolucionId, ctx);
                        if (ie2 != null)
                        {
                            ctx.Delete(ie2);
                        }
                        break;
                    case 3:
                        // modificada
                        IncidenciaEvolucion ie3 = CntLainsaSci.GetIncidenciaEvolucion(tie.IncidenciaEvolucionId, ctx);
                        if (ie3 != null)
                        {
                            Incidencia i3 = CntLainsaSci.GetIncidencia(tie.Incidencia.IncidenciaId, ctx);
                            ie3.Incidencia = i3;
                            ie3.FechaEvolucion = tie.FechaEvolucion;
                            ie3.Usuario = CntLainsaSci.GetUsuario(tie.Usuario.UsuarioId, ctx);
                            ie3.Comentarios = tie.Comentarios;
                            ie3.Operativo = tie.Operativo;
                        }
                        break;
                    default:
                        break;
                }
                ctx.SaveChanges();
            }
        }

        private void GuardarIncidenciaEvolucions(TIncidencia ti, Incidencia inci, SqlCeConnection conn, LainsaSci ctx)
        {
            IList<TIncidenciaEvolucion> ltie = CntSciTerminal.GetTIncidenciaEvolucions(ti, conn);
            foreach (TIncidenciaEvolucion tie in ltie)
            {
                if (tie.Abm == 0) continue; // no cambiada
                switch (tie.Abm)
                {
                    case 1:
                        // alta
                        // aqui no verificamos un doble pase de fcihero porque lo ha sido en la
                        // incidencia padre.
                        IncidenciaEvolucion ie = new IncidenciaEvolucion();
                        ie.Incidencia = inci; // en esta rutina la incidencia es conocida
                        ie.FechaEvolucion = tie.FechaEvolucion;
                        ie.Usuario = CntLainsaSci.GetUsuario(tie.Usuario.UsuarioId, ctx);
                        ie.Comentarios = tie.Comentarios;
                        ie.Operativo = tie.Operativo;
                        ctx.Add(ie);
                        break;
                    case 2:
                        // baja
                        IncidenciaEvolucion ie2 = CntLainsaSci.GetIncidenciaEvolucion(tie.IncidenciaEvolucionId, ctx);
                        if (ie2 != null)
                        {
                            ctx.Delete(ie2);
                        }
                        break;
                    case 3:
                        // modificada
                        // este caso no debería darse pero por si acaso
                        IncidenciaEvolucion ie3 = CntLainsaSci.GetIncidenciaEvolucion(tie.IncidenciaEvolucionId, ctx);
                        if (ie3 != null)
                        {
                            Incidencia i3 = CntLainsaSci.GetIncidencia(tie.Incidencia.IncidenciaId, ctx);
                            ie3.Incidencia = i3;
                            ie3.FechaEvolucion = tie.FechaEvolucion;
                            ie3.Usuario = CntLainsaSci.GetUsuario(tie.Usuario.UsuarioId, ctx);
                            ie3.Comentarios = tie.Comentarios;
                            ie3.Operativo = tie.Operativo;
                        }
                        break;
                    default:
                        break;
                }
                ctx.SaveChanges();
            }
        }
        
        // guardar las evoluciones relacionadas con una incidencia.
        private void GuardarIncidenciaEvolucion(TIncidencia ti, int abm, SqlCeConnection conn, LainsaSci ctx)
        {
            Incidencia incidencia = CntLainsaSci.GetIncidencia(ti.IncidenciaId, ctx);
            if (incidencia == null)
                return;
            // caso de las bajas, se eliminan todas las asociadas.
            if (abm == 2)
            {
                ctx.Delete(incidencia.IncidenciaEvolucions);
            }
            else
            {
                IncidenciaEvolucion ie;
                IList<TIncidenciaEvolucion> tlie = CntSciTerminal.GetTIncidenciaEvolucions(ti, conn);
                foreach (TIncidenciaEvolucion tie in tlie)
                {
                    if (tie.Abm == 0)
                        continue;
                    switch (tie.Abm)
                    {
                        case 1:
                            // alta
                            ie = new IncidenciaEvolucion();
                            ie.Incidencia = incidencia;
                            ie.FechaEvolucion = tie.FechaEvolucion;
                            ie.Comentarios = tie.Comentarios;
                            ie.Usuario = CntLainsaSci.GetUsuario(tie.Usuario.UsuarioId, ctx);
                            ctx.Add(ie);
                            break;
                        case 2:
                            // baja
                            // ya ha sido tratado en un paso anterior.
                            break;
                        case 3:
                            // modificación
                            ie = CntLainsaSci.GetIncidenciaEvolucion(tie.IncidenciaEvolucionId, ctx);
                            ie.FechaEvolucion = tie.FechaEvolucion;
                            ie.Comentarios = tie.Comentarios;
                            ie.Usuario = CntLainsaSci.GetUsuario(tie.Usuario.UsuarioId, ctx);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        private void GuardarSustituciones(Dispositivo dispositivo, TDispositivo disp, SqlCeConnection conn)
        {
            IList<TSustitucion> sustituciones = CntSciTerminal.GetTSustituciones(disp, conn);
            foreach (TSustitucion sust in sustituciones)
            {
                Sustitucion sustitucion;
                var rs = (from d in ctx.Sustitucions
                          where d.SustitucionId == sust.SustitucionId && d.DispositivoOriginal.DispositivoId == dispositivo.DispositivoId
                          select d).FirstOrDefault<Sustitucion>();
                if (rs != null)
                {
                    sustitucion = rs;
                    sustitucion.Usuario = CntLainsaSci.GetUsuario(sust.TUsuario.UsuarioId, ctx);
                    if (!CntSciTerminal.FechaNula(sust.Fecha))
                        sustitucion.Fecha = sust.Fecha;
                    sustitucion.Estado = sust.Estado;
                    if (sust.TDispositivoSustituto != null)
                        sustitucion.DispositivoSustituto = CntLainsaSci.GetDispositivo(sust.TDispositivoSustituto.DispositivoId, ctx);
                    sustitucion.Comentarios = sust.Comentarios;
                }
                else
                {
                    Revision revision = null;
                    if (sust.TRevision != null)
                        revision = CntLainsaSci.GetRevision(sust.TRevision.RevisionId, ctx);
                    Programa p = null;
                    if (revision != null && revision.Programa != null)
                        p = CntLainsaSci.GetPrograma(revision.Programa.ProgramaId, ctx);
                    DateTime fecha = new DateTime();
                    if (!CntSciTerminal.FechaNula(sust.Fecha))
                        fecha = sust.Fecha;
                    Dispositivo d = null;
                    if (sust.TDispositivoSustituto != null)
                        d = CntLainsaSci.GetDispositivo(sust.TDispositivoSustituto.DispositivoId, ctx);
                    // control del nulo en el dispositivo sustituto
                    if (d != null)
                    {
                        sustitucion = new Sustitucion()
                        {
                            Usuario = CntLainsaSci.GetUsuario(sust.TUsuario.UsuarioId, ctx),
                            Revision = revision,
                            Estado = sust.Estado,
                            Programa = p,
                            Comentarios = sust.Comentarios,
                            Fecha = fecha,
                            DispositivoOriginal = dispositivo,
                            DispositivoSustituto = d,
                        };
                        ctx.Add(sustitucion);
                    }
                }
                ctx.SaveChanges();
            }
        }
        
        private void GuardarRevisiones(SqlCeConnection conn)
        {
            IList<TRevision> revisiones = CntSciTerminal.GetTRevisiones(conn);
            foreach (TRevision rev in revisiones)
            {
                // no tiene sentido modificar revisiones que no se han tocado
                if (rev.Abm == 0) continue;
                Revision revision = null;
                var rs = (from d in ctx.Revisions
                          where d.RevisionId == rev.RevisionId
                          select d).FirstOrDefault<Revision>();
                // si no corresponde a un programa la omitimos (no se como la han dado de alta)
                if (rev.TPrograma == null)
                {
                    continue;
                }
                if (rs == null)
                {
                    // por si ha habido cambios de ID debido a 
                    // a generaciones, tenemos este control para a pesar de eso
                    // intentar encontrar la resiion
                    rs = (from r in ctx.Revisions
                          where r.Dispositivo.DispositivoId == rev.Dispositivo.DispositivoId &&
                                r.Programa.ProgramaId == rev.TPrograma.ProgramaId &&
                                r.PlantillaRevision.Descripcion == rev.Plantilla
                          select r).FirstOrDefault<Revision>();
                }
                if (rs == null)
                {
                    // un último intento con el mínimo de informacion
                    rs = (from r in ctx.Revisions
                          where r.Dispositivo.DispositivoId == rev.Dispositivo.DispositivoId &&
                                r.Programa.ProgramaId == rev.TPrograma.ProgramaId &&
                                r.Estado != "REALIZADA"
                          select r).FirstOrDefault<Revision>();
                }
                //siempre existirá la revisión ya que no se permite la creación de nuevas en TERMINAL
                if (rs != null)
                {
                    revision = rs;
                    if (rev.FechaRevision != null)
                        revision.FechaRevision = rev.FechaRevision;
                    revision.Resultado = rev.Resultado;
                    revision.Observaciones = rev.Comentario;
                    if (rev.Usuario != null)
                        revision.Usuario = CntLainsaSci.GetUsuario(rev.Usuario.UsuarioId, ctx);
                    CargarDatosRevision(rev, conn);
                    revision.ResumenInforme = CntLainsaSci.GetResumenInforme(revision, ctx);
                    revision.Estado = rev.Estado;
                    if (revision.Programa != null)
                        revision.Programa.Estado = CntLainsaSci.EstadoPrograma(revision.Programa);
                    if (rev.TTipoAnomalia != null)
                        revision.TipoAnomalia = CntLainsaSci.GetTipoAnomalia(rev.TTipoAnomalia.TipoAnomaliaId, ctx);
                    ctx.SaveChanges();
                    // ahora esta secuencia solo tiene sentido en el caso de periodicas
                    if (!revision.PlantillaRevision.NoPeriodica)
                    {
                        CntLainsaSci.EliminarInferiores(revision, ctx);
                        CntLainsaSci.ProgramarSiguienteRevision(revision, ctx, true);
                        CntLainsaSci.ProgramarInferiores(revision, ctx);
                    }
                }
            }
        }
        
        private void CargarDatosRevision(TRevision rev, SqlCeConnection conn)
        {
            IList<TDatoRevision> datos_revision = CntSciTerminal.GetTDatosRevision(rev, conn);
            foreach (TDatoRevision dr in datos_revision)
            {
                DatosRevision dato;
                var rs = (from d in ctx.DatosRevisions
                          where d.DatosId == dr.DatosId
                          select d).FirstOrDefault<DatosRevision>();
                //siempre existirá EL DATO DE REVISIÓN ya que no se permite la creación de nuevos en TERMINAL
                if (rs != null)
                {
                    dato = rs;
                    dato.Valor = dr.Valor;
                }
            }
            ctx.SaveChanges();
        }
        
        private void GuardarDispositivos(SqlCeConnection conn)
        {
            IList<TDispositivo> disps = CntSciTerminal.GetTDispositivos(conn);
            RadProgressContext context = RadProgressContext.Current;
            context.PrimaryTotal = 1;
            context.PrimaryValue = 1;
            context.PrimaryPercent = 100;
            int total = disps.Count;
            context.SecondaryTotal = total;
            int i = 0;
            foreach (TDispositivo disp in disps)
            {
                i++;
                if (disp.Abm == 0)
                    continue;
                RadProgress(context, i, total, disp.Nombre);
                // hay tres casos posible segun el valor de ABM
                // 0 = No cambia
                // 1 = nuevo
                // 2 = baja
                // 3 = modificación
                Dispositivo dispositivo;
                switch (disp.Abm)
                {
                    case 1:
                        // nuevo
                        // primero comprobamos que ese dispositivo no se ha dado de alta previamente
                        Dispositivo dsp = (from d in ctx.Dispositivos
                                           where d.CodBarras == disp.CodBarras
                                           select d).FirstOrDefault<Dispositivo>();
                        if (dsp != null) break; // ya existe han cargado dos veces el fichero.
                        dispositivo = new Dispositivo();
                        dispositivo.Nombre = disp.Nombre;
                        dispositivo.Instalacion = CntLainsaSci.GetInstalacion(disp.Instalacion.InstalacionId, ctx);
                        dispositivo.Operativo = disp.Operativo;
                        dispositivo.TipoDispositivo = CntLainsaSci.GetTipoDispositivo(disp.Tipo.TipoId, ctx);
                        if (disp.Modelo != null)
                            dispositivo.ModeloDispositivo = CntLainsaSci.GetModelodispositivo(disp.Modelo.ModeloId, ctx);
                        dispositivo.CodBarras = disp.CodBarras;
                        dispositivo.Funcion = "";
                        dispositivo.Estado = disp.Estado;
                        dispositivo.Caducado = false;
                        dispositivo.CargaKg = 0;
                        ctx.Add(dispositivo);
                        break;
                    case 2:
                        // baja
                        dispositivo = CntLainsaSci.GetDispositivo(disp.DispositivoId, ctx);
                        if (dispositivo != null)
                            ctx.Delete(dispositivo);
                        break;
                    case 3:
                        // modificación
                        dispositivo = CntLainsaSci.GetDispositivo(disp.DispositivoId, ctx);
                        if (dispositivo != null)
                        {
                            dispositivo.Operativo = disp.Operativo;
                            dispositivo.Estado = disp.Estado;
                        }
                        break;
                    default:
                        break;
                }
                ctx.SaveChanges();
            }
            context.CurrentOperationText = "Importación finalizada.";
            context.OperationComplete = true;
        }
        
        private void GuardarPrograma(SqlCeConnection conn)
        {
            IList<TPrograma> programas = CntSciTerminal.GetTProgramas(conn);
            foreach (TPrograma tp in programas)
            {
                var rs = (from d in ctx.Programas
                          where d.ProgramaId == tp.ProgramaId
                          select d).FirstOrDefault<Programa>();
                
                if (rs != null)
                    rs.Estado = tp.Estado;
                
                ctx.SaveChanges();
            }
        }
        
        private void PantallaValidacion(SqlCeConnection conn)
        {
            pantalla = new StringBuilder();
            pantalla.Append(String.Format("<b>Empresa: {0}</b><br/>", empresa.Nombre));
            //Incidencias
            IList<TIncidencia> incis = CntSciTerminal.GetTIncidencias(conn);
            pantalla.Append("--- INCIDENCIAS ------<br/>");
            if (incis != null)
            {
                foreach (TIncidencia inc in incis)
                {
                    // solo las incidencias que se han creado modificado o eliminado en el terminal
                    if (inc.Abm != 0)
                    {
                        pantalla.AppendLine(String.Format("ID:{6} Dispositivo: {0} ABM: {1} Apertura:{2:dd/MM/yyyy} Cierre:{3:dd/MM/yyyy} Prevista:{4:dd/MM/yyyy} Comentarios:{5} <br/>", 
                            inc.TDispositivo.Nombre,
                            inc.Abm,
                            inc.FechaApertura,
                            inc.FechaCierre,
                            inc.FechaPrevista,
                            inc.Comentarios,
                            inc.IncidenciaId));
                    }
                }
            }

            //Incidencias (Evolución)
            IList<TIncidenciaEvolucion> incievos = CntSciTerminal.GetTIncidenciaEvolucions(conn);
            pantalla.Append("--- INCIDENCIAS EVOLUCIONES ------<br/>");
            if (incievos != null)
            {
                foreach (TIncidenciaEvolucion inc in incievos)
                {
                    // solo las incidencias que se han creado modificado o eliminado en el terminal
                    if (inc.Abm != 0)
                    {
                        pantalla.AppendLine(String.Format("IDEVO:{4} IDINCI:{5} Dispositivo: {0} ABM: {1} Fecha:{2:dd/MM/yyyy} Comentarios:{3} <br/>",
                            inc.Incidencia.TDispositivo.Nombre,
                            inc.Abm,
                            inc.FechaEvolucion,
                            inc.Comentarios,
                            inc.IncidenciaEvolucionId,
                            inc.Incidencia.IncidenciaId));
                    }
                }
            }

            //Sustituciones
            IList<TSustitucion> sustituciones = CntSciTerminal.GetTSustituciones(conn);
            pantalla.AppendLine("--- SUSTITUCIONES ------<br/>");
            if (sustituciones != null)
            {
                foreach (TSustitucion sust in sustituciones)
                {
                    if (sust.Abm != 0)
                    {
                        var rs = (from d in ctx.Sustitucions
                                  where d.SustitucionId == sust.SustitucionId && d.DispositivoOriginal.DispositivoId == sust.TDispositivoOriginal.DispositivoId
                                  select d).FirstOrDefault<Sustitucion>();
                        if (rs == null)
                        {
                            if (sust.TDispositivoSustituto != null)
                            {
                                pantalla.AppendLine(String.Format("IDSUS:{0} Disp. Original:{1}  Disp. Sustituto:{2} Fecha:{3:dd/MM/yyyy} Comentarios:{4}<br/>",
                                    sust.SustitucionId,
                                    sust.TDispositivoOriginal.Nombre, 
                                    sust.TDispositivoSustituto.Nombre,
                                    sust.Fecha,
                                    sust.Comentarios));
                            }
                            else
                            {
                                // Si el sustituto es nulo el problema es que no se ha hecho la sustitución
                                pantalla.AppendLine(String.Format("IDSUS:{0} Disp. Original: {1} Fecha:{2:dd/MM/yyyy} Comentarios:{3} / Disp. ¿Sustitución no realizada?<br/>", 
                                    sust.SustitucionId,
                                    sust.TDispositivoOriginal.Nombre,
                                    sust.Fecha,
                                    sust.Comentarios));
                            }
                        }
                    }
                }
            }
            
            //Revisiones
            IList<TRevision> revisiones = CntSciTerminal.GetTRevisiones(conn);
            pantalla.AppendLine("--- REVISIONES ------<br/>");
            if (revisiones != null)
            {
                TPrograma p = null;
                int p_id = 0;
                foreach (TRevision rev in revisiones)
                {
                    if (rev.Abm != 0)
                    {
                        if ((p = rev.TPrograma) != null)
                            p_id = p.ProgramaId;
                        else
                            p_id = 0;
                        pantalla.AppendLine(String.Format("IDREV:{0} Dispositivo:{1} Fecha:{2:dd/MM/yyyy} Programa: {3} ABM:{4} Estado:{5} Comentario:{6}<br/>", 
                            rev.RevisionId,
                            rev.NDispositivo, 
                            rev.FechaRevision, 
                            p_id,
                            rev.Abm,
                            rev.Estado,
                            rev.Comentario));
                    }
                }
            }

            //Nuevos dispositivos
            IList<TDispositivo> dispositivos = CntSciTerminal.GetTNuevosDispositivos(conn);
            pantalla.Append("--- NUEVOS DISPOSITIVOS ------<br/>");
            if (dispositivos != null)
            {
                foreach (TDispositivo disp in dispositivos)
                {
                    pantalla.AppendLine(String.Format("ID:{0} Nombre:{1} Instalacion: {2} Tipo:{3} Modelo:{4} CodBarras:{5}<br/>",
                        disp.DispositivoId,
                        disp.Nombre,
                        disp.Instalacion.Nombre,
                        disp.Tipo.Nombre,
                        disp.Modelo.Nombre,
                        disp.CodBarras));
                }
            }

            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
            
            string msg = pantalla.ToString();
            msg = msg.Replace("'", "");
            msg = msg.Replace("<b>", "");
            msg = msg.Replace("</b>", "");
            msg = msg.Replace("<br/>", "\n");
            txtInf.Text = msg;
            
            //RadNotification2.Text = String.Format("<b>{0}</b><br/>{1}",
            //                                     (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
            //                                     pantalla.ToString());
            //RadNotification2.Show();
            
            // RadAjaxManager1.ResponseScripts.Add(String.Format("return radconfirm('¿Desea continuar con la importación?', confirmCallBackFn, 330, 100, null,'Importación', '');"));
            btnCargar.Visible = false;
            btnImportOK.Visible = true;
        }
        
        private static void RadProgress(RadProgressContext context, int n, int total, string nombre)
        {
            context.CurrentOperationText = "Importando dispositivo ... " + nombre;
            context.SecondaryValue = n;
            int x = n / total * 100;
            context.SecondaryPercent = x;
        }
        
        #region Llamado desde JavaScript
        
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            // OJO: Auitar
            //try
            //{
            file = new System.IO.FileInfo(lblPath.Text);
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            SqlCeConnection conn = GetConnection();

            RadProgress(RadProgressContext.Current, 1, 6, "GETEMPREWSA");
            GetEmpresa(conn);
            RadProgress(RadProgressContext.Current, 2, 6, "DISPOSITIVOS");
            GuardarDispositivos(conn);
            RadProgress(RadProgressContext.Current, 3, 6, "INCIDENCIAS");
            GuardarIncidencias(conn, ctx);
            RadProgress(RadProgressContext.Current, 4, 6, "INCIDENCIAS EVOLUCION");
            GuardarIncidenciaEvolucions(conn, ctx);
            // las revisiones las dejamos como estaban, al no incluir 
            // ni altas ni bajas (deberían serguir funcionando bien).
            RadProgress(RadProgressContext.Current, 5, 6, "REVISIONES");
            GuardarRevisiones(conn);
            //
            RadProgress(RadProgressContext.Current, 6, 6, "SUSTITUCIONES");
            GuardarSustituciones(conn, ctx);
            ctx.SaveChanges();
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
            RadWindowManager1.RadAlert("Proceso de importación finalizado",null,null,"AVISO","noHaceNada");
        }
        
        #endregion
        
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            // RadAjaxManager1.ResponseScripts.Add(String.Format("radconfirm('¿Desea continuar?', confirmCallBackFn, 330, 100, null,'Importación', '');"));
            string path = path = this.MapPath("/");
            //string curTempFileName = Path.GetTempFileName();
            //FileInfo f = new FileInfo(curTempFileName);
            
            //file = new FileInfo(FileUpload1.FileName);
            //if (RadUpload2.InvalidFiles.Count > 0)
            //{
            //    Label2.Visible = true;
            //}
            if (RadUpload2.UploadedFiles.Count > 0)
            {
                Label2.Visible = false;
                UploadedFile f = RadUpload2.UploadedFiles[0];
                string name =  f.GetName();
                string p = String.Format("{0}.sdf", Path.GetTempFileName());
                //string name = String.Format(@"{0}.sdf", Guid.NewGuid());
                //string filepath = string.Format("{0}BDII\\{1}", path, name);
                lblPath.Text = p;
                //if(File.Exists(filepath))
                //   filepath = String.Format(@"{0}.sdf", Guid.NewGuid());
                f.SaveAs(p);
                
                file = new System.IO.FileInfo(p);
                
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                SqlCeConnection conn = GetConnection();
                
                if (GetEmpresa(conn))
                {
                    PantallaValidacion(conn);
                }
                else
                {
                    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                        (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                        (string)GetGlobalResourceObject("ResourceLainsaSci", "ImportEmpresa"));
                    RadNotification1.Show();
                    return;
                }
            }
        }
        
        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            //args.IsValid = (RadUpload2.InvalidFiles.Count == 0);
        }
        
        protected void RadUpload1_ValidatingFile(object sender, Telerik.Web.UI.Upload.ValidateFileEventArgs e)
        {
            if (RadUpload2.UploadedFiles.Count > 0)
            {
                if (e.UploadedFile.GetExtension().ToLower() != ".sdf")
                {
                    e.IsValid = false;
                }
            }
        }

        protected void GuardarSustituciones(SqlCeConnection conn, LainsaSci ctx)
        {
            IList<TSustitucion> ltsu = CntSciTerminal.GetTSustituciones(conn);
            foreach (TSustitucion tsu in ltsu)
            {
                if (tsu.Abm == 0) continue; // no hay cambios
                Sustitucion sustitucion;
                switch (tsu.Abm)
                {
                    case 1:
                        // alta
                        // hay que controlar el doble procesamiento del fichero
                        Sustitucion sus = (from st in ctx.Sustitucions
                                           where st.DispositivoOriginal.DispositivoId == tsu.TDispositivoOriginal.DispositivoId
                                           && st.DispositivoSustituto.DispositivoId == tsu.TDispositivoSustituto.DispositivoId
                                           && st.Fecha == tsu.Fecha
                                           select st).FirstOrDefault<Sustitucion>();
                        if (sus != null) break; // entendemos que ya se ha dado de alta en otro procesamiento.
                        sustitucion = new Sustitucion();
                        // atributos directos
                        sustitucion.Fecha = tsu.Fecha;
                        sustitucion.Comentarios = tsu.Comentarios;
                        sustitucion.Estado = tsu.Estado;
                        // atributos como objetos
                        if (tsu.TUsuario != null)
                            sustitucion.Usuario = CntLainsaSci.GetUsuario(tsu.TUsuario.UsuarioId, ctx);
                        if (tsu.TDispositivoOriginal != null)
                            sustitucion.DispositivoOriginal = CntLainsaSci.GetDispositivo(tsu.TDispositivoOriginal.DispositivoId, ctx);
                        if (tsu.TDispositivoSustituto != null)
                            sustitucion.DispositivoSustituto = CntLainsaSci.GetDispositivo(tsu.TDispositivoSustituto.DispositivoId, ctx);
                        if (tsu.TRevision != null)
                            sustitucion.Revision = CntLainsaSci.GetRevision(tsu.TRevision.RevisionId, ctx);
                        if (tsu.TPrograma != null)
                            sustitucion.Programa = CntLainsaSci.GetPrograma(tsu.TPrograma.ProgramaId, ctx);
                        ctx.Add(sustitucion);
                        ctx.SaveChanges();
                        break;
                    case 2:
                        // baja
                        sustitucion = CntLainsaSci.GetSustitucion(tsu.SustitucionId, ctx);
                        if (sustitucion != null)
                        {
                            ctx.Delete(sustitucion);
                            ctx.SaveChanges();
                        }
                        break;
                    case 3:
                        // modificacion
                        sustitucion = CntLainsaSci.GetSustitucion(tsu.SustitucionId, ctx);
                        if (sustitucion != null)
                        {
                            // atributos directos
                            sustitucion.Fecha = tsu.Fecha;
                            sustitucion.Comentarios = tsu.Comentarios;
                            sustitucion.Estado = tsu.Estado;
                            // atributos como objetos
                            if (tsu.TUsuario != null)
                                sustitucion.Usuario = CntLainsaSci.GetUsuario(tsu.TUsuario.UsuarioId, ctx);
                            if (tsu.TDispositivoOriginal != null)
                                sustitucion.DispositivoOriginal = CntLainsaSci.GetDispositivo(tsu.TDispositivoOriginal.DispositivoId, ctx);
                            if (tsu.TDispositivoSustituto != null)
                                sustitucion.DispositivoSustituto = CntLainsaSci.GetDispositivo(tsu.TDispositivoSustituto.DispositivoId, ctx);
                            if (tsu.TRevision != null)
                                sustitucion.Revision = CntLainsaSci.GetRevision(tsu.TRevision.RevisionId, ctx);
                            if (tsu.TPrograma != null)
                                sustitucion.Programa = CntLainsaSci.GetPrograma(tsu.TPrograma.ProgramaId, ctx);
                            ctx.SaveChanges();
                        }
                        break;
                }
            }
        }

        protected void ImportOK_Click(object sender, EventArgs e)
        {
            // abrir una conexion con la base de datos seleccionada
            file = new System.IO.FileInfo(lblPath.Text);
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            SqlCeConnection conn = GetConnection();

            RadProgress(RadProgressContext.Current, 1, 6, "GETEMPREWSA");
            GetEmpresa(conn);
            RadProgress(RadProgressContext.Current, 2, 6, "DISPOSITIVOS");
            GuardarDispositivos(conn);
            RadProgress(RadProgressContext.Current, 3, 6, "INCIDENCIAS");
            GuardarIncidencias(conn, ctx);
            RadProgress(RadProgressContext.Current, 4, 6, "INCIDENCIAS EVOLUCION");
            GuardarIncidenciaEvolucions(conn, ctx);
            // las revisiones las dejamos como estaban, al no incluir 
            // ni altas ni bajas (deberían serguir funcionando bien).
            RadProgress(RadProgressContext.Current, 5, 6, "REVISIONES");
            GuardarRevisiones(conn);
            //
            RadProgress(RadProgressContext.Current, 6, 6, "SUSTITUCIONES");
            GuardarSustituciones(conn, ctx);
            ctx.SaveChanges();
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
            RadWindowManager1.RadAlert("Proceso de importación finalizado", null, null, "AVISO", "noHaceNada");
        }
    }
}