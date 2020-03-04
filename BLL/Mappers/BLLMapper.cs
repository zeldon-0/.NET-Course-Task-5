using System.Linq;
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
                
                cfg.CreateMap<Supplier, SupplierDTO>()
                    .ForMember(dest => dest.Products,
                                opt => opt.MapFrom(src => src.ProductSuppliers
                                .Select(ps => ps.Product)))
                    .ReverseMap()
                    .PreserveReferences()
                    .ForMember(dest => dest.ProductSuppliers,
                                opt => opt.MapFrom (src => src.Products
                                .Select (p => new {p.ProductId, p, src.SupplierId, src })));
                cfg.CreateMap<Product, ProductDTO>()
                    .ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>()
                    .ReverseMap();


            });
            mapper=configuration.CreateMapper();
        }
        public static T Map<T> (object src)
        {
            return mapper.Map<T>(src);
        }
    }
}