using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public float Price { get; set; }

    public ICollection<Order>? Orders { get; set; }
}
