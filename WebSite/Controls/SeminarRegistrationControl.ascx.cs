using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Erc.Apple.Data;
using Erc.Apple.Data.Cache;
using Erc.Apple.Data;

namespace Apple.Web.Controls
{
    public partial class SeminarRegistrationControl : UserControlBase
    {
        private SeminarRegistrations requests;

        public SeminarRegistrations SeminarRegistrations
        {
            get
            {
                if (requests == null)
                    requests = new SeminarRegistrations();
                return requests;
            }
        }
        protected bool IsFormSubmitted = false;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lbError.Visible = false;
        }

        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                //IsFormSubmitted = true;
                try
                {
                    SeminarRegistration sr = new SeminarRegistration{
                        CompanyName = txtCompanyName.Text,
                        Email = txtEmail.Text, 
                        FIO = txtFio.Text, 
                        JobAction = Convert.ToInt32(ddlFirmAction.SelectedValue),
                        JobTitle = txtJobTitle.Text,
                        TypeID = 1,
                        Site = txtSite.Text.ToLower().StartsWith("http://") ? txtSite.Text : "http://"+txtSite.Text
                    };

                    SeminarRegistrations.Add(sr);
                    SendMail();
                    IsFormSubmitted = true;
                }
                catch (Exception exc)
                {
                    IsFormSubmitted = false;
                    Logger.LogException(exc, "SeminarRegistrationControl.ascx");
                    lbError.Visible = true;
                    lbError.ForeColor = Color.Red;
                    lbError.Text = "Произошла внутрення ошибка. Обратитесь к администратору.";
                }

            }else
            {
                lbError.Visible = true;
                lbError.ForeColor = Color.Red;
                lbError.Text = "Просьба заполните все поля";
            }
        }
        private void SendMail()
        {
            string company = txtCompanyName.Text;
            string email = txtEmail.Text;

            MailDefinition md = new MailDefinition();
            md.BodyFileName = "~/MailTemplates/SeminarRegistration.htm";

            Dictionary<string, string> d = new Dictionary<string, string>();

            string jobAction = "";
            switch (ddlFirmAction.SelectedValue)
            {
                case "1":
                    jobAction = "Брендовая розница";
                    break;
                case "2":
                    jobAction = "Медийное агентство";
                    break;
                case "3":
                    jobAction = "Маркетинговое агентство";
                    break;
                case "4":
                    jobAction = "Туристическое агентство";
                    break;
                case "5":
                    jobAction = "Юридическая компания";
                    break;
                case "6":
                    jobAction = "Другие профессиональные услуги";
                    break;
            }
            d.Add("<%Email%>", email);
            d.Add("<%JobAction%>", jobAction);
            d.Add("<%CompanyName%>", company);
            d.Add("<%Name%>", txtFio.Text);
            d.Add("<%JobTitle%>", txtJobTitle.Text);
            d.Add("<%Site%>", txtSite.Text);

            md.IsBodyHtml = true;

            ContactFormsCache forms = new ContactFormsCache();
            string formName = "SeminarRegistration";

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
            lbJobTitle.ForeColor = Color.Black;
            lbFirmAction.ForeColor = Color.Black;
            lbFIO.ForeColor = Color.Black;
            lbEmail.ForeColor = Color.Black;
            lbCompanyName.ForeColor = Color.Black;

            bool result = true;
            if (string.IsNullOrEmpty(txtJobTitle.Text))
            {
                result = false;
                lbJobTitle.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(txtFio.Text))
            {
                result = false;
                lbFIO.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                result = false;
                lbCompanyName.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                result = false;
                lbEmail.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(txtSite.Text))
            {
                result = false;
                lbSite.ForeColor = Color.Red;
            }

            if (!Globals.CheckEmail(txtEmail.Text))
            {
                lbEmail.ForeColor = Color.Red;
                result = false;
            }
            
            return result;
        }
    }
}