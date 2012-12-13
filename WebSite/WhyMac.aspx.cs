using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web
{
    public partial class WhyMac : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			lText.Text = File.ReadAllText(Server.MapPath(string.Format("~/Templates/WhyMac.{0}.htm", Globals.CurrentLanguage)), System.Text.Encoding.GetEncoding(1251));
        	lText.Text = lText.Text.Replace("~/", this.ResolveUrl("~/")).Replace("{lang}", Globals.CurrentLanguage);
        }
    }
}
