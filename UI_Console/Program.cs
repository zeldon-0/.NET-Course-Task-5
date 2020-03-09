using System;
using BLL.UIModule;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System.Configuration;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.Generic;
using System.Linq;
namespace UI_Console
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DAL_EF.EF.RetailContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["RetailContext"].ConnectionString); 
            StandardKernel kernel = new StandardKernel (
                new UIModule(optionsBuilder.Options));

            IProductService product = kernel.Get<IProductService>();
            ICategoryService category = kernel.Get<ICategoryService>();
            ISupplierService supplier = kernel.Get<ISupplierService>();

            var  cat = new CategoryDTO () {Name="smth43242"};

            /*prod.Category=cat;
            prod1.Category=cat;
            prod2.Category=cat;*/
            
            /*category.Create(cat);
            
            var prod = new ProductDTO () {Name= "smth", CategoryId=1, Price = 10};
            var prod1 = new ProductDTO () {Name= "smth1", CategoryId=1, Price= 20};

            
            var sup = new SupplierDTO () {Name="sm", Products= new List<ProductDTO> {prod, prod1}};
            supplier.Create(sup);*/

            Console.WriteLine(product.GetWithMaxPrice().ProductId);
            Console.WriteLine(product.GetWithMinPrice().ProductId);

        }
    }
}
