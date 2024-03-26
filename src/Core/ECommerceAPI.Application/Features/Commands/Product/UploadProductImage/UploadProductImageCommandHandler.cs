using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Repositories.ProductImageFiles;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Domain.Entities;
using MediatR;
using E = ECommerceAPI.Domain.Entities;
namespace ECommerceAPI.Application.Features.Commands.Product.UploadProductImage;

public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest>
{
    public UploadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
    {
        _storageService = storageService;
        _productReadRepository = productReadRepository;
        _productImageFileWriteRepository = productImageFileWriteRepository;
    }

    IStorageService _storageService { get; }
    IProductReadRepository _productReadRepository { get; }
    IProductImageFileWriteRepository _productImageFileWriteRepository { get; }

    public async Task Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        if (Guid.Empty == request.productId)
            throw new NullReferenceException(); //todo replace with custom exception

        if (request.formFiles == null)
            throw new NullReferenceException(); //todo replace with custom exception

        var product = await _productReadRepository.GetSignleAsync(x => x.Id == request.productId);

        if (product == null)
            throw new NullReferenceException(); //todo replace with custom exception

        var datas = await _storageService.UploadAsync("files", request.formFiles);

        List<ProductImageFile> productImageFiles = datas.Select(x => new ProductImageFile
        {
            Path = x.pathOrContainerName,
            FileName = x.fileName,
            Storage = _storageService.StorageName,
            Products = new List<E::Product>() { product }

        }).ToList();

        await _productImageFileWriteRepository.AddRangeAsync(productImageFiles);
        await _productImageFileWriteRepository.SaveAsync();
    }
}
