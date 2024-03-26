using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Repositories.ProductImageFiles;
using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Product.RemoveProductImage;

public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest>
{
    IProductImageFileReadRepository _productImageFileReadRepository { get; }
    IProductImageFileWriteRepository _productImageFileWriteRepository { get; }
    IStorageService _storageService { get; }

    public RemoveProductImageCommandHandler(IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService)
    {
        _productImageFileReadRepository = productImageFileReadRepository;
        _productImageFileWriteRepository = productImageFileWriteRepository;
        _storageService = storageService;
    }

    public async Task Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        var image = await _productImageFileReadRepository.GetByIdAsync(request.imageId);
        if (image == null)
            throw new NullReferenceException(); //todo replace with custom exception

        _productImageFileWriteRepository.Remove(image);

        await _storageService.DeleteAsync(image.Path, image.FileName);
        await _productImageFileWriteRepository.SaveAsync();
    }
}
