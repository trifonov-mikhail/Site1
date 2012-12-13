using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Erc.Apple.Data;
using System.Web.Configuration;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class SuccessStoriesEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
    {
        public Control addButton;

        protected int GroupID
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
		protected void Page_Load(object sender, EventArgs e)
		{
            
		}
        private void InitCommonFields()
        {
            btnDeleteImage.Visible = false;
        }
        private void BindCommonFields()
        {
            SuccessStories dao = new SuccessStories();
            SuccessStory item = dao.GetByLangGroup("ru", GroupID);

            if (item != null)
            {
                dpStoryDate.SelectedDate = item.Date;
                //ip.CheckItem(item.ImagePosition);
                btnDeleteImage.Visible = item.HasImage;

                List<int> pages = dao.GetContentPagesIDs(item.GroupID);
                List<int> sections = dao.GetContentSectionsIDs(item.GroupID);

            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
        public System.Drawing.Image Resize(System.Drawing.Image img, int maxWidth)
        {
            //get the height and width of the image
            int originalW = img.Width;
            int originalH = img.Height;

            float percentage = (float)maxWidth / img.Width;
            //get the new size based on the percentage change
            int resizedW = (int)(originalW * percentage);
            int resizedH = (int)(originalH * percentage);

            //create a new Bitmap the size of the new image
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(resizedW, resizedH);
            //create a new graphic from the Bitmap
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage((System.Drawing.Image)bmp);
            graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(img, 0, 0, resizedW, resizedH);
            //dispose and free up the resources
            graphic.Dispose();
            //return the image
            return (System.Drawing.Image)bmp;
        }
        private void SaveCommonFields()
        {
            SuccessStories dao = new SuccessStories();
            if (fuImage.HasFile)
            {
                byte[] fileBytes = null;
                System.Drawing.Image image = byteArrayToImage(fuImage.FileBytes);
                int maxWidth = 320;
                try
                {
                    maxWidth = Int32.Parse(WebConfigurationManager.AppSettings["MaxWidthImageSuccessStories"]);
                }
                catch (Exception)
                {

                }
                if (image.Width > maxWidth)
                {
                    image = Resize(image, maxWidth);
                }
                fileBytes = imageToByteArray(image);
                if (fileBytes != null && dao.UpdateImage(this.GroupID, fileBytes))
                    btnDeleteImage.Visible = true;
            }
            //save pages
            //dao.ShowOnPages(this.GroupID, cp.GetSelectedIDs());
            //save sections
            
        }

		protected void RepeaterLang_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                BindCommonFields();
            }
        }
        
        protected void editor_Load(object sender, EventArgs e)
        {
            SuccessStoryEditor editor = (SuccessStoryEditor)sender;

			if (GroupID == 0)
			{
				editor.ChangeMode(DetailsViewMode.Insert);
			}
			else
			{
				
			}
        	editor.GroupID = this.GroupID;

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        protected void GridViewItemsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupID = Convert.ToInt32(GridViewItemsList.SelectedValue);
            RepeaterLang.DataBind();
            MvEditor.ActiveViewIndex = 1;
            AddButton.Visible = false;
        }

        protected void ObjectDataSourceEditItem_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            
        }

		protected void ODSCategory_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
		{
			//e.InputParameters["language"] = "ru";
		}

        protected void GridViewItemsList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                GroupID = 0;
                RepeaterLang.DataBind();
                
            }else
            {
                
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
                Close();
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        private void Save()
        {
            foreach (RepeaterItem item in RepeaterLang.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    SuccessStoryEditor editor = (SuccessStoryEditor)item.FindControl("editor");
                    editor.StoryDate = dpStoryDate.SelectedDate;
                    //editor.ImagePosition = ip.GetSelectedID();
                	editor.SaveItem();
                }
            }
            SaveCommonFields();
            GridViewItemsList.DataBind();
            //add new after saving
            //if (Convert.ToInt32(GridViewItemsList.SelectedValue) == 0)
            //    GroupID = Categories.GetNextCategoryGroupID();
            //RepeaterLang.DataBind();
        }

        private void Close()
        {
            MvEditor.ActiveViewIndex = 0;
            AddButton.Visible = true;
        }

		protected  void btnDeleteImage_Click(object sender, EventArgs e)
		{
            SuccessStories dao = new SuccessStories();
            if (dao.DeleteImage(this.GroupID))
                btnDeleteImage.Visible = false;
		}
        #region IAddControl Members

        public bool NeedAddButton
        {
            get 
            {
                return true;
            }
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            GridViewItemsList.SelectedIndex = -1;
            GroupID = Stories.GetNextGroupID();
            RepeaterLang.DataBind();
            MvEditor.ActiveViewIndex = 1;

            //AddButton = sender as AddItemButton;

            AddButton.Visible = false;
            InitCommonFields();
        }

        public Control AddButton
        {
            get
            {
                return addButton;
            }
            set
            {
                addButton = value;
            }
        }

        #endregion

        protected void GridViewItemsList_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridViewItemsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}