using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;

namespace Apple.Web
{
	public partial class DynamicPageMaster : MasterBase
    {
        private string mainMenuStyle;

        public string MainMenuStyle
        {
            get { return mainMenuStyle; }
            set { mainMenuStyle = value; }
        }

		
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void menuDS_Init(object sender, EventArgs e)
        {
            string lang = Globals.CurrentLanguage;
            string provider = string.Empty;

            switch (lang)
            {
                case "ua":  provider = "ua.SiteMapProvider"; break;
                case "en":  provider = "en.SiteMapProvider"; break;
                default:    provider = "ru.SiteMapProvider"; break;
            }

            menuDS.SiteMapProvider = provider;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (menuDS.Provider != null && menuDS.Provider.CurrentNode!=null)
            {
                this.Page.Title = String.Format("ERC :: {0}", menuDS.Provider.CurrentNode.Title);
            }
        }

        protected void Menu_PreRender(object sender, EventArgs e)
        {
            if (Menu.SelectedItem == null)
            {
                TemplatedPage tp = Globals.CurrentTemplatedPage;
                if (tp != null)
                {
                    foreach (MenuItem mi in Menu.Items)
                    {
                        string page = mi.NavigateUrl.ToLower();
                        string code = tp.ParentMenuItem.ToLower();
                        if (page.Contains(code))
                        {
                            mi.Selected = true;
                            break;
                        }
                    }

                    if (tp.ParentMenuItem.ToLower()=="whymac")
                    {
                        MainMenuStyle = "background-image:url(../../images/menu_bg_general_1.jpg);";
                    }
                    else if (tp.ParentMenuItem.ToLower() == "fordevelopers")
                    {
                        MainMenuStyle = "background-image:url(../../images/menu_bg_general_2.jpg);";
                    }
                }
            }
            else
            {
                if (Menu.SelectedItem.NavigateUrl.ToLower().Contains("whymac") || (Menu.SelectedItem.Parent != null && Menu.SelectedItem.Parent.NavigateUrl.ToLower().Contains("whymac")))
                {
                    MainMenuStyle = "background-image:url(../images/menu_bg_general_1.jpg);";
                }
                else if (Menu.SelectedItem.NavigateUrl.ToLower().Contains("fordevelopers") || (Menu.SelectedItem.Parent != null && Menu.SelectedItem.Parent.NavigateUrl.ToLower().Contains("fordevelopers")))
                {
                    MainMenuStyle = "background-image:url(../images/menu_bg_general_2.jpg);";
                }
            }
        }

        public void ShowSideBarItems(List<string> names)
        {
			//if(bar != null)
			//    bar.ShowItems(names);
        }
    }
}
