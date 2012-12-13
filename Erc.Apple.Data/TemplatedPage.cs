using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    [Serializable]
    public class TemplatedPage
    {
        protected string parentMenuItem;
        [XmlAttribute]
        public string ParentMenuItem
        {
            get
            {
                return parentMenuItem;
            }
            set
            {
                parentMenuItem = value;
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
        protected string url;
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
        protected string contentTemplate;
        public string ContentTemplate
        {
            get
            {
                return contentTemplate;
            }
            set
            {
                contentTemplate = value;
            }
        }

		protected string secondMenu;
		public string SecondMenu
		{
			get
			{
				return secondMenu;
			}
			set
			{
				secondMenu = value;
			}
		}

        private List<string> sideBarItems;

        public List<string> SideBarItems
        {
            get { return sideBarItems; }
            set { sideBarItems = value; }
        }

        public TemplatedPage()
        {

        }

    }

    
}

