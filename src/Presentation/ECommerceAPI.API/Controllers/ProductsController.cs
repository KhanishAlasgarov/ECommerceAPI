
using ECommerceAPI.Application.Extensions;
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
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
        public ProductsController(ICustomerWriteRepository customerWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository, IProductReadRepository productReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
            _productReadRepository = productReadRepository;
        }
        // Scoped oldugu ucun context herbirine eyni context gonderilicey
        private ICustomerWriteRepository _customerWriteRepository { get; }
        private ICustomerReadRepository _customerReadRepository { get; }
        private IOrderReadRepository _orderReadRepository { get; }
        private IOrderWriteRepository _orderWriteRepository { get; }

        private IProductReadRepository _productReadRepository { get; }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto dto)
        {
            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery]PaginateRequest request)
        {
            IPaginate data = _productReadRepository.GetAll().ToPaginate(request);
            return Ok(data);
        }

    }

}
