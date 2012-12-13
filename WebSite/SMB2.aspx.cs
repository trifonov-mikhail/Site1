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

namespace Apple.Web
{
    public partial class SMB2 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            iMap.Attributes["usemap"] = "#map1";

            SideBarItemsNames.AddRange(new string[] { "news", "Interesting", "feedback" });
        }
    }
}
