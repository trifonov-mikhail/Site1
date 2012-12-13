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

namespace Apple.Web.Admin.Controls
{
    public partial class AddItemButton : UserControlBase
    {
        public event EventHandler Click;

        private string text = "Создать";

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
	

        protected void Page_Load(object sender, EventArgs e)
        {
            lbAddNews.Text = Text;
        }

        protected void lbAddNews_Click(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click(this, new EventArgs());
            }
        }
    }
}