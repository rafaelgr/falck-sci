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

public partial class RevisionFormC : System.Web.UI.Page 
{
    LainsaSci ctx = null;
    Usuario usuario = null;
    Revision r = null;
    DatosRevision dr = null;
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
            if (usuario == null)
                Response.Redirect("Default.aspx");
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
        if (Request.QueryString["P"] != null)
        {
            pagina = int.Parse(Request.QueryString["P"]);
        }
        if (r == null)
            Response.Redirect("ProgramaList.aspx");
        numpag = r.DatosRevisions.Count + 1;
        IList<DatosRevision> ldr = r.DatosRevisions.OrderBy(x => x.Campo.Posicion).ToList<DatosRevision>();
        dr = ldr[pagina - 1];
        lblTitulo.Text = String.Format("{0}: {1} / {2} <br/> <b>D: </b>{3}", r.PlantillaRevision.Descripcion,
            pagina, numpag,
            r.Dispositivo.Nombre);
        // cargar controles segun los datos
        CargarControl(dr);
        if (pagina == 1)
        {
            btnAnterior.Text = "S";
        }
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
        string jCommand = String.Format("RevisionFormC.aspx?Id={0}&P={1}", r.RevisionId, 1);
        Response.Redirect(jCommand);
    }

    protected void DescargarControl(DatosRevision dr)
    {
        Control control = PlantillaHolder.Controls[0];
        string tipo = control.GetType().ToString();
        if (dr != null)
        {
            switch (tipo)
            {
                case "ASP.camposn_ascx":
                    CampoSN csn = (CampoSN)control;
                    dr.Valor = csn.GetValor();
                    break;
                case "ASP.campotext_ascx":
                    CampoText ctxt = (CampoText)control;
                    dr.Valor = ctxt.GetValor();
                    break;
                case "ASP.camponum_ascx":
                    CampoNum cnum = (CampoNum)control;
                    dr.Valor = cnum.GetValor();
                    break;
                case "ASP.campodate_ascx":
                    CampoDate cdt = (CampoDate)control;
                    dr.Valor = cdt.GetValor();
                    break;
                case "ASP.campotetra_ascx":
                    CampoTetra ctetra = (CampoTetra)control;
                    dr.Valor = ctetra.GetValor();
                    break;
            }
            dr.Revision = r;
        }
        // si descargamos grabamos
        ctx.SaveChanges();
    }

    protected void CargarControl(DatosRevision dr)
    {
        string tipo = dr.Campo.TipoCampo.Descripcion;
        switch (tipo)
        {
            case "Campo Si/No":
                CampoSN csn = (CampoSN)LoadControl("~/CampoSN.ascx");
                csn.ID = dr.DatosId.ToString();
                csn.SetNombre(dr.Campo.Nombre);
                csn.SetValor(dr.Valor);
                PlantillaHolder.Controls.Add(csn);
                break;
            case "Texto":
                CampoText ctxt = (CampoText)LoadControl("~/CampoText.ascx");
                ctxt.ID = dr.DatosId.ToString();
                ctxt.SetNombre(dr.Campo.Nombre);
                ctxt.SetValor(dr.Valor);
                PlantillaHolder.Controls.Add(ctxt);
                break;
            case "Tetra":
                CampoTetra ctt = (CampoTetra)LoadControl("~/CampoTetra.ascx");
                ctt.ID = dr.DatosId.ToString();
                ctt.SetNombre(dr.Campo.Nombre);
                ctt.SetValor(dr.Valor);
                PlantillaHolder.Controls.Add(ctt);
                break;
            case "Numerico":
                CampoNum cnum = (CampoNum)LoadControl("~/CampoNum.ascx");
                cnum.ID = dr.DatosId.ToString();
                cnum.SetNombre(dr.Campo.Nombre);
                cnum.SetValor(dr.Valor);
                PlantillaHolder.Controls.Add(cnum);
                break;
            case "Fecha":
                CampoDate cdt = (CampoDate)LoadControl("~/CampoDate.ascx");
                cdt.ID = dr.DatosId.ToString();
                cdt.SetNombre(dr.Campo.Nombre);
                cdt.SetValor(dr.Valor);
                PlantillaHolder.Controls.Add(cdt);
                break;
        }
    }

    protected void btnAnterior_Click(object sender, EventArgs e)
    {
        pagina = pagina - 1;
        if (pagina == 0)
        {
            Response.Redirect("ProgramaList.aspx");
        }
        string jCommand = String.Format("RevisionFormC.aspx?Id={0}&P={1}", r.RevisionId, pagina);
        Response.Redirect(jCommand);
        // guardar los datos
        DescargarControl(dr);
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        pagina = pagina + 1;
        string jCommand;
        if (pagina == numpag)
        {
            jCommand = String.Format("RevisionFormF.aspx?Id={0}", r.RevisionId);
        }
        else
            jCommand = String.Format("RevisionFormC.aspx?Id={0}&P={1}", r.RevisionId, pagina);
        // guarda los datos
        DescargarControl(dr);
        Response.Redirect(jCommand);
    }
    protected void btnF_Click(object sender, EventArgs e)
    {
        pagina = pagina + 1;
        string jCommand;
        jCommand = String.Format("RevisionFormF.aspx?Id={0}", r.RevisionId);
        // guardar los datos
        DescargarControl(dr);
        Response.Redirect(jCommand);
    }
    protected void GuardarDatos()
    {

    }
}