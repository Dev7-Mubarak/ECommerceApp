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
        await _unitOfWork.Orders.CreateAsync(order);
        await _unitOfWork.CompleteAsync();
        return order;
    }

    public Task<Order> CreateAsync(OrderDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    //public async Task<bool> DeleteAsync(int id)
    //{
    //    var order = await _unitOfWork.Orders.GetByIdAsync(id);

    //    var reslut =  _unitOfWork.Orders.Delete(order);

    //    if(reslut == false)
    //        return false;

    //    else
    //    {
    //        await _unitOfWork.CompleteAsync();

    //        return true;
    //    }

    //}

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
         _unitOfWork.Orders.Update(order);
        await _unitOfWork.CompleteAsync();
        return order;
    }

    public Task<bool> UpdateAsync(UpdateOrderDto updateOrderDto)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<OrderDto>> IOrderService.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}


