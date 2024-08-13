using ECommerceApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.PayPal;
        public Status Status { get; set; } = Status.Pending;
        public Order Order { get; set; }
    }
}


