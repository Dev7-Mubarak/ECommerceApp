using AutoMapper;
using ECommerceApp.Business.DTOs.Basket;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        IMapper mapper;
        private readonly IBasketService _basketService;

        public BasketsController(IMapper mapper, IBasketService basketService)
        {
            this.mapper=mapper;
            _basketService=basketService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket(int Id)
        {
            var basket = await _basketService.GetById(Id);
            if (basket == null)
                return BadRequest("Not Found");
            return Ok(basket);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("Create")]
        public async Task <IActionResult> Create(BasketDto cardto)
        {
            if (cardto == null)
            {
                return BadRequest("is Null");
            }

          await _basketService.Create(cardto);
            return Ok(cardto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var basket = await _basketService.DeleteAsync(Id);
            if (basket == false)
                return BadRequest("Not Found");

          
            return Ok(true);
        }
    }
}
