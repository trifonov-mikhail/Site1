using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    [Serializable]
    public class HomePageBlock
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
        protected string linkUrl;
        [XmlAttribute]
        public string LinkUrl
        {
            get
            {
                return linkUrl;
            }
            set
            {
                linkUrl = value;
            }
        }
        protected string linkText;
        [XmlAttribute]
        public string LinkText
        {
            get
            {
                return linkText;
            }
            set
            {
                linkText = value;
            }
        }
        protected byte[] imageFile;
        [XmlAttribute]
        public byte[] ImageFile
        {
            get
            {
                return imageFile;
            }
            set
            {
                imageFile = value;
            }
        }
        protected bool isActive;
        [XmlAttribute]
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;
            }
        }
        protected bool hasImage;
        [XmlAttribute]
        public bool HasImage
        {
            get
            {
                return hasImage;
            }
            set
            {
                hasImage = value;
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
        protected DateTime dateCreated;
        [XmlAttribute]
        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                dateCreated = value;
            }
        }
    }

}