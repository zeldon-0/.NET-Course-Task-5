using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;

namespace DAL_EF.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private RetailContext db;
        public ProductRepository(RetailContext context)
        {
            db=context;
        }
        public void Create(Product prod)
        {
            db.Add(prod);
        }

        public void Delete(int id)
        {
            Product toDelete = db.Products.Find(id);
            if (toDelete!=null)
                db.Remove(toDelete);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public void Update(Product prod)
        {
            db.Entry(prod).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}