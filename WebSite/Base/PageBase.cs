using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Apple.Web.Controls;

namespace Apple.Web
{
    public class PageBase:Page
    {
        public string CurrentLanguage
        {
            get
            {
                return Globals.CurrentLanguage;
            }
        }
		
		public string GetUrl(string url)
		{
			return this.ResolveUrl(url.Replace("{lang}", this.CurrentLanguage));
		}

        public string TranslatableText(string id)
        {
            return Globals.TranslatableText(id);
        }

        protected Dictionary<string, HtmlLink> customCssIncludes;
        protected Dictionary<string, HtmlLink> CustomCssIncludes
        {
            get
            {
                if (customCssIncludes == null)
                    customCssIncludes = new Dictionary<string, HtmlLink>();
                return customCssIncludes;
            }
        }
        protected Dictionary<string, HtmlJsInclude> customJsIncludes;
        protected Dictionary<string, HtmlJsInclude> CustomJsIncludes
        {
            get
            {
                if (customJsIncludes == null)
                    customJsIncludes = new Dictionary<string, HtmlJsInclude>();
                return customJsIncludes;
            }
        }

        protected List<string> SideBarItemsNames = new List<string>();

        public void RegCss(string url)
        {
            if (!CustomCssIncludes.ContainsKey(url))
            {

                HtmlCssInclude css = new HtmlCssInclude(ResolveUrl(url));
                CustomCssIncludes.Add(url, css);
            }
        }
        public void RegJS(string url)
        {
            if (!CustomJsIncludes.ContainsKey(url))
            {
                HtmlJsInclude js = new HtmlJsInclude(ResolveUrl(url));
                CustomJsIncludes.Add(url, js);
            }
        }

        public void UnRegJS(string url)
        {
            if (CustomJsIncludes.ContainsKey(url))
            {
                CustomJsIncludes.Remove(url);
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            object o = Request.QueryString["lang"];
            if (o != null)
            {
                Globals.CurrentLanguage = o.ToString();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            RegJS("~/js/jquery-1.3.2.min.js");
            //RegJS("/js/jquery.min.js");
			RegJS("/js/jquery.cookie.js");
            RegJS("~/js/jquery-ui-1.7.2.custom.min.js");
            RegCss("~/css/CustomPopup.css");
            RegCss("~/css/CustomAccordion.css");

            //for popup
            RegJS("~/js/jquery.ifixpng.js");
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //}

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            RenderCustomCssIncludesList();
            RenderCustomJsIncludesList();
            ShowSideBar();
        }

        private void ShowSideBar()
        {
            MainMaster master = Master as MainMaster;
            if (master != null)
            {
                master.ShowSideBarItems(SideBarItemsNames);
            }
        }

        private void RenderCustomCssIncludesList()
        {
            if (customCssIncludes != null)
            {
                Header.Controls.Add(new LiteralControl("\n<!--Custom css start-->"));

                foreach (HtmlCssInclude c in CustomCssIncludes.Values)
                {
                    Header.Controls.Add(c);
                }
                Header.Controls.Add(new LiteralControl("\n<!--Custom css end-->\n"));
            }
        }
        private void RenderCustomJsIncludesList()
        {
            if (customJsIncludes != null)
            {

                Header.Controls.AddAt(0, new LiteralControl("\n<!--Custom js start-->"));
                int pos = 1;
                foreach (HtmlJsInclude c in CustomJsIncludes.Values)
                {
                    Header.Controls.AddAt(pos++, c);
                }
                Header.Controls.AddAt(pos, new LiteralControl("\n<!--Custom js end-->\n"));
            }
        }
    }
}
