using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LainsaSciWinWeb
{
    public partial class CampoTetra : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        public void SetNombre(string nombre)
        {
            lblNombre.Text = nombre;
        }
        public string GetValor()
        {
            return String.Format("{0}|{1}",
                rdbLista.SelectedValue,
                txtComentario.Text);
        }
        public void SetValor(string valor)
        {
            if (valor == null) return;
            // Tiene dos campos
            int pos1 = valor.IndexOf("|");
            if (pos1 < 0) return;
            string c1 = valor.Substring(0, pos1);;
            string c2 = valor.Substring(pos1 + 1, valor.Length - (pos1+1));
            rdbLista.SelectedValue = c1;
            txtComentario.Text = c2;
        }
    }
}