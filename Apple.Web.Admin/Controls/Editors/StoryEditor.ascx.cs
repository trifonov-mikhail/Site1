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

namespace Apple.Web.Admin.Controls
{
    public partial class StoryEditor : UserControlBase
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

        private DateTime? storyDate;

        public DateTime? StoryDate
        {
            get { return storyDate; }
            set { storyDate = value; }
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
            Button b = this.DetailsViewEditItem.FindControl("PdfName") as Button;
            if (b != null)
            {
                b.Click += new EventHandler(GetPdfFile);
            }
        }

        protected void GetPdfFile(object sender, EventArgs e)
        {

            Stories ss = new Stories();
            Story sstory = ss.GetPdfFile(this.LangCode, this.GroupID);
            if (sstory != null && sstory.PdfFile != null && sstory.PdfFile.Length > 0 && !string.IsNullOrEmpty(sstory.PdfFileName))
            {
                Response.Clear();
                Response.AppendHeader("content-disposition", "attachment; filename=" + sstory.PdfFileName);
                Response.BinaryWrite(sstory.PdfFile);
                Response.Flush();
            }
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

             //Save Pdf file for item
            FileUpload fuUpload = this.DetailsViewEditItem.FindControl("fuImage") as FileUpload;
            if (fuUpload != null && fuUpload.HasFile)
            {
                Stories s = new Stories();
                if (s.UpdatePdfFile(this.GroupID, this.LangCode, fuUpload.FileBytes, fuUpload.FileName))
                {
                    ImageButton btnDeletePdfFile = this.DetailsViewEditItem.FindControl("btnDeletePdfFile") as ImageButton;
                    if (btnDeletePdfFile != null)
                    {
                        btnDeletePdfFile.Visible = true;
                    }
                    Button b = this.DetailsViewEditItem.FindControl("PdfName") as Button;
                    if (b != null)
                    {
                        b.Text = fuUpload.FileName;
                        b.Visible = true;
                        b.Click += new EventHandler(GetPdfFile);
                    }
                }
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
            e.NewValues["Date"] = StoryDate;
            
		}

        protected void DetailsViewEditItem_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Values["LangCode"] = this.LangCode;
            e.Values["GroupID"] = this.GroupID;
            e.Values["ImagePosition"] = ImagePosition;
            e.Values["Date"] = StoryDate;
        }

        protected void DetailsViewEditItem_DataBound(object sender, EventArgs e)
        {
            Story ss = (new Stories()).GetByLangGroup(this.LangCode, this.GroupID);
            if (ss != null && ss.HasPdfFile)
            {
                ImageButton btnDeletePdfFile = this.DetailsViewEditItem.FindControl("btnDeletePdfFile") as ImageButton;
                if (btnDeletePdfFile != null)
                {
                    btnDeletePdfFile.Visible = true;
                }
                Button b = this.DetailsViewEditItem.FindControl("PdfName") as Button;
                if (b != null)
                {
                    b.Text = ss.PdfFileName;
                    b.Visible = true;
                    b.Click += new EventHandler(GetPdfFile);
                }
            }
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

        protected void btnDeletePdfFile_Click(object sender, EventArgs e)
        {
            Stories ss = new Stories();
            if (ss.DeletePdfFile(LangCode, GroupID))
            {
                ImageButton btnDeletePdfFile = this.DetailsViewEditItem.FindControl("btnDeletePdfFile") as ImageButton;
                if (btnDeletePdfFile != null)
                {
                    btnDeletePdfFile.Visible = false;
                }
                Button b = this.DetailsViewEditItem.FindControl("PdfName") as Button;
                if (b != null)
                {
                    b.Visible = false;
                }
            }
        }
    }
}