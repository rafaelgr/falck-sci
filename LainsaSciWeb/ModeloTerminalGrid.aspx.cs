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
using System.Diagnostics;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlServerCe;


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
            // control de skin
            if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

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
                    if (ExportarTerminal(empresa, GetSelectedItems()))
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
            SqlCeConnection connCE = null;
            MySqlConnection connMy = null;


            RadProgressContext context = RadProgressContext.Current;
            context.PrimaryTotal = 1;
            context.PrimaryValue = 1;
            context.PrimaryPercent = 100;
            context.SecondaryTotal = 16;
            
            context.CurrentOperationText = "Exportando datos...";
            
            //Línea para cambiar el comportamiento predeterminado de SQL Server Compact 3.5 para trabajar en ASP.NET.
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);

            connCE = CrearSDF(empresa);

            connMy = new MySqlConnection(ConfigurationManager.ConnectionStrings["LainsaSciCTX"].ConnectionString);
            connMy.Open();

            if (connCE != null && connMy != null){

                Console.WriteLine("Borrar todo lo anterior....");
                BorrarTodo(connCE);

                CargarEmpresa(empresa, connCE, connMy, context);
                RadProgress(context, 1);

                context.CurrentOperationText = "Exportando datos: cargando usuarios...";
                CargarUsuarios(empresa, connCE, connMy, context);
                RadProgress(context, 2);

                context.CurrentOperationText = "Exportando datos: cargando estados...";
                CargarEstado(empresa, connCE, connMy, context);
                RadProgress(context, 3);

                context.CurrentOperationText = "Exportando datos: cargando prioridades...";
                CargarPrioridad(empresa, connCE, connMy, context);
                RadProgress(context, 4);

                context.CurrentOperationText = "Exportando datos: cargando responsables...";
                CargarResponsable(empresa, connCE, connMy, context);
                RadProgress(context, 5);

                context.CurrentOperationText = "Exportando datos: cargando instalaciones...";
                CargarInstalaciones(empresa, connCE, connMy, context);
                RadProgress(context, 6);

                context.CurrentOperationText = "Exportando datos: cargando tipos de anomalía...";
                CargarTipoAnomalias(empresa, connCE, connMy, context);
                RadProgress(context, 7);

                context.CurrentOperationText = "Exportando datos: cargando tipos de dispositivo...";
                CargarTipoDispositivos(empresa, connCE, connMy, context);
                RadProgress(context, 8);

                context.CurrentOperationText = "Exportando datos: cargando modelos de dispositivo...";
                CargarModeloDispositivo(empresa, connCE, connMy, context);
                RadProgress(context, 9);

                context.CurrentOperationText = "Exportando datos: cargando dispositivos...";
                CargarDispositivos(empresa, connCE, connMy, context);
                RadProgress(context, 10);

                context.CurrentOperationText = "Exportando datos: cargando incidencias...";
                CargarIncidencias(empresa, connCE, connMy, context);
                RadProgress(context, 11);

                context.CurrentOperationText = "Exportando datos: cargando evolucion incidencias...";
                CargarIncidenciaEvolucion(empresa, connCE, connMy, context);
                RadProgress(context, 12);

                string prg = "";
                if(programas.Count==0){
                    prg = "0";
                }else{
                    prg = String.Join(",", programas.ToArray());
                }
                    
                    

                context.CurrentOperationText = "Exportando datos: cargando programas...";
                CargarProgramas(empresa, prg, connCE, connMy, context);
                RadProgress(context, 13);

                context.CurrentOperationText = "Exportando datos: cargando revisiones...";
                CargarRevision(empresa, prg, connCE, connMy, context);
                RadProgress(context, 14);

                context.CurrentOperationText = "Exportando datos: cargando datos revisiones...";
                CargarDatoRevision(empresa, prg, connCE, connMy, context);
                RadProgress(context, 15);

                context.CurrentOperationText = "Exportando datos: cargando datos sustituciones...";
                CargarSustitucion(empresa, prg, connCE, connMy, context);
                RadProgress(context, 16);



                connCE.Close();
                connCE.Dispose();
                connMy.Close();
                connMy.Dispose();
                
                context.CurrentOperationText = "Exportación finalizada.";
                context.OperationComplete = true;
            
                return true;
            }
            context.CurrentOperationText = "ERROR en la exportación.";
            return false;
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
                
                System.IO.FileInfo file = new System.IO.FileInfo(string.Format("{0}BDII\\{1}_{2:yyyyMMddHHmmss}.sdf", path, empresa.EmpresaId.ToString(), DateTime.Now));
                System.IO.File.Copy(string.Format("{0}BD\\terminal.sdf", path), file.FullName, true);
                archivo = file.Name;
                string conn = string.Format("Data Source={0};Password =;Persist Security Info=True", file);
                
                DBDatabase = new SqlCeEngine(conn);
                SqlCeConnection vCon = new System.Data.SqlServerCe.SqlCeConnection(conn);
                vCon.Open();
            
                return vCon;
            }
            catch (Exception VError) 
            {
                throw VError; 
            }
            finally
            { 
                if (DBDatabase != null)
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

        private static void BorrarTodo(SqlCeConnection conn){
            int nrec = 0;
            string sql = "";
            using (SqlCeCommand cmd = conn.CreateCommand()){
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
                // nuevas tablas de incidencias
                sql = "DELETE FROM IncidenciaEvolucion";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Estado";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Prioridad";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
                sql = "DELETE FROM Responsable";
                cmd.CommandText = sql;
                nrec = cmd.ExecuteNonQuery();
            }
        }

        private static void CargarEmpresa(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context){
            string sql = @"
                INSERT INTO 
                    Empresa
                        (
                            empresa_id, 
                            nombre
                        ) 
                VALUES
                    ( 
                        " + empresa.EmpresaId.ToString() + @",
                        '" + empresa.Nombre + @"'
                    )
                ";
            using (SqlCeCommand cmd = connCE.CreateCommand()){
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private static void CargarUsuarios(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                usuario_id,
	                nombre,
	                login,
	                passwd,
	                IFNULL(grupo_trabajo_id, 0) AS grupo_trabajo_id
                FROM 
	                usuario
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
	                OR empresa_id IS NULL
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    Usuario
                                        (
                                            usuario_id, 
                                            nombre, 
                                            login, 
                                            password, 
                                            grupo_trabajo_id
                                        ) 
                                    VALUES
                                        (
                                            " + dr["usuario_id"].ToString() + @",
                                            '" + txt + @"',
                                            '" + dr["login"].ToString() + @"',
                                            '" + dr["passwd"].ToString() + @"',
                                            " + dr["grupo_trabajo_id"].ToString() + @"
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarEstado(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                estado_id,
	                nombre,
	                en_cierre,
	                en_apertura
                FROM 
	                estado
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    Estado
                                        (
                                            estado_id, 
                                            nombre, 
                                            en_cierre, 
                                            en_apertura
                                        ) 
                                    VALUES
                                        (
                                            " + dr["estado_id"].ToString() + @",
                                            '" + txt + @"',
                                            " + dr["en_cierre"].ToString() + @",
                                            " + dr["en_apertura"].ToString() + @"
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarPrioridad(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                prioridad_id,
	                nombre
                FROM 
	                prioridad
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    Prioridad
                                        (
                                            prioridad_id, 
                                            nombre
                                        ) 
                                    VALUES
                                        (
                                            " + dr["prioridad_id"].ToString() + @",
                                            '" + txt + @"'
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarResponsable(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                responsable_id,
	                nombre
                FROM 
	                responsable
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    Responsable
                                        (
                                            responsable_id, 
                                            nombre
                                        ) 
                                    VALUES
                                        (
                                            " + dr["responsable_id"].ToString() + @",
                                            '" + txt + @"'
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarInstalaciones(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                instalacion_id,
	                nombre
                FROM 
	                instalacion
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    Instalacion
                                        (
                                            instalacion_id, 
                                            nombre
                                        ) 
                                    VALUES
                                        (
                                            " + dr["instalacion_id"].ToString() + @",
                                            '" + txt + @"'
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarTipoAnomalias(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                tipo_anomalia_id,
	                nombre
                FROM 
	                tipo_anomalia
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    TipoAnomalia
                                        (
                                            tipo_anomalia_id, 
                                            nombre
                                        ) 
                                    VALUES
                                        (
                                            " + dr["tipo_anomalia_id"].ToString() + @",
                                            '" + txt + @"'
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarTipoDispositivos(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                tipo_id,
	                nombre
                FROM 
	                tipo_dispositivo
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    TipoDispositivo
                                        (
                                            tipo_id, 
                                            nombre
                                        ) 
                                    VALUES
                                        (
                                            " + dr["tipo_id"].ToString() + @",
                                            '" + txt + @"'
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarModeloDispositivo(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                modelo_id,
	                nombre
                FROM 
	                Modelo_dispositivo
                WHERE 
	                empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                                INSERT INTO 
                                    ModeloDispositivo
                                        (
                                            modelo_id, 
                                            nombre
                                        ) 
                                    VALUES
                                        (
                                            " + dr["modelo_id"].ToString() + @",
                                            '" + txt + @"'
                                        )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }




        private static void CargarDispositivos(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                d.dispositivo_id,
	                d.nombre,
	                e.nombre AS empresa,	
	                i.instalacion_id,
	                d.tipo_id,
	                d.funcion,
	                d.estado,
	                IFNULL(d.fecha_caducidad, '0001-01-01') AS fecha_caducidad,
	                d.caducado,
	                IFNULL(d.fecha_baja,'0001-01-01') AS fecha_baja,
	                IFNULL(d.modelo_id, 0) AS modelo_id,
	                d.operativo,
	                IFNULL(d.posicion,'') AS posicion,
	                IFNULL(d.cod_barras, '') AS cod_barras
                FROM 
	                dispositivo d
	                INNER JOIN instalacion i
		                ON i.instalacion_id = d.instalacion_id
	                INNER JOIN empresa e
		                ON e.empresa_id = i.empresa_id
                WHERE 
                    e.empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";


            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["nombre"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                       
                        sql = @"
                            INSERT INTO 
                                Dispositivo
                                    (
                                        dispositivo_id, 
                                        nombre, 
                                        empresa, 
                                        instalacion, 
                                        tipo, 
                                        funcion, 
                                        estado,
                                        fecha_caducidad, 
                                        caducado, 
                                        fecha_baja, 
                                        codbarras, 
                                        operativo, 
                                        modelo, 
                                        posicion
                                    )
                                VALUES
                                    (
                                        " + dr["dispositivo_id"].ToString() + @",
                                        '" + txt + @"',
                                        '" + dr["empresa"].ToString() + @"',
                                        " + dr["instalacion_id"].ToString() + @",
                                        " + dr["tipo_id"].ToString() + @",
                                        '" + dr["funcion"].ToString() + @"',
                                        '" + dr["estado"].ToString() + @"',
                                        " + ParseFecha(dr, "fecha_caducidad") + @",
                                        " + (((bool)dr["caducado"])?"1":"0") + @",
                                        " + ParseFecha(dr, "fecha_baja") + @",
                                        '" + dr["cod_barras"].ToString() + @"',
                                        " + dr["operativo"].ToString() + @",
                                        " + dr["modelo_id"].ToString() + @",
                                        '" + dr["posicion"].ToString().Replace("'","''") + @"'
                                    )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }

                }
            }
        }

        private static void CargarIncidencias(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {

            string sql = @"
                SELECT
	                i.incidencia_id,
	                IFNULL(i.fecha_apertura,'0001-01-01') AS fecha_apertura,
	                i.operativo,
	                i.dispositivo_id,
	                i.usuario_id,
	                IFNULL(i.comentarios, '') AS comentarios,
	                IFNULL(i.fecha_cierre,'0001-01-01') AS fecha_cierre,
	                IFNULL(i.fecha_prevista, '0001-01-01') AS fecha_prevista
                FROM 
	                incidencia i
	                INNER JOIN dispositivo d
		                ON d.dispositivo_id = i.dispositivo_id
	                INNER JOIN instalacion ii
		                ON ii.instalacion_id = d.instalacion_id
                WHERE 
                    i.fecha_cierre IS NULL 
                    AND
	                ii.empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";


            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["incidencia_id"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                            INSERT INTO 
                                Incidencia
                                    (
                                        incidencia_id, 
                                        fecha_apertura, 
                                        operativo, 
                                        disp_id, 
                                        usuario_id, 
                                        comentarios, 
                                        fecha_cierre, 
                                        fecha_prevista
                                    )
                                VALUES
                                    (
                                        " + txt + @",
                                        " + ParseFecha(dr, "fecha_apertura") + @",
                                        " + dr["operativo"].ToString() + @",
                                        " + dr["dispositivo_id"].ToString() + @",
                                        " + dr["usuario_id"].ToString() + @",
                                        '" + dr["comentarios"].ToString().Replace("'","''") + @"',
                                        " + ParseFecha(dr, "fecha_cierre") + @",
                                        " + ParseFecha(dr, "fecha_prevista") + @"
                                    )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }
                }
            }
        }

        private static void CargarIncidenciaEvolucion(Empresa empresa, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT
	                e.incidencia_evolucion_id,
	                e.incidencia_id,
	                IFNULL(e.fecha_evolucion, '0001-01-01') AS fecha_evolucion,
	                IFNULL(e.comentarios, '') AS comentarios,
	                IFNULL(e.usuario_id,0) AS usuario_id,
	                e.operativo
                FROM 
	                incidencia_evolucion e
	                INNER JOIN incidencia i
		                ON i.incidencia_id = e.incidencia_id
	                INNER JOIN dispositivo d
		                ON d.dispositivo_id = i.dispositivo_id
	                INNER JOIN instalacion ii
		                ON ii.instalacion_id = d.instalacion_id
                WHERE 
	                ii.empresa_id = " + empresa.EmpresaId.ToString() + @"
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";

            string comentarios = "";

            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["incidencia_evolucion_id"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        comentarios = dr["comentarios"].ToString();
                        if(comentarios.Length > 99) {
                            comentarios = comentarios.Substring(0, 99);
                        }

                        sql = @"
                            INSERT INTO 
                                IncidenciaEvolucion
                                    (
                                        incidencia_evolucion_id, 
                                        incidencia_id, 
                                        fecha_evolucion, 
                                        comentarios, 
                                        usuario_id, 
                                        operativo
                                    ) 
                                VALUES
                                    (
                                        " + txt + @",
                                        " + dr["incidencia_id"].ToString() + @",
                                        " + ParseFecha(dr, "fecha_evolucion") + @",
                                        '" + comentarios + @"',
                                        " + dr["usuario_id"].ToString() + @",
                                        " + dr["operativo"].ToString() + @"
                                    )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }
                }
            }
        }

        private static void CargarProgramas(Empresa empresa, string  programas, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            
            string sql = @"
                SELECT 
	                programa_id,
	                IFNULL(fecha_programada, '0001-01-01') AS fecha_programada,
	                IFNULL(usuario_id, 0) AS usuario_id,
	                IFNULL(estado,'') AS estado,
	                IFNULL(comentarios,'') AS comentarios
                FROM 
	                programa
                WHERE 
	                programa_id IN (" + programas + @")
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            string comentarios = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["programa_id"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        comentarios = dr["comentarios"].ToString();
                        if(comentarios.Length>99){
                            comentarios = comentarios.Substring(0, 99);
                        }
                        sql = @"
                            INSERT INTO 
                                Programa
                                    (
                                        programa_id, 
                                        usuario_id, 
                                        estado, 
                                        comentarios, 
                                        fecha_programada
                                    )
                                VALUES
                                    (
                                        " + txt + @",
                                        " + dr["usuario_id"].ToString() + @",
                                        '" + dr["estado"].ToString() + @"',
                                        '" + comentarios + @"',
                                        " + ParseFecha(dr, "fecha_programada") +@"
                                    )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }
                }
            }
        }

        private static void CargarRevision(Empresa empresa, string programas, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT 
	                r.revision_id,
	                IFNULL(r.dispositivo_id,0) AS dispositivo_id,
	                IFNULL(r.usuario_id,0) AS usuario_id,
	                IFNULL(r.fecha_planificada, '0001-01-01') AS fecha_planificada,
	                IFNULL(r.fecha_programada, '0001-01-01') AS fecha_programada,
	                IFNULL(r.fecha_revision, '0001-01-01') AS fecha_revision,
	                IFNULL(r.resultado,'') AS resultado,
	                IFNULL(r.observaciones,'') AS observaciones,
	                IFNULL(r.programa_id,0) AS programa_id,
	                IFNULL(r.estado,'') AS estado,
	                IFNULL(p.descripcion,'') AS plantilla,
	                IFNULL(r.tipo_anomalia_id,0) AS tipo_anomalia_id
                FROM 
	                revision r 
	                INNER JOIN dispositivo d
		                    ON r.dispositivo_id = d.dispositivo_id
	                INNER JOIN instalacion i
		                    ON d.instalacion_id = i.instalacion_id
	                INNER JOIN plantilla_revision p
		                    ON p.plantilla_id = r.plantilla_id
                WHERE 
                    i.empresa_id = " + empresa.EmpresaId.ToString() + @"
	                AND 
                        (	
		                    (
			                    r.programa_id IS NULL 
			                    AND r.Estado <> 'REALIZADA'
		                    ) OR (
			                    r.programa_id IN (" + programas + @")
		                    )
	                    )
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["revision_id"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                            INSERT INTO 
                                Revision
                                    (
                                        revision_id, 
                                        dispositivo_id, 
                                        usuario_id,
                                        fecha_planificada, 
                                        fecha_programada, 
                                        fecha_revision,
                                        resultado, 
                                        comentarios, 
                                        programa_id, 
                                        estado, 
                                        plantilla, 
                                        tipo_anomalia_id
                                    ) 
                            VALUES
                                (
                                    " + txt + @",
                                    " + dr["dispositivo_id"].ToString() + @",
                                    " + dr["usuario_id"].ToString() + @",
                                    " + ParseFecha(dr, "fecha_planificada") + @",
                                    " + ParseFecha(dr, "fecha_programada") + @",
                                    " + ParseFecha(dr, "fecha_revision") + @",
                                    '" + dr["resultado"].ToString() + @"',
                                    '" + dr["observaciones"].ToString() + @"',
                                    " + dr["programa_id"].ToString() + @",
                                    '" + dr["estado"].ToString() + @"',
                                    '" + dr["plantilla"].ToString() + @"',
                                    " + dr["tipo_anomalia_id"].ToString() + @"
                                )
                            ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }
                }
            }
        }

        private static void CargarDatoRevision(Empresa empresa, string programas, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
              string sql = @"
                SELECT 
	                dr.datos_id,
	                dr.revision_id,
	                IFNULL(tc.descripcion,'') AS descripcion,
	                c.posicion,
	                IFNULL(c.nombre,'') AS nombre,
	                IFNULL(dr.valor,'') AS valor
	
                FROM 
	                datos_revision dr
	                INNER JOIN campo c
		                ON c.campo_id = dr.campo_id
	                INNER JOIN tipo_campo tc
		                ON tc.tipo_id = c.tipo_id
	
	                INNER JOIN revision r 
		                ON r.revision_id = dr.revision_id
	                INNER JOIN dispositivo d
		                    ON r.dispositivo_id = d.dispositivo_id
	                INNER JOIN instalacion i
		                    ON d.instalacion_id = i.instalacion_id

                WHERE 
                    i.empresa_id = " + empresa.EmpresaId.ToString() + @"
	                AND 
                        (	
		                    (
			                    r.programa_id IS NULL 
			                    AND r.Estado <> 'REALIZADA'
		                    ) OR (
			                    r.programa_id IN (" + programas + @")
		                    )
	                    )
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["datos_id"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                            INSERT INTO 
                                 DatosRevision
                                    (
                                        datos_id, 
                                        revision_id, 
                                        tipo, 
                                        posicion, 
                                        nombre, 
                                        valor
                                    ) 
                            VALUES
                                (
                                    " + txt + @",
                                    " + dr["revision_id"].ToString() + @",
                                    '" + dr["descripcion"].ToString().Replace("'", "''") +@"',
                                    " + dr["posicion"].ToString() + @",
                                    '" + dr["nombre"].ToString() + @"',
                                    '" + dr["valor"].ToString().Replace("'", "''") + @"'
                                )
                            ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }
                }
            }
        }

        private static void CargarSustitucion(Empresa empresa, string programas, SqlCeConnection connCE, MySqlConnection connMy, RadProgressContext context) {
            string sql = @"
                SELECT
	                sustitucion_id,
	                IFNULL(fecha, '0001-01-01') AS fecha,
	                IFNULL(comentarios, '') AS comentarios,
	                IFNULL(estado, '') AS estado,
	                IFNULL(usuario_id, 0) AS usuario_id,
	                IFNULL(dispositivo_dispositivo_id, 0) AS dispositivo_dispositivo_id,
	                IFNULL(dispositivo1_dispositivo_id, 0) AS dispositivo1_dispositivo_id,
	                IFNULL(revision_id, 0) AS revision_id,
	                programa_id
                FROM 
	                sustitucion
                WHERE 
	                programa_id IN (" + programas + @")
                ";
            string texto = context.CurrentOperationText.ToString();
            int numReg = 0;
            string txt = "";
            using(MySqlCommand cmdSrc = connMy.CreateCommand()) {
                cmdSrc.CommandText = sql;
                using(MySqlDataReader dr = cmdSrc.ExecuteReader()) {
                    while(dr.Read()) {
                        txt = dr["sustitucion_id"].ToString();
                        context.CurrentOperationText = String.Format("{0}{1} [{2} de ?]", texto, txt, numReg);
                        sql = @"
                            INSERT INTO 
                                Sustituciones
                                    (
                                        sustitucion_id, 
                                        fecha, 
                                        comentarios, 
                                        estado,
                                        usuario_id, 
                                        dispo_id, 
                                        disps_id, 
                                        revision_id, 
                                        programa_id
                                    ) 
                                VALUES
                                    (
                                        " + txt + @",
                                        " + ParseFecha(dr, "fecha") + @",
                                        '" + dr["comentarios"].ToString() + @"',
                                        '" + dr["estado"].ToString() + @"',
                                        " + dr["usuario_id"].ToString() + @",
                                        " + dr["dispositivo_dispositivo_id"].ToString() + @",
                                        " + dr["dispositivo1_dispositivo_id"].ToString() + @",
                                        " + dr["revision_id"].ToString() + @",
                                        " + dr["programa_id"].ToString() + @"
                                    )
                                ";
                        using(SqlCeCommand cmdDst = connCE.CreateCommand()) {
                            cmdDst.CommandText = sql;
                            cmdDst.ExecuteNonQuery();
                        }
                        numReg++;
                    }
                }
            }
        }




        protected static  string ParseFecha(MySqlDataReader dr, string campo) {
            string rtn = "NULL";
            try {
                DateTime dt = DateTime.Parse(dr[campo].ToString());
                if(dt.Year == 1) {
                    rtn = "NULL";
                } else {
                    rtn = String.Format("'{0:yyyy/MM/dd}'", dt);
                }
            } catch(Exception) {
                rtn = "NULL";
            }
            return rtn;
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