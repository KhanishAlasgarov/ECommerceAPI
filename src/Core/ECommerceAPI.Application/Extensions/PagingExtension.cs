using ECommerceAPI.Domain.Common.Paging;
using ECommerceAPI.Domain.Entities.Common;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ECommerceAPI.Application.Extensions;

public static partial class Extension
{
    public static TResponse ToPaginate<TResponse>(this
        IQueryable<dynamic> query,
        PaginateRequest paginateRequest
        )
        where TResponse : Paginate, new()
    {

        TResponse response = new TResponse();
        response.SetValue(paginateRequest.Page, paginateRequest.Size, query.Count());

        if (paginateRequest.Page < 1)
        {
            response.Items = Enumerable.Empty<dynamic>();
            return response;
        }
        response.Items = query.SelectIt(paginateRequest?.Fields)?
            .Skip((response.Page - 1) * response.Size).Take(response.Size).ToDynamicList();
        return response;
    }

    private static IQueryable<dynamic>? SelectIt(this IQueryable<dynamic> query, string[]? fields)
    {
        if (fields == null || fields.Length < 1)
            return query;


        return query.Select($"new({string.Join(", ", fields)})") as IQueryable<dynamic>;


    }
}
