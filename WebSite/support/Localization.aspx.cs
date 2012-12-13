using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data;
using System.IO;
using System.Web.Configuration;

namespace Apple.Web
{
    public partial class Localization : PageBase
    {
		protected string GetImagePath(object o)
		{
			int id = Convert.ToInt32(o);
			string path = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			string filename = Path.Combine(path, id + ".jpg");
			if (File.Exists(filename))
			{
				return VirtualPathUtility.ToAbsolute(string.Format("~/virtualimages/{0}.jpg", id));
			}
			return VirtualPathUtility.ToAbsolute("~/images/test.jpeg");
		}
        protected void Page_Load(object sender, EventArgs e)
        {
            var df = new DownloadFiles();
            int type = 0;
            try
            {
                type = Convert.ToInt32(ddlCategory.SelectedValue);
            }
            catch (Exception ex)
            {
				Logger.LogException(ex, "Localization.aspx");
            }
			if (!string.IsNullOrEmpty(Request["items"]))
			{
				var files = df.GetByTypeId(type).OrderByDescending(p => p.ID).ToList();
				rptFile.DataSource = files;
			}
			else
			{
				var files = df.GetByTypeId(type).OrderByDescending(p => p.ID).Take(5).ToList();
				rptFile.DataSource = files;
			}
            
            rptFile.DataBind();
        }
    }
}
