using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class AdminPages
    {
        public virtual List<AdminPage> GetAll()
        {
            List<AdminPage> all = new List<AdminPage>();
            using (StoredProcedure sp = new StoredProcedure("AdminPages_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            AdminPage item = new AdminPage(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }
        public List<AdminPage> GetByParent(int parentID)
        {
            List<AdminPage> all = new List<AdminPage>();
            using (StoredProcedure sp = new StoredProcedure("AdminPages_GetByParentID"))
            {
                sp.Params.Add("@ParentID", System.Data.SqlDbType.Int).Value = parentID;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            AdminPage item = new AdminPage(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public AdminPage GetByID(int id)
        {
            AdminPage item = null;
            using (StoredProcedure sp = new StoredProcedure("AdminPages_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new AdminPage(r);
                    }
                }
            }
            return item;
        }
        public AdminPage GetRoot()
        {
            AdminPage item = null;
            using (StoredProcedure sp = new StoredProcedure("AdminPages_GetRoot"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new AdminPage(r);
                    }
                }
            }
            return item;
        }

        public int Add(AdminPage item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("AdminPages_AddItem"))
            {
                sp.Params.Add("@ParentID", System.Data.SqlDbType.Int).Value = item.ParentID;
                sp.Params.Add("@Title", System.Data.SqlDbType.NVarChar, 50).Value = item.Title;
                sp.Params.Add("@Url", System.Data.SqlDbType.NVarChar, 250).Value = item.Url;
                sp.Params.Add("@Control", System.Data.SqlDbType.NVarChar, 250).Value = item.Control;
                sp.Params.Add("@OrderID", System.Data.SqlDbType.Int).Value = item.OrderID;
                sp.Params.Add("@Active", System.Data.SqlDbType.Bit).Value = item.Active;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(AdminPage item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("AdminPages_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@ParentID", System.Data.SqlDbType.Int).Value = item.ParentID;
                sp.Params.Add("@Title", System.Data.SqlDbType.NVarChar, 50).Value = item.Title;
                sp.Params.Add("@Url", System.Data.SqlDbType.NVarChar, 250).Value = item.Url;
                sp.Params.Add("@Control", System.Data.SqlDbType.NVarChar, 250).Value = item.Control;
                sp.Params.Add("@OrderID", System.Data.SqlDbType.Int).Value = item.OrderID;
                sp.Params.Add("@Active", System.Data.SqlDbType.Bit).Value = item.Active;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(AdminPage item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("AdminPages_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
