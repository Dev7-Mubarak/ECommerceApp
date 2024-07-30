using AutoMapper;
using ECommerceApp.API.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product> AddAsync(ProductDto productDto)
    {
        var product =  _mapper.Map<Product>(productDto);
        await _unitOfWork.Products.CreateAsync(product);
        await _unitOfWork.CompleteAsync();

        return product;
        
    }

   

    //public async Task<Product> DeleteAsync(int id)
    //{
    //    var product = await _unitOfWork.Products.DeleteAsync(id);
    //    await _unitOfWork.CompleteAsync();

    //    return product;

    //}

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
    
        return products;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(product);
    }

    public Product Update(ProductDto productDto)
    {
       
        var product = _mapper.Map<Product>(productDto);
        _unitOfWork.Products.Update(product);
        return product;
    }

  
}


