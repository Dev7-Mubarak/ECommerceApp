using AutoMapper;
using ECommerceApp.API.DTOs;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();

            CreateMap<Order, OrderDto>()
                .ReverseMap();

            CreateMap<UpdateOrderDto, Order>();
        }
    }
}
