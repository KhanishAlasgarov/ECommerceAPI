using ECommerceAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.Domain.Entities;

public class File : BaseEntity<Guid>
{
    public string FileName { get; set; } = default!;
    public string Path { get; set; } = default!;
    public string Storage { get; set; }
}
