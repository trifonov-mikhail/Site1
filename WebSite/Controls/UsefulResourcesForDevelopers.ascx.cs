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
    public partial class UsefulResourcesForDevelopers : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void odsItems_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["langCode"] = this.CurrentLanguage;
        }

        protected void rItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DevelopersLink link = (DevelopersLink)e.Item.DataItem;
                Label lDesrc = (Label)e.Item.FindControl("lDesrc");

                string text = link.Text.Trim();

                if (text.Length > 0)
                {
                    if (text[0] != '(')
                    {
                        lDesrc.Text = string.Format(" — {0}", text);
                    }
                    else
                    {
                        lDesrc.Text = text;
                    }
                }
            }
        }
    }
}