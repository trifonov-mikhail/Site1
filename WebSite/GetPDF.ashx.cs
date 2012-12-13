using System;
using System.IO;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Erc.Apple.Data;

namespace Apple.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetPDF : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string name = context.Request.QueryString["name"];
            string type = context.Request.QueryString["type"];
            string GroupID = context.Request.QueryString["groupid"];
            string Lang = context.Request.QueryString["lang"];
            if (!string.IsNullOrEmpty(name))
            {
                string filename = context.Server.MapPath(string.Format("~/files/{0}", name)).ToLower();
                string path = Path.GetDirectoryName(filename);
                if (filename.EndsWith(".pdf") && path.EndsWith("files") && File.Exists(filename))
                {
                    context.Response.Clear();
                    context.Response.ClearHeaders();

                    string attachment = String.Format("attachment; filename={0}", name);
                    context.Response.AddHeader("content-disposition", attachment);
                    context.Response.ContentType = "Application/pdf";
                    context.Response.AddHeader("Pragma", "public");

                    context.Response.WriteFile(filename);
                }
                else
                {
                    context.Response.Write("file not found");
                }
            }
            else if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(GroupID) && !string.IsNullOrEmpty(Lang))
            {
                switch (type)
                {
                    case "1":
                        Erc.Apple.Data.SuccessStories ss = new Erc.Apple.Data.SuccessStories();
                        try
                        {
                            SuccessStory s = ss.GetPdfFile(Lang, Int32.Parse(GroupID));
                            if (s != null)
                            {
                                string attachment = String.Format("attachment; filename={0}", s.PdfFileName);
                                context.Response.AddHeader("content-disposition", attachment);
                                //context.Response.ContentType = "Application/pdf";
                                context.Response.AddHeader("Pragma", "public");
                                context.Response.BinaryWrite(s.PdfFile);
                                context.Response.Flush();
                            }
                        }
                        catch (Exception)
                        {
                            context.Response.WriteFile("file not found");
                        }
                        break;
                    case "2":
                        Erc.Apple.Data.Stories sss = new Erc.Apple.Data.Stories();
                        try
                        {
                            Story st = sss.GetPdfFile(Lang, Int32.Parse(GroupID));
                            if (st != null)
                            {
                                string attachment = String.Format("attachment; filename={0}", st.PdfFileName);
                                context.Response.AddHeader("content-disposition", attachment);
                                //context.Response.ContentType = "Application/pdf";
                                context.Response.AddHeader("Pragma", "public");
                                context.Response.BinaryWrite(st.PdfFile);
                                context.Response.Flush();
                            }
                        }
                        catch (Exception)
                        {
                            context.Response.WriteFile("file not found");
                        }
                        break;
                }
                
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
