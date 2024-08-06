using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.DTOs.Order;
using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Product, ProductDto>()
            //    .ReverseMap();

            CreateMap<ProductReturnDto, Product>()
                .ReverseMap();
            CreateMap<ProductCreateDto, Product>()
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ReverseMap();



            CreateMap<Basket, BasketDto>()
                .ReverseMap();

            CreateMap<UpdateOrderDto, Order>();

            CreateMap<Product, ProductCreateDto>()
               .ForMember(prdto => prdto.BrandName,
               opt => opt.MapFrom(src => src.Brand.Name))
               .ForMember(prdto => prdto.CategoryName,
               opt => opt.MapFrom(src => src.Category.Name))
               .ForMember(prdto => prdto.Images,
               opt => opt.MapFrom(src => src.ProductImages.Select(pi => pi.ImageURL.ToList())))
               .ReverseMap();


            CreateMap<Product, ProductUpdateDto>()
               .ForMember(prdto => prdto.BrandName,
               opt => opt.MapFrom(src => src.Brand.Name))
               .ForMember(prdto => prdto.CategoryName,
               opt => opt.MapFrom(src => src.Category.Name))
               .ForMember(prdto => prdto.Images,
               opt => opt.MapFrom(src => src.ProductImages.Select(pi => pi.ImageURL.ToList())))
               .ReverseMap();


        }
    }
}
