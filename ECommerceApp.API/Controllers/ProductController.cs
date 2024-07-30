using ECommerceApp.API.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productService.GetAllAsync();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var product = await _productService.GetByIdAsync(id);

        //    if(product == null)
        //    {
        //        return NotFound();
        //    }

        //    await _productService.DeleteAsync(id);
        //    return Ok();
        //}


        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id , ProductDto productDto)
        {

            var product = _productService.GetByIdAsync(id);

            if (product == null)
                NotFound();
            _productService.Update(productDto);
            return Ok();


        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            
            if(productDto == null)
            {
                return NotFound();
            }

           await _productService.AddAsync(productDto);
            return Ok(productDto);



        }
    }


}