
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.Product.RemoveProductImage;
using ECommerceAPI.Application.Features.Commands.Product.UploadProductImage;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetProductById;
using ECommerceAPI.Application.Features.Queries.Product.GetProductByName;
using ECommerceAPI.Application.Features.Queries.Product.GetProductImages;
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
    // Scoped oldugu ucun context herbirine eyni context gonderilicey


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
        await Mediator.Send(new UploadProductImageCommandRequest(formFiles, productId));
        return Ok();
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetProductImages(Guid id)
    {
        var data = await Mediator.Send(new GetProductImagesQueryRequest
        {
            Id = id
        });

        return Ok(data);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(GetProductByIdQueryRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetByName(string name)
    {
        var data = await Mediator.Send(new GetProductByNameQueryRequest(name));
        return Ok(data);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteImage(Guid imageId)
    {
        await Mediator.Send(new RemoveProductImageCommandRequest(imageId));

        return Ok();
    }
}
