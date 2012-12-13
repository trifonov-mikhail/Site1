using System;
using System.Web.UI;
using Erc.Apple.Data.Repositories;

namespace Apple.Web.Admin.Controls
{
	public class UserControlBase : UserControl
	{
		protected Erc.Apple.Data.Models.Admin User
		{
			get { return new AdminRepository().GetByEmail(Page.User.Identity.Name); }
		}

		public void RegCss(string url)
		{
			(Page as PageBase).RegCss(url);
		}

		public void RegJS(string url)
		{
			(Page as PageBase).RegJS(url);
		}

		public void ShowError(string error)
		{
			((PageBase) Page).ShowError(error);
		}

		public void ShowError(Exception exc)
		{
			((PageBase) Page).ShowError(exc);
		}

		public void ShowMessage(string mess)
		{
			((PageBase) Page).ShowMessage(mess);
		}
	}
}