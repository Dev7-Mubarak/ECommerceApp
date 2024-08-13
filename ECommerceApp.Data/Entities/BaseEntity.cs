using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
