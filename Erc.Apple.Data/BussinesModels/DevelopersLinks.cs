using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
    public class DevelopersLinks
    {
        public static int SequenceID = 13;

        public static int GetNextGroupID()
        {
            int result = -1;
            try
            {
                using (StoredProcedure sp = new StoredProcedure("GetNextSeqeuenceValue"))
                {
                    sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = SequenceID;
                    result = Convert.ToInt32(sp.ExecuteScalar());
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public virtual List<DevelopersLink> GetAll(string langCode)
        {
            List<DevelopersLink> all = new List<DevelopersLink>();
            using (StoredProcedure sp = new StoredProcedure("DevelopersLinks_GetAll"))
            {
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            DevelopersLink item = new DevelopersLink(r);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }
        public virtual DevelopersLink GetByID(int id)
        {
            DevelopersLink item = null;
            using (StoredProcedure sp = new StoredProcedure("DevelopersLinks_GetByID"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new DevelopersLink(r);
                    }
                }
            }
            return item;
        }

        public virtual DevelopersLink GetByLangGroup(string language, int groupId)
        {
            DevelopersLink item = null;
            using (StoredProcedure sp = new StoredProcedure("DevelopersLinks_GetByLangGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new DevelopersLink(r);
                    }
                }
            }
            return item;
        }

        public virtual int Add(DevelopersLink item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("DevelopersLinks_AddItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;

                sp.Params.Add("@LinkUrl", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.LinkUrl);
                sp.Params.Add("@LinkText", System.Data.SqlDbType.NVarChar, 255).Value = item.LinkText;
                sp.Params.Add("@OrderNumber", System.Data.SqlDbType.Int).Value = item.OrderNumber;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public virtual bool Update(DevelopersLink item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("DevelopersLinks_UpdateItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;

                sp.Params.Add("@LinkUrl", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.LinkUrl);
                sp.Params.Add("@LinkText", System.Data.SqlDbType.NVarChar, 255).Value = item.LinkText;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public bool DeleteGroup(DevelopersLink item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("DevelopersLinks_DeleteGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
