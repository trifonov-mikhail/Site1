using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class PartnerSpecializations
    {

        public List<Specialization> GetAllSpecializationByPartner(Partner partner)
        {
			List<Specialization> all = new List<Specialization>();
			using (StoredProcedure sp = new StoredProcedure("PartnerSpecializations_GetAllSpecializationByPartner"))
            {
            	sp.Params.Add("@PartnerID", SqlDbType.Int).Value = partner.GroupID;
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = partner.LangCode;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
						while (r.Read())
						{
							Specialization item = new Specialization();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.Description = Convert.ToString(r["Description"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							all.Add(item);
						}
                    }
                }
            }
            return all;
        }

		public List<string> GetListSpecializationByPartner(Partner partner)
		{
			List<string> all = new List<string>();
			List<Specialization> list = GetAllSpecializationByPartner(partner);
			if(list != null && list.Count>0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					all.Add(list[i].Name);
				}
			}
			return all;
		}

       

        public int Add(PartnerSpecialization item)
        {
            int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("PartnerSpecialization_AddSpecialization"))
            {
				sp.Params.Add("@PartnerID", System.Data.SqlDbType.NChar).Value = item.PartnerID;
				sp.Params.Add("@SpecializationID", System.Data.SqlDbType.NVarChar).Value = item.SpecializationID;
                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(PartnerSpecialization item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("PartnerSpecializations_UpdateItem"))
            {
				//sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
				//sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				//sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				//sp.Params.Add("@Description", System.Data.SqlDbType.NVarChar).Value = item.Description;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
		
		/// <summary>
		/// Probably better use method with parameter has type Partner
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public bool Delete(PartnerSpecialization item)
        {
            bool result = false;
			using (StoredProcedure sp = new StoredProcedure("PartnerSpecialization_DeleteByPartner"))
            {
				sp.Params.Add("@PartnerID", System.Data.SqlDbType.Int).Value = item.PartnerID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
		public bool Delete(int partnerID)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("PartnerSpecialization_DeleteByPartner"))
			{
				sp.Params.Add("@PartnerID", System.Data.SqlDbType.Int).Value = partnerID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
		public bool Delete(Partner item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("PartnerSpecialization_DeleteByPartner"))
			{
				sp.Params.Add("@PartnerID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
    }
}
