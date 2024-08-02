using ECommerceApp.API.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          
           var product =  await _productService.DeleteAsync(id);
            if(product == true)
                return Ok(id);
           else
                return BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id ,[FromForm] ProductUpdateDto updateDto)
        {

            //if(ModelState.IsValid)
            //{
            //    var product = await _productService.GetAllPropertiesAsync(updateDto.Id);

            //    if (product != null)
            //    {
            //        _productService.Update(updateDto);
            //        return Ok(updateDto.Name + "/" + updateDto.BrandName);
            //    }              
            //}

            return BadRequest();

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create( [FromForm] ProductDto productDto)
        {
           

            if (productDto == null)
            {
                return NotFound();
            }

           await _productService.CreateAsync(productDto);
            return Ok(productDto);

        }

    }


}