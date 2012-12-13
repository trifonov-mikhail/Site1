using System;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using System.Web.Caching;

namespace Erc.Apple.Data
{

    public abstract class XmlConfig<T> where T : new()
    {
        protected abstract string StorePath
        {
            get;
        }
        private string FizPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(StorePath);
            }
        }
        protected T data;
        private XmlSerializer ser;
        protected XmlSerializer Ser
        {
            get
            {
                if (ser == null)
                    ser = new XmlSerializer(typeof(T));
                return ser;
            }
        }

        public XmlConfig()
        {
            data = new T();
        }
        public void Load()
        {
            lock (FizPath)
            {
                object o = HttpContext.Current.Cache[FizPath];
                if (o != null)
                {
                    data = (T)o;
                }
                else
                {
                    using (FileStream reader = File.Open(FizPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        data = (T)serializer.Deserialize(reader);
                    }
                    HttpContext.Current.Cache.Insert(FizPath, data, new CacheDependency(FizPath), DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }
            }
        }
        public void Save()
        {
            lock (FizPath)
            {
                if (!Directory.Exists(Path.GetDirectoryName(FizPath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(FizPath));

                using (FileStream writer = File.Create(FizPath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, data);
                }
                HttpContext.Current.Cache.Insert(FizPath, data, new CacheDependency(FizPath), DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }
        public virtual bool Delete()
        {
            bool success = true;

            if (File.Exists(FizPath))
            {
                lock (FizPath)
                {
                    try
                    {
                        File.Delete(FizPath);
                        HttpContext.Current.Cache.Remove(FizPath);
                    }
                    catch { success = false; }
                }
            }
            return success;
        }
    }

}