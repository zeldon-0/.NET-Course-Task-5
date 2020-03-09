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
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _uow;
        public SupplierService (IUnitOfWork uow)
        {
            _uow=uow;
        }

        public void Create(SupplierDTO sup)
        {
            _uow.Suppliers.Create(BLLMapper.Map<Supplier>(sup));
            _uow.Save();
        }

        public void Delete(SupplierDTO sup)
        {
            _uow.Suppliers.Delete(sup.SupplierId);
            _uow.Save();
        }


        public IEnumerable<SupplierDTO> GetAll()
        {
            return  _uow.Suppliers.GetAll()
                .Select(s => BLLMapper.Map<SupplierDTO>(s));
        }

        public SupplierDTO GetById(int id)
        {
            return BLLMapper.Map<SupplierDTO>
                    (_uow.Suppliers.GetById(id));
        }

        public IEnumerable<SupplierDTO> GetCategorySuppliers(CategoryDTO cat)
        {

            
            IEnumerable<ProductDTO> prod = (BLLMapper.Map<CategoryDTO>
                (_uow.Categories.GetById(cat.CategoryId))).Products;
            var sups = _uow.Suppliers.GetAll()
                        .Select(s=> BLLMapper.Map<SupplierDTO>(s));
            
            List<SupplierDTO> res = new List<SupplierDTO>();
            foreach (var p in prod)
            {
                res.Concat(sups.Where(s => s.Products.Any(
                    product => product.ProductId == p.ProductId)));
            }


            return res;
        }

        public IEnumerable<SupplierDTO> GetProductSuppliers(ProductDTO prod)
        {
            var sups = _uow.Suppliers.GetAll()
                .Select(s => BLLMapper.Map<SupplierDTO>(s));
            List<SupplierDTO> result = new List<SupplierDTO>();
            foreach (var sup in sups)
            {
                if (sup.Products.Any(
                    p => p.ProductId == prod. ProductId))
                        result.Add(sup);
            }
            return result;
        }

        public void Update(SupplierDTO sup)
        {
            _uow.Suppliers.Update(BLLMapper.Map<Supplier>(sup));
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