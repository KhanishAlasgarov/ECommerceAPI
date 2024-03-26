namespace ECommerceAPI.Application.Features.Queries.Product.GetProductById;

public class GetProductByIdQueryResponse
{
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public float Price { get; set; }
}