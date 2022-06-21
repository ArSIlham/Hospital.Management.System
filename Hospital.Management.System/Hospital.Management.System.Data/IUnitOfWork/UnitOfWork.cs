using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.IUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly string _connectionString;

        private SqlTransaction sqlTransaction;
        private SqlConnection sqlConnection;

        public UnitOfWork(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            sqlConnection = new SqlConnection(_connectionString);
        }

        public SqlTransaction BeginTransaction()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction();
            }

            return sqlTransaction;
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public SqlTransaction GetTransaction()
        {
            return sqlTransaction;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        sqlTransaction = null;
                    }
                    sqlConnection.Close();
                    disposed = true;
                }
            }
            catch
            {
                throw new Exception("Sql error");
            }
        }

        public void SaveChanges()
        {
            sqlTransaction.Commit();
            sqlConnection.Close();
            sqlTransaction = null;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
