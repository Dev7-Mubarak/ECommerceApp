using ECommerceApp.API.Base;
using ECommerceApp.Business.DTOs.User;
using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    public class UserController : AppControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public UserController(IUserService userService, IProductService productService)
        {
            _userService = userService;
            _productService = productService;
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Router.UserRouting.GetById)]
        #endregion
        public async Task<IActionResult> GetCurrentUserByIdAsync(string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NewResult(await _userService.GetCurrentUserByIdAsync(userId));
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Router.UserRouting.GetByUserName)]
        #endregion
        public async Task<IActionResult> GetCurrentUserByUserNameAsync(string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NewResult(await _userService.GetCurrentUserByUserNameAsync(userId));
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(Router.UserRouting.Delete)]
        #endregion
        public async Task<IActionResult> DeleteUserAsync(string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NewResult(await _userService.DeleteUserAsync(userId));
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(Router.UserRouting.Update)]
        #endregion
        public async Task<IActionResult> UpdateUserAsync(ReturnUserDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NewResult(await _userService.UpdateUserAsync(request));
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Router.UserRouting.GetUserRoles)]
        #endregion
        public async Task<IActionResult> GetUserRolesAsync(string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NewResult(await _userService.GetUserRolesAsync(userId));
        }
    }
}
