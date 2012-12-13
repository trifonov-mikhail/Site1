using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    [Serializable]
    public class SideBarItem
    {
        protected string id;
        [XmlAttribute]  
        public string ID
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
        protected TranslatableField titles;
        public TranslatableField Titles
        {
            get
            {
                return titles;
            }
            set
            {
                titles = value;
            }
        }
        protected string navigateUrl;
        public string NavigateUrl
        {
            get
            {
                return navigateUrl;
            }
            set
            {
                navigateUrl = value;
            }
        }
        protected string imageUrl;
        public string ImageUrl
        {
            get
            {
                return imageUrl;
            }
            set
            {
                imageUrl = value;
            }
        }
		protected string _ImageStyle;
		public string ImageStyle
		{
			get { return _ImageStyle; }
			set { _ImageStyle = value; }
		}
	
        public SideBarItem()
        {

        }

    }
}

