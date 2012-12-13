/*using System;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
	[Serializable]
	public class SerialNumber
	{
		protected int id;
		protected int adminID;
		protected DateTime? createdDate;
		protected DateTime? modifiedDate;
		protected string number;
		protected int? serviceID;

		[XmlAttribute]
		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		[XmlAttribute]
		public string Number
		{
			get { return number; }
			set { number = value; }
		}

		[XmlAttribute]
		public int? ServiceID
		{
			get { return serviceID; }
			set { serviceID = value; }
		}

		[XmlAttribute]
		public int AdminID
		{
			get { return adminID; }
			set { adminID = value; }
		}

		[XmlAttribute]
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}

		[XmlAttribute]
		public DateTime? ModifiedDate
		{
			get { return modifiedDate; }
			set { modifiedDate = value; }
		}
	}
}*/