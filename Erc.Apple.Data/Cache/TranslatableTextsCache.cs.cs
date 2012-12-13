using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data.Cache
{
    public class TranslatableTextsCache : Erc.Apple.Data.TranslatableTexts
    {
        protected static readonly string CacheKey = "TranslatableTexts";

        public override List<TranslatableText> GetAll()
        {
            List<TranslatableText> all = new List<TranslatableText>();

            object o = HttpContext.Current.Cache[CacheKey];

            if (o != null)
            {
                all = (List<TranslatableText>)o;
            }
            else
            {
                all = base.GetAll();
                SqlCacheDependency dep = new SqlCacheDependency("SiteDB", "TranslatableTexts");
                HttpContext.Current.Cache.Insert(CacheKey, all, dep);
            }
            return all;
        }

        public TranslatableText GetByIdAndLang(string id,string lang)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (lang ==null)
                throw new ArgumentNullException("lang");

            foreach (TranslatableText text in GetAll())
            {
                if (text.ID == id && text.LangCode == lang)
                    return text;
            }
            return null;
        }

        public static void ClearCache()
        {
            HttpContext.Current.Cache.Remove(CacheKey);
        }
    }

}
