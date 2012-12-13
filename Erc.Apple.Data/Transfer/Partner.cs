using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
	[Serializable]
	public class Partner
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
		protected string address;
		[XmlAttribute]
		public string Address
		{ 
			get
			{
				return address;
			}
			set
			{
				address = value;
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
		protected string telephone;
		[XmlAttribute]
		public string Telephone
		{
			get
			{
				return telephone;
			}
			set
			{
				telephone = value;
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
		protected int regionID;
		[XmlAttribute]
		public int RegionID
		{
			get
			{
				return regionID;
			}
			set
			{
				regionID = value;
			}
		}
		protected int partnerStatusID;
		[XmlAttribute]
		public int PartnerStatusID
		{
			get
			{
				return partnerStatusID;
			}
			set
			{
				partnerStatusID = value;
			}
		}
		protected int cityID;
		[XmlAttribute]
		public int CityID
		{
			get
			{
				return cityID;
			}
			set
			{
				cityID = value;
			}
		}

        protected string cityName;
        [XmlAttribute]
        public string CityName
        {
            get
            {
                return cityName;
            }
            set
            {
                cityName = value;
            }
        }
        protected string statusName;
        [XmlAttribute]
        public string StatusName
        {
            get
            {
                return statusName;
            }
            set
            {
                statusName = value;
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
        private bool publish;
        [XmlAttribute]
        public bool Publish
        {
            get { return publish; }
            set { publish = value; }
        }
	
	}

}