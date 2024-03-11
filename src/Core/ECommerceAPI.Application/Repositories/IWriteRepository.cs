using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity<Guid>
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    bool Remove(T model);
    bool RemoveRange(List<T> entities);
    Task<bool> RemoveAsync(Guid id);
    bool Update(T model);
    Task<int> SaveAsync();
}