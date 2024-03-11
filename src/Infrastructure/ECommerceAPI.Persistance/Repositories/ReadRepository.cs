using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
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

    public IQueryable<T> GetAll()
        => Table.AsQueryable();

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        => Table.Where(expression);

    public async Task<T?> GetSignleAsync(Expression<Func<T, bool>> expression)
        => await Table.FirstOrDefaultAsync(expression);

    public async Task<T?> GetByIdAsync(Guid id)
        => await GetSignleAsync(x => x.Id == id);




}
