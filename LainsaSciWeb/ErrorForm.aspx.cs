using System;
using LainsaSciModelo;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class ErrorForm : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
        // control de skin
        if (Session["Skin"] != null) RadSkinManager1.Skin = Session["Skin"].ToString();

    }
    protected void LoadData()
    {
        try
        {
            if (Session["ErrorControl"] != null)
            {
                ErrorControl errorControl = (ErrorControl)Session["ErrorControl"];
                txtFechaHora.Text = String.Format("{0:dd/MM/yyyy hh:mm:sss}", errorControl.ErrorDateTime);
                if(errorControl.ErrorProcess != null)
                    txtProceso.Text = errorControl.ErrorProcess.Descripcion;
                txtUsuario.Text = errorControl.ErrorUsuario.Nombre;
                txtError.Text = errorControl.ErrorException.Message;
                RadAjaxManager1.ResponseScripts.Add("resizeWindow();");
            }
            else
            {
                txtError.Text = "NO ERROR TO CONTROL";
            }
        }catch{ txtError.Text = "NO ERROR TO CONTROL";}
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        RadAjaxManager1.ResponseScripts.Add("closeWindow();");
    }
}
