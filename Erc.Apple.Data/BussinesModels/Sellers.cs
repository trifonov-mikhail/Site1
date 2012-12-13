using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Erc.Apple.Data.BussinesModels
{
	[System.ComponentModel.DataObject()]
	public class Sellers
	{
		public static int Add(Seller item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Seller_AddItem"))
			{
				sp.Params.Add("@Name", System.Data.SqlDbType.DateTime).Value = item.Name;
				
				newID = Convert.ToInt32(sp.ExecuteScalar());
			}
			return newID;
		}

		public static List<Seller> GetAll()
		{
			List<Seller> items = new List<Seller>();
			using (StoredProcedure sp = new StoredProcedure("Seller_GetAll"))
			{
				var r = sp.ExecuteReader();
				
				if (r != null)
				{
					while (r.Read())
					{
						Seller item = new Seller
						{
							ID = Convert.ToInt32(r["ID"]),
							Name = Convert.ToString(r["Name"])
						};

						items.Add(item);
					}
				}
			}

			return items;
		}
	}
}
