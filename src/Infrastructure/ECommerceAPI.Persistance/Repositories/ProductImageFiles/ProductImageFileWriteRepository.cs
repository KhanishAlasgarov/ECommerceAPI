using ECommerceAPI.Application.Repositories.ProductImageFiles;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistance.Contexts;

namespace ECommerceAPI.Persistance.Repositories.ProductImageFiles;

public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
{
    public ProductImageFileWriteRepository(BaseDbContext context) : base(context)
    {
    }
}
