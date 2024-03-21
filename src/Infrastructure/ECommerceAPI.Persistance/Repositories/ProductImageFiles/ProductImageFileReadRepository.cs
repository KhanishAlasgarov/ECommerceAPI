using ECommerceAPI.Application.Repositories.ProductImageFiles;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistance.Contexts;

namespace ECommerceAPI.Persistance.Repositories.ProductImageFiles;

public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
{
    public ProductImageFileReadRepository(BaseDbContext context) : base(context)
    {
    }
}
