using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Modules
{
	public class SendMailHelper
	{

		public static void SendEmail(string ToEmail, string FromEmail, string Subject, string Text, string displayName)
		{
			SendEmail(ToEmail, FromEmail, Subject, Text,displayName, false, string.Empty);
		}

		public static void SendEmail(string ToEmail, string FromEmail, string Subject, string Text, string displayName, bool isBodyHtml)
		{
			SendEmail(ToEmail, FromEmail, Subject, Text, displayName, isBodyHtml, string.Empty);
		}
		public static void SendEmail(string ToEmail, string FromEmail, string Subject, string Text, string displayName, bool isBodyHtml, string CCemail)
		{
			string text = Text;
			try
			{
				MailMessage message = new MailMessage();
				string toEmail = ToEmail;
				string subject = Subject;
				string fromEmail = FromEmail;
				if (!string.IsNullOrEmpty(toEmail))
				{
                    if (!string.IsNullOrEmpty(fromEmail))
                        message.From = new MailAddress(fromEmail, displayName);
					
                    message.To.Add(toEmail.Replace(" ", ""));
					if (!string.IsNullOrEmpty(CCemail))
					{
						message.CC.Add(CCemail);
					}
					message.Subject = subject;
					message.Body = text;
					message.IsBodyHtml = isBodyHtml;
					SmtpClient client = new SmtpClient();

					client.Send(message);

				}
			}
			catch (Exception e)
			{
				WriteLog(e.Message);
				throw;
			}
		}

#warning Need extract this method to single Log module.
		private static void WriteLog(string text)
		{
			if (!string.IsNullOrEmpty(WebConfigurationManager.AppSettings["isLogged"]) && WebConfigurationManager.AppSettings["isLogged"] == "true")
			{
				string file = HttpContext.Current.Server.MapPath("~/email.log");
				FileStream f = new FileStream(file, FileMode.Append);
				string testText = text;
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				byte[] bytes = encoding.GetBytes(testText);
				f.Write(bytes, 0, bytes.Length);
				f.Close();
			}
		}
	}
	
		
}
