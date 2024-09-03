using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationServices _authorizationServices;

        public AuthorizationController(IAuthorizationServices authorizationServices)
        {
            _authorizationServices=authorizationServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(string name)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var role = await _authorizationServices.AddRoleAsyncAsync(name);
            return Ok(role);


        }
    }
}
