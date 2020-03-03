using System;
using BLL.Models;
using System.Collections.Generic;
namespace BLL.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        void Create(CategoryDTO prod);
        void Delete(CategoryDTO prod);
        void Update(CategoryDTO prod);

        CategoryDTO GetById(int id);
        IEnumerable<CategoryDTO> GetAll();

    }
}