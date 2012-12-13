using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class HomePageBlocks
    {
        public static int SequenceID = 17;

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

        public virtual List<HomePageBlock> GetAll(string langCode)
        {
            List<HomePageBlock> all = new List<HomePageBlock>();
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_GetAll"))
            {
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = langCode;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            HomePageBlock item = new HomePageBlock();

                            item.ID = Convert.ToInt32(r["ID"]);
                            item.GroupID = Convert.ToInt32(r["GroupID"]);
                            item.LangCode = Convert.ToString(r["LangCode"]);
                            item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                            item.LinkText = Convert.ToString(r["LinkText"]);
                            item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                            item.IsActive = Convert.ToBoolean(r["IsActive"]);
                            item.DateCreated = Convert.ToDateTime(r["DateCreated"]);

                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }
        public virtual HomePageBlock GetByID(int id)
        {
            HomePageBlock item = null;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new HomePageBlock();

                        item.ID = Convert.ToInt32(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                        item.LinkText = Convert.ToString(r["LinkText"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.IsActive = Convert.ToBoolean(r["IsActive"]);
                        item.HasImage = Convert.ToBoolean(r["HasImage"]);
                        item.DateCreated = Convert.ToDateTime(r["DateCreated"]);
                        
                    }
                }
            }
            return item;
        }

        public byte[] GetImage(string langCode, int groupId)
        {
            byte[] item = null;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_GetImage"))
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

        public virtual HomePageBlock GetByLangGroup(string language, int groupId)
        {
            HomePageBlock item = null;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_GetByLangGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new HomePageBlock();

                        item.ID = Convert.ToInt32(r["ID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.LinkUrl = Convert.ToString(r["LinkUrl"]);
                        item.LinkText = Convert.ToString(r["LinkText"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.IsActive = Convert.ToBoolean(r["IsActive"]);
                        item.HasImage = Convert.ToBoolean(r["HasImage"]);
                        item.DateCreated = Convert.ToDateTime(r["DateCreated"]);
                    }
                }
            }
            return item;
        }

        public virtual int Add(HomePageBlock item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_AddItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@ImageFile", System.Data.SqlDbType.VarBinary).Value = item.ImageFile;
                sp.Params.Add("@LinkUrl", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.LinkUrl);
                sp.Params.Add("@LinkText", System.Data.SqlDbType.NVarChar, 255).Value = item.LinkText;
                sp.Params.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;
                sp.Params.Add("@OrderNumber", System.Data.SqlDbType.Int).Value = item.OrderNumber;
                
                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public virtual bool Update(HomePageBlock item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_UpdateItem"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
                sp.Params.Add("@LinkUrl", System.Data.SqlDbType.NVarChar, 255).Value = Tools.FixUrl(item.LinkUrl);
                sp.Params.Add("@LinkText", System.Data.SqlDbType.NVarChar, 255).Value = item.LinkText;
                sp.Params.Add("@IsActive", System.Data.SqlDbType.Bit).Value = item.IsActive;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public virtual bool UpdateImage(int groupID, byte[] image)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_UpdateImage"))
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
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_DeleteImage"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool DeleteGroup(HomePageBlock item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_DeleteGroup"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool SetOrderNumber(int categoryID, int orderNumber)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_SetOrderNumber"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = categoryID;
                sp.Params.Add("@OrderNumber", System.Data.SqlDbType.Int).Value = orderNumber;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        protected List<int> GetOrderedIDs()
        {
            List<int> all = new List<int>();
            using (StoredProcedure sp = new StoredProcedure("HomePageBlocks_GetOrderedIDs"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            int number = Convert.ToInt32(r["GroupID"]);
                            all.Add(number);
                        }
                    }
                }
            }
            return all;
        }
        protected void InitOrderNumbers()
        {
            List<int> all = GetOrderedIDs();
            int i = 0;
            foreach (int id in all)
            {
                SetOrderNumber(id, i++);
            }
        }
        public void MoveUp(int itemID)
        {
            InitOrderNumbers();

            List<int> all = GetOrderedIDs();

            int index = all.IndexOf(itemID);

            if (index > 0)
            {
                SetOrderNumber(all[index], index - 1);
                SetOrderNumber(all[index - 1], index);
            }
        }
        public void MoveDown(int itemID)
        {
            InitOrderNumbers();

            List<int> all = GetOrderedIDs();

            int index = all.IndexOf(itemID);

            if (index >= 0 && index < all.Count - 1)
            {
                SetOrderNumber(all[index], index + 1);
                SetOrderNumber(all[index + 1], index);
            }
        }

    }
}
