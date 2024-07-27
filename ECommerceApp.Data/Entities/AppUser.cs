using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public byte Age { get; set; }
        public bool Gender { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public ICollection<Order> Orders { get; set; } = new List<Order> ();

        public Payment Payment { get; set; }
    }
}
