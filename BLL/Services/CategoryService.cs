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
    public class CategoryService: ICategoryService
    {
         private readonly IUnitOfWork _uow;
        public CategoryService (IUnitOfWork uow)
        {
            _uow=uow;
        }

        public void Create(CategoryDTO cat)
        {
            _uow.Categories.Create(BLLMapper.Map<Category>(cat));
            _uow.Save();
        }

        public void Delete(CategoryDTO cat)
        {
            _uow.Categories.Delete(cat.CategoryId);
            _uow.Save();
        }        

        public IEnumerable<CategoryDTO> GetAll()
        {
            return _uow.Categories.GetAll()
                    .Select(c => BLLMapper.Map<CategoryDTO>(c));;
        }

        public CategoryDTO GetById(int id)
        {
            return BLLMapper.Map<CategoryDTO>
                (_uow.Categories.GetById(id));
        }

        public CategoryDTO GetProductCategory(ProductDTO prod)
        {
            var cat = _uow.Categories.GetAll() 
                    .Where(c => c.Products
                        .Any(p => p.ProductId == prod.ProductId));
            return BLLMapper.Map<CategoryDTO>(cat);
        }

        public IEnumerable<CategoryDTO> GetSupplierCategories(SupplierDTO sup)
        {
            IEnumerable<ProductDTO> prod = BLLMapper.Map<SupplierDTO>
                (_uow.Suppliers.GetById(sup.SupplierId)).Products;
            var cats = _uow.Categories.GetAll()
                        .Select(c=> BLLMapper.Map<CategoryDTO>(c));
            
            List<CategoryDTO> res = new List<CategoryDTO>();
            foreach (var p in prod)
            {
                res.Concat(cats.Where(c => c.Products.Any(
                    product => product.ProductId == p.ProductId)));
            }

            return res;
        }

        public void Update(CategoryDTO cat)
        {
            _uow.Categories.Update(BLLMapper.Map<Category>(cat));
            _uow.Save();
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