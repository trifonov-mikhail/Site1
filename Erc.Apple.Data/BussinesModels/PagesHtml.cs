using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class PagesHtml
    {
        public List<PageHtml> GetAll()
        {
            List<PageHtml> all = new List<PageHtml>();
            using (StoredProcedure sp = new StoredProcedure("PagesHtml_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            PageHtml item = new PageHtml(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public PageHtml GetByName(string name)
        {
            PageHtml item = null;
            using (StoredProcedure sp = new StoredProcedure("PagesHtml_GetByID"))
            {
				sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = name;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new PageHtml(r);
                    }
                }
            }
            return item;
        }

        public bool Add(PageHtml item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("PagesHtml_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = item.Name;
                sp.Params.Add("@Html", System.Data.SqlDbType.NVarChar).Value = item.Html;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Update(PageHtml item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("PagesHtml_UpdateItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = item.Name;
                sp.Params.Add("@Html", System.Data.SqlDbType.NVarChar).Value = item.Html;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(PageHtml item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("PagesHtml_DeleteItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = item.Name;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
