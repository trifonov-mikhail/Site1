using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erc.Apple.Data.Models
{
	public partial class SerialNumber
	{
		private string _serviceName = string.Empty;

		public string ServiceName
		{
			get
			{
				if (string.IsNullOrEmpty(_serviceName))
				{
					int serviceID = ServiceID != null ? ServiceID.Value : int.MinValue;
					Service service = new Services().GetByID(serviceID);

					if (service != null)
						_serviceName = service.Name;
				}

				return _serviceName ?? string.Empty;
			}
		}
	}
}
