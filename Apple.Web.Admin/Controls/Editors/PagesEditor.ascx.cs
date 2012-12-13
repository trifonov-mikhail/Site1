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

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class PagesEditor : EditorBase
    {
        protected override GridView ItemsList
        {
            get { return GridViewItemsList; }
        }

        protected override DetailsView ItemDetails
        {
            get { return DetailsViewEditItem; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}