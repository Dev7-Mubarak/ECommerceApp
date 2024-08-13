using AutoMapper;
using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHost;
    private readonly string _imagePath;
    public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IWebHostEnvironment webHost)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _webHost = webHost;
        _imagePath = _webHost.WebRootPath + FileSetings.ImagesPath;
    }

    public async Task<IEnumerable<ProductReturnDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Products
            .GetAllAsync(p => p.Category, p => p.Brand, p => p.ProductImages);

        var productDtos = _mapper.Map<IEnumerable<ProductReturnDto>>(products);

        foreach (var productDto in productDtos)
        {
            var product = products.FirstOrDefault(p => p.Id == productDto.Id);
            if (product != null && product.ProductImages != null && product.ProductImages.Any())
            {
                var imageUrls = product.ProductImages.Select(img => Path.Combine(_webHost.WebRootPath, img.ImageURL)).ToList();
                productDto.ImageUrls = imageUrls;
            }
        }

        return productDtos;
    }
    public async Task<ProductReturnDto> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products
            .GetByIdAsync(id, p => p.Category, p => p.Brand, p => p.ProductImages);

        if (product == null)
            return null;

        var productDto = _mapper.Map<ProductReturnDto>(product);

        if (product.ProductImages != null && product.ProductImages.Any())
        {
            var imageUrls = product.ProductImages.Select(img => Path.Combine(_imagePath, img.ImageURL)).ToList();
            productDto.ImageUrls = imageUrls;
        }

        return productDto;
    }
    public async Task<ProductReturnDto?> CreateAsync(ProductCreateDto productCreateDto)
    {

        var product = _mapper.Map<Product>(productCreateDto);

        if (productCreateDto.Images != null)
        {
            product.ProductImages = new List<ProductImage>();

            foreach (var image in productCreateDto.Images)
            {
                // Tuple
                var result = await Utilities.SaveFileAsync(image, _imagePath);

                if (result.isSuccess)
                {
                    var productImage = new ProductImage
                    {
                        ImageURL = result.FileName,
                        Product = product,
                    };

                    product.ProductImages.Add(productImage);
                }

            }

        }

        await _unitOfWork.Products.CreateAsync(product);
        int rowAffected = await _unitOfWork.CompleteAsync();

        return rowAffected > 0 ? _mapper.Map<ProductReturnDto>(product) : null;
    }
    public async Task<bool> UpdateAsync(ProductUpdateDto productDto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productDto.Id, p => p.ProductImages);

        if (product == null)
        {
            return false;
        }

        return true;
    }
    public async Task<bool> DeleteAsync(int productId)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productId, p => p.ProductImages);

        if (product == null)
        {
            return false;
        }

        if (product.ProductImages != null)
        {
            foreach (var image in product.ProductImages)
            {
                Utilities.DeleteFile(image.ImageURL, _imagePath);
            }
        }

        _unitOfWork.Products.Delete(product);
        var rowAffected = await _unitOfWork.CompleteAsync();

        return rowAffected > 0 ? true : false;
    }

  
}












