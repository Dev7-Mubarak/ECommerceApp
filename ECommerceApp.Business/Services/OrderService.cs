using AutoMapper;
using ECommerceApp.API.DTOs;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Order> AddAsync(OrderDto orderDto)
    {
        var order =  _mapper.Map<Order>(orderDto);
        await _unitOfWork.Orders.cr(order);
        await _unitOfWork.CompleteAsync();
        return order;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _unitOfWork.Orders.DeleteAsync(id);
        if(order == false)
            return false;

        else
        {
            await _unitOfWork.CompleteAsync();

            return true;
        }
      
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
    
        return orders;
    }

    public async Task<OrderDto> GetByIdAsync(int id )  
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<Order> UpdateAsync(OrderDto orderDto)
    {
       
        var order = _mapper.Map<Order>(orderDto);
         _unitOfWork.Orders.UpdateAsync(order);
        await _unitOfWork.CompleteAsync();
        return order;
    }

  
}


