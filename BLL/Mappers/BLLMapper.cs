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
        static BLLMapper()
        {
            Configure();
        }
        public static void Configure()
        {
            configuration = new MapperConfiguration(cfg =>
            {
                
                /*cfg.CreateMap<Supplier, SupplierDTO>()
                    .ForMember(dest => dest.Products,
                                opt => opt.MapFrom(src => src.ProductSuppliers
                                .Select(ps => ps.Product).ToList()))
                    .ReverseMap()
                    .PreserveReferences()
                    .ForMember(dest => dest.ProductSuppliers,
                                opt => opt.MapFrom (src => src.Products
                                .Select(p => new {Product = p, Supplier = src })));*/
                cfg.CreateMap<Product, ProductDTO>()
                    .ReverseMap();
                cfg.CreateMap<SupplierDTO, Supplier>()
                    .ForMember(dest => dest.ProductSuppliers,
                                opt => opt.MapFrom(dto => dto.Products))
                    .AfterMap((dto, entity) =>
                        {
                            foreach (var productSupplier in entity.ProductSuppliers)
                            {
                                productSupplier.Supplier = entity;
                            }
                        });

                cfg.CreateMap<Supplier, SupplierDTO>()
                    .ForMember(dest => dest.Products,
                                opt => opt.MapFrom(entity => entity.ProductSuppliers
                                .Select(ps => ps.Product).ToList()));

                cfg.CreateMap<ProductDTO, ProductSupplier>()
                    .ForMember(dest => dest.Product,
                                opt => opt.MapFrom(prod => prod));            


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