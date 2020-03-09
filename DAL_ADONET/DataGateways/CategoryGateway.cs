using DAL_ADONET.Context;
using DAL_ADONET.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DAL_ADONET.Gateways
{
    public class CategoryGateway
    {
        private SqlContext db;
        public CategoryGateway (SqlContext context)
        {
            db = context;
        }

        public void Create(ADOCategory cat)
        {
            if (cat != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "INSERT INTO Categories (Name) VALUES (@CName)",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("CName", cat.Name);
                    com.ExecuteNonQuery();
                }

            }
        }

        public void Delete(ADOCategory cat)
        {
            if (cat != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "DELETE Categories WHERE CategoryId = @CatId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("CatId", cat.CategoryId);
                    com.ExecuteNonQuery();
                }
            }
        }
        public void Update(ADOCategory cat)
        {
            if (cat != null)
            {
                using (SqlCommand com = new SqlCommand(
                    "UPDATE Categories SET Name = @CName WHERE CategoryId = @CatId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("CName", cat.Name);
                    com.Parameters.AddWithValue("CatId", cat.CategoryId);
                    com.ExecuteNonQuery();
                }
            }
        }

        public ADOCategory GetById (int id)
        {
            ADOCategory cat = null;
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM Categories WHERE CategoryId = @CId",
                    db.Connection))
                {
                    com.Parameters.AddWithValue("CId", id);
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        if (reader.Read())
                            cat = new ADOCategory()
                            {
                                CategoryId = (int) reader[0],
                                Name = (string) reader[1]
                    
                            };
                    }
                }
            return cat;
        }

        public IEnumerable<ADOCategory> GetAll()
        {
            List<ADOCategory> cats =new List<ADOCategory>();
            using (SqlCommand com = new SqlCommand(
                    "SELECT * FROM Categories",
                    db.Connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    { 
                        while (reader.Read())
                            cats.Add(new ADOCategory()
                            {
                                CategoryId = (int) reader[0],
                                Name = (string) reader[1]
                            });
                    }
                }
            return cats;
        }
    }
}