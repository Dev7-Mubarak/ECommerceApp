using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Business.Services
{
    public class BasketService : IBasketService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<Basket> Delete()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Basket>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Basket> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Basket> Update()
        {
            throw new NotImplementedException();
        }

        //public async Task<Basket> Create(BasketDto basketDto)
        //{
        //    var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //    var basket = _mapper.Map<Basket>(basketDto);
        //    basket.user = user;
        //    await _unitOfWork.ShoppingCars.CreateAsync(basket);
        //    await _unitOfWork.CompleteAsync();

        //    return basket;
        //}


        public async Task<Basket> Create(BasketDto basketDto)
        {
            var user = "ahmed";
            var basket = _mapper.Map<Basket>(basketDto);
           // basket.user = user;

            foreach (var itemDto in basketDto.Items)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {itemDto.ProductId} not found");
                }

               var basketItem = new BasketItem
               {
                   ProdutId = product.Id,
                   Quantity = itemDto.Quantity,
                   Price = itemDto.PricePerUnit,
                   Product = product,
                   Basket = basket
               };
              
            }

            // _unitOfWork.Basksets.Attach(basket);
            await _unitOfWork.Baskets.CreateAsync(basket);
            await _unitOfWork.CompleteAsync();

            return basket;
        }

        public Task<Basket> Attac12h(Basket basket)
        {
            throw new NotImplementedException();
        }

        //public Task<Basket> Attach(Basket basket)
        //{
        //    throw new NotImplementedException();
        //}
    }
}



//public class BasketService : IBasketService
//{
//    private readonly IMapper _mapper;
//    private readonly IUnitOfWork _unitOfWork;
//    private readonly UserManager<AppUser> _userManager;
//    private readonly IHttpContextAccessor _httpContextAccessor;


//    public BasketService(IMapper mapper, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
//    {
//        _mapper=mapper;
//        _unitOfWork=unitOfWork;
//        _userManager=userManager;
//        _httpContextAccessor=httpContextAccessor;
//    }


//    public async Task<Basket> Create(BasketDto basketDto)
//    {
//        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
//        var basket = _mapper.Map<Basket>(basketDto);
//        basket.user = user;

//        foreach (var itemDto in basketDto.Items)
//        {
//            var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
//            if (product == null)
//            {
//                throw new Exception($"Product with ID {itemDto.ProductId} not found");
//            }





//            var basketItem = new BasketItem
//            {
//                ProdutId = product.Id,
//                Quantity = itemDto.Quantity,
//                Price = itemDto.PricePerUnit,
//                product = product,
//                cart = basket
//            };



//            basket.catItems.Add(basketItem);
//            break;
//        }

//        await _unitOfWork.ShoppingCars.CreateAsync(basket);
//        await _unitOfWork.CompleteAsync();

//        return basket;



//    }
//}
//public interface IBasketService
//{
//    Task<Basket> Create(BasketDto shoppingCart);


//}
//public class Product
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string? Description { get; set; }
//    public decimal Price { get; set; }
//    public int? QuantityInStock { get; set; }
//    public int? CategoryId { get; set; }
//    public Category? Category { get; set; }
//    public int? BrandId { get; set; }
//    public Brand? Brand { get; set; }
//    public ICollection<OrderItem>? OrderItems { get; set; }
//    public ICollection<ProductImageDto>? ProductImages { get; set; }
//    public ICollection<BasketItem> cartItems { get; set; }
//}
//public class Basket
//{
//    public int Id { get; set; }
//    public string UserId { get; set; }

//    public AppUser user { get; set; }
//    public ICollection<BasketItem> catItems { get; set; }
//}
//public class BasketItem
//{
//    public int Id { get; set; }

//    public int ProdutId { get; set; }

//    public int Quantity { get; set; }

//    public int ShoppingCartId { get; set; }

//    public decimal Price { get; set; }

//    public Product product { get; set; }

//    public Basket cart { get; set; }
//}
//public class ProductConfig : IEntityTypeConfiguration<Product>
//{
//    public void Configure(EntityTypeBuilder<Product> builder)
//    {
//        builder.HasKey(x => x.Id);

//        builder.HasOne(x => x.Category)
//             .WithMany(x => x.Products)
//             .HasForeignKey(x => x.CategoryId);

//        builder.HasMany(x => x.OrderItems)
//            .WithOne(x => x.Product)
//            .HasForeignKey(x => x.ProductID);


//        builder.HasMany(x => x.ProductImages)
//            .WithOne(x => x.Product)
//            .HasForeignKey(x => x.ProductId);

//        builder.HasOne(x => x.Brand)
//            .WithMany(x => x.Products)
//            .HasForeignKey(x => x.BrandId);


//        builder.HasMany(x => x.OrderItems)
//            .WithOne(x => x.Product);
//    }
//}
//public class ShoppingCartConfig : IEntityTypeConfiguration<Basket>
//{
//    public void Configure(EntityTypeBuilder<Basket> builder)
//    {
//        builder.HasKey(x => x.Id);

//        builder.HasMany(x => x.catItems)
//            .WithOne(x => x.cart);


//        builder.HasOne(x => x.user)
//                .WithOne(x => x.shoppingCart)
//                .HasForeignKey<Basket>(e => e.UserId)
//                .IsRequired(false);
//    }
//}
//public class BasketDto
//{
//    public List<BasketItemDto> Items { get; set; }
//}
//public class BasketItemDto
//{
//    public int ProductId { get; set; }
//    public int Quantity { get; set; }
//    public decimal PricePerUnit { get; set; }
//}
//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
//        CreateMap<Basket, BasketDto>()
//            .ForMember(dto => dto.Items, opt => opt.MapFrom(src => src.CartItems))
//            .ReverseMap();

//        CreateMap<BasketItem, BasketItemDto>()
//            .ForMember(dto => dto.ProductId, opt => opt.MapFrom(src => src.ProductId))
//            .ReverseMap();
//    }
//}

