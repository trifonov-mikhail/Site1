using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Admin.CSV
{
    /// <summary>
    /// Summary description for ReportOptions
    /// </summary>
    public class ReportOptions
    {
        private string columns;

        public string Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private string columnsLengths;

        public string ColumnsLengths
        {
            get { return columnsLengths; }
            set { columnsLengths = value; }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string headerText;

        public string HeaderText
        {
            get { return headerText; }
            set { headerText = value; }
        }

        private string footerText;

        public string FooterText
        {
            get { return footerText; }
            set { footerText = value; }
        }
    }
}