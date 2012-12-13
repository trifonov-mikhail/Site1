using System;
using System.Web;
using System.Web.Caching;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data.Cache
{
    public class ContactFormsCache : Erc.Apple.Data.ContactForms
    {
        protected static readonly string CacheKey = "ContactForms";

        public override List<ContactForm> GetAll()
        {
            List<ContactForm> all = new List<ContactForm>();

            object o = HttpContext.Current.Cache[CacheKey];

            if (o != null)
            {
                all = (List<ContactForm>)o;
            }
            else
            {
                all = base.GetAll();
                SqlCacheDependency dep = new SqlCacheDependency("SiteDB", "ContactForms");
                HttpContext.Current.Cache.Insert(CacheKey, all, dep);
            }
            return all;
        }

        public override ContactForm GetByID(int id)
        {
            ContactForm result = null;

            List<ContactForm> all = GetAll();

            foreach (ContactForm i in all)
            {
                if (i.ID == id)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public override ContactForm GetByName(string name)
        {
            ContactForm result = null;

            List<ContactForm> all = GetAll();

            foreach (ContactForm i in all)
            {
                if (i.Name.ToLower() == name.ToLower())
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public static void ClearCache()
        {
            HttpContext.Current.Cache.Remove(CacheKey);
        }
    }

}
