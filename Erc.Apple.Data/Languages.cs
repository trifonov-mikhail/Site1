using System;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Languages
    {
        public virtual List<Language> GetAll()
        {
            List<Language> all = new List<Language>();
            using (StoredProcedure sp = new StoredProcedure("Languages_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            Language item = new Language();
                        	item.Code = Convert.ToString(r["Code"]);
							item.Locale = Convert.ToString(r["Locale"]);
							item.Description = Convert.ToString(r["Description"]);
                            
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual Language GetByCode(string code)
        {
            Language item = null;
            using (StoredProcedure sp = new StoredProcedure("Languages_GetByID"))
            {
				sp.Params.Add("@Code", System.Data.SqlDbType.NChar, 2).Value = code;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new Language();
						item.Code = Convert.ToString(r["Code"]);
						item.Locale = Convert.ToString(r["Locale"]);
						item.Description = Convert.ToString(r["Description"]);
                    }
                }
            }
            return item;
        }

		//public string Add(Language item)
		//{
		//    string newID = string.Empty;
		//    using (StoredProcedure sp = new StoredProcedure("Languages_AddItem"))
		//    {
		//        sp.Params.Add("@Code", System.Data.SqlDbType.NChar).Value = item.Code;
		//        sp.Params.Add("@Locale", System.Data.SqlDbType.NChar).Value = item.Locale;

		//        newID = Convert.ToString(sp.ExecuteScalar());
		//    }
		//    return newID;
		//}

		//public bool Update(Language item)
		//{
		//    bool result = false;
		//    using (StoredProcedure sp = new StoredProcedure("Languages_UpdateItem"))
		//    {
		//        sp.Params.Add("@Code", System.Data.SqlDbType.NChar).Value = item.Code;
		//        sp.Params.Add("@Locale", System.Data.SqlDbType.NChar).Value = item.Locale;

		//        result = sp.ExecuteNonQuery() > 0;
		//    }
		//    return result;
		//}

		//public bool Delete(Language item)
		//{
		//    bool result = false;
		//    using (StoredProcedure sp = new StoredProcedure("Languages_DeleteItem"))
		//    {
		//        sp.Params.Add("@Code", System.Data.SqlDbType.Int).Value = item.Code;

		//        result = sp.ExecuteNonQuery() > 0;
		//    }
		//    return result;
		//}
    }
}
