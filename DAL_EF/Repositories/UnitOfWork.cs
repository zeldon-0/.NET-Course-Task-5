using System;
using DAL_EF.Interfaces;
using DAL_EF.Entities;
using DAL_EF.EF;
namespace DAL_EF.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private RetailContext db;
        public UnitOfWork (RetailContext context)
        {
            db=context;
        }
        private ProductRepository productRepository;
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        private CategoryRepository categoryRepository;
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }
        private SupplierRepository supplierRepository;
        public IRepository<Supplier> Suppliers
        {
            get
            {
                if (supplierRepository == null)
                    supplierRepository = new SupplierRepository(db);
                return supplierRepository;
            }
        }
        private ProductSupplierRepository productSupplierRepository;
        public IRepository<ProductSupplier> ProductSuppliers
        {
            get
            {
                if (productSupplierRepository == null)
                    productSupplierRepository = new ProductSupplierRepository(db);
                return productSupplierRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    db.Dispose();
            }
            this.disposed=true;

        } 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}