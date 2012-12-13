using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Erc.Apple.Data;

namespace Apple.Web.Admin.Controls.Editors
{
    public partial class HomePageEditor : UserControlBase
    {
        private static readonly string key = "HomePageBannerUrl";
		private static readonly string key2 = "HomePageBannerUrl2";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadValue();
            }
        }

        private void LoadValue()
        {
            txtBannerUrl.Text = DbConfig.GetItemValue(key);
			txtBannerUrl2.Text = DbConfig.GetItemValue(key2);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (HomePageImage.HasFile && HomePageImage.FileBytes.Length > 0)
                {
                    string path = ConfigurationManager.AppSettings["HomePageImagePath"];
                    if (string.IsNullOrEmpty(path))
                    {
                        throw new Exception("Invalid store path!");
                    }

                    HomePageImage.SaveAs(path);
                    ShowMessage("Изображение успешно загружено!");
                }
                DbConfig.Save(key, Erc.Apple.Data.Tools.FixUrl(txtBannerUrl.Text));
				LoadValue();
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
            
        }

		protected void btnUpload_Click2(object sender, EventArgs e)
		{
			try
			{
				if (HomePageImage2.HasFile && HomePageImage2.FileBytes.Length > 0)
				{
					string path = ConfigurationManager.AppSettings["HomePageImagePath2"];
					if (string.IsNullOrEmpty(path))
					{
						throw new Exception("Invalid store path!");
					}

					HomePageImage2.SaveAs(path);
					ShowMessage("Изображение успешно загружено!");
				}
				DbConfig.Save(key2, Erc.Apple.Data.Tools.FixUrl(txtBannerUrl2.Text));
				LoadValue();
			}
			catch (Exception exc)
			{
				ShowError(exc);
			}

		}
    }
}