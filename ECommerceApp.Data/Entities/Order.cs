using ECommerceApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Status OrderStatus { get; set; } = Status.Pending;
        public DateTime OrderedDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public string UserID { get; set; }
        public AppUser User { get; set; }   
        public ICollection<OrderItem> OrderItems { get; set; }
    }

}



