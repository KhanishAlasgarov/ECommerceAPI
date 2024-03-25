using ECommerceAPI.Application.Extensions;
using ECommerceAPI.Application.Repositories.Products;
using MediatR;
using System.Collections;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    IProductReadRepository _productReadRepository { get; }

    public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var data = _productReadRepository.GetAll().ToPaginate<GetAllProductQueryResponse>(request);
        return data;
    }
}
