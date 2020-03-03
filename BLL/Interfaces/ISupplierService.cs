using System;
using BLL.Models;
using System.Collections.Generic;
namespace BLL.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        void Create(SupplierDTO prod);
        void Delete(SupplierDTO prod);
        void Update(SupplierDTO prod);

        SupplierDTO GetById(int id);
        IEnumerable<SupplierDTO> GetAll();
        IEnumerable<SupplierDTO> GetByCategory(CategoryDTO cat);
    }
}