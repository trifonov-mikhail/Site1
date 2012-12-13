using System;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class StatusRequests
    {
        public List<StatusRequest> GetAll()
        {
            List<StatusRequest> all = new List<StatusRequest>();
            using (StoredProcedure sp = new StoredProcedure("StatusRequests_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            StatusRequest item = new StatusRequest(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public List<StatusRequest> GetByStatus(string status)
        {
            List<StatusRequest> all = new List<StatusRequest>();
            using (StoredProcedure sp = new StoredProcedure("StatusRequests_GetByStatus"))
            {
                sp.Params.Add("@Status", System.Data.SqlDbType.NVarChar, 5).Value = status;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            StatusRequest item = new StatusRequest(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public StatusRequest GetByID(int id)
        {
            StatusRequest item = null;
            using (StoredProcedure sp = new StoredProcedure("StatusRequests_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new StatusRequest(r);
                    }
                }
            }
            return item;
        }

        public int Add(StatusRequest item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("StatusRequests_AddItem"))
            {
                sp.Params.Add("@Status", System.Data.SqlDbType.NVarChar, 5).Value = item.Status;
                sp.Params.Add("@CompanyName", System.Data.SqlDbType.NVarChar, 255).Value = item.CompanyName;
                sp.Params.Add("@ContactName", System.Data.SqlDbType.NVarChar, 255).Value = item.ContactName;
                sp.Params.Add("@Address", System.Data.SqlDbType.NVarChar, 255).Value = item.Address;
                sp.Params.Add("@Phone", System.Data.SqlDbType.VarChar, 20).Value = item.Phone;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = item.Email;

                sp.Params.Add("@IsPartner", System.Data.SqlDbType.Bit).Value = item.IsPartner;
                sp.Params.Add("@IsServicePartner", System.Data.SqlDbType.Bit).Value = item.IsServicePartner;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(StatusRequest item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("StatusRequests_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@Status", System.Data.SqlDbType.NVarChar, 5).Value = item.Status;
                sp.Params.Add("@CompanyName", System.Data.SqlDbType.NVarChar, 255).Value = item.CompanyName;
                sp.Params.Add("@ContactName", System.Data.SqlDbType.NVarChar, 255).Value = item.ContactName;
                sp.Params.Add("@Address", System.Data.SqlDbType.NVarChar, 255).Value = item.Address;
                sp.Params.Add("@Phone", System.Data.SqlDbType.VarChar, 20).Value = item.Phone;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = item.Email;

                sp.Params.Add("@IsPartner", System.Data.SqlDbType.Bit).Value = item.IsPartner;
                sp.Params.Add("@IsServicePartner", System.Data.SqlDbType.Bit).Value = item.IsServicePartner;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(StatusRequest item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("StatusRequests_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
