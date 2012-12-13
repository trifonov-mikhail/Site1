using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Specializations
    {
		public static int SequenceID = 7;

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

		public List<Specialization> GetAllByLanguage(string language)
		{
			List<Specialization> all = new List<Specialization>();
			using (StoredProcedure sp = new StoredProcedure("Specializations_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
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

		public List<Specialization> GetAllByLanguageFilter(string language)
		{
			List<Specialization> all = new List<Specialization>();
			Specialization item = new Specialization();
			item.GroupID = 0;
			item.ID = 0;
			item.LangCode = language;
			item.Name = "Все";
			all.Add(item);
			all.AddRange(GetAllByLanguage(language));
			return all;
		}

		public Specialization GetByID(int id)
		{
			Specialization item = null;
			using (StoredProcedure sp = new StoredProcedure("Specializations_GetByID"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Specialization();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.Description = Convert.ToString(r["Description"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
					}
				}
			}
			return item;
		}

		public Specialization GetByLangGroup(string language, int groupId)
		{
			Specialization item = null;
			using (StoredProcedure sp = new StoredProcedure("Specializations_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Specialization();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.Description = Convert.ToString(r["Description"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
					}
				}
			}
			return item;
		}

		public int AddUpdate(Specialization item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Specializations_AddUpdateItem"))
			{
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				if (!string.IsNullOrEmpty(item.Description))
				{
					sp.Params.Add("Description", System.Data.SqlDbType.NVarChar).Value = item.Description;	
				}
				sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				sp.Params.Add("GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
				newID = Convert.ToInt32(sp.ExecuteScalar());
				item.ID = newID;
			}
			return newID;
		}

		public bool DeleteGroup(Specialization item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Specializations_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
		
    }
}
