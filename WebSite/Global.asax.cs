using System;
using System.Globalization;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;

using Erc.Apple.Data;
using Erc.Apple.Data.Cache;

namespace Apple.Web
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly LanguagesCache LangCache = new LanguagesCache();

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = Request.AppRelativeCurrentExecutionFilePath.ToLower();
            string lang = "ru";
			if(path == "~/default.aspx")
			{
				Response.Redirect("~/ru/Default.aspx");
                return;
			}
            string s = Server.MapPath(path.Replace("ru/", "").Replace("uk/", ""));
            if (File.Exists(s) && (s.Contains("localization.aspx") || s.ToLower().Contains("downloadfileform.aspx")))
            {
				string query = Request.QueryString.ToString();
                string nPath = string.Format("~/{0}?lang={1}&{2}", path.Substring(5), lang, query);
                if (nPath.Length != 0)
                {
                    Globals.OriginalPath = Request.Path;
                    Context.RewritePath(nPath, false);
                }
                return;
            }
            if (path.Contains(".aspx"))
            {
                if (path[1]=='/' && path[4]=='/')
                {
                    lang = path.Substring(2, 2);

                    Language dblang = LangCache.GetByCode(lang);
                    if (dblang != null)
                    {
                        CultureInfo cultureInfo = null;

                        try
                        {
                            cultureInfo = new CultureInfo(dblang.Locale);
                        }
                        catch { }

                        if (cultureInfo != null)
                        {
                            Thread.CurrentThread.CurrentUICulture = cultureInfo;
                            Thread.CurrentThread.CurrentCulture = cultureInfo;

                            string newPath = string.Empty;
                            if (path.Contains("/support/"))
                            {
                                
                            }
                            if (path.Contains("/content/") || path.Contains("/support/") || path.Contains("/partners/"))
                            {
                                int index = path.LastIndexOf('/');
                                string page = string.Empty;
                                if (index > 0)
                                {
                                    page = path.Substring(index+1);
                                }

                                TemplatedPage tp = null;

                                foreach (TemplatedPage p in Globals.TemplatedPages)
                                {
                                    if (page == p.Url.ToLower())
                                    {
                                        tp = p;
                                        break;
                                    }
                                }
                                if (tp != null)
                                {
                                    newPath = string.Format("~/DynamicPage.aspx?lang={1}", page, lang);
                                }
                                Globals.CurrentTemplatedPage = tp;
                            }
                            else
                            {
								string query = Request.QueryString.ToString(); 
								newPath = string.Format("~/{0}?lang={1}&{2}", path.Substring(5), lang, query);
                            }

                            if (newPath.Length != 0)
                            {
                                Globals.OriginalPath = Request.Path;
                                Context.RewritePath(newPath, false);
                            }
                        }
                    }
                }
            }
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError().GetBaseException();

            Logger.LogException(exc, "SiteApp Error");
        }
    }
}