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

namespace LainsaSciWinWeb
{
    public partial class ImportarTerminal : System.Web.UI.Page
    {
        #region Definición de variables
        LainsaSci ctx = null; // conector con la base de datos
        Usuario usuario = null; // controla el usuario del login
        private static string path = null;
        private static string archivo = null;
        private CargaTerminales terminal = null;
        private FileInfo file;
        private Empresa empresa;

        #endregion

        #region Carga y descarga de la página
        protected void Page_Init(object sender, EventArgs e)
        {
            ctx = new LainsaSci("LainsaSciCTX"); // el conector figura en el config
            path = this.MapPath("/");
            UsuarioCorrecto(); // control de usuario logado

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
                        where d.EmpresaId== emp.EmpresaId
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
                         where d.IncidenciaId== inc.IncidenciaId && d.Dispositivo.DispositivoId == dispositivo.DispositivoId
                         select d).FirstOrDefault<Incidencia>();
                if (rs != null)
                {
                    incidencia = rs;
                    incidencia.Operativo = inc.Operativo;
                    incidencia.Comentarios = inc.Comentarios;
                }
                else
                {
                    incidencia = new Incidencia()
                    {
                        Fecha = inc.Fecha,
                        Comentarios = inc.Comentarios,
                        Dispositivo = dispositivo,
                        Operativo = inc.Operativo,
                        Usuario = CntLainsaSci.GetUsuario(inc.Usuario.UsuarioId, ctx)
                    };
                    dispositivo.Operativo = incidencia.Operativo;
                    ctx.Add(incidencia);
                }
                ctx.SaveChanges();
             }
        }
        private void GuardarSustituciones(Dispositivo dispositivo, TDispositivo disp, SqlCeConnection conn)
        {
            IList<TSustitucion> sustituciones = CntSciTerminal.GetTSustituciones(disp, conn);
            foreach (TSustitucion sust in sustituciones)
            {
                Sustitucion sustitucion;
                var rs = (from d in ctx.Sustitucions
                         where d.SustitucionId== sust.SustitucionId &&  d.DispositivoOriginal.DispositivoId== dispositivo.DispositivoId
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
                    if(sust.TRevision != null)
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
                ctx.SaveChanges();
            }
           
        }
        private void GuardarRevisiones(TDispositivo disp, SqlCeConnection conn)
        {
            IList<TRevision> revisiones = CntSciTerminal.GetTRevisiones(disp, conn);
            foreach (TRevision rev in revisiones)
            {
                Revision revision;
                var rs = (from d in ctx.Revisions
                         where d.RevisionId == rev.RevisionId
                         select d).FirstOrDefault<Revision>();
                //siempre existirá la revisión ya que no se permite la creación de nuevas en TERMINAL
                if (rs != null)
                {
                    revision = rs;
                    if(rev.FechaRevision != null)
                        revision.FechaRevision = rev.FechaRevision;
                    revision.FechaPlanificada = rev.FechaPlanificada;
                    revision.Resultado = rev.Resultado;
                    revision.Observaciones = rev.Comentario;
                    if(rev.Usuario != null)
                        revision.Usuario = CntLainsaSci.GetUsuario(rev.Usuario.UsuarioId, ctx);
                    revision.Estado = rev.Estado;
                    if (rev.TTipoAnomalia != null)
                        revision.TipoAnomalia = CntLainsaSci.GetTipoAnomalia(rev.TTipoAnomalia.TipoAnomaliaId, ctx);
                }
                else
                {
                   // revision = new Revision();
                   // revision.FechaRevision = rev.FechaRevision;
                   // revision.Resultado = rev.Resultado;
                   // if (rev.Usuario != DBNull.Value)
                   //     revision.Usuario = CntLainsaSci.GetUsuario(rev.Usuario.UsuarioId, ctx);
                   // revision.ResumenInforme = CntLainsaSci.GetResumenInforme(revision, ctx);
                   // revision.Estado = rev.Estado;
                   // if (rev.TTipoAnomalia != DBNull.Value)
                   //     revision.TipoAnomalia = CntLainsaSci.GetTipoAnomalia(rev.TTipoAnomalia.TipoAnomaliaId, ctx);
                   // revision.Dispositivo = CntLainsaSci.GetDispositivo(rev.Dispositivo.DispositivoId, ctx);

                   //// revision.ResumenInforme = CntLainsaSci.GetResumenInforme(revision, ctx);
                   // ctx.Add(revision);
                }
                ctx.SaveChanges();
                CargarDatosRevision(rev, conn);
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
                ctx.SaveChanges();
            }
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
            
                RadProgress(context, i, total, disp.Nombre);
                Dispositivo dispositivo;
                var rs = (from d in ctx.Dispositivos
                         where d.Instalacion.Empresa.EmpresaId == empresa.EmpresaId && d.DispositivoId == disp.DispositivoId
                         select d).FirstOrDefault<Dispositivo>();
                if (rs != null)
                {
                    dispositivo = rs;
                    dispositivo.Operativo = disp.Operativo;
                    dispositivo.Estado = disp.Estado;
                }
                else
                {
                    dispositivo = new Dispositivo();
                    dispositivo.Nombre = disp.Nombre;
                    dispositivo.Instalacion = CntLainsaSci.GetInstalacion(disp.Instalacion.InstalacionId, ctx);
                    dispositivo.Operativo = disp.Operativo;
                    dispositivo.TipoDispositivo = CntLainsaSci.GetTipoDispositivo(disp.Tipo.TipoId, ctx);
                    if(disp.Modelo != null)
                        dispositivo.ModeloDispositivo = CntLainsaSci.GetModelodispositivo(disp.Modelo.ModeloId, ctx);
                    dispositivo.CodBarras = disp.CodBarras;

                    dispositivo.Funcion = "";
                    dispositivo.Estado = disp.Estado;
                    dispositivo.Caducado = false;
                    dispositivo.CargaKg = 0;
                                    
                    ctx.Add(dispositivo);
                }
                ctx.SaveChanges();
                
                //Si es un nuevo dispositivo lo buscamos, para así tener su nuevo id
                if(rs==null)
                     dispositivo= CntLainsaSci.GetLastDispositivo(ctx);
                
                CntLainsaSci.CrearResumenesRevision(dispositivo, ctx);
                GuardarIncidencias(dispositivo, disp, conn);
                GuardarSustituciones(dispositivo, disp, conn);
                GuardarRevisiones(disp, conn);
                
            }
            context.CurrentOperationText = "Importación finalizada.";
            context.OperationComplete = true;
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
            try
            {
                string path = path = this.MapPath("/");
                string f = e.Argument.Replace("/", @"\");

                file = new System.IO.FileInfo(string.Format("{0}{1}", path, f));

                //int empresa_id = int.Parse(file.Name.Split('_')[0]);
                
                //empresa = CntLainsaSci.GetEmpresa(empresa_id, ctx);
                //if(empresa != null)
                 
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                SqlCeConnection conn = GetConnection();

                if (GetEmpresa(conn))
                {
                    string mens = "La empresa {0} con ID = {1} va a ser importada.\n¿Desea continuar?";
                    RadAjaxManager1.ResponseScripts.Add(String.Format("return radconfirm('{0}',event,300,100,'','IMPORTACIÓN');", mens));
                   // GuardarDispositivos(conn);
                   // ctx.SaveChanges();
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
            catch (Exception ex)
            {
                RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                     (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                    ex.Message);
                RadNotification1.Show();
                return;
            }
        }
        #endregion

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }

        protected void RadButton1_Click(object sender, EventArgs e)
        {
           int a = RadUpload1.UploadedFiles.Count;
        }
    }
}