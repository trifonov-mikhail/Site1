using System;
using System.Data.Common;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    [Serializable]
    public class DevelopersLink
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
        public DevelopersLink()
        {
        }
        public DevelopersLink(DbDataReader r)
        {
            ID = Convert.ToInt32(r["ID"]);
            GroupID = Convert.ToInt32(r["GroupID"]);
            LangCode = Convert.ToString(r["LangCode"]);
            Text = Convert.ToString(r["Text"]);
            LinkUrl = Convert.ToString(r["LinkUrl"]);
            LinkText = Convert.ToString(r["LinkText"]);
            OrderNumber = Convert.ToInt32(r["OrderNumber"]);
            DateCreated = Convert.ToDateTime(r["DateCreated"]);
        }
    }

}