using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    [Serializable]
    public class Story
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
        protected DateTime? date;
        [XmlAttribute]
        public DateTime? Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        protected string title;
        [XmlAttribute]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        protected string notice;
        [XmlAttribute]
        public string Notice
        {
            get
            {
                return notice;
            }
            set
            {
                notice = value;
            }
        }
        protected string text;
        [XmlAttribute]
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
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
        protected string link2Url;
        [XmlAttribute]
        public string Link2Url
        {
            get
            {
                return link2Url;
            }
            set
            {
                link2Url = value;
            }
        }
        protected string link2Text;
        [XmlAttribute]
        public string Link2Text
        {
            get
            {
                return link2Text;
            }
            set
            {
                link2Text = value;
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
        protected int imagePosition;
        [XmlAttribute]
        public int ImagePosition
        {
            get
            {
                return imagePosition;
            }
            set
            {
                imagePosition = value;
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
        protected byte[] pdfFile;
        [XmlAttribute]
        public byte[] PdfFile
        {
            get
            {
                return pdfFile;
            }
            set
            {
                pdfFile = value;
            }
        }
        protected bool haspdfFile;
        [XmlAttribute]
        public bool HasPdfFile
        {
            get
            {
                return haspdfFile;
            }
            set
            {
                haspdfFile = value;
            }
        }

        [XmlAttribute]
        public string PdfFileName
        {
            get;
            set;
        }
    }

}