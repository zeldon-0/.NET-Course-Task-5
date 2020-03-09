using BLL.Interfaces;
using BLL.Services;
using DAL_EF.Repositories;
using DAL_EF.Interfaces;
using DAL_EF.EF;
using Ninject.Modules;
using Microsoft.EntityFrameworkCore;
using Ninject;
namespace BLL.UIModule
{
    public class UIModule : NinjectModule
    {

        private readonly DbContextOptions<RetailContext> dbContext;
        public UIModule(DbContextOptions<RetailContext> db)
        {
            dbContext=db;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("context", new RetailContext(dbContext));
            Bind<ISupplierService>().To<SupplierService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IProductService>().To<ProductService>();
            
        }
    }
}