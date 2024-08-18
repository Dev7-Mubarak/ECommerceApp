using ECommerceApp.Bases;
using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<Response<IEnumerable<ProductReturnDto>>> GetAllAsync();
        Task<Response<ProductReturnDto>> GetByIdAsync(int id);
        Task<Response<ProductCreateDto>> CreateAsync(ProductCreateDto productDto);
        Task<bool> UpdateAsync(ProductUpdateDto productDto);
        Task <Response<bool>> DeleteAsync(int id);
    }
}




