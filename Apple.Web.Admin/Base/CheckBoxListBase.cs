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
    public abstract class CheckBoxListBase:CheckBoxList
    {
        public CheckBoxListBase()
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

        public void CheckItems(List<int> items)
        {
            this.ClearSelection();
            foreach (int val in items)
            {
                ListItem item = this.Items.FindByValue(val.ToString());
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }
        public List<int> GetSelectedIDs()
        {
            List<int> ids = new List<int>();

            foreach (ListItem i in this.Items)
            {
                if (i.Selected)
                {
                    ids.Add(Convert.ToInt32(i.Value));
                }
            }
            return ids;
        }
    }
}
