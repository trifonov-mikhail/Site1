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

namespace Apple.Web.Admin.Controls
{
    public partial class DatePicker : UserControlBase
    {
        public DateTime? SelectedDate
        {
            get 
            {
                DateTime date;

                if (DateTime.TryParse(txtDate.Text, out date))
                {
                    return date; 
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                if (value.HasValue)
                {
                    txtDate.Text = value.Value.ToShortDateString();
                }else{
                    txtDate.Text = null;
                }
            }
        }

        private bool isRequired;

        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        public string ValidationGroup
        {
            get
            {
                return txtDate.ValidationGroup;
            }
            set
            {
                txtDate.ValidationGroup = rvf.ValidationGroup = value;
            }
        }
	
	
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Attributes.Add("onkeypress", "return false;");
            txtDate.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#eee");
            txtDate.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
            txtDate.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
            txtDate.Style.Add(HtmlTextWriterStyle.BorderColor, "#aaa");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            rvf.Visible = IsRequired;
        }
    }
}