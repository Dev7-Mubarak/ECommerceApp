using ECommerceApp.Business.DTOs.Order;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<bool> UpdateAsync(UpdateOrderDto updateOrderDto);
        Task<Order> CreateAsync(OrderDto productDto);
        Task<bool> DeleteAsync(int id);
    }
}
