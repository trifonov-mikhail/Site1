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
    public partial class StoriesList : UserControlBase
    {
        private int sectionID = 1;

        public int SectionID
        {
            get { return sectionID; }
            set { sectionID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsItems_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["langCode"] = this.CurrentLanguage;
            e.InputParameters["sectionID"] = this.SectionID;
        }

        protected void dlItems_PreRender(object sender, EventArgs e)
        {
            dlItems.ShowHeader = dlItems.Items.Count > 0;
        }
    }
}