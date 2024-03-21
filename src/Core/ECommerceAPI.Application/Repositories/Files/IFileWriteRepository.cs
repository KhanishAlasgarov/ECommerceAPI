using FilePath = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories.Files;

public interface IFileWriteRepository : IWriteRepository<FilePath::File>
{
}
