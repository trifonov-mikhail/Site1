using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data.Cache
{
    public class AdminPagesCache : Erc.Apple.Data.AdminPages
    {
        protected static readonly string CacheKey = "AdminPages";

        public override List<AdminPage> GetAll()
        {
            List<AdminPage> all = new List<AdminPage>();

            object o = HttpContext.Current.Cache[CacheKey];

            if (o != null)
            {
                all = (List<AdminPage>)o;
            }
            else
            {
                all = base.GetAll();
                SqlCacheDependency dep = new SqlCacheDependency("SiteDB", "AdminPages");
                HttpContext.Current.Cache.Insert(CacheKey, all, dep);
            }
            return all;
        }

        public static void ClearCache()
        {
            HttpContext.Current.Cache.Remove(CacheKey);
        }
    }

}
