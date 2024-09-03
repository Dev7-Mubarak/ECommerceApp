using AutoMapper;
using ECommerceApp.Business.DTOs.Basket;
using ECommerceApp.Business.DTOs.Order;
using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductReturnDto>()
                 .ForMember(poductReturnDto => poductReturnDto.ImageUrls,
                 opt => opt.MapFrom(product => product.ProductImages.Select(x => x.ImageURL)));

            CreateMap<ProductReturnDto, Product>()
                .ReverseMap();
            CreateMap<ProductCreateDto, Product>()
                .ReverseMap();
            CreateMap<ProductCreateDto, Product>()
                .ReverseMap();

            CreateMap<Order, CreateOrderDto>()
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


            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<Basket, BasketDto>()
                .ForMember(baskdto => baskdto.BasketItems,
                    opt => opt.MapFrom(src => src.BasketItems))
                .ReverseMap();


            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
            CreateMap<Order, CreateOrderDto>()
                .ForMember(orderdto => orderdto.orderItemDtos,
                    opt => opt.MapFrom(src => src.OrderItems))
                .ReverseMap();


            CreateMap<Order, ReturnOrderDto>()
                .ReverseMap();

            //CreateMap<AppUser, ReturnUserDto>()
            //    .ForMember(x => x.PorfileImageUrl)

        }
    }
}
