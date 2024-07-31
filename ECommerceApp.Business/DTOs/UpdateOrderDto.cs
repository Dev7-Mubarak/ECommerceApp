using ECommerceApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class UpdateOrderDto
    {
        public int id { get; set; }
        public Status OrderStatus { get; set; }
        public DateTime OrderedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserID { get; set; }
    }
}
