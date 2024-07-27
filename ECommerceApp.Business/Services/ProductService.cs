using AutoMapper;
using ECommerceApp.API.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;

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
        await _unitOfWork.Products.AddAsync(product);
        _unitOfWork.Complete();

        return product;
        
    }

   

    public Product Delete(int id)
    {
        var product = _unitOfWork.Products.Delete(id);
        _unitOfWork.Complete();

        return product;


    }

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


