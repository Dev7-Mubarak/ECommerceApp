using AutoMapper;
using ECommerceApp.Business.DTOs.Basket;
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
        public async Task<BasketDto> GetById(int id)
        {
           var basket = await _unitOfWork.Baskets.GetByIdAsync(id , b => b.BasketItems);
           var basketDto = _mapper.Map<BasketDto>(basket);
            if (basket != null)
            {
                return basketDto;
            }

            else
            {
                return null;
            }
        }
        public async Task<Basket> Create(BasketDto basketDto)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var basket = _mapper.Map<Basket>(basketDto);
            basket.UserId ="d63698b9-da90-44d9-acfb-7d26d52ce901";

           

            foreach (var itemDto in basketDto.BasketItems)
            {
                
                var product = await _unitOfWork.Products.GetByIdAsync(itemDto.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {itemDto.ProductId} not found");
                }

               var basketItem = new BasketItem
               {
                   ProductId = product.Id,
                   Quantity = itemDto.Quantity,
                   Price = itemDto.Price,
                   Product = product,
                   Basket = basket
               };
              
            }
      
            
            await _unitOfWork.Baskets.CreateAsync(basket);
            await _unitOfWork.CompleteAsync();

            return basket;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var basket = await _unitOfWork.Baskets.GetByIdAsync(id , b => b.BasketItems);
            if (basket == null)
                return false;

            _unitOfWork.Baskets.Delete(basket);

            var rowAffected = await _unitOfWork.CompleteAsync();

            return rowAffected > 0 ? true : false;

        }
    }
}

