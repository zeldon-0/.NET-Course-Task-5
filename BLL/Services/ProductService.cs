using System;
using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Models;
using DAL_EF.Interfaces;
using BLL.Mappers;
using DAL_EF.Entities;
using System.Linq;
namespace BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _uow;
        public ProductService (IUnitOfWork uow)
        {
            _uow=uow;
        }

        public void Create(ProductDTO prod)
        {
            _uow.Products.Create(BLLMapper.Map<Product>(prod));
            _uow.Save();
        }

        public void Delete(ProductDTO prod)
        {
            _uow.Products.Delete(prod.ProductId);
            _uow.Save();
        }
        public void Update(ProductDTO prod)
        {
            _uow.Products.Update(BLLMapper.Map<Product>(prod));
            _uow.Save();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            return _uow.Products.GetAll()
                    .Select(product => BLLMapper.Map<ProductDTO>(product));
        }

        public IEnumerable<ProductDTO> GetByCategory(CategoryDTO cat)
        {
            var category=_uow.Categories.GetById(cat.CategoryId);
            return BLLMapper.Map<CategoryDTO>(category).Products;
        }

        public ProductDTO GetById(int id)
        {
            return BLLMapper.Map<ProductDTO>
                    (_uow.Products.GetById(id));
        }

        public IEnumerable<ProductDTO> GetBySupplier(SupplierDTO sup)
        {
            var supplier=_uow.Suppliers.GetById(sup.SupplierId);
            return BLLMapper.Map<SupplierDTO>(supplier).Products;
        }

        public ProductDTO GetWithMaxPrice()
        {
            var products = _uow.Products.GetAll();

            int max = products.Max(p => p.Price);

            return products.Where(p => p.Price == max)
                .Select(product => BLLMapper.Map<ProductDTO>(product))
                .FirstOrDefault();

        }
        public ProductDTO GetWithMinPrice()
        {
            var products = _uow.Products.GetAll();

            int min = products.Min(p => p.Price);

            return products.Where(p => p.Price == min)
                .Select(product => BLLMapper.Map<ProductDTO>(product))
                .FirstOrDefault();

        }

        private bool disposed=false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _uow.Dispose();
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