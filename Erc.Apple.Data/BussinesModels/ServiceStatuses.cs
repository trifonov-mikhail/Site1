using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class ServiceStatuses
    {
		public static int SequenceID = 8;

		public static int GetNextGroupID()
		{
			int result = -1;
			try
			{
				using (StoredProcedure sp = new StoredProcedure("GetNextSeqeuenceValue"))
				{
					sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = SequenceID;
					result = Convert.ToInt32(sp.ExecuteScalar());
				}
				return result;
			}
			catch (Exception)
			{
				return result;
			}
		}

		public List<ServiceStatus> GetAll()
		{
			List<ServiceStatus> all = new List<ServiceStatus>();
			using (StoredProcedure sp = new StoredProcedure("ServiceStatuses_GetAll"))
			{
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							ServiceStatus item = new ServiceStatus();
							item.ID = Convert.ToInt32(r["ID"]);
							item.Name = Convert.ToString(r["Name"]);
							item.Description = Convert.ToString(r["Description"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

		public ServiceStatus GetByID(int id)
		{
			ServiceStatus item = null;
			using (StoredProcedure sp = new StoredProcedure("ServiceStatuses_GetByID"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new ServiceStatus();
						item.ID = Convert.ToInt32(r["ID"]);
						item.Name = Convert.ToString(r["Name"]);
						item.Description = Convert.ToString(r["Description"]);
					}
				}
			}
			return item;
		}

		


    }
}
