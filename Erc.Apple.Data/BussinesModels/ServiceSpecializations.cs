using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class ServiceSpecializations
    {

        public List<Specialization> GetAllSpecializationByService(Service service)
        {
			List<Specialization> all = new List<Specialization>();
			using (StoredProcedure sp = new StoredProcedure("ServiceSpecializations_GetAllSpecializationByService"))
            {
				sp.Params.Add("@ServiceID", SqlDbType.Int).Value = service.GroupID;
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = service.LangCode;
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

		public List<string> GetListSpecializationByService(Service service)
		{
			List<string> all = new List<string>();
			List<Specialization> list = GetAllSpecializationByService(service);
			if(list != null && list.Count>0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					all.Add(list[i].Name);
				}
			}
			return all;
		}

       

        public int Add(ServiceSpecialization item)
        {
            int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("ServiceSpecialization_AddSpecialization"))
            {
				sp.Params.Add("@ServiceID", System.Data.SqlDbType.NChar).Value = item.ServiceID;
				sp.Params.Add("@SpecializationID", System.Data.SqlDbType.NVarChar).Value = item.SpecializationID;
                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

		/// <summary>
		/// Probably better use method with parameter has type Service
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Delete(ServiceSpecialization item)
        {
            bool result = false;
			using (StoredProcedure sp = new StoredProcedure("ServiceSpecialization_DeleteByService"))
            {
				sp.Params.Add("@ServiceID", System.Data.SqlDbType.Int).Value = item.ServiceID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
		public bool Delete(int serviceID)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("ServiceSpecialization_DeleteByService"))
			{
				sp.Params.Add("@ServiceID", System.Data.SqlDbType.Int).Value = serviceID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
		public bool Delete(Service item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("ServiceSpecialization_DeleteByService"))
			{
				sp.Params.Add("@ServiceID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
    }
}
