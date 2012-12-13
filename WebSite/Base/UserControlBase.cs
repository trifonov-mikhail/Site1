using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Controls
{
    public class UserControlBase:UserControl
    {
        public string CurrentLanguage
        {
            get 
            {
                return Globals.CurrentLanguage;
            }
        }
        public string TranslatableText(string id)
        {
            return Globals.TranslatableText(id);
        }
        public void RegCss(string url)
        {
            (Page as PageBase).RegCss(url);
        }
        public void RegJS(string url)
        {
            (Page as PageBase).RegJS(url);
        }

		public string GetUrl(string url)
		{
			return this.ResolveUrl(url.Replace("{lang}", this.CurrentLanguage));
		}
    }
}
