using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Feedbacks
    {

		
		public int AddUpdate(Feedback item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Feedback_Add"))
			{
				sp.Params.Add("FirstName", System.Data.SqlDbType.NVarChar).Value = item.FirstName;
				sp.Params.Add("LastName", System.Data.SqlDbType.NVarChar).Value = item.LastName;
				sp.Params.Add("Telephone", System.Data.SqlDbType.NVarChar).Value = item.Telephone;
				sp.Params.Add("EMail", System.Data.SqlDbType.NVarChar).Value = item.EMail;
				sp.Params.Add("Company", System.Data.SqlDbType.NVarChar).Value = item.Company;
				sp.Params.Add("Position", System.Data.SqlDbType.NVarChar).Value = item.Position;
				sp.Params.Add("Comment", System.Data.SqlDbType.NVarChar).Value = item.Comment;
				sp.Params.Add("UserInfo", System.Data.SqlDbType.NVarChar).Value = item.UserInfo;
				
				newID = Convert.ToInt32(sp.ExecuteScalar());
				item.ID = newID;
			}
			return newID;
		}

		public bool SendEmail()
		{
			return false;
		}
    }
}
