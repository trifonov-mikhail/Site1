using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Adapters
{
    public class HtmlFormControlAdapter : ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(new RewriteFormHtmlTextWriter(writer));
        }
    }

    public class RewriteFormHtmlTextWriter : HtmlTextWriter
    {
        public RewriteFormHtmlTextWriter(HtmlTextWriter writer)
            : base(writer)
        {
            this.InnerWriter = writer.InnerWriter;
        }
        public RewriteFormHtmlTextWriter(System.IO.TextWriter writer)
            : base(writer)
        {
            this.InnerWriter = writer;
        }
        public override void WriteAttribute(string name, string value, bool fEncode)
        {
            if (name == "action")
            {
                string path = Globals.OriginalPath;
                if (!string.IsNullOrEmpty(path))
                {
                    value = path;
                }
            }

            base.WriteAttribute(name, value, fEncode);
        }
    } 
}
