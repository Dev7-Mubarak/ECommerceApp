using ECommerceApp.Data.Enums;

namespace ECommerceApp.Business.DTOs.Order
{
    public class ReturnOrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Status OrderStatus { get; set; }
        public DateTime OrderedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserID { get; set; }
        public int Quantity {  get; set; }
    }
}
