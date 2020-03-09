using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;
using System.Linq;

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
            return db.Products
                    .Where(prod => prod.ProductId == id)
                    .Include(prod => prod.Category)
                    .FirstOrDefault();
        }

        public void Update(Product prod)
        {
            if (prod != null)
            {
                var product = GetById(prod.ProductId);
                if (product !=null)
                {
                    db.Entry(product).CurrentValues.SetValues(prod);
                    db.Entry(product).State = EntityState.Modified;
                }
            
                else
                {
                    db.Entry(prod).State = EntityState.Modified;
                }
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}