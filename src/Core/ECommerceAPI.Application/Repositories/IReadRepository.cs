using ECommerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceAPI.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity<Guid>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
    Task<T?> GetSignleAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(Guid id);
}
