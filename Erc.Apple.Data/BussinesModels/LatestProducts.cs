using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class LatestProducts
    {
        public static int SequenceID = 15;

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

        public virtual List<LatestProduct> GetAll(string language)
        {
            List<LatestProduct> all = new List<LatestProduct>();
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            LatestProduct item = new LatestProduct();

                            item.ID = Convert.ToInt32(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Title = Convert.ToString(r["Title"]);
                            item.Notice = Convert.ToString(r["Notice"]);
                            item.Text = Convert.ToString(r["Text"]);
                            item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                            item.LinkText = Convert.ToString(r["LinkText"]);
                            item.Link2Url = Convert.ToString(r["Link2Url"]);
                            item.Link2Text = Convert.ToString(r["Link2Text"]);
                            item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                            item.IsActive = Convert.ToBoolean(r["IsActive"]);
                            item.ImagePosition = Convert.ToInt32(r["ImagePosition"]);
                            item.Date = NullableConverter.ToDateTime(r["Date"]);
                            item.DateCreated = Convert.ToDateTime(r["DateCreated"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }
        public virtual List<LatestProduct> GetByLangForPage(string langCode, int pageID)
        {
            List<LatestProduct> all = new List<LatestProduct>();
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetByLangForPage"))
            {
                sp.Params.Add("@PageID", System.Data.SqlDbType.Int).Value = pageID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;

                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            LatestProduct item = new LatestProduct();

                            item.ID = Convert.ToInt32(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Title = Convert.ToString(r["Title"]);
                            item.Notice = Convert.ToString(r["Notice"]);
                            item.Text = Convert.ToString(r["Text"]);
                            item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                            item.LinkText = Convert.ToString(r["LinkText"]);
                            item.Link2Url = Convert.ToString(r["Link2Url"]);
                            item.Link2Text = Convert.ToString(r["Link2Text"]);
                            item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                            item.IsActive = Convert.ToBoolean(r["IsActive"]);
                            item.ImagePosition = Convert.ToInt32(r["ImagePosition"]);
                            item.Date = NullableConverter.ToDateTime(r["Date"]);
                            item.DateCreated = Convert.ToDateTime(r["DateCreated"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual List<LatestProduct> GetByLangForSection(string langCode, int sectionID)
        {
            List<LatestProduct> all = new List<LatestProduct>();
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetByLangForSection"))
            {
                sp.Params.Add("@SectionID", System.Data.SqlDbType.Int).Value = sectionID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;

                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            LatestProduct item = new LatestProduct();

                            item.ID = Convert.ToInt32(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.Title = Convert.ToString(r["Title"]);
                            item.Notice = Convert.ToString(r["Notice"]);
                            item.Text = Convert.ToString(r["Text"]);
                            item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                            item.LinkText = Convert.ToString(r["LinkText"]);
                            item.Link2Url = Convert.ToString(r["Link2Url"]);
                            item.Link2Text = Convert.ToString(r["Link2Text"]);
                            item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                            item.IsActive = Convert.ToBoolean(r["IsActive"]);
                            item.ImagePosition = Convert.ToInt32(r["ImagePosition"]);
                            item.Date = NullableConverter.ToDateTime(r["Date"]);
                            item.DateCreated = Convert.ToDateTime(r["DateCreated"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public virtual LatestProduct GetByID(int id)
        {
            LatestProduct item = null;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new LatestProduct();

                        item.ID = Convert.ToInt32(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Title = Convert.ToString(r["Title"]);
                        item.Notice = Convert.ToString(r["Notice"]);
                        item.Text = Convert.ToString(r["Text"]);
                        item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                        item.LinkText = Convert.ToString(r["LinkText"]);
                        item.Link2Url = Convert.ToString(r["Link2Url"]);
                        item.Link2Text = Convert.ToString(r["Link2Text"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.HasImage = Convert.ToBoolean(r["HasImage"]);
                        item.IsActive = Convert.ToBoolean(r["IsActive"]);
                        item.ImagePosition = Convert.ToInt32(r["ImagePosition"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.Date = NullableConverter.ToDateTime(r["Date"]);
                        item.DateCreated = Convert.ToDateTime(r["DateCreated"]);
                    }
                }
            }
            return item;
        }

        public byte[] GetImage(string langCode, int groupId)
        {
            byte[] item = null;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetImage"))
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

        public virtual LatestProduct GetByLangGroup(string language, int groupId)
        {
            LatestProduct item = null;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetByLangGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new LatestProduct();

                        item.ID = Convert.ToInt32(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Title = Convert.ToString(r["Title"]);
                        item.Notice = Convert.ToString(r["Notice"]);
                        item.Text = Convert.ToString(r["Text"]);
                        item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                        item.LinkText = Convert.ToString(r["LinkText"]);
                        item.Link2Url = Convert.ToString(r["Link2Url"]);
                        item.Link2Text = Convert.ToString(r["Link2Text"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.HasImage = Convert.ToBoolean(r["HasImage"]);
                        item.IsActive = Convert.ToBoolean(r["IsActive"]);
                        item.ImagePosition = Convert.ToInt32(r["ImagePosition"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.Date = NullableConverter.ToDateTime(r["Date"]);
                        item.DateCreated = Convert.ToDateTime(r["DateCreated"]);
                    }
                }
            }
            return item;
        }

        public virtual int Add(LatestProduct item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_AddItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Title", System.Data.SqlDbType.NVarChar,255).Value = item.Title;
                sp.Params.Add("@ImageFile", System.Data.SqlDbType.VarBinary).Value = item.ImageFile;
                sp.Params.Add("@Notice", System.Data.SqlDbType.NVarChar, 1024).Value = item.Notice;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;

                sp.Params.Add("@LinkUrl", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.LinkUrl);
                sp.Params.Add("@LinkText", System.Data.SqlDbType.NVarChar, 255).Value = item.LinkText;
                sp.Params.Add("@Link2Url", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.Link2Url);
                sp.Params.Add("@Link2Text", System.Data.SqlDbType.NVarChar, 255).Value = item.Link2Text;
                sp.Params.Add("@ImagePosition", System.Data.SqlDbType.Int).Value = item.ImagePosition;

                sp.Params.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;
                sp.Params.Add("@Date", System.Data.SqlDbType.DateTime).Value = item.Date;

                sp.Params.Add("@OrderNumber", System.Data.SqlDbType.Int).Value = item.OrderNumber;
                
                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public virtual bool Update(LatestProduct item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_UpdateItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@Title", System.Data.SqlDbType.NVarChar, 255).Value = item.Title;

                sp.Params.Add("@Notice", System.Data.SqlDbType.NVarChar, 1024).Value = item.Notice;
                sp.Params.Add("@Text", System.Data.SqlDbType.NVarChar).Value = item.Text;

                sp.Params.Add("@LinkUrl", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.LinkUrl);
                sp.Params.Add("@LinkText", System.Data.SqlDbType.NVarChar, 255).Value = item.LinkText;
                sp.Params.Add("@Link2Url", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.Link2Url);
                sp.Params.Add("@Link2Text", System.Data.SqlDbType.NVarChar, 255).Value = item.Link2Text;
                sp.Params.Add("@ImagePosition", System.Data.SqlDbType.Int).Value = item.ImagePosition;

                sp.Params.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;
                sp.Params.Add("@Date", System.Data.SqlDbType.DateTime).Value = item.Date;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public virtual bool UpdateImage(int groupID, byte[] image)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_UpdateImage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;
                sp.Params.Add("@ImageFile", System.Data.SqlDbType.VarBinary).Value = image;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public virtual bool DeleteImage(int groupID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_DeleteImage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool DeleteGroup(LatestProduct item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_DeleteGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public void ShowOnPages(int newID, List<int> pagesIDs)
        {
            RemoveFromAllPages(newID);

            using (StoredProcedure sp = new StoredProcedure("LatestProducts_AddToPage"))
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
        public void ShowInSections(int newID, List<int> sectionsIDs)
        {
            RemoveFromAllSections(newID);
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_AddToSection"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = newID;
                SqlParameter pid = sp.Params.Add("@SectionID", System.Data.SqlDbType.Int);

                foreach (int id in sectionsIDs)
                {
                    pid.Value = id;
                    sp.ExecuteNonQuery();
                }
            }
        }

        public bool RemoveFromAllPages(int newID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_RemoveFromAllPages"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = newID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public bool RemoveFromAllSections(int newID)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_RemoveFromAllSections"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = newID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public List<int> GetContentPagesIDs(int LatestProductID)
        {
            List<int> all = new List<int>();
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetContentPagesIDs"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = LatestProductID;
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
        public List<int> GetContentSectionsIDs(int LatestProductID)
        {
            List<int> all = new List<int>();
            using (StoredProcedure sp = new StoredProcedure("LatestProducts_GetContentSectionsIDs"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = LatestProductID;
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
