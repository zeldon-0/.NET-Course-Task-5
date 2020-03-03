using System;
using AutoMapper;
using DAL_EF.Entities;
using BLL.Models;
namespace BLL.Mappers
{
    public static class BLLMapper 
    {
        private static IMapper mapper;
        private static MapperConfiguration configuration;
        public static void Configure()
        {
            configuration = new MapperConfiguration(cfg =>
            {
               CreateTwoWayMap<Category, CategoryDTO>(cfg);
               CreateTwoWayMap<Supplier, SupplierDTO>(cfg);
               CreateTwoWayMap<Product, ProductDTO>(cfg);

            });
            mapper=configuration.CreateMapper();
        }
        private static void CreateTwoWayMap<T1, T2>(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<T1,T2>();
            cfg.CreateMap<T2,T1>();
        }

        public static T Map<T> (object src)
        {
            return mapper.Map<T>(src);
        }
    }
}