using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
	[Serializable]
	public class iPadActionSerial
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
	}
}
