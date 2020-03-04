using System;
using BLL.Models;
using System.Collections.Generic;
namespace BLL.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        void Create(CategoryDTO cat);
        void Delete(CategoryDTO cat);
        void Update(CategoryDTO cat);

        CategoryDTO GetById(int id);
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO GetProductCategory (ProductDTO prod);
        IEnumerable<CategoryDTO> GetSupplierCategories(SupplierDTO sup);

    }
}