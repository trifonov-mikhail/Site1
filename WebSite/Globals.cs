using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;
using Erc.Apple.Data.Cache;

namespace Apple.Web
{
    public static class Globals
    {
        private static Cache Cache
        {
            get
            {
                return HttpContext.Current.Cache;
            }
        }
        private static HttpServerUtility Server
        {
            get
            {
                return HttpContext.Current.Server;
            }
        }
        private static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
        public static string CurrentLanguage
        {
            get
            {
                string lang = "ru";
				object o = Session["CurrentLanguage"];
                if (o != null)
                {
                    lang = o.ToString();
                }
                return lang;
            }
            set
            {
                Session["CurrentLanguage"] = value;
            }
        }

        public static TemplatedPage CurrentTemplatedPage
        {
            get
            {
                return HttpContext.Current.Items["CurrentTemplatePage"] as TemplatedPage;
            }
            set
            {
                HttpContext.Current.Items["CurrentTemplatePage"] = value;
            }
        }

        public static string OriginalPath
        {
            get
            {
                return (string)HttpContext.Current.Items["OriginalPath"];
            }
            set
            {
                HttpContext.Current.Items["OriginalPath"] = value;
            }
        }

        private static readonly SitePagesConfig sitePagesConfig = new SitePagesConfig();
        public static List<TemplatedPage> TemplatedPages
        {
            get
            {
                return sitePagesConfig.GetAll();
            }
        }

        public static bool CheckEmail(string input)
        {

            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
     + @"([a-zA-Z]*[\w-]+\.)+[a-zA-Z]{2,4})$");

        }
        public static string TranslatableText(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("string id can not be empty");
            }
            TranslatableTextsCache cache = new TranslatableTextsCache();

            TranslatableText text = cache.GetByIdAndLang(id, CurrentLanguage);
            if (text != null)
            {
                return text.Text;
            }

            return string.Empty;
        }
    }
}
