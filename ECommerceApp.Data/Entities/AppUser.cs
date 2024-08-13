using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public byte Age { get; set; }
        [Required]
        public bool Gender { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public ICollection<Order> Orders { get; set; } = new List<Order> ();

        public Payment Payment { get; set; }

        public ICollection <Basket> Basket { get; set; }
    }
}
