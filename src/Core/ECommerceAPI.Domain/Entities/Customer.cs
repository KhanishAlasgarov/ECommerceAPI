using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public class Customer : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public ICollection<Order>? Orders { get; set; }
}