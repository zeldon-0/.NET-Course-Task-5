using System;
using BLL.Models;
using System.Collections.Generic;
namespace BLL.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        void Create(SupplierDTO sup);
        void Delete(SupplierDTO sup);
        void Update(SupplierDTO sup);

        SupplierDTO GetById(int id);
        IEnumerable<SupplierDTO> GetAll();
        IEnumerable<SupplierDTO> GetCategorySuppliers(CategoryDTO cat);
        IEnumerable<SupplierDTO> GetProductSuppliers(ProductDTO prod);
    }
}