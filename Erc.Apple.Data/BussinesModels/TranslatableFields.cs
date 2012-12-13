using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
    public class TranslatableTexts
    {
        public static int SequenceID = 16;

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

        public virtual List<TranslatableText> GetAll()
        {
            List<TranslatableText> all = new List<TranslatableText>();
            using (StoredProcedure sp = new StoredProcedure("TranslatableTexts_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            TranslatableText item = new TranslatableText();

                            item.ID = Convert.ToString(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Text = Convert.ToString(r["Value"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }
        public virtual List<TranslatableText> GetAllByLang(string language)
        {
            List<TranslatableText> all = new List<TranslatableText>();
            using (StoredProcedure sp = new StoredProcedure("TranslatableTexts_GetAllByLang"))
            {
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            TranslatableText item = new TranslatableText();

                            item.ID = Convert.ToString(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Text = Convert.ToString(r["Value"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual TranslatableText GetByLangGroup(string language, int groupId)
        {
            TranslatableText item = null;
            using (StoredProcedure sp = new StoredProcedure("TranslatableTexts_GetByLangGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new TranslatableText();

                        item.ID = Convert.ToString(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Text = Convert.ToString(r["Value"]);
                    }
                }
            }
            return item;
        }

        public virtual int Add(TranslatableText item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("TranslatableTexts_AddItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.NVarChar,50).Value = item.ID;
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public virtual bool Update(TranslatableText item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("TranslatableTexts_UpdateItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        
        public bool DeleteGroup(TranslatableText item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("TranslatableTexts_DeleteGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }
}
