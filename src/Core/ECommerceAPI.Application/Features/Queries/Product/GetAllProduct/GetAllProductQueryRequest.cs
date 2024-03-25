using ECommerceAPI.Domain.Common.Paging;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryRequest : PaginateRequest, IRequest<GetAllProductQueryResponse>
{

}
