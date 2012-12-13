using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
	[Serializable]
	public class Feedback
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
		protected string firstname;
		[XmlAttribute]
		public string FirstName
		{ 
			get
			{
				return firstname;
			}
			set
			{
				firstname = value;
			}
		}
		protected string lastname;
		[XmlAttribute]
		public string LastName
		{
			get
			{
				return lastname;
			}
			set
			{
				lastname = value;
			}
		}

		protected string tel;
		[XmlAttribute]
		public string Telephone
		{
			get
			{
				return tel;
			}
			set
			{
				tel = value;
			}
		}

		protected string email;
		[XmlAttribute]
		public string EMail
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

		protected string company;
		[XmlAttribute]
		public string Company
		{
			get
			{
				return company;
			}
			set
			{
				company = value;
			}
		}

		protected string position;
		[XmlAttribute]
		public string Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
			}
		}

		protected string comment;
		[XmlAttribute]
		public string Comment
		{
			get
			{
				return comment;
			}
			set
			{
				comment = value;
			}
		}

		protected string userInfo;
		[XmlAttribute]
		public string UserInfo
		{
			get
			{
				return userInfo;
			}
			set
			{
				userInfo = value;
			}
		}
		
	}

}