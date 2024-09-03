using ECommerceApp.Business.Base;
using ECommerceApp.Business.DTOs.User;

namespace ECommerceApp.Business.Interfaces
{
    public interface IUserService
    {
        public Task<Response<ReturnUserDto>> GetCurrentUserByIdAsync(string Id);
        public Task<Response<ReturnUserDto>> GetCurrentUserByUserNameAsync(string usreName);
        public Task<Response<string>> GetUserRolesAsync(string Id);
        public Task<Response<string>> DeleteUserAsync(string Id);
        public Task<Response<string>> UpdateUserAsync(ReturnUserDto request);
        //public Task<AppUser> GetUserRoles(string Id);
    }
}