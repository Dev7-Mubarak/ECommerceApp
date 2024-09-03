using ECommerceApp.Bases;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class Authorization : ResponseHandler , IAuthorizationServices
    {
        #region Fields
        private readonly RoleManager<Response<IdentityRole>> _roleManager;

        #endregion


        #region Constrcutor(s)
        public Authorization(RoleManager<Response<IdentityRole>> roleManager)
        {
            _roleManager=roleManager;
        }

        #endregion


        #region Funcation Hnadler

        public Task<Response<string>> AddRoleAsyncAsync(string RoleName)
        {
            var identityRole = new IdentityRole()
            {
                Name = RoleName
            };

            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
                return Success(RoleName);
            return BadRequest<string>("Failed");
        }
        public Task<Response<string>> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound<string>();

            var user = await _userManager.GetUsersInRoleAsync(role.Name);
            if (user != null) return BadRequest<string>("role Used");

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return Success($"This Id {id} is Deleted");

            var _erros = string.Join("-", result.Errors);
            return BadRequest<string>(_erros);
        }
        public Task<Response<string>> EditRoleAsync(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound<string()>;

            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return Success("updated");


            var _erros = string.Join("-", result.Errors);
            return BadRequest<string>(_erros);
        }
        public Task<Response<IdentityRole>> GetRoleByIdAsync(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (role == null) return NotFound<string>();
            return Success(role);
        }
        public Task<Response<IEnumerable<IdentityRole>>> GetRoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles == null) return NotFound<string>();

            return Success(roles);
        }

       
        #endregion

    }
}
