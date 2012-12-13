using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Products
    {

		public static int SequenceID = 2;

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

		public List<Product> GetAllByLanguage(string language)
		{
			List<Product> all = new List<Product>();
			using (StoredProcedure sp = new StoredProcedure("Products_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Product item = new Product();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
							item.CategoryID = Convert.ToInt32(r["CategoryID"]);
							item.Url = Convert.ToString(r["Url"]);
							item.ImageLenght = Convert.ToInt32(r["ImageLenght"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

		public List<Product> GetAllByLanguageCategory(string language, int categoryId)
		{
			List<Product> all = new List<Product>();
			using (StoredProcedure sp = new StoredProcedure("Products_GetAllByLanguageCategory"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				sp.Params.Add("@CategoryID", SqlDbType.Int).Value = categoryId;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Product item = new Product();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
							item.CategoryID = Convert.ToInt32(r["CategoryID"]);
							item.Url = Convert.ToString(r["Url"]);
							item.ImageLenght = Convert.ToInt32(r["ImageLenght"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

		public Product GetByID(int id)
		{
			Product item = null;
			using (StoredProcedure sp = new StoredProcedure("Products_GetByID"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Product();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
						item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
						item.CategoryID = Convert.ToInt32(r["CategoryID"]);
						item.Url = Convert.ToString(r["Url"]);
						item.ImageLenght = Convert.ToInt32(r["ImageLenght"]);
					}
				}
			}
			return item;
		}

		public Product GetByLangGroup(string language, int groupId)
		{
			Product item = null;
			using (StoredProcedure sp = new StoredProcedure("Products_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Product();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
						item.OrderNumber = Convert.ToInt32(r["OrderNumber"]);
						item.CategoryID = Convert.ToInt32(r["CategoryID"]);
						item.Url = Convert.ToString(r["Url"]);
						item.ImageLenght = Convert.ToInt32(r["ImageLenght"]);

					}
				}
			}
			return item;
		}

		public int AddUpdate(Product item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Products_AddUpdateItem"))
			{
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				sp.Params.Add("GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
				sp.Params.Add("OrderNumber", System.Data.SqlDbType.Int).Value = item.OrderNumber;
				sp.Params.Add("CategoryID", System.Data.SqlDbType.Int).Value = item.CategoryID;
				sp.Params.Add("Url", System.Data.SqlDbType.NVarChar).Value = Tools.FixUrl(item.Url);
				newID = Convert.ToInt32(sp.ExecuteScalar());
				item.ID = newID;
			}
			return newID;
		}

		public bool DeleteGroup(Product item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Products_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}

		public Product GetProductImage(int id)
		{
			Product item = null;
			using (StoredProcedure sp = new StoredProcedure("Products_GetByIDWithImage"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					DataTable table = new DataTable();
					table.Load(r);
					if (table.Rows.Count > 0)
					{
						DataRow row = table.Rows[0];
						item = new Product();
						item.ID = Convert.ToInt32(row["ID"]);
						item.LangCode = Convert.ToString(row["LangCode"]);
						item.Name = Convert.ToString(row["Name"]);
						item.GroupID = Convert.ToInt32(row["GroupID"]);
						item.OrderNumber = Convert.ToInt32(row["OrderNumber"]);
						item.CategoryID = Convert.ToInt32(row["CategoryID"]);
						item.Url = Convert.ToString(row["Url"]);
						item.ImageLenght = Convert.ToInt32(row["ImageLenght"]);
						try
						{
							item.Image = (byte[])row["Image"];
							item.ImageName = Convert.ToString(row["ImageName"]);
							item.ImageType = Convert.ToString(row["ImageType"]);
						}
						catch (Exception)
						{
								
						}
						
					}
				}
			}
			return item;
		}

		public Product GetProductImageByGroupID(string langCode, int groupId)
		{
			Product item = null;
			using (StoredProcedure sp = new StoredProcedure("Products_GetProductImageByGroupID"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NVarChar).Value = langCode;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					DataTable table = new DataTable();
					table.Load(r);
					if (table.Rows.Count > 0)
					{
						DataRow row = table.Rows[0];
						item = new Product();
						item.ID = Convert.ToInt32(row["ID"]);
						item.LangCode = Convert.ToString(row["LangCode"]);
						item.Name = Convert.ToString(row["Name"]);
						item.GroupID = Convert.ToInt32(row["GroupID"]);
						item.OrderNumber = Convert.ToInt32(row["OrderNumber"]);
						item.CategoryID = Convert.ToInt32(row["CategoryID"]);
						item.Url = Convert.ToString(row["Url"]);
						item.ImageLenght = Convert.ToInt32(row["ImageLenght"]);
						try
						{
							item.Image = (byte[])row["Image"];
							item.ImageName = Convert.ToString(row["ImageName"]);
							item.ImageType = Convert.ToString(row["ImageType"]);
						}
						catch (Exception)
						{

						}

					}
				}
			}
			return item;
		}

		public bool UpdateImageByGroupID(Product item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Products_UpdateImage"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
				sp.Params.Add("@Image", System.Data.SqlDbType.Image).Value = item.Image;
				sp.Params.Add("@ImageName", System.Data.SqlDbType.NVarChar).Value = item.ImageName;
				sp.Params.Add("@ImageType", System.Data.SqlDbType.NVarChar).Value = item.ImageType;
				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}

		public bool DeleteImageByGroupID(int groupID)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Products_DeleteImage"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupID;
				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}

        public bool SetOrderNumber(int categoryID, int orderNumber)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Products_SetOrderNumber"))
            {
                sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = categoryID;
                sp.Params.Add("@OrderNumber", System.Data.SqlDbType.Int).Value = orderNumber;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        protected List<int> GetOrderedIDs(int categoryID)
        {
            List<int> all = new List<int>();
            using (StoredProcedure sp = new StoredProcedure("Products_GetOrderedIDsByCategory"))
            {
                sp.Params.Add("@CategoryID", System.Data.SqlDbType.Int).Value = categoryID;
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
        protected void InitOrderNumbers(int categoryID)
        {
            List<int> all = GetOrderedIDs(categoryID);
            int i = 0;
            foreach (int id in all)
            {
                SetOrderNumber(id, i++);
            }
        }
        public void MoveUp(int productID,int categoryID)
        {
            InitOrderNumbers(categoryID);

            List<int> all = GetOrderedIDs(categoryID);

            int index = all.IndexOf(productID);

            if (index > 0)
            {
                SetOrderNumber(all[index], index - 1);
                SetOrderNumber(all[index - 1], index);
            }
        }
        public void MoveDown(int productID, int categoryID)
        {
            InitOrderNumbers(categoryID);

            List<int> all = GetOrderedIDs(categoryID);

            int index = all.IndexOf(productID);

            if (index >= 0 && index < all.Count - 1)
            {
                SetOrderNumber(all[index], index + 1);
                SetOrderNumber(all[index + 1], index);
            }
        }
    }
}
