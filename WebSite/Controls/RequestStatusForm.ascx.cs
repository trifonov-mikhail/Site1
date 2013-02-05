using System;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Net;
using System.Net.Mail;

using Erc.Apple.Data;
using Erc.Apple.Data.Cache;

namespace Apple.Web.Controls
{
    public partial class RequestStatusForm : UserControlBase
    {
        public enum StatusType
        {
            LAR,
            AASP,
            ACP,
			iPadAction,
            MacAction
        }

        private StatusType status;

        public StatusType Status
        {
            get { return status; }
            set { status = value; }
        }

        private StatusRequests requests;

        public StatusRequests Requests
        {
            get 
            {
                if (requests == null)
                    requests = new StatusRequests();
                return requests; 
            }
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imgStatus.ImageUrl; }
            set { imgStatus.ImageUrl = value; }
        }
                    

        protected void Page_Load(object sender, EventArgs e)
        {
            phForm.Visible = true;
            phThankYou.Visible = false;
            lblError.Visible = false;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ImageUrl = GetStatusImageUrl(this.Status);
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    SaveRequest();
                    SendMail();

                    phForm.Visible = false;
                    phThankYou.Visible = true;
                }
                catch(Exception exc) 
                {
                    Logger.LogException(exc, "RequestStatusForm.ascx");
                    lblError.Visible = true;
                }
            }
        }

        public bool ShowSubMenu()
        {
            return this.Status != StatusType.LAR;
        }

        private void SaveRequest()
        {
            string company = txtCompanyName.Text;
            string contact = txtContactName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            bool isPartner = rbIsPartner.Checked;
            bool isServicePartner = rbIsServicePartner.Checked;
            string status = this.Status.ToString();

            StatusRequest r = new StatusRequest();

            r.Status = status;
            r.CompanyName = company;
            r.ContactName = contact;
            r.Address = address;
            r.Phone = phone;
            r.Email = email;
            r.IsPartner = isPartner;
            r.IsServicePartner = isServicePartner;

            Requests.Add(r);
        }

        private void SendMail()
        {
            string company = txtCompanyName.Text;
            string contact = txtContactName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            bool isPartner = rbIsPartner.Checked;
            bool isServicePartner = rbIsServicePartner.Checked;
            string status = this.Status.ToString();

            MailDefinition md = new MailDefinition();
            md.BodyFileName = "~/MailTemplates/StatusRequest.htm";

            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("<%Status%>", status);
            d.Add("<%CompanyName%>", company);
            d.Add("<%ContactName%>", contact);
            d.Add("<%Address%>", address);
            d.Add("<%Phone%>", phone);
            d.Add("<%Email%>", email);
            d.Add("<%IsPartner%>", isPartner ? "yes" : "no");
            d.Add("<%IsServicePartner%>", isServicePartner ? "yes" : "no");

            md.IsBodyHtml = true;

            ContactFormsCache forms = new ContactFormsCache();
            string formName = string.Format("Request_{0}",Status);

            ContactForm form = forms.GetByName(formName);

            if (form == null)
                throw new InvalidOperationException(string.Format("Can not find settings for form {0}", formName));

            string subject = form.Subject;
            string to = form.To;
            string cc = form.CC;

            md.Subject = string.Format(subject, company);

            if (!string.IsNullOrEmpty(cc))
            {
                md.CC = cc;
            }

            MailMessage message = md.CreateMailMessage(to, d, this);

            SmtpClient sc = new SmtpClient();

            sc.Send(message);
        }

        private bool IsValid()
        {
            bool result = true;

            lbCompanyName.ForeColor = Color.Black;
            lbAddress.ForeColor = Color.Black;
            lbContactName.ForeColor = Color.Black;
            lbEmail.ForeColor = Color.Black;
            lbPhone.ForeColor = Color.Black;

            if (txtCompanyName.Text.Trim().Length == 0)
            {
                result = false;
                lbCompanyName.ForeColor = Color.Red;
            }
            if (txtAddress.Text.Trim().Length == 0)
            {
                result = false;

                lbAddress.ForeColor = Color.Red;
            }
            if (txtContactName.Text.Trim().Length == 0)
            {
                result = false;
                lbContactName.ForeColor = Color.Red;
            }
            if (txtEmail.Text.Trim().Length == 0)
            {
                result = false;
                lbEmail.ForeColor = Color.Red;
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                result = false;
                lbPhone.ForeColor = Color.Red;
            }

            if (!Globals.CheckEmail(txtEmail.Text))
            {
                lbEmail.ForeColor = Color.Red;
                result = false;
            }

            return result;
        }


        public string GetStatusImageUrl(StatusType type)
        {
            switch (type)
            {
                case StatusType.LAR:
                    return "~/images/LimitedAuthorisedReseller.gif";
                    break;
                case StatusType.AASP:
                    return "~/images/AuthorisedServiceProvider.gif";
                    break;
                case StatusType.ACP:
                    return "~/images/AuthorisedCollectionPoint.gif";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}