using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
	[Serializable]
	public class Specialization
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
		protected string name;
		[XmlAttribute]
		public string Name
		{ 
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		protected string langCode;
		[XmlAttribute]
		public string LangCode
		{ 
			get
			{
				return langCode;
			}
			set
			{
				langCode = value;
			}
		}
		protected string description;
		[XmlAttribute]
		public string Description
		{ 
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}
		protected int groupID;
		[XmlAttribute]
		public int GroupID
		{
			get
			{
				return groupID;
			}
			set
			{
				groupID = value;
			}
		}
	}

}