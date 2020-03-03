using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;

namespace DAL_EF.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private RetailContext db;
        public CategoryRepository(RetailContext context)
        {
            db=context;
        }
        public void Create(Category cat)
        {
            db.Add(cat);
        }

        public void Delete(int id)
        {
            Category toDelete = db.Categories.Find(id);
            if (toDelete!=null)
                db.Remove(toDelete);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category GetById(int id)
        {
            return db.Categories.Find(id);
        }

        public void Update(Category cat)
        {
            db.Entry(cat).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}