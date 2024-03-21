
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Extensions;
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.ProductImageFiles;
using ECommerceAPI.Application.Repositories.Products;

using ECommerceAPI.Application.Validators.Products;
using ECommerceAPI.Domain.Common.Paging;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(ICustomerWriteRepository customerWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService)
        {
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
            _productReadRepository = productReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            this.storageService = storageService;
        }
        // Scoped oldugu ucun context herbirine eyni context gonderilicey
        private ICustomerWriteRepository _customerWriteRepository { get; }
        private ICustomerReadRepository _customerReadRepository { get; }
        private IOrderReadRepository _orderReadRepository { get; }
        private IOrderWriteRepository _orderWriteRepository { get; }

        private IProductReadRepository _productReadRepository { get; }
        private IStorageService storageService { get; }

        IProductImageFileWriteRepository _productImageFileWriteRepository { get; }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto dto)
        {
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginateRequest request)
        {
            IPaginate data = _productReadRepository.GetAll().ToPaginate(request);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile[] formFiles)
        {
            var datas = await storageService.UploadAsync("files", formFiles);

            List<ProductImageFile> productImageFiles = datas.Select(x => new ProductImageFile
            {
                Path = x.pathOrContainerName,
                FileName = x.fileName,
                Storage = storageService.StorageName

            }).ToList();

            await _productImageFileWriteRepository.AddRangeAsync(productImageFiles);
            await _productImageFileWriteRepository.SaveAsync();
            return Ok();
        }

    }

}
