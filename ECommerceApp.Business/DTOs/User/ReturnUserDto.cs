using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Business.DTOs.User
{
    public class ReturnUserDto
    {
        public string Id { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        public string Email { get; set; }
        //[Ac]
        [MaxLength(100)]
        public byte Age { get; set; }
        public bool Gender { get; set; }
        public IFormFile? PorfileImageUrl { get; set; }
    }
}
