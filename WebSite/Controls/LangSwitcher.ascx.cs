using System;
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

namespace Apple.Web.Controls
{
    public partial class LangSwitcher : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rLangs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Language lang = (Language)e.Item.DataItem;
                HyperLink hl = (HyperLink)e.Item.FindControl("hlLang");
				//HtmlControl iLang = (HtmlControl)e.Item.FindControl("iLang");

                //hl.Text = lang.Code;
                string p = string.Empty;
                int index = 0;

                string path = Request.Path;

                if (!string.IsNullOrEmpty(Globals.OriginalPath))
                {
                    path = Globals.OriginalPath.ToLower();
                    index = 3;
                }

            	string page = path.Substring(Request.ApplicationPath.Length); 
				// 3 is slash(/) + langcode.Length (3) = "/ru"
				page = page.StartsWith("/") ? page.Substring(1) : page;
				if (page.IndexOf(Globals.CurrentLanguage) > -1)
					page = page.Substring(Globals.CurrentLanguage.Length);
            	page = page.StartsWith("/") ? page.Substring(1) : page;
            	//page = page.Replace("default.aspx", "");
            	string applicationPath = Request.ApplicationPath == "/" ? "" : Request.ApplicationPath;
				
#warning Заглушка для украинского языка
				if(lang.Code.ToLower() == "ua")
				{
					hl.Attributes["href"] = "#";
				}
				else
				{
                    hl.NavigateUrl = string.Format("{0}/{1}/{2}", applicationPath, lang.Code, page);
				}

            	hl.Attributes["class"] = "lang" + lang.Code;
            	if(Globals.CurrentLanguage == lang.Code)
            	{
					hl.Attributes["class"] += " active" + lang.Code;
            	}
				
				
            }
        }
    }
}