namespace ECommerceAPI.Application.Features.Queries.Product.GetProductByName;

public class GetProductByNameQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public float Price { get; set; }
}
