using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
    public class Admins
    {
        public List<Admin> GetAll()
        {
            List<Admin> all = new List<Admin>();
            using (StoredProcedure sp = new StoredProcedure("Admins_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            Admin item = new Admin(r);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public Admin GetByID(int id)
        {
            Admin item = null;
            using (StoredProcedure sp = new StoredProcedure("Admins_GetByID"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new Admin(r);
                    }
                }
            }
            return item;
        }

        public int Add(Admin item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("Admins_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = item.Name;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 100).Value = item.Email;
                sp.Params.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = item.Password;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(Admin item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Admins_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 100).Value = item.Name;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 100).Value = item.Email;
                sp.Params.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = item.Password;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(Admin item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Admins_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Login(string email, string password)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
                {
                    using (StoredProcedure sp = new StoredProcedure("Admins_FindItem"))
                    {
                        sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 100).Value = email;
                        sp.Params.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = password;

                        result = Convert.ToInt32(sp.ExecuteScalar()) > 0;
                    }
                }
            }
            catch { }
            return result;
        }
    }
}
