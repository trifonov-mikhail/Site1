using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Apple.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(ResolveCityByIp("83.169.8.217"));
			Console.ReadLine();
		}

		private static string ResolveCityByIp(string ip)
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
								//SerialNumberRepository snRepository = new SerialNumberRepository();
								//snRepository.InsertIpDatabase(ip, s);
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
	}
}
