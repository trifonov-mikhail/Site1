using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Erc.Apple.Data;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
    public class SeminarRegistrations
    {
        public List<SeminarRegistration> GetAll()
        {
            List<SeminarRegistration> all = new List<SeminarRegistration>();
            using (StoredProcedure sp = new StoredProcedure("SeminarsRegistration_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            SeminarRegistration item = new SeminarRegistration(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }
        public List<SeminarRegistration> GetByType(int typeID)
        {
            return GetByType(typeID, 0);
        }
        public List<SeminarRegistration> GetByType(int typeID, int emailType)
        {
            return GetByType(typeID, emailType, string.Empty);
        }
        public List<SeminarRegistration> GetByType(int typeID, int emailType, string email)
        {
            List<SeminarRegistration> result = new List<SeminarRegistration>();
            List<SeminarRegistration> all = new List<SeminarRegistration>();
            using (StoredProcedure sp = new StoredProcedure("SeminarsRegistration_GetAll"))
            {
                sp.Params.Add("TypeID", SqlDbType.Int).Value = typeID;
                sp.Params.Add("emailType", SqlDbType.Int).Value = emailType;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            SeminarRegistration item = new SeminarRegistration(r);
                            all.Add(item);
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(email))
                result = new List<SeminarRegistration>(all.Where(p => p.Email.ToLower() == email).ToArray());
            else
            {
                result.AddRange(all);
            }
            return result;
        }

        public void DeleteById(SeminarRegistration s)
        {
            if (s != null)
            {
                using (
                    StoredProcedure sp =
                        new StoredProcedure("DELETE FROM SeminarsRegistration WHERE ID=" + s.ID.ToString()))
                {
                    sp.command.CommandType = CommandType.Text;
                    sp.ExecuteNonQuery();
                }
            }
        }


        public List<SeminarRegistration> GetByIds(string[] IDs)
        {
            List<SeminarRegistration> all = new List<SeminarRegistration>();
            string s = string.Join(", ", IDs);

            using (StoredProcedure sp = new StoredProcedure(string.Format("SELECT * FROM SeminarsRegistration WHERE ID in ({0})", s)))
            {
                sp.command.CommandType = CommandType.Text;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            SeminarRegistration item = new SeminarRegistration(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public void UpdateEmailStatus(string[] IDs, int type)
        {
            string s = string.Join(", ", IDs);
            string sql = string.Format(@"UPDATE SeminarsRegistration SET 
                                        SentEmailType=@SentEmailType, 
                                        EmailSent=@EmailSent
                                        WHERE ID in ({0})", s);
            using (StoredProcedure sp = new StoredProcedure(sql))
            {
                sp.command.CommandType = CommandType.Text;
                sp.Params.Add("SentEmailType",SqlDbType.Int).Value = type;
                sp.Params.Add("EmailSent", SqlDbType.DateTime).Value = DateTime.Now;
                sp.ExecuteNonQuery();
            }
        }

        public int Add(SeminarRegistration item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("SeminarsRegistration_AddItem"))
            {
                
                sp.Params.Add("@CompanyName", System.Data.SqlDbType.NVarChar, 255).Value = item.CompanyName;
                sp.Params.Add("@FIO", System.Data.SqlDbType.NVarChar, 255).Value = item.FIO;
                sp.Params.Add("@JobTitle", System.Data.SqlDbType.NVarChar, 255).Value = item.JobTitle;
                sp.Params.Add("@JobAction", System.Data.SqlDbType.VarChar, 20).Value = item.JobAction;
                sp.Params.Add("@Email", System.Data.SqlDbType.NVarChar, 255).Value = item.Email;
                sp.Params.Add("@Site", System.Data.SqlDbType.NVarChar, 255).Value = item.Site;
                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }
    }
}
