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
    public partial class WhereToBuy : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SideBarItemsNames.AddRange(new string[] { "about", 
				"feedback", "SerialNumberCheck", "Important", "Shipping" });
        }

        
    }
}
