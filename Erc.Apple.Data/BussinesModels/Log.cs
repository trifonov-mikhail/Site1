using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Erc.Apple.Data
{
    [System.ComponentModel.DataObject()]
	public class Log
    {
        public List<LogMessage> GetAll()
        {
            List<LogMessage> all = new List<LogMessage>();
            using (StoredProcedure sp = new StoredProcedure("Log_GetAll"))
            {
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            LogMessage item = new LogMessage(r);
                            all.Add(item);
                        }
                    }
                }
            }
            return all;
        }

        public LogMessage GetByID(int id)
        {
            LogMessage item = null;
            using (StoredProcedure sp = new StoredProcedure("Log_GetByID"))
            {
				sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                using (SqlDataReader r = (SqlDataReader)sp.ExecuteReader())
                {
                    if (r != null && r.Read())
                    {
                        item = new LogMessage(r);
                    }
                }
            }
            return item;
        }

        public int Add(LogMessage item)
        {
            int newID = 0;
            using (StoredProcedure sp = new StoredProcedure("Log_AddItem"))
            {
                sp.Params.Add("@MessageType", System.Data.SqlDbType.Int).Value = item.MessageType;
                sp.Params.Add("@Source", System.Data.SqlDbType.NVarChar, 255).Value = item.Source;
                sp.Params.Add("@Message", System.Data.SqlDbType.NVarChar).Value = item.Message;
                
                newID = Convert.ToInt32(sp.ExecuteScalar());
            }
            return newID;
        }

        public bool Update(LogMessage item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Log_UpdateItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;
                sp.Params.Add("@MessageType", System.Data.SqlDbType.Int).Value = item.MessageType;
                sp.Params.Add("@Source", System.Data.SqlDbType.NVarChar, 255).Value = item.Source;
                sp.Params.Add("@Message", System.Data.SqlDbType.NVarChar).Value = item.Message;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool Delete(LogMessage item)
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Log_DeleteItem"))
            {
                sp.Params.Add("@ID", System.Data.SqlDbType.Int).Value = item.ID;

                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
        public static bool Clear()
        {
            bool result = false;
            using (StoredProcedure sp = new StoredProcedure("Log_Clear"))
            {
                result = sp.ExecuteNonQuery() > 0;
            }
            return result;
        }
    }

    public enum LogMessageType
    {
        Error,
        Warning,
        Info
    }
}
