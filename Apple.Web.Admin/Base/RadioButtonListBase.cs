using System;
using System.Collections.Generic;
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
    /// Summary description for CheckBoxListBase
    /// </summary>
    public abstract class RadioButtonListBase:RadioButtonList
    {
        public RadioButtonListBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            FillValues();
        }
        
        protected abstract void FillValues();

        public void Refresh()
        {
            Items.Clear();
            FillValues();
        }

        public void CheckItem(int value)
        {
            this.ClearSelection();
            ListItem item = this.Items.FindByValue(value.ToString());
            if (item != null)
            {
                item.Selected = true;
            }
        }
        public int GetSelectedID()
        {
            int id = 0;

            if (SelectedValue.Length > 0)
            {
                id = Convert.ToInt32(SelectedValue);
            }

            return id;
        }
    }
}
