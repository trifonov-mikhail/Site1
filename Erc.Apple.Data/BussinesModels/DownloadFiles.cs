using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Erc.Apple.Data;
using System.IO;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
    public class DownloadFiles
    {
        public virtual void Add(DownloadFile item)
        {
            /*
             *  @TypeID int,
		        @Name nvarchar(255),
		        @Description nvarchar(500),
		        @FileName nvarchar(255),
		        @MimeType nvarchar(100)
		
             */
            try
            {
                using (StoredProcedure sp = new StoredProcedure("DownloadFile_Add"))
                {
                    sp.Params.Add("ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    
                    sp.Params.Add("TypeID", System.Data.SqlDbType.Int).Value = item.TypeId;
                    sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
                    sp.Params.Add("Description", System.Data.SqlDbType.NVarChar).Value = item.Description;
                    sp.Params.Add("FileName", System.Data.SqlDbType.NVarChar).Value = item.FileName;
                    sp.Params.Add("MimeType", System.Data.SqlDbType.NVarChar).Value = item.MimeType;
                    sp.ExecuteNonQuery();
                    item.ID = (int)sp.Params["ID"].Value;
                }
            }catch(Exception ex)
            {
				throw;
            }
        }


        public void Update(DownloadFile item)
        {
            try
            {
                using (StoredProcedure sp = new StoredProcedure("DownloadFile_Update"))
                {
                    sp.Params.Add("ID", System.Data.SqlDbType.Int).Value = item.ID;
                    sp.Params.Add("TypeID", System.Data.SqlDbType.Int).Value = item.TypeId;
                    sp.Params.Add("Name", System.Data.SqlDbType.NVarChar).Value = item.Name;
                    sp.Params.Add("Description", System.Data.SqlDbType.NVarChar).Value = item.Description;
                    sp.Params.Add("FileName", System.Data.SqlDbType.NVarChar).Value = item.FileName;
                    sp.Params.Add("MimeType", System.Data.SqlDbType.NVarChar).Value = item.MimeType;
                    sp.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }

        public List<DownloadFile> GetAll()
        {
            List<DownloadFile> all = new List<DownloadFile>();
            using (StoredProcedure sp = new StoredProcedure("DownloadFile_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader) sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            DownloadFile item = new DownloadFile();
                            item.ID = Convert.ToInt32(r["ID"]);
                            item.TypeId = Convert.ToInt32(r["TypeId"]);
                            item.Name = Convert.ToString(r["Name"]);
                            item.FileName = Convert.ToString(r["FileName"]);
                            item.MimeType = Convert.ToString(r["MimeType"]);
                            item.Description = Convert.ToString(r["Description"]);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public void Delete(DownloadFile d)
        {
			string path = "";
            if(d!= null)
            {
				
                using (
                    StoredProcedure sp =
                        new StoredProcedure("DELETE FROM DownloadFiles WHERE ID=" + d.ID.ToString()))
                {
                    sp.command.CommandType = CommandType.Text;
                    sp.ExecuteNonQuery();
                }
            }
        }

        public List<DownloadFile> GetByTypeId(int typeid)
        {
            var all = GetAll();
            if (typeid == 0)
                return all;
            List<DownloadFile> res = all.Where(p => p.TypeId == typeid).ToList();
            return res;
        }

        public DownloadFile GetById(int id)
        {
            DownloadFile item = new DownloadFile();
            using (StoredProcedure sp = new StoredProcedure("DownloadFiles_GetById"))
            {
                sp.Params.Add("ID", SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            
                            item.ID = Convert.ToInt32(r["ID"]);
                            item.TypeId = Convert.ToInt32(r["TypeId"]);
                            item.Name = Convert.ToString(r["Name"]);
                            item.FileName = Convert.ToString(r["FileName"]);
                            item.MimeType = Convert.ToString(r["MimeType"]);
                            item.Description = Convert.ToString(r["Description"]);
                            
                        }
                    }
                }
            }
            return item;
        }
    }
}
