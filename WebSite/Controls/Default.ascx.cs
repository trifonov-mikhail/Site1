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
using Erc.Apple.Data.Cache;

namespace Apple.Web.Controls
{
	public partial class Default : UserControlBase
    {
		protected string url1 = string.Empty;
		protected string url2 = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            ShowAuctionBanner();
            News dao = new News();
            NewsItem item = dao.GetLastOneNewsForPage(3,CurrentLanguage);

            if (item != null && !string.IsNullOrEmpty(item.Title))
            {
                ltLastNews.Text = item.Title;
            }

			url1 = setHyperLink("HomePageBannerUrl");
			url2 = setHyperLink("HomePageBannerUrl2");
        }

        private void ShowAuctionBanner()
        {
            phStandart.Visible = true;
            phAuction.Visible = false;
            if (DateTime.Now > new DateTime(2013, 02, 07, 22, 0, 0) &&
                DateTime.Now < new DateTime(2013, 03, 14, 22, 0, 0))
            {
                phStandart.Visible = false;
                phAuction.Visible = true;
            }
        }

		private string setHyperLink( string key)
		{
			string url = DbConfigCache.GetItemValue(key);

            if (!string.IsNullOrEmpty(url))
            {
				return url;
            }
            else
            {
				return GetUrl("~/{lang}/Default.aspx");
            }
		}
    }
}