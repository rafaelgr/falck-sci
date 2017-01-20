using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;

using LainsaSciModelo;
using LainsaSciWinWeb;
using LainsaSciInformes;
using Telerik.Web.UI;
using System.Collections;
using LainsaTerminalLib;
using System.Data.SqlServerCe;

using System.Web.UI.WebControls;

namespace LainsaSciWinWeb
{
    public partial class ModeloTerminalGrid : System.Web.UI.Page
    {
        #region Definición de variables
        LainsaSci ctx = null; // conector con la base de datos
        Usuario usuario = null; // controla el usuario del login
        ProgramacionInforme prgInf = null;
        Dispositivo dispositivo = null;
        Empresa empresa = null;
        private static string path = null;
        private static string archivo = null;
        CargaTerminales terminal = null;
      
        #endregion

        #region Carga y descarga de la página
        protected void Page_Init(object sender, EventArgs e)
        {
            ctx = new LainsaSci("LainsaSciCTX"); // el conector figura en el config
            path = this.MapPath("/");
            UsuarioCorrecto(); // control de usuario logado

            if (!IsPostBack)
            {
                CargaComboEmpresa();
                Session["selectedItems"] = null;
                RadProgressArea1.Localization.UploadedFiles = "Registro procesado: ";
                RadProgressArea1.Localization.CurrentFileName = "Registro: ";
                RadProgressArea1.Localization.TotalFiles = "Total registros:";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (ctx != null)
                ctx.Dispose();
        }
        #endregion

        #region Botones generales
        protected void btnLanzador_Click(object sender, EventArgs e)
        {
            btnLanzador.Enabled = false;
            using (ctx)
            {
               empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
               if (empresa != null)
               {
                   if(ExportarTerminal(empresa, GetSelectedItems()))
                       GuardarTerminal();
                   Session["selectedItems"] = null;
                   RefreshGrid(true);
               }
           }
           btnLanzador.Enabled = true;
         }
        public void GuardarTerminal()
        {
              try
              {
                  terminal = CntLainsaSci.GetCargaTerminal(archivo, ctx);
                  if (terminal == null)
                  {
                      terminal = new CargaTerminales();
                      terminal.Empresa = empresa;
                      terminal.Archivo = archivo;
                      terminal.Fecha = DateTime.Now;
                      ctx.Add(terminal);
                  }
                  terminal.Fecha = DateTime.Now;
                  ctx.SaveChanges();
               }
               catch (Exception ex)
               {
                   ControlDeError(ex);
               }
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
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
        }
        #endregion

        #region Funciones auxiliares
        /// <summary>
        /// Comprueba que los campos son correctos
        /// antes de asignarlos
        /// </summary>
        /// <returns></returns>
        protected bool DatosOk()
        {
            bool res = true;

            return res;
        }
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

        public bool ExportarTerminal(Empresa empresa, ArrayList programas)
        {
            SqlCeConnection conn = null;
            try
            {
                //Inicializamos la barra de progreso
                RadProgressContext context = RadProgressContext.Current;
                context.PrimaryTotal = 1;
                context.PrimaryValue = 1;
                context.PrimaryPercent = 100;
                context.SecondaryTotal = 9;

                context.CurrentOperationText = "Exportando datos...";

                //C:\ProyectosNet\BasesDatos\TerminalFalck
                //string pathCE = @"C:\ProyectosNet\lainsa_sci\BD\terminal.sdf";
                LainsaSci ctx = new LainsaSci("LainsaSciCTX");

                //Línea para cambiar el comportamiento predeterminado de SQL Server Compact 3.5 para trabajar en ASP.NET.
                AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
                //SqlCeConnection conn = CntSciTerminal.TOpen(pathCE, "");
                conn = CrearSDF(empresa);

                if (conn != null)
                {

                    // Ahora buscamos primero usuarios
                    Console.WriteLine("Borrar todo lo anterior....");
                    BorrarTodo(conn);
                    RadProgress(context, 1);

                    CargarEmpresa(empresa, conn, ctx, context);

                    context.CurrentOperationText = "Exportando datos: cargando usuarios...";
                    CargarUsuarios(empresa, conn, ctx, context);
                    RadProgress(context, 2);

                    context.CurrentOperationText = "Exportando datos: cargando instalaciones...";
                    CargarInstalaciones(empresa, conn, ctx, context);
                    RadProgress(context, 3);

                    context.CurrentOperationText = "Exportando datos: cargando tipos de anomalía...";
                    CargarTipoAnomalias(conn, ctx, context);
                    RadProgress(context, 4);

                    context.CurrentOperationText = "Exportando datos: cargando tipos de dispositivo...";
                    CargarTiposD(empresa, conn, ctx, context);
                    RadProgress(context, 5);

                    context.CurrentOperationText = "Exportando datos: cargando modelos de dispositivo...";
                    CargarModelosD(empresa, conn, ctx, context);
                    RadProgress(context, 6);

                    context.CurrentOperationText = "Exportando datos: cargando dispositivos...";
                    CargarDispositivos(empresa, conn, ctx, context);
                    RadProgress(context, 7);

                    context.CurrentOperationText = "Exportando datos: cargando programas...";
                    CargarProgramas(empresa, programas, conn, ctx, context);
                    RadProgress(context, 8);

                    context.CurrentOperationText = "Exportando datos: cargando revisiones...";
                    CargarRevisionesPlanificadas(empresa, conn, ctx, context);
                    RadProgress(context, 9);

                    conn.Close();
                    conn.Dispose();

                    context.CurrentOperationText = "Exportación finalizada.";
                    context.OperationComplete = true;
            
                    return true;
                }
                context.CurrentOperationText = "ERROR en la exportación.";
                return false;
            }
            catch (Exception ex)
            {
                ControlDeError(ex);
                return false;
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private SqlCeConnection CrearSDF(Empresa empresa)
        {
            SqlCeEngine DBDatabase = null;
            try
            {
                if (!System.IO.File.Exists(string.Format("{0}BD\\terminal.sdf", path)))
                {
                    
                    RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
                                                         (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
                                                         (string)GetGlobalResourceObject("ResourceLainsaSci", "ExportFile"));
                    RadNotification1.Show();
                    return null;
                }

                System.IO.FileInfo file = new System.IO.FileInfo(string.Format("{0}BDII\\{1}_{2}.sdf",path, empresa.EmpresaId.ToString(), DateTime.Now.ToShortDateString()).Replace("/","_"));
                System.IO.File.Copy(string.Format("{0}BD\\terminal.sdf", path), file.FullName, true);
                archivo = file.Name;
                string conn = string.Format("Data Source={0};Password =;Persist Security Info=True", file);
                
                DBDatabase = new SqlCeEngine(conn);
                SqlCeConnection vCon = new System.Data.SqlServerCe.SqlCeConnection(conn);
                //SqlCeCommand VComandoSQL = new System.Data.SqlServerCe.SqlCeCommand("", vCon);

           
                //*** Creo la Base de Datos 
                //DBDatabase.CreateDatabase();
                //DBDatabase.Dispose();
                vCon.Open();

                return vCon;
            }
            catch(Exception VError) 
            {
                throw VError; 
            } 
            finally
            { 
            //    vCon.Close();
            //    vCon.Dispose();
            //    vCon = null;
                if(DBDatabase != null)
                    DBDatabase.Dispose();
            }
        }
        private static void RadProgress(RadProgressContext context, int n)
        {
            context.SecondaryValue = n;
            context.SecondaryPercent = (n / 9) * 100;
            //context.CurrentOperationText += "Doing step " + n.ToString();

            //context.TimeEstimated = 100 - (n / 6) * 100;
        }
        private static void BorrarTodo(SqlCeConnection conn)
        {
            int nrec = 0;
            string sql = "";
     
             using (SqlCeCommand cmd = conn.CreateCommand())
            {
                sql = "DELETE FROM Empresa";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Instalacion";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM ModeloDispositivo";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM TipoDispositivo";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM DatosRevision";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Dispositivo";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Grupo_Trabajo";
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
                sql = "DELETE FROM Incidencia";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM TipoAnomalia";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Usuario";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
            }
        }
        private static void CargarEmpresa(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            TEmpresa temp = new TEmpresa()
            {
                EmpresaId = empresa.EmpresaId,
                Nombre = empresa.Nombre
            };
            CntSciTerminal.TSave(temp, conn);
        }
        private static void CargarUsuarios(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from u in ctx.Usuarios
                     where u.Empresa.EmpresaId == empresa.EmpresaId || u.Empresa == null
                     select u;
           string texto = context.CurrentOperationText.ToString();
           foreach (Usuario usu in rs)
            {
                context.CurrentOperationText = String.Format("{0}{1}", texto, usu.Nombre);
                int grupo_trabajo = 0;
                if (usu.GrupoTrabajo != null)
                    grupo_trabajo = usu.GrupoTrabajo.GrupoTrabajoId;
                TUsuario tusu = new TUsuario()
                {
                    UsuarioId = usu.UsuarioId,
                    Nombre = usu.Nombre,
                    Login = usu.Login,
                    Password = usu.Password,
                    Grupo_Trabajo = grupo_trabajo
               };
                CntSciTerminal.TSave(tusu, conn);
            }
        }
        private static void CargarInstalaciones(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from i in ctx.Instalacions
                     where i.Empresa.EmpresaId == empresa.EmpresaId
                     select i;
            string texto = context.CurrentOperationText.ToString();
            foreach (Instalacion inst in rs)
            {
                context.CurrentOperationText = String.Format("{0}{1}", texto, inst.Nombre);
                TInstalacion tusu = new TInstalacion()
                {
                    InstalacionId = inst.InstalacionId,
                    Nombre = inst.Nombre
                };
                CntSciTerminal.TSave(tusu, conn);
            }
        }
        private static void CargarTiposD(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from td in ctx.TipoDispositivos
                     where td.Empresa.EmpresaId == empresa.EmpresaId
                     select td;
            string texto = context.CurrentOperationText.ToString();
            foreach (TipoDispositivo td in rs)
            {
                context.CurrentOperationText = String.Format("{0}{1}", texto, td.Nombre);
                TTipoDispositivo tusu = new TTipoDispositivo()
                {
                    TipoId = td.TipoId,
                    Nombre = td.Nombre
                };
                CntSciTerminal.TSave(tusu, conn);
            }
        }
        private static void CargarModelosD(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from td in ctx.ModeloDispositivos
                     where td.Empresa.EmpresaId == empresa.EmpresaId
                     select td;
            string texto = context.CurrentOperationText.ToString();
            foreach (ModeloDispositivo td in rs)
            {
                context.CurrentOperationText = String.Format("{0}{1}", texto, td.Nombre);
                TModeloDispositivo tusu = new TModeloDispositivo()
                {
                    ModeloId = td.ModeloId,
                    Nombre = td.Nombre
                };
                CntSciTerminal.TSave(tusu, conn);
            }
        }
        private static void CargarDispositivos(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from d in ctx.Dispositivos
                     where d.Instalacion.Empresa.EmpresaId == empresa.EmpresaId
                     select d;
            string texto = context.CurrentOperationText.ToString();
            foreach (Dispositivo dsp in rs)
            {
                context.CurrentOperationText = String.Format("{0}{1}", texto, dsp.Nombre);
                TModeloDispositivo modelo = null;
                if (dsp.ModeloDispositivo != null)
                    modelo = CntSciTerminal.GetTModeloDispositivo(dsp.ModeloDispositivo.ModeloId, conn);
                TDispositivo tdsp = new TDispositivo()
                {
                    DispositivoId = dsp.DispositivoId,
                    Nombre = dsp.Nombre,
                    Empresa = dsp.Instalacion.Empresa.Nombre,
                    Instalacion = CntSciTerminal.GetTInstalacion(dsp.Instalacion.InstalacionId,conn),
                    Tipo = CntSciTerminal.GetTTipoDispositivo(dsp.TipoDispositivo.TipoId, conn),
                    Modelo = modelo,
                    Funcion = dsp.Funcion,
                    Estado = dsp.Estado,
                    FechaCaducidad = dsp.FechaCaducidad,
                    Caducado = dsp.Caducado,
                    FechaBaja = dsp.FechaBaja,
                    CodBarras = dsp.CodBarras,
                    Operativo = dsp.Operativo,
                    Posicion = dsp.Posicion,
                };

                CntSciTerminal.TSave(tdsp, conn);

                foreach (Incidencia incidencia in dsp.Incidencias)
                    CargarIncidencias(incidencia, conn, ctx);
               
            }
        }
        private static void CargarIncidencias(Incidencia incidencia, SqlCeConnection conn, LainsaSci ctx)
        {
            TUsuario tusu = null;
            TDispositivo tdispo = null;
            if (incidencia.Usuario != null) tusu = CntSciTerminal.GetTUsuario(incidencia.Usuario.UsuarioId, conn);
            if (incidencia.Dispositivo != null) tdispo = CntSciTerminal.GetTDispositivo(incidencia.Dispositivo.DispositivoId, conn);
            TIncidencia ts = new TIncidencia()
            {
               IncidenciaId = incidencia.IncidenciaId,
               Fecha = incidencia.Fecha,
               Operativo = incidencia.Operativo,
               Dispositivo = tdispo,
               Usuario = tusu,
               Comentarios = incidencia.Comentarios
            };
            CntSciTerminal.TSave(ts, conn);
        }
        private static void CargarProgramas(Empresa empresa, ArrayList programas, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            string texto = context.CurrentOperationText.ToString();
            
             Int16 stackIndex;
             for (stackIndex = 0; stackIndex <= programas.Count - 1; stackIndex++)
             {
                 string curItem = programas[stackIndex].ToString();
                 int id = int.Parse(curItem);
                 Programa p = CntLainsaSci.GetPrograma(id, ctx);

                 if (p.Revisions != null && p.Revisions.Count > 0)
                     if (p.Revisions[0].Dispositivo.Instalacion.Empresa.EmpresaId != empresa.EmpresaId)
                         continue;

                 context.CurrentOperationText = String.Format("{0}{1}", texto, id);
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
           
            //foreach (string programaId in programas)
            //{
            //    Programa p = CntLainsaSci.GetPrograma(int.Parse(programaId), ctx);
                
            //    if (p.Revisions != null && p.Revisions.Count > 0)
            //         if (p.Revisions[0].Dispositivo.Instalacion.Empresa.EmpresaId != empresa.EmpresaId)
            //             continue;

            //    context.CurrentOperationText = String.Format("{0}{1}", texto, programaId);
            //    TPrograma tp = new TPrograma()
            //    {
            //        ProgramaId = p.ProgramaId,
            //        Usuario = CntSciTerminal.GetTUsuario(p.Usuario.UsuarioId, conn),
            //        Estado = p.Estado,
            //        FechaProgramada = p.FechaProgramada,
            //        Comentarios = p.Comentarios
            //    };
            //    CntSciTerminal.TSave(tp, conn);
            //    foreach (Revision r in p.Revisions)
            //    {
            //        CargarRevision(r, conn, ctx);
            //    }
            //    foreach (Sustitucion s in p.Sustitucions)
            //    {
            //        CargarSustitucion(s, conn, ctx);
            //    }
            //}
        }
        private static void CargarTipoAnomalias(SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from ta in ctx.TipoAnomalias
                     select ta;
            string texto = context.CurrentOperationText.ToString();
            foreach (TipoAnomalia ta in rs)
            {
                String.Format("{0}{1}", texto, ta.TipoAnomaliaId);
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
            if (r.Programa != null) tpr = CntSciTerminal.GetTPrograma(r.Programa.ProgramaId, conn);
            TDispositivo d = CntSciTerminal.GetTDispositivo(r.Dispositivo.DispositivoId, conn);
            TRevision tr = new TRevision()
            {
                RevisionId = r.RevisionId,
                Dispositivo = d,
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
            string v1 = null, v3 = null, v4 = null;
            int v2 = 0;
            if (dr.Campo != null)
            {
                if(dr.Campo.TipoCampo != null)
                   v1 = dr.Campo.TipoCampo.Descripcion;
                v2 = dr.Campo.Posicion;
                v3 = dr.Campo.Nombre;
            }

            TDatoRevision tdr = new TDatoRevision()
            {
                DatosId = dr.DatosId,
                TRevision = CntSciTerminal.GetTRevision(dr.Revision.RevisionId, conn),
                Tipo = v1,
                Posicion =v2,
                Nombre = v3,
                Valor = dr.Valor
            };
            CntSciTerminal.TSave(tdr, conn);
        }
        private static void CargarRevisionesPlanificadas(Empresa empresa, SqlCeConnection conn, LainsaSci ctx, RadProgressContext context)
        {
            var rs = from r in ctx.Revisions
                     where r.Dispositivo.Instalacion.Empresa.EmpresaId == empresa.EmpresaId
                     && r.Programa == null && r.Estado != "REALIZADA" 
                     select r;
            string texto = context.CurrentOperationText.ToString();
            foreach (Revision r in rs)
            {
                context.CurrentOperationText = String.Format("{0}{1}", texto, r.RevisionId);
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
                SustitucionId = s.SustitucionId,
                Comentarios = s.Comentarios,
                Estado = s.Estado,
                TUsuario = tusu,
                TDispositivoOriginal = tdispo,
                TDispositivoSustituto = tdisps,
                TPrograma = tpr,
                Fecha = s.Fecha
            };
            CntSciTerminal.TSave(ts, conn);
        }
        #endregion

        #region Llamado desde JavaScript
        protected void rdcEmpresa_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value != "")
            {
                empresa = CntLainsaSci.GetEmpresa(int.Parse(e.Value), ctx);
                RefreshGrid(true);
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaProgramada"].Text)))
                {
                    item["FechaProgramada"].Text = "";
                }
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RefreshGrid(false);
        }
        protected void ToggleRowSelection(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridDataItem dataItem = (GridDataItem)chk.NamingContainer;
            dataItem.Selected = chk.Checked;
            string programaId = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ProgramaId"].ToString();
            ArrayList selectedItems = GetSelectedItems();
            if (chk.Checked)
                selectedItems.Add(programaId);
            else
            {
                selectedItems.Remove(programaId);
                dataItem.Selected = false;
                System.Drawing.Color ARG = dataItem.BackColor;
            }
            Session["selectedItems"] = selectedItems;
        }

        protected void ToggleSelectedState(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            ArrayList selectedItems = GetSelectedItems();
            foreach (GridDataItem dataItem in RadGrid1.MasterTableView.Items)
            {
                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = headerCheckBox.Checked;
                dataItem.Selected = headerCheckBox.Checked;
                string programaId = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ProgramaId"].ToString();
                if (headerCheckBox.Checked)
                {
                    if (!selectedItems.Contains(programaId))
                        selectedItems.Add(programaId);
                }
                else
                {
                    selectedItems.Remove(programaId);
                    dataItem.Selected = false;
                }
            }
            Session["selectedItems"] = selectedItems;
        }
        protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            ArrayList selectedItems;
            if ((selectedItems = GetSelectedItems()).Count > 0)
            {
                Int16 stackIndex;
                for (stackIndex = 0; stackIndex <= selectedItems.Count - 1; stackIndex++)
                {
                    string curItem = selectedItems[stackIndex].ToString();
                    foreach (GridItem item in RadGrid1.MasterTableView.Items)
                    {
                        if (item is GridDataItem)
                        {
                            GridDataItem dataItem = (GridDataItem)item;
                            if (curItem.Equals(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["ProgramaId"].ToString()))
                            {
                                (dataItem.FindControl("CheckBox1") as CheckBox).Checked = true;
                                dataItem.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
      
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            RefreshGrid(true);
            RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
        }
        #endregion

      
        #region Auxiliary
        protected void CargaComboEmpresa()
        {
            rdcEmpresa.Items.Clear();
            if (usuario == null)
                return;
            foreach (Empresa emp in CntLainsaSci.GetEmpresas(usuario, ctx))
            {
                rdcEmpresa.Items.Add(new RadComboBoxItem(emp.Nombre, emp.EmpresaId.ToString()));
            }
            if (rdcEmpresa.Items.Count > 0)
            {
                rdcEmpresa.Items[0].Selected = true;
                empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
            }
            //rcbEmpresa.Text = "";
        }
        protected ArrayList GetSelectedItems()
        {
            ArrayList selectedItems;
            if (Session["selectedItems"] == null)
            {
                selectedItems = new ArrayList();
            }
            else
            {
                selectedItems = (ArrayList)Session["selectedItems"];
            }
            return selectedItems;
        }
        protected void RefreshGrid(bool rebind)
        {
            empresa = CntLainsaSci.GetEmpresa(int.Parse(rdcEmpresa.SelectedValue), ctx);
            RadGrid1.DataSource = CntLainsaSci.GetProgramas(empresa, usuario, ctx);
            if (rebind)
                RadGrid1.Rebind();
        }
        #endregion
       
    }
}


//using System;
//using Telerik.OpenAccess;
//using LainsaSciModelo;
//using LainsaSciWinWeb;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
//using System.Configuration;
//using System.Web.Security;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using Telerik.Web.UI;

//namespace LainsaSciWinWeb
//{
//    public partial class ModeloTerminalGrid : System.Web.UI.Page
//    {
//          #region Global variables declaration
//    LainsaSci ctx; // openaccess context used in this page
//    Usuario Usuario; // Usuario loged
//    Permiso permiso;
//    string mode = ""; // the way it's called, S = for search
//    string caller = ""; // who's calling the grid form
//    #endregion
//    #region Init, load, unload events
//    protected void Page_Init(object sender, EventArgs e)
//    {
//        // it gets an appropiate context (LainsaSciCTX -> web.config)
//        ctx = new LainsaSci("LainsaSciCTX");
//        // verify if a Usuario is logged
//        Usuario = CntWinWeb.IsSomeoneLogged(this, ctx);
//        if (Usuario == null)
//            Response.Redirect("Default.aspx");
//        else
//            Session["UsuarioId"] = Usuario.UsuarioId;
//        //
//        permiso = CntLainsaSci.GetPermiso(Usuario.GrupoUsuario, "grupousuariogrid", ctx);
//        if (permiso == null)
//        {
//            RadNotification1.Text = String.Format("<b>{0}</b><br/>{1}",
//                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "Warning"),
//                                                  (string)GetGlobalResourceObject("ResourceLainsaSci", "NoPermissionsAssigned"));
//            RadNotification1.Show();
//            RadAjaxManager1.ResponseScripts.Add("closeWindow();");
//        }
//        CntWinWeb.TranslateRadGridFilters(RadGrid1);
//        if (Request.QueryString["Mode"] != null)
//            mode = Request.QueryString["Mode"];
//        if (Request.QueryString["Caller"] != null)
//            caller = Request.QueryString["Caller"];
//    }

//    protected void Page_Load(object sender, EventArgs e)
//    {
//    }

//    protected void Page_Unload(object sender, EventArgs e)
//    {
//        // it closes context in order to release resources
//        if (ctx != null)
//            ctx.Dispose();
//        //
//        //Session["CategoriaGrid"] = null;
//    }
//    #endregion
//    #region RadGrid events
//    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
//    {
//        RefreshGrid(false);
//    }

//    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
//    {
//        if (e.Item is GridCommandItem)
//        {
//            GridCommandItem item = (GridCommandItem)e.Item;
//            ImageButton imgb = (ImageButton)item.FindControl("New");
//            imgb.Visible = permiso.Crear;
//        }
//        if (e.Item is GridDataItem)
//        {
//            ImageButton imgb = null;
//            string jCommand = "";
//            GridDataItem item = (GridDataItem)e.Item;
//            string strKey = item.GetDataKeyValue("Id").ToString();
            
//            // when it returns from form with new record
//            if (Session["NewRecordId"] != null)
//            {
//                if (strKey == Session["NewRecordId"] as String)
//                {
//                    item.Selected = true;
//                    Session["NewRecordId"] = null;
//                }
//            }
            
//            // in order to assign the appropiate javascript function to select button
//            imgb = (ImageButton)item.FindControl("Select");
//            jCommand = String.Format("returnValues2('{0}','{1}');", strKey, item["Nombre"].Text);
//            imgb.OnClientClick = jCommand;
//            if (mode == "S") imgb.Visible = true;
//                else imgb.Visible = false;

//            // assign the appropiate javascript function to edit button
//            imgb = (ImageButton)item.FindControl("Edit");
//            jCommand = String.Format("editModeloTerminal('{0}');", strKey);
//            imgb.OnClientClick = jCommand;
//            imgb.Visible = permiso.Ver;

//            // assign to delete button (not needed by now)
//            imgb = (ImageButton)item.FindControl("Delete");
//            jCommand = String.Format("return radconfirm('{0}',event,300,100,'','{1}');", Resources.ResourceLainsaSci.DeleteRecordQuestion + " " + item["Nombre"].Text, Resources.ResourceLainsaSci.DeleteRecord);
//            imgb.OnClientClick = jCommand;
//            imgb.Visible = permiso.Crear;
//        }
//    }

//    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
//    {
//        // we only process commands with a datasource (our image buttons)
//        if (e.CommandSource == null)
//            return;
//        string typeOfControl = e.CommandSource.GetType().ToString();
//        if (typeOfControl.Equals("System.Web.UI.WebControls.ImageButton"))
//        {
//            int id = 0;
//            ImageButton imgb = (ImageButton)e.CommandSource;
//            if (imgb.ID != "New" && imgb.ID != "Exit")
//                id = int.Parse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]].ToString());
//            switch (imgb.ID)
//            {
//                case "Select":
//                    break;
//                case "Edit":
//                    break;
//                case "Delete":
//                    try
//                    {
//                        ModelosTerminales p = CntLainsaSci.GetModeloTerminal(id, ctx);
//                        CntLainsaSci.CTXEliminar(p, ctx);
//                        CntLainsaSci.CTXGuardar(ctx);
//                        RefreshGrid(true);
//                    }
//                    catch (Exception ex)
//                    {
//                        ControlDeError(ex);
//                    }
//                    break;
//            }
//        }
//    }
//    #endregion
//    #region Auxiliary 
//    protected void RefreshGrid(bool rebind)
//    {
//        RadGrid1.DataSource = CntLainsaSci.GetModelosTerminales(ctx);
//        if (rebind)
//            RadGrid1.Rebind();
//    }
//    #endregion

//    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
//    {
//        if (e.Argument == "new")
//            RadGrid1.CurrentPageIndex = RadGrid1.PageCount - 1;
//        RefreshGrid(true);
//        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
//    }

//    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
//    {
//        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
//    }
//    protected void ControlDeError(Exception ex)
//    {
//        ErrorControl eC = new ErrorControl();
//        eC.ErrorUsuario = Usuario;
//        eC.ErrorProcess = permiso.Proceso;
//        eC.ErrorDateTime = DateTime.Now;
//        eC.ErrorException = ex;
//        Session["ErrorControl"] = eC;
//        RadAjaxManager1.ResponseScripts.Add("openOutSide('ErrorForm.aspx','ErrorForm');");
//    }

//    protected void btnInforme_Click(object sender, EventArgs e)
//    {
//        string url = String.Format("VisorInforme.aspx?Informe=RptModeloTerminal3");
//        string jCommand = String.Format("openOutSide('{0}','{1}');", url, "VisorInforme");
//        RadAjaxManager1.ResponseScripts.Add(jCommand);
//    }
//}
    
//}