using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Erc.Apple.Data.Models
{
	public partial class AppleDataContext
	{
		public AppleDataContext() : this(ConfigurationManager.ConnectionStrings["SiteDBConnectionString"].ConnectionString)
		{
		}
	}
}
