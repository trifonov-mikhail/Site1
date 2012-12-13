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

namespace Apple.Web.Controls
{
    public partial class ProductList : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void odsCategories_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["language"] = this.CurrentLanguage;
        }
    }
}