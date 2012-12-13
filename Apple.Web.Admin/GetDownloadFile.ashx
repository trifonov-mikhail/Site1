<%@ WebHandler Language="C#" Class="Apple.Web.Admin.GetImage" %>

using System;
using System.Web;
using System.IO;

using Erc.Apple.Data;

namespace Apple.Web.Admin
{
    public class GetDownloadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/octet-stream";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;

            byte[] image = null;
            
            try
            {
                //int type = Convert.ToInt32(context.Request.QueryString["type"]);
                int id = Convert.ToInt32(context.Request.QueryString["id"]);


                DownloadFiles d = new DownloadFiles();
                var file = d.GetById(id);
                string path = Path.Combine(System.Web.Configuration.WebConfigurationManager.AppSettings[""],
                                           file.FileName);
                if(File.Exists(path))
                    context.Response.WriteFile(path);
                context.Response.WriteFile(context.Server.MapPath("~/img/1px.gif"));
                
            }
            catch (Exception)
            {
                context.Response.WriteFile(context.Server.MapPath("~/img/1px.gif"));
            }

            
        }


        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

    }
}