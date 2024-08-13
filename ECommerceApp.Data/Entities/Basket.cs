using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Data.Entities
{
    public class Basket : BaseEntity
    {
        [Required]
        public string UserId { get; set; }
        public AppUser user { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }

  

}
