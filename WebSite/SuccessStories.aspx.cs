using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Apple.Web
{
    public partial class SuccessStories : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SideBarItemsNames.AddRange(new string[] { "SuccessStories", "news", "about", "feedback" });
        }
    }
}
