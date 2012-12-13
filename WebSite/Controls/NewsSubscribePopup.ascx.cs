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

namespace Apple.Web.Controls
{
    public partial class NewsSubscribePopup : System.Web.UI.UserControl
    {
        public string ServiceMethod
        {
            get
            {
                return string.Format("{0}/AddNewsSubscriber", Page.ResolveClientUrl("~/WS/SysService.asmx"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}