using ECommerceApp.Business.DTOs;
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
        Task<Basket> Create(BasketDto shoppingCart);

        Task<Basket> Update();

        Task<Basket> Delete();

        Task<IEnumerable<Basket>> GetAll();

        Task<Basket> GetById(int id);

    }
}
