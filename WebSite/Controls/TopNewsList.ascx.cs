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
    public partial class TopNewsList : UserControlBase
    {
        private int pageID = 1;

        public int PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }

        private int newsCount = 5;

        public int NewsCount
        {
            get { return newsCount; }
            set { newsCount = value; }
        }

        private bool skipMain;

        public bool SkipMain
        {
            get { return skipMain; }
            set { skipMain = value; }
        }
	
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsItems_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["langCode"] = this.CurrentLanguage;
            e.InputParameters["pageID"] = this.PageID;
            e.InputParameters["count"] = this.NewsCount;
            e.InputParameters["skipMain"] = this.SkipMain;
        }

        protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                NewsItem news = (NewsItem)e.Item.DataItem;
                
                HyperLink link = (HyperLink)e.Item.FindControl("hlMore");
                HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");
                Label lblTitle = (Label)e.Item.FindControl("lblTitle");
                PlaceHolder ph = (PlaceHolder)e.Item.FindControl("phMore");

                string text = news.LinkUrl;

                if(text.Length > 0)
                {
                    ph.Visible = true;
                    hlTitle.Visible = true;
                    lblTitle.Visible = false;
                }
            }
        }
    }
}