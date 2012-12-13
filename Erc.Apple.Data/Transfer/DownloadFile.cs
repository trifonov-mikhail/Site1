using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erc.Apple.Data
{
    public class DownloadFile
    {
        public int ID { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}
