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

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class CategoriesEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
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

		protected void RepeaterLang_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        
        protected void editor_Load(object sender, EventArgs e)
        {
            CategoryEditor editor = (CategoryEditor)sender;
            
            if (GroupID==0)
                editor.ChangeMode(DetailsViewMode.Insert);

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
                    CategoryEditor editor = (CategoryEditor)item.FindControl("editor");
                    editor.SaveItem();
                }
            }
            GridViewItemsList.DataBind();
        }
        private void Close()
        {
            MvEditor.ActiveViewIndex = 0;
            AddButton.Visible = true;
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
            GroupID = Categories.GetNextCategoryGroupID();
            RepeaterLang.DataBind();
            MvEditor.ActiveViewIndex = 1;

            AddButton.Visible = false;
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

        protected void GridViewItemsList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridViewItemsList_DataBound(object sender, EventArgs e)
        {
            ImageButton ib = null;
            if (GridViewItemsList.Rows.Count > 0)
            {
                ib = (ImageButton)GridViewItemsList.Rows[0].Cells[1].FindControl("imgUp");
                ib.Visible = false;
                
                ib = (ImageButton)GridViewItemsList.Rows[GridViewItemsList.Rows.Count - 1].Cells[1].FindControl("imgDown");
                ib.Visible = false;
                
                if (GridViewItemsList.Rows.Count == 1)
                    GridViewItemsList.Columns[1].Visible = false;
                else
                    GridViewItemsList.Columns[1].Visible = true;
            }
        }

        protected void GridViewItemsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Categories dao = new Categories();

            if (e.CommandName == "MoveUp")
            {
                int id = int.Parse((string)e.CommandArgument);
                dao.MoveUp(id);
            }
            else if (e.CommandName == "MoveDown")
            {
                int id = int.Parse((string)e.CommandArgument);
                dao.MoveDown(id);
            }

            GridViewItemsList.DataBind();
        }
    }
}