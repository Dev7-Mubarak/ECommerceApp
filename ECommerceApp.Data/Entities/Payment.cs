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
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }

        public Order Order { get; set; }
    }
}


