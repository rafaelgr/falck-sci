using System.Web.UI;
using LainsaSciModelo;
using Telerik.Web.UI;

namespace LainsaSciWinWeb
{
    public static class CntWinWeb
    {
        public static Usuario IsSomeoneLogged(Page page , LainsaSci ctx)
        {
            Usuario Usuario = null;
            if (page.Session["UsuarioId"] != null)
                Usuario = CntLainsaSci.GetUsuario(int.Parse(page.Session["UsuarioId"].ToString()), ctx);
            return Usuario;
            //return new Usuario(); // TODO: Take this off (provisional)
        }
        public static void VisibleOnPageLoadAllWindows(RadWindowManager rdwm, bool visible)
        {
            foreach (RadWindow rdw in rdwm.Windows)
            {
                rdw.VisibleOnPageLoad = visible;
                rdw.DestroyOnClose = true;
            }
            
        }
        public static void controlOpenedWindows(RadWindowManager rdwn, Page page)
        {
            foreach (RadWindow rdw in rdwn.Windows)
            {
                if (page.Session[rdw.ID] == null)
                {
                    rdw.VisibleOnPageLoad = false;
                }
            }
        }
        public static void TranslateRadGridFilters(RadGrid rdg)
        {
            GridFilterMenu rfm = rdg.FilterMenu;
            foreach (RadMenuItem item in rfm.Items)
            {
                switch (item.Text)
                {
                    case "NoFilter":
                        item.Text = Resources.FilterResource.NoFilter;
                        break;
                    case "EqualTo":
                        item.Text = Resources.FilterResource.EqualTo;
                        break;
                    case "NotEqualTo":
                        item.Text = Resources.FilterResource.NotEqualTo;
                        break;
                    case "GreaterThan":
                        item.Text = Resources.FilterResource.GreatherThan;
                        break;
                    case "LessThan":
                        item.Text = Resources.FilterResource.LessThan;
                        break;
                    case "GreaterThanOrEqualTo":
                        item.Text = Resources.FilterResource.GreatherThanOrEqualTo;
                        break;
                    case "LessThanOrEqualTo":
                        item.Text = Resources.FilterResource.LessThanOrEqualTo;
                        break;
                    case "Between":
                        item.Text = Resources.FilterResource.Between;
                        break;
                    case "NotBetween":
                        item.Text = Resources.FilterResource.NotBetween;
                        break;
                    case "IsNull":
                        item.Text = Resources.FilterResource.IsNull;
                        break;
                    case "NotIsNull":
                        item.Text = Resources.FilterResource.NotIsNull;
                        break;

                    case "Contains":
                        item.Text = Resources.FilterResource.Contains;
                        break;
                    case "DoesNotContain":
                        item.Text = Resources.FilterResource.DoesNotContain;
                        break;
                    case "StartsWith":
                        item.Text = Resources.FilterResource.StartsWith;
                        break;
                    case "EndsWith":
                        item.Text = Resources.FilterResource.EndsWith;
                        break;
                    case "IsEmpty":
                        item.Text = Resources.FilterResource.IsEmpty;
                        break;
                    case "NotIsEmpty":
                        item.Text = Resources.FilterResource.NotIsEmpty;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void OcultarPestanyas(RadTabStrip rdts) 
        {
            foreach (RadTab rd in rdts.Tabs)
            {
                rd.Visible = false;
            }
            rdts.Tabs[0].Visible = true;
        }

    }
}