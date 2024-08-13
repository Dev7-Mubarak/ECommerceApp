using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
            
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productService.GetAllAsync();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                return NotFound();
            }

            var product = await _productService.CreateAsync(productCreateDto);
            return Ok(product);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("Update")]
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


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int id)
        {
           var product =  await _productService.DeleteAsync(id);
            if(product == true)
                return Ok(id);
           else
                return BadRequest();
        }


    }


}