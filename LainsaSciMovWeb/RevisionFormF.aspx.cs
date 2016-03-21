using System;
using LainsaSciModelo;
using LainsaSciWinWeb;
using System.Linq;
using System.Collections.Generic;


using Telerik.OpenAccess;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class RevisionFormF : System.Web.UI.Page 
{
    LainsaSci ctx = null;
    Usuario usuario = null;
    Revision r = null;
    int pagina = 0;
    int numpag = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        // it gets an appropiate context (LainsaSciCTX -> web.config)
        ctx = new LainsaSci("LainsaSciCTX");
        // Comprobar que hay algún usuario
        if (Session["UsuarioId"] != null)
        {
            usuario = CntLainsaSci.GetUsuario(int.Parse(Session["UsuarioId"].ToString()), ctx);
            if (usuario == null) Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
        lblUsuario.Text = usuario.Nombre;
        if (Request.QueryString["Id"] != null)
        {
            r = CntLainsaSci.GetRevision(int.Parse(Request.QueryString["Id"]), ctx);
        }
        if (r == null) Response.Redirect("ProgramaList.aspx");
        numpag = r.DatosRevisions.Count + 1;
        pagina = numpag;
        lblTitulo.Text = String.Format("{0}: {1} / {2} <br/> <b>D: </b>{3}", r.PlantillaRevision.Descripcion, 
            pagina,numpag,
            r.Dispositivo.Nombre);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // it closes context in order to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        string jCommand = String.Format("RevisionFormC.aspx?Id={0}&P=1", r.RevisionId);
        Response.Redirect(jCommand);
    }


    protected void btnAnterior_Click(object sender, EventArgs e)
    {
        pagina = pagina - 1;
        if (pagina == 0) return;
        string jCommand = String.Format("RevisionFormC.aspx?Id={0}&P={1}", r.RevisionId, pagina);
        Response.Redirect(jCommand);
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        pagina = pagina + 1;
        if (pagina == numpag) return;
        string jCommand = String.Format("RevisionFormF.aspx?Id={0}&P={1}", r.RevisionId, pagina);
        Response.Redirect(jCommand);
    }

    protected void btnFin_Click(object sender, EventArgs e)
    {
        r.FechaRevision = (DateTime)rdpFechaRevision.SelectedDate;
        r.Resultado = txtResultado.Text;
        r.Observaciones = txtObservaciones.Text;
        r.Estado = "REALIZADA";
        ctx.SaveChanges();
        Response.Redirect("ProgramaList.aspx");
    }
    protected void CargarDatos() 
    {
        if (!CntLainsaSci.FechaNula(r.FechaRevision))
            rdpFechaRevision.SelectedDate = r.FechaRevision;
        txtStatus.Text = r.Estado;
        txtStatus.Enabled =false;
        txtResultado.Text = r.Resultado;
        txtObservaciones.Text = r.Observaciones;
    }

}
