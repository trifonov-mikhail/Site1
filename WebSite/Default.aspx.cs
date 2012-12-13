using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;
using Erc.Apple.Data.Cache;

namespace Apple.Web
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SideBarItemsNames.AddRange(new string[] { "about", 
				"feedback", 
				"SerialNumberCheck", 
				"Important"});
            
        }
    }
}
