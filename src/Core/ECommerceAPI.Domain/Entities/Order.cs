using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    public string Description { get; set; } = default!;
    public string Address { get; set; } = default!;
    public ICollection<Product>? Products { get; set; }

    public Customer? Customer { get; set; }
    public Guid CustomerId { get; set; }
}
