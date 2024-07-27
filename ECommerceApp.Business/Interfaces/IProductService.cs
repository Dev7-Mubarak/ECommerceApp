using ECommerceApp.API.DTOs;
using ECommerceApp.Data.Entities;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Product Update(ProductDto productDto);
        Task<Product> AddAsync(ProductDto productDto);
        Product Delete(int id);
    }
}
