using System;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Apple.Web.Admin.CSV;

namespace Apple.Web.Admin.Controls
{
    /// <summary>
    /// Summary description for CsvGenerator
    /// </summary>
    public class CsvFileGenerator : DataBoundControl
    {
        private ReportOptions options;

        public ReportOptions Options
        {
            get
            {
                if (options == null)
                    options = new ReportOptions();
                return options;
            }
        }

        public CsvFileGenerator()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override void PerformDataBinding(System.Collections.IEnumerable data)
        {
            if (data != null)
            {
                new CsvHelper().WriteToCSV(data, Options);
            }
        }
    }
}
