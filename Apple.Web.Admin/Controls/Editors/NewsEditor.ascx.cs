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
using Apple.Web.Admin.Tools;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class NewsEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
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
            dpNewsDate.SelectedDate = null;
            chbIsMain.Checked = false;
            btnDeleteImage.Visible = false;
            cp.ClearSelection();
        }
        private void BindCommonFields()
        {
            News news = new News();
            NewsItem item = news.GetByLangGroup("ru", GroupID);

            if (item != null)
            {
                dpNewsDate.SelectedDate = item.Date;
                //ip.CheckItem(item.ImagePosition);
                btnDeleteImage.Visible = item.HasImage;

                List<int> pages = news.GetContentPagesIDs(item.GroupID);
                List<int> sections = news.GetContentSectionsIDs(item.GroupID);

                cp.CheckItems(pages);
                //cs.CheckItems(sections);

                chbIsMain.Checked = item.IsMain;
            }
        }
        private void SaveCommonFields()
        {
            News news = new News();
            if (fuImage.HasFile && fuImage.FileBytes.Length>0)
            {
                int size = 0;
                byte[] image = fuImage.FileBytes;
                
                if (int.TryParse(ConfigurationManager.AppSettings["NewsImageWidth"],out size))
                {
                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    string mime = fuImage.PostedFile.ContentType.ToLower();
                    if (mime == "image/gif")
                    {
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                    }
                    else if (mime == "image/png")
                    {
                        format = System.Drawing.Imaging.ImageFormat.Png;
                    }
                    image = ImageResizer.ResizeByWidth(fuImage.FileBytes, format, size);
                }
                
                if (news.UpdateImage(this.GroupID, image))
                    btnDeleteImage.Visible = true;
            }
            //save pages
            news.ShowOnPages(this.GroupID, cp.GetSelectedIDs());
            //save sections
            //news.ShowInSections(this.GroupID, cs.GetSelectedIDs());
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
            NewsItemEditor editor = (NewsItemEditor)sender;

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
                    NewsItemEditor editor = (NewsItemEditor)item.FindControl("editor");
                    editor.NewsDate = dpNewsDate.SelectedDate;
                    editor.IsMain = chbIsMain.Checked;
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
            News news = new News();
            if (news.DeleteImage(this.GroupID))
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
            GroupID = News.GetNextGroupID();
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