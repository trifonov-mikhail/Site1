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
    public partial class CaseStudiesList : UserControlBase
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

        protected void odsCaseStudies_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["langCode"] = this.CurrentLanguage;
            e.InputParameters["sectionID"] = this.SectionID;
        }

        protected void rCaseStudies_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CaseStudy cs = (CaseStudy)e.Item.DataItem;

                CsItem item = null;

                if (cs.ImagePosition == 0)
                {
                    item = (CsItem)LoadControl("~/Controls/CsItemImageLeft.ascx");
                }
                else
                {
                    item = (CsItem)LoadControl("~/Controls/CsItemImageRight.ascx");
                }

                item.Title = cs.Title;
                item.Notice = cs.Notice;
                item.Text = cs.Text;

                item.CsID = cs.GroupID;
                item.LinkUrl = cs.LinkUrl;
                item.LinkText = cs.LinkText;
                item.Link2Url = cs.Link2Url;
                item.Link2Text = cs.Link2Text;

                e.Item.Controls.Add(item);
            }
        }
    }
}