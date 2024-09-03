using AutoMapper;
using ECommerceApp.Business.Base;
using ECommerceApp.Business.DTOs.User;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Business.Services
{
    public class UserService : ResponseHandler, IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Response<ReturnUserDto>> GetCurrentUserByIdAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
                return NotFound<ReturnUserDto>("User Not Found");

            var userMapped = _mapper.Map<ReturnUserDto>(user);

            return Success(userMapped);
        }

        public async Task<Response<ReturnUserDto>> GetCurrentUserByUserNameAsync(string usreName)
        {
            var user = await _userManager.FindByNameAsync(usreName);

            if (user == null)
                return NotFound<ReturnUserDto>("User Not Found");

            var userMapped = _mapper.Map<ReturnUserDto>(user);

            return Success(userMapped);
        }

        public async Task<Response<string>> DeleteUserAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
                return NotFound<string>("User Not Found");

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return BadRequest<string>($"Some think want wrong with {result.Errors}");

            return Success("User Deleted Succeefuly");
        }

        public async Task<Response<string>> UpdateUserAsync(ReturnUserDto request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                return NotFound<string>("User Not Found");

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest<string>($"Some think want wrong with {result.Errors}");


            return Success("User Deleted Succeefuly");
        }

        public async Task<Response<string>> GetUserRolesAsync(string Id)
        {
            var usserRoles = await _userManager.GetUsersInRoleAsync(Id);

            if (usserRoles == null)
                return NotFound<string>("User Don't have any roles");

            return Success(usserRoles.ToString());
        }
    }
}
