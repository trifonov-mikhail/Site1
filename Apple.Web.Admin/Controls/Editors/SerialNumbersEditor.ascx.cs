using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple.Web.Admin.Interfaces;

namespace Apple.Web.Admin.Controls.Editors
{
	public partial class SerialNumbersEditor : EditorBase, IAddControl
	{
		public Control addButton;

        protected int SerialNumberID
        {
            get { return Convert.ToInt32(ViewState["SerialNumberID"]); }
            set { ViewState["SerialNumberID"] = value; }
        }

		protected override GridView ItemsList
		{
			get { return GridViewItemsList; }
		}

		protected override DetailsView ItemDetails
		{
			get { return DetailsViewEditItem; }
		}

		protected override bool HandleErrors
		{
			get { return false; }
		}

		#region IAddControl Members

		public bool NeedAddButton
		{
			get { return true; }
		}

		public Control AddButton
		{
			get { return addButton; }
			set { addButton = value; }
		}

		public void AddButton_Click(object sender, EventArgs e)
		{
			GridViewItemsList.SelectedIndex = -1;
			DetailsViewEditItem.ChangeMode(DetailsViewMode.Insert);
			MvEditor.SetActiveView(ViewEdit);
			AddButton.Visible = false;
		}

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			btnApplyFilter.Click += btnApplyFilter_Click;
			GridViewItemsList.SelectedIndexChanged += GridViewItemsList_SelectedIndexChanged;
			this.PreRender += SerialNumbersEditor_PreRender;

			csv.Options.FileName = "SerialNumbers";
			csv.Options.HeaderText = "ID,Number,ServiceID,CreatedDate,ModifiedDate";
			csv.Options.Columns = "ID,Number,ServiceID,CreatedDate,ModifiedDate";

		}

		void btnApplyFilter_Click(object sender, EventArgs e)
		{
		}

		void SerialNumbersEditor_PreRender(object sender, EventArgs e)
		{
			if (SerialNumberID > 0)
			{
				LinqDataSourceEditItem.Where = "ID = " + SerialNumberID;
				DetailsViewEditItem.ChangeMode(DetailsViewMode.Edit);
				MvEditor.SetActiveView(ViewEdit);
			}
		}

		void GridViewItemsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			SerialNumberID = Convert.ToInt32(GridViewItemsList.SelectedValue);
			LinqDataSourceEditItem.Where = "ID = " + SerialNumberID;
			DetailsViewEditItem.ChangeMode(DetailsViewMode.Edit);
			MvEditor.SetActiveView(ViewEdit);
		}

		protected void GridViewItemsList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
		{
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
			SerialNumberID = 0;
			GridViewItemsList.DataBind();
			MvEditor.SetActiveView(ViewList);
			AddButton.Visible = true;
		}

		protected void GridViewItemsList_DataBound(object sender, EventArgs e)
		{
			csv.Visible = (GridViewItemsList.Rows.Count > 0);
		}

		protected void DetailsViewEditItem_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
		{
			if (User != null)
				e.NewValues["AdminID"] = User.ID;

			e.NewValues["ModifiedDate"] = DateTime.Now;
		}

		protected void DetailsViewEditItem_ItemInserting(object sender, DetailsViewInsertEventArgs e)
		{
			if (User != null)
				e.Values["AdminID"] = User.ID;

			e.Values["CreatedDate"] = DateTime.Now;
		}

		protected void DetailsViewEditItem_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
		{
			e.KeepInInsertMode = true;
		}
	}
}