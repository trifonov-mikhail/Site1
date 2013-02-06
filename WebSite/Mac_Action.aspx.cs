using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Erc.Apple.Data.Models;
using Erc.Apple.Data.Repositories;
using System.Globalization;
using Erc.Apple.Data.BussinesModels;
using Erc.Apple.Data.Cache;
using Erc.Apple.Data;
using System.Net.Mail;
using System.Diagnostics;

namespace Apple.Web
{
    public partial class Mac_Action : PageBase
	{
		protected const string CHECK_SERIALNUMBER_HEADER = "CheckSerialNumberMacAction";
		private void Page_Load(object sender, EventArgs e)
		{
			HandleAjaxCheckSerialNumberRequest();
		}

		private void HandleAjaxCheckSerialNumberRequest()
		{
			if (Request.Headers[CHECK_SERIALNUMBER_HEADER] != null)
			{
				CheckCheckSerialNumberResponse response = DoCheckSerialNumber();
				Response.Write(response.ToString());
				Response.End();
			}
		}
		private CheckCheckSerialNumberResponse DoCheckSerialNumber()
		{
			CheckCheckSerialNumberResponse response = new CheckCheckSerialNumberResponse();
			SerialNumberRepository snRepository = new SerialNumberRepository();
			string number = string.Empty;
			if (Request["SNValue"] != null)
				number = Request["SNValue"].ToString().ToUpperInvariant();

			string BuyDate = string.Empty;
			if (Request["BuyDate"] != null)
				BuyDate = Request["BuyDate"].ToString();

			string Email = string.Empty;
			if (Request["Email"] != null)
				Email = Request["Email"].ToString();

			int seller = 0;
			try
			{
				if (Request["Seller"] != null)
					seller = int.Parse(Request["Seller"].ToString());
			}
			catch (Exception)
			{
				response.IsValid = false;
				response.Message = "invalid seller";
				return response;
			}
			if (string.IsNullOrEmpty(Email.Trim()))
			{
				response.IsValid = false;
				response.Message = "invalid email";
				return response;
			}
			if (seller == 0)
			{
				response.IsValid = false;
				response.Message = "invalid seller";
				return response;
			}
			List<string> list = (new MacActionSerials()).GetSerialNumbers();
			if (list.Contains(number))
			{
				response.IsValid = false;
				response.Message = "duplicate number";
				return response;
			}

			DateTime buydate = DateTime.MinValue;
			if(!DateTime.TryParseExact(BuyDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out buydate))
			{
				response.Message = "invalid date";
				response.IsValid = false;
				return response;
			}

			if (buydate < new DateTime(2013, 02, 8) || buydate > new DateTime(2013, 3, 10))
			{
				response.IsValid = false;
				response.Message = "invalid daterange";
				return response;
			}



			ResolveCity();

            MacActionSerials rep = new MacActionSerials();
			var item = new MacActionSerial { Serial = number, BuyDate = buydate, Email = Email, Seller = seller, SellerName= Sellers.FirstOrDefault(s=>s.ID==seller).Name };

			
			try
			{
				item.ID = rep.Add(item);

				SendMail(item);
				SendEmail(item.ID, item.Status, item.Email, item.Serial);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("MacAction: " + ex.ToString());
			}
			

			return response;



		}
		private static void SendEmail(int id, int statusid, string email, string serial)
		{
			MailDefinition md = new MailDefinition();
			md.BodyFileName = "~/MailTemplates/MacAction_ChangeStatus.htm";

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
			string formName = "MacAction";

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
        private void SendMail(MacActionSerial item)
		{
			
			MailDefinition md = new MailDefinition();
			md.BodyFileName = "~/MailTemplates/request_MacAction.htm";

			Dictionary<string, string> d = new Dictionary<string, string>();

			d.Add("<%Serial%>", item.Serial);
			d.Add("<%BuyDate%>", item.BuyDate.ToShortDateString());
			d.Add("<%Email%>", item.Email);
			d.Add("<%Seller%>", item.SellerName);
			
			md.IsBodyHtml = true;

			ContactFormsCache forms = new ContactFormsCache();
			string formName = string.Format("Request_{0}", Apple.Web.Controls.RequestStatusForm.StatusType.MacAction);

			ContactForm form = forms.GetByName(formName);

			if (form == null)
				throw new InvalidOperationException(string.Format("Can not find settings for form {0}", formName));

			string subject = form.Subject;
			string to = form.To;
			string cc = form.CC;

			md.Subject = subject;

			if (!string.IsNullOrEmpty(cc))
			{
				md.CC = cc;
			}

			MailMessage message = md.CreateMailMessage(to, d, this);
			

			SmtpClient sc = new SmtpClient();

			sc.Send(message);
		}

		private void ResolveCity()
		{
			string ip = Request.UserHostAddress;
			//http://api.ipinfodb.com/v3/ip-city/?key=5ebf5803d4420744d4253fc2db0f2f6c578eb151ff71a0416e8b6bdcdcabab86&ip=74.125.45.100
			string city = ResolveCityByIp(ip);
		}

		private string ResolveCityByIp(string ip)
		{
			try
			{
				using (WebClient client = new WebClient())
				{
					client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
					string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key=5ebf5803d4420744d4253fc2db0f2f6c578eb151ff71a0416e8b6bdcdcabab86&ip={0}", ip);
					List<string> parameters = new List<string>();
					using (Stream data = client.OpenRead(url))
					{
						using (StreamReader reader = new StreamReader(data))
						{
							string s = reader.ReadToEnd();
							parameters.AddRange(s.Split(';'));
							data.Close();
							reader.Close();
							try
							{
								SerialNumberRepository snRepository = new SerialNumberRepository();
								snRepository.InsertIpDatabase(ip, s);
							}
							catch (Exception)
							{

							}
						}
					}
					//OK;;74.125.45.100;US;UNITED STATES;CALIFORNIA;MOUNTAIN VIEW;94043;37.3861;-122.084;-08:00
					//OK;;85.223.209.2;UA;UKRAINE;KYYIV;KIEV;-;50.4547;30.5238;+02:00

					return parameters.Count < 7 ? "" : parameters[6];
				}
			}
			catch (Exception)
			{

				return string.Empty;
			}

		}

		public class CheckCheckSerialNumberResponse
		{
			private string _message = string.Empty;
			private bool _isValid = true;
			private string _serviceCenter = string.Empty;

			public bool IsValid
			{
				get { return _isValid; }
				set { _isValid = value; }
			}

			public string Message
			{
				get { return _message; }
				set { _message = value; }
			}

			public string ServiceCenter
			{
				get { return _serviceCenter; }
				set { _serviceCenter = value; }
			}

			public override string ToString()
			{
				return "{" +
					string.Format("{0},{1},{2}", string.Format("Message:\"{0}\"", Message),
					string.Format("IsValid:\"{0}\"", IsValid.ToString()),
					string.Format("ServiceCenter:\"{0}\"", ServiceCenter.ToString()))
					+ "}";
			}
		}
		private List<Seller> m_seller = null;
		protected List<Seller> Sellers
		{
			get
			{
				if (m_seller == null)
				{
                    var list = Erc.Apple.Data.BussinesModels.Sellers.GetMacAll().OrderBy(s => s.Name);
					m_seller = new List<Seller>();
					m_seller.Add(new Seller { ID = 0, Name = "Выбрать" });
					m_seller.AddRange(list);
				}
				return m_seller;
			}
		}
	}
}