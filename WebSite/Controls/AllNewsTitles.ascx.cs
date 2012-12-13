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
    public partial class AllNewsTitles : UserControlBase
    {
        private bool skipFirst;

        public bool SkipFirst
        {
            get { return skipFirst; }
            set { skipFirst = value; }
        }
	

        public int PageSize
        {
            get { return gvItems.PageSize; }
            set { gvItems.PageSize = value; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void odsItems_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["language"] = this.CurrentLanguage;
        }

        protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0 && SkipFirst && gvItems.PageIndex == 0)
            {
                e.Row.Visible = false;
            }
        }
    }
}