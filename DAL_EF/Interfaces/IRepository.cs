using System.Collections.Generic;
namespace DAL_EF.Interfaces
{
    public interface IRepository<T> where T:class
    {
         T GetById (int id);
         IEnumerable<T> GetAll();
         void Create (T t);
         void Delete (int id);
         void Update (T t);
         void Save();
    }
}