using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace Erc.Apple.Data
{
	public class iPadActionSerials
	{
		public virtual int Add(iPadActionSerial item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("iPadActionSerial_AddItem"))
			{
				sp.Params.Add("@BuyDate", System.Data.SqlDbType.DateTime).Value = item.BuyDate;
				sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar).Value = item.Email;
				sp.Params.Add("@Serial", System.Data.SqlDbType.NVarChar).Value = item.Serial;
				sp.Params.Add("@Seller", System.Data.SqlDbType.Int).Value = item.Seller;

				newID = Convert.ToInt32(sp.ExecuteScalar());
			}
			return newID;
		}

		public virtual void Delete(iPadActionSerial item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("iPadActionSerial_DeleteItem"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
				try
				{
					sp.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Debug.WriteLine("iPadActionSerial_DeleteItem:" + ex.ToString());
				}
				
			}
		}
		public virtual int Update(iPadActionSerial item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("iPadActionSerial_UpdateItem"))
			{
				Debug.WriteLine(string.Format("id={0}, status={1}", item.ID, item.Status));
				sp.Params.Add("@Status", System.Data.SqlDbType.Int).Value = item.Status;
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
				try
				{
					sp.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Debug.WriteLine("iPadActionSerial_UpdateItem:" + ex.ToString());
				}
				
			}
			return newID;
		}


		public List<iPadActionSerial> GetAll(int statusid, string serial, string email, int seller)
		{
			//if(serial == "0")
			//    return GetAll().Where(s => s.Status == statusid).ToList();
			//else
			//    return GetAll().Where(s => s.Serial == serial).ToList();

			return GetAll().Where(s => (s.Serial == serial  || serial == "0")
				&& (s.Seller == seller  || seller == 0)
				&& (s.Email.ToLowerInvariant() == email || email == "0")
				&& s.Status == statusid).ToList();
		}

		public List<string> GetSerialNumbers()
		{
			List<string> list = new List<string>();
			using (StoredProcedure sp = new StoredProcedure("SELECT distinct Serial FROM iPadActionSerial ORDER BY Serial"))
			{
				sp.command.CommandType = System.Data.CommandType.Text;
				var reader = sp.ExecuteReader();
				if (reader == null) return list;

				while (reader.Read())
				{
					list.Add(reader[0].ToString().ToUpperInvariant());
				}
			}
			return list;
		}

		public List<string> GetEmails()
		{
			List<string> list = new List<string>();
			using (StoredProcedure sp = new StoredProcedure("SELECT distinct Email FROM iPadActionSerial ORDER BY Email"))
			{
				sp.command.CommandType = System.Data.CommandType.Text;
				var reader = sp.ExecuteReader();
				if (reader == null) return list;

				while (reader.Read())
				{
					list.Add(reader[0].ToString().ToLowerInvariant());
				}
			}
			return list;
		}

		public List<ListItem> GetSellers()
		{			
			return GetAll().Select(s => new ListItem(s.SellerName, s.Seller.ToString())).OrderBy(s => s.Text).ToList();
		}

		public List<iPadActionSerial> GetAll()
		{
			List<iPadActionSerial> items = new List<iPadActionSerial>();
			using (StoredProcedure sp = new StoredProcedure("iPadActionSerial_GetAll"))
			{
				var r = sp.ExecuteReader();

				if (r != null)
				{
					while (r.Read())
					{
						iPadActionSerial item = new iPadActionSerial { 
								BuyDate = Convert.ToDateTime(r["BuyDate"]),
							    Email = Convert.ToString(r["Email"]),
								Seller = Convert.ToInt32(r["Seller"]),
								ID = Convert.ToInt32(r["ID"]),
								Serial = Convert.ToString(r["Serial"]),
								SellerName = Convert.ToString(r["SellerName"]),
								Status = Convert.ToInt32(r["Status"])
						};

						items.Add(item);
					}
				}
			}

			return items;
		}
	}
}
