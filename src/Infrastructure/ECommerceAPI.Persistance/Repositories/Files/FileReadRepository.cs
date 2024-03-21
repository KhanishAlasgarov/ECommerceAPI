using ECommerceAPI.Application.Repositories.Files;
using ECommerceAPI.Persistance.Contexts;
using FilePath = ECommerceAPI.Domain.Entities;
namespace ECommerceAPI.Persistance.Repositories.Files;

public class FileReadRepository : ReadRepository<FilePath::File>, IFileReadRepository
{
    public FileReadRepository(BaseDbContext context) : base(context)
    {
    }
}
