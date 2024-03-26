using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetProductById;

public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
{
    public Guid Id { get; set; }
}
