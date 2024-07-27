using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string UserID { get; set; }
        public AppUser User { get; set; }
    }
}



