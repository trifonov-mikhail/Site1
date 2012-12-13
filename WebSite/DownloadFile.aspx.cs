using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Erc.Apple.Data.BussinesModels;
using Erc.Apple.Data;
using System.Web.Configuration;
using System.IO;

namespace Apple.Web
{
	public partial class DownloadFile : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			DownloadUserForms m = new DownloadUserForms();
			string guid = "";
			if (!string.IsNullOrEmpty(Request["guid"]))
				guid = Request["guid"];
			DownloadUserForm duf = m.GetByGuid(guid);
			DownloadFiles d = new DownloadFiles();
			var file = d.GetById(duf.FileID);
			string rootPath = WebConfigurationManager.AppSettings["DownloadFilesPath"];
			
			if (string.IsNullOrEmpty(file.FileName)) return;

			string filename = Path.Combine(rootPath, file.FileName);
			if (!File.Exists(filename)) return;
			FileInfo fileInfo = new FileInfo(filename);

			if (fileInfo.Exists)
			{
				Response.Clear();
				Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
				Response.AddHeader("Content-Length", fileInfo.Length.ToString());
				Response.ContentType = "application/octet-stream";
				Response.WriteFile(filename);
				Response.End();
			}			

		}
	}
}