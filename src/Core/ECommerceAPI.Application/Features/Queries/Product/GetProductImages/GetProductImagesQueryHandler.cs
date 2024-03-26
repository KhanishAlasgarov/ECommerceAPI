using AutoMapper;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Application.Features.Queries.Product.GetProductImages;

public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, IEnumerable<GetProductImagesQueryResponse>>
{
    IProductReadRepository _productReadRepository { get; }
    IConfiguration _configuration { get; }
    IMapper _mapper { get; }

    public GetProductImagesQueryHandler(IProductReadRepository productReadRepository, IConfiguration configuration, IMapper mapper)
    {
        _productReadRepository = productReadRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new NullReferenceException(); //todo replace with custom exception

        var products = _productReadRepository.GetAll(include: x => x.Include(x => x.ProductImageFiles));

        var product = await products.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (product != null)
        {
            return _mapper.Map<IEnumerable<GetProductImagesQueryResponse>>(product.ProductImageFiles);
        }

        throw new NullReferenceException(); //todo replace with custom exception

    }
}
public class GetProductImagesQueryRequest : IRequest<IEnumerable<GetProductImagesQueryResponse>>
{
    public Guid Id { get; set; }
}
public class GetProductImagesQueryResponse
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = default!;
    public string Path { get; set; } = default!;
}