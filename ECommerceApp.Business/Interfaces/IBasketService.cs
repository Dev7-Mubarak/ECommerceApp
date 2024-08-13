using ECommerceApp.Business.DTOs.Basket;
using ECommerceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> GetById(int id);
        Task<Basket> Create(BasketDto shoppingCart);
        Task<bool> DeleteAsync(int id);
    }
}
