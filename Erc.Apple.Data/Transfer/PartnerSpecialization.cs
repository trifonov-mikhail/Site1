using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
	[Serializable]
	public class PartnerSpecialization
	{
		protected int id;
		[XmlAttribute]
		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		protected int partnerId;
		[XmlAttribute]
		public int PartnerID
		{
			get
			{
				return partnerId;
			}
			set
			{
				partnerId = value;
			}
		}

		protected int specializationID;
		[XmlAttribute]
		public int SpecializationID
		{
			get
			{
				return specializationID;
			}
			set
			{
				specializationID = value;
			}
		}
	}
}
