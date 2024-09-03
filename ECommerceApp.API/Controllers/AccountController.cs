using ECommerceApp.Business.DTOs.User;
using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly ITokenService _tokenService;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _webHost;
        private readonly string _imagePath;

        public AccountController(UserManager<AppUser> userManger, ITokenService tokenService, IEmailSender emailSender, IWebHostEnvironment webHost)
        {
            _userManger = userManger;
            _tokenService = tokenService;
            _emailSender = emailSender;
            _webHost = webHost;
            _imagePath = _webHost.WebRootPath + FileSetings.UsersImagesPath;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            if (IsUserExistByEmail(registerDto.Email).Result.Value)
                return BadRequest("This Email Is Already Exist");

            AppUser user = new()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            // Add Porfile Image
            if (registerDto.PorfileImageUrl != null)
            {
                var fileResult = await Utilities.SaveFileAsync(registerDto.PorfileImageUrl, _imagePath);

                if(fileResult.Succeeded)
                    user.PorfileImageUrl = fileResult.FileName;
            }

            IdentityResult result = await _userManger.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest();

            // Return User Information
            UserDto userDto = new()
            {
                DisplayName = registerDto.UserName,
                Email = registerDto.Email,
                Token = _tokenService.CreateToken(user)
            };

            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = userDto.Token }, Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                $"Please confirm your email by clicking on this link:<a herf='{confirmationLink}'>Confirm Email</a>");



            return Ok(userDto);
        }


        //Authcation 
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user =  await _userManger.FindByNameAsync(loginDto.Email);

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

        [HttpGet("IsUserExist")]
        public async Task<ActionResult<bool>> IsUserExistByEmail(string Email)
        {
            return await _userManger.FindByEmailAsync(Email) is not null;
        }

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return BadRequest("User ID and Token are required");

            var user = await _userManger.FindByIdAsync(userId);

            if(user == null)
            {
                return BadRequest();
            }

            var result = await _userManger.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return Ok("Email conframtion successfully");


            return BadRequest("Email conframtion Failed");
        }
    }
}