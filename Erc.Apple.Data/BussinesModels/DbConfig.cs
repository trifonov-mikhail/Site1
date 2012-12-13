using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class DbConfig
    {
        public static List<DbConfigItem> GetAll()
        {
            List<DbConfigItem> all = new List<DbConfigItem>();
            using (StoredProcedure sp = new StoredProcedure("DbConfig_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            DbConfigItem item = new DbConfigItem();

                            item.Name = Convert.ToString(r["Name"]);
                            item.Value = Convert.ToString(r["Value"]);
                            item.DateCreated = Convert.ToDateTime(r["DateCreated"]);
                            
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public static DbConfigItem GetByID(string id)
        {
            DbConfigItem item = null;
            using (StoredProcedure sp = new StoredProcedure("DbConfig_GetByID"))
            {
				sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar,255).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new DbConfigItem();

                        item.Name = Convert.ToString(r["Name"]);
                        item.Value = Convert.ToString(r["Value"]);
                        item.DateCreated = Convert.ToDateTime(r["DateCreated"]);
                    }
                }
            }
            return item;
        }
        public static string GetItemValue(string id)
        {
            DbConfigItem item = GetByID(id);

            if (item != null && !string.IsNullOrEmpty(item.Value))
            {
                return item.Value;
            }

            return string.Empty;
        }

        public static bool Add(DbConfigItem item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("DbConfig_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;
                sp.Params.Add("@Value", System.Data.SqlDbType.NVarChar).Value = item.Value;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public static bool Update(DbConfigItem item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("DbConfig_UpdateItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;
                sp.Params.Add("@Value", System.Data.SqlDbType.NVarChar).Value = item.Value;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public static bool Save(DbConfigItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return Save(item.Name, item.Value);
        }
        public static bool Save(string name,string value)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("DbConfig_AddUpdateItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = name;
                sp.Params.Add("@Value", System.Data.SqlDbType.NVarChar).Value = value;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public static bool Delete(DbConfigItem item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("DbConfig_DeleteItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
