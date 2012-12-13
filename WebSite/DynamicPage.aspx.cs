using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;

namespace Apple.Web
{
    public partial class DynamicPage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TemplatedPage p = Globals.CurrentTemplatedPage;
            if (p != null)
            {
                try
                {
                    bool replaceContacts = false;
                    bool replaceCompaniesList = false;
                    string template = p.ContentTemplate;

                    if (p.ContentTemplate.ToLower() == "aboutus.htm")
                    {
                        replaceContacts = true;
                        replaceCompaniesList = true;
                    }
                    
                    int index = template.LastIndexOf('.');
                    if (index != -1)
                    {
                        template = template.Insert(index,string.Format(".{0}",Globals.CurrentLanguage));
                    }

					string text = File.ReadAllText(Server.MapPath(string.Format("~/templates/{0}", template)), System.Text.Encoding.GetEncoding(1251));
                	ltContent.Text = text.Replace("~/", this.ResolveUrl("~/")).Replace("{lang}",Globals.CurrentLanguage);
                    if (replaceContacts)
                    {
                        string contacts = TranslatableText("Contacts");
                        ltContent.Text = ltContent.Text.Replace("<%Contacts%>",contacts);
                    }
                    if (replaceCompaniesList)
                    {
                        string companiesList = TranslatableText("CompaniesList");
                        ltContent.Text = ltContent.Text.Replace("<%CompaniesList%>", companiesList);
                    }
                }
                catch (Exception exc)
                {
                    ltContent.Text = string.Format("Error while loading temlate {0}:{1}",p.ContentTemplate,exc.Message);
                }
				//try
				//{
				//    string template = p.SecondMenu;
				//    if (!string.IsNullOrEmpty(template))
				//    {

				//        int index = template.LastIndexOf('.');
				//        if (index != -1)
				//        {
				//            template = template.Insert(index, string.Format(".{0}", Globals.CurrentLanguage));
				//        }

				//        ltSecondMenu.Text = File.ReadAllText(Server.MapPath(string.Format("~/templates/{0}", template)),
				//                                             System.Text.Encoding.GetEncoding(1251));
				//    }
				//}
				//catch (Exception exc)
				//{
				//    ltSecondMenu.Text = string.Format("Error while loading temlate {0}:{1}", p.ContentTemplate, exc.Message);
				//}
				
                this.Title = p.Titles[Globals.CurrentLanguage];

                SideBarItemsNames = p.SideBarItems;
            }
        }
    }
}
