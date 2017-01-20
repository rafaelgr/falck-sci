using System;
using System.Web.UI;
using System.Linq;
using System.Collections.Generic;

using LainsaSciModelo;
using LainsaSciWinWeb;
using LainsaSciInformes;
using Telerik.Web.UI;
using System.Configuration;
using Telerik.Reporting.Processing;
using System.IO;

public partial class ProgramacionExe : System.Web.UI.Page
{
    #region Definición de variables
    LainsaSci ctx = null; // conector con la base de datos
    Usuario usuario = null; // controla el usuario del login
    ProgramacionInforme prgInf = null;
    Dispositivo dispositivo = null;

    #endregion

    #region Carga y descarga de la página
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new LainsaSci("LainsaSciCTX"); // el conector figura en el config
        UsuarioCorrecto(); // control de usuario logado
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadProgressArea1.Localization.UploadedFiles = "Registros procesado: ";
            RadProgressArea1.Localization.CurrentFileName = "Registro: ";
            RadProgressArea1.Localization.TotalFiles = "Total registros:";
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        ctx.Dispose(); // evitamos dejar conexiones abiertas.
    }
    #endregion

#region Manejo combo box

#endregion

#region Botones generales
    protected void btnLanzador_Click(object sender, EventArgs e)
    {
        int pT = 0; // primary total
        int pV = 0; // primary value
        int pP = 0; // primary percent

        int sT = 0; // secondary total
        int sV = 0; // secondary value
        int sP = 0; // secondary percent
        // this happens for every company
        RadProgressContext context = RadProgressContext.Current;
        sT = ctx.Empresas.Count();
        context.SecondaryTotal = pT;
        context.CurrentOperationText = "Generando los informes y documentos...";
        string repodir = ConfigurationManager.AppSettings["Repositorio"];

        IList<NombreInforme> nombres = CntInforme.GetNombresDeInforme();
        pT = nombres.Count;
        foreach (Empresa empresa in ctx.Empresas)
        {
            sV++;
            sP = (int)(decimal)((sV / sT) * 100.0);
            context.SecondaryValue = sV;
            context.SecondaryPercent = sP;
            // por cada instalacion hay que sacar el informe
            foreach (Instalacion instalacion in empresa.Instalaciones)
            {
                pV = 0;
                foreach (NombreInforme ninf in nombres)
                {
                    pV++;
                    pP = (int)(decimal)((pV / pT) * 100.0);
                    context.PrimaryValue = pV;
                    context.PrimaryPercent = pP;

                    CntInforme.ElaborarInformesProgramados((DateTime)rdtFecha.SelectedDate, ninf.Informe, instalacion, repodir, ctx);
                }
            }
        }

        //Documentos de las Revisiones y Dispositivos por filtro

        foreach(UsuarioEmpresa ue in usuario.UsuarioEmpresas) {

            foreach(Filtro filtro in usuario.Filtros) {
                if(filtro.Tipo == "Revision" || filtro.Tipo == "Dispositivo") {
                    AplicarFiltro(filtro, filtro.Tipo);
                    CrearInforme(filtro, repodir,ue.Empresa, ue.Instalacion);
                }
            }
        }

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
    protected void RefreshGrid(bool rebind)
    {
       RadGrid1.DataSource = usuario.Filtros;
       ConsRev.DataSource = CntLainsaSci.GetRevisiones(usuario, ctx);
       ConsRev.DataSource = CntLainsaSci.GetDispositivos(usuario, ctx);
    }
    protected void CrearInforme(Filtro f, string repositorio, Empresa e, Instalacion i)
    {
       string consulta = string.Empty;
       
        

       Documento documento = new Documento();
       documento.Nombre = f.Nombre;
       documento.Empresa = e;
       documento.Instalacion = i;
       documento.Fecha = DateTime.Now;
       documento.Comentarios = "Informe generado automáticamente";
       documento.Extension = "PDF";
       ctx.Add(documento);
       ctx.SaveChanges();

       string directorio = repositorio;
       string nombreFichero = String.Format("{0:000000000}", documento.DocumentoId) + ".PDF";
       string fichero = String.Format("{0}\\{1}", directorio, nombreFichero);

       ReportProcessor reportProcessor = new ReportProcessor();
       RenderingResult renderingResult = null;
      
        switch (f.Tipo)
        {
           case "Dsipositivo":
               List<string> dispositivos = new List<string>();
               //ConsDisp.AllowPaging = false;// disabling paging
               //ConsDisp.Rebind();
               foreach (GridDataItem item in ConsDisp.MasterTableView.Items)
               {
                   dispositivos.Add(item["DispositivoId"].Text);
               }
               Session["Filtro"] = dispositivos;
               //ConsDisp.AllowPaging = true;// disabling paging
               //ConsDisp.Rebind();
               consulta =  "Consulta dispositivos. " + f.Nombre;
               RptConsultaDispositivos cd = new RptConsultaDispositivos(dispositivos, consulta);
               renderingResult = reportProcessor.RenderReport("PDF", cd, null);
               break;
           case "Revision": 
               List<string> revisiones = new List<string>();
               //ConsRev.AllowPaging = false;// disabling paging
               //ConsRev.Rebind();
               foreach (GridDataItem item in ConsRev.MasterTableView.Items)
               {
                   revisiones.Add(item["RevisionId"].Text);
               }
               Session["Filtro"] = revisiones;
               //ConsRev.AllowPaging = true;// disabling paging
               //ConsDisp.Rebind();
               consulta =  "Consulta revisiones. " + f.Nombre;
               IList<Revision> lr = new List<Revision>();
                foreach (string rid in revisiones)
                {
                    lr.Add(CntLainsaSci.GetRevision(int.Parse(rid), ctx));
                }
               RptInfConsultaRevision icr = new RptInfConsultaRevision(lr, consulta);
               renderingResult = reportProcessor.RenderReport("PDF", icr, null);
               break;
       }
        
        FileStream fs = new FileStream(fichero, FileMode.Create);
        fs.Write(renderingResult.DocumentBytes, 0, renderingResult.DocumentBytes.Length);
        fs.Close();
    }
    protected void AplicarFiltro(Filtro f, string tipo)
    {
        if (tipo == "Revision")
        {
            RadFilter1.RootGroup.Expressions.Clear();
            RadFilter1.RecreateControl();
            RadFilter1.LoadSettings(f.Expresion);
            RadFilter1.FireApplyCommand();
        }
        else
        {
            RadFilter2.RootGroup.Expressions.Clear();
            RadFilter2.RecreateControl();
            RadFilter2.LoadSettings(f.Expresion);
            RadFilter2.FireApplyCommand();
        }
   }
#endregion

#region Llamado desde JavaScript
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshGrid(true);
        RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
    }
    protected void RadGrid1_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = usuario.Filtros;
    }
    protected void ConsRev_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        foreach (Filtro f in usuario.Filtros)
        {
            if (f.Tipo == "Revision")
            {
                ConsRev.DataSource = CntLainsaSci.GetRevisiones(usuario, ctx);
                break;
            }
        }
    }

    protected void ConsDisp_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        foreach (Filtro f in usuario.Filtros)
        {
            if (f.Tipo == "Dispositivo")
            {
                ConsDisp.DataSource = CntLainsaSci.GetDispositivos(usuario, ctx);
                break;
            }
        }
    }
    protected void ConsRev_ItemDataBound(object sender, GridItemEventArgs e)
    {

        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaRevision"].Text)))
            {
                item["FechaRevision"].Text = "";
            }
            if (CntLainsaSci.FechaNula(DateTime.Parse(item["FechaProgramada"].Text)))
            {
                item["FechaProgramada"].Text = "";
            }
        }
    }

#endregion

   
    

 

   

 


  
   




}