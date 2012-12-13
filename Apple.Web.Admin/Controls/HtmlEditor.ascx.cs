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
    public partial class HtmlEditor : UserControlBase
    {
        public string Text
        {
            get { return Value.Text; }
            set { Value.Text = value; }
        }

        public Unit Width
        {
            get { return Value.Width; }
            set { Value.Width = value; }
        }
        public Unit Height
        {
            get { return Value.Height; }
            set { Value.Height = value; }
        }
        private void Page_Load(object sender, System.EventArgs e)
        {

        }
    }
}