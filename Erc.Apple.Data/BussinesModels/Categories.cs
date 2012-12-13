using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Categories
    {
		public static int SequenceID = 1;

		public static int GetNextCategoryGroupID()
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

		public List<Category> GetAllByLanguage(string language)
		{
			List<Category> all = new List<Category>();
			using (StoredProcedure sp = new StoredProcedure("Categories_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Category item = new Category();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
							item.ParentID = Convert.ToInt32(r["ParentID"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

		public Category GetByID(int id)
        {
            Category item = null;
            using (StoredProcedure sp = new StoredProcedure("Categories_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new Category();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
						item.ParentID = Convert.ToInt32(r["ParentID"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
                    }
                }
            }
            return item;
        }

		public Category GetByLangGroup(string language, int groupId)
		{
			Category item = null;
			using (StoredProcedure sp = new StoredProcedure("Categories_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
                    if (r != null && r.Read())
                    {
                        item = new Category();
                        item.ID = Convert.ToInt32(r["ID"]);
                        item.LangCode = Convert.ToString(r["LangCode"]);
                        item.Name = Convert.ToString(r["Name"]);
                        item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
                        item.ParentID = Convert.ToInt32(r["ParentID"]);
                        item.GroupID = Convert.ToInt32(r["GroupID"]);
                    }
                    //else
                    //{
                    //    item = new Category();
                    //    item.LangCode = language;
                    //    item.GroupID = groupId;
                    //}
				}
			}
			return item;
		}

        public int AddUpdate(Category item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("Categories_AddUpdateItem"))
            {
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				sp.Params.Add("OrderNumber", System.Data.SqlDbType.Int).Value = item.OrderNumber;
				sp.Params.Add("ParentID", System.Data.SqlDbType.Int).Value = item.ParentID;
				sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				sp.Params.Add("GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
                newID = Convert.ToInt32(sp.ExecuteScalar());
            	item.ID = newID;
            }
            return newID;
        }

		public bool DeleteGroup(Category item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Categories_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}

        public bool SetOrderNumber(int categoryID,int orderNumber)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Categories_SetOrderNumber"))
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
            using (StoredProcedure sp = new StoredProcedure("Categories_GetOrderedIDs"))
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
        public void MoveUp(int categoryID)
        {
            InitOrderNumbers();

            List<int> all = GetOrderedIDs();

            int index = all.IndexOf(categoryID);

            if (index > 0)
            {
                SetOrderNumber(all[index], index - 1);
                SetOrderNumber(all[index-1], index);
            }
        }
        public void MoveDown(int categoryID)
        {
            InitOrderNumbers();

            List<int> all = GetOrderedIDs();

            int index = all.IndexOf(categoryID);

            if (index >= 0 && index < all.Count - 1)
            {
                SetOrderNumber(all[index], index + 1);
                SetOrderNumber(all[index + 1], index);
            }
        }

		//public List<Category> GetAll()
		//{
		//    List<Category> all = new List<Category>();
		//    using (StoredProcedure sp = new StoredProcedure("Categories_GetAll"))
		//    {
		//        using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
		//        {
		//            if (r != null)
		//            {
		//                while (r.Read())
		//                {
		//                    Category item = new Category();
		//                    item.ID = Convert.ToInt32(r["ID"]);
		//                    item.LangCode = Convert.ToString(r["LangCode"]);
		//                    item.Name = Convert.ToString(r["Name"]);
		//                    item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
		//                    item.ParentID = Convert.ToInt32(r["ParentID"]);
		//                    //LoadTranslate(item);
		//                    all.Add(item);
		//                }
		//            }
		//        }
		//    }
		//    return all;
		//}

		//public bool Update(Category item)
		//{
		//    bool result = false;
		//    using (StoredProcedure sp = new StoredProcedure("Categories_UpdateItem"))
		//    {
		//        sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
		//        sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
		//        sp.Params.Add("OrderNumber", System.Data.SqlDbType.Int).Value = item.OrderNumber;
		//        sp.Params.Add("ParentID", System.Data.SqlDbType.Int).Value = item.ParentID;
		//        sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;

		//        result = sp.ExecuteNonQuery() > 0;
		//    }
		//    return result;
		//}

		//public bool Delete(Category item)
		//{
		//    bool result = false;
		//    using (StoredProcedure sp = new StoredProcedure("Categories_DeleteItem"))
		//    {
		//        sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

		//        result = sp.ExecuteNonQuery() > 0;
		//    }
		//    return result;
		//}

		//public void LoadTranslate(Category item)
		//{
		//    using (StoredProcedure sp = new StoredProcedure("GetTranslates_ByItemIDGroupID"))
		//    {
		//        sp.Params.Add("@ItemID", System.Data.SqlDbType.Int).Value = item.ID;
		//        sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = (int)Translate.Type.CategoryText;
		//        using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
		//        {
		//            if (r != null)
		//            {
		//                DataTable table = new DataTable();
		//                table.Load(r);
		//                for (int i = 0; i < table.Rows.Count; i++)
		//                {
		//                    string lang = table.Rows[i]["LangCode"] != DBNull.Value ? table.Rows[i]["LangCode"].ToString() : string.Empty;
		//                    string text = table.Rows[i]["Text"] != DBNull.Value ? table.Rows[i]["Text"].ToString() : string.Empty; 
		//                    if(!item.Translate.ContainsKey(lang))
		//                    {
		//                        item.Translate.Add(lang, text);
		//                    }
		//                }
		//            }
		//        }

		//    }
		//}
    }
}
