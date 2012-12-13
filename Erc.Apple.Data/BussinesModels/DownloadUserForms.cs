using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erc.Apple.Data;
using System.Data.SqlClient;
using System.Data;

namespace Erc.Apple.Data.BussinesModels
{
    public class DownloadUserForms
    {
        public DownloadUserForm GetByIds(int id)
        {
            DownloadUserForm res = new DownloadUserForm();
            using (StoredProcedure sp = new StoredProcedure(string.Format("SELECT * FROM DownloadUserForms WHERE ID = ", id)))
            {
                sp.command.CommandType = CommandType.Text;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            
                        }
                    }
                }
            }
            return res;
        }

        public string InsertForm(DownloadUserForm duf)
        {
			bool ifExists = false;
			using (StoredProcedure sp = new StoredProcedure("SELECT * FROM DownloadUserForms WHERE FileID=@FileID AND Email = @Email AND CreateDate > @CreateDate"))
			{
				sp.command.CommandType = CommandType.Text;
				sp.Params.Add("Email", SqlDbType.NVarChar).Value = duf.Email.ToLower();
				sp.Params.Add("FileID", SqlDbType.Int).Value = duf.FileID;
				sp.Params.Add("CreateDate", SqlDbType.DateTime).Value = DateTime.Now.AddHours(-1);
				var reader = sp.ExecuteReader();
				if (reader != null && reader.Read())
				{
					ifExists = true;
					duf.Url = reader.GetString(reader.GetOrdinal("Url"));
				}
			}
			if (ifExists) return duf.Url;
            using (
                    StoredProcedure sp =
						new StoredProcedure(@"INSERT INTO DownloadUserForms(FirstName, LastName, Email, FileID, Url) 
                                            VALUES(@FirstName, @LastName, @Email, @FileID, @Url)"))
            {
                sp.command.CommandType = CommandType.Text;
				sp.Params.Add("FirstName", SqlDbType.NVarChar).Value = duf.FirstName;
				sp.Params.Add("LastName", SqlDbType.NVarChar).Value = duf.LastName;
				sp.Params.Add("Email", SqlDbType.NVarChar).Value = duf.Email.ToLower();
				sp.Params.Add("FileID", SqlDbType.Int).Value = duf.FileID;
				duf.Url = Guid.NewGuid().ToString();
				sp.Params.Add("Url", SqlDbType.NVarChar).Value = duf.Url;
                sp.ExecuteNonQuery();
            }
			return duf.Url;
        }

		public DownloadUserForm GetByGuid(string url)
		{
			DownloadUserForm res = new DownloadUserForm();
			using (StoredProcedure sp = new StoredProcedure(string.Format("SELECT * FROM DownloadUserForms WHERE Url = @Url")))
			{
				sp.command.CommandType = CommandType.Text;
				sp.Params.Add("Url", SqlDbType.NVarChar).Value = url;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						while (r.Read())
						{
							res.Url = r.GetString(r.GetOrdinal("Url"));
							res.FileID = r.GetInt32(r.GetOrdinal("FileID"));
						}
					}
				}
			}
			return res;
		}

		public List<DownloadUserForm> GetByFileID(int id)
		{
			List<DownloadUserForm> res = new List<DownloadUserForm>();
			using (StoredProcedure sp = new StoredProcedure(string.Format("SELECT * FROM DownloadUserForms WHERE FileID = @FileID")))
			{
				sp.command.CommandType = CommandType.Text;
				sp.Params.Add("FileID", SqlDbType.NVarChar).Value = id;
				using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
				{
					if (r != null)
					{
						
						while (r.Read())
						{
							DownloadUserForm d = new DownloadUserForm();
							d.Url = r.GetString(r.GetOrdinal("Url"));
							d.FileID = r.GetInt32(r.GetOrdinal("FileID"));
							d.ID = r.GetInt32(r.GetOrdinal("ID"));
							d.Email = r.GetString(r.GetOrdinal("Email"));
							d.FirstName = r.GetString(r.GetOrdinal("FirstName"));
							d.LastName = r.GetString(r.GetOrdinal("LastName"));
							res.Add(d);
						}
						
					}
				}
			}
			return res;
		}
	}

}
