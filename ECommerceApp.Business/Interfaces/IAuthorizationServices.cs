using ECommerceApp.Bases;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Interfaces
{
    public interface IAuthorizationServices
    {
        Task<Response<IdentityRole>> GetRoleByIdAsync(string Id);
        Task<Response<IEnumerable<IdentityRole>>> GetRoleList();
        Task<Response<string>> AddRoleAsyncAsync(string RoleName);
        Task<Response<string>> EditRoleAsync(string id, string name);
        Task<Response<string>> DeleteRoleAsync(string id);
    }
}
