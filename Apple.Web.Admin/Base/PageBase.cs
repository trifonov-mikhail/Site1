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

using Apple.Web.Admin.Controls;

namespace Apple.Web.Admin
{
    public class PageBase:Page
    {
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

        public virtual void ShowError(string error)
        {
        }

        public virtual void ShowError(Exception exc)
        {
            throw exc;
        }
        public virtual void ShowMessage(string mess)
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegCss("~/css/common.css");
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            RenderCustomCssIncludesList();
            RenderCustomJsIncludesList();
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
