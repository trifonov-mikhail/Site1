using System;
using System.Collections.Generic;
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
    public partial class ServicesEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
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
			DdlRegionFilter.DataBound += new EventHandler(DdlRegionFilter_DataBound);
			ddlCityFilter.DataBound +=new EventHandler(ddlCityFilter_DataBound);
			ddlSpecialization.DataBound +=new EventHandler(ddlSpecialization_DataBound);
			if(Request.UrlReferrer.AbsoluteUri.ToLower().IndexOf("cities.aspx") > 0)
			{
				
				string region = "0";
				if (!string.IsNullOrEmpty(Request["Region"]))
				{
					BackLink.Visible = true;
					region = Request["Region"];
					BackLink.Text = string.Format("<a href='{0}' >К городам</a>",
								this.ResolveUrl(string.Format("~/Cities.aspx?region={0}", region))
								);
				}
				
			}
		}

		void ddlSpecialization_DataBound(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Request["Specialization"]))
			{
				ListItem item = ddlSpecialization.Items.FindByValue(Request["Specialization"]);
				if (item != null)
				{
					ddlSpecialization.SelectedValue = Request["Specialization"];
				}
			}
		}

		void ddlCityFilter_DataBound(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Request["City"]))
			{
				ListItem item = ddlCityFilter.Items.FindByValue(Request["City"]);
				if (item != null)
				{
					ddlCityFilter.SelectedValue = Request["City"];
				}
			}
		}

		void DdlRegionFilter_DataBound(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Request["Region"]))
			{
				ListItem item = DdlRegionFilter.Items.FindByValue(Request["Region"]);
				if (item != null)
				{
					DdlRegionFilter.SelectedValue = Request["Region"];
				}
			}
		}

		private void InitService()
    	{
			Services ps = new Services();
			Service p = ps.GetByLangGroup("ru", this.GroupID);

    		if (p != null)
    		{
				if(ddlRegion.Items.Count == 0)
					ddlRegion.DataBind();
				ListItem item = ddlRegion.Items.FindByValue(p.RegionID.ToString());
				if (item != null && item.Value == p.RegionID.ToString())
    			{
					ddlRegion.SelectedValue = p.RegionID.ToString();
    			}
				if (ddlCity.Items.Count == 0)
					ddlCity.DataBind();
				item = ddlCity.Items.FindByValue(p.CityID.ToString());
				if (item != null && item.Value == p.CityID.ToString())
				{
					ddlCity.SelectedValue = p.CityID.ToString();
				}
				if (ddlStatus.Items.Count == 0)
					ddlStatus.DataBind();
				item = ddlStatus.Items.FindByValue(p.ServiceStatusID.ToString());
				if (item != null && item.Value == p.ServiceStatusID.ToString())
				{
					ddlStatus.SelectedValue = p.ServiceStatusID.ToString();
				}
    			txtTelephone.Text = p.Telephone;
				txtUrl.Text = p.Url;
                chbSpecialization.ClearSelection();
				ServiceSpecializations serviceSpecializations = new ServiceSpecializations();
				List<Specialization> specializations = serviceSpecializations.GetAllSpecializationByService(p);
    			for (int i = 0; i < chbSpecialization.Items.Count; i++)
    			{
    				for (int j = 0; j < specializations.Count; j++)
    				{
						if (chbSpecialization.Items[i].Value == specializations[j].GroupID.ToString())
						{
							chbSpecialization.Items[i].Selected = true;
							break;
						}
    				}
    			}
				
    		}
    	}

    	protected void RepeaterLang_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }
        
        protected void editor_Load(object sender, EventArgs e)
        {
			ServiceEditor editor = (ServiceEditor)sender;

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
			InitService();
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
					ServiceEditor editor = (ServiceEditor)item.FindControl("editor");
                	editor.CityID = Int32.Parse(ddlCity.SelectedValue);
					editor.RegionID = Int32.Parse(ddlRegion.SelectedValue);
                	editor.ServiceStatus = Int32.Parse(ddlStatus.SelectedValue);
                	editor.Telephone = txtTelephone.Text;
					editor.Url = txtUrl.Text;
                    editor.SaveItem();
                }
            }
			ServiceSpecializations ps = new ServiceSpecializations();
        	ps.Delete(this.GroupID);
        	for (int i = 0; i < chbSpecialization.Items.Count; i++)
        	{

        		if(chbSpecialization.Items[i].Selected)
        		{
					ServiceSpecialization p = new ServiceSpecialization();
        			p.ServiceID = this.GroupID;
        			p.SpecializationID = Int32.Parse(chbSpecialization.Items[i].Value);
        			ps.Add(p);
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
        	GroupID = Services.GetNextGroupID();
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

        protected void GridViewItemsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Services dao = new Services();

            if (e.CommandName == "On" || e.CommandName == "Off")
            {
                int id = int.Parse((string)e.CommandArgument);
                dao.ChangePublishStatus(id);
            }
            
            GridViewItemsList.DataBind();
        }

    }
}