using System;
using LainsaSciModelo;
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

public partial class ProgramaList : System.Web.UI.Page 
{
    LainsaSci ctx = null;
    Usuario usuario = null;
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
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarTabPanel(usuario, ctx);
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
        Response.Redirect("Default.aspx");
    }
    protected void CargarTabPanel(Usuario u, LainsaSci ctx)
    {
        RadPanelBar1.Items.Clear();
        if (u == null) return;
        // primerpo buscamos los programas que no están acabados.
        IList<Programa> lp = (from p in ctx.Programas
                              where p.Usuario.UsuarioId == u.UsuarioId
                              select p).ToList<Programa>();
        foreach (Programa p in lp)
        {
            LainsaSciModelo.Revision r = p.Revisions[0];
            RadPanelItem item = new RadPanelItem();
            item.ImageUrl = "imagenes/pawn_glass_blue.png";
            item.Text = String.Format("{0:dd/MM/yyyy} ({1}) [{2}] ",p.FechaProgramada,r.Dispositivo.Instalacion.Nombre,p.Comentarios);
            RadPanelBar1.Items.Add(item);
            CargarRevisiones(item, p, ctx);
        }
    }
    protected void CargarRevisiones(RadPanelItem item, Programa p, LainsaSci ctx)
    {
        item.Items.Clear();
        foreach (LainsaSciModelo.Revision r in p.Revisions)
        {
            RadPanelItem i2 = new RadPanelItem();
            i2.ImageUrl = "imagenes/pawn_glass_green.png";
            i2.Text = String.Format("<b>D:</b>{0} <b>P:</b>{1} <b>S:</b>{2}", r.Dispositivo.Nombre, r.PlantillaRevision.Descripcion, r.Estado);
            i2.NavigateUrl = String.Format("RevisionFormC.aspx?Id={0}&P=1", r.RevisionId);
            item.Items.Add(i2);
        }
    }
}
