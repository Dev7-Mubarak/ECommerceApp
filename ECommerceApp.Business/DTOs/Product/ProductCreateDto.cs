using Microsoft.AspNetCore.Http;

namespace ECommerceApp.Business.DTOs.Product
{
    public class ProductCreateDto : BaseProuductDto
    {
        public List<IFormFile>? Images { get; set; }
    }
}
