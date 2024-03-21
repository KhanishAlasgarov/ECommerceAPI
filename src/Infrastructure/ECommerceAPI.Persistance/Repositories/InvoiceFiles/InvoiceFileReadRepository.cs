using ECommerceAPI.Application.Repositories.Files;
using ECommerceAPI.Application.Repositories.InvoiceFiles;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistance.Contexts;

namespace ECommerceAPI.Persistance.Repositories.InvoiceFiles;

public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
{
    public InvoiceFileReadRepository(BaseDbContext context) : base(context)
    {
    }
}
