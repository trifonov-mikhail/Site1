using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web
{
    public class MasterBase:MasterPage
    {
        public string GetUrl(string url)
        {
            return this.ResolveUrl(url.Replace("{lang}", Globals.CurrentLanguage));
        }
        public string TranslatableText(string id)
        {
            return Globals.TranslatableText(id);
        }
    }
}
