using ECommerceApp.Business.DTOs.Order;
using ECommerceApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
       
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateOrderDto orderDto)
        {
            var order = await _orderService.CreateAsync(orderDto);

            if (order is null)
                return BadRequest();

            return Ok(order);

        }

        //[HttpPut("Update")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Update(UpdateOrderDto updateOrderDto)
        //{
        //    var result = await _orderService.UpdateAsync(updateOrderDto);

        //    if(!result)
        //        return NotFound();

        //    return NoContent();
        //}

        [HttpDelete("Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }

    }


}