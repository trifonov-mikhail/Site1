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

namespace Apple.Web.Admin
{
    public partial class LoginPage : PageBase
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            RegCss("~/css/LoginPage.css");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (new Admins().Login(txtEmail.Text, txtPass.Text) ||
                FormsAuthentication.Authenticate(txtEmail.Text, txtPass.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtEmail.Text, false);
            }
            else
            {
				
                lblMess.Text = "Invalid credentials! Try again!";
            }
        }
    }
}
