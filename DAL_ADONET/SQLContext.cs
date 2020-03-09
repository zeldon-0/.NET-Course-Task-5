using System.Data.SqlClient;
using System;
namespace DAL_ADONET.Context
{
    public class SqlContext :IDisposable
    {
        public SqlConnection Connection {get; set;}

        public SqlContext()
        {
            Connection = new SqlConnection("Server=localhost; Database=Task5_; Trusted_Connection=True;");
            Connection.Open();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    Connection.Dispose();
            }
            this.disposed=true;

        } 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}