using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class ContentPages
    {
        public List<ContentPage> GetAll()
        {
            List<ContentPage> all = new List<ContentPage>();
            using (StoredProcedure sp = new StoredProcedure("ContentPages_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            ContentPage item = new ContentPage(r);
                            
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public ContentPage GetByID(int id)
        {
            ContentPage item = null;
            using (StoredProcedure sp = new StoredProcedure("ContentPages_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new ContentPage(r);
                    }
                }
            }
            return item;
        }

        public int Add(ContentPage item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("ContentPages_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(ContentPage item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("ContentPages_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(ContentPage item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("ContentPages_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
