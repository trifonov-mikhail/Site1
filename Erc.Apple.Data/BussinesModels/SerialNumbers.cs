using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Erc.Apple.Data.Models;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class SerialNumbers
    {
        public List<SerialNumber> GetAll()
        {
            List<SerialNumber> all = new List<SerialNumber>();
            using (StoredProcedure sp = new StoredProcedure("SerialNumbers_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            SerialNumber item = new SerialNumber();
							
							item.ID = Convert.ToInt32(r["ID"]);
							item.Number = Convert.ToString(r["SerialNumber"]);
							item.ServiceID = NullableConverter.ToInt32(r["ServiceID"]);
							item.AdminID = Convert.ToInt32(r["AdminID"]);
							item.CreatedDate = Convert.ToDateTime(r["CreatedDate"]);
							item.ModifiedDate = NullableConverter.ToDateTime(r["ModifiedDate"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public SerialNumber GetByID(int id)
        {
            SerialNumber item = null;
            using (StoredProcedure sp = new StoredProcedure("SerialNumbers_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
							item = new SerialNumber();
						
							item.ID = Convert.ToInt32(r["ID"]);
							item.Number = Convert.ToString(r["SerialNumber"]);
							item.ServiceID = NullableConverter.ToInt32(r["ServiceID"]);
							item.AdminID = Convert.ToInt32(r["AdminID"]);
							item.CreatedDate = Convert.ToDateTime(r["CreatedDate"]);
							item.ModifiedDate = NullableConverter.ToDateTime(r["ModifiedDate"]);
						
                    }
                }
            }
            return item;
        }

        public int Add(SerialNumber item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("SerialNumbers_AddItem"))
            {
				sp.Params.Add("@SerialNumber", System.Data.SqlDbType.NVarChar, 20).Value = item.Number;
				sp.Params.Add("@ServiceID", System.Data.SqlDbType.Int).Value = item.ServiceID;
				sp.Params.Add("@AdminID", System.Data.SqlDbType.Int).Value = item.AdminID;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(SerialNumber item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SerialNumbers_UpdateItem"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
				sp.Params.Add("@SerialNumber", System.Data.SqlDbType.NVarChar, 20).Value = item.Number;
				sp.Params.Add("@ServiceID", System.Data.SqlDbType.Int).Value = item.ServiceID;
				sp.Params.Add("@AdminID", System.Data.SqlDbType.Int).Value = item.AdminID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(SerialNumber item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SerialNumbers_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
