using ECommerceAPI.Application.Repositories.InvoiceFiles;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistance.Contexts;

namespace ECommerceAPI.Persistance.Repositories.InvoiceFiles;

public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
{
    public InvoiceFileWriteRepository(BaseDbContext context) : base(context)
    {
    }
}