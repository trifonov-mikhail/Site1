using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Cities
    {

		public static int SequenceID = 4;

		public static int GetNextCGroupID()
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

		//

		

		public List<City> GetAllByLanguage(string language)
		{
			List<City> all = new List<City>();
			using (StoredProcedure sp = new StoredProcedure("Cities_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							City item = new City();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.RegionID = Convert.ToInt32(r["RegionID"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

        public List<City> GetAllByLanguageAndRegionFilter(string language,int regionID)
        {
            List<City> all = new List<City>();
			City city = new City();
        	city.Name = "Все";
        	city.GroupID = 0;
			all.Add(city);
			all.AddRange(GetAllByLanguageAndRegion(language, regionID));
            return all;
        }
		public List<City> GetAllByLanguageAndRegion(string language, int regionID)
		{
			List<City> all = new List<City>();
			using (StoredProcedure sp = new StoredProcedure("Cities_GetAllByLanguageAndRegion"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				sp.Params.Add("@RegionID", System.Data.SqlDbType.Int).Value = regionID;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							City item = new City();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.RegionID = Convert.ToInt32(r["RegionID"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

        public List<City> GetAllByLanguageAndRegionAndName(string language, int regionID, string name)
        {
            List<City> all = new List<City>();
            using (StoredProcedure sp = new StoredProcedure("Cities_GetAllByLanguageAndRegionAndName"))
            {
                sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
                sp.Params.Add("@RegionID", System.Data.SqlDbType.Int).Value = regionID;
                
                if (!string.IsNullOrEmpty(name))
                    sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = name;
                
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            City item = new City();
                            item.ID = Convert.ToInt32(r["ID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Name = Convert.ToString(r["Name"]);
                            item.RegionID = Convert.ToInt32(r["RegionID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

		//public List<City> GetAll()
		//{
		//    List<City> all = new List<City>();
		//    using (StoredProcedure sp = new StoredProcedure("Cities_GetAll"))
		//    {
		//        using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
		//        {
		//            if (r != null)
		//            {
		//                while (r.Read())
		//                {
		//                    City item = new City();
		//                    item.ID = Convert.ToInt32(r["ID"]);
		//                    item.LangCode = Convert.ToString(r["LangCode"]);
		//                    item.RegionID = Convert.ToInt32(r["RegionID"]);
		//                    item.Name = Convert.ToString(r["Name"]);
		//                    item.GroupID = Convert.ToInt32(r["GroupID"]);
		//                    all.Add(item);
		//                }
		//            }
		//        }
		//    }
		//    return all;
		//}

		public City GetByLangGroup(string language, int groupId)
		{
			City item = null;
			using (StoredProcedure sp = new StoredProcedure("Cities_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new City();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.RegionID = Convert.ToInt32(r["RegionID"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
					}
				}
			}
			return item;
		}
		public int AddUpdate(City item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Cities_AddUpdateItem"))
			{
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				sp.Params.Add("RegionID", System.Data.SqlDbType.Int).Value = item.RegionID;
				sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				sp.Params.Add("GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
				newID = Convert.ToInt32(sp.ExecuteScalar());
				item.ID = newID;
			}
			return newID;
		}

		public bool DeleteGroup(City item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Cities_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
        public City GetByID(int id)
        {
            City item = null;
            using (StoredProcedure sp = new StoredProcedure("Cities_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new City();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.RegionID = Convert.ToInt32(r["RegionID"]);
						item.Name = Convert.ToString(r["Name"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
                    }
                }
            }
            return item;
        }

		//public int Add(City item)
		//{
		//    int newID = 0;
		//    using (StoredProcedure sp = new StoredProcedure("Cities_AddItem"))
		//    {
		//        sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
		//        sp.Params.Add("RegionID", System.Data.SqlDbType.Int).Value = item.RegionID;
		//        sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
		//        newID = Convert.ToInt32(sp.ExecuteScalar());
		//    }
		//    return newID;
		//}

		//public bool Update(City item)
		//{
		//    bool result = false;
		//    using (StoredProcedure sp = new StoredProcedure("Cities_UpdateItem"))
		//    {
		//        sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
		//        sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
		//        sp.Params.Add("RegionID", System.Data.SqlDbType.Int).Value = item.RegionID;
		//        sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
		//        result = sp.ExecuteNonQuery() > 0;
		//    }
		//    return result;
		//}

		//public bool Delete(City item)
		//{
		//    bool result = false;
		//    using (StoredProcedure sp = new StoredProcedure("Cities_DeleteItem"))
		//    {
		//        sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

		//        result = sp.ExecuteNonQuery() > 0;
		//    }
		//    return result;
		//}
    }
}
