using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    public class ShoppingCart 
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public AppUser user { get; set; }

        public ICollection<CartItem> catItems { get; set; }
    }
}
