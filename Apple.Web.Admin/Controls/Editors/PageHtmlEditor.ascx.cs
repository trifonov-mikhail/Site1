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
    public partial class PageHtmlEditor : UserControlBase
    {
        private string pageID="test";

        public string PageID
        {
            get { return pageID; }
            set { pageID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSourceEditItem_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["name"] = PageID;
        }

        protected void DetailsViewEditItem_DataBound(object sender, EventArgs e)
        {
            if (DetailsViewEditItem.DataItemCount == 0 && DetailsViewEditItem.CurrentMode == DetailsViewMode.Edit)
            {
                DetailsViewEditItem.ChangeMode(DetailsViewMode.Insert);
            }
        }

        protected void DetailsViewEditItem_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["Name"] = PageID;
        }

        protected void DetailsViewEditItem_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.Exception == null)
            {

            }
            else
            {
                ShowError(e.Exception);
                e.ExceptionHandled = true;
            }
        }

        protected void DetailsViewEditItem_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {

            }
            else
            {
                ShowError(e.Exception);
                e.ExceptionHandled = true;
            }
        }

        protected void ObjectDataSourceEditItem_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {

            }
            else
            {
                ShowError(e.Exception);
                e.ExceptionHandled = true;
            }
        }
    }
}