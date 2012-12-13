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
    public class ContentSectionsCBL:CheckBoxListBase
    {
        public ContentSectionsCBL()
        {
            this.RepeatColumns = 2;
            this.RepeatDirection = RepeatDirection.Vertical;
        }
        protected override void FillValues()
        {
            ContentSections dao = new ContentSections();
            foreach (ContentSection s in dao.GetAll())
            {
                ListItem i = new ListItem(s.Name, s.ID.ToString());
                Items.Add(i);
            }
        }
    }
}
