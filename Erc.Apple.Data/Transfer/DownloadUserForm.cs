using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Erc.Apple.Data
{

    [Serializable]
    public class DownloadUserForm
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public string FirstName { get; set; }
        [XmlAttribute]
        public string LastName { get; set; }
        [XmlAttribute]
        public string Email { get; set; }
        [XmlAttribute]
        public int FileID { get; set; }
		[XmlAttribute]
		public string Url { get; set; }
	}
}
