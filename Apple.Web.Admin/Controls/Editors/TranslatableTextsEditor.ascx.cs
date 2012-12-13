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
    public partial class TranslatableTextsEditor : UserControlBase, Apple.Web.Admin.Interfaces.IAddControl
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

        }
        private void BindCommonFields()
        {
            TranslatableText text = new TranslatableTexts().GetByLangGroup("ru", GroupID);
            if (text != null)
            {
                txtName.Text = text.ID;
            }
        }
        private void SaveCommonFields()
        {
            
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
            TranslatableTextItemEditor editor = (TranslatableTextItemEditor)sender;

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
            if (NeedAddButton)
                AddButton.Visible = false;
            txtName.ReadOnly = true;
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

            }
            else
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
                    TranslatableTextItemEditor editor = (TranslatableTextItemEditor)item.FindControl("editor");
                    editor.ItemID = txtName.Text;
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
            if (NeedAddButton)
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
            GroupID = TranslatableTexts.GetNextGroupID();
            RepeaterLang.DataBind();
            MvEditor.ActiveViewIndex = 1;

            //AddButton = sender as AddItemButton;
            txtName.Text = "";
            if(NeedAddButton)
                AddButton.Visible = false;
            txtName.ReadOnly = false;

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