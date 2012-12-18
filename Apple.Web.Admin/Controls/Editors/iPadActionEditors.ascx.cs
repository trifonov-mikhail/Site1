using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using Erc.Apple.Data.Cache;
using Erc.Apple.Data;
using Erc.Apple.Data.Models;
using Erc.Apple.Data.Repositories;
using System.Globalization;
using Erc.Apple.Data.BussinesModels;
using Erc.Apple.Data.Cache;
using Erc.Apple.Data;
using System.Net.Mail;

namespace Apple.Web.Admin.Controls.Editors
{
	public partial class iPadActionEditors : UserControlBase
	{
		protected List<string> Serials = null;
		protected void Page_Load(object sender, EventArgs e)
		{
			csv.Options.FileName = "activation"+DateTime.Now.ToString("dd.MM.yyyy");
			csv.Options.HeaderText = "Серийный Номер,Дата покупки,Email,Место покупки,Статус";
			csv.Options.Columns = "Serial,BuyDateText,Email,SellerName,StatusText";
			csv.Options.Splitter = ";";
			
		}

		protected void GridViewItemsList_RowUpdated(object sender, GridViewUpdatedEventArgs e)
		{
			
			if (e.Exception == null )
			{
				
				string keyName = "ID";
				int id = (int)e.Keys[keyName];
				int statusid = int.Parse(e.NewValues["Status"].ToString());
				string email = e.OldValues["Email"].ToString();
				string Serial = e.OldValues["Serial"].ToString();
				Debug.WriteLine(string.Format("ID={0}, statusid={1}, email:{2}, Serial:{3}", id, statusid, email, Serial));
				try
				{
					SendEmail(id, statusid, email, Serial);
				}
				catch (Exception ex)
				{
					Debug.WriteLine("SendEmail:" + ex.ToString());
				}
			}
		}

		private static void SendEmail(int id, int statusid, string email, string serial)
		{
			MailDefinition md = new MailDefinition();
			md.BodyFileName = "~/MailTemplates/iPadAction_ChangeStatus.htm";

			Dictionary<string, string> d = new Dictionary<string, string>();
			string status = string.Empty;
			switch (statusid)
			{
				case 0:
					status = "На стадии проверки";
					break;

				case 1:
					status = "Дополнительная гарантия подтверждена";
					break;

				case 2:
					status = "Заявка на дополнительную гарантию отклонена. Чтобы уточнить причину отказа, свяжитесь с оператором по телефону 0 800 302 777 0";
					break;

				case 3:
					status = "Ошибка ввода данных. Пожалуйста, введите серийный номер еще раз или свяжитесь с оператором по телефону 0 800 302 777 0";
					break;
				default:
					break;
			}
			d.Add("<%Serial%>", serial);
			d.Add("<%Status%>", status);
			
			md.IsBodyHtml = true;

			ContactFormsCache forms = new ContactFormsCache();
			string formName = "iPadAction";

			ContactForm form = forms.GetByName(formName);

			if (form == null)
				throw new InvalidOperationException(string.Format("Can not find settings for form {0}", formName));

			string subject = form.Subject;
			string to = email;
			

			md.Subject = subject;

			MailMessage message = md.CreateMailMessage(to, d, new Label());
			


			SmtpClient sc = new SmtpClient();

			sc.Send(message);
		}

		protected void GridViewItemsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView gv = (GridView)sender;
			// Change the row state
			gv.Rows[e.NewEditIndex].RowState = DataControlRowState.Edit;

		}

	}
}