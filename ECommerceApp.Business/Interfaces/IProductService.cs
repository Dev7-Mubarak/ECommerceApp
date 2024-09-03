using ECommerceApp.API;
using ECommerceApp.Business.Base;
using ECommerceApp.Business.DTOs.Product;

namespace ECommerceApp.Business.Interfaces
{
    public interface IProductService
    {
        Task<Response<IEnumerable<ProductReturnDto>>> GetAllAsync();
        Task<PagedList<ProductReturnDto>> GetAllAsyncWithPaginted
            (string search, string? sortColumn, string? sortOrder, int page, int pageNumber, int pageSize);
        Task<Response<ProductReturnDto>> GetByIdAsync(int id);
        Task<ProductReturnDto> CreateAsync(ProductCreateDto productDto);
        Task<bool> UpdateAsync(ProductUpdateDto productDto);
        Task<Response<bool>> DeleteAsync(int id);
    }
}




