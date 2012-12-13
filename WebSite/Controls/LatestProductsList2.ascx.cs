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

using Erc.Apple.Data;

namespace Apple.Web.Controls
{
    public partial class LatestProductsList2 : UserControlBase
    {
        private int pageID;

        public int PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }

        private int sectionID;

        public int SectionID
        {
            get { return sectionID; }
            set { sectionID = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
	
	
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageID > 0)
            {
                odsItems.SelectMethod = "GetByLangForPage";
            }
            else
            {
                odsItems.SelectMethod = "GetByLangForSection";
            }
        }

        protected void odsItems_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["langCode"] = this.CurrentLanguage;

            if (PageID > 0)
            {
                e.InputParameters["pageID"] = this.PageID;
            }
            else
            {
                e.InputParameters["sectionID"] = this.SectionID;
            }
        }

        protected void rItems_PreRender(object sender, EventArgs e)
        {
            if (rItems.Items.Count == 0)
            {
                this.Visible = false;
            }
        }
    }
}