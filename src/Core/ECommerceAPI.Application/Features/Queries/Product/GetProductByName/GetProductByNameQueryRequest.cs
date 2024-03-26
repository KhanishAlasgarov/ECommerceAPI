using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetProductByName;

public class GetProductByNameQueryRequest : IRequest<GetProductByNameQueryResponse>
{
    public GetProductByNameQueryRequest(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
