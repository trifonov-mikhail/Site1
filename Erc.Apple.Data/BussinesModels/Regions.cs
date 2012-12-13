using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Regions
    {
		public static int SequenceID = 3;

		public static int GetNextRegionGroupID()
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

		public List<Region> GetAllByLanguage(string language)
		{
			List<Region> all = new List<Region>();
			using (StoredProcedure sp = new StoredProcedure("Regions_GetAllByLanguage"))
			{
				sp.Params.Add("@LangCode", SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							Region item = new Region();
							item.ID = Convert.ToInt32(r["ID"]);
							item.LangCode = Convert.ToString(r["LangCode"]);
							item.Name = Convert.ToString(r["Name"]);
							item.GroupID = Convert.ToInt32(r["GroupID"]);
							all.Add(item);
						}
					}
				}
			}
			return all;
		}

		public Region GetByID(int id)
		{
			Region item = null;
			using (StoredProcedure sp = new StoredProcedure("Regions_GetByID"))
			{
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Region();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
					}
				}
			}
			return item;
		}

		public Region GetByLangGroup(string language, int groupId)
		{
			Region item = null;
			using (StoredProcedure sp = new StoredProcedure("Regions_GetByLangGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = groupId;
				sp.Params.Add("@LangCode", System.Data.SqlDbType.NChar).Value = language;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null && r.Read())
					{
						item = new Region();
						item.ID = Convert.ToInt32(r["ID"]);
						item.LangCode = Convert.ToString(r["LangCode"]);
						item.Name = Convert.ToString(r["Name"]);
						item.GroupID = Convert.ToInt32(r["GroupID"]);
					}
				}
			}
			return item;
		}

		public int AddUpdate(Region item)
		{
			int newID = 0;
			using (StoredProcedure sp = new StoredProcedure("Regions_AddUpdateItem"))
			{
				sp.Params.Add("LangCode", System.Data.SqlDbType.NChar).Value = item.LangCode;
				sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
				sp.Params.Add("GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;
				newID = Convert.ToInt32(sp.ExecuteScalar());
				item.ID = newID;
			}
			return newID;
		}

		public bool DeleteGroup(Region item)
		{
			bool result = false;
			using (StoredProcedure sp = new StoredProcedure("Regions_DeleteGroup"))
			{
				sp.Params.Add("@GroupID", System.Data.SqlDbType.Int).Value = item.GroupID;

				result = sp.ExecuteNonQuery() > 0;
			}
			return result;
		}
    }
}
/*
 * 
яебюярнонкэ
юбрнмнлмю пеяосак╡йю йпхл
б╡ммхжэйю
бнкхмяэйю
дм╡опноерпнбяэйю
днмежэйю
фхрнлхпяэйю
гюйюпоюряэйю
гюонп╡гэйю
╡бюмн-тпюмй╡бяэйю
йх╞б
йх╞бяэйю
й╡пнбнцпюдяэйю
ксцюмяэйю
кэб╡бяэйю
лхйнкю╞бяэйю
ндеяэйю
онкрюбяэйю
п╡бмемяэйю
ясляэйю
репмно╡кэяэйю
уюпй╡бяэйю
уепянмяэйю
улекэмхжэйю
вепйюяэйю
вепм╡бежэйю
вепм╡ц╡бяэйю
 * 
яебюярнонкэ
юбрнмнлмюъ пеяосакхйю йпшл
бхмхжйюъ
бнкшмяйюъ
дмхопноерпнбяйюъ
днмежйюъ
фхрнлхпяйюъ
гюйюпоюряйюъ
гюонпнфяйюъ
╡бюмн-тпюмйнбяйюъ
йхеб
йхебяйюъ
йхпнбнцпюдяйюъ
ксцюмяйюъ
кэбнбяйюъ
мхйнкюебяйюъ
ндеяяйюъ
онкрюбяйюъ
пнбемяйюъ
ясляйюъ
репмнонкэяйюъ
уюпйнбяйюъ
уепянмяйюъ
улекэмхжйюъ
вепйюяйюъ
вепмнбхжйюъ
вепм╡цнбяйюъ
 * 
 * 
 
 
 AUTONOMOUS REPUBLIC of CRIMEA
CHERKюSKю
CHERNIHIVSKю
CHERNIVETSKю
DNIPROPETROVSKю
DONETSKю
IVюNO-FRюNKIVSKю
KHARKIVSKю
KHERSONSKю
KHMELNYTSKю
KIROVOHRюDSKю
KYIV
KYIVSKю
LUHюNSKю
LVIVSKю
MYKOLюIVSKю
ODESKю
POLTюVSKю
RIVNENSKю
SEVюSTOPOL
SUMSKю
TERNOPILSKю
VINNYTSKю
VOLYNSKю
ZAKюRPюTSKю
ZAPORIZKю
ZHYTOMYRSKю
 
 */
