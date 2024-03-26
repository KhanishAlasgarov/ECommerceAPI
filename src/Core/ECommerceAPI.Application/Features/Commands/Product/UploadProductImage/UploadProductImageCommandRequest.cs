using MediatR;
using Microsoft.AspNetCore.Http;
namespace ECommerceAPI.Application.Features.Commands.Product.UploadProductImage;

public class UploadProductImageCommandRequest : IRequest
{
    public UploadProductImageCommandRequest(IFormFile[]? formFiles, Guid productId)
    {
        this.formFiles = formFiles;
        this.productId = productId;
    }

    public IFormFile[]? formFiles { get; set; }
    public Guid productId { get; set; }
}
