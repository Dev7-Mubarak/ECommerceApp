using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? QuantityInStock { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<ProductImageDto>? ProductImages { get; set; }
        public ICollection<BasketItem> cartItems {  get; set; } 
    }
}

