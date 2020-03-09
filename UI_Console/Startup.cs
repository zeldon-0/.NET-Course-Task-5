using BLL.Interfaces;
using BLL.Services;
using DAL_EF.Interfaces;
using DAL_EF.Repositories;
using DAL_EF.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<RetailContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
        

            BLL.Mappers.BLLMapper.Configure();

        }
    
    }
}