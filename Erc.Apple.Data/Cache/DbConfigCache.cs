using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data.Cache
{
    public class DbConfigCache
    {
        protected static readonly string CacheKey = "DbConfig";

        protected static Dictionary<string,DbConfigItem> GetAll()
        {
            Dictionary<string, DbConfigItem> all = new Dictionary<string, DbConfigItem>();

            object o = HttpContext.Current.Cache[CacheKey];

            if (o != null)
            {
                all = (Dictionary<string, DbConfigItem>)o;
            }
            else
            {
                foreach (DbConfigItem item in DbConfig.GetAll())
                {
                    all.Add(item.Name, item);
                }
                SqlCacheDependency dep = new SqlCacheDependency("SiteDB", "DbConfig");
                HttpContext.Current.Cache.Insert(CacheKey, all, dep);
            }
            return all;
        }

        public static DbConfigItem GetItem(string name)
        {
            DbConfigItem result = null;

            Dictionary<string, DbConfigItem> all = GetAll();

            if (all.ContainsKey(name))
                result = all[name];

            return result;
        }
        public static string GetItemValue(string name)
        {
            DbConfigItem item = GetItem(name);

            if (item != null && !string.IsNullOrEmpty(item.Value))
            {
                return item.Value;
            }

            return string.Empty;
        }

        public static void ClearCache()
        {
            HttpContext.Current.Cache.Remove(CacheKey);
        }
    }

}
