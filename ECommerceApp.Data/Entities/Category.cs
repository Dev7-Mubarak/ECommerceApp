using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Data.Entities
{
    public class Category : BaseEntity
    {
        public string? ImageURL { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}



