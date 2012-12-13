using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple.Web.Controls
{
    public partial class ReadTemplateControl : UserControlBase
    {
        public string FileName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            lText.Text = File.ReadAllText(Server.MapPath(string.Format("~/Templates/{1}.{0}.htm", Globals.CurrentLanguage, FileName)), System.Text.Encoding.GetEncoding(1251));
            lText.Text = lText.Text.Replace("~/", this.ResolveUrl("~/")).Replace("{lang}", Globals.CurrentLanguage);
        }
    }
}