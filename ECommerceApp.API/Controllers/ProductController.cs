using ECommerceApp.API.Base;
using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    public class ProductsController : AppControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Router.ProductRouting.List)]
        #endregion
        public async Task<IActionResult> GetAll()
            => NewResult(await _productService.GetAllAsync());

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Router.ProductRouting.Paginted)]
        #endregion
        public async Task<IActionResult> GetAllWithPaginted
            (string? search, string? sortColumn, string? sortOrder, int page = 1, int pageNumber = 1, int pageSize = 10)
        {
            var product = await _productService.GetAllAsyncWithPaginted(search, sortColumn, sortOrder, page, pageNumber, pageSize);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(Router.ProductRouting.GetById)]
        #endregion
        public async Task<IActionResult> GetById(int id)
            => NewResult(await _productService.GetByIdAsync(id));

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut(Router.ProductRouting.Create)]
        #endregion
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                return NotFound();
            }

            var product = await _productService.CreateAsync(productCreateDto);
            return Ok(product);
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost(Router.ProductRouting.Update)]
        #endregion
        public async Task<IActionResult> Update(int id, [FromForm] ProductUpdateDto updateDto)
        {

            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateAsync(updateDto);

                if (product != null)
                {
                    await _productService.UpdateAsync(updateDto);
                    return Ok(updateDto.Name + "/" + updateDto.BrandName);
                }
            }

            return BadRequest();
        }

        #region Routing
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete(Router.ProductRouting.Delete)]
        #endregion
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.DeleteAsync(id);
            if (product == true)
                return Ok(id);
            else
                return BadRequest();
        }


    }


}