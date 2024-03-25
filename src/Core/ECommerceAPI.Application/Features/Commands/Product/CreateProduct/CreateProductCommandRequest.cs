using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct;

public class CreateProductCommandRequest : IRequest
{
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public float Price { get; set; }
}