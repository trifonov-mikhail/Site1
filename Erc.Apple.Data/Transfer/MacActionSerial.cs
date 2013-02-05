using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
	[Serializable]
	public class MacActionSerial
	{
		[XmlAttribute]
		public int ID { get; set; }
		
		[XmlAttribute]
		public string Serial { get; set; }


		[XmlAttribute]
		public string Email { get; set; }
		
		[XmlAttribute]
		public DateTime BuyDate { get; set; }

		[XmlAttribute]
		public int Seller { get; set; }

		[XmlAttribute]
		public int Status { get; set; }
		
		[XmlAttribute]
		public string SellerName { get; set; }

		public string BuyDateText
		{
			get {
				return BuyDate.ToString("dd.MM.yyyy");
			}
		}

		public string StatusText
		{
			get
			{
				switch (Status)
				{
					case 0:
						return "В стадии проверки";
					case 1:
						return "Гарантия подтверждена";
					case 2:
						return "Гарантия отклонена";
					case 3:
						return "Ошибка ввода данных";
					default:
						return "не известно";
						break;
				}
			}
		}
	}
}
