using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;
using System.Linq;

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
            return db.Suppliers
                    .Where(sup => sup.SupplierId == id)
                    .Include(sup => sup.ProductSuppliers)
                    .FirstOrDefault();
        }

        public void Update(Supplier sup)
        {
            if (sup != null)
            {
                var supplier = GetById(sup.SupplierId);
                if (supplier !=null)
                {
                    db.Entry(supplier).CurrentValues.SetValues(sup);
                    db.Entry(supplier).State = EntityState.Modified;
                }
            
                else
                {
                    db.Entry(sup).State = EntityState.Modified;
                }
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}