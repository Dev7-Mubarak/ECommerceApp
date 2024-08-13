using AutoMapper;
using ECommerceApp.Business.DTOs.Order;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using NuGet.ContentModel;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
   }
   
    public async Task<IEnumerable<ReturnOrderDto>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();

    
        return _mapper.Map<IEnumerable<ReturnOrderDto>>(orders);
    }
    public async Task<ReturnOrderDto> GetByIdAsync(int id )  
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return _mapper.Map<ReturnOrderDto>(order);
    }
    public async Task<CreateOrderDto> CreateAsync(CreateOrderDto orderDto)
    {
        // var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        var order = _mapper.Map<Order>(orderDto);
        order.UserId = "d63698b9-da90-44d9-acfb-7d26d52ce901";
        if (order != null)
        {
            foreach (var orderdto in orderDto.orderItemDtos)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(orderdto.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {orderdto.ProductId} not found");
                }


                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = orderdto.Quantity,
                    Price = orderdto.Price,
                    Product = product,
                    Order = order
                };
            }

            await _unitOfWork.Orders.CreateAsync(order);
            await _unitOfWork.CompleteAsync();
            return orderDto;
        }

        return null;
    }
    public async Task<Order> UpdateAsync(CreateOrderDto orderDto)
    {
       
        var order = _mapper.Map<Order>(orderDto);
         _unitOfWork.Orders.Update(order);
        await _unitOfWork.CompleteAsync();
        return order;
    }
    public Task<bool> UpdateAsync(UpdateOrderDto updateOrderDto)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order != null)
        {
            _unitOfWork.Orders.Delete(order);
            var rowAffected = await _unitOfWork.CompleteAsync();

            return rowAffected > 0 ? true : false;
        }

        return false;
    }

}


