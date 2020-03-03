using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;

namespace DAL_EF.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private RetailContext db;
        public SupplierRepository(RetailContext context)
        {
            db=context;
        }
        public void Create(Supplier sup)
        {
            db.Add(sup);
        }

        public void Delete(int id)
        {
            Supplier toDelete = db.Suppliers.Find(id);
            if (toDelete!=null)
                db.Remove(toDelete);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers;
        }

        public Supplier GetById(int id)
        {
            return db.Suppliers.Find(id);
        }

        public void Update(Supplier sup)
        {
            db.Entry(sup).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}