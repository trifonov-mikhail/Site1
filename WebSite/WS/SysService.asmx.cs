using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using AjaxControlToolkit;
using Erc.Apple.Data;

namespace Apple.Web.WS
{
    /// <summary>
    /// Summary description for SysService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService()]
    public class SysService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public CascadingDropDownNameValue[] GetProducts(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            try
            {
                List<Product> all = new Products().GetAllByLanguage(Globals.CurrentLanguage);
                if (all.Count == 0)
                    return null;
                foreach (Product p in all)
                {
                    values.Add(new CascadingDropDownNameValue(p.Name, p.GroupID.ToString()));
                }
            }
            catch { }
            return values.ToArray();
        }
        [WebMethod(EnableSession = true)]
        public CascadingDropDownNameValue[] GetSpecializations(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            try
            {
                List<Specialization> all = new Specializations().GetAllByLanguage(Globals.CurrentLanguage);
                if (all.Count == 0)
                    return null;
                foreach (Specialization s in all)
                {
                    values.Add(new CascadingDropDownNameValue(s.Name, s.GroupID.ToString()));
                }
            }
            catch { }
            return values.ToArray();
        }

        [WebMethod(EnableSession = true)]
        public CascadingDropDownNameValue[] GetRegions(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            try
            {
                List<Region> regions = new Regions().GetAllByLanguage(Globals.CurrentLanguage);
                if (regions.Count == 0)
                    return null;
                foreach (Region r in regions)
                {
                    values.Add(new CascadingDropDownNameValue(r.Name, r.GroupID.ToString()));
                }
            }
            catch { }
            return values.ToArray();
        }

        [WebMethod(EnableSession = true)]
        public CascadingDropDownNameValue[] GetCities(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int id;
            if (!kv.ContainsKey("Region") ||
                !Int32.TryParse(kv["Region"], out id))
            {
                return null;
            }
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            try
            {
                List<City> all = (new Cities()).GetAllByLanguageAndRegion(Globals.CurrentLanguage, id);

                foreach (City c in all)
                {
                    values.Add(new CascadingDropDownNameValue(c.Name, c.GroupID.ToString()));
                }
            }
            catch { }
            return values.ToArray();
        }
        [WebMethod]
        public bool AddNewsSubscriber(string name, string email)
        {
            bool result = false;

            try
            {
                NewsSubscribers dao = new NewsSubscribers();
                NewsSubscriber item = new NewsSubscriber();
                item.Name = name;
                item.Email = email;
                dao.Add(item);
                result = true;
            }
            catch { }

            return result;
        }
        [WebMethod]
        public string GetNewsText(int id)
        {
            string result = string.Empty;

            try
            {
                News dao = new News();
                NewsItem item = dao.GetByID(id);
                if (item != null && !string.IsNullOrEmpty(item.Text))
                {
                    result = item.Text;
                }
            }
            catch { }

            return result;
        }
        [WebMethod]
        public NewsItem GetNews(int id)
        {
            NewsItem item =null;

            try
            {
                News dao = new News();
                item = dao.GetByID(id);
            }
            catch { }

            return item;
        }
    }
}
