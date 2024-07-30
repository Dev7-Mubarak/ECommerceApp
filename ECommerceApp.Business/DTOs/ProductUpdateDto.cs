using Microsoft.AspNetCore.Http;

namespace ECommerceApp.API.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public int? QuantityInStock { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
