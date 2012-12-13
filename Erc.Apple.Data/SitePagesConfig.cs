using System;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    public class SitePagesConfig:XmlConfig<List<TemplatedPage>>
    {
        protected override string StorePath
        {
            get 
            {
                return "~/config/SitePages.config";
            }
        }

        public void AddPage(TemplatedPage page)
        {
            data.Add(page);
        }
        public List<TemplatedPage> GetAll()
        {
            Load();
            return base.data;
        }
    }
}
