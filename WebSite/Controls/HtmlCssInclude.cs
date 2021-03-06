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
    public class HtmlCssInclude : HtmlLink
    {
        public HtmlCssInclude()
        {
        }
        public HtmlCssInclude(string href)
        {
            this.Attributes["type"] = "text/css";
            this.Attributes["rel"] = "stylesheet";
            this.Href = href;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write('\n');
            base.Render(writer);
        }
    }
}