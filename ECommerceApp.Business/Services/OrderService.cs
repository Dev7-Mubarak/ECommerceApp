using AutoMapper;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.Build.Framework;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Order> CreateAsync(OrderDto orderDto)
    {
        var order =  _mapper.Map<Order>(orderDto);
        await _unitOfWork.Orders.CreateAsync(order);

        int result = await _unitOfWork.CompleteAsync();

        return result > 0? order : null;
    }
  
    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<bool> UpdateAsync(UpdateOrderDto updateOrderDto)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(updateOrderDto.id);

        if (order == null)
            return false;

        _mapper.Map(updateOrderDto, order);

        _unitOfWork.Orders.Update(order);
        int result = await _unitOfWork.CompleteAsync();
        return result > 0? true : false;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);

        if (order == null)
            return false;

        _unitOfWork.Orders.Delete(order);
        int result = await _unitOfWork.CompleteAsync();
        return result > 0 ? true : false;
    }

}


