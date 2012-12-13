using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    public class StoredProcedure: IDisposable
    {
        public static string DefaultConnectionString
        {
            get{
                return ConfigurationManager.ConnectionStrings["SiteDBConnectionString"].ConnectionString;
            }
        }
        
        string connectionString;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
        
        public SqlCommand command;
        
        SqlConnection  connection;
        public SqlConnection  Connection
        {
            get {
                return connection;
            }
        }

        SqlTransaction transaction;

        public SqlTransaction Transaction
        {
            get
            {
                return transaction;
            }
        }

        public SqlParameterCollection  Params
        {
            get
            {
                return command.Parameters;
            }
        }
        public SqlParameter  this[string parameterName]
        {
            get { return command.Parameters[parameterName]; }
            set { command.Parameters[parameterName] = value; }
        }

        public string Name{
            get
            {
                return command.CommandText;
            }
            set
            {
                command.CommandText = value;
                command.Parameters.Clear();
            }
        }

        protected bool inTransaction;

        public StoredProcedure(string name)
            : this(name, StoredProcedure.DefaultConnectionString)
        {
            
        }
        
        public StoredProcedure(string name, string connectionString)
        {
            this.connectionString = connectionString;

            connection = new SqlConnection(connectionString);
            command = new SqlCommand(name, connection);
            command.CommandType = CommandType.StoredProcedure;
        }
        
        ~StoredProcedure()
        {
            Dispose(false);
        }
        public int ExecuteNonQuery()
        {
            int result = -1;

            try
            {
                OpenConnection();
                result = command.ExecuteNonQuery();
            }
            finally
            {
                if (!inTransaction)
                {
                    CloseConnection();
                }
            }
            
            return result;
        }
        
        public object ExecuteScalar()
        {
            object result = null;

            try
            {
                OpenConnection();
                result = command.ExecuteScalar();
            }
            finally
            {
                if (!inTransaction)
                {
                    CloseConnection();
                }
            }

            return result;
        }

        public SqlDataReader ExecuteReader()
        {
            SqlDataReader  reader = null;

            try
            {
                this.OpenConnection();
                reader = this.command.ExecuteReader();
            }
            catch (Exception e)
            {
                if (!this.inTransaction)
                {
                    this.CloseConnection();
                }
                throw e;
            }
            return reader;

        }
        
        public DataTable ExecuteTable(string tableName)
        {
            DataTable table = null;

            try
            {
                OpenConnection();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;
                    table = new DataTable(tableName);
                    adapter.Fill(table);
                }
            }
            finally
            {
                if (!inTransaction)
                {
                    CloseConnection();
                }
            }
            return table;
        }

        public SqlTransaction BeginTransaction()
        {
            inTransaction = true;
            OpenConnection();
            transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            return transaction;
        }
        public void CommitTransaction()
        {
            inTransaction = false;
            transaction.Commit();
            CloseConnection();
            command.Transaction = null;
        }
        public void RollbackTransaction()
        {
            inTransaction = false;
            transaction.Rollback();
            CloseConnection();
            command.Transaction = null;
        }
        private void OpenConnection()
        {
            if (connection != null && connection.State != ConnectionState.Open)
                connection.Open();
        }
        private void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch { }
            }
        }
        #region IDisposable Members

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (connection != null)
                        connection.Dispose();
                    if (command != null)
                        command.Dispose();
                    if (transaction != null)
                        transaction.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                
                // Note disposing has been done.
                disposed = true;

            }
        }

        #endregion
    }
}
