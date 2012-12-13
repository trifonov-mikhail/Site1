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
    public partial class CitiesEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
    {
        string CityNameFilter;

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
            ddlRegionFilter.DataBound += new EventHandler(ddlRegionFilter_DataBound);
		}

        void ddlRegionFilter_DataBound(object sender, EventArgs e)
		{
            if (!string.IsNullOrEmpty(Request["Region"]))
			{
                ListItem item = ddlRegionFilter.Items.FindByValue(Request["Region"]);
				if (item != null)
				{
                    ddlRegionFilter.SelectedValue = Request["Region"];
				}
			}
		}

        protected void ddlRegions_DataBound(object sender, EventArgs e)
        {
            InitCategory();
        }

    	private void InitCategory()
    	{
    		Cities ps = new Cities();
    		City p = ps.GetByLangGroup("ru", this.GroupID);

    		if (p != null)
    		{
                ListItem item = ddlRegions.Items.FindByValue(p.RegionID.ToString());
    			if (item != null && item.Value == p.RegionID.ToString())
    			{
                    ddlRegions.SelectedValue = p.RegionID.ToString();
    			}
    		}
    	}

    	protected void RepeaterLang_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        
        protected void editor_Load(object sender, EventArgs e)
        {
			CityEditor editor = (CityEditor)sender;

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

		protected void ODSRegions_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
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
					CityEditor editor = (CityEditor)item.FindControl("editor");
                    editor.RegionID = Int32.Parse(ddlRegions.SelectedValue);
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
            GroupID = Cities.GetNextCGroupID();
            RepeaterLang.DataBind();
            MvEditor.ActiveViewIndex = 1;

            //AddButton = sender as AddItemButton;

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

        protected void btnApplyFilter_Click(object sender, EventArgs e)
        {
            CityNameFilter = txtNameFilter.Text.Trim();
            GridViewItemsList.DataBind();
        }

        protected void ObjectDataSourceItemsList_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["name"] = this.CityNameFilter;
        }
    }
}