using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data.Cache
{
    public class LanguagesCache : Erc.Apple.Data.Languages
    {
        protected static readonly string CacheKey = "Languages";

        public override List<Language> GetAll()
        {
            List<Language> all = new List<Language>();

            object o = HttpContext.Current.Cache[CacheKey];

            if (o != null)
            {
                all = (List<Language>)o;
            }
            else
            {
                all = base.GetAll();
                SqlCacheDependency dep = new SqlCacheDependency("SiteDB", "Languages");
                HttpContext.Current.Cache.Insert(CacheKey, all, dep);
            }
            return all;
        }

        public override Language GetByCode(string code)
        {
            if (code == null)
                throw new ArgumentNullException("code");

            foreach (Language lang in GetAll())
            {
                if (lang.Code == code)
                    return lang;
            }
            return null;
        }

        public static void ClearCache()
        {
            HttpContext.Current.Cache.Remove(CacheKey);
        }
    }

}
