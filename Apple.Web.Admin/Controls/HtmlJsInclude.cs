using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Admin.Controls
{
    public class HtmlJsInclude : HtmlControl
    {
        private string src;

        public string Src
        {
            get { return src; }
            set { src = value; }
        }

        public HtmlJsInclude()
        {
        }
        public HtmlJsInclude(string src)
        {
            this.Src = src;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(String.Format("\n<script type=\"text/javascript\" src=\"{0}\"></script>", Src));
        }
    }
}