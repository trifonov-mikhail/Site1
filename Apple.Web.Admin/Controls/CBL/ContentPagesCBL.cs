using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;

namespace Apple.Web.Admin.Controls
{
    public class ContentPagesCBL:CheckBoxListBase
    {
        public ContentPagesCBL()
        {
        }
        protected override void FillValues()
        {
            ContentPages dao = new ContentPages();
            foreach (ContentPage p in dao.GetAll())
            {
                ListItem i = new ListItem(p.Name, p.ID.ToString());
                Items.Add(i);
            }
        }
    }
}
