using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace ECommerceAPI.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity<Guid>
{
    public ReadRepository(BaseDbContext context)
    {
        _context = context;
    }
    protected BaseDbContext _context { get; }
    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool enableTracking = true)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return query;
    }



    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool enableTracking = true)
    {
        IQueryable<T> query = Table.Where(expression);

        if (!enableTracking)
            query = query.AsNoTracking();

        return query;
    }

    public async Task<T?> GetSignleAsync(Expression<Func<T, bool>> expression, bool enableTracking = true)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task<T?> GetByIdAsync(Guid id, bool enableTracking = true)
    {
        IQueryable<T> query = Table.AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return await GetSignleAsync(x => x.Id == id, false);

    }




}
