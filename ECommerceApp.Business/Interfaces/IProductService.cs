using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<ProductReturnDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductReturnDto>> GetAllAsync();
        Task<bool> UpdateAsync(ProductUpdateDto productDto);
        Task <bool> DeleteAsync(int id);
        Task<ProductReturnDto> CreateAsync(ProductCreateDto productDto);
    }
}




