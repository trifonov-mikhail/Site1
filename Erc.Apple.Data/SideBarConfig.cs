using System;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    public class SideBarConfig : XmlConfig<List<SideBarItem>>
    {
        protected override string StorePath
        {
            get 
            {
                return "~/config/SideBar.config";
            }
        }

        public void Add(SideBarItem item)
        {
            data.Add(item);
        }
        public List<SideBarItem> GetAll()
        {
            Load();
            return base.data;
        }
        public List<SideBarItem> GetByNames(List<string> names)
        {
            Load();
            List<SideBarItem> result = new List<SideBarItem>();

            if (names != null)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    foreach (SideBarItem item in data)
                    {
                        if (names[i].Contains(item.ID))
                        {
                            result.Add(item);
                        }
                    }
                }
                
            }
            return result;
        }
    }
}
