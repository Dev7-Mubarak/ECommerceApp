using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReturnDto>> GetAllAsync();
        Task<ProductReturnDto> GetByIdAsync(int id);
        Task<ProductReturnDto> CreateAsync(ProductCreateDto productDto);
        Task<bool> UpdateAsync(ProductUpdateDto productDto);
        Task <bool> DeleteAsync(int id);
    }
}




