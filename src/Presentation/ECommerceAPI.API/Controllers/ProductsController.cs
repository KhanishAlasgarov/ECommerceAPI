
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.ProductImageFiles;
using ECommerceAPI.Application.Repositories.Products;

using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.API.Controllers;


public class ProductsController : BaseController
{
    public ProductsController(ICustomerWriteRepository customerWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService, IProductImageFileReadRepository productImageFileReadRepository)
    {
        _customerWriteRepository = customerWriteRepository;
        _orderWriteRepository = orderWriteRepository;
        _customerReadRepository = customerReadRepository;
        _orderReadRepository = orderReadRepository;
        _productReadRepository = productReadRepository;
        _productImageFileWriteRepository = productImageFileWriteRepository;
        this.storageService = storageService;
        _productImageFileReadRepository = productImageFileReadRepository;
    }
    // Scoped oldugu ucun context herbirine eyni context gonderilicey
    private ICustomerWriteRepository _customerWriteRepository { get; }
    private ICustomerReadRepository _customerReadRepository { get; }
    private IOrderReadRepository _orderReadRepository { get; }
    private IOrderWriteRepository _orderWriteRepository { get; }

    private IProductReadRepository _productReadRepository { get; }
    private IStorageService storageService { get; }

    IProductImageFileWriteRepository _productImageFileWriteRepository { get; }
    IProductImageFileReadRepository _productImageFileReadRepository { get; }

    [HttpPost]
    public async Task<IActionResult> Add(CreateProductCommandRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest request)
    {
        var data = await Mediator.Send(request);
        return Ok(data);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Upload(IFormFile[] formFiles, Guid productId)
    {
        if (Guid.Empty == productId)
            return NotFound();


        var datas = await storageService.UploadAsync("files", formFiles);
        var product = await _productReadRepository.GetSignleAsync(x => x.Id == productId);

        if (product == null)
            return NotFound();



        List<ProductImageFile> productImageFiles = datas.Select(x => new ProductImageFile
        {
            Path = x.pathOrContainerName,
            FileName = x.fileName,
            Storage = storageService.StorageName,
            Products = new List<Product>() { product }

        }).ToList();

        await _productImageFileWriteRepository.AddRangeAsync(productImageFiles);
        await _productImageFileWriteRepository.SaveAsync();
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetProductImages(Guid id)
    {
        var products = _productReadRepository.GetAll().Include(x => x.ProductImageFiles);

        var product = await products.FirstOrDefaultAsync(x => x.Id == id);

        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetByName(string name)
    {
        return Ok(await _productReadRepository.GetSignleAsync(x => x.Name == name));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteImage(Guid imageId)
    {
        var image = await _productImageFileReadRepository.GetByIdAsync(imageId);
        if (image == null)
            return NotFound();
        _productImageFileWriteRepository?.Remove(image);

        await storageService.DeleteAsync(image.Path, image.FileName);
        await _customerWriteRepository.SaveAsync();

        return Ok();
    }
}
