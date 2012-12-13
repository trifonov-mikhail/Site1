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
    public partial class SideBarPanel : System.Web.UI.UserControl
    {
        private static readonly SideBarConfig dao = new SideBarConfig();

        public static SideBarConfig DAO
        {
            get { return dao; }
        }
	
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hl1 = e.Item.FindControl("hl1") as HyperLink;
                HyperLink hl2 = e.Item.FindControl("hl2") as HyperLink;

                SideBarItem item = (SideBarItem)e.Item.DataItem;

                string title = item.Titles[Globals.CurrentLanguage];
                string url = item.NavigateUrl;//.Insert(2,Globals.CurrentLanguage+"/");
            	url = url.Replace("{lang}", Globals.CurrentLanguage);

                if (hl1 != null)
                {
                    hl1.Text = title;
                    hl1.NavigateUrl = url;
                }

                if (hl2 != null)
                {
                    hl2.NavigateUrl = url;
                }

				Image icon_news = e.Item.FindControl("icon_news") as Image;
				if (icon_news != null)
				{
					icon_news.Attributes.Add("style", item.ImageStyle);
				}
            }
        }

        public void ShowItems(List<string> names)
        {
            rItems.DataSource = DAO.GetByNames(names);
            rItems.DataBind();
        }
    }
}