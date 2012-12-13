using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

namespace Apple.Web.Controls
{
    public class CustomMenu : WebControl
    {
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<ul>");
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("</ul>");
        }
        protected override void RenderChildren(HtmlTextWriter writer)
        {
            RenderNodes(writer);
        }
        private void RenderNodes(HtmlTextWriter writer)
        {
            if (SiteMap.RootNode != null)
            {
                foreach (SiteMapNode node in SiteMap.RootNode.ChildNodes)
                {
                	string title = node.Title;
					string url = Page.ResolveClientUrl(node.Url);
                    string aCss = "blk";
                    string liCss = "";
                    if (SiteMap.CurrentNode != null && SiteMap.CurrentNode.Equals(node))
                    {
                        aCss = "wht";
                        liCss = "menuOn";
                    }
                    writer.Write(String.Format("<li class='{0}'><a class='{1}' href='{2}'>{3}</a></li>",liCss, aCss, url, title));
                }
            }
        }
    }
}
