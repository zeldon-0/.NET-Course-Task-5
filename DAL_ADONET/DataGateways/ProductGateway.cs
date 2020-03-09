using DAL_ADONET.Context;
using DAL_ADONET.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DAL_ADONET.Gateways
{
    public class ProductGateway
    {
        private SqlContext db;
        public ProductGateway (SqlContext context)
        {
            db = context;
        }

        public void Create(ADOProduct prod)
        {
            if (prod != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "INSERT INTO Products (Name, CategoryID) VALUES (@PName, @CatId)",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("PName", prod.Name);
                    com.Parameters.AddWithValue("CatId", prod.CategoryId);
                    com.ExecuteNonQuery();
                }

            }
        }

        public void Delete(ADOProduct prod)
        {
            if (prod != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "DELETE Products WHERE ProductId = @ProdId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("ProdId", prod.ProductId);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void Update(ADOProduct prod)
        {
            if (prod != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "UPDATE Products SET Name = @PName, CategoryId = @CatId WHERE ProductId = @ProdId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("PName", prod.Name);
                    com.Parameters.AddWithValue("CatId", prod.CategoryId);
                    com.Parameters.AddWithValue("ProdId", prod.ProductId);
                    com.ExecuteNonQuery();
                }
            }
        }

        public ADOProduct GetById (int id)
        {
            ADOProduct prod = null;
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM Products WHERE ProductId = @PId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("PId", id);
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        if (reader.Read())
                            prod = new ADOProduct()
                            {
                                ProductId = (int) reader[0],
                                Name = (string) reader[1],
                                Price = (int) reader[2],
                                CategoryId = (int) reader[3]
                            };
                    }
                }
            return prod;
        }

        public IEnumerable<ADOProduct> GetAll()
        {
            List<ADOProduct> prods =new List<ADOProduct>();
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM Products",
                    db.Connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        while (reader.Read())
                            prods.Add(new ADOProduct()
                            {
                                ProductId = (int) reader[0],
                                Name = (string) reader[1],
                                Price = (int) reader[2],
                                CategoryId = (int) reader[3]
                            });
                    }
                }
            return prods;
        }
    }
}