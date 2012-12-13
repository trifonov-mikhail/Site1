using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;


namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Partners
    {


		public static int SequenceID = 5;

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

		
#warning MT: Please add a partner status text for Partner object and get this data from SP.
		public List<Partner> GetAllByLanguage(string language)
		{
			List<Partner> all = new List<Partner>();
			using (StoredProcedure sp = new StoredProcedure("Partners_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Partner item = new Partner();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.Telephone = Convert.ToString(r["Telephone"]);
							item.Url = Convert.ToString(r["Url"]);
							item.PartnerStatusID = Convert.ToInt32(r["PartnerStatusID"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							item.CityID = Convert.ToInt32(r["CityID"]);
                            item.Publish = Convert.ToBoolean(r["Publish"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}
		public Partner GetByLangGroup(string language, int groupId)
		{
			Partner item = null;
			using (StoredProcedure sp = new StoredProcedure("Partners_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Partner();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.Telephone = Convert.ToString(r["Telephone"]);
						item.PartnerStatusID = Convert.ToInt32(r["PartnerStatusID"]);
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

		public List<Partner> Partners_GetAllByLanguageRegionCitySpecialization( string language, int cityID, int specializationID, int regionID)
		{
			List<Partner> all = new List<Partner>();
			using (StoredProcedure sp = new StoredProcedure("Partners_GetAllByLanguageRegionCitySpecialization"))
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
							Partner item = new Partner();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.Address = Convert.ToString(r["Address"]);
							item.Telephone = Convert.ToString(r["Telephone"]);
							item.PartnerStatusID = Convert.ToInt32(r["PartnerStatusID"]);
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

		public List<Partner> Partners_GetAllByLanguageRegionCitySpecializationAdmin(string language, int cityID, int specializationID, int regionID, string company)
        {
            List<Partner> all = new List<Partner>();
            using (StoredProcedure sp = new StoredProcedure("Partners_GetAllByLanguageRegionCitySpecializationAdmin"))
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
                            Partner item = new Partner();
                            item.ID = Convert.ToInt32(r["ID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Name = Convert.ToString(r["Name"]);
                            item.Address = Convert.ToString(r["Address"]);
                            item.Telephone = Convert.ToString(r["Telephone"]);
                            item.PartnerStatusID = Convert.ToInt32(r["PartnerStatusID"]);
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

			if (!string.IsNullOrEmpty(company))
			{
				string[] splitCompany = company.Split(' ');
				List<Partner> list = new List<Partner>();
				for (int i = 0; i < splitCompany.Length; i++)
				{
					list.AddRange(all.Where(s => s.Name.ToLower().Contains(splitCompany[i].ToLower()) || s.Address.ToLower().Contains(splitCompany[i].ToLower())));
				}
				return list;
			}

			return all;
        }


		public int AddUpdate(Partner item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Partners_AddUpdateItem"))
			{
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				sp.Params.Add("PartnerStatusID", System.Data.SqlDbType.Int).Value = item.PartnerStatusID;
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

		public bool DeleteGroup(Partner item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Partners_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
        public bool ChangePublishStatus(int groupID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Partners_ChangePublishStatus"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        //public Partner GetByID(int id)
        //{
        //    Partner item = null;
        //    using (StoredProcedure sp = new StoredProcedure("Partners_GetByID"))
        //    {
        //        sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
        //        using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
        //        {
        //            if (r != null && r.Read())
        //            {
        //                item = new Partner();
        //                item.LangCode = Convert.ToString(r["LangCode"]);
        //                item.Name = Convert.ToString(r["Name"]);
        //                item.ID = Convert.ToInt32(r["ID"]);
        //            }
        //        }
        //    }
        //    return item;
        //}

	
    }
}
