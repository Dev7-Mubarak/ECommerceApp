using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManger;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManger, ITokenService tokenService)
        {
            _userManger = userManger;
            _tokenService = tokenService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto userDto)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new()
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email
                };

                IdentityResult result = await _userManger.CreateAsync(user, userDto.Password);

                if (result.Succeeded)
                    return Ok();
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(ModelState.IsValid)
            {
                var user =  await _userManger.FindByNameAsync(loginDto.UserName);

                if(user != null)
                {
                    if(await _userManger.CheckPasswordAsync(user, loginDto.Password))
                        return Ok(_tokenService.CreateToken(user));
                    else
                        return Unauthorized();
                }
                else
                {
                    ModelState.AddModelError("", "User Name is inviled");
                }
            }

            return BadRequest(ModelState);
        }
    }
}