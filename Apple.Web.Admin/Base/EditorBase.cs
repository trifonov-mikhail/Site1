using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Admin.Controls
{
    /// <summary>
    /// Summary description for EditorBase
    /// </summary>
    public abstract class EditorBase : UserControlBase
    {
        protected abstract GridView ItemsList
        {
            get;
        }
        protected abstract DetailsView ItemDetails
        {
            get;
        }
        protected virtual bool AllowInsert
        {
            get
            {
                return true;
            }
        }
        protected virtual bool HandleErrors
        {
            get
            {
                return true;
            }
        }
        public EditorBase()
        {
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ItemsList.SelectedIndexChanging += new GridViewSelectEventHandler(ItemsList_SelectedIndexChanging);
            ItemsList.RowDeleted += new GridViewDeletedEventHandler(ItemsList_RowDeleted);
            ItemsList.PageIndexChanging += new GridViewPageEventHandler(ItemsList_PageIndexChanging);

            ItemDetails.DataBound += new EventHandler(ItemDetails_DataBound);
            ItemDetails.ItemInserted += new DetailsViewInsertedEventHandler(ItemDetails_ItemInserted);
            ItemDetails.ItemUpdated += new DetailsViewUpdatedEventHandler(ItemDetails_ItemUpdated);
            ItemDetails.ModeChanged += new EventHandler(ItemDetails_ModeChanged);
        }

        void ItemsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ItemsList.SelectedIndex = -1;
        }

        void ItemDetails_ModeChanged(object sender, EventArgs e)
        {
            if (ItemDetails.CurrentMode == DetailsViewMode.Insert)
            {
                ItemsList.SelectedIndex = -1;
            }
        }

        void ItemDetails_DataBound(object sender, EventArgs e)
        {
            if (ItemDetails.DataItemCount == 0 && ItemDetails.CurrentMode == DetailsViewMode.Edit && AllowInsert)
            {
                ItemDetails.ChangeMode(DetailsViewMode.Insert);
            }
        }

        void ItemsList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                //ItemDetails.DataBind();
            }
            else
            {
                ShowError(e.Exception);

                e.ExceptionHandled = HandleErrors;
            }
        }

        void ItemsList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (ItemDetails.CurrentMode != DetailsViewMode.Edit)
            {
                ItemDetails.ChangeMode(DetailsViewMode.Edit);
            }
        }

        void ItemDetails_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (e.Exception == null)
            {
                ItemsList.DataBind();
            }
            else
            {
                ShowError(e.Exception);

                e.ExceptionHandled = HandleErrors;
                e.KeepInInsertMode = true;
            }
        }
        void ItemDetails_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {
                ItemsList.DataBind();
            }
            else
            {
                ShowError(e.Exception);

                e.ExceptionHandled = HandleErrors;
                e.KeepInEditMode = true;
            }
        }
    }
}