using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Erc.Apple.Data;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class ProductsEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
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
			DdlCategoryFilter.DataBound += new EventHandler(DdlCategoryFilter_DataBound);
		}

        private void InitCommonFields()
        {
            //btnDeleteImage.Visible = false;
            //cs.ClearSelection();
            //cp.ClearSelection();
            btnDeleteImage.Visible = false;
            ddlCategory.ClearSelection();
        }

		void DdlCategoryFilter_DataBound(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Request["Category"]))
			{
				ListItem item = DdlCategoryFilter.Items.FindByValue(Request["Category"]);
				if (item != null)
				{
					DdlCategoryFilter.SelectedValue = Request["Category"];
				}
			}
		}

        protected void ddlCategory_DataBound(object sender, EventArgs e)
        {
            InitCategory();
        }

    	private void InitCategory()
    	{
    		Products ps = new Products();
    		Product p = ps.GetByLangGroup("ru", this.GroupID);

    		if (p != null)
    		{
    			ListItem item = ddlCategory.Items.FindByValue(p.CategoryID.ToString());
    			if (item != null && item.Value == p.CategoryID.ToString())
    			{
    				ddlCategory.SelectedValue = p.CategoryID.ToString();
    			}
				if(p.ImageLenght > 0)
				{
					btnDeleteImage.Visible = true;
				}
				else
				{
					btnDeleteImage.Visible = false;
				}
    		}
    	}

    	protected void RepeaterLang_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        
        protected void editor_Load(object sender, EventArgs e)
        {
			ProductEditor editor = (ProductEditor)sender;

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
			InitCategory();
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
					ProductEditor editor = (ProductEditor)item.FindControl("editor");
                	editor.CategoryID = Int32.Parse(ddlCategory.SelectedValue);
                    editor.SaveItem();
                }
            }
			if(fuImage.HasFile)
			{
				Products ps = new Products();
				Product p = new Product();
				p.Image = fuImage.FileBytes;
				p.ImageName = Path.GetFileName(fuImage.FileName);
				p.ImageType = fuImage.PostedFile.ContentType;
				p.GroupID = this.GroupID;
				if(ps.UpdateImageByGroupID(p))
					btnDeleteImage.Visible = true;
			}
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
			Products ps = new Products();
			if(ps.DeleteImageByGroupID(this.GroupID))
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
            GroupID = Products.GetNextGroupID();
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
            ImageButton ib = null;
            if (GridViewItemsList.Rows.Count > 0)
            {
                ib = (ImageButton)GridViewItemsList.Rows[0].Cells[1].FindControl("imgUp");
                ib.Visible = false;

                ib = (ImageButton)GridViewItemsList.Rows[GridViewItemsList.Rows.Count - 1].Cells[1].FindControl("imgDown");
                ib.Visible = false;

                if (GridViewItemsList.Rows.Count == 1 || DdlCategoryFilter.SelectedValue=="0")
                    GridViewItemsList.Columns[1].Visible = false;
                else
                    GridViewItemsList.Columns[1].Visible = true;
            }
        }

        protected void GridViewItemsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Products dao = new Products();

            if (e.CommandName == "MoveUp")
            {
                int id = int.Parse((string)e.CommandArgument);
                int category = int.Parse(DdlCategoryFilter.SelectedValue);
                dao.MoveUp(id, category);
            }
            else if (e.CommandName == "MoveDown")
            {
                int id = int.Parse((string)e.CommandArgument);
                int category = int.Parse(DdlCategoryFilter.SelectedValue);
                dao.MoveDown(id, category);
            }

            GridViewItemsList.DataBind();
        }
    }
}