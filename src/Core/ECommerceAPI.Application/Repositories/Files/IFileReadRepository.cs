using FilePath = ECommerceAPI.Domain.Entities;
namespace ECommerceAPI.Application.Repositories.Files;

public interface IFileReadRepository : IReadRepository<FilePath::File>
{
}
