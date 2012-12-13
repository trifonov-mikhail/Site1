using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class SuccessStories
    {
        public static int SequenceID = 18;

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

        public virtual List<SuccessStory> GetAll(string language)
        {
            List<SuccessStory> all = new List<SuccessStory>();
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            SuccessStory item = new SuccessStory();

                            item.ID = Convert.ToInt32(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Title = Convert.ToString(r["Title"]);
                            item.Text = Convert.ToString(r["Text"]);
                            item.Date = NullableConverter.ToDateTime(r["Date"]);
                            item.PdfFileName = Convert.ToString(r["PdfFileName"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual List<SuccessStory> GetByLang(string langCode)
        {
            List<SuccessStory> all = new List<SuccessStory>();
            using (StoredProcedure sp = new StoredProcedure("SuccessStory_GetByLang"))
            {
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;

                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            SuccessStory item = new SuccessStory();

                            item.ID = Convert.ToInt32(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Title = Convert.ToString(r["Title"]);
                            item.Text = Convert.ToString(r["Text"]);
                            item.Date = NullableConverter.ToDateTime(r["Date"]);
                            item.HasImage = Convert.ToBoolean(r["HasImage"]);
                            item.HasPdfFile = Convert.ToBoolean(r["HasPdfFile"]);
                            item.PdfFileName = Convert.ToString(r["PdfFileName"]);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual SuccessStory GetByID(int id)
        {
            SuccessStory item = null;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new SuccessStory();

                        item.ID = Convert.ToInt32(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Title = Convert.ToString(r["Title"]);
                        item.Text = Convert.ToString(r["Text"]);
                        item.Date = NullableConverter.ToDateTime(r["Date"]);
                        item.HasImage = Convert.ToBoolean(r["HasImage"]);
                        item.HasPdfFile = Convert.ToBoolean(r["HasPdfFile"]);
                        item.PdfFileName = Convert.ToString(r["PdfFileName"]);
                    }
                }
            }
            return item;
        }

        public byte[] GetImage(string langCode, int groupId)
        {
            byte[] item = null;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_GetImage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        object o = r["ImageFile"];
                        if (o != DBNull.Value)
                            item = (byte[])o;
                    }
                }
            }
            return item;
        }

        public SuccessStory GetPdfFile(string langCode, int groupId)
        {
            SuccessStory item = null;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_GetPdfFile"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        object o = r["PdfFile"];
                        if (o != DBNull.Value)
                        {
                            item = new SuccessStory();
                            item.PdfFile = (byte[])o;
                            item.PdfFileName = Convert.ToString(r["PdfFileName"]);
                        }
                    }
                }
            }
            return item;
        }


        public virtual SuccessStory GetByLangGroup(string language, int groupId)
        {
            SuccessStory item = null;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_GetByLangGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new SuccessStory();

                        item.ID = Convert.ToInt32(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Title = Convert.ToString(r["Title"]);
                        item.Text = Convert.ToString(r["Text"]);
                        item.Date = NullableConverter.ToDateTime(r["Date"]);
                        item.HasImage = Convert.ToBoolean(r["HasImage"]);
                        item.HasPdfFile = Convert.ToBoolean(r["HasPdfFile"]);
                        item.PdfFileName = Convert.ToString(r["PdfFileName"]);

                    }
                }
            }
            return item;
        }

        public virtual int Add(SuccessStory item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_AddItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Title", System.Data.SqlDbType.NVarChar,255).Value = item.Title;
                sp.Params.Add("@ImageFile", System.Data.SqlDbType.VarBinary).Value = item.ImageFile;
                sp.Params.Add("@PdfFile", System.Data.SqlDbType.VarBinary).Value = item.PdfFile;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;
                sp.Params.Add("@Date", System.Data.SqlDbType.DateTime).Value = item.Date;
                sp.Params.Add("@PdfFileName", System.Data.SqlDbType.DateTime).Value = item.PdfFileName;

                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public virtual bool Update(SuccessStory item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_UpdateItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Title", System.Data.SqlDbType.NVarChar, 255).Value = item.Title;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;
                sp.Params.Add("@Date", System.Data.SqlDbType.DateTime).Value = item.Date;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public virtual bool UpdateImage(int groupID, byte[] image)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_UpdateImage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;
                sp.Params.Add("@ImageFile", System.Data.SqlDbType.VarBinary).Value = image;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }


        public virtual bool UpdatePdfFile(int groupID, string langCode, byte[] pdffile, string PdfFileName)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_UpdatePdfFile"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NVarChar).Value = langCode;
                sp.Params.Add("@PdfFile", System.Data.SqlDbType.VarBinary).Value = pdffile;
                sp.Params.Add("@PdfFileName", System.Data.SqlDbType.NVarChar).Value = PdfFileName;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public virtual bool DeleteImage(int groupID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_DeleteImage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool DeleteGroup(SuccessStory item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_DeleteGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public bool DeletePdfFile(string LangCode, int GroupID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("SuccessStories_DeletePdfFile"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NVarChar).Value = LangCode;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

#warning This method should be changed
        public void ShowOnPages(int newID, List<int> pagesIDs)
        {
            //RemoveFromAllPages(newID);

            using (StoredProcedure sp = new StoredProcedure("Stories_AddToPage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = newID;
                SqlParameter pid = sp.Params.Add("@PageID", System.Data.SqlDbType.Int);

                foreach (int id in pagesIDs)
                {
                    pid.Value = id;
                    sp.ExecuteNonQuery();
                }
            }
        }

        
        public List<int> GetContentPagesIDs(int StoryID)
        {
            List<int> all = new List<int>();
            using (StoredProcedure sp = new StoredProcedure("Stories_GetContentPagesIDs"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = StoryID;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            int id = Convert.ToInt32(r["ID"]);
                            all.Add(id);
                        }
                    }
                }
            }
            return all;
        }
        public List<int> GetContentSectionsIDs(int StoryID)
        {
            List<int> all = new List<int>();
            using (StoredProcedure sp = new StoredProcedure("Stories_GetContentSectionsIDs"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = StoryID;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            int id = Convert.ToInt32(r["ID"]);
                            all.Add(id);
                        }
                    }
                }
            }
            return all;
        }

        
    }
}
