using ECommerceAPI.Application.Repositories.Files;
using ECommerceAPI.Persistance.Contexts;
using FilePath = ECommerceAPI.Domain.Entities;
namespace ECommerceAPI.Persistance.Repositories.Files;

public class FileWriteRepository : WriteRepository<FilePath::File>, IFileWriteRepository
{
    public FileWriteRepository(BaseDbContext context) : base(context)
    {
    }
}