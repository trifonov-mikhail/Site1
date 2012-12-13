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

namespace Apple.Web.Admin.Controls
{
    public partial class CaseStudyEditor : UserControlBase
    {
        public int GroupID
        {
            get
            {
                return Convert.ToInt32(ViewState["GroupID"]);
            }
            set
            {
                ViewState["GroupID"] = value;
            }
        }

		public string LangCode
        {
            get
            {
                return Convert.ToString(ViewState["LangCode"]);
            }
            set
            {
                ViewState["LangCode"] = value;
            }
        }

        private DateTime? caseStudyDate;

        public DateTime? CaseStudyDate
        {
            get { return caseStudyDate; }
            set { caseStudyDate = value; }
        }

        int imagePosition;
        public int ImagePosition
        {
            get
            {
                return imagePosition;
            }
            set
            {
                imagePosition = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void SaveItem()
        {
            if (DetailsViewEditItem.CurrentMode == DetailsViewMode.Insert)
            {
                DetailsViewEditItem.InsertItem(false);
            }
            else if (DetailsViewEditItem.CurrentMode == DetailsViewMode.Edit)
            {
                DetailsViewEditItem.UpdateItem(false);
            }
        }
        public void ChangeMode(DetailsViewMode mode)
        {
            DetailsViewEditItem.ChangeMode(mode);
        }
        protected void ObjectDataSourceEditItem_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["groupId"] = GroupID;
            e.InputParameters["language"] = LangCode;
        }

		protected void DetailsViewEditItem_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
		{
			e.NewValues["LangCode"] = this.LangCode;
			e.NewValues["GroupID"] = this.GroupID;
            e.NewValues["ImagePosition"] = ImagePosition;
            e.NewValues["Date"] = CaseStudyDate;
            
		}

        protected void DetailsViewEditItem_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["LangCode"] = this.LangCode;
            e.Values["GroupID"] = this.GroupID;
            e.Values["ImagePosition"] = ImagePosition;
            e.Values["Date"] = CaseStudyDate;
        }

        protected void DetailsViewEditItem_DataBound(object sender, EventArgs e)
        {

        }
        protected void ObjectDataSourceEditItem_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception==null)
            {
                if (e.ReturnValue == null)
                {
                    DetailsViewEditItem.ChangeMode(DetailsViewMode.Insert);
                }
            }
            else
            {
                //e.ExceptionHandled = true;
            }
        }
    }
}