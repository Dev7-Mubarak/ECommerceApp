using ECommerceApp.API.DTOs;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<ProducrImageDto> GetByIdAsync(int id);
        Task<IEnumerable<ProducrImageDto>> GetAllAsync();
        Task<bool> UpdateAsync(ProductUpdateDto productDto);
        Task <bool> DeleteAsync(int id);
        Task<Product> CreateAsync(ProductDto productDto);
        

      

    }
}




