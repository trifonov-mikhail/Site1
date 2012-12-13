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
    public partial class LogEditor : EditorBase
    {
        protected override GridView ItemsList
        {
            get { return GridViewItemsList; }
        }

        protected override DetailsView ItemDetails
        {
            get { return DetailsViewEditItem; }
        }

        protected override bool AllowInsert
        {
            get
            {
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                Erc.Apple.Data.Log.Clear();
                GridViewItemsList.DataBind();
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        protected void GridViewItemsList_DataBound(object sender, EventArgs e)
        {
            if (GridViewItemsList.Rows.Count == 0)
            {
                btnClearLog.Visible = false;
            }
            else
            {
                btnClearLog.Visible = true;
            }
        }
    }
}