using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    [Serializable]
    public class SuccessStory
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