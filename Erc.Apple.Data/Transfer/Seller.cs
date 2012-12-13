using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
	[Serializable]
	public class Seller
	{
		[XmlAttribute]
		public int ID { get; set; }
		[XmlAttribute]
		public string Name { get; set; }
	}
}
