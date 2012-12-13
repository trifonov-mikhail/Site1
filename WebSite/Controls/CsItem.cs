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
    public partial class CsItem : System.Web.UI.UserControl
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string notice;

        public string Notice
        {
            get { return notice; }
            set { notice = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private int csID;

        public int CsID
        {
            get { return csID; }
            set { csID = value; }
        }

        public string ImageUrl
        {
            get { return string.Format("~/GetImage.ashx?type=3&id={0}", CsID); }
        }

        private string linkText;

        public string LinkText
        {
            get { return linkText; }
            set { linkText = value; }
        }

        private string linkUrl;

        public string LinkUrl
        {
            get { return linkUrl; }
            set { linkUrl = value; }
        }

        private string link2Text;

        public string Link2Text
        {
            get { return link2Text; }
            set { link2Text = value; }
        }

        private string link2Url;

        public string Link2Url
        {
            get { return link2Url; }
            set { link2Url = value; }
        }

        public bool HasLink
        {
            get
            {
                return !string.IsNullOrEmpty(LinkText);
            }
        }

        public bool HasLink2
        {
            get
            {
                return !string.IsNullOrEmpty(Link2Text);
            }
        }

        protected Label Label1;

        protected Label Label2;

        protected Label Label3;

        protected Image i;

        protected HyperLink link1;

        protected HyperLink link2;

        protected PlaceHolder phLink1;

        protected PlaceHolder phLink2;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Label1.Text = Title;
            Label2.Text = Notice;
            Label3.Text = Text;

            i.ImageUrl = ImageUrl;
            
            if (HasLink)
            {
                link1.Text = LinkText;
                link1.NavigateUrl = LinkUrl;
            }
            else
            {
                phLink1.Visible = false;
            }

            if (HasLink2)
            {
                link2.Text = Link2Text;
                link2.NavigateUrl = Link2Url;
            }
            else
            {
                phLink2.Visible = false;
            }
        }
    }
}