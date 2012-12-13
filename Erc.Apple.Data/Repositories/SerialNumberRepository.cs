using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erc.Apple.Data.Models;
using System.Data.SqlClient;

namespace Erc.Apple.Data.Repositories
{
	public class SerialNumberRepository : RepositoryBase<SerialNumber>
	{
		public SerialNumber GetByNumber(string serialNumber)
		{
			return Context.GetTable<SerialNumber>().FirstOrDefault(e => e.Number.Equals(serialNumber));
		}

		public void TrackSerialNumber(string serialNumber, string request, string ip, string city)
		{
			using (StoredProcedure sp = new StoredProcedure("Insert_TrackSerialNumber"))
			{
				sp.Params.Add("@Serial", System.Data.SqlDbType.NVarChar, 50).Value = serialNumber;
				sp.Params.Add("@RequestObject", System.Data.SqlDbType.NVarChar).Value = request;
				sp.Params.Add("@IP", System.Data.SqlDbType.NVarChar).Value = ip;
				sp.Params.Add("@city", System.Data.SqlDbType.NVarChar).Value = city;
				sp.ExecuteNonQuery();
			}
			
			//Context.ExecuteCommand("INSERT INTO TrackSerialNumber(Serial) VALUES(@Serial)", new System.Data.SqlClient.SqlParameter[] {new SqlParameter("@Serial", serialNumber)});

		}

		public void InsertIpDatabase(string ip, string response)
		{
			using (StoredProcedure sp = new StoredProcedure("Insert_IpDatabase"))
			{
				sp.Params.Add("@IP", System.Data.SqlDbType.NVarChar).Value = ip;
				sp.Params.Add("@Response", System.Data.SqlDbType.NVarChar).Value = response;
				sp.ExecuteNonQuery();
			}
		}
	}
}
