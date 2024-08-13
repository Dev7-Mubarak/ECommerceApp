using ECommerceApp.Data.Enums;

namespace ECommerceApp.Business.DTOs.Order
{
    public class CreateOrderDto
    {
        public Status OrderStatus { get; set; }
     
        public decimal TotalAmount
        {
            get
            {
                return orderItemDtos.Sum(x => x.Quantity * x.Price);
            }

        }
     
        public ICollection<OrderItemDto> orderItemDtos  { get; set; }
    }
}
