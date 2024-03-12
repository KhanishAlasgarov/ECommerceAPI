using ECommerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceAPI.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity<Guid>
{
    IQueryable<T> GetAll(bool enableTracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool enableTracking = true);
    Task<T?> GetSignleAsync(Expression<Func<T, bool>> expression, bool enableTracking = true);
    Task<T?> GetByIdAsync(Guid id, bool enableTracking = true);
}
