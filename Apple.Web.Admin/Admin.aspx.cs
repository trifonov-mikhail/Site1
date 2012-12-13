using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;
using Apple.Web.Admin.Interfaces;

namespace Apple.Web.Admin
{
    public partial class AdminsPage : PageBase
    {
        private IAddControl ControlAddItem;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && User.Identity.Name.ToLower() == "admin")
            {
                RegCss("~/css/Developer.css");
            }
            else
            {
                RegCss("~/css/AdminPage.css");
            }
            RegCss("~/js/calendar/themes/layouts/small.css");
            RegCss("~/js/calendar/themes/aqua.css");

            RegJS("~/js/calendar/utils/zapatec.js");
            RegJS("~/js/calendar/src/calendar.js");
            RegJS("~/js/calendar/lang/calendar-ru.js");

            RegJS("~/js/tiny_mce/tiny_mce.js");
            RegJS("~/js/tiny_mce/mce_init_blue.js");

            lblError.Visible = false;
            lblInfo.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(Request.QueryString["id"], out id))
                id = 2;

            AdminPages dao = new AdminPages();

            AdminPage page = dao.GetByID(id);

            if (page != null)
            {
                Control c = null;

                if (!string.IsNullOrEmpty(page.TabContentTitle))
                {
                    lblTabContentTitle.Text = page.TabContentTitle;
                }
                else
                {
                    lblTabContentTitle.Text = page.Title;
                }

                try
                {
                    c = LoadControl(page.Control);

                    ControlAddItem = c as IAddControl;
                    if (ControlAddItem != null)
                    {
                        if (ControlAddItem.NeedAddButton)
                        {
							if(!this.IsPostBack)
								btnAdd.Visible = true;
                            btnAdd.Click += new EventHandler(ControlAddItem.AddButton_Click);

                            ControlAddItem.AddButton = btnAdd;
                        }
                    }
                }
                catch (Exception exc)
                {
                    c = new LiteralControl(String.Format("Error while loading control \"{0}\": {1}", page.Control ?? "Empty", exc.Message));
                }

                PanelMain.Controls.Add(c);
            }

        }

        public override void ShowError(string error)
        {
            lblError.Text = error;
            lblError.Visible = true;
        }

    	public override void ShowError(Exception exc)
        {
            string mess = exc.Message;
            if (exc.InnerException != null)
            {
                mess += string.Format("<br />{0}", exc.InnerException.Message);
            }
            lblError.Text = mess;
            lblError.Visible = true;
        }

        public override void ShowMessage(string mess)
        {
            lblInfo.Text = mess;
            lblInfo.Visible = true;
        }
    }
}
