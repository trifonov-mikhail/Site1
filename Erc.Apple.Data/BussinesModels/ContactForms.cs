using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class ContactForms
    {
        public virtual List<ContactForm> GetAll()
        {
            List<ContactForm> all = new List<ContactForm>();
            using (StoredProcedure sp = new StoredProcedure("ContactForms_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            ContactForm item = new ContactForm(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual ContactForm GetByID(int id)
        {
            ContactForm item = null;
            using (StoredProcedure sp = new StoredProcedure("ContactForms_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new ContactForm(r);
                    }
                }
            }
            return item;
        }

        public virtual ContactForm GetByName(string name)
        {
            ContactForm item = null;
            using (StoredProcedure sp = new StoredProcedure("ContactForms_GetByName"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = name;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new ContactForm(r);
                    }
                }
            }
            return item;
        }

        public virtual int Add(ContactForm item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("ContactForms_AddItem"))
            {
                sp.Params.Add("@Name", System.Data.SqlDbType.NVarChar, 255).Value = item.Name;
                sp.Params.Add("@Subject", System.Data.SqlDbType.NVarChar, 255).Value = item.Subject;
                sp.Params.Add("@To", System.Data.SqlDbType.NVarChar).Value = item.To;
                sp.Params.Add("@CC", System.Data.SqlDbType.NVarChar).Value = item.CC;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public virtual bool Update(ContactForm item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("ContactForms_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@Subject", System.Data.SqlDbType.NVarChar, 255).Value = item.Subject;
                sp.Params.Add("@To", System.Data.SqlDbType.NVarChar).Value = item.To;
                sp.Params.Add("@CC", System.Data.SqlDbType.NVarChar).Value = item.CC;
                sp.Params.Add("@SetForAll", System.Data.SqlDbType.Bit).Value = item.SetForAllForms;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public virtual bool Delete(ContactForm item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("ContactForms_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
