using DAL_ADONET.Context;
using DAL_ADONET.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DAL_ADONET.Gateways
{
    public class SupplierGateway
    {
        private SqlContext db;
        public SupplierGateway (SqlContext context)
        {
            db = context;
        }

        public void Create(ADOSupplier sup)
        {
            if (sup != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "INSERT INTO Suppliers (Name) VALUES (@SName)",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("SName", sup.Name);
                    com.ExecuteNonQuery();
                }

            }
        }

        public void Delete(ADOSupplier sup)
        {
            if (sup != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "DELETE Suppliers WHERE SupplierId = @SupId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("SupId", sup.SupplierId);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void Update(ADOSupplier sup)
        {
            if (sup != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "UPDATE Suppliers SET Name = @SName WHERE SupplierId = @SupId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("SName", sup.Name);
                    com.Parameters.AddWithValue("SupId", sup.SupplierId);
                    com.ExecuteNonQuery();
                }
            }
        }

        public ADOSupplier GetById (int id)
        {
            ADOSupplier sup = null;
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM Suppliers WHERE SupplierId = @SId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("SId", id);
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        if (reader.Read())
                            sup = new ADOSupplier()
                            {
                                SupplierId = (int) reader[0],
                                Name = (string) reader[1]
                    
                            };
                    }
                }
            return sup;
        }

        public IEnumerable<ADOSupplier> GetAll()
        {
            List<ADOSupplier> sups =new List<ADOSupplier>();
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM Suppliers",
                    db.Connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        while (reader.Read())
                            sups.Add(new ADOSupplier()
                            {
                                SupplierId = (int) reader[0],
                                Name = (string) reader[1]
                            });
                    }
                }
            return sups;
        }
    }
}