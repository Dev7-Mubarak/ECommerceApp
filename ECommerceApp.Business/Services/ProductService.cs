using AutoMapper;
using ECommerceApp.API.DTOs;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IWebHostEnvironment _env;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService, IWebHostEnvironment env)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _fileService=fileService;
        _env=env;
    }

    public async Task<bool> DeleteAsync(int productId)
    {
       // var product = await _unitOfWork.Products.GetByIdAsync(productId);
        var product = await _unitOfWork.Products.GetByIdAsync(productId, p => p.ProductImages);

        if (product == null)
        {
            return false;
        }

        // Remove existing images
        if (product.ProductImages != null)
        {
            foreach (var image in product.ProductImages)
            {
                await _fileService.DeleteFileAsync(image.ImageURL, "Images/products");
            }
        }

        _unitOfWork.Products.Delete(product);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    public async Task<IEnumerable<ProducrImageDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync(
            p => p.Category,
            p => p.Brand,
            p => p.ProductImages
        );

        var productDtos = _mapper.Map<IEnumerable<ProducrImageDto>>(products);

        foreach (var productDto in productDtos)
        {
            var product = products.FirstOrDefault(p => p.Id == productDto.Id);
            if (product != null && product.ProductImages != null && product.ProductImages.Any())
            {
                var imageUrls = product.ProductImages.Select(img => Path.Combine(_env.WebRootPath, img.ImageURL)).ToList();
                productDto.ImageUrls = imageUrls;
            }
        }

        return productDtos;
    }
    public async Task<ProducrImageDto> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(
            id,
            p => p.Category,
            p => p.Brand,
            p => p.ProductImages 
        );

        if(product == null)
            return null;

        var productDto = _mapper.Map<ProducrImageDto>(product);

        if (product.ProductImages != null && product.ProductImages.Any())
        {
            var imageUrls = product.ProductImages.Select(img => Path.Combine(_env.WebRootPath, img.ImageURL)).ToList();
            productDto.ImageUrls = imageUrls;
        }

        return productDto;
    }

    public async Task<Product> CreateAsync(ProductDto productDto)
    {

        var produt = _mapper.Map<Product>(productDto);

        if (productDto.Images != null && produt is Product product)
        {
            foreach (var file in productDto.Images)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "Images", file.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var productImage = new ProductImageDto
                    {
                        ImageURL = Path.Combine("images", file.FileName),
                        Product = product
                    };

                    product.ProductImages ??= new List<ProductImageDto>();
                    product.ProductImages.Add(productImage);

                }
            }
        }


        await _unitOfWork.Products.CreateAsync(produt);
        await _unitOfWork.CompleteAsync();
        return produt;
    }

    public Task<bool> UpdateAsync(ProductUpdateDto productDto)
    {
        throw new NotImplementedException();
    }

}













