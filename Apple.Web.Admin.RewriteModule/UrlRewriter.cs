using System;
using System.Web;
using System.Collections.Generic;
using System.Text;

using Erc.Apple.Data;
using Erc.Apple.Data.Cache;

namespace Apple.Web.Admin.RewriteModule
{
    public class UrlRewriter:IHttpModule
    {
        private readonly string redirectPage = "~/Admin.aspx?id={0}";

        private AdminPagesCache pages;

        public AdminPagesCache Pages
        {
            get 
            {
                if (pages == null)
                    pages = new AdminPagesCache();
                return pages; 
            }
        }
	

        #region IHttpModule Members

        public void Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(app_BeginRequest);
        }

        void app_BeginRequest(object sender, EventArgs e)
        {

            HttpApplication app = (HttpApplication)sender;
            string oldUrl = app.Context.Request.AppRelativeCurrentExecutionFilePath.ToLower();
            if (oldUrl.EndsWith(".aspx"))
            {
                string newUrl = String.Empty;
                int id = -1;
                string rawUrl = app.Context.Request.RawUrl;
                int beginQuery = rawUrl.IndexOf("?");
                string query = string.Empty;
                if (beginQuery > 0 && beginQuery + 1 < rawUrl.Length)
                {
                    query = "&" + rawUrl.Substring(beginQuery + 1);
                }

                foreach (AdminPage p in Pages.GetAll())
                {
                    if (p.Url.ToLower() == oldUrl)
                    {
                        id = p.ID;
                        break;
                    }
                }
                if (id > 0)
                {
                    string url = String.Format(redirectPage, id);
                    if (!string.IsNullOrEmpty(query) && query.Length > 1)
                        url += query;
                    app.Context.RewritePath(url);
                }
            }
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
