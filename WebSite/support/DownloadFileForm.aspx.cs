using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data;
using Erc.Apple.Data.Cache;
using Erc.Apple.Data.BussinesModels;

namespace Apple.Web
{
    public partial class DownloadFileForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			phForm.Visible = true;
			phLink.Visible = false;
			
			
			if (!this.IsPostBack)
			{
				try
				{
					if (Session["email"] != null)
						txtEmail.Text = Session["email"].ToString();
					if (Session["firstname"] != null)
						txtFirstName.Text = Session["firstname"].ToString();
					if (Session["lastname"] != null)
						txtLastName.Text = Session["lastname"].ToString();
				}
				catch (Exception)
				{
					
				}
				
				Session["id"] = Request["id"];
			}
        }
        protected bool IsFormSubmitted = false;
        protected void imgSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                //IsFormSubmitted = true;
                try
                {
                    //SeminarRegistration sr = new SeminarRegistration
                    //{
                    //    CompanyName = txtCompanyName.Text,
                    //    Email = txtEmail.Text,
                    //    FIO = txtFio.Text,
                    //    JobAction = Convert.ToInt32(ddlFirmAction.SelectedValue),
                    //    JobTitle = txtJobTitle.Text,
                    //    TypeID = 1,
                    //    Site = txtSite.Text.ToLower().StartsWith("http://") ? txtSite.Text : "http://" + txtSite.Text
                    //};

                    //SeminarRegistrations.Add(sr);
            //        SendMail();
					
					try
					{
						Session["email"] = txtEmail.Text;
						Session["firstname"] = txtFirstName.Text;
						Session["lastname"] = txtLastName.Text;
					}
					catch (Exception)
					{
						
						throw;
					}
					int id = 0;
					if (Session["id"] != null && !string.IsNullOrEmpty(Session["id"].ToString()))
					{
						try
						{
							id = Int32.Parse(Session["id"].ToString());
						}
						catch (Exception)
						{
							id = -1;
						} 
					}
                    DownloadUserForm duf = new DownloadUserForm{Email=txtEmail.Text,
                                            FirstName = txtFirstName.Text,
                                            LastName = txtLastName.Text,
                                            FileID = id};

					DownloadUserForms manager = new DownloadUserForms();
					string urlGuid = manager.InsertForm(duf);

                    IsFormSubmitted = true;
					hlLink.NavigateUrl = "~/DownloadFile.aspx?guid=" + urlGuid;
					phForm.Visible = false;
					phLink.Visible = true;
					Session.Remove("id");
                }
                catch (Exception exc)
                {
                    IsFormSubmitted = false;
                    Logger.LogException(exc, "DownloadFileForm.ascx");
                    lbError.Visible = true;
                    lbError.ForeColor = Color.Red;
                    lbError.Text = "Произошла внутрення ошибка. Обратитесь к администратору.";
                }

            }
            else
            {
                lbError.Visible = true;
                lbError.ForeColor = Color.Red;
                lbError.Text = "Просьба заполните все поля";
            }
        }

		private string GetToBase64String(string str)
		{
			return Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(str));
		}

		private string GetFromBase64String(string str)
		{
			return System.Text.Encoding.Unicode.GetString(Convert.FromBase64String(str));
		}
		//private void SendMail()
		//{
		//    string company = txtCompanyName.Text;
		//    string email = txtEmail.Text;

		//    MailDefinition md = new MailDefinition();
		//    md.BodyFileName = "~/MailTemplates/SeminarRegistration.htm";

		//    Dictionary<string, string> d = new Dictionary<string, string>();

		//    string jobAction = "";
		//    switch (ddlFirmAction.SelectedValue)
		//    {
		//        case "1":
		//            jobAction = "Брендовая розница";
		//            break;
		//        case "2":
		//            jobAction = "Медийное агентство";
		//            break;
		//        case "3":
		//            jobAction = "Маркетинговое агентство";
		//            break;
		//        case "4":
		//            jobAction = "Туристическое агентство";
		//            break;
		//        case "5":
		//            jobAction = "Юридическая компания";
		//            break;
		//        case "6":
		//            jobAction = "Другие профессиональные услуги";
		//            break;
		//    }
		//    d.Add("<%Email%>", email);
		//    d.Add("<%JobAction%>", jobAction);
		//    d.Add("<%CompanyName%>", company);
		//    d.Add("<%Name%>", txtFio.Text);
		//    d.Add("<%JobTitle%>", txtJobTitle.Text);
		//    d.Add("<%Site%>", txtSite.Text);

		//    md.IsBodyHtml = true;

		//    ContactFormsCache forms = new ContactFormsCache();
		//    string formName = "SeminarRegistration";

		//    ContactForm form = forms.GetByName(formName);

		//    if (form == null)
		//        throw new InvalidOperationException(string.Format("Can not find settings for form {0}", formName));

		//    string subject = form.Subject;
		//    string to = form.To;
		//    string cc = form.CC;

		//    md.Subject = string.Format(subject, company);

		//    if (!string.IsNullOrEmpty(cc))
		//    {
		//        md.CC = cc;
		//    }

		//    MailMessage message = md.CreateMailMessage(to, d, this);

		//    SmtpClient sc = new SmtpClient();

		//    sc.Send(message);
		//}

        private bool IsValid()
        {
            lbEmail.ForeColor = Color.Black;
            lbFirstName.ForeColor = Color.Black;
            lbLastName.ForeColor = Color.Black;
            
            bool result = true;
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                result = false;
                lbFirstName.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                result = false;
                lbLastName.ForeColor = Color.Red;
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
