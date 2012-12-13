using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{
	[Serializable]
	public class ServiceSpecialization
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

		protected int serviceID;
		[XmlAttribute]
		public int ServiceID
		{
			get
			{
				return serviceID;
			}
			set
			{
				serviceID = value;
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
