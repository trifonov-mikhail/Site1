using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
	[Serializable]
	public class Product
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
		protected int categoryID;
		[XmlAttribute]
		public int CategoryID
		{ 
			get
			{
				return categoryID;
			}
			set
			{
				categoryID = value;
			}
		}
		protected int orderNumber;
		[XmlAttribute]
		public int OrderNumber
		{ 
			get
			{
				return orderNumber;
			}
			set
			{
				orderNumber = value;
			}
		}

		protected int groupId;
		[XmlAttribute]
		public int GroupID
		{
			get
			{
				return groupId;
			}
			set
			{
				groupId = value;
			}
		}

		protected byte[] image;
		[XmlAttribute]
		public byte[] Image
		{
			get
			{
				return image;
			}
			set
			{
				image = value;
			}
		}

		protected string imageName;
		[XmlAttribute]
		public string ImageName
		{
			get
			{
				return imageName;
			}
			set
			{
				imageName = value;
			}
		}

		protected string imageType;
		[XmlAttribute]
		public string ImageType
		{
			get
			{
				return imageType;
			}
			set
			{
				imageType = value;
			}
		}

		protected string url;
		[XmlAttribute]
		public string Url
		{
			get
			{
				return url;
			}
			set
			{
				url = value;
			}
		}


		protected int imageLenght;
		[XmlAttribute]
		public int ImageLenght
		{
			get
			{
				return imageLenght;
			}
			set
			{
				imageLenght = value;
			}
		}



	}

}