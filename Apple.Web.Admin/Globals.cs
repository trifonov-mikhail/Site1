using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Apple.Web.Admin
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
        
        public static string MenuItemTemplate
        {
            get
            {
                object o = Cache["MenuItemTemptate"];
                if (o != null)
                {
                    return (string)o;
                }
                else
                {
                    string fname = Server.MapPath("~/Templates/MenuItem.txt");
                    string template = File.ReadAllText(fname);
                    Cache.Insert("MenuItemTemptate", template, new CacheDependency(fname));
                    return template;
                }
            }
        }
    }
}
