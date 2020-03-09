using DAL_ADONET.Context;
using DAL_ADONET.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DAL_ADONET.Gateways
{
    public class ProductSupplierGateway
    {
        private SqlContext db;
        public ProductSupplierGateway (SqlContext context)
        {
            db = context;
        }

        public void Create(ADOProductSupplier ps)
        {
            if (ps != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "INSERT INTO ProductSuppliers (ProductId, SupplierId) VALUES (@PId, @SId)",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("PId", ps.ProductId);
                    com.Parameters.AddWithValue("SId", ps.SupplierId);
                    com.ExecuteNonQuery();
                }

            }
        }

        public void Delete(ADOProductSupplier ps)
        {
            if (ps != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "DELETE ProductSuppliers WHERE PSId = @psId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("psId", ps.PSId);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void Update(ADOProductSupplier ps)
        {
            if (ps != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "UPDATE ProductSuppliers SET ProductId = @PId, SupplierId = @SId WHERE PSId = @psId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("PId", ps.ProductId);
                    com.Parameters.AddWithValue("SId", ps.SupplierId);
                    com.Parameters.AddWithValue("psId", ps.PSId);
                    com.ExecuteNonQuery();
                }
            }
        }

        public ADOProductSupplier GetById (int id)
        {
            ADOProductSupplier ps = null;
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM ProductSuppliers WHERE PSId = @psId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("psId", id);
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        if (reader.Read())
                            ps = new ADOProductSupplier()
                            {
                                PSId = (int) reader[0],
                                ProductId = (int) reader[1],
                                SupplierId = (int) reader[2]
                    
                            };
                    }
                }
            return ps;
        }

        public IEnumerable<ADOProductSupplier> GetAll (int id)
        {
            List<ADOProductSupplier> ps = new List<ADOProductSupplier>();
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM ProductSuppliers",
                    db.Connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        while (reader.Read())
                            ps.Add(new ADOProductSupplier()
                            {
                                PSId = (int) reader[0],
                                ProductId = (int) reader[1],
                                SupplierId = (int) reader[2]
                    
                            });
                    }
                }
            return ps;
        }

    }
}