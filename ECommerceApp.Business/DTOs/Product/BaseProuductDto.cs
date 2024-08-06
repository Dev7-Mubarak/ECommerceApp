namespace ECommerceApp.Business.DTOs.Product
{
    public class BaseProuductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public int? QuantityInStock { get; set; }
    }
}
