using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data.Repositories;
using Erc.Apple.Data.Models;
using Erc.Apple.Data;
using System.Net;
using System.IO;

namespace Apple.Web.Controls
{
	public partial class CheckSerialNumber : UserControlBase
	{
		protected const string CHECK_SERIALNUMBER_HEADER = "CheckSerialNumber";
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.Load += new EventHandler(Page_Load);
			//this.Page.Request.Url
		}

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
			if(Request["SNValue"] != null)
				number = Request["SNValue"].ToString();
			SerialNumber sn = snRepository.GetByNumber(number);
			string ip = Request.UserHostAddress;
			//http://api.ipinfodb.com/v3/ip-city/?key=5ebf5803d4420744d4253fc2db0f2f6c578eb151ff71a0416e8b6bdcdcabab86&ip=74.125.45.100
			string city = ResolveCityByIp(ip);

			// If you want it formated in some other way.
			var headers = String.Empty;
			foreach (var key in Request.Headers.AllKeys)
				headers += key + "=" + Request.Headers[key] + Environment.NewLine;
			try
			{
				snRepository.TrackSerialNumber(number, headers, Request.UserHostAddress, city);
			}
			catch (Exception)
			{
				
			}
			
			if (sn != null)
			{
				Erc.Apple.Data.Services services = new Erc.Apple.Data.Services();
				if (sn.ServiceID != null)
				{
					Erc.Apple.Data.Service service = services.GetByID(sn.ServiceID.Value);
					if (service != null)
						response.ServiceCenter = (string.IsNullOrEmpty(service.Name)) ? "<Unknown name>" : service.Name;
				}
				response.Message = "Serial number is valid.";
			}
			else
			{
				response.Message = "Invalid serial number.";
				response.IsValid = false;
			}
			return response;
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
					string.Format("ServiceCenter:\"{0}\"", ServiceCenter.ToString()) ) 
					+ "}";
			}
		}


	}
}