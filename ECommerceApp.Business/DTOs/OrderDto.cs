using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class OrderDto
    {
        public Status OrderStatus { get; set; }
        public DateTime OrderedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int? PaymentId { get; set; }
        public string UserID { get; set; }
    }
}
