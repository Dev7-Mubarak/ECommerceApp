using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Business.DTOs.User
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte Age { get; set; }
        public bool Gender { get; set; }
        public string ClintUrl { get; set; }
        public IFormFile? PorfileImageUrl { get; set; }
    }
}
