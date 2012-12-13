using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Apple.Web.Admin.Interfaces;

namespace Apple.Web.Admin.Controls
{
	public partial class TrackSerialNumbersEditor : UserControlBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			csv.Options.FileName = "TrackingSerialNumbers";
			csv.Options.HeaderText = "Serial,DateStamp,IP,City";
			csv.Options.Columns = "Serial,DateStamp,IP,City";

		}



	}
}