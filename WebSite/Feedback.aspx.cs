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
using System.Drawing;
using System.Web.Configuration;
using Apple.Web.Modules;

using System.Net;
using System.Net.Mail;

using Erc.Apple.Data;
using Erc.Apple.Data.Cache;

namespace Apple.Web
{
	public partial class FeedbackPage : PageBase
	{
		protected void Page_Init(object sender, EventArgs e)
        {
            btnSend.Click += new ImageClickEventHandler(btnSend_Click);
        }

        protected void Page_Load(object sender, EventArgs e)
		{
            SideBarItemsNames.AddRange(new string[] { "news", "about", "feedback" });

            phForm.Visible = true;
            phThankYou.Visible = false;
            lblError.Visible = false;
		}

        void btnSend_Click(object sender, ImageClickEventArgs e)
        {
            if (CheckRequiredField())
            {
                try
                {
                    SaveRequest();
                    SendMail();

                    phForm.Visible = false;
                    phThankYou.Visible = true;
                }
                catch (Exception exc)
                {
                    Logger.LogException(exc, "Feedback.aspx");
                    lblError.Visible = true;
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "reload", "setTimeout(\"" + ClientScript.GetPostBackEventReference(up, "") + "\",3000);", true);
            }
        }

        private void SaveRequest()
        {
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string position = txtPosition.Text;
            string company = txtCompany.Text;
            string comment = txtComment.Text;
            string email = txtEmail.Text;
            string phone = txtTelephone.Text;

            Feedbacks feedbacks = new Feedbacks();
            Feedback item = new Feedback();

            item.LastName = lastName;
            item.FirstName = firstName;
            item.Position = position;
            item.Company = company;
            item.Comment = comment;
            item.EMail = email;
            item.Telephone = phone;

            item.UserInfo = item.UserInfo = Server.UrlDecode(Request.ServerVariables.ToString().Replace("%0d%0a", "\r\n")).Replace("&","\r\n\t");

            feedbacks.AddUpdate(item);
        }

        private void SendMail()
        {
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string position = txtPosition.Text;
            string company = txtCompany.Text;
            string comment = txtComment.Text;
            string email = txtEmail.Text;
            string phone = txtTelephone.Text;

            MailDefinition md = new MailDefinition();
            md.BodyFileName = "~/MailTemplates/Feedback.htm";

            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("<%LastName%>", lastName);
            d.Add("<%FirstName%>", firstName);
            d.Add("<%Position%>", position);
            d.Add("<%Company%>", company);
            d.Add("<%Comment%>", comment);
            d.Add("<%Email%>", email);
            d.Add("<%Phone%>", phone);
            
            md.IsBodyHtml = true;

            ContactFormsCache forms = new ContactFormsCache();
            string formName = "Feedback";

            ContactForm form = forms.GetByName(formName);

            if (form == null)
                throw new InvalidOperationException(string.Format("Can not find settings for form {0}",formName));

            string subject = form.Subject;
            string to = form.To;
            string cc = form.CC;

            md.Subject = string.Format(subject, firstName, lastName);

            if (!string.IsNullOrEmpty(cc))
            {
                md.CC = cc;
            }

            MailMessage message = md.CreateMailMessage(to, d, this);

            SmtpClient sc = new SmtpClient();

            sc.Send(message);
        }

		private bool CheckRequiredField()
		{
			bool result = true;
			lbFirstName.ForeColor = Color.Black;
			lbLastName.ForeColor = Color.Black;
			lbEmail.ForeColor = Color.Black;

			if(string.IsNullOrEmpty(txtFirstName.Text))
			{
				lbFirstName.ForeColor = Color.Red;
				result = false;
			}
			if(string.IsNullOrEmpty(txtLastName.Text))
			{
				lbLastName.ForeColor = Color.Red;
				result = false;
			}
			if(string.IsNullOrEmpty(txtEmail.Text))
			{
				lbEmail.ForeColor = Color.Red;
				result = false;
			}
			else
			{
				
			}if(!Globals.CheckEmail(txtEmail.Text))
			{
				lbEmail.ForeColor = Color.Red;
				result = false;
			}
			return result;
		}
	}
}
