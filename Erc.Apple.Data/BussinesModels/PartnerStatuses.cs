using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class PartnerStatuses
    {
		public static int SequenceID = 6;

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

		public List<PartnerStatus> GetAll()
		{
			List<PartnerStatus> all = new List<PartnerStatus>();
			using (StoredProcedure sp = new StoredProcedure("PartnerStatuses_GetAll"))
			{
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							PartnerStatus item = new PartnerStatus();
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

		public PartnerStatus GetByID(int id)
		{
			PartnerStatus item = null;
			using (StoredProcedure sp = new StoredProcedure("PartnerStatuses_GetByID"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new PartnerStatus();
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
