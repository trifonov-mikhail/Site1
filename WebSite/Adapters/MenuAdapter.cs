using System;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CSSFriendly
{
    public class MenuAdapter : System.Web.UI.WebControls.Adapters.MenuAdapter
    {
        private WebControlAdapterExtender _extender = null;
        private WebControlAdapterExtender Extender
        {
            get
            {
                if (((_extender == null) && (Control != null)) ||
                    ((_extender != null) && (Control != _extender.AdaptedControl)))
                {
                    _extender = new WebControlAdapterExtender(Control);
                }

                System.Diagnostics.Debug.Assert(_extender != null, "CSS Friendly adapters internal error", "Null extender instance");
                return _extender;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (Extender.AdapterEnabled)
            {
                Extender.RenderBeginTag(writer, "AspNet-Menu-" + Control.Orientation.ToString());
            }
            else
            {
                base.RenderBeginTag(writer);
            }
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            if (Extender.AdapterEnabled)
            {
                Extender.RenderEndTag(writer);
            }
            else
            {
                base.RenderEndTag(writer);
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (Extender.AdapterEnabled)
            {
                writer.Indent++;
                BuildItems(Control.Items, true, writer);
                writer.Indent--;
                writer.WriteLine();
            }
            else
            {
                base.RenderContents(writer);
            }
        }

        private void BuildItems(MenuItemCollection items, bool isRoot, HtmlTextWriter writer)
        {
            if (items.Count > 0)
            {
                writer.WriteLine();

                writer.WriteBeginTag("ul");
                if (isRoot)
                {
                    //writer.WriteAttribute("class", "AspNet-Menu");
					writer.WriteAttribute("class", "");
                }
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Indent++;

            	for (int i = 0; i < items.Count; i++)
            	{
					if (!items[i].NavigateUrl.ToLower().Contains("feedback"))
						BuildItem(items[i],writer, i);
            	}
				//foreach (MenuItem item in items)
				//{
				//    BuildItem(item, writer);
				//}

                writer.Indent--;
                writer.WriteLine();
                writer.WriteEndTag("ul");
            }
        }

        private void BuildItem(MenuItem item, HtmlTextWriter writer, int index)
        {
            Menu menu = Control as Menu;
            if ((menu != null) && (item != null) && (writer != null) && item.Depth < 1)
            {
                writer.WriteLine();
                writer.WriteBeginTag("li");

                string theClass = "";
                if (item.Selected || IsChildItemSelected(item))
                {
					theClass = "item_active"+(index+1).ToString();
                }
                writer.WriteAttribute("class", theClass);

                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Indent++;
                writer.WriteLine();

                if (IsLink(item))
                {
                    writer.WriteBeginTag("a");
                    if (!String.IsNullOrEmpty(item.NavigateUrl))
                    {
                        writer.WriteAttribute("href", Page.Server.HtmlEncode(menu.ResolveClientUrl(item.NavigateUrl)));
                    }
                    else
                    {
                        writer.WriteAttribute("href", Page.ClientScript.GetPostBackClientHyperlink(menu, "b" + item.ValuePath.Replace(menu.PathSeparator.ToString(), "\\"), true));
                    }

                    writer.WriteAttribute("class", GetItemClass(menu, item));
                    WebControlAdapterExtender.WriteTargetAttribute(writer, item.Target);

                    if (!String.IsNullOrEmpty(item.ToolTip))
                    {
                        writer.WriteAttribute("title", item.ToolTip);
                    }
                    else if (!String.IsNullOrEmpty(menu.ToolTip))
                    {
                        writer.WriteAttribute("title", menu.ToolTip);
                    }
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                    writer.WriteLine();
                }
                else
                {
                    writer.WriteBeginTag("span");
                    writer.WriteAttribute("class", GetItemClass(menu, item));
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Indent++;
                    writer.WriteLine();
                }

                if (!String.IsNullOrEmpty(item.ImageUrl))
                {
                    writer.WriteBeginTag("img");
                    writer.WriteAttribute("src", menu.ResolveClientUrl(item.ImageUrl));
                    writer.WriteAttribute("alt", !String.IsNullOrEmpty(item.ToolTip) ? item.ToolTip : (!String.IsNullOrEmpty(menu.ToolTip) ? menu.ToolTip : item.Text));
                    writer.Write(HtmlTextWriter.SelfClosingTagEnd);
                }

                writer.Write("<span>" + item.Text + "</span>");

                if (IsLink(item))
                {
                    writer.Indent--;
                    writer.WriteEndTag("a");
                }
                else
                {
                    writer.Indent--;
                    writer.WriteEndTag("span");
                }

                if ((item.ChildItems != null) && (item.ChildItems.Count > 0))
                {
                    BuildItems(item.ChildItems, false, writer);
                }

                writer.Indent--;
                writer.WriteLine();
                writer.WriteEndTag("li");
            }
        }

        private bool IsLink(MenuItem item)
        {
            return (item != null) && item.Enabled && ((!String.IsNullOrEmpty(item.NavigateUrl)) || item.Selectable);
        }

        private string GetItemClass(Menu menu, MenuItem item)
        {
            string value = "blk";
            if (item.Selected)
            {
                value = "wht";
            }
            return value;
        }

        private string GetSelectStatusClass(MenuItem item)
        {
            string value = "";
                if (item.Selected)
                {
                    value = "menuOn";
                }
                //else if (IsChildItemSelected(item))
                //{
                //    value += " AspNet-Menu-ChildSelected";
                //}
                //else if (IsParentItemSelected(item))
                //{
                //    value += " AspNet-Menu-ParentSelected";
                //}
            return value;
        }

        private bool IsChildItemSelected(MenuItem item)
        {
            bool bRet = false;

            if ((item != null) && (item.ChildItems != null))
            {
                bRet = IsChildItemSelected(item.ChildItems);
            }

            return bRet;
        }

        private bool IsChildItemSelected(MenuItemCollection items)
        {
            bool bRet = false;

            if (items != null)
            {
                foreach (MenuItem item in items)
                {
                    if (item.Selected || IsChildItemSelected(item.ChildItems))
                    {
                        bRet = true;
                        break;
                    }
                }
            }

            return bRet;
        }

        private bool IsParentItemSelected(MenuItem item)
        {
            bool bRet = false;

            if ((item != null) && (item.Parent != null))
            {
                if (item.Parent.Selected)
                {
                    bRet = true;
                }
                else
                {
                    bRet = IsParentItemSelected(item.Parent);
                }
            }

            return bRet;
        }
    }
}
