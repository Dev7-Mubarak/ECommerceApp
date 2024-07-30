using ECommerceApp.API.DTOs;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> UpdateAsync(OrderDto productDto);
        Task<Order> AddAsync(OrderDto productDto);
        Task<bool> DeleteAsync(int id);
    }
}
