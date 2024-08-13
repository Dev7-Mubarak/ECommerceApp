using ECommerceApp.Business.DTOs.Order;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<ReturnOrderDto>> GetAllAsync();
        Task<ReturnOrderDto> GetByIdAsync(int id);
        Task<CreateOrderDto> CreateAsync(CreateOrderDto productDto);
        Task<bool> UpdateAsync(UpdateOrderDto updateOrderDto);
        Task<bool> DeleteAsync(int id);
    }
}
