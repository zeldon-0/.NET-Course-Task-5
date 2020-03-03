using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;

namespace DAL_EF.Repositories
{
    public class ProductSupplierRepository : IRepository<ProductSupplier>
    {
        private RetailContext db;
        public ProductSupplierRepository(RetailContext context)
        {
            db=context;
        }
        public void Create(ProductSupplier ps)
        {
            db.Add(ps);
        }

        public void Delete(int id)
        {
            ProductSupplier toDelete = db.ProductSuppliers.Find(id);
            if (toDelete!=null)
                db.Remove(toDelete);
        }

        public IEnumerable<ProductSupplier> GetAll()
        {
            return db.ProductSuppliers;
        }

        public ProductSupplier GetById(int id)
        {
            return db.ProductSuppliers.Find(id);
        }

        public void Update(ProductSupplier ps)
        {
            db.Entry(ps).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }


    }
}