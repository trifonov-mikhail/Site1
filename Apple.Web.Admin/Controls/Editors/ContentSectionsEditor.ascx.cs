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
    public partial class ContentSectionsEditor : EditorBase, Apple.Web.Admin.Interfaces.IAddControl
    {
        public Control addButton;

        protected override GridView ItemsList
        {
            get { return GridViewItemsList; }
        }

        protected override DetailsView ItemDetails
        {
            get { return DetailsViewEditItem; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridViewItemsList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            MvEditor.ActiveViewIndex = 1;
            AddButton.Visible = false;
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
            if (DetailsViewEditItem.CurrentMode == DetailsViewMode.Insert)
            {
                DetailsViewEditItem.InsertItem(false);
            }
            else if (DetailsViewEditItem.CurrentMode == DetailsViewMode.Edit)
            {
                DetailsViewEditItem.UpdateItem(false);
            }
        }
        private void Close()
        {
            MvEditor.ActiveViewIndex = 0;
            AddButton.Visible = true;
        }

        protected void GridViewItemsList_DataBound(object sender, EventArgs e)
        {
        }

        #region IAddControl Members

        public bool NeedAddButton
        {
            get { return true; }
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

        public void AddButton_Click(object sender, EventArgs e)
        {
            GridViewItemsList.SelectedIndex = -1;
            MvEditor.ActiveViewIndex = 1;

            if (DetailsViewEditItem.CurrentMode != DetailsViewMode.Insert)
            {
                DetailsViewEditItem.ChangeMode(DetailsViewMode.Insert);
            }

            AddButton.Visible = false;
        }

        #endregion

        protected void ObjectDataSourceEditItem_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {

        }

        protected void DetailsViewEditItem_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            
        }
    }
}