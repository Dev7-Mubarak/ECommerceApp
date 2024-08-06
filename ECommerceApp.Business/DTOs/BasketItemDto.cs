using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class BasketItemDto
    {   
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
        public decimal PricePerUnit { get; set; }
    }

}
