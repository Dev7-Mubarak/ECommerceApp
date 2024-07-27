using ECommerceApp.API.DTOs;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if(order == null)
            {
                return NotFound();
            }

            await _orderService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(int id, OrderDto orderDto)
        {

            var product = await _orderService.GetByIdAsync(id);

            if (product == null)
                NotFound();

            await _orderService.UpdateAsync(orderDto);
            return Ok();

        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
          
            await _orderService.AddAsync(orderDto);
            return Ok(orderDto);

        }
    }


}