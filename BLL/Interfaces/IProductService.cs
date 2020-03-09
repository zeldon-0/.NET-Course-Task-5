using System;
using BLL.Models;
using System.Collections.Generic;
namespace BLL.Interfaces
{
    public interface IProductService : IDisposable
    {
        void Create(ProductDTO prod);
        void Delete(ProductDTO prod);
        void Update(ProductDTO prod);

        ProductDTO GetById(int id);
        IEnumerable<ProductDTO> GetAll();
        IEnumerable<ProductDTO> GetByCategory(CategoryDTO cat);
        IEnumerable<ProductDTO> GetBySupplier(SupplierDTO sup);

        ProductDTO GetWithMaxPrice();
        ProductDTO GetWithMinPrice();
    }
}