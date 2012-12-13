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

namespace Apple.Web.Controls
{
    public partial class ProductCategory : UserControlBase
    {
        public int CategoryID
        {
            get { return Convert.ToInt32(ViewState["CategoryID"]); }
            set { ViewState["CategoryID"] = value; }
        }
        private string itemIndex = "1";

        public string ItemIndex
        {
            get { return itemIndex; }
            set { itemIndex = value; }
        }
	
        public string ScriptID
        {
            get { return String.Format("G{0}", ItemIndex); }
        }
        public string CategoryName
        {
            get { return Convert.ToString(ViewState["CategoryName"]); }
            set { ViewState["CategoryName"] = value; }
        }
        string rightButtonID = string.Empty;
        public string RightButtonID
        {
            get
            {
                return rightButtonID;
            }
            set
            {
                rightButtonID = value;
            }
        }
        string leftButtonID = string.Empty;
        public string LeftButtonID
        {
            get
            {
                return leftButtonID;
            }
            set
            {
                leftButtonID = value;
            }
        }
	
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void odsProducts_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["language"] = this.CurrentLanguage;
            e.InputParameters["categoryId"] = this.CategoryID;
        }

        protected void rProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Image img = (Image)e.Item.FindControl("btnLeft");

                LeftButtonID = img.ClientID;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                Image img = (Image)e.Item.FindControl("btnRight");

                RightButtonID = img.ClientID;
            }

        }

        public string FormatName(string name)
        {
            return name.Replace("  ", "<br/>").Replace(" ","&nbsp;");
        }
    }
}