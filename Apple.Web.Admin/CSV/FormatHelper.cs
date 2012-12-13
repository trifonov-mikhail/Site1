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
    /// Summary description for FormatHelper
    /// </summary>
    public static class FormatHelper
    {
        public static string GetFormat(Type type)
        {
            string format = "{0}";
            switch (type.Name)
            {
                case "DateTime":
                    format = "{0:dd MMMM yyyy}";
                    break;
                case "Decimal":
                    format = "{0:0.00}";
                    break;
            }
            return format;
        }
    }
}