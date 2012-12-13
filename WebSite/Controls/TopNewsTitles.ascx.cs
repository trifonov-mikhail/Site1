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
    public partial class TopNewsTitles : UserControlBase
    {
        private int pageID = 1;

        public int PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }

        private int newsCount = 10;

        public int NewsCount
        {
            get { return newsCount; }
            set { newsCount = value; }
        }

        private bool openFirst = true;

        public bool OpenFirst
        {
            get { return openFirst; }
            set { openFirst = value; }
        }
	

        public string ServiceMethod
        {
            get
            {
                return string.Format("{0}/GetNews", Page.ResolveClientUrl("~/WS/SysService.asmx"));
            }
        }

        public string ImageUrl
        {
            get
            {
                return Page.ResolveClientUrl("~/GetImage.ashx?type=2&id=");
            }
        }

        private bool skipMain;

        public bool SkipMain
        {
            get { return skipMain; }
            set { skipMain = value; }
        }
	

        protected void Page_Init(object sender, EventArgs e)
        {
            if (NewsCount == 0)
            {
                odsItems.SelectMethod = "GetAll";
            }
            else
            {
                odsItems.SelectMethod = "GetTitlesByLangForPageTopN";
            }
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
            //if (e.Item.ItemIndex == 0)
            //{
            //    e.Item.Visible = false;
            //}
        }
    }
}