using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Services
    {


		public static int SequenceID = 9;

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


#warning MT: Please add a Service status text for Service object and get this data from SP.
		public List<Service> GetAllByLanguage(string language)
		{
			List<Service> all = new List<Service>();
			using (StoredProcedure sp = new StoredProcedure("Services_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Service item = new Service();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.Telephone = Convert.ToString(r["Telephone"]);
							item.ServiceStatusID = Convert.ToInt32(r["ServiceStatusID"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							item.CityID = Convert.ToInt32(r["CityID"]);
							item.Url = Convert.ToString(r["Url"]);
                            item.Publish = Convert.ToBoolean(r["Publish"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}
		public Service GetByLangGroup(string language, int groupId)
		{
			Service item = null;
			using (StoredProcedure sp = new StoredProcedure("Services_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Service();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.Telephone = Convert.ToString(r["Telephone"]);
						item.ServiceStatusID = Convert.ToInt32(r["ServiceStatusID"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
						item.CityID = Convert.ToInt32(r["CityID"]);
						item.RegionID = Convert.ToInt32(r["RegionID"]);
						item.Address = Convert.ToString(r["Address"]);
						item.Url = Convert.ToString(r["Url"]);
                        item.Publish = Convert.ToBoolean(r["Publish"]);
					}
				}
			}
			return item;
		}

		public List<Service> Services_GetAllByLanguageRegionCitySpecialization(string language, int cityID, int specializationID, int regionID)
		{
			List<Service> all = new List<Service>();
			using (StoredProcedure sp = new StoredProcedure("Services_GetAllByLanguageRegionCitySpecialization"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				sp.Params.Add("@CityID", SqlDbType.Int).Value = cityID;
				sp.Params.Add("@RegionID", SqlDbType.Int).Value = regionID;
				sp.Params.Add("@SpecializationID", SqlDbType.Int).Value = specializationID;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Service item = new Service();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.Address = Convert.ToString(r["Address"]);
							item.Telephone = Convert.ToString(r["Telephone"]);
							item.ServiceStatusID = Convert.ToInt32(r["ServiceStatusID"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							item.CityID = Convert.ToInt32(r["CityID"]);
							item.RegionID = Convert.ToInt32(r["RegionID"]);
							item.Url = Convert.ToString(r["Url"]);

                            item.CityName = Convert.ToString(r["CityName"]);
                            item.StatusName = Convert.ToString(r["StatusName"]);
                            item.Publish = Convert.ToBoolean(r["Publish"]);

                            all.Add(item);
						}
					}
				}
			}
			return all;
		}

        public List<Service> Services_GetAllByLanguageRegionCitySpecializationAdmin(string language, int cityID, int specializationID, int regionID)
        {
            List<Service> all = new List<Service>();
            using (StoredProcedure sp = new StoredProcedure("Services_GetAllByLanguageRegionCitySpecializationAdmin"))
            {
                sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
                sp.Params.Add("@CityID", SqlDbType.Int).Value = cityID;
                sp.Params.Add("@RegionID", SqlDbType.Int).Value = regionID;
                sp.Params.Add("@SpecializationID", SqlDbType.Int).Value = specializationID;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            Service item = new Service();
                            item.ID = Convert.ToInt32(r["ID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Name = Convert.ToString(r["Name"]);
                            item.Address = Convert.ToString(r["Address"]);
                            item.Telephone = Convert.ToString(r["Telephone"]);
                            item.ServiceStatusID = Convert.ToInt32(r["ServiceStatusID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.CityID = Convert.ToInt32(r["CityID"]);
                            item.RegionID = Convert.ToInt32(r["RegionID"]);
                            item.Url = Convert.ToString(r["Url"]);

                            item.CityName = Convert.ToString(r["CityName"]);
                            item.StatusName = Convert.ToString(r["StatusName"]);
                            item.Publish = Convert.ToBoolean(r["Publish"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }


		public int AddUpdate(Service item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Services_AddUpdateItem"))
			{
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				sp.Params.Add("ServiceStatusID", System.Data.SqlDbType.Int).Value = item.ServiceStatusID;
				sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				sp.Params.Add("Address", System.Data.SqlDbType.NVarChar).Value = item.Address;
				sp.Params.Add("Telephone", System.Data.SqlDbType.NVarChar).Value = item.Telephone;
				sp.Params.Add("GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
				sp.Params.Add("CityID", System.Data.SqlDbType.Int).Value = item.CityID;
				sp.Params.Add("RegionID", System.Data.SqlDbType.Int).Value = item.RegionID;
				sp.Params.Add("Url", System.Data.SqlDbType.NVarChar).Value = Tools.FixUrl(item.Url);
                //sp.Params.Add("Publish", System.Data.SqlDbType.Bit).Value = item.Publish;
				newID = Convert.ToInt32(sp.ExecuteScalar());
				item.ID = newID;
			}
			return newID;
		}

		public bool DeleteGroup(Service item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Services_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
        public bool ChangePublishStatus(int groupID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Services_ChangePublishStatus"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public Service GetByID(int id)
        {
            Service item = null;
            using (StoredProcedure sp = new StoredProcedure("Services_GetByID"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new Service();
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Name = Convert.ToString(r["Name"]);
                        item.ID = Convert.ToInt32(r["ID"]);
                    }
                }
            }
            return item;
        }



        public bool Check2yearWarranty(string number)
        {
            List<string> list = new List<string>();
            // 
            using (StoredProcedure sp = new StoredProcedure("SELECT count(Serial) FROM iPadActionSerial WHERE Status = 1"))
            {
                sp.command.CommandType = System.Data.CommandType.Text;
                int cnt = (int)sp.ExecuteScalar();
                if (cnt > 0) return true;
            }
            //using (StoredProcedure sp = new StoredProcedure("SELECT count(Serial) FROM MacActionSerial WHERE Status = 1"))
            //{
            //    sp.command.CommandType = System.Data.CommandType.Text;
            //    int cnt = (int)sp.ExecuteScalar();
            //    if (cnt > 0) return true;
            //}
            return false;
        }
    }
}
