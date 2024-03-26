using AutoMapper;
using ECommerceAPI.Application.Repositories.Products;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetProductByName;

public class GetProductByNameQueryHandler : IRequestHandler<GetProductByNameQueryRequest, GetProductByNameQueryResponse>
{
    IProductReadRepository _productReadRepository { get; }
    IMapper _mapper { get; }

    public GetProductByNameQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }

    public async Task<GetProductByNameQueryResponse> Handle(GetProductByNameQueryRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new NullReferenceException(); //todo replace with custom exception
        var product = await _productReadRepository.GetSignleAsync(x => x.Name == request.Name);

        if (product == null)
            throw new NullReferenceException(); //todo replace with custom exception

        return _mapper.Map<GetProductByNameQueryResponse>(product);
    }
}
