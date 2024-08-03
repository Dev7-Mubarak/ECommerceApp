using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.DTOs
{
    public class BasketDto
    {
        public int Id { get; set; } 
        public List<BasketItemDto> Items { get; set; }
    }

}
