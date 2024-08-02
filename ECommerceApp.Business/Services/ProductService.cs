using AutoMapper;
using ECommerceApp.Business.DTOs.Product;
using ECommerceApp.Business.DTOs;
using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using ECommerceApp.Data.Interfaces;
using Microsoft.AspNetCore.Hosting;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IFileService fileService, IWebHostEnvironment webHostEnvironment)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _webHostEnvironment = webHostEnvironment;
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

    public async Task<IEnumerable<ProductReturnDto>> GetAllAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync(
            p => p.Category,
            p => p.Brand,
            p => p.ProductImages
        );

        var productDtos = _mapper.Map<IEnumerable<ProductReturnDto>>(products);

        foreach (var productDto in productDtos)
        {
            var product = products.FirstOrDefault(p => p.Id == productDto.Id);
            if (product != null && product.ProductImages != null && product.ProductImages.Any())
            {
                var imageUrls = product.ProductImages.Select(img => Path.Combine(_webHostEnvironment.WebRootPath, img.ImageURL)).ToList();
                productDto.ImageUrls = imageUrls;
            }
        }

        return productDtos;
    }
    public async Task<ProductReturnDto> GetByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(
            id,
            p => p.Category,
            p => p.Brand,
            p => p.ProductImages 
        );

        if(product == null)
            return null;

        var productDto = _mapper.Map<ProductReturnDto>(product);

        if (product.ProductImages != null && product.ProductImages.Any())
        {
            var imageUrls = product.ProductImages.Select(img => Path.Combine(_webHostEnvironment.WebRootPath, img.ImageURL)).ToList();
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

                var ImageURL = await Utilities.SaveFileAsync(image, _webHostEnvironment + FileSetings.ImagesPath);

                var productImage = new ProductImage
                {
                    ImageURL = ImageURL,
                    Product = product,
                };
                product.ProductImages.Add(productImage);
            }
        }

        await _unitOfWork.Products.CreateAsync(product);
        int result = await _unitOfWork.CompleteAsync();

        return result > 0? _mapper.Map<ProductReturnDto>(product): null;
    }

    public Task<bool> UpdateAsync(ProductUpdateDto productDto)
    {
        throw new NotImplementedException();
    }

}













