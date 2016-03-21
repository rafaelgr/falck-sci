using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;

public partial class Uploader2 : System.Web.UI.Page
{
    #region Variable definition
    // these variables go inside URL
    string returnUrl = "";
    string application = "";
    string userId = "";
    string formId = "";
    string fieldId = "";
    string message = "";
    string extension = "";
    // other parameters
    string repository = "";
    #endregion
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["Message"] != null)
        {
            message = Request.QueryString["Message"];
        }
        else 
        {
            message = "Seleccione el fichero con el botón \"Seleccionar\". Haga clic en \"Cargar fichero\" para proceder a la carga del  mismo";
        }
        lblAddtionalInformation.Text = message;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLoader_Click(object sender, EventArgs e)
    {
        // 
        //if (rdUploader.InvalidFiles.Count > 0)
        //{
        //    RadWindowManager1.RadAlert(String.Format("Debe escoger un fichero con la extensión {0}",extension), null, null, "Aviso", "doNothing");
        //    return;
        //}
        // when file have been loaded this event fires
        int nf = rdUploader.UploadedFiles.Count;
        if (nf == 0)
        {
            RadWindowManager1.RadAlert("Debe escoger un fichero", null, null, "Aviso", "doNothing");
            return;
        }
        UploadedFile f = rdUploader.UploadedFiles[0];
        string name = f.GetName();
    }
}
