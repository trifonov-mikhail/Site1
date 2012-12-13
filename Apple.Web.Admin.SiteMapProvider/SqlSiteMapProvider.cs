using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Configuration.Provider;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;

namespace Apple.Web.Admin.SiteMapProvider
{
    /// <summary>
    /// Summary description for SqlSiteMapProviderBase 
    /// </summary> 
    public class SqlSiteMapProvider : StaticSiteMapProvider
    {
        private string cacheDB;

        protected string CacheDB
        {
            get { return cacheDB; }
        }

        private string cacheTable;

        protected string CacheTable
        {
            get { return cacheTable; }
        }

        protected string CacheKey
        {
            get { return String.Format("{0}-{1}-CacheKey", CacheDB, CacheTable); }
        }

        protected SiteMapNode rootNode = null;

        private AdminPages dao;

        public AdminPages DAO
        {
            get
            {
                if (dao == null)
                    dao = new AdminPages();
                return dao;
            }
        }

        public SqlSiteMapProvider() 
        { 

        }

        public override SiteMapNode RootNode
        {
            get
            {
                SiteMapNode temp = null;
                temp = BuildSiteMap();
                return temp;
            }
        }
        
        public override void Initialize(string name, NameValueCollection config)
        { 
            if (config == null)
                throw new ArgumentNullException("config");

            if (string.IsNullOrEmpty(name))
                name = this.GetType().Name;

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "SQL site map provider");
            }

            base.Initialize(name, config);

            string dependency = config["sqlCacheDependency"];

            try
            {
                string[] info = dependency.Split(new char[] { ':' });
                
                cacheDB = info[0];
                cacheTable = info[1];

                config.Remove("sqlCacheDependency");
            }
            catch
            {
                throw new ProviderException("Invalid sqlCacheDependency");
            }

            //config end
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException("Unrecognized attribute: " + attr);
            }
        }
        
        protected override SiteMapNode GetRootNodeCore()
        {
            return RootNode;
        }
        
        protected override void Clear()
        {
            lock (this)
            {
                rootNode = null;
                base.Clear();
            }
        }
        
        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                if (null == rootNode)
                { 
                    Clear();

                    LoadSiteMap();

                    SqlCacheDependency dep = new SqlCacheDependency(CacheDB,CacheTable);

                    HttpRuntime.Cache.Insert(CacheKey,new object(),dep,Cache.NoAbsoluteExpiration,Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(OnSiteMapChanged));
                }
                return rootNode;
            }
        }

        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {
            //check IsAccessibleToUser for dynamic pages
            return base.IsAccessibleToUser(context, node);
        }

        protected void LoadSiteMap()
        {
            AdminPage item = DAO.GetRoot();

            if (item != null)
                rootNode = GetNode(item);

            if (rootNode == null)
                rootNode = new SiteMapNode(this, "Home", "~/Default.aspx", "Home");

            AddChildNodes(rootNode);
        }


        private SiteMapNode GetNode(AdminPage page)
        {
            return new SiteMapNode(this, page.ID.ToString(), page.Url, page.Title);
        }

        public void AddChildNodes(SiteMapNode root)
        {
            List<AdminPage> list = DAO.GetByParent(Convert.ToInt32(root.Key)); 

            if (list.Count == 0)
                return;

            foreach (AdminPage p in list)
            {
                SiteMapNode node = GetNode(p);
                this.AddNode(node, root);
                AddChildNodes(node);
            }
        }
        
        void OnSiteMapChanged(string key, object item, CacheItemRemovedReason reason)
        {
            lock (this)
            {
                if (key == this.CacheKey && reason == CacheItemRemovedReason.DependencyChanged)
                {
                    Clear();
                    rootNode = null;
                }
            }
        }
    }
}