using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    public class Basket 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser user { get; set; }
        public ICollection<BasketItem> catItems { get; set; }
    }
}
