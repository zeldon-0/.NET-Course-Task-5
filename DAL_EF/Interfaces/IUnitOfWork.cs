using System;
using DAL_EF.Entities;
namespace DAL_EF.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Product> Products {get;}
        IRepository<Category> Categories {get;}
        IRepository<Supplier> Suppliers {get;}
        IRepository<ProductSupplier> ProductSuppliers {get;}
        void Save();
    }
}