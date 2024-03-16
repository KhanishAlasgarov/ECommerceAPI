
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Application.Validators.Products;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(ICustomerWriteRepository customerWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerReadRepository customerReadRepository, IOrderReadRepository orderReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderReadRepository = orderReadRepository;
        }
        // Scoped oldugu ucun context herbirine eyni context gonderilicey
        private ICustomerWriteRepository _customerWriteRepository { get; }
        private ICustomerReadRepository _customerReadRepository { get; }
        private IOrderReadRepository _orderReadRepository { get; }
        private IOrderWriteRepository _orderWriteRepository { get; }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto dto)
        {
             return Ok(dto);
        }

    }

}
