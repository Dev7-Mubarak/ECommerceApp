namespace ECommerceApp.Business.DTOs.Product
{
    public class ProductReturnDto : BaseProuductDto
    {
        public int Id { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
