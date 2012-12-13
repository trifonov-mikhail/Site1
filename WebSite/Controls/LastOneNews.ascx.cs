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
    public partial class LastOneNews : UserControlBase
    {
        private int pageID = 1;

        public int PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsItem_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["pageID"] = this.PageID;
            e.InputParameters["langCode"] = this.CurrentLanguage;
        }
    }
}