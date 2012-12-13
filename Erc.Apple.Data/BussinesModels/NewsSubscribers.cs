using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class NewsSubscribers
    {
        public List<NewsSubscriber> GetAll()
        {
            List<NewsSubscriber> all = new List<NewsSubscriber>();
            using (StoredProcedure sp = new StoredProcedure("NewsSubscribers_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            NewsSubscriber item = new NewsSubscriber(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public NewsSubscriber GetByID(int id)
        {
            NewsSubscriber item = null;
            using (StoredProcedure sp = new StoredProcedure("NewsSubscribers_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new NewsSubscriber(r);
                    }
                }
            }
            return item;
        }

        public int Add(NewsSubscriber item)
        {
            if (!Tools.CheckEmail(item.Email))
                throw new InvalidOperationException("Invalid e-mail address");
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("NewsSubscribers_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = item.Email;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(NewsSubscriber item)
        {
            if (!Tools.CheckEmail(item.Email))
                throw new InvalidOperationException("Invalid e-mail address");
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("NewsSubscribers_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = item.Email;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(NewsSubscriber item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("NewsSubscribers_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
