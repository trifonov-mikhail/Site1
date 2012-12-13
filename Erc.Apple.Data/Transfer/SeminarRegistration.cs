using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Data.Common;

namespace Erc.Apple.Data
{
    [Serializable]
    public class SeminarRegistration
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public string FIO { get; set; }
        [XmlAttribute]
        public string CompanyName { get; set; }
        [XmlAttribute]
        public string JobTitle { get; set; }
        [XmlAttribute]
        public int JobAction { get; set; }
        [XmlAttribute]
        public string Email { get; set; }
        [XmlAttribute]
        public DateTime DateCreated { get; set; }
        [XmlAttribute]
        public int TypeID { get; set; }
        [XmlAttribute]
        public int SentEmailType { get; set; }
        [XmlAttribute]
        public DateTime EmailSent { get; set; }
        [XmlAttribute]
        public string Site { get; set; }

        public string TypeString
        {
            get
            {
                switch (JobAction)
                {
                    case 1:
                        return "Брендовая розница";
                    case 2:
                        return "Медийное агентство";
                    case 3:
                        return "Маркетинговое агентство";
                    case 4:
                        return "Туристическое агентство";
                    case 5:
                        return "Юридическая компания";
                    case 6:
                        return "Другие профессиональные услуги";
                    case 7:
                        return "Торговая компания";
                }
                return "Не установленно";
            }
        }

        public SeminarRegistration()
        {
            
        }

        public SeminarRegistration(DbDataReader r)
        {
            ID = Convert.ToInt32(r["ID"]);
            CompanyName = Convert.ToString(r["CompanyName"]);
            FIO = Convert.ToString(r["FIO"]);
            JobTitle = Convert.ToString(r["JobTitle"]);
            JobAction = Convert.ToInt32(r["JobAction"]);
            Email = Convert.ToString(r["Email"]);
            Site = r["Site"] != DBNull.Value ? Convert.ToString(r["Site"]) : string.Empty;
            DateCreated = Convert.ToDateTime(r["DateCreated"]);
            TypeID = Convert.ToInt32(r["TypeID"]);
            SentEmailType = Convert.ToInt32(r["SentEmailType"]);
            EmailSent = r["EmailSent"] != DBNull.Value ? Convert.ToDateTime(r["EmailSent"]) : DateTime.MinValue;
        }
    }
}
