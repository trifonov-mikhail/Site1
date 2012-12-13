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

namespace Apple.Web.Admin.Controls
{
    public class CustomMenu:WebControl
    {
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.Write("<div id='tabs'>");
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("</div>");
        }
        protected override void RenderChildren(HtmlTextWriter writer)
        {
            RenderNodes(writer);
            RenderSubMenu(writer);
        }

        private void RenderNodes(HtmlTextWriter writer)
        {
            if (SiteMap.RootNode != null)
            {
                int i = 0;
                writer.Write("<table cellpadding='0' cellspacing='0' border='0'>");
                writer.Write("<tr>\n");
                foreach (SiteMapNode node in SiteMap.RootNode.ChildNodes)
                {
                	IPrincipal User = HttpContext.Current.User;
                	bool isAdmin = false;
					isAdmin = User.Identity.IsAuthenticated && User.Identity.Name.ToLower() == "admin";
					
                    string title = node.Title;
					string url = Page.ResolveClientUrl(node.Url);
                    string css = "tab";
                    if (SiteMap.CurrentNode != null && SiteMap.CurrentNode.Equals(node) || ChildSelected(node))
                    {
                        css = "stab";
                    }
                    if (node.Url.IndexOf("AdminPages.aspx") > 0 || node.Url.IndexOf("Log.aspx") > 0)
					{
						if(isAdmin)
							writer.Write(String.Format(Globals.MenuItemTemplate, i++, url, title, css));
					}
					else
					{
						writer.Write(String.Format(Globals.MenuItemTemplate, i++, url, title, css));
					}
					
                }
                writer.Write("</tr>\n");
                writer.Write("</table>");
            }
        }

        private bool ChildSelected(SiteMapNode node)
        {
            bool result = false;

            if (SiteMap.CurrentNode != null && node.HasChildNodes)
            {
                foreach (SiteMapNode n in node.ChildNodes)
                {
                    if (n.Equals(SiteMap.CurrentNode))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private void RenderSubMenu(HtmlTextWriter writer)
        {
            SiteMapNode node = SiteMap.CurrentNode;

            if (node == null)
                return;

            SiteMapNode parent = null;

            bool firstOn = false;
            if (node.HasChildNodes){
                parent = node;
                firstOn = true;
            }
            else if (node.ParentNode != null && node.ParentNode.ParentNode != null)
            {
                parent = node.ParentNode;
            }

            if (parent != null)
            {
                writer.Write("<div class='subMenu'>");
                writer.Write("<table cellpadding='0' cellspacing='0' border='0'>");
                writer.Write("<tr>\n");
                int i = 0;
                foreach (SiteMapNode item in parent.ChildNodes)
                {
                    string title = item.Title;
                    string url = Page.ResolveClientUrl(item.Url);
                    string css = "";
                    if (SiteMap.CurrentNode != null && SiteMap.CurrentNode.Equals(item)|| (i==0) && firstOn)
                    {
                        css = "on";
                    }

                    writer.Write(String.Format("<td><a href='{0}' class='{2}'>{1}<a/></td>", url, title, css));
                    i++;
                }
                writer.Write("</tr>\n");
                writer.Write("</table>");
                writer.Write("</div>");
            }
        }
    }
}
