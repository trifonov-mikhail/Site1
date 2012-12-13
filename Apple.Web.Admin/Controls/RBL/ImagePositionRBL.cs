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
    public class ImagePositionRBL:RadioButtonListBase
    {
        public ImagePositionRBL()
        {
            this.RepeatDirection = RepeatDirection.Horizontal;
            this.RepeatColumns = 2;
        }
        protected override void FillValues()
        {
            ListItem i = null;
            
            i = new ListItem("Left", "0");
            i.Selected = true;
            Items.Add(i);

            i = new ListItem("Right", "1");
            Items.Add(i);
        }
    }
}
