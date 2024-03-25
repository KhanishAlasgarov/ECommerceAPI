using AutoMapper;
using ECommerceAPI.Application.Repositories.Products;
using MediatR;
using E = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    IProductWriteRepository _productWriteRepository { get; }
    IMapper _mapper { get; }

    public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
    {
        _productWriteRepository = productWriteRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _productWriteRepository.AddAsync(_mapper.Map<E::Product>(request));
        await _productWriteRepository.SaveAsync();
    }
}
