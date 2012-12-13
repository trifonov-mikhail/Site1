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

namespace Apple.Web.Controls
{
    public partial class Map : UserControlBase
    {
        private string ddlRegionsID;

        public string DdlRegionsID
        {
            get { return ddlRegionsID; }
            set { ddlRegionsID = value; }
        }

        private string btnShowID;

        public string BtnShowID
        {
            get { return btnShowID; }
            set { btnShowID = value; }
        }
	
        protected void Page_Load(object sender, EventArgs e)
        {
            iMap.Attributes["usemap"] = "#map1";
            RegJS("~/js/jquery.selectboxes.min.js");
            RegJS("~/js/jquery.preloadImages.js");
        }
    }
}