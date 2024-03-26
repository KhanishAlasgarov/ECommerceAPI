using MediatR;

namespace ECommerceAPI.Application.Features.Commands.Product.RemoveProductImage;

public class RemoveProductImageCommandRequest : IRequest
{
    public RemoveProductImageCommandRequest(Guid imageId)
    {
        this.imageId = imageId;
    }

    public Guid imageId { get; set; }
}