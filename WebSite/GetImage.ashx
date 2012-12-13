<%@ WebHandler Language="C#" Class="Apple.Web.GetImage" %>

using System;
using System.Web;
using System.IO;

using Erc.Apple.Data;

namespace Apple.Web
{

    public class GetImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;

            byte[] image = null;

            try
            {
                int type = Convert.ToInt32(context.Request.QueryString["type"]);
                int id = Convert.ToInt32(context.Request.QueryString["id"]);


                switch (type)
                {
                    case 1:
                        Product p = new Products().GetProductImageByGroupID("ru", id);
                        image = p.Image;
                        context.Response.ContentType = p.ImageType;
                        break;
                    case 2:
                        image = new News().GetImage("ru", id);
                        break;
                    case 3:
                        image = new CaseStudies().GetImage("ru", id);
                        break;
                    case 4:
                        image = new Stories().GetImage("ru", id);
                        break;
                    case 5:
                        image = new DevelopersTools().GetImage("ru", id);
                        break;
                    case 6:
                        image = new LatestProducts().GetImage("ru", id); 
                        break;
                    case 7:
                        image = new HomePageBlocks().GetImage("ru", id);
                        break;
                    case 8:
                        image = new Erc.Apple.Data.SuccessStories().GetImage("ru", id);
                        break;
                }

                if (image == null)
                    throw new Exception("no image");

                context.Response.BinaryWrite(image);
            }
            catch (Exception)
            {
                context.Response.WriteFile(context.Server.MapPath("~/images/1px.gif"));
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