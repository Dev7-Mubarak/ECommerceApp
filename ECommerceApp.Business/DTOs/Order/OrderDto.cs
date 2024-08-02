using ECommerceApp.Data.Enums;

namespace ECommerceApp.Business.DTOs.Order
{
    public class OrderDto
    {
        public Status OrderStatus { get; set; }
        public DateTime OrderedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserID { get; set; }
    }
}
