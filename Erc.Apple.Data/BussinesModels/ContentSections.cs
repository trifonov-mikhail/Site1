using System;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class ContentSections
    {
        public List<ContentSection> GetAll()
        {
            List<ContentSection> all = new List<ContentSection>();
            using (StoredProcedure sp = new StoredProcedure("ContentSections_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            ContentSection item = new ContentSection(r);
                            
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public ContentSection GetByID(int id)
        {
            ContentSection item = null;
            using (StoredProcedure sp = new StoredProcedure("ContentSections_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new ContentSection(r);
                    }
                }
            }
            return item;
        }

        public int Add(ContentSection item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("ContentSections_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(ContentSection item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("ContentSections_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(ContentSection item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("ContentSections_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
