using AutoMapper;
using ECommerceAPI.Application.Repositories.Products;
using MediatR;
using E = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Queries.Product.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    IProductReadRepository _productReadRepository { get; }
    IMapper _mapper { get; }

    public GetProductByIdQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _mapper = mapper;
    }

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {

        if (request.Id == Guid.Empty)
            throw new NullReferenceException(); //todo replace with custom exception

        var product = await _productReadRepository.GetByIdAsync(request.Id, false);

        if (product != null)
        {
            return _mapper.Map<GetProductByIdQueryResponse>(product);
        }

        throw new NullReferenceException(); //todo replace with custom exception


    }
}
